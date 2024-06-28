namespace CatlogApi.Products.GetProduct
{
    public record GetProductRequest(int? PageNumber = 1, int? PageSize = 10);

    public record GetProductResponse(IEnumerable<Product> Products);
    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductRequest request, ISender sender) =>
                {
                    var query = request.Adapt<GetProductQuery>();
                    var result = await sender.Send(query);
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
