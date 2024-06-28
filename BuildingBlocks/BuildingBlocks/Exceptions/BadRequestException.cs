namespace BuildingBlocks.Exceptions
{
    public class BadRequestException : System.Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }

    }
}
