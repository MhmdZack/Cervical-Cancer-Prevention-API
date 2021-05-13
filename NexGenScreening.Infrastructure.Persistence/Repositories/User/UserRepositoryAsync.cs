using NexGenScreening.Application.Interfaces.Repositories;
using NHibernate;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public class UserRepositoryAsync : GenericRepositoryAsync<Domain.User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(ISession session) : base(session)
        { }
    }
}
