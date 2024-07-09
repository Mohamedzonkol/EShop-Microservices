namespace Ordering.Domin.Events
{
    public record OrderCreateEvent(Order order) : IDomainEvent;
}