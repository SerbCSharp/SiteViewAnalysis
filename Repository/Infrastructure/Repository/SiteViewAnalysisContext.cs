using Microsoft.EntityFrameworkCore;
using Repository.Infrastructure.Repository.Models;

namespace Repository.Infrastructure.Repository
{
    public class SiteViewAnalysisContext : DbContext
    {
        public SiteViewAnalysisContext(DbContextOptions<SiteViewAnalysisContext> options) : base(options) { }

        public DbSet<Visit> Visits { get; set; }
    }
}
