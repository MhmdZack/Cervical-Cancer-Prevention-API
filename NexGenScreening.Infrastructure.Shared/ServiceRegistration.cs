using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexGenScreening.Application.Interfaces.Services;
using NexGenScreening.Infrastructure.Shared.Services;

namespace NexGenScreening.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            //services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IPasswordService, PasswordService>();
        }
    }
}
