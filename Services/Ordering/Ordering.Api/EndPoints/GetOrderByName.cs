using Ordering.Applecation.Orders.Queries.GetOrderByName;
namespace Ordering.Api.EndPoints
{
    public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);

    public class GetOrderByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{name}", async (string name, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByNameQuery(name));

                var response = result.Adapt<GetOrdersByNameResponse>();

                return Results.Ok(response);
            }).WithName("GetOrderByName")
            .Produces<GetOrdersByNameResponse>(200)
            .ProducesProblem(400)
            .ProducesProblem(404)
            .WithSummary("Get Order By Name")
            .WithDescription("Get Order By Name");
        }
    }
}
