using Microsoft.Extensions.Options;
using Notification.Application.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Notification.Infrastructure.EventBus.RabbitMQ
{
    public class EventBus : BackgroundService
    {
        readonly RabbitMqConfiguration _rabbitMqConfiguration;
        readonly IChannelProvider _channelProvider;
        readonly NotificationService _notificationService;
        private IChannel _channel;

        public EventBus(IOptions<RabbitMqConfiguration> rabbitMqConfiguration, IChannelProvider channelProvider, NotificationService notificationService)
        {
            _channelProvider = channelProvider;
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
            _notificationService = notificationService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _channel = await _channelProvider.GetChannelAsync();

            // Declare the Queue
            var queueArgs = new Dictionary<string, object>
            {
                { "x-queue-type", "quorum" },
                { "x-dead-letter-strategy", "at-least-once" },
                { "overflow", "reject-publish" }
            };
            await _channel.ExchangeDeclareAsync(exchange: _rabbitMqConfiguration.Exchange, type: ExchangeType.Direct, durable: true);
            await _channel.QueueDeclareAsync(queue: _rabbitMqConfiguration.Queue, durable: true, exclusive: false, autoDelete: false, arguments: queueArgs);
            await _channel.QueueBindAsync(queue: _rabbitMqConfiguration.Queue, exchange: _rabbitMqConfiguration.Exchange, routingKey: "VisitCreateEvent");

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await _notificationService.NotificationAsync(message);
                await _channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
            };

            await _channel.BasicConsumeAsync(queue: _rabbitMqConfiguration.Queue, autoAck: false, consumer: consumer);
        }
    }
}
