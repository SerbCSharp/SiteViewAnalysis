using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Notification.Infrastructure.EventBus.RabbitMQ
{
    public class EventBus
    {
        readonly RabbitMqConfiguration _rabbitMqConfiguration;

        public EventBus(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
        }

        public async Task ReceiveAsync()
        {
            var factory = new ConnectionFactory { HostName = _rabbitMqConfiguration.Host };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            // Declare the Queue
            var queueArgs = new Dictionary<string, object>
            {
                { "x-queue-type", "quorum" },
                { "x-dead-letter-strategy", "at-least-once" },
                { "overflow", "reject-publish" }
            };
            await channel.ExchangeDeclareAsync(exchange: _rabbitMqConfiguration.Exchange, type: ExchangeType.Direct, durable: true);
            await channel.QueueDeclareAsync(queue: _rabbitMqConfiguration.Queue, durable: true, exclusive: false, autoDelete: false, arguments: queueArgs);
            await channel.QueueBindAsync(queue: _rabbitMqConfiguration.Queue, exchange: _rabbitMqConfiguration.Exchange, routingKey: "VisitCreateEvent");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
                channel.BasicAckAsync(ea.DeliveryTag, false);
                return Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(queue: _rabbitMqConfiguration.Queue, autoAck: false, consumer: consumer);
        }
    }
}
