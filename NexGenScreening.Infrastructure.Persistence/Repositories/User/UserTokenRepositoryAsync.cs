using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Domain;
using NHibernate;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public class UserTokenRepositoryAsync : GenericRepositoryAsync<UserToken>, IUserTokenRepositoryAsync
    {
        public UserTokenRepositoryAsync(ISession session) : base(session)
        {
        }
    }
}
