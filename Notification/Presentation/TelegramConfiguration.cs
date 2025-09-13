using Telegram.Bot.Types;

namespace Notification.Presentation
{
    public class TelegramConfiguration
    {
        public const string Section = "TelegramConfiguration";
        public string BotToken { get; set; }
        public ChatId ChatId { get; set; }

    }
}
