

using GeekShop.MessageBus;

namespace GeekShop.OrderAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
