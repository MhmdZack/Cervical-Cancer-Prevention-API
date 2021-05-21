using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.Domain
{
    public class GynaCenter : AuditableBaseEntity
    {
        public virtual int GynId { get; set; }
        public virtual string GynCenterCode { get; set; }
        public virtual string GyncCenterName { get; set; }
        public virtual int HealthCenterId { get; set; }
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
        public virtual string ContactInfo { get; set; }
        public virtual string AdditionalInfo { get; set; }
        public virtual string MapUrl { get; set; }
        public virtual long XCoordinate { get; set; }
        public virtual int YCoordinate { get; set; }
        public virtual int IsActive { get; set; }
    }
}
