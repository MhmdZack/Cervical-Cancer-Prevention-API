using NexGenScreening.Domain;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public partial class UserStatusesMap : ClassMapping<UserStatus>
    {
        public UserStatusesMap()
        {
            Table("UserStatuses");
            Lazy(true);
            Id(x => x.UserStatusId, map => map.Generator(Generators.Identity));
            Property(x => x.StatusDescription, map => map.Length(50));
            Property(x => x.StatusValue, map => { map.NotNullable(true); map.Length(50); });
        }
    }
}
