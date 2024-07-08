namespace Ordering.Infrastructure.Data.Configrations
{
    public class OrderItemConfigrations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(
                OrderItemId => OrderItemId.Value,
                dbId => OrderItemId.Of(dbId));
            builder.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();

        }
    }
}
