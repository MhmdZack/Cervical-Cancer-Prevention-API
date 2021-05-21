using NexGenScreening.Application.Interfaces.Repositories;
using NHibernate;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public class GynaecologyCenterRepositoryAsync : GenericRepositoryAsync<Domain.GynaCenter>, IGynaecologyCenterRepositoryAsync
    {
        public GynaecologyCenterRepositoryAsync(ISession session) : base(session) { }
    }
}
