using Ordering.Applecation.Orders.Queries.GetOrder;

namespace Ordering.Api.EndPoints
{
    public record GetOrdersResponse(PaginatedResult<OrderDto> Orders);
    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersQuery(request));

                var response = result.Adapt<GetOrdersResponse>();

                return Results.Ok(response);
            }).WithName("GetOrders")
            .Produces<GetOrdersResponse>(200)
            .ProducesProblem(400)
            .ProducesProblem(404)
            .WithSummary("Get Orders")
            .WithDescription("Get Orders");
        }
    }
}
