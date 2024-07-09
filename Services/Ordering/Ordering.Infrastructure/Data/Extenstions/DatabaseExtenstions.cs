using Microsoft.AspNetCore.Builder;

namespace Ordering.Infrastructure.Data.Extenstions
{
    public static class DatabaseExtenstions
    {
        public static async Task InitializeDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
            await SeedAsync(context);
        }

        private static async Task SeedAsync(AppDbContext context)
        {
            await seedCustomerAsync(context);
            await SeedOrdersWithItemsAsync(context);
            await SeedProductAsync(context);

        }
        private static async Task seedCustomerAsync(AppDbContext context)
        {
            if (!await context.Customers.AnyAsync())
            {
                await context.Customers.AddRangeAsync(InitialData.Customers);
                await context.SaveChangesAsync();
            }
        }
        private static async Task SeedProductAsync(AppDbContext context)
        {
            if (!await context.Products.AnyAsync())
            {
                await context.Products.AddRangeAsync(InitialData.Products);
                await context.SaveChangesAsync();
            }
        }
        private static async Task SeedOrdersWithItemsAsync(AppDbContext context)
        {
            if (!await context.Orders.AnyAsync())
            {
                await context.Orders.AddRangeAsync(InitialData.OrdersWithItems);
                await context.SaveChangesAsync();
            }
        }
    }
}
