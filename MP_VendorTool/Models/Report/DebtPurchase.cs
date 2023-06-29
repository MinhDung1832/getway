using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Report
{
    public class DebtPurchaseSource
    {
        public string SourceOrder { set; get; }
        public string SourceMienBac { set; get; }
        public string SourceMienNam { set; get; }
    }
    public class Detail_DebtPurchase
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string NgayLapDeNghi { set; get; }

    }
    public class DebtPurchase_Fillter
    {
        public string KyTinhCongNo { set; get; }
        public string HanThanhToanKyNay { set; get; }
        public string DieuKhoanThanhToan { set; get; }
    }

    public class DebtPurchase_header
    {
        public string RcptNo { set; get; }
        public string MaNCC { set; get; }
        public string KyTinhCongNo { set; get; }
        public string GhiChu { set; get; }
    }
    public class DebtPurchase
    {
        public string PostingDate { set; get; }
        public string RcptNo { set; get; }
        public string AmountIncludingVAT { set; get; }
        public string Amount { set; get; }
        public string VendorInvoiceNo { set; get; }
        public string GhiChu { set; get; }
        public string sumAmountIncludingVATDSThang { set; get; }
        public string sumAmountDSThang { set; get; }
        public string MinPostingDate { set; get; }
        public string MaxMinPostingDate { set; get; }
        public string sumAmountIncludingVAT { set; get; }
        public string sumAmount { set; get; }
    }
    public class objSumTradingtem
    {
        public string Name { set; get; }
        public string PhanTram { set; get; }
        public string DieuKienDoanhSo { set; get; }
        public string Total { set; get; }
    }
    public class objSumTradingtem_VanHanh
    {
        public string Name { set; get; }
        public string PhanTram { set; get; }
        public string DieuKienDoanhSo { set; get; }
        public string GiaTriDauTu { set; get; }
    }
    public class ReportDeposit_TradingTemMienBN
    {
        public string MaNCC { set; get; }
        public string Nam { set; get; }
        public string KyCongNo { set; get; }
        public string Tieude { set; get; }
        public string Total { set; get; }
        public string SoHD { set; get; }
        public string NgayHD { set; get; }
        public string GhiChu { set; get; }
        public string CreateBy { set; get; }
        public string TypeBy_NCC_BBM { set; get; }
        public string TypeMien { set; get; }
    }
    public class ReportDeposit_header
    {
        public string ItemNo { set; get; }
        public string MaNCC { set; get; }
        public string KyTinhCongNo { set; get; }//=PaymentDate
        public string Ngayban { set; get; }
        public string GhiChu { set; get; }
    }
    public class Obj_ReportDeposit
    {
        public string MaHang { set; get; }
        public string Tenhang { set; get; }
        public string Ton_DK { set; get; }
        public string QuantityMB { set; get; }
        public string QuantityMN { set; get; }
        public string Nhap { set; get; }
        public string XuatTra { set; get; }
        public string Ton_CK { set; get; }
        public string Giaban { set; get; }
        public string AmountMB { set; get; }
        public string AmountMN { set; get; }
        public string GhiChu { set; get; }
        public string SumTon_DK { set; get; }
        public string SumDoanhSoVAT { set; get; }
        public string SumQuantityMB { set; get; }
        public string SumQuantityMN { set; get; }
        public string SumNhap { set; get; }
        public string SumXuatTra { set; get; }
        public string SumTon_CK { set; get; }
        public string SumGiaban { set; get; }
        public string SumAmountMB { set; get; }
        public string SumAmountMN { set; get; }
        public string MinNgayBan { set; get; }
        public string MaxNgayBan { set; get; }
    }
}
