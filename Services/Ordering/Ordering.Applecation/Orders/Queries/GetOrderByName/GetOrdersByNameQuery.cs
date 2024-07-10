namespace Ordering.Applecation.Orders.Queries.GetOrderByName
{
    public record GetOrdersByNameQuery(string Name)
        : IQuery<GetOrdersByNameResult>;

    public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);
}
