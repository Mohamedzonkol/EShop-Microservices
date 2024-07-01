
namespace Basket.Api.Basket.DeleteBasket
{
    public record DeleteBasketRespone(bool IsSuccess);
    public class DeleteBasketEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
                {
                    var command = new DeleteBasketCommand(userName);
                    var result = await sender.Send(command);
                    var response = result.Adapt<DeleteBasketRespone>();
                    return Results.Ok(response);
                }).WithName("DeleteBasket")
                .Produces<DeleteBasketRespone>(200)
                .ProducesProblem(400)
                .WithSummary("Delete Basket")
                .WithDescription("Delete Basket With Minimal Api");

        }
    }
}
