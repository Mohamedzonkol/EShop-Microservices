﻿namespace Ordering.Infrastructure.Data.Configrations
{
    public class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasConversion(
                productId => productId.Value,
                dbId => ProductId.Of(dbId));

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
