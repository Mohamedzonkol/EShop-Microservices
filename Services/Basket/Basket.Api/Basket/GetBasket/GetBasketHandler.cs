namespace Basket.Api.Basket.GetBasket
{
    public record GetBasketQuery(string userName/*int? PageNumber = 1, int? PageSize = 10*/) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            return new GetBasketResult(new ShoppingCart("Sunny"));
        }
    }

}
