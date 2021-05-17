using NexGenScreening.Application.Interfaces.Repositories;
using NHibernate;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public class HealthcareCenterRepositoryAsync : GenericRepositoryAsync<Domain.HealthcareCenter>, IHealthcareCenterRepositoryAsync
    {
        public HealthcareCenterRepositoryAsync(ISession session) : base(session) { }
    }
}
