using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.ObjTrungBayNH
{

    public class MoRongTrungBayHH
    {
        public string MaHang { get; set; }
        public string Brand_Code { get; set; }
        public string Brand_Name { get; set; }
        public string MaCH { get; set; }
        public string TenCH { get; set; }
        public string MaNCC { get; set; }
        public string TenHang { get; set; }
        public string Mien { get; set; }
        public string MaTinhCode { get; set; }
        public string Images { get; set; }
        public string TrangThaiHD { get; set; }
        public string SoMatTB { get; set; }
        public string M2FNet_SKU { get; set; }
        public string GPM2F { get; set; }
        public string Stockday { get; set; }

    }
    public class SearchMoRongKD
    {
        public string MaNCC { get; set; }
        public string MaHang { get; set; }
        public string CuaHang { get; set; }
        public string TinhThanh { get; set; }
        public string Mien { get; set; }

    }

    public class QuanLyTrungBayHH_gateway
    {
        public string MaHang { get; set; }
        public string Brand_Code { get; set; }
        public string Brand_Name { get; set; }
        public string MaNCC { get; set; }
        public string TenHang { get; set; }
        public string Images { get; set; }
        public string GiabanVAT { get; set; }
        public string TrangThai { get; set; }
        public string IsCheck { get; set; }
        public string MaAutoCT { get; set; }
        public string NgayCapNhat { get; set; }
        public string GPM2F { get; set; }
        public string XucTien { get; set; }
        public string IsChekXucTien { get; set; }
        public string Stockday { get; set; }
        public string SoCuaHangKinhDoanh { get; set; }

    }

    public class TrungBayHH_gateway
    {
        public string MaNCC { get; set; }
        public string MaHang { get; set; }
        public string Trangthai { get; set; }
        public string Xuctien { get; set; }

    }
    public class obj_TrungBayNHDetail
    {
        public string MaNCC { get; set; }
        public string MaCT { get; set; }
        public string CuaHang { get; set; }
        public string Mien { get; set; }
        public string TinhThanh { get; set; }

    }
    public class TrungBayNganhHang_Detail
    {
        public string MaAutoCT { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MaCuaHang { get; set; }
        public string TenCuaHang { get; set; }
        public string SoMatTB { get; set; }
        public string Stockday { get; set; }
        public string SoMatTBMoi { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string ChiPhi { get; set; }
        public string VungMien { get; set; }
        public string TinhThanh { get; set; }

    }
    public class TrungBayNgangHang_Header
    {
        public string MaAutoCT { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string ChiPhi { get; set; }
        public string CreateBy { get; set; }


    }

    public class TrungBayNgangHang_add
    {
        public string MaAutoCT { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string ChiPhi { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }


    }
    public class TrungBayNgangHang_Line
    {
        public string MaAutoCT { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MaCuaHang { get; set; }
        public string TenCuaHang { get; set; }
        public string SoMatTB { get; set; }
        public string Stockday { get; set; }
        public string SoMatTBMoi { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string ChiPhi { get; set; }
        public string VungMien { get; set; }
        public string TinhThanh { get; set; }

    }
}
