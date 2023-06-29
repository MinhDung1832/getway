using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Tradingterm
{
    public class TradingtermLine
    {
        public string tradingterm_Id { set; get; }
        public string productID { set; get; }
        public string BBM_Code { set; get; }
        public string productName { set; get; }
        public string faceQty { set; get; }
        public string margin { set; get; }
    }
}