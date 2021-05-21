using NexGenScreening.HccGyna.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.HccGyna.Application.Persistence
{
    public interface IHccRepository : IDisposable
    {
        void CreateDatabase();

        void RemoveHealthcareCenter(Hcc hcc);

        void UpdateHealthcareCenter(Hcc hcc);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        ValueTask<Hcc?> GetSingleOrDefault(string hccCode, CancellationToken cancellationToken);

        ValueTask AddAsync(Hcc hcc, CancellationToken cancellationToken);

        ValueTask<ICollection<Hcc>> GetAsync(string Username, CancellationToken cancellationToken);

        ValueTask<ICollection<Hcc>> GetPageAsync(string username,
                                                  int pageIndex, int pageSize,
                                                  CancellationToken cancellationToken);
    }
}
