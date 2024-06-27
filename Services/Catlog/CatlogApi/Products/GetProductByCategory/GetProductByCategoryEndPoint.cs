using CatlogApi.Products.GetProductById;

namespace CatlogApi.Products.GetProductByCategory
{
    public record GetProductByCategoryResponse(Product Product);

    public class GetProductByCategoryEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/product/{category}", async (string category, ISender sender) =>
                {
                    var result = await sender.Send(new GetProductByCategoryQuery(category));
                    var response = result.Adapt<GetProductByCategoryResponse>();
                    return Results.Ok(response);
                }).WithName("GetProductByCategory")
             .Produces<GetProductByIdResponse>(200)
             .ProducesProblem(400)
             .WithSummary("Get Product By Category")
             .WithDescription("Get Product By Category With Minimal Api");

        }
    }
}
