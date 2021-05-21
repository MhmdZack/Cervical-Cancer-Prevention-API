using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public partial class HealthcareCenterMap : ClassMapping<Domain.HealthcareCenter>
    {
        public HealthcareCenterMap()
        {
            //Schema("public");
            //string table = @"""Hcc""";
            Table("Hcc");
            Lazy(true);

            Id(x => x.HccId, map =>
            {
                map.Generator(Generators.Increment);
                map.Column("HccId");
                map.UnsavedValue(0);
            });

            //Id(x => x.HccId, map => map.Generator(Generators.Increment));
            Property(x => x.HccCode, map => { map.NotNullable(true); map.Length(10); });
            Property(x => x.HccName, map => { map.NotNullable(true); map.Length(100); });
            Property(x => x.CAddressLine1, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.CAddressLine2, map => { map.Length(50); });
            Property(x => x.CAddressLine3, map => { map.Length(50); });
            Property(x => x.CCity, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.CPostalCode, map => { map.NotNullable(true); map.Length(10); });
            Property(x => x.TelePhoneNumber, map => { map.NotNullable(true); map.Length(10); });
            Property(x => x.MobileNumber, map => { map.Length(10); });
            Property(x => x.FaxNumber, map => { map.Length(10); });
            Property(x => x.PAddressLine1, map => { map.Length(50); });
            Property(x => x.PAddressLine2, map => { map.Length(50); });
            Property(x => x.PAddressLine3, map => { map.Length(50); });
            Property(x => x.PCity, map => { map.Length(50); });
            Property(x => x.PPostalCode, map => { map.Length(10); });
            Property(x => x.EmailAddress, map => { map.Length(50); });
            Property(x => x.WebsiteUrl, map => { map.Length(50); });
            Property(x => x.IsActive, map => { map.NotNullable(true); });
            Property(x => x.ClientId, map => { map.NotNullable(true); });
            Property(x => x.CreatedBy, map => { map.Length(10); });
            Property(x => x.CreatedDate);
            Property(x => x.UpdatedBy, map => { map.Length(10); });
            Property(x => x.UpdatedDate);

        }
    }
}
