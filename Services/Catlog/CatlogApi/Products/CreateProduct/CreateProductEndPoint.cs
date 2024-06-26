namespace CatlogApi.Products.CreateProduct
{
    public record CreateProductRequest(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price) : ICommand<CreateProductResponse>;

    public record CreateProductResponse(Guid Id);
    public class CreateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest req,
                    ISender sender) =>
                {
                    var command = req.Adapt<CreateProductCommand>();
                    var result = await sender.Send(command);
                    var response = result.Adapt<CreateProductResponse>();
                    return Results.Created($"/products/{response.Id}", response);

                })
                .WithName("CreateProducts")
                .Produces<CreateProductResponse>(201)
                .ProducesProblem(400)
                .WithSummary("Create New Product")
                .WithDescription("Create New Product With Minimal Api");

        }
    }
}
