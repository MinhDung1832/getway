using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Order;
using Newtonsoft.Json;
using ProductAllTool.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProductAllTool.DataAccess
{
    public class DataAccessCTKM
    {
        private static string strConnTHUCTAP = ConfigurationManager.AppSettings.Get("strConnTHUCTAP");
        #region CreateCTKM
        public static List<objCombox> CTKM_cboNCC(string userid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CTKM_cboNCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM_cboNCC");
                    return it_r;
                }
            }
        }

        public static DataTable CTKM_getSPTang(string userid, string TongTien)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CTKM_getSPTang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("TongTien", TongTien));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM_getSPTang");
                return ds.Tables[0];
            }
        }
        public static DataTable CTKM_getSPMua(string userid, string NCC)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CTKM_getSPMua", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("NCC", NCC));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM_getSPMua");
                return ds.Tables[0];
            }
        }

        public static bool CTKM_AddHangMua(string userid, CBKM_MuaHang it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CTKM_AddHangMua", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaHang",  it.MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", it.TenHang));
                    cmd.Parameters.Add(new SqlParameter("DonGia",  decimal.Parse(it.DonGia)));
                    cmd.Parameters.Add(new SqlParameter("SoLuong", it.SoLuong));
                    cmd.Parameters.Add(new SqlParameter("PTQua",   decimal.Parse(it.PTQua)));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM",  it.MaCTKM));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM_AddHangMua");
                    return false;
                }
            }
        }

        public static bool CTKM_AddHangTang(string userid, CBKM_HangTang it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CTKM_AddHangTang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaHang",  it.MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", it.TenHang));
                    cmd.Parameters.Add(new SqlParameter("DonGia", decimal.Parse(it.DonGia)));
                    cmd.Parameters.Add(new SqlParameter("SLTang", it.SLTang));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", it.MaCTKM));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM_AddHangTang");
                    return false;
                }
            }
        }

        public static bool CTKM_AddCBKM(string userid, CBKMModel it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CTKM_AddCBKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM",  it.MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("TenCTKM", it.TenCTKM));
                    cmd.Parameters.Add(new SqlParameter("TuNgay",  it.TuNgay));
                    cmd.Parameters.Add(new SqlParameter("DenNgay", it.DenNgay));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM_AddCBKM");
                    return false;
                }
            }
        }
        public static List<CBKMModel> CBKM_autocode()
        {
            List<CBKMModel> it_r = new List<CBKMModel>();

            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("CBKM_autocode", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("Code", Code));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CBKMModel it = new CBKMModel
                        {
                            MaCTKM = reader["Code"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CBKM_autocode");
                    return it_r;
                }
            }
        }
        #endregion
        #region DuyetCBKM
        public static DataTable CTKM_getDuyetCBKM(string userid, string NCC, string NgayTao, string TrangThai, string MaCTKM)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CTKM_getDuyetCBKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("NCC", NCC));
                    cmd.Parameters.Add(new SqlParameter("NgayTao", NgayTao));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM_getDuyetCBKM");
                return ds.Tables[0];
            }
        }
        public static int CBKM_deleteCBKM(string userid, string ID,string MaCTKM)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CBKM_deleteCBKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", Int32.Parse(ID)));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));

                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CBKM_deleteCBKM");
                return 0;
            }
        }
        public static int CBKM_setTrangThai(string userid, int type,string MaCTKM)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CBKM_setTrangThai", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));

                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CBKM_setTrangThai");
                return 0;
            }
        }
        public static List<CBKM_HangTang> CBKM_getHangTang(string userid,string MaCTKM)
        {
            List<CBKM_HangTang> it_r = new List<CBKM_HangTang>();

            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CBKM_getHangTang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        it_r.Add(new CBKM_HangTang
                        {
                            MaCTKM = reader["MaCTKM"].ToString(),
                            ID = reader["ID"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            DonGia = reader["DonGia"].ToString(),
                            SLTang = reader["SLTang"].ToString()
                        }); ;
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CBKM_getHangTang");
                    return it_r;
                }

            }
        }
        public static List<CBKM_MuaHang> CBKM_getHangMua(string userid,string MaCTKM)
        {
            List<CBKM_MuaHang> it_r = new List<CBKM_MuaHang>();

            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CBKM_getHangMua", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        it_r.Add(new CBKM_MuaHang
                        {
                            MaCTKM = reader["MaCTKM"].ToString(),
                            ID = reader["ID"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            DonGia = reader["DonGia"].ToString(),
                            SoLuong = reader["SoLuong"].ToString(),
                            PTQua = reader["PTQua"].ToString()
                        }); ;
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CBKM_getHangMua");
                    return it_r;
                }

            }
        }
        #endregion
    }
}