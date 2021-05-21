using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NexGenScreening.HccGyna.Infrastructure.Validation;

namespace NexGenScreening.HccGyna.Infrastructure.ServiceCollection
{
    public static class CustomRequestValidationExtenstion
    {
        public static IServiceCollection AddCustomRequestValidation(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
