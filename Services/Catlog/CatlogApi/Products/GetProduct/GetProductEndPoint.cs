namespace CatlogApi.Products.GetProduct
{
    public record GetProductResponse(IEnumerable<Product> Products);
    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductQuery());
                var response = result.Adapt<GetProductResponse>();
                return Results.Ok(response);
            }).WithName("GetProducts")
                .Produces<GetProductResponse>(200)
                .ProducesProblem(400)
                .WithSummary("Get All Products")
                .WithDescription("Get All Products With Minimal Api");

        }
    }
}
