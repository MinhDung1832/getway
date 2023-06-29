using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.PriceSell
{
    public class PriceSell
    {
        public string IDPriceSell { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string Price { get; set; }
        public string PriceNew { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }
        public string ischeck { get; set; }
    }
    public class Obj_PriceSell
    {
        public string vendorNo { get; set; }
        public string MaHang { get; set; }
        public string Barcode { get; set; }
    }
    public class Obj_PriceSell_GetAll
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Barcode { get; set; }
        public string Price { get; set; }
        public string Images { get; set; }
        public string PriceNew { get; set; }
        public string IDPriceSell { get; set; }
        public string ttNgayBatDau { get; set; }
        public string ttNgayKetThuc { get; set; }
    }
    public class Obj_PriceSell_GetAll_Ar
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Barcode { get; set; }
        public string Price { get; set; }
        public string Images { get; set; }
        public string PriceNew { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string TrangThai { get; set; }
    }
    public class Obj_PriceSellAr
    {
        public string vendorNo { get; set; }
        public string MaHang { get; set; }
        public string Barcode { get; set; }
        public string TrangThai { get; set; }
    }

}
