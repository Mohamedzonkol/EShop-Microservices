using BuildingBlocks.CQRS;

namespace Ordering.Applecation.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;
    public record CreateOrderResult(Guid Id);
}
