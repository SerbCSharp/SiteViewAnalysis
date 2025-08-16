using Repository.Domain.VisitAggregate;

namespace Repository.Application.Interfaces
{
    public interface ISiteVisitsRepository
    {
        Task<int> CreateAsync(Visit visit);
        Task<List<Visit>> ReadAllAsync();
    }
}
