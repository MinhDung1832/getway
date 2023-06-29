using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Vendor
{
    public class Certificate_Item
    {
        public string ApproveID { set; get; }
        public string VendorCode { set; get; }
        public string VendorContactID { set; get; }
        public string ChangeType { set; get; }
        public string attributeCode { set; get; }
        public string attributeName { set; get; }
        public string Filename { set; get; }
        public string link { set; get; }
        public string status { set; get; }
        public string createdDate { set; get; }
    }
}