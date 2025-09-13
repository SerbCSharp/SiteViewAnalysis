using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Notification.Application.Interfaces;
using Notification.Models;
using Telegram.Bot;

namespace Notification.Presentation.Controllers
{
    [ApiController]
    [Route("/")]
    public class TelegramController : ControllerBase, ISendMessage
    {
        private readonly TelegramConfiguration _telegramConfiguration;

        public TelegramController(IOptions<TelegramConfiguration> telegramConfiguration)
        {
            _telegramConfiguration = telegramConfiguration.Value;
        }

        [HttpPost]
        public async Task SendAsync(Message message)
        {
            var client = new TelegramBotClient(_telegramConfiguration.BotToken);
            //await client.SendTextMessageAsync(_telegramConfiguration.ChatId, message);
        }
    }
}
