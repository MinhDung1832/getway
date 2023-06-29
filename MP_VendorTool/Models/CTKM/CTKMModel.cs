namespace ProductAllTool.Models
{
    public class CTKMModel
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string DonGia { get; set; }
        public int SLQua { get; set; }
        public int SLMua { get; set; }
        public string PTQua { get; set; }
        public string MaCTKM { get; set; }
        public string TenCTKM { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
    }

    public class CBKMModel
    {
        public string MaCTKM { get; set; }
        public string TenCTKM { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
    }

    public class CBKMUpdate
    {
        public string ID { get; set; }
        public string type { get; set; }
        public string MaCTKM { get; set; }
    }

    public class CBKM_MuaHang
    {
        public string ID { set; get; }
        public string MaCTKM { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string DonGia { set; get; }
        public string SoLuong { set; get; }
        public string PTQua { set; get; }
    }

    public class CBKM_HangTang
    {
        public string ID { set; get; }
        public string MaCTKM { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string DonGia { set; get; }
        public string SLTang { set; get; }
    }
    public class AddCBKM {
        public string HangMua { get; set; }
        public string HangTang { get; set; }
        public string CTKM { get; set; }
    }
    public class Anh
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
    }
}