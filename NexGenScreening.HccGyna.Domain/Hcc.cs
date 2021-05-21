using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.HccGyna.Domain
{
    public class Hcc
    {
        public int HccId { get; set; }
        public string HccCode { get; set; }
        public string HccName { get; set; }
        public string CAddressLine1 { get; set; }
        public string CAddressLine2 { get; set; }
        public string CAddressLine3 { get; set; }
        public string CCity { get; set; }
        public string CPostalCode { get; set; }
        public string TelePhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string PAddressLine1 { get; set; }
        public string PAddressLine2 { get; set; }
        public string PAddressLine3 { get; set; }
        public string PCity { get; set; }
        public string PPostalCode { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteUrl { get; set; }
        public bool IsActive { get; set; }
        public Int64 ClientId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
