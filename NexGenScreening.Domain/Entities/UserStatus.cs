using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.Domain
{
    public class UserStatus
    {
        public virtual int UserStatusId { get; set; }
        public virtual string StatusDescription { get; set; }
        public virtual string StatusValue { get; set; }
    }
}
