using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Tradingterm
{
    public class TradingtermHeader
    {
        public string id { set; get; }
        public string registrationTax { set; get; }
        public string cooperateType { set; get; }
        public string cooperateName { set; get; }
        public int listingQty { set; get; }
        public string faceAcreage_total { set; get; }
        public string guaranteeMinimum { set; get; }
        public string discount { set; get; }
        public string salesCost { set; get; }
        public string marketingCost { set; get; }
        public string operatingCost { set; get; }
        public string createdDate { set; get; }
        public string status { set; get; }
        public string modifyDate { set; get; }
        public string modifyBy { set; get; }
        public string description { set; get; }
        public string VendorContact_ID { set; get; }
    }
}