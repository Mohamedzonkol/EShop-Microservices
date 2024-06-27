namespace CatlogApi.Products.GetProductById
{
    public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    public class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductByIdHandler> logger)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get Product By Id with {@Query}", request);
            var product = await session.LoadAsync<Product>(request.id, cancellationToken);
            if (product is null)
            {
                logger.LogWarning("Product Not Found with Id {Id}", request.id);
                throw new ProductNotFoundException(request.id);
            }
            return new GetProductByIdResult(product);
        }
    }
}
