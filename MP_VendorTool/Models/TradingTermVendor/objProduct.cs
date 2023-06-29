using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.TradingTermVendor
{
    public class objProduct
    {
        public string ContractNo { get; set; }
        public string VendorNo { get; set; }
        public string productcode { get; set; }
        public string productname { get; set; }
        public string barcode { get; set; }
        public string p_CoopType { get; set; }
        public string p_Vat { get; set; }
        public string p_PriceDiscount { get; set; }
        public string p_PercentDiscountBill { get; set; }
        public string p_PriceAfterDiscountBasic { get; set; }
        public string TypeTab { get; set; }
        public string Images { get; set; }
        public string RangeReviewName { get; set; }
        public string TinhTrang { get; set; }
    }
    public class objProductFunction
    {
        public string ContractNo { get; set; }
        public string VendorNo { get; set; }
        public string FunctionCode { get; set; }
        public string FunctionName { get; set; }
        public string hinhthucht { get; set; }
        public string p_Vat { get; set; }
        public string p_PriceDiscount { get; set; }
        public string TypeTab { get; set; }
    }
    public class objProductBrand
    {
        public string ContractNo { get; set; }
        public string VendorNo { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string hinhthucht { get; set; }
        public string p_Vat { get; set; }
        public string p_PriceDiscount { get; set; }
        public string TypeTab { get; set; }
    }
}