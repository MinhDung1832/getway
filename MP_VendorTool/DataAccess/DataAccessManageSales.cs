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
using MP_VendorTool.Models.ChiDinhHotdeal;
using MP_VendorTool.Models.OfferPrice;
using MP_VendorTool.Models.Report;
using MP_VendorTool.Models;

namespace MP_VendorTool.DataAccess
{
    public class DataAccessManageSales
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConnSpac = ConfigurationManager.AppSettings.Get("strConnSpac");
        public async static Task<bool> Create_TrungBayNgangHang_Header(string CreateBy, string MaAutoCT, obj_TrungBayNgangHang po)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Create_TrungBayNgangHang_Header", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaAutoCT", MaAutoCT));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", po.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", po.TenNCC.Trim()));
                    cmd.Parameters.Add(new SqlParameter("MaHang", po.MaHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("TenHang", po.TenHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("TuNgay", po.TuNgay.Trim()));
                    cmd.Parameters.Add(new SqlParameter("DenNgay", po.DenNgay.Trim()));
                    cmd.Parameters.Add(new SqlParameter("ChiPhi", po.ChiPhi.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));

                    var reader = await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Create_TrungBayNgangHang_Header");
                    return false;
                }
            }
        }
        public async static Task<bool> Create_TrungBayNgangHang_Line(obj_TrungBayNgangHang po)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Create_TrungBayNgangHang_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaAutoCT", po.MaAutoCT));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", po.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", po.TenNCC.Trim()));
                    cmd.Parameters.Add(new SqlParameter("MaHang", po.MaHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("TenHang", po.TenHang.Trim()));

                    cmd.Parameters.Add(new SqlParameter("MaCuaHang", po.MaCuaHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("TenCuaHang", po.TenCuaHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("SoMatTB", po.SoMatTB.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("Stockday", po.Stockday.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("SoMatTBMoi", po.SoMatTBMoi.Trim().Replace(",", "")));

                    cmd.Parameters.Add(new SqlParameter("TuNgay", po.TuNgay.Trim()));
                    cmd.Parameters.Add(new SqlParameter("DenNgay", po.DenNgay.Trim()));
                    cmd.Parameters.Add(new SqlParameter("ChiPhi", po.ChiPhi.Trim() != null ? po.ChiPhi.Trim().Replace(",", "") : "0"));

                    cmd.Parameters.Add(new SqlParameter("VungMien", po.VungMien.Trim()));
                    cmd.Parameters.Add(new SqlParameter("TinhThanh", po.TinhThanh.Trim()));

                    var reader = await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Create_TrungBayNgangHang_Line");
                    return false;
                }
            }
        }

    }
}