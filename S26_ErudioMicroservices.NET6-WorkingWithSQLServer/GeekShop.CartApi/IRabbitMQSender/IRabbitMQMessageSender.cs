

using GeekShop.MessageBus;

namespace GeekShop.CartApi.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
