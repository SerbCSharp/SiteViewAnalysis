using System.ComponentModel.DataAnnotations;

namespace Repository.Infrastructure.Repositories.Models
{
    public class VisitEntity
    {
        [Key]
        public Guid VisitId { get; set; }
        public string IpAddress { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    }
}
