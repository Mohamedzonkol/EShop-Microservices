using Marten;

namespace Basket.Api.Data
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);
            return basket is null ? throw new b



        }

        public Task<ShoppingCart> StoreBasket(ShoppingCart cart, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(cart);
        }

        public Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }
}
