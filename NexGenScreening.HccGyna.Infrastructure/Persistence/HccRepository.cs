using Microsoft.EntityFrameworkCore;
using NexGenScreening.HccGyna.Application.Persistence;
using NexGenScreening.HccGyna.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NexGenScreening.HccGyna.Infrastructure.Persistence
{
    public class HccRepository : IHccRepository
    {
        private readonly HccDbContext _hccDbContext;
        private readonly DbSet<Hcc> _hcc;

        public HccRepository(HccDbContext hccDbContext)
        {
            _hccDbContext = hccDbContext;
            _hcc = _hccDbContext.Set<Hcc>();
        }
        public async ValueTask AddAsync(Hcc hcc, CancellationToken cancellationToken)
        {
            await _hcc.AddAsync(hcc, cancellationToken);
        }

        public void CreateDatabase()
        {
            _hccDbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _hccDbContext.Dispose();
        }

        public ValueTask<ICollection<Hcc>> GetAsync(string Username, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Hcc>> GetPageAsync(string username, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            //return await _hcc.AsNoTracking()
            //             .Skip((pageIndex - 1) * pageSize)
            //             .Take(pageSize)
            //             .SingleOrDefaultAsync(cancellationToken);
            throw new NotImplementedException();
        }

        public async ValueTask<Hcc> GetSingleOrDefault(string hccCode, CancellationToken cancellationToken)
        {
            return await _hcc
                .SingleOrDefaultAsync(x => x.HccCode.ToLower() == hccCode.ToLower(), cancellationToken: cancellationToken);
        }

        public void RemoveHealthcareCenter(Hcc hcc)
        {
            _hcc.Remove(hcc);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _hccDbContext.SaveChangesAsync(cancellationToken);
        }

        public void UpdateHealthcareCenter(Hcc hcc)
        {
            _hcc.Update(hcc);
        }
    }
}
