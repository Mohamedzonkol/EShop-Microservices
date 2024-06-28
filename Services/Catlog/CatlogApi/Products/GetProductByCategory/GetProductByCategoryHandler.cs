namespace CatlogApi.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public class GetProductByCategoryHandler(IDocumentSession session)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            // logger.LogInformation("Get Product By Category with {@Query}", request);
            var product = await session.Query<Product>().Where(x => x.Category.Contains(request.category))
                .ToListAsync(cancellationToken);
            return new GetProductByCategoryResult(product);
        }
    }
}
