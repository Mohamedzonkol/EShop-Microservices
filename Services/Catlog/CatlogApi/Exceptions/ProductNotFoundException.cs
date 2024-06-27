namespace CatlogApi.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(Guid id) : base($"Product Not Found with Id {id}")
        {
        }
    }
}
