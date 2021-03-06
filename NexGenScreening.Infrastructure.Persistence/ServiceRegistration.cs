using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Infrastructure.Persistence.Repositories;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(UserMap).Assembly.ExportedTypes);

            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            var connectionString = string.Empty;
            var NHConfiguration = new Configuration();

            if (configuration.GetValue<string>("DBProvider").ToLower().Equals("mssql"))
            {
                connectionString = configuration.GetConnectionString("MSSQLConnection");
                #region "AWS Settings"
                //if (configuration.GetValue<bool>("IsCloudDeployment"))
                //{
                //    var request = new GetParameterRequest()
                //    {
                //        Name = configuration.GetConnectionString("CloudSSMConnectionString")
                //    };

                //    using (var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.GetBySystemName(configuration.GetValue<string>("Region"))))
                //    {
                //        var response = client.GetParameterAsync(request).GetAwaiter().GetResult(); ;
                //        connectionString = response.Parameter.Value;
                //    }
                //}
                #endregion

                NHConfiguration.DataBaseIntegration(c =>
                {
                    c.Dialect<MsSql2008Dialect>();
                    c.ConnectionString = connectionString;
                    c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    c.LogFormattedSql = true;
                    c.LogSqlInConsole = true;
                });
            }
            else if (configuration.GetValue<string>("DBProvider").ToLower().Equals("postgres"))
            {
                connectionString = configuration.GetConnectionString("PostgresConnection");
                #region "AWS Settings"
                //if (configuration.GetValue<bool>("IsCloudDeployment"))
                //{
                //    var request = new GetParameterRequest()
                //    {
                //        Name = configuration.GetConnectionString("CloudSSMConnectionString")
                //    };

                //    using (var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.GetBySystemName(configuration.GetValue<string>("Region"))))
                //    {
                //        var response = client.GetParameterAsync(request).GetAwaiter().GetResult();
                //        connectionString = response.Parameter.Value;
                //    }
                //}
                #endregion
                NHConfiguration.DataBaseIntegration(c =>
                {
                    c.Dialect<PostgreSQL82Dialect>();
                    c.ConnectionString = connectionString;
                    c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    c.LogFormattedSql = true;
                    c.LogSqlInConsole = true;
                });
            }
            NHConfiguration.AddMapping(domainMapping);

            var sessionFactory = NHConfiguration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());

            #region Repositories

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddTransient<IUserStatusRepositoryAsync, UserStatusRepositoryAsync>();
            services.AddTransient<ILoginLogRepositoryAsync, LoginLogRepositoryAsync>();
            services.AddTransient<ILoginLogTypeRepositoryAsync, LoginLogTypeRepositoryAsync>();
            services.AddTransient<IUserTokenRepositoryAsync, UserTokenRepositoryAsync>();
            //services.AddTransient<IEmailTemplateRepositoryAsync, EmailTemplateRepositoryAsync>();
            //services.AddTransient<IEmailRecipientRepositoryAsync, EmailRecipientRepositoryAsync>();

            #endregion Repositories
        }
    }
}
