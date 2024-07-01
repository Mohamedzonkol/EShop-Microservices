using BuildingBlocks.Exception;

namespace CatlogApi.Exceptions
{
    public class ProductNotFoundException(Guid id) : NotFoundException($"Product with id {id} is not found");
}
