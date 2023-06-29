using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.PriceAll
{
    public class PriceAll
    {
        public string ID { get; set; }
        public string MaHang { get; set; }
        public string NgayCapNhat { get; set; }
        public string PhanTramGP { get; set; }
        public string GBLAllMoi { get; set; }
        public string Status { get; set; }
        public string NguoiTao { get; set; }
        public string NgayTao { get; set; }
        public string NguoiDuyet { get; set; }
        public string NgayDuyet { get; set; }
        public string NgayGuiDuyetERP { get; set; }
        public string NguoiGuiDuyetERP { get; set; }
        public string JsonAPI { get; set; }

        public string PhanTramGiamGia { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayketThuc { get; set; }

    }
    public class BinhOnGia_ThiTruong
    {
        public string ID { get; set; }
        public string NCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string Images { get; set; }
        public string GiaBanAll { get; set; }
        public string GiaDoiThu { get; set; }
        public string TenDoiThu { get; set; }
        public string GiaGoiY { get; set; }
        public string GiaDieuChinh { get; set; }
        public string GiaMuaNet { get; set; }
        public string PhanTramGPMoi { get; set; }
        public string TrangThai { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string JsonAPI { get; set; }
    }
}
