using System;

namespace NexGenScreening.Domain
{
    public partial class LoginLogType
    {
        public virtual Guid LoginLogTypeId { get; set; }
        public virtual string LoginLogTypeName { get; set; }
    }
}
