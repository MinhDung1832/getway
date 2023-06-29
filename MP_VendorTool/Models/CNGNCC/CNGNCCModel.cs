namespace ProductAllTool.Models.CNGNCC
{
    public class CNGNCCModel
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MaNCC { get; set; }
        public string NCC { get; set; }
        public string GiaCu { get; set; }
        public string GiaCuVAT { get; set; }
        public string VAT { get; set; }
        public string GiaMoi { get; set; }
        public string GiaMoiVAT { get; set; }
    }

    public class Sp_Duyet_Model
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MaNCC { get; set; }
        public string NCC { get; set; }
        public string GiaMoi { get; set; }
        public string GiaMoiVAT { get; set; }
        public string VAT { get; set; }
        public string NgayBD { get; set; }
        public string NgayKT { get; set; }
        public string GiaNY { get; set; }
    }
}