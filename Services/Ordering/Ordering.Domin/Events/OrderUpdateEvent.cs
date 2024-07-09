namespace Ordering.Domin.Events
{
    public record OrderUpdateEvent(Order order) : IDomainEvent;
}