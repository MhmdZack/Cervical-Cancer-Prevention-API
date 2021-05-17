using System;

namespace NexGenScreening.Domain
{
    public abstract class AuditableBaseEntity
    {
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual string UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual long ClientId { get; set; }
    }
}
