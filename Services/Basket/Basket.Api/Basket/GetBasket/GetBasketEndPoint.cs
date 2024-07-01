namespace Basket.Api.Basket.GetBasket
{
    // public record GetBasketQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetBasketResult>;
    public record GetBasketReponse(ShoppingCart Cart);
    public class GetBasketEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket", async (string userName, ISender sender) =>
                {
                    var result = await sender.Send(new GetBasketQuery(userName));
                    var response = result.Adapt<GetBasketReponse>();
                    return Results.Ok(response);
                }).WithName("GetBasket")
                .Produces<GetBasketReponse>(200)
                .ProducesProblem(400)
                .WithSummary("Get Basket")
                .WithDescription("Get Basket With Minimal Api");
        }
    }
}
