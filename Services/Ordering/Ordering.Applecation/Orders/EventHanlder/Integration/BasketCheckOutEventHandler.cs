﻿
namespace Ordering.Applecation.Orders.EventHanlder.Integration
{
    internal class BasketCheckOutEventHandler(ISender sender, ILogger<BasketCheckOutEventHandler> logger)
        : IConsumer<BasketCheackOut>
    {
        public async Task Consume(ConsumeContext<BasketCheackOut> context)
        {
            logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);
            var command = MapToCreateOrderCommand(context.Message);
            await sender.Send(command);
        }

        private CreateOrderCommand MapToCreateOrderCommand(BasketCheackOut message)
        {
            var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress,
                message.AddressLine, message.Country, message.State, message.ZipCode);
            var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV,
                message.PaymentMethod);
            var orderId = Guid.NewGuid();
            var orderDto = new OrderDto(
                Id: orderId,
                CustomerId: message.CustomerId,
                OrderName: message.UserName,
                ShippingAddress: addressDto,
                BillingAddress: addressDto,
                Payment: paymentDto,
                Status: OrderStatus.Pending,
                OrderItems:
                [
                    new OrderItemDto(orderId, new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"), 2, 500),
                    new OrderItemDto(orderId, new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"), 1, 400)
                ]);
            return new CreateOrderCommand(orderDto);
        }
    }
}
