using Microsoft.EntityFrameworkCore;
using Repository.Application.Interfaces;
using Repository.Domain.VisitAggregate;
using Repository.Infrastructure.Repositories.Models;

namespace Repository.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository : ISiteVisitsRepository
    {
        private readonly SiteViewAnalysisContext _siteViewAnalysisContext;
        public MSSqlRepository(SiteViewAnalysisContext siteViewAnalysisContext)
        {
            _siteViewAnalysisContext = siteViewAnalysisContext;
        }

        public async Task CreateAsync(Visit visit)
        {
            var visitEntity = new VisitEntity { IpAddress = visit.IpAddress, Url = visit.Url, Created = visit.Created };
            await _siteViewAnalysisContext.Visits.AddAsync(visitEntity);
            await _siteViewAnalysisContext.SaveChangesAsync();
        }

        public async Task<List<Visit>> ReadAllAsync()
        {
            var visitsEntity = await _siteViewAnalysisContext.Visits.ToListAsync();
            return visitsEntity.Select(x => new Visit(x.IpAddress, x.Url, x.Created)).ToList();
        }
    }
}
