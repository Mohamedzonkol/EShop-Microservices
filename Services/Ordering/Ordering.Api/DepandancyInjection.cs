namespace Ordering.Api
{
    public static class DepandancyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            return services;
        }
        public static WebApplication UseApiServices(this WebApplication app)
        {
            return app;
        }
    }
}
