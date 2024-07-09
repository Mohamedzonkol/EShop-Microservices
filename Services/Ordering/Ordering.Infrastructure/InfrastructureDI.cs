using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //   services.AddScoped<ISaveChangesInterceptor, DataInterceptors>();
            // services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
            services.AddDbContext<AppDbContext>((s, options) =>
            {
                options.AddInterceptors(new DataInterceptors()/*s.GetService<ISaveChangesInterceptor>()!*/);
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            //   services.AddScoped<AppDbContext,AppDbContext>();
            return services;
        }
    }
}