using GeekShopping.MessageBus;
using System;

namespace GeekShopping.OrderAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, String queueName);
    }
}
