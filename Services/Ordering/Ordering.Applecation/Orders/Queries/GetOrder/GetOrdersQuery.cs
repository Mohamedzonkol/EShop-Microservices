namespace Ordering.Applecation.Orders.Queries.GetOrder
{
    public record GetOrdersQuery(PaginationRequest PaginationRequest)
        : IQuery<GetOrdersResult>;

    public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
}
