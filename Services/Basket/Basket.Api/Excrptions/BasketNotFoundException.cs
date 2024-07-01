using BuildingBlocks.Exception;

namespace Basket.Api.Excrptions
{
    public class BasketNotFoundException(Guid id) : NotFoundException($"Basket with id {id} was not found.");

}
