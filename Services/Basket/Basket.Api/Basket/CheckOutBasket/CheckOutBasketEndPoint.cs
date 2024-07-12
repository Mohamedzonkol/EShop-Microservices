using Basket.Api.DTOS;

namespace Basket.Api.Basket.CheckOutBasket
{
    public record CheckoutBasketRequest(BasketCheackOutDto BasketCheckoutDto);
    public record CheckoutBasketResponse(bool isSuccess);
    public class CheckOutBasketEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/checkout", async (CheckoutBasketRequest request,
                ISender sender) =>
            {
                var command = request.Adapt<CheckoutBasketCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CheckoutBasketResponse>();
                return Results.Ok(response);
            }).WithName("CheckoutBasket")
            .Produces<CheckoutBasketResponse>(201)
            .ProducesProblem(400)
            .WithSummary("Checkout Basket")
            .WithDescription("Checkout Basket"); ;
        }
    }
}
