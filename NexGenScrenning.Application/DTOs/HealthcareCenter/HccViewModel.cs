using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.Application.DTOs.HealthcareCenter
{
    public class HccViewModel
    {
        public virtual Int64 HccId { get; set; }
        public virtual string HccCode { get; set; }
        public virtual string HccName { get; set; }
        public virtual string CAddressLine1 { get; set; }
        public virtual string CAddressLine2 { get; set; }
        public virtual string CAddressLine3 { get; set; }
        public virtual string CCity { get; set; }
        public virtual string CPostalCode { get; set; }
        public virtual string TelePhoneNumber { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string FaxNumber { get; set; }
        public virtual string PAddressLine1 { get; set; }
        public virtual string PAddressLine2 { get; set; }
        public virtual string PAddressLine3 { get; set; }
        public virtual string PCity { get; set; }
        public virtual string PPostalCode { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string WebsiteUrl { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}
