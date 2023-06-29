using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.ERP_API.Promotion
{
    public class MixMatchLines
    {
        public string Item_No { set; get; }
        public string Line_Group { set; get; }
        public string No_of_Items_Needed { set; get; }
        public string Type { set; get; }
        public string Deal_Price_Disc_Percent { set; get; }
        public string Disc_Type { set; get; }
    }
}