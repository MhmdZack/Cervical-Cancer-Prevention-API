using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Domain;
using NHibernate;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public class LoginLogRepositoryAsync : GenericRepositoryAsync<LoginLog>, ILoginLogRepositoryAsync
    {
        public LoginLogRepositoryAsync(ISession session) : base(session)
        { }
    }
}
