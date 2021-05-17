using NexGenScreening.Application.Interfaces.Repositories;
using NexGenScreening.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public class MyTestRepositoryAsync : GenericRepositoryAsync<MySample>, IMyTestRepositoryAsync
    {
        public MyTestRepositoryAsync(ISession session) : base(session)
        {
        }
    }
}
