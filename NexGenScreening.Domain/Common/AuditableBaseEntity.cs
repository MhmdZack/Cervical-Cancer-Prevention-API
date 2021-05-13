using System;

namespace NexGenScreening.Domain
{
    public abstract class AuditableBaseEntity
    {
        public virtual Guid CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual Guid UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual string ClientId { get; set; }
    }
}
