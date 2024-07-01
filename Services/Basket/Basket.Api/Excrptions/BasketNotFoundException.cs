using BuildingBlocks.Exception;

namespace Basket.Api.Excrptions
{
    public class BasketNotFoundException(string userName) : NotFoundException($"Basket for user {userName} was not found.");

}
