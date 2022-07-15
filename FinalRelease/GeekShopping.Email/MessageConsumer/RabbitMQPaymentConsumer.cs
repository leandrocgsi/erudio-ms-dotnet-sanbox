using GeekShopping.Email.Messages;
using GeekShopping.Email.Repository;
using GeekShopping.Integration.Enuns;
using GeekShopping.Utils;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShopping.Email.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {
        private readonly EmailRepository _repository;
        private IConnection _connection;
        private IModel _channel;        
        
        public RabbitMQPaymentConsumer(
                EmailRepository repository
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

            _channel.ExchangeDeclare(ExchangeName.DirectPaymentUpdate.GetDescription(), ExchangeType.Direct);
            _channel.QueueDeclare(QueueName.PaymentEmailUpdate.GetDescription(), false, false, false, null);
            _channel.QueueBind(
                    QueueName.PaymentEmailUpdate.GetDescription(), 
                    ExchangeName.DirectPaymentUpdate.GetDescription(),
                    RoutingKey.PaymentEmail.GetDescription()
                );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, evento) =>
            {
                var content = Encoding.UTF8.GetString(evento.Body.ToArray());
                UpdatePaymentResultMessage message = JsonSerializer.Deserialize<UpdatePaymentResultMessage>(content);
                ProcessLogs(message).GetAwaiter().GetResult();
                _channel.BasicAck(evento.DeliveryTag, false);
            };

            _channel.BasicConsume(QueueName.PaymentEmailUpdate.GetDescription(), false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessLogs(UpdatePaymentResultMessage model)
        {
            try
            {
                await _repository.LogEmail(model);
            }
            catch (Exception ex)
            {
                // Log
                throw;
            }
        }
    }
}
