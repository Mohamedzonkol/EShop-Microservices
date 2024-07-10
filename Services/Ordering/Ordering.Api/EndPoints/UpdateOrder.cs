namespace Ordering.Api.EndPoints
{
    public record UpdateOrderRequest(OrderDto Order);
    public record UpdateOrderResponse(bool IsSuccess);

    public class UpdateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/orders", async (UpdateOrderResponse req, ISender sender) =>
                {
                    var command = req.Adapt<UpdateOrderCommand>();
                    var res = await sender.Send(command);
                    var response = res.Adapt<UpdateOrderResponse>();
                    return Results.Ok(response);
                }).WithName("UpdateOrder")
                .Produces<UpdateOrderResponse>(200)
                .ProducesProblem(400)
                .WithSummary("Update Order")
                .WithDescription("Update Order");
        }
    }
}
