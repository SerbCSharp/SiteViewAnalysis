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
        public Task<int> CreateAsync(Visit visit)
        {
            //var priceChangedEvent = new ProductPriceChangedIntegrationEvent(catalogItem.Id, product.Price, oldPrice);
            //_eventBus.Send(priceChangedEvent);
            return _siteVisitsRepository.CreateAsync(visit);
        }

        public Task<List<Visit>> ReadAllAsync()
        {
            return _siteVisitsRepository.ReadAllAsync();
        }
    }
}
