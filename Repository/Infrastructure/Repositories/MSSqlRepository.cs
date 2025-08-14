using Repository.Application.Interfaces;
using Repository.Domain.VisitAggregate;

namespace Repository.Infrastructure.Repositories
{
    public class MSSqlRepository : ISiteVisitsRepository
    {
        public Task<bool> CreateAsync(Visit visit)
        {
            throw new NotImplementedException();
        }

        public Task<List<Visit>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
