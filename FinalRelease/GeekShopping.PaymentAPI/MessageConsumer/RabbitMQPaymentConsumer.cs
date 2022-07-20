using GeekShopping.Integration.Enuns;
using GeekShopping.PaymentAPI.Messages;
using GeekShopping.PaymentAPI.RabbitMQSender;
using GeekShopping.PaymentProcessor;
using GeekShopping.Utils;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShopping.PaymentAPI.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {        
        private IConnection _connection;
        private IModel _channel;
        private IRabbitMQMessageSender _rabbitMQMessageSender;
        private readonly IProcessPayment _processPayment;
       
        public RabbitMQPaymentConsumer(
                IProcessPayment processPayment,
                IRabbitMQMessageSender rabbitMQMessageSender
            )
        {
            _processPayment = processPayment;
            _rabbitMQMessageSender = rabbitMQMessageSender;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
                        
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(QueueName.OrderPaymentProcess.GetDescription(), false, false, false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested ();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, evento) => 
            {
                var content = Encoding.UTF8.GetString(evento.Body.ToArray());
                PaymentMessage model = JsonSerializer.Deserialize<PaymentMessage>(content);
                ProcessPayment(model).GetAwaiter().GetResult();
                _channel.BasicAck(evento.DeliveryTag, false);
            };

            _channel.BasicConsume(QueueName.OrderPaymentProcess.GetDescription(), false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessPayment(PaymentMessage model)
        {
            var result = _processPayment.PaymentProcessor();
            UpdatePaymentResultMessage paymentResult = new()
            {
                Status = result,
                OrderId = model.OrderId,
                Email = model.Email
            };

            try
            {
                _rabbitMQMessageSender.SendMessage(paymentResult);
            }
            catch (Exception ex)
            {
                // Log
                throw;
            }
        }
    }
}
