using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.ERP_API
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

    public class API_returnAPI
    {
        public bool StatusCode { set; get; }
        public string Message { set; get; }
        public string Items { set; get; }
    }
    public class API_returnAPI_Call<T>
    {
        public bool StatusCode { set; get; }
        public string Message { set; get; }
        public List<T> Items { set; get; }
    }
}
