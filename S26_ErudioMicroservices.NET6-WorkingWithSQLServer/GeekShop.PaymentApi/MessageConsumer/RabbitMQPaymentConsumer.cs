using GeekShop.OrderApi.IRepository;
using GeekShop.PaymentApi.Messages;
using GeekShop.PaymentApi.RabbitMQSender;
using GeekShop.PaymentProcess.IService;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShop.PaymentApi.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IRabbitMQMessageSender _rabbitMQMessageSender;
        private readonly IProcessPayment _processPayment;

        public RabbitMQPaymentConsumer(IProcessPayment processPayment, IRabbitMQMessageSender rabbitMQMessageSender)
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
            _channel.QueueDeclare(queue: "orderpaymentprocessqueue", false, false, false, arguments: null);
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, evento) =>
            {
                var content = Encoding.UTF8.GetString(evento.Body.ToArray());
                PaymentMessage paymentMessage = JsonSerializer.Deserialize<PaymentMessage>(content);
                ProcessPayment(paymentMessage).GetAwaiter().GetResult();
                _channel.BasicAck(evento.DeliveryTag, false);
            };

            _channel.BasicConsume("orderpaymentprocessqueue", false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessPayment(PaymentMessage paymentMessage)
        {
            var result = _processPayment.PaymentProcessor();

            UpdatePaymentResultMessage paymentResult = new()
            {
                Status = result,
                OrderId = paymentMessage.OrderId,
                Email = paymentMessage.Email
            };

            try
            {
                _rabbitMQMessageSender.SendMessage(paymentResult);
            }
            catch (Exception)
            {
                //Log
                throw;
            }
        }
    }
}
