namespace CatlogApi.Products.UpdateProduct
{
    public record UpdateProductRequest(
        Guid Id,
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price) : ICommand<UpdateProductResponse>;

    public record UpdateProductResponse(bool isSuccess);

    public class UpdateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest req,
                    ISender sender) =>
                {
                    var command = req.Adapt<UpdateProductCommand>();
                    var result = await sender.Send(command);
                    var response = result.Adapt<UpdateProductResponse>();
                    return Results.Ok(response);

                })
                .WithName("UpdateProducts")
                .Produces<UpdateProductResponse>(200)
                .ProducesProblem(400)
                .ProducesProblem(404)
                .WithSummary("Update Product")
                .WithDescription("Update Product With Minimal Api");

        }

    }
}


