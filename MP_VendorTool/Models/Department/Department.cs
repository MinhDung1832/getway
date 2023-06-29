using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Department
{
    public class Department_ChucDanh_NCC
    {
        public string ID { get; set; }
        public string MoTa { get; set; }
        public string TenChucDanh { get; set; }
        public string Vendor { get; set; }
        public string CreateBy { get; set; }
    }
    public class Department_VaiTro_NCC
    {
        public string ID { get; set; }
        public string MoTa { get; set; }
        public string VaiTro { get; set; }
        public string Vendor { get; set; }
        public string CreateBy { get; set; }
    }

    public class Add_NhanVien_PhongBan_Roll
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string VendorCode { get; set; }
        public string PhongBan { get; set; }
        public string NguoiDaiDien { get; set; }
        public string AnhDaiDien { get; set; }
        public string ChucDanh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QuanLyCap1 { get; set; }
        public string SDTQuanLyCap1 { get; set; }
        public string EmailQuanLyCap1 { get; set; }
        public string QuanLyCap2 { get; set; }
        public string SDTQuanLyCap2 { get; set; }
        public string EmailQuanLyCap2 { get; set; }
        public string CreateBy { get; set; }
        public string Mien { get; set; }
        public string ThuongHieu { get; set; }
    }
    public class NhanVien_PhongBan_Roll
    {
        public int ID { get; set; }
        public string VendorCode { get; set; }
        public string UserName { get; set; }
        public string PhongBan { get; set; }
        public string NguoiDaiDien { get; set; }
        public string AnhDaiDien { get; set; }
        public string ChucDanh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public string QuanLyCap1 { get; set; }
        public string SDTQuanLyCap1 { get; set; }
        public string EmailQuanLyCap1 { get; set; }
        public string QuanLyCap2 { get; set; }
        public string SDTQuanLyCap2 { get; set; }
        public string EmailQuanLyCap2 { get; set; }
        public string StatusNCC { get; set; }
        public string Status { get; set; }
        public string StatusSend { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ChucDanhNew { get; set; }
        public string PhongBanNew { get; set; }
        public string Mien { get; set; }
        public string ThuongHieu { get; set; }
    }
    public class RouteInfo
    {
        public int RespId { get; set; }
        public string RespMsg { get; set; }
        public bool codeReturn { get; set; }
        public Array PushSalesLine { get; set; }
    }
    public class Department_VaiTro_NCC_info
    {
        public int ID { get; set; }
        public string VaiTro { get; set; }
        public string MoTa { get; set; }
        public string Vendor { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
    public class Department_ChucDanh_NCC_info
    {
        public int ID { get; set; }
        public string TenChucDanh { get; set; }
        public string MoTa { get; set; }
        public string Vendor { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}