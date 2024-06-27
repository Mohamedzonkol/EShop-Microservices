namespace CatlogApi.Products.GetProductById
{
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/product/{id}", async (ISender sender, Guid id) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            }).Produces<GetProductByIdResponse>(200)
                .ProducesProblem(400)
                .WithSummary("Get Product By Id")
                .WithDescription("Get Product By Id With Minimal Api");
        }
    }
}
