using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Tradingterm
{
    public class TradingtermLeadtime
    {
        public string id { set; get; }
        public string tradingterm_Id { set; get; }
        public string Address { set; get; }
        public string leadtimeType { set; get; }
        public string leadtimeName { set; get; }
        public string leadtimeValue { set; get; }
    }
}