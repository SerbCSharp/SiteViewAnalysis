using RabbitMQ.Client;

namespace Notification.Infrastructure.EventBus.RabbitMQ
{
    public interface IConnectionProvider
    {
        Task<IConnection> GetConnectionAsync();
    }
}
