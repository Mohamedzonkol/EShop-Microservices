using Basket.Api.Data;
using Basket.Api.DTOS;
using BuildingBlocks.Masseging.Event;
using MassTransit;

namespace Basket.Api.Basket.CheckOutBasket
{
    public record CheckoutBasketCommand(BasketCheackOutDto BasketCheckoutDto)
        : ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResult(bool IsSuccess);
    public class CheckOutBasketHandler(IBasketRepository basketRepository, IPublishEndpoint publishEndpoint)
        : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await basketRepository.GetBasket(request.BasketCheckoutDto.UserName, cancellationToken);
            if (basket is null)
                return new CheckoutBasketResult(false);
            var eventMessage = request.BasketCheckoutDto.Adapt<BasketCheackOut>();
            eventMessage.TotalPrice = basket.TotalPrice;
            await publishEndpoint.Publish(eventMessage, cancellationToken);
            await basketRepository.DeleteBasket(request.BasketCheckoutDto.UserName, cancellationToken);
            return new CheckoutBasketResult(true);
        }
    }

}
