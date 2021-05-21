using Microsoft.EntityFrameworkCore;
using NexGenScreening.HccGyna.Domain;

namespace NexGenScreening.HccGyna.Infrastructure.Persistence
{
    public class HccDbContext : DbContext
    {
        public DbSet<Hcc> hcc { get; set; }

        public HccDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Todo just for testing.
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
