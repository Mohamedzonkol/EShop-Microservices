namespace Ordering.Domin.ValueObject
{
    public class Payment
    {
        public string CardNumber { get; } = default!;
        public string CardHolderName { get; } = default!;
        public DateTime Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!;

    }
}
