namespace Repository.Domain.Events
{
    public abstract class EventDomain
    {
        public DateTime Created { get; protected set; }
    }
}
