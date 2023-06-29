using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.PushSale
{
    public class ObjPushSales_DiscountOffer
    {
        public string SourceCTKMPrice { get; set; }
        public string SourceCTKM { get; set; }

    }
    public class ObjPushSales_MixMaxLine
    {
        public string SourceMixMatch { get; set; }
        public string SourceMixMaxLine { get; set; }
        public string SourceMixMaxLineGroup { get; set; }
    }
    public class ObjPushSales_TotalDiscount
    {
        public string SourceTotalDiscount { get; set; }
        public string SourceTotalTotalDiscount { get; set; }
        public string SourceTotalTotalDiscountLine { get; set; }
    }

    public class objContracNo
    {
        public string VendorNo { get; set; }
        public string VendorName { get; set; }
        public string SoCHKinhDoanh { get; set; }
        public string DoanhSoY1 { get; set; }
        public string DoanhSoYTD { get; set; }
        public string NgayTonKho { get; set; }
        public string GPM2F { get; set; }
        public string GPThucDat { get; set; }
        public string GAP { get; set; }

    }
    public class PUSHSALES_Header
    {
        public string ID { set; get; }
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string SoCHKinhDoanh { set; get; }
        public string DoanhSoY1 { set; get; }
        public string DoanhSoYTD { set; get; }
        public string NgayTonKho { set; get; }
        public string GPToiThieuNam { set; get; }
        public string GPThucDatNam { set; get; }
        public string GAP { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }
    }

    public class PUSHSALES_ThuongNhanVien
    {
        public string ID { set; get; }
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string CodeDiv { set; get; }
        public string NameDiv { set; get; }
        public string CodeBrand { set; get; }
        public string NameBrand { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string Bonus { set; get; }
        public string FromDay { set; get; }
        public string ToDay { set; get; }
        public string CodePhamVi { set; get; }
        public string NamePhamVi { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }

    }

    public class PUSHSALES_GiaTangTrungBay
    {
        public string ID { set; get; }
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string CodeDiv { set; get; }
        public string NameDiv { set; get; }
        public string CodeBrand { set; get; }
        public string NameBrand { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string SoCuaHang { set; get; }
        public string SoMatHangTrungBay { set; get; }
        public string DonGiaCHMTB { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }
    }
    public class Obj_Discount_Offer
    {
        public string MaCTKM { get; set; }
        public string FromDay { get; set; }
        public string ToDay { get; set; }
        public string CouponCode { get; set; }
        public string CouponName { get; set; }
        public string PriceGroupCode { get; set; }
        public string PriceGroupName { get; set; }
        public string Status { get; set; }
    }
    public class Obj_Discount_Offer_Line
    {
        public string Type { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string DiscStdPrice { get; set; }
        public string DiscAmountStdPrice { get; set; }
    }

    public class Obj_MixMatch
    {
        public string MaCTKM { get; set; }
        public string FromDay { get; set; }
        public string ToDay { get; set; }
        public string CouponCode { get; set; }
        public string CouponName { get; set; }
        public string PriceGroupCode { get; set; }
        public string PriceGroupName { get; set; }
        public string NoOfLeastItem { get; set; }
        public string Leastexp { get; set; }
        public string Same_DifLine { get; set; }
        public string Mix_DiscountType { get; set; }
        public string DealPriceValue { get; set; }
        public string DiscValue { get; set; }
        public string DiscountAmoutValue { get; set; }
        public string NoTimeApp { get; set; }
        public string Status { get; set; }
    }
    public class Obj_MixMatch_Line_Groups
    {
        public string LineGroupCode { get; set; }
        public string lineGroupType { get; set; }
        public string lineGroupType1 { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
    }

    public class Obj_MixMatch_Line
    {
        public string Type { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string NoItemNeeded { get; set; }
        public string DealPriceDiscPercent { get; set; }
        public string DiscType { get; set; }
        public string DiscType1 { get; set; }
        public string LineGroup { get; set; }
    }

    public class Obj_Total_Discount
    {
        public string MaCTKM { get; set; }
        public string FromDay { get; set; }
        public string ToDay { get; set; }
        public string CouponCode { get; set; }
        public string CouponName { get; set; }
        public string PriceGroupCode { get; set; }
        public string PriceGroupName { get; set; }
        public string Status { get; set; }

    }

    public class Obj_Total_Discount_Line
    {
        public string Type { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
    public class Obj_Total_Discount_Line_Benefits
    {
        public string StepAmount { get; set; }
        public string Type { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ValueType { get; set; }
        public string ValueType1 { get; set; }
        public string Value { get; set; }
    }
    public class obj_TangCuongNhanDien
    {
        public string ID { get; set; }
        public string IDPushSale { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string HangMuc { get; set; }
        public string DonVi { get; set; }
        public string DonGia { get; set; }
        public string SoLuong { get; set; }
        public string FromDay { get; set; }
        public string ToDay { get; set; }
        public string ThanhTien { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }

    }

    public class PushSale_Vender_Item
    {
        public string IDPuSale { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string PhanTramKM { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }
        public string ischeck { get; set; }


    }


}
