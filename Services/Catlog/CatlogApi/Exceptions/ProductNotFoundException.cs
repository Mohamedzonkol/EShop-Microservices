using BuildingBlocks.Exception;

namespace CatlogApi.Exceptions
{
    public class ProductNotFoundException(string userName) : NotFoundException($"Basket for user {userName} is not found");
}
