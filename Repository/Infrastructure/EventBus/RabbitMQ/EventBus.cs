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
        readonly IChannelProvider _channelProvider;
        readonly string _exchange;

        public EventBus(IOptions<RabbitMqConfiguration> rabbitMqConfiguration, IChannelProvider channelProvider)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
            _exchange = _rabbitMqConfiguration.Exchange;
            _channelProvider = channelProvider;
        }

        public async Task SendAsync(EventDomain eventDomain)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eventDomain));
            var channel = await _channelProvider.GetChannelAsync();
            await channel.ExchangeDeclareAsync(exchange: _exchange, type: ExchangeType.Direct, durable: true);

            await channel.BasicPublishAsync(exchange: _exchange, routingKey: eventDomain.GetType().Name, body: body);
        }
    }
}
