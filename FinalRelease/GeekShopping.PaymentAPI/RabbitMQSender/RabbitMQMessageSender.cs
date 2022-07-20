using GeekShopping.Integration.Enuns;
using GeekShopping.MessageBus;
using GeekShopping.PaymentAPI.Messages;
using GeekShopping.Utils;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GeekShopping.PaymentAPI.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;       

        public RabbitMQMessageSender()
        {
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
        }

        public void SendMessage(BaseMessage message)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();
                channel.ExchangeDeclare(ExchangeName.DirectPaymentUpdate.GetDescription(), ExchangeType.Direct, durable: false);
                
                channel.QueueDeclare(QueueName.PaymentEmailUpdate.GetDescription(), false, false, false, null);
                channel.QueueDeclare(QueueName.PaymentOrderUpdate.GetDescription(), false, false, false, null);

                channel.QueueBind(
                        QueueName.PaymentEmailUpdate.GetDescription(), 
                        ExchangeName.DirectPaymentUpdate.GetDescription(), 
                        RoutingKey.PaymentEmail.GetDescription()
                    );

                channel.QueueBind(
                        QueueName.PaymentOrderUpdate.GetDescription(), 
                        ExchangeName.DirectPaymentUpdate.GetDescription(),
                        RoutingKey.PaymentOrder.GetDescription()
                    );

                byte[] body = GetMessageAsByteArray(message);
                channel.BasicPublish(
                        exchange: ExchangeName.DirectPaymentUpdate.GetDescription(),
                        RoutingKey.PaymentEmail.GetDescription(), 
                        basicProperties: null, 
                        body: body
                    );
                channel.BasicPublish(
                        exchange: ExchangeName.DirectPaymentUpdate.GetDescription(),
                        RoutingKey.PaymentOrder.GetDescription(), 
                        basicProperties: null, 
                        body: body
                    );
            }
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize<UpdatePaymentResultMessage>(
                    (UpdatePaymentResultMessage)message, 
                    options
                );

            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
                return true;

            CreateConnection();

            return _connection != null;
        }        
    }
}
