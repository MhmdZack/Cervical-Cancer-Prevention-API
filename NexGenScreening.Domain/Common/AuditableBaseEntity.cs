using System;

namespace NexGenScreening.Domain
{
    public abstract class AuditableBaseEntity
    {
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual long ClientId { get; set; }
    }
}
