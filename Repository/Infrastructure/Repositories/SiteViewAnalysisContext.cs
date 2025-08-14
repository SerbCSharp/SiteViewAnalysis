using Microsoft.EntityFrameworkCore;
using Repository.Infrastructure.Repositories.Models;

namespace Repository.Infrastructure.Repositories
{
    public class SiteViewAnalysisContext : DbContext
    {
        public SiteViewAnalysisContext(DbContextOptions<SiteViewAnalysisContext> options) : base(options) { }

        public DbSet<VisitEntity> Visits { get; set; }
    }
}
