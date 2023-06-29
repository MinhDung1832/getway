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
using MP_VendorTool.Models.Newoffer;

namespace MP_VendorTool.DataAccess
{
    public class DataAccessNewoffer
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConnSpac = ConfigurationManager.AppSettings.Get("strConnSpac");

        public static bool InfoNewoffer_Save(InfoNewoffer info, string CreatedBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Newoffer_Save", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("NganhHangCode", info.NganhHangCode != null ? info.NganhHangCode : ""));
                    cmd.Parameters.Add(new SqlParameter("NganhHang", info.NganhHang != null ? info.NganhHang : ""));
                    cmd.Parameters.Add(new SqlParameter("TenSanPham", info.TenSanPham != null ? info.TenSanPham : ""));
                    cmd.Parameters.Add(new SqlParameter("Barcode", info.Barcode != null ? info.Barcode : ""));
                    cmd.Parameters.Add(new SqlParameter("XuatXuCode", info.XuatXuCode != null ? info.XuatXuCode : ""));
                    cmd.Parameters.Add(new SqlParameter("XuatXu", info.XuatXu != null ? info.XuatXu : ""));
                    cmd.Parameters.Add(new SqlParameter("MauSac", info.MauSac != null ? info.MauSac : ""));
                    cmd.Parameters.Add(new SqlParameter("Size", info.Size != null ? info.Size : ""));
                    cmd.Parameters.Add(new SqlParameter("Tuoi", info.Tuoi != null ? info.Tuoi : ""));
                    cmd.Parameters.Add(new SqlParameter("TrongLuong", info.TrongLuong != null ? info.TrongLuong : ""));
                    cmd.Parameters.Add(new SqlParameter("SoLuongTon", info.SoLuongTon != null ? info.SoLuongTon : ""));
                    cmd.Parameters.Add(new SqlParameter("MOQ", info.MOQ != null ? info.MOQ : ""));
                    cmd.Parameters.Add(new SqlParameter("LeadtimeSX", info.LeadtimeSX != null ? info.LeadtimeSX : ""));
                    cmd.Parameters.Add(new SqlParameter("SoLuongThung", info.SoLuongThung != null ? info.SoLuongThung : ""));
                    cmd.Parameters.Add(new SqlParameter("KichThuocDai", info.KichThuocDai != null ? info.KichThuocDai : ""));
                    cmd.Parameters.Add(new SqlParameter("KichThuocRong", info.KichThuocRong != null ? info.KichThuocRong : ""));
                    cmd.Parameters.Add(new SqlParameter("KichThuocCao", info.KichThuocCao != null ? info.KichThuocCao : ""));
                    cmd.Parameters.Add(new SqlParameter("TongM3", info.TongM3 != null ? info.TongM3 : ""));

                    cmd.Parameters.Add(new SqlParameter("AnhSanPham", info.AnhSanPham != null ? info.AnhSanPham : ""));
                    cmd.Parameters.Add(new SqlParameter("GiaBan", Decimal.Parse(info.GiaBan.Replace(",", "") != "" ? info.GiaBan.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("LinkSP", info.LinkSP != null ? info.LinkSP : ""));
                    cmd.Parameters.Add(new SqlParameter("MoTa", info.MoTa != null ? info.MoTa : ""));
                    cmd.Parameters.Add(new SqlParameter("KichThuocSPDai", info.KichThuocSPDai != null ? info.KichThuocSPDai : ""));
                    cmd.Parameters.Add(new SqlParameter("KichThuocSPRong", info.KichThuocSPRong != null ? info.KichThuocSPRong : ""));
                    cmd.Parameters.Add(new SqlParameter("KichThuocSPCao", info.KichThuocSPCao != null ? info.KichThuocSPCao : ""));

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

                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "InfoNewoffer_Save");
                    return false;
                }
            }
        }
        public static List<InfoNewoffer> sp_VendorTool_InfoNewoffer_get(string VendorCode)
        {
            List<InfoNewoffer> it_r = new List<InfoNewoffer>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_VendorTool_InfoNewoffer_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        InfoNewoffer it = new InfoNewoffer
                        {
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VendorTool_InfoNewoffer_get");
                    return it_r;
                }
            }
        }
    }
}