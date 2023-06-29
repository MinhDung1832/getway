using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.SourceProduct
{
    public class DivCatGroupFunc
    {
        public string DivisionCode { set; get; }
        public string DivisionName { set; get; }
        public string CategoryCode { set; get; }
        public string CategoryName { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
        public string GroupCode { set; get; }
        public string GroupName { set; get; }
        public string UoM { set; get; }
    }

    public class DivCatGroupFuncollect
    {
        public string DivisionCode { set; get; }
        public string DivisionName { set; get; }
        public string CategoryCode { set; get; }
        public string CategoryName { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
        public string GroupCode { set; get; }
        public string GroupName { set; get; }
        public string BrandCode { set; get; }
        public string BrandName { set; get; }
        public string NguonNhapCode { set; get; }
        public string NguonNhapName { set; get; }
        public string MuaVuCode { set; get; }
        public string MuaVuName { set; get; }
    }

    public class filter_pushsale
    {
        public string CategoryCode { set; get; }
        public string CategoryName { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
        public string BrandCode { set; get; }
        public string BrandName { set; get; }
        public string StoreNo { set; get; }
        public string StoreName { set; get; }
    }

    public class filterRR
    {
        public string Brandncc { set; get; }
        public string Nguonnhap { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
        public string DivCode { set; get; }
        public string DivName { set; get; }
    }

    public class filterRO
    {
        public string Brandncc { set; get; }
        public string CatCode { set; get; }
        public string CatName { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
        public string GroupCode { set; get; }
        public string GroupName { set; get; }
    }
    public class itemks
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public decimal GBLALL { set; get; }
    }

    public class tdhsummary
    {
        public string StaffCode { get; set; }
        public string StaffName { get; set; }
        public string Address { get; set; }
        public string StoreCode { get; set; }
        public decimal DoanhSo { get; set; } = 0;
        public decimal TDH { get; set; } = 0;
    }

    public class filter_AR
    {
        public string BrandNccCode { set; get; }
        public string BrandNccName { set; get; }
        public string ItemCode { set; get; }
        public string ItemName { set; get; }
    }

    public class filter_AR_Auto
    {
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string BrandCode { set; get; }
        public string BrandName { set; get; }
        public string ItemCode { set; get; }
        public string ItemName { set; get; }
    }

    public class Cuahang_Tinh_AR_Auto
    {
        public string MaMien { set; get; }
        public string TenMien { set; get; }
        public string MaTinh { set; get; }
        public string TenTinh { set; get; }
        public string MaCH { set; get; }
        public string TenCH { set; get; }
    }

    public class DongKienInfo
    {
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public string MaKien { set; get; }
        public string KhoChiaCode { set; get; }
        public string M3 { set; get; }
        public string SLSkus { set; get; }
    }

}