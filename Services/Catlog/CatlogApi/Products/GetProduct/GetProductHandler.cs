using Marten.Pagination;

namespace CatlogApi.Products.GetProduct
{
    public record GetProductQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductResult>;
    public record GetProductResult(IEnumerable<Product> Products);
    public class GetProductHandler(IDocumentSession session)
        : IQueryHandler<GetProductQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            //  logger.LogInformation("Get All Products with {@Query}", request);
            var products = await session.Query<Product>()
                .ToPagedListAsync(request.PageNumber ?? 1, request.PageSize ?? 10, cancellationToken);
            return new GetProductResult(products);
        }
    }
}
