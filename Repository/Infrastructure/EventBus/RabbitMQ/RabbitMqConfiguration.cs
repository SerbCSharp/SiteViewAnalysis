namespace Repository.Infrastructure.EventBus.RabbitMQ
{
    public class RabbitMqConfiguration
    {
        public const string Section = "RabbitMq";
        public string Host { get; set; }
        public string Exchange { get; set; }
    }
}
