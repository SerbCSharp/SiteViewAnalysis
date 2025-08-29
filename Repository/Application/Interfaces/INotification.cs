using Repository.Domain.Events;

namespace Repository.Application.Interfaces
{
    public interface INotification
    {
        Task SendAsync(EventDomain eventDomain);
    }
}
