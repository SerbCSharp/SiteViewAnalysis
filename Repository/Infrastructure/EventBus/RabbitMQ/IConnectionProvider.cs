using RabbitMQ.Client;

namespace Repository.Infrastructure.EventBus.RabbitMQ
{
    public interface IConnectionProvider
    {
        Task<IConnection> GetConnectionAsync();
    }
}
