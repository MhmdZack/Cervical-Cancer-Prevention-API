using System;
using System.Collections.Generic;

namespace NexGenScreening.Domain
{
    public class User : AuditableBaseEntity
    {
        public User()
        {
            UserTokens = new List<UserToken>();
        }

        public virtual Guid UserId { get; set; }
        public virtual UserStatus UserStatuses { get; set; }
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserEmail { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }
        public virtual IList<UserToken> UserTokens { get; set; }
    }
}
