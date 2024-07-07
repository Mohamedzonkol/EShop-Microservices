namespace Ordering.Domin.Models
{
    public class Order : Aggregate<Guid>
    {
        private List<OrderItem> _orderItems = [];
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public Guid CustomerId { get; private set; } = default!;
        public string OrderName { get; private set; } = default!;
        public Address ShippingAddress { get; private set; } = default!;
        public Address BillingAddress { get; private set; } = default!;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public Payment Payment { get; private set; } = default!;

        public decimal TotalPrice => OrderItems.Sum(x => x.Quantity * x.Price);
    }
}
