using NexGenScreening.Domain;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.Infrastructure.Persistence.Repositories
{
    public partial class MyTestMap : ClassMapping<MySample>
    {
        public MyTestMap()
        {
            //[Id(Name = "Id", Column = "Id", UnsavedValue = "0")]
            //[Generator(1, Class = "sequence")]
            //[Param(2, Name = "sequence", Content = "tblSample_Id_seq")]
            Table("tblSample");
            Lazy(true);
            Id(x => x.Id, map =>
            {
                map.Column("Id");
                map.Generator(Generators.Sequence, gmap => gmap.Params(new { Name = "sequence", sequence = "tblSample_Id_seq" }));
                map.UnsavedValue(0);
            });
            Property(x => x.FirstName, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.MiddleName, map => { map.NotNullable(false); map.Length(50); });
            Property(x => x.LastName, map => { map.NotNullable(true); map.Length(50); });
            Property(X => X.IsActive, map => { map.NotNullable(false); });
            Property(x => x.CreatedBy, map => { map.NotNullable(false); map.Length(50); });
            Property(x => x.CreatedDate, map => { map.NotNullable(false); });
            Property(x => x.UpdatedBy, map => { map.NotNullable(false); map.Length(50); });
            Property(x => x.UpdatedDate, map => { map.NotNullable(false); });

        }
    }
}
