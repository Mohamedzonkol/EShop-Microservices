namespace CatlogApi.Products.GetProduct
{
    public record GetProductQuery() : IQuery<GetProductResult>;
    public record GetProductResult(IEnumerable<Product> Products);
    public class GetProductHandler(IDocumentSession session, ILogger<GetProductHandler> logger)
        : IQueryHandler<GetProductQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get All Products with {@Query}", request);
            var products = await session.Query<Product>().ToListAsync(token: cancellationToken);
            return new GetProductResult(products);
        }
    }
}
