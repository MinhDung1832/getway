using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Order
{
    public class objUpdatePurchaseOrder
    {
        public string SourceOrder { set; get; }
        public string DocumentNo { set; get; }
        public string locationCode { set; get; }
    }
}