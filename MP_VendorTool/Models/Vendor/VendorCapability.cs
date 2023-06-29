using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Vendor
{
    public class VendorCapability
    {
        public string id { set; get; }
        public string registrationTax { set; get; }
        public string yearActive { set; get; } = "";
        public string yearActiveName { set; get; }
        public string employeesScale { set; get; } = "0";
        public string coverageMarket { set; get; } = "";
        public string coverageMarket_Name { set; get; }
        public string previousRevenue { set; get; } = "";
        public string previousRevenue_Name { set; get; }
        public string competencyCore { set; get; } = "";
        public string competencyCore_Name { set; get; }
        public string customerKey { set; get; } = "";
        public string warehouseAcreage { set; get; } = "0";
        public int truckQuantity { set; get; }
        public string createdDate { set; get; }
        public string status { set; get; }
    }
}