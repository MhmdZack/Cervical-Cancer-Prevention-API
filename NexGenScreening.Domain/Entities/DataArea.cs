using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.Domain
{
    public class DataArea
    {
        public virtual string DataAreaId { get; set; }
        public virtual int RecId { get; set; }
        public virtual string Description { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual string UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual bool Status { get; set; }
    }
}
