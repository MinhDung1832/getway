using MP_VendorTool.Models.Order;
using MP_VendorTool.Models.Promotion2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MP_VendorTool.DataAccess
{
    public class DataAccessPromotion2
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConnSpac = ConfigurationManager.AppSettings.Get("strConnSpac");

        public static List<objCombox> ComboKhuyenMai_Auto_MaCT(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ComboKhuyenMai_Auto_MaCT", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Code"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ChiDinhHotdeal_Vender");
                    return it_r;
                }
            }
        }
        
        public static DataTable ComboKhuyenMai_Header_Detail(string TenCT, string VendorCode, string TrangThai, string NgayTao)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ComboKhuyenMai_Header_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("TenCT", TenCT));
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
                    cmd.Parameters.Add(new SqlParameter("NgayTao", NgayTao));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ComboKhuyenMai_Header_Detail");
                return ds.Tables[0];
            }
        }
        
        public static bool ComboKhuyenMai_Header_Insert(ComboKhuyenMai_Header info, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ComboKhuyenMai_Header_Insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCT", info.MaCT != null ? info.MaCT : ""));
                    cmd.Parameters.Add(new SqlParameter("TenCT", info.TenCT != null ? info.TenCT : ""));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC != null ? info.MaNCC : ""));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC != null ? info.TenNCC : ""));
                    if (String.IsNullOrWhiteSpace(info.TuNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DateTime.Parse(info.TuNgay)));
                    }
                    if (String.IsNullOrWhiteSpace(info.DenNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DateTime.Parse(info.DenNgay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ComboKhuyenMai_Header_Insert");
                    return false;
                }
            }
        }
        public static bool ComboKhuyenMai_Line_MuaHang_Insert(ComboKhuyenMai_MuaHang info)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ComboKhuyenMai_Line_MuaHang_Insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCT", info.MaCT != null ? info.MaCT : ""));
                    cmd.Parameters.Add(new SqlParameter("TenCT", info.TenCT != null ? info.TenCT : ""));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC != null ? info.MaNCC : ""));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC != null ? info.TenNCC : ""));
                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang != null ? info.MaHang : ""));
                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang != null ? info.TenHang : ""));
                    cmd.Parameters.Add(new SqlParameter("HinhAnh", info.HinhAnh != null ? info.HinhAnh : ""));
                    cmd.Parameters.Add(new SqlParameter("GiaBanNTD", Decimal.Parse(info.GiaBanNTD.Replace(",", "") != "" ? info.GiaBanNTD.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SoLuongApDung", Decimal.Parse(info.SoLuongApDung.Replace(",", "") != "" ? info.SoLuongApDung.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("PhanTramQua", Decimal.Parse(info.PhanTramQua.Replace(",", "") != "" ? info.PhanTramQua.Replace(",", "") : "0")));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ComboKhuyenMai_Header_Insert");
                    return false;
                }
            }
        }
        public static bool ComboKhuyenMai_Line_TangHang_Insert(ComboKhuyenMai_TangHang info)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ComboKhuyenMai_Line_TangHang_Insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCT", info.MaCT != null ? info.MaCT : ""));
                    cmd.Parameters.Add(new SqlParameter("TenCT", info.TenCT != null ? info.TenCT : ""));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC != null ? info.MaNCC : ""));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC != null ? info.TenNCC : ""));
                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang != null ? info.MaHang : ""));
                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang != null ? info.TenHang : ""));
                    cmd.Parameters.Add(new SqlParameter("HinhAnh", info.HinhAnh != null ? info.HinhAnh : ""));
                    cmd.Parameters.Add(new SqlParameter("GiaQua", Decimal.Parse(info.GiaQua.Replace(",", "") != "" ? info.GiaQua.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SoLuongApDung", Decimal.Parse(info.SoLuongApDung.Replace(",", "") != "" ? info.SoLuongApDung.Replace(",", "") : "0")));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ComboKhuyenMai_Line_TangHang_Insert");
                    return false;
                }
            }
        }
        public static bool ComboKhuyenMai_Delete(string MaCTKM)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ComboKhuyenMai_Delete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ComboKhuyenMai_Delete");
                    return false;
                }
            }
        }


    }
}