using GeekShop.MessageBus;

namespace GeekShop.PaymentApi.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}
