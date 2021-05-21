using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NexGenScreening.HccGyna.Application.Persistence;

namespace NexGenScreening.HccGyna.Infrastructure.ServiceCollection
{
    public static class DatabaseExtensions
    {
        public static IHost CreateDatabase<T>(this IHost webHost) where T : IHccRepository
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;
            var itemRepository = services.GetRequiredService<T>();
            itemRepository.CreateDatabase();

            return webHost;
        }
    }
}
