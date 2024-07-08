namespace Ordering.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((s, options) =>
            {
                // options.AddInterceptors(s.GetService<ISaveChangesInterceptor>()!);
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });
            return services;
        }
    }
}
