using System;
using System.Collections.Generic;

namespace MP_VendorTool.Models.Order2
{
    public class OrderGetlAll
    {
        public int total_item { get; set; }
        public int total_page { get; set; }
        public DateTime RequestDate { get; set; }
        public long STT { get; set; }
        public string MaNCC { get; set; }
        public string PoNo { get; set; }
        public int prePO_ID { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public int SL_Xacnhan { get; set; }
        public DateTime NgayYC_GiaoHang { get; set; }
        public string Kho { get; set; }
        public string KhoName { get; set; }
        public string MaMien { get; set; }
        public string TenMien { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
    }

    public class OrderGetlDonHang
    {
        public int total_item { get; set; }
        public int total_page { get; set; }
        public int ID { get; set; }
        public DateTime RequestDate { get; set; }
        public long STT { get; set; }
        public string MaNCC { get; set; }
        public string PoNo { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime NgayYC_GiaoHang { get; set; }
        public string Kho { get; set; }
        public string KhoName { get; set; }
        public string MaMien { get; set; }
        public string TenMien { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public string Trangthai { get; set; }
        public string TrangthaiCode { get; set; }
    }

    public class OrderGetlDonHang_mapper
    {
        public DateTime RequestDate { get; set; }
        public int ID { get; set; }
        public long STT { get; set; }
        public string MaNCC { get; set; }
        public string PoNo { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime NgayYC_GiaoHang { get; set; }
        public string Kho { get; set; }
        public string KhoName { get; set; }
        public string MaMien { get; set; }
        public string TenMien { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public string Trangthai { get; set; }
        public string TrangthaiCode { get; set; }
    }

    public class NgayGiao
    {
        public DateTime Ngay { set; get; }
        public int isCheck { set; get; }
    }

    public class getSL
    {
        public int SLDonHangChoXacNhan { set; get; }
        public int SLDonHangChoGiao { set; get; }
        public int SlDonHoan { set; get; }
    }

    public class OrderGetlAll_mapper
    {
        public string MaNCC { get; set; }
        public string PoNo { get; set; }
        public int prePO_ID { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public int SL_Xacnhan { get; set; }
        public DateTime NgayYC_GiaoHang { get; set; }
        public string Kho { get; set; }
        public string KhoName { get; set; }
        public string MaMien { get; set; }
        public string TenMien { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public DateTime RequestDate { get; set; }
    }

    public class get_chitetdonhang
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string PoType { get; set; }
        public DateTime RequestDate { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string linkanh { get; set; }
        public string NCC { get; set; }
        public decimal GiaMuaNet { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public int SL { get; set; }
        public int tongSLxacnhan { get; set; }
        public int ConfirmID { get; set; }
        public string Status { get; set; }
    }

    public class XacNhanDonHang_Header
    {
        public int prePO_ID { set; get; }
        public DateTime NgayXN_GiaoHang { set; get; }
    }

    public class XacNhanDonHang_Line
    {
        public int header_ID { set; get; }
        public int ConfirmID { set; get; }
        public int Quantity { set; get; }
    }

    public class Obj_XacNhanDonHang_Line
    {
        public int ConfirmID { set; get; }
        public int Quantity { set; get; }
    }

    public class XacNhanDonHang
    {
        public XacNhanDonHang_Header Header { set; get; }
        public List<Obj_XacNhanDonHang_Line> Line { set; get; }
    }

    public class XacNhanDonHang_Headerv2
    {
        public int prePO_ID { set; get; }
        public DateTime NgayXN_GiaoHang { set; get; }
    }

    public class XacNhanDonHang_Linev2
    {
        public int header_ID { set; get; }
        public int prePO_ID { set; get; }
        public int Quantity { set; get; }
        public DateTime? HanSD { set; get; }
        public DateTime NgaySanXuat { set; get; }
    }

    public class Obj_XacNhanDonHang_Linev2
    {
        public string prePO_ID { set; get; }
        public string quantity { set; get; }
        public string hanSD { set; get; }
        public string NgaySanXuat { set; get; }
    }

    public class DonHang_Detail
    {
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string ID { set; get; }
        public string PoNo { set; get; }
        public string expDate { set; get; }
        public string TotalQuantity { set; get; }
        public string TotalQuantity1 { set; get; }
        public string TotalAmount { set; get; }
        public string TotalSoLuongXacNhan { set; get; }
        public string TotalSoLuongXacNhan1 { set; get; }
        public string KhoNhan { set; get; }
        public string Trangthai { set; get; }
    }
    public class DonHang_Detail_DaXacNhan
    {
        public string IDXacNhan { set; get; }
        public string ID { set; get; }
        public string prePO_ID { set; get; }
        public string ParentID { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string GiaMua { set; get; }
        public string Quantity { set; get; }
        public string Amount { set; get; }
        public string HanSD { set; get; }
        public string NgayXS { set; get; }
        public string linkanh { set; get; }
        public int DotGiao { set; get; }
        public string SumQuantity { set; get; }
        public string SumSoLuong { set; get; }
        public string TrangThai { set; get; }
        public string TrangThaiCode { set; get; }
        public string NgayGiao { set; get; }
        public string GioGiao { set; get; }
        public string NgayXacNhan_GiaoHang { set; get; }

        // Xe
        public string XeVanChuyen { set; get; }
        public string TaiXe { set; get; }
        public string sdtTaixe { set; get; }
        public string DonViGiaoHang { set; get; }
        public string CCCD { set; get; }

        // lý do từ chối
        public string Lydotuchoi { set; get; }
        public string SDTlienhe { set; get; }
        public string DeXuatNgayGiao { set; get; }
        public string DeXuatGioGiao { set; get; }
    }

    public class SoLuong_hanSD
    {
        public string Quantity { set; get; }
        public string GiaMua { set; get; }
        public string Amount { set; get; }
        public string HanSD { set; get; }
        public string NgayXS { set; get; }
    }

    public class Product
    {
        public string IDXacNhan { get; set; }
        public string prePO_ID { get; set; }
        public string ParentID { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string linkanh { set; get; }
        public string SumQuantity { set; get; }
        public string SumSoLuong { set; get; }
        public int DotGiao { set; get; }
        public string TrangThai { set; get; }
        public string TrangThaiCode { set; get; }
        public string NgayGiao { set; get; }
        public string GioGiao { set; get; }
        public string NgayXacNhan_GiaoHang { set; get; }
        // Xe
        public string XeVanChuyen { set; get; }
        public string TaiXe { set; get; }
        public string sdtTaixe { set; get; }
        public string DonViGiaoHang { set; get; }
        public string CCCD { set; get; }
        // lý do từ chối
        public string Lydotuchoi { set; get; }
        public string SDTlienhe { set; get; }
        public string DeXuatNgayGiao { set; get; }
        public string DeXuatGioGiao { set; get; }
        public List<SoLuong_hanSD> SoLuong_hanSD { get; set; }
    }
    public class XacNhan_DonHang
    {
        public string Header { set; get; }
        public string Line { set; get; }
    }
    public class XacNhanDonHangv2
    {
        public XacNhanDonHang_Headerv2 Header { set; get; }
        public List<Obj_XacNhanDonHang_Linev2> Line { set; get; }
    }

    public class ChiTietDonHang
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string PoType { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? expDate { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string linkanh { get; set; }
        public DateTime? HanSuDung { get; set; }
        public decimal TotalQuantity { get; set; }
        public bool CheckHanSuDung { get; set; }
    }

    public class ChiTietDonHang_Tkey
    {
        public string userid { get; set; }
        public string vendor { get; set; }
        public int ID { get; set; }
    }

    public class XacNhanThongTinSanPham
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string PoType { get; set; }
        public DateTime RequestDate { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string linkanh { get; set; }
        public string NCC { get; set; }
        public decimal GiaMuaNet { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public int ConfirmID { get; set; }
        public int SL { get; set; }
        public int tongSLxacnhan { get; set; }
        public string Status { get; set; }
    }

    //get_donhang_daxacnhangiao
    public class get_donhang_daxacnhangiao
    {
        public int ID { get; set; }
        public int prePO_ID { get; set; }
        public int ParentID { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public decimal GiaMua { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string HanSD { get; set; }
        public string linkanh { get; set; }
        public long DotGiao { get; set; }
        public DateTime NgayGiao { get; set; }
    }

    public class get_chitietdonhang_ncc
    {
        public int ID { get; set; }
        public int ID_DonHang { get; set; }
        public int prePO_ID { get; set; }
        public int ParentID { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public decimal GiaMua { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string HanSD { get; set; }
        public string linkanh { get; set; }
        public DateTime NgayXacNhan_GiaoHang { get; set; }
        public long DotGiao { get; set; }
        public string TrangThai { get; set; }
        public string TrangThaiCode { get; set; }
        public string XeVanChuyen { get; set; }
        public string TaiXe { get; set; }
        public string sdtTaixe { get; set; }
        public string NgayGiao { get; set; }
        //public string GioGiao { get; set; }
        //public DateTime NgayGiao { get; set; }
    }

    public class get_donhanggiao_bydate
    {
        public int ID { get; set; }
        public string PoNo { get; set; }
        public string TenKho { get; set; }
        public DateTime NgayGiao { get; set; }
        public long DotGiao { get; set; }
        public int slsanpham { get; set; }
        public string TrangThai { get; set; }
        public string TrangThaiCode { get; set; }
    }

    public class updatelichgiaohang_ncc
    {
        public int ID { get; set; }
        public int isAccept { get; set; }
        public string lydo { get; set; }
        public string sdt { get; set; }
        public string DeXuatGioGiao { get; set; }
        public string DeXuatNgayGiao { get; set; }
    }

    public class updatexegiao_ncc
    {
        public int ID { get; set; }
        public string xe { get; set; }
        public string taixe { get; set; }
        public string sdt { get; set; }
        public string DonViGiaoHang { get; set; }
        public string CCCD { get; set; }
    }

    public class RouteInfo
    {
        public int RespId { get; set; }
        public string RespMsg { get; set; }
        public bool codeReturn { get; set; }
        public Array PushSalesLine { get; set; }
    }
}