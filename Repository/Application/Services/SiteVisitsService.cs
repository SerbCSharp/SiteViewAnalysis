using Repository.Application.Interfaces;
using Repository.Domain.Events;
using Repository.Domain.VisitAggregate;

namespace Repository.Application.Services
{
    public class SiteVisitsService
    {
        private readonly ISiteVisitsRepository _siteVisitsRepository;
        private readonly INotification _notification;
        public SiteVisitsService(ISiteVisitsRepository siteVisitsRepository, INotification notification)
        {
            _siteVisitsRepository = siteVisitsRepository;
            _notification = notification;
        }

        public async Task CreateAsync(Visit visit)
        {
            var visitCreateEvent = new VisitCreateEvent(visit);
            await _notification.SendAsync(visitCreateEvent);
            await _siteVisitsRepository.CreateAsync(visit);

        }

        public async Task<List<Visit>> ReadAllAsync()
        {
            return await _siteVisitsRepository.ReadAllAsync();
        }
    }
}
