namespace Notification.Application
{
    public class TelegramConfiguration
    {
        public const string Section = "TelegramConfiguration";
        public string BotToken { get; set; }
        public string ChatId { get; set; }
    }
}
