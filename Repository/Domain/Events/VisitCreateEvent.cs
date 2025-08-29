using Repository.Domain.VisitAggregate;

namespace Repository.Domain.Events
{
    public class VisitCreateEvent : EventDomain
    {
        public VisitCreateEvent(Visit visit)
        {
            IpAddress = visit.IpAddress;
            Url = visit.Url;
            Created = visit.Created;
        }
        public string IpAddress { get; }
        public string Url { get; }
    }
}
