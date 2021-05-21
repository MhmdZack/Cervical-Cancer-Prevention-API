using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexGenScreening.HccGyna.Application.Persistence;
using NexGenScreening.HccGyna.Infrastructure.Persistence;
using System.Reflection;

namespace NexGenScreening.HccGyna.Infrastructure.ServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHttpContextAccessor()
            .AddCustomDbContext(configuration.GetConnectionString("SqlConnection"))
            .AddTransient<IHccRepository, HccRepository>()
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddCustomRequestValidation()
            .AddCustomDapr()
            .AddTransient<HccItemNotificationHandler>()
            .AddTransient<DaprHccGateway>();

        return services;
    }
}
