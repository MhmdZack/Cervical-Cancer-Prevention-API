using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Domain;
using NHibernate;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public class LoginLogTypeRepositoryAsync : GenericRepositoryAsync<LoginLogType>, ILoginLogTypeRepositoryAsync
    {
        public LoginLogTypeRepositoryAsync(ISession session) : base(session)
        { }
    }
}
