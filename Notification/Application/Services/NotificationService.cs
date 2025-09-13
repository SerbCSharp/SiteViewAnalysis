using Notification.Application.Interfaces;
using Notification.Models;

namespace Notification.Application.Services
{
    public class NotificationService
    {
        private readonly ISendMessage _sendMessage;

        public NotificationService(ISendMessage sendMessage)
        {
            _sendMessage = sendMessage;
        }

        public async Task NotificationAsync(Message message)
        {
            await _sendMessage.SendAsync(message);
        }
    }
}
