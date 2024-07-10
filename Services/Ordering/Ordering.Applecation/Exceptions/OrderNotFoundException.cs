using BuildingBlocks.Exception;

namespace Ordering.Applecation.Exceptions
{
    public class OrderNotFoundException(Guid id) : NotFoundException("Order", id);
}
