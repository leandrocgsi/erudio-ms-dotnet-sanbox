using GeekShopping.OrderAPI.Messages;
using GeekShopping.OrderAPI.Repository;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShopping.OrderAPI.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {
        private readonly OrderRepository _repository;
        private IConnection _connection;
        private IModel _channel;
        private const string ExchangeName = "DirectPaymentUpdateExchange";
        private const string PaymentOrderUpdateQueueName = "PaymentOrderUpdateQueueName";

        public RabbitMQPaymentConsumer(
                OrderRepository repository                
            )
        {
            _repository = repository;
            
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
                        
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(PaymentOrderUpdateQueueName, false, false, false, null);
            _channel.QueueBind(PaymentOrderUpdateQueueName, ExchangeName, "PaymentOrder");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested ();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, evento) => 
            {
                var content = Encoding.UTF8.GetString(evento.Body.ToArray());
                UpdatePaymentResultDTO model = JsonSerializer.Deserialize<UpdatePaymentResultDTO>(content);
                UpdatePaymentStatus(model).GetAwaiter().GetResult();
                _channel.BasicAck(evento.DeliveryTag, false);
            };

            _channel.BasicConsume(PaymentOrderUpdateQueueName, false, consumer);
            return Task.CompletedTask;
        }

        private async Task UpdatePaymentStatus(UpdatePaymentResultDTO model)
        {
            try
            {
                await _repository.UpdateOrderPaymentStatus(model.OrderId, model.Status);
            }
            catch (Exception ex)
            {
                // Log
                throw;
            }
        }       
    }
}
