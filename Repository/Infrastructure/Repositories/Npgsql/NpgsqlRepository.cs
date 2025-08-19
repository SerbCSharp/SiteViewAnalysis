using Microsoft.EntityFrameworkCore;
using Repository.Application.Interfaces;
using Repository.Domain.VisitAggregate;
using Repository.Infrastructure.Repositories.Models;

namespace Repository.Infrastructure.Repositories.Npgsql
{
    public class NpgsqlRepository : ISiteVisitsRepository
    {
        private readonly SiteViewAnalysisContext _siteViewAnalysisContext;
        public NpgsqlRepository(SiteViewAnalysisContext siteViewAnalysisContext)
        {
            _siteViewAnalysisContext = siteViewAnalysisContext;
        }

        public async Task<int> CreateAsync(Visit visit)
        {
            var visitEntity = new VisitEntity { IpAddress = visit.IpAddress, Url = visit.Url, Created = visit.Created };
            await _siteViewAnalysisContext.Visits.AddAsync(visitEntity);
            return await _siteViewAnalysisContext.SaveChangesAsync();
        }

        public async Task<List<Visit>> ReadAllAsync()
        {
            var visitsEntity = await _siteViewAnalysisContext.Visits.ToListAsync();
            return visitsEntity.Select(x => new Visit { IpAddress = x.IpAddress, Url = x.Url, Created = x.Created.ToLocalTime() }).ToList();
        }
    }
}
