using System;
using System.Collections.Generic;

namespace MP_VendorTool.Models.Refund
{
    public class Refund_Request_Producst
    {
        public string MaHang { set; get; }
        public string HanSuDung { set; get; }
        public string SoLuong { set; get; }
    }
    public class add_Refund_TaoMoiYeuCau_Line
    {
        public int SoLuongHoanHang { get; set; }
        public string MaHang { get; set; }
        public DateTime HanSD { get; set; }
        public string VendorCode { get; set; }
    }
    public class obj_Refund_TaoMoiYeuCau_Hearder
    {
        public string CreateBy { set; get; }
        public string VendorNo { set; get; }
        public string LyDoHoanHang { set; get; }
        public string GhiChu { set; get; }
    }
    public class RequestObject
    {
        public string MaHang { get; set; }
        public string HanSuDung { get; set; }
        public string SoLuong { get; set; }
    }

    public class REFUND_2023_Header
    {
        public int ID { get; set; }
        public string PoNoHH { get; set; }
        public string PoNoGiao { get; set; }
        public string VendorNo { get; set; }
        public string VendorName { get; set; }
        public string StoreCode { get; set; }
        public string StoreNhan { get; set; }
        public decimal TongSLHoanHang { get; set; }
        public decimal TongTien { get; set; }
        public DateTime NgayHoanHang { get; set; }
        public string LyDoHoanHang { get; set; }
        public string GhiChu { get; set; }
        public string XeVanChuyen { get; set; }
        public string TaiXe { get; set; }
        public string SdtTaixe { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public int ischeck { get; set; }
        public string User_XN_DonHH { get; set; }
        public DateTime Date_XN_DonHH { get; set; }
        public string LyDoTuChoi { get; set; }
        public string SDTLienHe { get; set; }
        public int IDHeader { get; set; }
        public string User_XN_ThoiGianNhanHang { get; set; }
        public DateTime Date_XN_ThoiGianNhanHang { get; set; }
        public string User_XN_TaoMoiYeuCau { get; set; }
        public string Trangthai { get; set; }
        public string TotalQuantity { get; set; }
        public string TotalAmount { get; set; }
        public string ThoigianNhanHang { get; set; }
        public string NgayHoanHangNew { get; set; }
        public string TongMaHang { get; set; }
        public string AnhCCCD { get; set; }
        public string AnhChungTu { get; set; }
        public string SLXacNhan { get; set; }
        public DateTime Date_XN_TaoMoiYeuCau { get; set; }
    }

    public class DonHangPoNo
    {
        public string IDHeader { get; set; }
        public string PoNoGiao { get; set; }
        public string NgayGiaoHang { get; set; }
        public string NgayGiaoHangv1 { get; set; }
        public string XeVanChuyen { get; set; }
        public string TaiXe { get; set; }
        public string sdtTaixe { get; set; }
    }
    public class obj_XacNhanThoiGianNhanHang
    {
        public int IDHeader { get; set; }
        public string PoNoGiao { get; set; }
        public DateTime NgayGiaoHang { get; set; }
        public string XeVanChuyen { get; set; }
        public string TaiXe { get; set; }
        public string SdtTaiXe { get; set; }
    }

    public class add_XacNhanThoiGianNhanHang
    {
        public int IDHeader { get; set; }
        public string PoNoGiao { get; set; }
        public string VendorNo { get; set; }
        public DateTime NgayGiaoHang { get; set; }
        public string XeVanChuyen { get; set; }
        public string TaiXe { get; set; }
        public string SdtTaiXe { get; set; }
        public string Userid { get; set; }
    }
    public class add_refund_XN_DonHH
    {
        public int IDHeader { get; set; }
        public string userid { get; set; }
        public string LyDoTuChoi { get; set; }
        public string SDTLienHe { get; set; }
        public string type { get; set; }
    }
}