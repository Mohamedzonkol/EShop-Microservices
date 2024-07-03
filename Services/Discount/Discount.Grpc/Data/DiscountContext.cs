using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext(DbContextOptions<DiscountContext> options) : DbContext(options)
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "IPhone X", Description = "IPhone Discount", Amount = 150 },
                new Coupon { Id = 2, ProductName = "Samsung 10", Description = "Samsung Discount", Amount = 100 },
                new Coupon { Id = 3, ProductName = "Huawei P30", Description = "Huawei Discount", Amount = 50 },
                new Coupon { Id = 4, ProductName = "OnePlus 2", Description = "OnePlus Discount", Amount = 80 },
                new Coupon { Id = 5, ProductName = "Xiaomi Mi 10", Description = "Xiaomi Discount", Amount = 200 }
            );
        }
    }
}
