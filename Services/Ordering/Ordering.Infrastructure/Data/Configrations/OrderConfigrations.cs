namespace Ordering.Infrastructure.Data.Configrations
{
    public class OrderConfigrations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(
                OrderId => OrderId.Value,
                dbId => OrderId.Of(dbId));
            builder.HasOne<Customer>().WithMany().HasForeignKey(x => x.CustomerId).IsRequired();
            builder.HasMany<OrderItem>().WithOne().HasForeignKey(x => x.OrderId);
            builder.ComplexProperty(o => o.OrderName, nameBulder =>
            {
                nameBulder.Property(x => x.Value).HasColumnName(nameof(Order.OrderName)).IsRequired().HasMaxLength(100);
            });
            builder.ComplexProperty(o => o.ShippingAddress, builderName =>
            {
                builderName.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
                builderName.Property(x => x.LastName).IsRequired().HasMaxLength(50);
                builderName.Property(x => x.AddressLine).HasMaxLength(180);
                builderName.Property(x => x.Country).HasMaxLength(60);
                builderName.Property(x => x.EmailAddress).IsRequired().HasMaxLength(60);
                builderName.Property(x => x.State).HasMaxLength(20);
                builderName.Property(x => x.ZipCode).HasMaxLength(8);
            });
            builder.ComplexProperty(
                o => o.BillingAddress, addressBuilder =>
                {
                    addressBuilder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
                    addressBuilder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
                    addressBuilder.Property(a => a.EmailAddress).HasMaxLength(50);
                    addressBuilder.Property(a => a.AddressLine).HasMaxLength(180).IsRequired();
                    addressBuilder.Property(a => a.Country).HasMaxLength(50);
                    addressBuilder.Property(a => a.State).HasMaxLength(20);
                    addressBuilder.Property(a => a.ZipCode).HasMaxLength(8).IsRequired();
                });
            builder.ComplexProperty(
                o => o.Payment, paymentBuilder =>
                {
                    paymentBuilder.Property(p => p.CardHolderName).HasMaxLength(50);
                    paymentBuilder.Property(p => p.CardNumber).HasMaxLength(24).IsRequired();
                    paymentBuilder.Property(p => p.Expiration).HasMaxLength(10);
                    paymentBuilder.Property(p => p.CVV).HasMaxLength(3);
                    paymentBuilder.Property(p => p.PaymentMethod);
                });
            builder.Property(o => o.Status)
                .HasDefaultValue(OrderStatus.Pending)
                .HasConversion(
                    s => s.ToString(),
                    dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

            builder.Property(o => o.TotalPrice);
        }
    }
}
