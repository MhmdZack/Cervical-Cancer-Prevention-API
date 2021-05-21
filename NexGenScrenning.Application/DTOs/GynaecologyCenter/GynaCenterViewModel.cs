using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGenScreening.Application.DTOs
{
    public class GynaCenterViewModel
    {
        //public int GynId { get; set; }
        public string GynCenterCode { get; set; }
        public string GyncCenterName { get; set; }
        public int HealthCenterId { get; set; }
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
        public string ContactInfo { get; set; }
        public string AdditionalInfo { get; set; }
        public string MapUrl { get; set; }
        public long XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int IsActive { get; set; }
    }
}
