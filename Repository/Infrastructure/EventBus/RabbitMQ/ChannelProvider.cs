using RabbitMQ.Client;

namespace Repository.Infrastructure.EventBus.RabbitMQ
{
    public sealed class ChannelProvider : IDisposable, IChannelProvider
    {
        private readonly IConnectionProvider _connectionProvider;
        private IChannel _channel;

        public ChannelProvider(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public void Dispose()
        {
            if (_channel != null && _channel.IsOpen)
            {
                _channel?.CloseAsync();
                _channel?.Dispose();
            }
        }

        public async Task<IChannel> GetChannelAsync()
        {
            if (_channel == null || !_channel.IsOpen)
            {
                var connection = await _connectionProvider.GetConnectionAsync();
                _channel = await connection.CreateChannelAsync();
            }

            return _channel;
        }
    }
}
