using Basket.Api.Data;
using Discount.Grpc.Protos;

namespace Basket.Api.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string userName);
    public class StoreBasketHandler(IBasketRepository basketRepository, DiscountService.DiscountServiceClient discountGrpc) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            //communicate with Discount Grpc Services
            foreach (var item in request.Cart.Items)
            {
                var coupon = await discountGrpc.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName });
                item.Price -= coupon.Amount;

            }
            await basketRepository.StoreBasket(request.Cart, cancellationToken);
            return new StoreBasketResult(request.Cart.UserName);
        }
    }

}
