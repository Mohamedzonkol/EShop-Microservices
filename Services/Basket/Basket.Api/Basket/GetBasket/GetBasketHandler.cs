using Basket.Api.Data;

namespace Basket.Api.Basket.GetBasket
{
    public record GetBasketQuery(string userName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketHandler(IBasketRepository basketRepository) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            return new GetBasketResult(new ShoppingCart("Sunny"));
        }
    }

}
