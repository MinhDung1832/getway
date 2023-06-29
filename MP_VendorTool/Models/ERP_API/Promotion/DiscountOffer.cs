using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.ERP_API.Promotion
{
    public class DiscountOffer
    {
        public string No { set; get; }
        public string Description { set; get; }
        public string Price_Group { set; get; }
        public string Validation_Period_ID { set; get; }

        public DiscountOfferLine[] DiscountOfferLine;

    }
}