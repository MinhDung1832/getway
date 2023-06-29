using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Promotion2
{
    public class ComboKhuyenMai_Header
    {
        public string ID { set; get; }
        public string MaCT { set; get; }
        public string TenCT { set; get; }
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string TuNgay { set; get; }
        public string DenNgay { set; get; }
        public string Status { set; get; }
        public string TrangThai { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }

    }
    public class ComboKhuyenMai_MuaHang
    {
        public string ID { set; get; }
        public string MaCT { set; get; }
        public string TenCT { set; get; }
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string HinhAnh { set; get; }
        public string GiaBanNTD { set; get; }
        public string SoLuongApDung { set; get; }
        public string PhanTramQua { set; get; }

    }
    public class ObjPromotionSource
    {
        public string SourceHeader { get; set; }
        public string SourceHangMua { get; set; }
        public string SourceHangTang { get; set; }
    }
    public class ComboKhuyenMai_TangHang
    {
        public string ID { get; set; }
        public string MaCT { get; set; }
        public string TenCT { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string HinhAnh { get; set; }
        public string GiaQua { get; set; }
        public string SoLuongApDung { get; set; }
    }
    public class Search_Detail
    {
        public string TenCT { get; set; }
        public string VendorCode { get; set; }
        public string TrangThai { get; set; }
        public string NgayTao { get; set; }
    }
    public class Header_Detail
    {
        public string ID { get; set; }
        public string MaCT { get; set; }
        public string TenCT { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string Status { get; set; }
        public string TrangThai { get; set; }
        public string CreateDate { get; set; }
        public string ModifyDate { get; set; }
        public string SumSoLuongApDung { get; set; }
        public string SumPhanTramQua { get; set; }
        public string SumGiaBanNTD { get; set; }
        public string SumGiaQua { get; set; }
        public string SumSoLuongApDungMH { get; set; }

    }
    public class GetWay_HHOA_KGUI
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string HHOA_KGUI { get; set; }
        public string Barcode { get; set; }
        public string GBNTD { get; set; }
        public string HinhAnh { get; set; }
        public string MaNCC { get; set; }

    }
    public class TangHang_GetWay_HHOA_KGUI
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string HHOA_KGUI { get; set; }
        public string Price { get; set; }
        public string HinhAnh { get; set; }

    }
}
