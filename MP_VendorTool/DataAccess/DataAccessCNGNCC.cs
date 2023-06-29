using MP_VendorTool.DataAccess;
using Newtonsoft.Json;
using ProductAllTool.Models.CNGNCC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProductAllTool.DataAccess
{
    public class DataAccessCNGNCC
    {
        private static string strConnTHUCTAP = ConfigurationManager.AppSettings.Get("strConnTHUCTAP");

        public static List<CNGNCCModel> CNGNCC_cboNCC_SP_Duyet(string userid)
        {
            List<CNGNCCModel> it_r = new List<CNGNCCModel>();

            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CNGNCC_cboNCC_SP_Duyet", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", userid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CNGNCCModel it = new CNGNCCModel
                        {
                            MaNCC = reader["MaNCC"].ToString(),
                            NCC = reader["NCC"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CNGNCC_cboNCC_SP_Duyet");
                    return it_r;
                }
            }
        }

        public static List<CNGNCCModel> CNGNCC_cboNCC_SP(string userid)
        {
            List<CNGNCCModel> it_r = new List<CNGNCCModel>();

            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CNGNCC_cboNCC_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", userid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CNGNCCModel it = new CNGNCCModel
                        {
                            MaNCC = reader["MaNCC"].ToString(),
                            NCC = reader["NCC"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CNGNCC_cboNCC_SP");
                    return it_r;
                }
            }
        }

        public static CNGNCCModel CNGNCC_getSP(string MaHang)
        {
            CNGNCCModel it_r = new CNGNCCModel();

            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CNGNCC_getSP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CNGNCCModel it = new CNGNCCModel
                        {
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            GiaCu = reader["GiaCu"].ToString(),
                            GiaCuVAT = reader["GiaCuVAT"].ToString(),
                            VAT = reader["VAT"].ToString(),
                        };

                        it_r = it;
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CNGNCC_getSP");
                    return it_r;
                }
            }
        }

        public static bool CNGNCC_Add(string userid, Sp_Duyet_Model it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CNGNCC_Add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaHang", it.MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", it.TenHang));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", it.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("NCC", it.NCC));
                    cmd.Parameters.Add(new SqlParameter("GiaMoi", decimal.Parse(it.GiaMoi)));
                    cmd.Parameters.Add(new SqlParameter("GiaMoiVAT", decimal.Parse(it.GiaMoiVAT)));
                    cmd.Parameters.Add(new SqlParameter("VAT", decimal.Parse(it.VAT)));
                    cmd.Parameters.Add(new SqlParameter("NgayBD", it.NgayBD));
                    cmd.Parameters.Add(new SqlParameter("NgayKT", it.NgayKT));
                    cmd.Parameters.Add(new SqlParameter("GiaNY", decimal.Parse(it.GiaNY)));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CNGNCC_Add");
                    return false;
                }
            }
        }

        public static DataTable CNGNCC_GetDuyet(string userid, string NCC, string TenHang,string TrangThai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CNGNCC_GetDuyet", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("NCC", NCC));
                    cmd.Parameters.Add(new SqlParameter("TenHang", TenHang));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", Int32.Parse(TrangThai)));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CNGNCC_GetDuyet");
                return ds.Tables[0];
            }
        }

        public static int CNGNCC_setTrangThai(string userid, Sp_Duyet_Model it, string type)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CNGNCC_setTrangThai", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("type", Int32.Parse(type)));
                    cmd.Parameters.Add(new SqlParameter("MaHang", it.MaHang));

                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CNGNCC_setTrangThai");
                return 0;
            }
        }
    }
}