namespace Ordering.Infrastructure.Data.Configrations
{
    public class CustomerConfigrations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(
                CustomerId => CustomerId.Value,
                dbId => CustomerId.Of(dbId));
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).HasMaxLength(255);

            builder.HasIndex(c => c.Email).IsUnique(); // Unique Index

        }
    }
}
