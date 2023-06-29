using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.TradingTermVendor
{
    public class objCoopInfoVendor
    {
        public string VendorNo { get; set; }
        public string VendorName { get; set; }
        public string Sale_LastYear { get; set; }
        public string SaleYTD { get; set; }
        public string SalesEstimateCurrYear { get; set; }
        public string CountItem_Store { get; set; }
        public string ContractStatus { get; set; }
        public string SalesLossOOS { get; set; }
    }
}