using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Vendors
{
    public class InfoCompany
    {
        public string ID { set; get; }
        public string VendorCode { set; get; }
        public string LoaiHinhHopTacCode { set; get; }
        public string LoaiHinhHopTac { set; get; }
        public string TenDoanhNghiep { set; get; }
        public string DiaChi { set; get; }
        public string SoDienThoai { set; get; }
        public string Website { set; get; }
        public string Email { set; get; }
        public string Facebook { set; get; }
        public string LinhVucHoatDong { set; get; }
        public string LinhVucHoatDongCode { set; get; }
        public string SoDKKD { set; get; }
        public string MaSoThue { set; get; }
        public string SoTaiKhoan { set; get; }
        public string TaiNganHangCode { set; get; }
        public string TaiNganHang { set; get; }
        public string Invoice { set; get; }
        public string TenInvoiceCode { set; get; }
        public string TenInvoice { set; get; }
        public string ThoiGianHoatDongCode { set; get; }
        public string ThoiGianHoatDong { set; get; }
        public string SoLuongNhanSu { set; get; }
        public string DoBaoPhuCode { set; get; }
        public string DoBaoPhu { set; get; }
        public string DoanhThuNamTruocCode { set; get; }
        public string DoanhThuNamTruoc { set; get; }
        public string LoiTheDoanhNghiepCode { set; get; }
        public string LoiTheDoanhNghiep { set; get; }
        public string KhachHangChinh { set; get; }
        public string SoM2Kho { set; get; }
        public string SoLuongXe { set; get; }
        public string DaiDien { set; get; }
        public string EmailDaiDien { set; get; }
        public string ChucDanhDaiDienCode { set; get; }
        public string ChucDanhDaiDien { set; get; }
        public string PhoneDaiDien { set; get; }
        public string NguoiLienHe { set; get; }
        public string EmailLienHe { set; get; }
        public string ChucDanhLienHeCode { set; get; }
        public string ChucDanhLienHe { set; get; }
        public string PhoneLienHe { set; get; }
        public string Status { set; get; }
        public string CreatedBy { set; get; }
        public string CreatedDate { set; get; }
        public string ModifiedBy { set; get; }
        public string ModifiedDate { set; get; }
    }

    public class Info_MD_Vendor
    {
        public string LoaiHinhDoanhNghiep_Code { get; set; }
        public string TenDoanhNghiep { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string SoDKKD { get; set; }
        public string LinhVucHoatDong_Code { get; set; }
        public string MaSoThue { get; set; }
        public string ThoiGianHoatDong_Code { get; set; }
        public string SoLuongNhanSu { get; set; }
        public string DoPhuThiTruong_Code { get; set; }
        public string DoPhuThiTruong_Name { get; set; }
        public string DoanhThuNamTruoc_Code { get; set; }
        public string LoiTheCuaDN_Code { get; set; }
        public string KhachHangChinh { get; set; }
        public string DienTichKho_m2 { get; set; }
        public string SoLuongXeVanTai { get; set; }
        public string NguoiDaiDien { get; set; }
        public string EmailNguoiDaiDien { get; set; }
        public string ChucDanhNguoiDaiDien_Code { get; set; }
        public string SDT_NguoiDaiDien { get; set; }
        public string NguoiLienHe { get; set; }
        public string EmailNguoiLienHe { get; set; }
        public string ChucDanhNguoiLienHe_Code { get; set; }
        public string SDT_NguoiLienHe { get; set; }
    }
}