namespace CatlogApi.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid id) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool isSuccess);
    public class DeleteProductHnadler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            // logger.LogInformation("Delete Product with {@Command}", command);
            var product = await session.LoadAsync<Product>(command.id, cancellationToken);
            //if (product is null)
            //{
            //    //logger.LogWarning("Product Not Found with Id {Id}", command.id);
            //    throw new ProductNotFoundException(command.id);
            //}
            session.Delete(product);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }


    }
}
