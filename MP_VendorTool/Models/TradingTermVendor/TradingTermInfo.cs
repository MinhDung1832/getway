using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.TradingTermVendor
{
    public class RouteInfo
    {
        public int RespId { get; set; }
        public string RespMsg { get; set; }
    }
    public class objCONTENT_RETURNS_GOODS
    {
        public string contentApply { get; set; }
        public string changeReturns { get; set; }
        public string refundTerm { get; set; }
        public string Penalty { get; set; }
    }
    public class objCONTENT_RETURNS_GOODS_View
    {
        public string contentApply { get; set; }
        public string changeReturns { get; set; }
        public string refundTerm { get; set; }
        public string Penalty { get; set; }
        public string Satus { get; set; }
        public string TypeTab { get; set; }
        public string Conten { get; set; }
    }
    public class DoiTraHang_Show
    {
        public int TongSo { get; set; }
    }
    public class obj_TRADTERM_LEADTIME_View
    {
        public string Leadtimesx { get; set; }
        public string ThoiGianKyHD { get; set; }
        public string ThanhToan { get; set; }
        public string DongCongVaHQXuat { get; set; }
        public string DiBien { get; set; }
        public string ThuTucHQDauNhap { get; set; }
        public string TongLeadtime { get; set; }
        public string TypeTab { get; set; }
    }

    public class obj_TRADTERM_CHIPHIVANHANH
    {
        public string NoiDungDauTu { get; set; }
        public string PTDauTu { get; set; }
        public string GiaTriDauTu { get; set; }
        public string DieuKien { get; set; }
        public string DiBien { get; set; }
        public string salesConditions { get; set; }
        public string TypeTab { get; set; }
    }
    public class ObjTradeRequest
    {
        public string SourceContract { get; set; }
        public string SourceCoopInfoVendors { get; set; }
        public string SourceHangHoa { get; set; }
        public string SourceHangHoaFunction { get; set; }
        public string SourceHangHoaBrand { get; set; }
        public string SourceChietKhau { get; set; }
        public string SourceHangTang { get; set; }
        public string SourceBonus { get; set; }
        public string SourceTrade { get; set; }
        public string SourceThuongHieu { get; set; }
        public string SourceCustomer { get; set; }
        public string SourceDoiTra { get; set; }
        public string SourceThanhToan { get; set; }
        public string SourceHopTacKhac { get; set; }
        public string SourceLeaderTime { get; set; }
        public string SourceChiPhiVanHanh { get; set; }
        public string SourceHangThueKe { get; set; }
        public string SourceThueKeBrand { get; set; }
        public string SourceThueKeFunction { get; set; }
        public string SourceThongTinChung { get; set; }
    }
    public class objBrandBonus
    {
        public string VendorNo { get; set; }
        public string ContractNo { get; set; }
        public string content_invest { get; set; }
        public string percent_invest { get; set; }
        public string invest_value { get; set; }
        public string Description { get; set; }
        public string salesConditions { get; set; }
        public string TypeTab { get; set; }

    }
    public class objApplyReturnProduct
    {
        public string VendorNo { get; set; }
        public string ContractNo { get; set; }
        public string confirmChange { get; set; }
        public string Conten { get; set; }
        public string Satus { get; set; }
        public string TypeTab { get; set; }
        public string refundTerm { get; set; }
        public string Penalty { get; set; }
        public string BaoTruocNgay { get; set; }
    }
    public class objCooperationOther
    {
        public string VendorNo { get; set; }
        public string ContractNo { get; set; }
        public string content1 { get; set; }
        public string content2 { get; set; }
        public string content3 { get; set; }
        public string TypeTab { get; set; }

    }
    public class objCUSTOMERBONUS
    {
        public string VendorNo { get; set; }
        public string ContractNo { get; set; }
        public string content_invest { get; set; }
        public string percent_invest { get; set; }
        public string invest_value { get; set; }
        public string Description { get; set; }
        public string salesConditions { get; set; }
        public string TypeTab { get; set; }

    }

    public class objDISCOUNTQTTY
    {
        public string VendorNo { get; set; }
        public string ContractNo { get; set; }
        public string Co_OperateTypeID { get; set; }
        public string quantityBuy { get; set; }
        public string QuantityGifts { get; set; }
        public string TypeTab { get; set; }

    }

    public class objDISCOUNTSALES
    {
        public string VendorNo { get; set; }
        public string ContractNo { get; set; }
        public string Co_OperateTypeID { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string DiscountSalesType { get; set; }
        public string DiscountAmount { get; set; }
        public string DiscountPercent { get; set; }
        public string OrderValue { get; set; }
        public string TypeTab { get; set; }


    }

    public class objLINEBONUS
    {
        public string VendorNo { get; set; }
        public string ContractNo { get; set; }
        public string BonusType { get; set; }
        public string SalesLevel { get; set; }
        public string SalesLevelDen { get; set; }
        public string SalesConditions { get; set; }
        public string DiscountPercent { get; set; }
        public string DiscountAmountNoVAT { get; set; }
        public string Description { get; set; }
        public string DKDSTinhThuong { get; set; }
        public string TypeTab { get; set; }
    }

    public class objMKTBONUS
    {
        public string VendorNo { get; set; }
        public string ContractNo { get; set; }
        public string content_invest { get; set; }
        public string percent_invest { get; set; }
        public string invest_value { get; set; }
        public string Description { get; set; }
        public string salesConditions { get; set; }
        public string TypeTab { get; set; }
    }

    public class objPAYMENT
    {
        public string VendorNo { get; set; }
        public string ContractNo { get; set; }
        public string TypeOrder { get; set; }
        public string PaymentPeriod { get; set; }
        public string OnDay { get; set; }
        public string AndDay { get; set; }
        public string ApplyFor { get; set; }
        public string Content { get; set; }
        public string TypeTab { get; set; }
    }
    public class objPAYMENT_View
    {
        public string VendorNo { get; set; }
        public string ContractNo { get; set; }
        public string TypeOrder { get; set; }
        public string PaymentPeriod { get; set; }
        public string OnDay { get; set; }
        public string AndDay { get; set; }
        public string ApplyFor { get; set; }
        public string TypeTab { get; set; }
        public string Text { get; set; }

        public string Content { get; set; }
    }

    public class APDung_HoangHoa_New
    {
        public string MaSP { set; get; }
        public string NameProduct { set; get; }
        public string Barcode { set; get; }
        public string M2netSP { set; get; }
        public string M2FGrossSP { set; get; }
        public string SoCHPhu { set; get; }
        public string SoMatTBCH { set; get; }
        public string Mien { set; get; }
        public string NgayBatDau { set; get; }
        public string NgayKetThuc { set; get; }
        public string NgaybatDauThue { set; get; }
        public string NgayDieuChinhKetThuc { set; get; }
        public string TuDongGiaHan { set; get; }
        public string HieuLuc { set; get; }
    }

    public class ThongTinChung
    {
        public string SoCHThue { get; set; }
        public string SoThang { get; set; }
        public string M2FThue { get; set; }
        public string CpThueCHThang { get; set; }
        public string TongPhiThueThang { get; set; }
        public string TongPhiThueNam { get; set; }
        public string DScamketThangCH { get; set; }
        public string Mien { get; set; }
        public string NgayKyHD { get; set; }
        public string NgayHetHan { get; set; }
        public string NgayBatDauTinhTienThue { get; set; }
        public string NgayDieuChinhKetThuc { get; set; }
        public string TuDongGiaHans { get; set; }
        public string TuDongGiaHan { get; set; }
        public string HieuLuc { get; set; }

    }
    public class DanhMucSanPham_ApDung
    {
        public string MaSP { get; set; }
        public string NameProduct { get; set; }
        public string Barcode { get; set; }
        public string M2netSP { get; set; }
        public string M2FGrossSP { get; set; }
        public string SoCHPhu { get; set; }
        public string SoMatTBCH { get; set; }
        public string Mien { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string NgaybatDauThue { get; set; }
        public string NgayDieuChinhKetThuc { get; set; }
        public string TuDongGiaHan { get; set; }
        public string HieuLuc { get; set; }
    }

}