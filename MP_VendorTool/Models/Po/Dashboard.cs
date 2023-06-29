
using System;
using System.Collections.Generic;

namespace MP_VendorTool.Models.Dashboard
{
    public class Dashboard
    {
        public int Nam { get; set; }
        public decimal SL { get; set; }
        public decimal SalesAmount { get; set; }
    }
    public class Dasboard_DoanhSo
    {
        public string Nam { get; set; }
        public string TYPE { get; set; }
        public string SL { get; set; }
        public string SalesAmount { get; set; }
        public string totalAmount { get; set; }
        public string Perc { get; set; }
    }

    //Nam	TYPE	SL	SalesAmount	totalAmount	Perc

    public class Dasboard_DoanhSo_Thang
    {
        public string Nam { get; set; }
        public string Thang { get; set; }
        public decimal SL { get; set; }
        public decimal SalesAmount { get; set; }
    }
    public class Dasboard_DoanhSo_SanPham
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public decimal SL { get; set; }
        public decimal SalesAmount { get; set; }
    }
    public class Dasboard_forecast_DuBaoTangTruong
    {
        public int Nam { get; set; }
        public int Thang { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public int SongayKD { get; set; }
        public int SoCHKD { get; set; }
        public decimal SL { get; set; }
        public decimal SalesAmount { get; set; }
        public string linkanh { get; set; }
    }

    // Pgae 2

    public class SUPPLIER_Dasboard_D30
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public decimal SL { get; set; }
        public decimal SalesAmount { get; set; }
    }

    public class SUPPLIER_Dasboard_D30Detail
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string linkanh { get; set; }
        public decimal Candat { get; set; }
        public decimal Cuahangcoton { get; set; }
        public decimal Donhangchuagiao { get; set; }
        public decimal Price { get; set; }
    }
    public class SUPPLIER_FC_Khaibao_get
    {
        public int ID { get; set; }
        public string Vendor { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string Mien { get; set; }
        public int Tonhienco { get; set; }
        public string NgaySanXuat { get; set; }
        public string HanSuDung { get; set; }
        public string KhoXuat { get; set; }
        public string NgayGiao { get; set; }
        public decimal GiaBan { get; set; }
        public int Active { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }
    }

    public class Add_SUPPLIER_FC_Khaibao_Add
    {
        public int ID { get; set; }
        public string userid { get; set; }
        public string vendor { get; set; }
        public string item { get; set; }
        public string Mien { get; set; }
        public int Tonhienco { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public DateTime HanSuDung { get; set; }
        public string KhoXuat { get; set; }
        public DateTime NgayGiao { get; set; }
        public decimal GiaBan { get; set; }
    }

    public class SUPPLIER_FC_Khaibao_Add
    {
        public string item { get; set; }
        public string Mien { get; set; }
        public int ID { get; set; }
        public int Tonhienco { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public DateTime? HanSuDung { get; set; }
        public string KhoXuat { get; set; }
        public DateTime NgayGiao { get; set; }
        public decimal GiaBan { get; set; }
    }

    public class Add_SUPPLIER_FC_Khaibao_Add_KhuyenMai
    {
        public string userid { get; set; }
        public string vendor { get; set; }
        public string item { get; set; }
        public string Mien { get; set; }
        public int ID { get; set; }
        public string Contents { get; set; }
    }


    public class SUPPLIER_FC_Khaibao_Add_KhuyenMai
    {
        public string item { get; set; }
        public string Mien { get; set; }
        public int ID { get; set; }
        public string Contents { get; set; }
    }

    public class SUPPLIER_FC_Khaibao_khuyenMai_get
    {
        public int ID { get; set; }
        public string Vendor { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string Contents { get; set; }
        public int Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public class DemandForct
    {
        public List<SUPPLIER_Dasboard_D30Detail> Item_Detai { get; set; }
        public List<SUPPLIER_FC_Khaibao_get> Khaibao { get; set; }
        public List<SUPPLIER_FC_Khaibao_khuyenMai_get> KhuyenMai { get; set; }

    }


}