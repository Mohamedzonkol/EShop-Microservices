namespace Ordering.Domin.Abstractions
{
    public interface IDomainEvent : INotification
    {
        Guid EventId => Guid.NewGuid();
        DateTime OccurredOn => DateTime.Now;
        public string? EventName => GetType().AssemblyQualifiedName;
    }
}