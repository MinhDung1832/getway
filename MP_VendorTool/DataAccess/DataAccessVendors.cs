using MP_VendorTool.Models.Order;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using MP_VendorTool.Common;
using System.Web;
using System.Threading.Tasks;
using MP_VendorTool.Models.PushSale;
using MP_VendorTool.Models.OfferPrice;
using MP_VendorTool.Models.Report;
using MP_VendorTool.Models.Vendors;

namespace MP_VendorTool.DataAccess
{
    public class DataAccessVendors
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConnSpac = ConfigurationManager.AppSettings.Get("strConnSpac");

        public static bool InfoCompany_Save(InfoCompany info, string CreatedBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("InfoCompany_Save", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("VendorCode", CreatedBy != null ? CreatedBy : ""));
                    cmd.Parameters.Add(new SqlParameter("LoaiHinhHopTacCode", info.LoaiHinhHopTacCode != null ? info.LoaiHinhHopTacCode : ""));
                    cmd.Parameters.Add(new SqlParameter("LoaiHinhHopTac", info.LoaiHinhHopTac != null ? info.LoaiHinhHopTac : ""));
                    cmd.Parameters.Add(new SqlParameter("TenDoanhNghiep", info.TenDoanhNghiep != null ? info.TenDoanhNghiep : ""));
                    cmd.Parameters.Add(new SqlParameter("DiaChi", info.DiaChi != null ? info.DiaChi : ""));
                    cmd.Parameters.Add(new SqlParameter("SoDienThoai", info.SoDienThoai != null ? info.SoDienThoai : ""));
                    cmd.Parameters.Add(new SqlParameter("Website", info.Website != null ? info.Website : ""));
                    cmd.Parameters.Add(new SqlParameter("Email", info.Email != null ? info.Email : ""));
                    cmd.Parameters.Add(new SqlParameter("Facebook", info.Facebook != null ? info.Facebook : ""));

                    cmd.Parameters.Add(new SqlParameter("LinhVucHoatDongCode", info.LinhVucHoatDongCode != null ? info.LinhVucHoatDongCode : ""));
                    cmd.Parameters.Add(new SqlParameter("LinhVucHoatDong", info.LinhVucHoatDong != null ? info.LinhVucHoatDong : ""));

                    cmd.Parameters.Add(new SqlParameter("SoDKKD", info.SoDKKD != null ? info.SoDKKD : ""));
                    cmd.Parameters.Add(new SqlParameter("MaSoThue", info.MaSoThue != null ? info.MaSoThue : ""));
                    cmd.Parameters.Add(new SqlParameter("SoTaiKhoan", info.SoTaiKhoan != null ? info.SoTaiKhoan : ""));
                    cmd.Parameters.Add(new SqlParameter("TaiNganHangCode", info.TaiNganHangCode != null ? info.TaiNganHangCode : ""));
                    cmd.Parameters.Add(new SqlParameter("TaiNganHang", info.TaiNganHang != null ? info.TaiNganHang : ""));
                    cmd.Parameters.Add(new SqlParameter("Invoice", info.Invoice != null ? info.Invoice : "0"));
                    cmd.Parameters.Add(new SqlParameter("TenInvoiceCode", info.TenInvoiceCode != null ? info.TenInvoiceCode : ""));
                    cmd.Parameters.Add(new SqlParameter("TenInvoice", info.TenInvoice != null ? info.TenInvoice : ""));

                    cmd.Parameters.Add(new SqlParameter("ThoiGianHoatDongCode", info.ThoiGianHoatDongCode != null ? info.ThoiGianHoatDongCode : ""));
                    cmd.Parameters.Add(new SqlParameter("ThoiGianHoatDong", info.ThoiGianHoatDong != null ? info.ThoiGianHoatDong : ""));
                    cmd.Parameters.Add(new SqlParameter("SoLuongNhanSu", info.SoLuongNhanSu != null ? info.SoLuongNhanSu : ""));
                    cmd.Parameters.Add(new SqlParameter("DoBaoPhuCode", info.DoBaoPhuCode != null ? info.DoBaoPhuCode : ""));
                    cmd.Parameters.Add(new SqlParameter("DoBaoPhu", info.DoBaoPhu != null ? info.DoBaoPhu : ""));

                    cmd.Parameters.Add(new SqlParameter("DoanhThuNamTruocCode", info.DoanhThuNamTruocCode != null ? info.DoanhThuNamTruocCode : ""));
                    cmd.Parameters.Add(new SqlParameter("DoanhThuNamTruoc", info.DoanhThuNamTruoc != null ? info.DoanhThuNamTruoc : ""));

                    cmd.Parameters.Add(new SqlParameter("LoiTheDoanhNghiepCode", info.LoiTheDoanhNghiepCode != null ? info.LoiTheDoanhNghiepCode : ""));
                    cmd.Parameters.Add(new SqlParameter("LoiTheDoanhNghiep", info.LoiTheDoanhNghiep != null ? info.LoiTheDoanhNghiep : ""));
                    cmd.Parameters.Add(new SqlParameter("KhachHangChinh", info.KhachHangChinh != null ? info.KhachHangChinh : ""));
                    cmd.Parameters.Add(new SqlParameter("SoM2Kho", info.SoM2Kho != null ? info.SoM2Kho : ""));
                    cmd.Parameters.Add(new SqlParameter("SoLuongXe", info.SoLuongXe != null ? info.SoLuongXe : ""));

                    cmd.Parameters.Add(new SqlParameter("DaiDien", info.DaiDien != null ? info.DaiDien : ""));
                    cmd.Parameters.Add(new SqlParameter("EmailDaiDien", info.EmailDaiDien != null ? info.EmailDaiDien : ""));
                    cmd.Parameters.Add(new SqlParameter("ChucDanhDaiDienCode", info.ChucDanhDaiDienCode != null ? info.ChucDanhDaiDienCode : ""));
                    cmd.Parameters.Add(new SqlParameter("ChucDanhDaiDien", info.ChucDanhDaiDien != null ? info.ChucDanhDaiDien : ""));
                    cmd.Parameters.Add(new SqlParameter("PhoneDaiDien", info.PhoneDaiDien != null ? info.PhoneDaiDien : ""));
                    cmd.Parameters.Add(new SqlParameter("NguoiLienHe", info.NguoiLienHe != null ? info.NguoiLienHe : ""));
                    cmd.Parameters.Add(new SqlParameter("EmailLienHe", info.EmailLienHe != null ? info.EmailLienHe : ""));

                    cmd.Parameters.Add(new SqlParameter("ChucDanhLienHeCode", info.ChucDanhLienHeCode != null ? info.ChucDanhLienHeCode : ""));
                    cmd.Parameters.Add(new SqlParameter("ChucDanhLienHe", info.ChucDanhLienHe != null ? info.ChucDanhLienHe : ""));
                    cmd.Parameters.Add(new SqlParameter("PhoneLienHe", info.PhoneLienHe != null ? info.PhoneLienHe : ""));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "InfoCompany_Save");
                    return false;
                }
            }
        }
        public static List<InfoCompany> sp_VendorTool_InfoCompany_get(string VendorCode)
        {
            List<InfoCompany> it_r = new List<InfoCompany>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_VendorTool_InfoCompany_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        InfoCompany it = new InfoCompany
                        {
                            VendorCode = reader["VendorCode"].ToString(),
                            LoaiHinhHopTacCode = reader["LoaiHinhHopTacCode"].ToString(),
                            LoaiHinhHopTac = reader["LoaiHinhHopTac"].ToString(),
                            TenDoanhNghiep = reader["TenDoanhNghiep"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            Website = reader["Website"].ToString(),
                            Facebook = reader["Facebook"].ToString(),
                            LinhVucHoatDong = reader["LinhVucHoatDong"].ToString(),
                            LinhVucHoatDongCode = reader["LinhVucHoatDongCode"].ToString(),
                            SoDKKD = reader["SoDKKD"].ToString(),
                            MaSoThue = reader["MaSoThue"].ToString(),
                            SoTaiKhoan = reader["SoTaiKhoan"].ToString(),
                            TaiNganHangCode = reader["TaiNganHangCode"].ToString(),
                            TaiNganHang = reader["TaiNganHang"].ToString(),
                            Invoice = reader["Invoice"].ToString(),
                            TenInvoiceCode = reader["TenInvoiceCode"].ToString(),
                            TenInvoice = reader["TenInvoice"].ToString(),
                            ThoiGianHoatDongCode = reader["ThoiGianHoatDongCode"].ToString(),
                            ThoiGianHoatDong = reader["ThoiGianHoatDong"].ToString(),
                            SoLuongNhanSu = reader["SoLuongNhanSu"].ToString(),
                            DoBaoPhuCode = reader["DoBaoPhuCode"].ToString(),
                            DoBaoPhu = reader["DoBaoPhu"].ToString(),
                            DoanhThuNamTruocCode = reader["DoanhThuNamTruocCode"].ToString(),
                            DoanhThuNamTruoc = reader["DoanhThuNamTruoc"].ToString(),
                            LoiTheDoanhNghiepCode = reader["LoiTheDoanhNghiepCode"].ToString(),
                            LoiTheDoanhNghiep = reader["LoiTheDoanhNghiep"].ToString(),
                            KhachHangChinh = reader["KhachHangChinh"].ToString(),
                            SoM2Kho = reader["SoM2Kho"].ToString(),
                            SoLuongXe = reader["SoLuongXe"].ToString(),
                            DaiDien = reader["DaiDien"].ToString(),
                            EmailDaiDien = reader["EmailDaiDien"].ToString(),
                            ChucDanhDaiDien = reader["ChucDanhDaiDien"].ToString(),
                            ChucDanhDaiDienCode = reader["ChucDanhDaiDienCode"].ToString(),
                            PhoneDaiDien = reader["PhoneDaiDien"].ToString(),
                            NguoiLienHe = reader["NguoiLienHe"].ToString(),
                            EmailLienHe = reader["EmailLienHe"].ToString(),
                            ChucDanhLienHeCode = reader["ChucDanhLienHeCode"].ToString(),
                            ChucDanhLienHe = reader["ChucDanhLienHe"].ToString(),

                            PhoneLienHe = reader["PhoneLienHe"].ToString(),
                            Status = reader["Status"].ToString(),
                            CreatedBy = reader["CreatedBy"].ToString(),
                            CreatedDate = reader["CreatedDate"].ToString(),
                            ModifiedBy = reader["ModifiedBy"].ToString(),
                            ModifiedDate = reader["ModifiedDate"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VendorTool_InfoCompany_get");
                    return it_r;
                }
            }
        }

        public static bool InfoCompany_RegisterPartner_Save(InfoCompany info, string CreatedBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("InfoCompany_RegisterPartner_Save", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("VendorCode", CreatedBy != null ? CreatedBy : ""));
                    cmd.Parameters.Add(new SqlParameter("LoaiHinhHopTacCode", info.LoaiHinhHopTacCode != null ? info.LoaiHinhHopTacCode : ""));
                    cmd.Parameters.Add(new SqlParameter("LoaiHinhHopTac", info.LoaiHinhHopTac != null ? info.LoaiHinhHopTac : ""));
                    cmd.Parameters.Add(new SqlParameter("TenDoanhNghiep", info.TenDoanhNghiep != null ? info.TenDoanhNghiep : ""));
                    cmd.Parameters.Add(new SqlParameter("DiaChi", info.DiaChi != null ? info.DiaChi : ""));
                    cmd.Parameters.Add(new SqlParameter("SoDienThoai", info.SoDienThoai != null ? info.SoDienThoai : ""));
                    cmd.Parameters.Add(new SqlParameter("Website", info.Website != null ? info.Website : ""));
                    cmd.Parameters.Add(new SqlParameter("Email", info.Email != null ? info.Email : ""));
                    cmd.Parameters.Add(new SqlParameter("Facebook", info.Facebook != null ? info.Facebook : ""));

                    cmd.Parameters.Add(new SqlParameter("LinhVucHoatDongCode", info.LinhVucHoatDongCode != null ? info.LinhVucHoatDongCode : ""));
                    cmd.Parameters.Add(new SqlParameter("LinhVucHoatDong", info.LinhVucHoatDong != null ? info.LinhVucHoatDong : ""));

                    cmd.Parameters.Add(new SqlParameter("SoDKKD", info.SoDKKD != null ? info.SoDKKD : ""));
                    cmd.Parameters.Add(new SqlParameter("MaSoThue", info.MaSoThue != null ? info.MaSoThue : ""));
                    cmd.Parameters.Add(new SqlParameter("SoTaiKhoan", info.SoTaiKhoan != null ? info.SoTaiKhoan : ""));
                    cmd.Parameters.Add(new SqlParameter("TaiNganHangCode", info.TaiNganHangCode != null ? info.TaiNganHangCode : ""));
                    cmd.Parameters.Add(new SqlParameter("TaiNganHang", info.TaiNganHang != null ? info.TaiNganHang : ""));
                    cmd.Parameters.Add(new SqlParameter("Invoice", info.Invoice != null ? info.Invoice : "0"));
                    cmd.Parameters.Add(new SqlParameter("TenInvoiceCode", info.TenInvoiceCode != null ? info.TenInvoiceCode : ""));
                    cmd.Parameters.Add(new SqlParameter("TenInvoice", info.TenInvoice != null ? info.TenInvoice : ""));

                    cmd.Parameters.Add(new SqlParameter("ThoiGianHoatDongCode", info.ThoiGianHoatDongCode != null ? info.ThoiGianHoatDongCode : ""));
                    cmd.Parameters.Add(new SqlParameter("ThoiGianHoatDong", info.ThoiGianHoatDong != null ? info.ThoiGianHoatDong : ""));
                    cmd.Parameters.Add(new SqlParameter("SoLuongNhanSu", info.SoLuongNhanSu != null ? info.SoLuongNhanSu : ""));
                    cmd.Parameters.Add(new SqlParameter("DoBaoPhuCode", info.DoBaoPhuCode != null ? info.DoBaoPhuCode : ""));
                    cmd.Parameters.Add(new SqlParameter("DoBaoPhu", info.DoBaoPhu != null ? info.DoBaoPhu : ""));

                    cmd.Parameters.Add(new SqlParameter("DoanhThuNamTruocCode", info.DoanhThuNamTruocCode != null ? info.DoanhThuNamTruocCode : ""));
                    cmd.Parameters.Add(new SqlParameter("DoanhThuNamTruoc", info.DoanhThuNamTruoc != null ? info.DoanhThuNamTruoc : ""));

                    cmd.Parameters.Add(new SqlParameter("LoiTheDoanhNghiepCode", info.LoiTheDoanhNghiepCode != null ? info.LoiTheDoanhNghiepCode : ""));
                    cmd.Parameters.Add(new SqlParameter("LoiTheDoanhNghiep", info.LoiTheDoanhNghiep != null ? info.LoiTheDoanhNghiep : ""));
                    cmd.Parameters.Add(new SqlParameter("KhachHangChinh", info.KhachHangChinh != null ? info.KhachHangChinh : ""));
                    cmd.Parameters.Add(new SqlParameter("SoM2Kho", info.SoM2Kho != null ? info.SoM2Kho : ""));
                    cmd.Parameters.Add(new SqlParameter("SoLuongXe", info.SoLuongXe != null ? info.SoLuongXe : ""));

                    cmd.Parameters.Add(new SqlParameter("DaiDien", info.DaiDien != null ? info.DaiDien : ""));
                    cmd.Parameters.Add(new SqlParameter("EmailDaiDien", info.EmailDaiDien != null ? info.EmailDaiDien : ""));
                    cmd.Parameters.Add(new SqlParameter("ChucDanhDaiDienCode", info.ChucDanhDaiDienCode != null ? info.ChucDanhDaiDienCode : ""));
                    cmd.Parameters.Add(new SqlParameter("ChucDanhDaiDien", info.ChucDanhDaiDien != null ? info.ChucDanhDaiDien : ""));
                    cmd.Parameters.Add(new SqlParameter("PhoneDaiDien", info.PhoneDaiDien != null ? info.PhoneDaiDien : ""));
                    cmd.Parameters.Add(new SqlParameter("NguoiLienHe", info.NguoiLienHe != null ? info.NguoiLienHe : ""));
                    cmd.Parameters.Add(new SqlParameter("EmailLienHe", info.EmailLienHe != null ? info.EmailLienHe : ""));

                    cmd.Parameters.Add(new SqlParameter("ChucDanhLienHeCode", info.ChucDanhLienHeCode != null ? info.ChucDanhLienHeCode : ""));
                    cmd.Parameters.Add(new SqlParameter("ChucDanhLienHe", info.ChucDanhLienHe != null ? info.ChucDanhLienHe : ""));
                    cmd.Parameters.Add(new SqlParameter("PhoneLienHe", info.PhoneLienHe != null ? info.PhoneLienHe : ""));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "InfoCompany_Save");
                    return false;
                }
            }
        }
    }
}