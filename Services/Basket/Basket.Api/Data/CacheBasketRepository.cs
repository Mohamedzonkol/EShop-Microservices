using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;


namespace Basket.Api.Data
{
    public class CacheBasketRepository(IBasketRepository basketRepository, IDistributedCache cache) : IBasketRepository
    {

        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var cacheBasket = await cache.GetStringAsync(userName, cancellationToken);
            if (!string.IsNullOrEmpty(cacheBasket))
                return JsonSerializer.Deserialize<ShoppingCart>(cacheBasket);
            var basket = await basketRepository.GetBasket(userName, cancellationToken);
            await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(40)
            }, cancellationToken);
            return basket;

        }
        public async Task<ShoppingCart> StoreBasket(ShoppingCart cart, CancellationToken cancellationToken = default)
        {
            await cache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(40)
            }, cancellationToken);
            await basketRepository.StoreBasket(cart, cancellationToken);
            return cart;


        }
        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            await cache.RemoveAsync(userName, cancellationToken);
            return await basketRepository.DeleteBasket(userName, cancellationToken);
        }
    }
}
