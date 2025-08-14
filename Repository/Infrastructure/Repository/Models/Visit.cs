namespace Repository.Infrastructure.Repository.Models
{
    public class Visit
    {
        public string IpAddress { get; set; }
        public string Url { get; set; }
        public DateTime Created => DateTime.UtcNow;
    }
}
