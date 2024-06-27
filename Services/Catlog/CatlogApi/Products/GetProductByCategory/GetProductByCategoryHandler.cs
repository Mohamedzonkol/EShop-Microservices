namespace CatlogApi.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(Product Product);
    public class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get Product By Category with {@Query}", request);
            var product = await session.LoadAsync<Product>(request.category, cancellationToken);
            if (product is null)
            {
                logger.LogWarning("Product Not Found with Category {Category}", request.category);
                throw new ProductNotFoundException();
            }
            return new GetProductByCategoryResult(product);
        }
    }
}
