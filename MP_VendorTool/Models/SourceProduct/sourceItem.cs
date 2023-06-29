using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.SourceProduct
{
    public class sourceItem
    {
        public string id { set; get; } ="0";
        public string sku { set; get; } = "";
        public string name { set; get; }
        public string vendorCode { set; get; } = "";
        public string vendorName { set; get; } = "";
        public string Total_PR_Qty { set; get; } = "";
        public string descriptions { set; get; } = "";
        public string imgLink { set; get; }
        public string corePrice { set; get; } = "";
        public string price { set; get; } = "";
        public string url_link { set; get; } = "";
        public string DivisionCode { set; get; } = "";
        public string DivisionName { set; get; } = "";
        public string CategoryCode { set; get; } = "";
        public string CategoryName { set; get; } = "";
        public string GroupCode { set; get; } = "";
        public string GroupName { set; get; } = "";
        public string FunctionCode { set; get; } = "";
        public string FunctionName { set; get; } = "";
        public string UoM { set; get; }
        public string status { set; get; } = "";
        public string createBy { set; get; } = "";
        public string createDate { set; get; } = "";

    }
}