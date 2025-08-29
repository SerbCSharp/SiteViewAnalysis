using RabbitMQ.Client;

namespace Repository.Infrastructure.EventBus.RabbitMQ
{
    public interface IChannelProvider
    {
        Task<IChannel> GetChannelAsync();
    }
}
