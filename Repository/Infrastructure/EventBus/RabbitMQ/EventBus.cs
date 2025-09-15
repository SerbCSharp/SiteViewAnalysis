using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Repository.Application.Interfaces;
using Repository.Domain.Events;
using System.Text;

namespace Repository.Infrastructure.EventBus.RabbitMQ
{
    public class EventBus : INotification
    {
        readonly RabbitMqConfiguration _rabbitMqConfiguration;

        public EventBus(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
        }

        public async Task SendAsync(EventDomain eventDomain)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eventDomain));

            var factory = new ConnectionFactory { HostName = _rabbitMqConfiguration.Host };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(exchange: _rabbitMqConfiguration.Exchange, type: ExchangeType.Direct, durable: true);
            await channel.BasicPublishAsync(exchange: _rabbitMqConfiguration.Exchange, routingKey: eventDomain.GetType().Name, body: body);
        }
    }
}
