namespace Basket.Api.Basket.GetBasket
{
    // public record GetBasketQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetBasketResult>;
    public record GetBasketResponse(ShoppingCart Cart);
    public class GetBasketEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
                {
                    var result = await sender.Send(new GetBasketQuery(userName));
                    var response = result.Adapt<GetBasketResponse>();
                    return Results.Ok(response);
                }).WithName("GetProductById")
        .Produces<GetBasketResponse>(200)
        .ProducesProblem(400)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
        }
    }
}
