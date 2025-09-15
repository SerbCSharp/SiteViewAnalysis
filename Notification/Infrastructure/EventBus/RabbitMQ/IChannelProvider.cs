using RabbitMQ.Client;

namespace Notification.Infrastructure.EventBus.RabbitMQ
{
    public interface IChannelProvider
    {
        Task<IChannel> GetChannelAsync();
    }
}
