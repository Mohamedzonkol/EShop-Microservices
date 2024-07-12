namespace Ordering.Applecation.Orders.EventHanlder.Domain
{
    public class OrderCreatedEventHanddler(IPublishEndpoint publishEndpoint, IFeatureManager featureManager,
        ILogger<OrderCreatedEventHanddler> logger) : INotificationHandler<OrderCreateEvent>
    {
        public async Task Handle(OrderCreateEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            if (await featureManager.IsEnabledAsync("OrderFillFeature"))
            {
                var orderCreatedIntegrationEvent = notification.order.ToOrderDto();
                await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
            }
        }
    }
}
