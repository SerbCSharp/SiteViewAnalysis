using Repository.Domain.VisitAggregate;

namespace Repository.Application.Interfaces
{
    public interface ISiteVisitsRepository
    {
        Task<bool> CreateAsync(Visit visit);
        Task<List<Visit>> ReadAllAsync();
    }
}
