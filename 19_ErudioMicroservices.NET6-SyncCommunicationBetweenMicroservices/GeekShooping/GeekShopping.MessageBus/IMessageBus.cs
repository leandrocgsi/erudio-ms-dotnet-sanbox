using System;
using System.Threading.Tasks;

namespace GeekShopping.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage message, string topicName);
    }
}