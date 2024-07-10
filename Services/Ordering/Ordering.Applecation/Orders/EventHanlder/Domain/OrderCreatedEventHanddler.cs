using Microsoft.Extensions.Logging;

namespace Ordering.Applecation.Orders.EventHanlder.Domain
{
    public class OrderCreatedEventHanddler(ILogger<OrderCreatedEventHanddler> logger) : INotificationHandler<OrderCreateEvent>
    {
        public Task Handle(OrderCreateEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
