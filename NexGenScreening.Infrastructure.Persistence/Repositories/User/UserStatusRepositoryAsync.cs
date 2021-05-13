using NexGenScreening.Application.Interfaces.Repositories;
using NHibernate;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public class UserStatusRepositoryAsync : GenericRepositoryAsync<Domain.UserStatus>, IUserStatusRepositoryAsync
    {
        public UserStatusRepositoryAsync(ISession session) : base(session)
        { }
    }
}
