using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domin.ValueObject;

namespace Ordering.Infrastructure.Configrations
{
    public class OrderConfigrations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(
                OrderId => OrderId.Value,
                dbId => OrderId.Of(dbId));
        }
    }
}
