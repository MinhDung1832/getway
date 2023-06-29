using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models
{
    public class CTKM_Product
    {
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string MaSP { set; get; }
        public string TenSP { set; get; }
        public string Images { set; get; }

    }
    public class CTKM
    {
        public string SourceHeader { set; get; }
        public string SourceLine { set; get; }
    }
    public class CTKM_Header
    {
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string MaCTKM { set; get; }
        public string TenCTKM { set; get; }
        public string TuNgay { set; get; }
        public string DenNgay { set; get; }
        public string CreateBy { set; get; }
    }
    public class CTKM_Line
    {
        public string MaCTKM { set; get; }
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string HinhAnh { set; get; }
        public string SLHang { set; get; }
        public string MaQua { set; get; }
        public string TenQua { set; get; }
        public string SLQua { set; get; }

    }
    public class CTKM_GateWay
    {
        public string MaNCC { get; set; }
        public string Status { get; set; }
        public string MaCTKM { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }

    }
    public class CTKM_Ql_GateWay
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaCTKM { get; set; }
        public string TenCTKM { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string SLHang { get; set; }
        public string MaQua { get; set; }
        public string TenQua { get; set; }
        public string SLQua { get; set; }
        public string HinhAnh { get; set; }
        public string Status { get; set; }
        public string TrangThai { get; set; }
        public string CreateDate { get; set; }
        public string ModifyDate { get; set; }
    }
}
