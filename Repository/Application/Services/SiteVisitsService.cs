using Repository.Application.Interfaces;
using Repository.Domain.VisitAggregate;

namespace Repository.Application.Services
{
    public class SiteVisitsService
    {
        private readonly ISiteVisitsRepository _siteVisitsRepository;
        public SiteVisitsService(ISiteVisitsRepository siteVisitsRepository)
        {
            _siteVisitsRepository = siteVisitsRepository;
        }
        public Task<bool> CreateAsync(Visit visit)
        {
            return _siteVisitsRepository.CreateAsync(visit);
        }

        public Task<List<Visit>> ReadAllAsync()
        {
            return _siteVisitsRepository.ReadAllAsync();
        }
    }
}
