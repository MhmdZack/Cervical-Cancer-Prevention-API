using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.Application.DTOs
{
    public class MyTestViewModel
    {
        public virtual long Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Boolean IsActive { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}
