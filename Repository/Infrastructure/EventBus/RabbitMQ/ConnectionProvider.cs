using RabbitMQ.Client;

namespace Repository.Infrastructure.EventBus.RabbitMQ
{
    public sealed class ConnectionProvider : IDisposable, IConnectionProvider
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;


        public ConnectionProvider(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.IsOpen)
            {
                _connection?.CloseAsync();
                _connection?.Dispose();
            }
        }

        public async Task<IConnection> GetConnectionAsync()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                _connection = await _connectionFactory.CreateConnectionAsync();
            }

            return _connection;
        }
    }
}
