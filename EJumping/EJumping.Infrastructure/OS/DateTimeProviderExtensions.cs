using EJumping.CrossCuttingConcerns.OS;
using EJumping.Infrastructure.OS;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DateTimeProviderExtensions
    {
        public static IServiceCollection AddDateTimeProvider(this IServiceCollection services)
        {
            _ = services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
