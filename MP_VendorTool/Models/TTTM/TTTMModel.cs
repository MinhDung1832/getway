namespace ProductAllTool.Models.TTTM
{
    public class ThoaThuan
    {
        public string ID { get; set; }
        public string SoHopDong { get; set; }
        public string ToDateHD { get; set; }
        public string FromDateHD { get; set; }
        public string SoPhuLuc { get; set; }
        public string ToDatePL { get; set; }
        public string FromDatePL { get; set; }
        public string TenDDBBM { get; set; }
        public string DaiDienBBM { get; set; }
        public string TenDDDoiTac { get; set; }
        public string DaiDienDoiTac { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string TinhTrang { get; set; }
    }

    public class DMSP
    {
        public string ID { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string VAT { get; set; }
        public string GiaADCK { get; set; }
        public string PTCK { get; set; }
        public string GiaSauCK { get; set; }
        public string ThuongDH { get; set; }
        public string RangeReviewCode { get; set; }
        public string RangeReview { get; set; }
        public string TinhTrang { get; set; }
        public string type { get; set; }
    }

    public class ChietKhau
    {
        public string ID { get; set; }
        public string MaCK { get; set; }
        public string LoaiCK { get; set; }
        public string HHTTCode { get; set; }
        public string HinhThucTT { get; set; }
        public string GiaTriCK { get; set; }
        public string PTCK { get; set; }
        public string GiaTriDHTD { get; set; }
        public string type { get; set; }
    }

    public class HTH
    {
        public string ID { get; set; }
        public string SLMua { get; set; }
        public string SLTang { get; set; }
        public string type { get; set; }
    }

    public class Thuong
    {
        public string ID { get; set; }
        public string LoaiThuongCode { get; set; }
        public string LoaiThuong { get; set; }
        public string MucDSTu { get; set; }
        public string MucDSDen { get; set; }
        public string DKDSCode { get; set; }
        public string DKDSTTCode { get; set; }
        public string DKDSTarget { get; set; }
        public string DKDSTinhThuong { get; set; }
        public string PTThuong { get; set; }
        public string GiaTriThuong { get; set; }
        public string GhiChu { get; set; }
        public string type { get; set; }
    }

    public class TradeMarketing
    {
        public string ID { get; set; }
        public string NDCode { get; set; }
        public string NDDauTu { get; set; }
        public string PTDauTu { get; set; }
        public string GiaTriDT { get; set; }
        public string DieuKien { get; set; }
        public string DKDoanhSoCode { get; set; }
        public string DKDoanhSo { get; set; }
        public string type { get; set; }
    }
    public class OBJ {
        public string SourceLineThuong { get; set; }
        public string SourceLineTrade { get; set; }
        public string SourceLineCK { get; set; }
        public string SourceLineHTH { get; set; }
        public string ThoaThuan { get; set; }
        public string DMSP { get; set; }
    }
}