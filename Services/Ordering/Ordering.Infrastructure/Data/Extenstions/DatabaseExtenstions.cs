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

        }
    }
}
