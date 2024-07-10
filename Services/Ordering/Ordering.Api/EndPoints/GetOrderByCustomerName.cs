using Ordering.Applecation.Orders.Queries.GetOrderByCustomer;

namespace Ordering.Api.EndPoints
{
    public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);

    public class GetOrderByCustomerName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/customer/{customerId}", async (Guid customerId, ISender sender) =>
                {
                    var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));

                    var response = result.Adapt<GetOrdersByCustomerResponse>();

                    return Results.Ok(response);
                })
                .WithName("GetOrdersByCustomer")
                .Produces<GetOrdersByCustomerResponse>(200)
                .ProducesProblem(404)
                .WithSummary("Get Orders By Customer")
                .WithDescription("Get Orders By Customer");
        }
    }
}
