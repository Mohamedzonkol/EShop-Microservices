namespace Ordering.Domin.Abstractions
{
    public abstract class Aggregate<T> : Entity<T>, IAggregate<T>
    {
        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] events = _domainEvents.ToArray();
            _domainEvents.Clear();
            return events;
        }
    }
}