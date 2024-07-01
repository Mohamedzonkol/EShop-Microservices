
namespace Basket.Api.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart); /*: ICommand<StoreBasketResult>;*/
    public record StoreBasketResponse(string userName);
    public class StoreBasketEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
                {
                    var command = request.Adapt<StoreBasketCommand>();
                    var result = await sender.Send(command);
                    var response = result.Adapt<StoreBasketResponse>();
                    return Results.Created($"/basket/{response.userName}", response);
                }).WithName("CreateBasket")
                .Produces<StoreBasketResponse>(201)
                .ProducesProblem(400)
                .WithSummary("Create Basket")
                .WithDescription("Store Basket With Minimal Api");

        }
    }
}
