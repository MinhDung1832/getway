using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.ERP_API.Promotion
{
    public class MixMatch
    {
        public string No { set; get; }
        public string Description { set; get; }
        public string Price_Group { set; get; }
        public string status { set; get; }
        public string Validation_Period_ID { set; get; }
        //Mix__x0026__Match_Lines
        public MixMatchLines[] MixMatchLine;
        public List<MixMatchLineGroup> MixMatchLineGroup;
        //BeneBits
        public string Discount_Type { set; get; }
        public string Deal_Price_Value { set; get; } //decimal
        public string Discount_Percent_Value { set; get; } //decimal
        public string Discount_Amount_Value { set; get; } //decimal
        public string No_of_Line_Groups { set; get; } //int
        public string No_of_Least_Expensive_Items { set; get; }
        public string Disc_Percent_of_Least_Expensive { set; get; }
        public string No_of_Times_Applicable { set; get; }

    }
}