using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Notification.Application.Services
{
    public class NotificationService
    {
        private readonly TelegramConfiguration _telegramConfiguration;

        public NotificationService(IOptions<TelegramConfiguration> telegramConfiguration)
        {
            _telegramConfiguration = telegramConfiguration.Value;
        }

        public async Task NotificationAsync(string message)
        {
            var client = new TelegramBotClient(_telegramConfiguration.BotToken);
            await client.SendTextMessageAsync(new ChatId(_telegramConfiguration.ChatId), message);
        }
    }
}
