using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API
{
    public class API_return
    {
        public bool codeReturn { set; get; }
        public string orderNo { set; get; }
        public string No { set; get; }
        public string message { set; get; }
        public string ValidationPeriodID { set; get; }
        public string Items { set; get; }
    }
}
