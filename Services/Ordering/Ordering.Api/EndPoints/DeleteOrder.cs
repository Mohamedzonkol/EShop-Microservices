using Ordering.Applecation.Orders.Commands.DeleteOrder;

namespace Ordering.Api.EndPoints
{
    public record DeleteOrderResponse(bool IsSuccess);

    public class DeleteOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/orders/{id}", async (Guid Id, ISender sender) =>
            {
                var command = new DeleteOrderCommand(Id);
                var res = await sender.Send(command);
                var response = res.Adapt<DeleteOrderResponse>();
                return Results.Ok(response);
            }).WithName("DeleteOrder")
            .Produces<DeleteOrderResponse>(200)
            .ProducesProblem(404)
            .ProducesProblem(400)
            .WithSummary("Delete Order")
            .WithDescription("Delete Order");
        }
    }
}
