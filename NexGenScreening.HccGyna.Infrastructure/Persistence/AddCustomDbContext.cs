using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NexGenScreening.HccGyna.Infrastructure.Persistence
{
    public static class CustomServiceCollectionExtenstion
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HccDbContext>(
                options => options.UseNpgsql(connectionString,
                    providerOptions => providerOptions.EnableRetryOnFailure()));

            return services;
        }
    }
}
