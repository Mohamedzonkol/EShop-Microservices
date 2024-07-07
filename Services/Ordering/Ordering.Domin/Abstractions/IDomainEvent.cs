using MediatR;

namespace Ordering.Domin.Abstractions
{
    public interface IDomainEvent : INotification
    {
        Guid EventId => Guid.NewGuid();
        DateTime OccurredOn => DateTime.UtcNow;
        public string? EventName => GetType().AssemblyQualifiedName;
    }
}
