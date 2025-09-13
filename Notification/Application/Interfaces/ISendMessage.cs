using Notification.Models;

namespace Notification.Application.Interfaces
{
    public interface ISendMessage
    {
        Task SendAsync(Message message);
    }
}
