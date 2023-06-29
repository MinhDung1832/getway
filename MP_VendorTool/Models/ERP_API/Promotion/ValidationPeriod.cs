using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.ERP_API.Promotion
{
    public class ValidationPeriod
    {
        public string ID { set; get; }
        public string Description { set; get; }
        public string Starting_Date { set; get; }
        public string Ending_Date { set; get; }
    }
}