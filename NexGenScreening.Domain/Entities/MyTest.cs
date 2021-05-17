using System;

namespace NexGenScreening.Domain
{
    public class MySample
    {
        
        public virtual long Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual string UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}
