using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Vendor
{
    public class VendorContact
    {
        public string id { set; get; } = "0";
        public string registrationTax { set; get; }
        public string BBM_Code { set; get; }
        public string representativeName { set; get; }
        public string representativeEmail { set; get; }
        public string representativePosition { set; get; }
        public string representativePosition_Name { set; get; }
        public string representativePhone { set; get; }
        public string contactName { set; get; }
        public string contactEmail { set; get; }
        public string contactPosition { set; get; }
        public string contactPosition_Name { set; get; }
        public string contactPhone { set; get; }
        public string createdDate { set; get; }
        public string status { set; get; }
    }
}