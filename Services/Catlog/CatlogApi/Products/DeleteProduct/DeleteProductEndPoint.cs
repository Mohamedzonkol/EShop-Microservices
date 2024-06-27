namespace CatlogApi.Products.DeleteProduct
{
    //public record DeleteProductRequest(Guid id) : ICommand<DeleteProductResult>;
    public record DeleteProductResponse(bool isSuccess);
    public class DeleteProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));
                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            }).WithName("DeleteProduct")
                .Produces<DeleteProductResponse>(200)
                .ProducesProblem(400)
                .ProducesProblem(404)
                .WithSummary("Delete Product")
                .WithDescription("Delete Product With Minimal Api");

        }
    }
}
