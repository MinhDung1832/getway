using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.ChiDinhHotdeal
{
    public class ChiDinhHotdeal_Vender_Item
    {
        public string ID { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string Images { get; set; }
        public string Price { get; set; }
        public string HHOA_KGUI { get; set; }
        public string GiaKM { get; set; }
        public string PTGiamGia { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string SLApDung { get; set; }
        public string GBLALL { get; set; }
        public string NganSachKM { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }
    }

    public class ChiDinhHotdeal_HHOA_KGUI
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string HHOA_KGUI { get; set; }
        public string Barcode { get; set; }
        public string usePricerid { get; set; }
        public string Images { get; set; }
        public string Price { get; set; }
        public string ttMaHang { get; set; }
        public string NgayKetThuc { get; set; }
        public string ischeck { get; set; }
        public string SLApDung { get; set; }
        public string PriceAllNTD { get; set; }
    }
    public class Obj_fillter_Ar
    {
        public string vendorNo { get; set; }
        public string MaHang { get; set; }
        public string Barcode { get; set; }
    }
    public class Obj_ChiDinhHotdeal
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string Images { get; set; }
        public string Price { get; set; }
        public string HHOA_KGUI { get; set; }
        public string GiaKM { get; set; }
        public string PTGiamGia { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string SLApDung { get; set; }
        public string GBLALL { get; set; }
        public string NganSachKM { get; set; }
        public string userid { get; set; }

    }
    // Ar

    public class Obj_ChiDinhHotdealApr
    {
        public string ID { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string Images { get; set; }
        public string Price { get; set; }
        public string GiaKM { get; set; }
        public string PTGiamGia { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string SLApDung { get; set; }
        public string GBLALL { get; set; }
        public string NganSachKM { get; set; }
        public string PriceAllNTD { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string ModifyDate { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
        public string TrangThai { get; set; }
        public string sumNganSachKM { get; set; }
        public string sumSLApDung { get; set; }

    }
    public class Obj_HotdealApr
    {
        public string vendorNo { get; set; }
        public string MaHang { get; set; }
        public string TrangThai { get; set; }
    }
}
