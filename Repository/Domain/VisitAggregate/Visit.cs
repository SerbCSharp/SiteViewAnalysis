namespace Repository.Domain.VisitAggregate
{
    public class Visit
    {
        public Visit(string ipAddress, string url, DateTime created)
        {
            IpAddress = ipAddress;
            Url = url;
            Created = created;
        }

        public string IpAddress { get; }
        public string Url { get; }
        public DateTime Created { get; }
    }
}
