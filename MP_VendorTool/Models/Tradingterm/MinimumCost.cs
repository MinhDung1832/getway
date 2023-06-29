using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Tradingterm
{
    public class MinimumCost
    {
        public int ID { set; get; }
        public string MasterID { set; get; }
        public int NoStore { set; get; }
        public string VendorCode { set; get; }
        public string BrandCode { set; get; }
        public decimal ChiPhiToiThieuYTD { set; get; }
        public decimal DoanhSoBan { set; get; }
        public decimal LaiGop { set; get; }
        public string HieuQuaKinhDoanh { set; get; }
        public string Ranking { set; get; }
        public int Status { set; get; }
        public string CreateBy { set; get; }
        public DateTime CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public DateTime ModifyDate { set; get; }
        public List<MinimumCostDetail> lstdetail { set; get; }
        public List<MinimumCostDetailDSCH> lststore { set; get; }
    }
    public class MinimumCostDetail
    {
        public int ID { set; get; }
        public string MasterID { set; get; }
        public string VendorCode { set; get; }
        public string BrandCode { set; get; }
        public string BrandName { set; get; }
        public string TenSanPham { set; get; }
        public string HinhAnhSanPham { set; get; }
        public int MatTbSpCh { set; get; }
        public decimal ChiPhiToiThieu { set; get; }
        public decimal GPToiThieu { set; get; }
        public decimal GPHienHanh { set; get; }
        public decimal HieuQuaKinhDoanh { set; get; }
        public string HieuQuaKinhDoanhText { set; get; }
        public decimal MucDauTu { set; get; }
        public int Status { set; get; }
        public string GhiChu { set; get; }
        public string CreateBy { set; get; }
        public DateTime CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public DateTime ModifyDate { set; get; }
    }

    public class MinimumCostDetailDSCH
    {
        public int ID { set; get; }
        public string MasterID { set; get; }
        public string VendorCode { set; get; }
        public string BrandCode { set; get; }
        public string StoreCode { set; get; }
        public string StoreName { set; get; }
        public string Status { set; get; }
        public string GhiChu { set; get; }
        public string CreateBy { set; get; }
        public DateTime CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public DateTime ModifyDate { set; get; }
    }

    public class StoreInfo
    {
        public string StoreCode { set; get; }
        public string StoreName { set; get; }
        public string PostCode { set; get; }
        public string DateOpen { set; get; }
        public string DateClose { set; get; }
        public string RegionName { set; get; }
        public string RegionCode { set; get; }
        public string DistrictCode { set; get; }
        public string DistrictName { set; get; }
    }

    public class Brandinfo
    {
        public string BrandCode { set; get; }
        public string BrandName { set; get; }
    }

    public class HangMuc
    {
        public string ID { set; get; }
        public string HangMucCode { set; get; }
        public string HangMucName { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public DateTime CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public DateTime ModifyDate { set; get; }
    }

    public class KeHoach
    {
        public int ID { set; get; }
        public string VendorCode { set; get; }
        public string VendorName { set; get; }
        public string Year { set; get; }
        public decimal Thang1 { set; get; }
        public decimal Thang2 { set; get; }
        public decimal Thang3 { set; get; }
        public decimal Thang4 { set; get; }
        public decimal Thang5 { set; get; }
        public decimal Thang6 { set; get; }
        public decimal Thang7 { set; get; }
        public decimal Thang8 { set; get; }
        public decimal Thang9 { set; get; }
        public decimal Thang10 { set; get; }
        public decimal Thang11 { set; get; }
        public decimal Thang12 { set; get; }
        public decimal Quy1 { set; get; }
        public decimal Quy2 { set; get; }
        public decimal Quy3 { set; get; }
        public decimal Quy4 { set; get; }
        public decimal Mucdautu { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public DateTime CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public DateTime ModifyDate { set; get; }
    }

    public class KeHoachKhac
    {
        public int ID { set; get; }
        public string VendorCode { set; get; }
        public string VendorName { set; get; }
        public string HangMuc11 { set; get; }
        public decimal MucDauTu11 { set; get; }
        public string HangMuc12 { set; get; }
        public decimal MucDauTu12 { set; get; }
        public string HangMuc13 { set; get; }
        public decimal MucDauTu13 { set; get; }
        public decimal TongNganSach1 { set; get; }
        public string HangMuc21 { set; get; }
        public decimal MucDauTu21 { set; get; }
        public string HangMuc22 { set; get; }
        public decimal MucDauTu22 { set; get; }
        public string HangMuc23 { set; get; }
        public decimal MucDauTu23 { set; get; }
        public decimal TongNganSach2 { set; get; }
        public string HangMuc31 { set; get; }
        public decimal MucDauTu31 { set; get; }
        public string HangMuc32 { set; get; }
        public decimal MucDauTu32 { set; get; }
        public string HangMuc33 { set; get; }
        public decimal MucDauTu33 { set; get; }
        public decimal TongNganSach3 { set; get; }
        public string HangMuc41 { set; get; }
        public decimal MucDauTu41 { set; get; }
        public string HangMuc42 { set; get; }
        public decimal MucDauTu42 { set; get; }
        public string HangMuc43 { set; get; }
        public decimal MucDauTu43 { set; get; }
        public decimal TongNganSach4 { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public DateTime CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public DateTime ModifyDate { set; get; }
    }
}