using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Notification.Infrastructure.EventBus.RabbitMQ
{
    public class ConnectionProvider : IDisposable, IConnectionProvider
    {
        readonly RabbitMqConfiguration _rabbitMqConfiguration;
        private IConnection _connection;

        public ConnectionProvider(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
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
                var factory = new ConnectionFactory { HostName = _rabbitMqConfiguration.Host };
                _connection = await factory.CreateConnectionAsync();
            }

            return _connection;
        }
    }
}
