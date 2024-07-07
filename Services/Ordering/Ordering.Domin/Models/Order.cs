namespace Ordering.Domin.Models
{
    public class Order : Aggregate<OrderId>
    {
        private List<OrderItem> _orderItems = [];
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public CustomerId CustomerId { get; private set; } = default!;
        public OrderName OrderName { get; private set; } = default!;
        public Address ShippingAddress { get; private set; } = default!;
        public Address BillingAddress { get; private set; } = default!;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public Payment Payment { get; private set; } = default!;

        public decimal TotalPrice => OrderItems.Sum(x => x.Quantity * x.Price);
    }
}
