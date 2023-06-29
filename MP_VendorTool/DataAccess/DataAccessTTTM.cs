using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Order;
using Newtonsoft.Json;
using ProductAllTool.Models.TTTM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProductAllTool.DataAccess
{
    public class DataAccessTTTM
    {
        private static string strConnTHUCTAP = ConfigurationManager.AppSettings.Get("strConnTHUCTAP");

        public static DataTable TTTM_getDMSP(string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("TTTM_getDMSP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_getDMSP");
                return ds.Tables[0];
            }
        }

        public static List<objCombox> TTTM_cboDKDSTarget()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_cboDKDSTarget", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_cboDKDSTarget");
                    return it_r;
                }
            }
        }

        public static List<objCombox> TTTM_cboDKDSTinhThuong()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_cboDKDSTinhThuong", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_cboDKDSTinhThuong");
                    return it_r;
                }
            }
        }

        public static List<objCombox> TTTM_cboNDDauTu()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_cboNDDauTu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_cboNDDauTu");
                    return it_r;
                }
            }
        }

        public static List<objCombox> TTTM_cboLoaiThuong()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_cboLoaiThuong", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_cboLoaiThuong");
                    return it_r;
                }
            }
        }

        public static bool TTTM_createChietKhau(string userid, ChietKhau it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createChietKhau", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiCK ", it.LoaiCK));
                    cmd.Parameters.Add(new SqlParameter("HinhThucTT", it.HinhThucTT));
                    cmd.Parameters.Add(new SqlParameter("GiaTriCK", decimal.Parse(it.GiaTriCK)));
                    cmd.Parameters.Add(new SqlParameter("PTCK", decimal.Parse(it.PTCK)));
                    cmd.Parameters.Add(new SqlParameter("GiaTriDHTD", decimal.Parse(it.GiaTriDHTD)));
                    cmd.Parameters.Add(new SqlParameter("type", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createChietKhau");
                    return false;
                }
            }
        }

        public static bool TTTM_createChietKhauKe(string userid, ChietKhau it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createChietKhauKe", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiCK ", it.LoaiCK));
                    cmd.Parameters.Add(new SqlParameter("HinhThucTT", it.HinhThucTT));
                    cmd.Parameters.Add(new SqlParameter("GiaTriCK", decimal.Parse(it.GiaTriCK)));
                    cmd.Parameters.Add(new SqlParameter("PTCK", decimal.Parse(it.PTCK)));
                    cmd.Parameters.Add(new SqlParameter("GiaTriDHTD", decimal.Parse(it.GiaTriDHTD)));
                    cmd.Parameters.Add(new SqlParameter("type ", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createChietKhauKe");
                    return false;
                }
            }
        }

        public static bool TTTM_createChietKhauKy(string userid, ChietKhau it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createChietKhauKy", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiCK ", it.LoaiCK));
                    cmd.Parameters.Add(new SqlParameter("HinhThucTT", it.HinhThucTT));
                    cmd.Parameters.Add(new SqlParameter("GiaTriCK", decimal.Parse(it.GiaTriCK)));
                    cmd.Parameters.Add(new SqlParameter("PTCK", decimal.Parse(it.PTCK)));
                    cmd.Parameters.Add(new SqlParameter("GiaTriDHTD", decimal.Parse(it.GiaTriDHTD)));
                    cmd.Parameters.Add(new SqlParameter("type ", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createChietKhauKy");
                    return false;
                }
            }
        }

        public static bool TTTM_createHTH(string userid, HTH it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createHTH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("SLMua ", Int32.Parse(it.SLMua)));
                    cmd.Parameters.Add(new SqlParameter("SLTang", Int32.Parse(it.SLTang)));
                    cmd.Parameters.Add(new SqlParameter("type", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createHTH");
                    return false;
                }
            }
        }

        public static bool TTTM_createHTHKe(string userid, HTH it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createHTHKe", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("SLMua ", Int32.Parse(it.SLMua)));
                    cmd.Parameters.Add(new SqlParameter("SLTang", Int32.Parse(it.SLTang)));
                    cmd.Parameters.Add(new SqlParameter("type ", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createHTHKe");
                    return false;
                }
            }
        }

        public static bool TTTM_createHTHKy(string userid, HTH it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createHTHKy", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("SLMua ", Int32.Parse(it.SLMua)));
                    cmd.Parameters.Add(new SqlParameter("SLTang", Int32.Parse(it.SLTang)));
                    cmd.Parameters.Add(new SqlParameter("type ", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createHTHKy");
                    return false;
                }
            }
        }

        public static bool TTTM_createThuong(string userid, Thuong it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createThuong", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiThuongCode ", it.LoaiThuongCode));
                    cmd.Parameters.Add(new SqlParameter("LoaiThuong", it.LoaiThuong));
                    cmd.Parameters.Add(new SqlParameter("MucDSTu", Int32.Parse(it.MucDSTu)));
                    cmd.Parameters.Add(new SqlParameter("MucDSDen", Int32.Parse(it.MucDSDen)));
                    cmd.Parameters.Add(new SqlParameter("DKDSCode", it.DKDSCode));
                    cmd.Parameters.Add(new SqlParameter("DKDSTTCode", it.DKDSTTCode));
                    cmd.Parameters.Add(new SqlParameter("DKDSTarget", it.DKDSTarget));
                    cmd.Parameters.Add(new SqlParameter("DKDSTinhThuong", it.DKDSTinhThuong));
                    cmd.Parameters.Add(new SqlParameter("PTThuong", decimal.Parse(it.PTThuong)));
                    cmd.Parameters.Add(new SqlParameter("GiaTriThuong", decimal.Parse(it.GiaTriThuong)));
                    cmd.Parameters.Add(new SqlParameter("GhiChu", it.GhiChu));
                    cmd.Parameters.Add(new SqlParameter("type", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createThuong");
                    return false;
                }
            }
        }

        public static bool TTTM_createThuongKe(string userid, Thuong it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createThuongKe", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiThuongCode ", it.LoaiThuongCode));
                    cmd.Parameters.Add(new SqlParameter("LoaiThuong", it.LoaiThuong));
                    cmd.Parameters.Add(new SqlParameter("MucDSTu", Int32.Parse(it.MucDSTu)));
                    cmd.Parameters.Add(new SqlParameter("MucDSDen", Int32.Parse(it.MucDSDen)));
                    cmd.Parameters.Add(new SqlParameter("DKDSCode", it.DKDSCode));
                    cmd.Parameters.Add(new SqlParameter("DKDSTTCode", it.DKDSTTCode));
                    cmd.Parameters.Add(new SqlParameter("DKDSTarget", it.DKDSTarget));
                    cmd.Parameters.Add(new SqlParameter("DKDSTinhThuong", it.DKDSTinhThuong));
                    cmd.Parameters.Add(new SqlParameter("PTThuong", decimal.Parse(it.PTThuong)));
                    cmd.Parameters.Add(new SqlParameter("GiaTriThuong", decimal.Parse(it.GiaTriThuong)));
                    cmd.Parameters.Add(new SqlParameter("GhiChu", it.GhiChu));
                    cmd.Parameters.Add(new SqlParameter("type ", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createThuongKe");
                    return false;
                }
            }
        }

        public static bool TTTM_createThuongKy(string userid, Thuong it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createThuongKy", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiThuongCode ", it.LoaiThuongCode));
                    cmd.Parameters.Add(new SqlParameter("LoaiThuong", it.LoaiThuong));
                    cmd.Parameters.Add(new SqlParameter("MucDSTu", Int32.Parse(it.MucDSTu)));
                    cmd.Parameters.Add(new SqlParameter("MucDSDen", Int32.Parse(it.MucDSDen)));
                    cmd.Parameters.Add(new SqlParameter("DKDSCode", it.DKDSCode));
                    cmd.Parameters.Add(new SqlParameter("DKDSTTCode", it.DKDSTTCode));
                    cmd.Parameters.Add(new SqlParameter("DKDSTarget", it.DKDSTarget));
                    cmd.Parameters.Add(new SqlParameter("DKDSTinhThuong", it.DKDSTinhThuong));
                    cmd.Parameters.Add(new SqlParameter("PTThuong", decimal.Parse(it.PTThuong)));
                    cmd.Parameters.Add(new SqlParameter("GiaTriThuong", decimal.Parse(it.GiaTriThuong)));
                    cmd.Parameters.Add(new SqlParameter("GhiChu", it.GhiChu));
                    cmd.Parameters.Add(new SqlParameter("type ", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createThuongKy");
                    return false;
                }
            }
        }

        public static bool TTTM_createTradeMarketing(string userid, TradeMarketing it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createTradeMarketing", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("NDCode ", it.NDCode));
                    cmd.Parameters.Add(new SqlParameter("NDDauTu", it.NDDauTu));
                    cmd.Parameters.Add(new SqlParameter("PTDauTu", decimal.Parse(it.PTDauTu)));
                    cmd.Parameters.Add(new SqlParameter("GiaTriDT", decimal.Parse(it.GiaTriDT)));
                    cmd.Parameters.Add(new SqlParameter("DieuKien", it.DieuKien));
                    cmd.Parameters.Add(new SqlParameter("DKDoanhSoCode", it.DKDoanhSoCode));
                    cmd.Parameters.Add(new SqlParameter("DKDoanhSo", it.DKDoanhSo));
                    cmd.Parameters.Add(new SqlParameter("type", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createTradeMarketing");
                    return false;
                }
            }
        }

        public static bool TTTM_createTradeMarketingKe(string userid, TradeMarketing it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createTradeMarketingKe", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("NDCode ", it.NDCode));
                    cmd.Parameters.Add(new SqlParameter("NDDauTu", it.NDDauTu));
                    cmd.Parameters.Add(new SqlParameter("PTDauTu", decimal.Parse(it.PTDauTu)));
                    cmd.Parameters.Add(new SqlParameter("GiaTriDT", decimal.Parse(it.GiaTriDT)));
                    cmd.Parameters.Add(new SqlParameter("DieuKien", it.DieuKien));
                    cmd.Parameters.Add(new SqlParameter("DKDoanhSoCode", it.DKDoanhSoCode));
                    cmd.Parameters.Add(new SqlParameter("DKDoanhSo", it.DKDoanhSo));
                    cmd.Parameters.Add(new SqlParameter("type ", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createTradeMarketingKe");
                    return false;
                }
            }
        }

        public static bool TTTM_createTradeMarketingKy(string userid, TradeMarketing it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createTradeMarketingKy", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("NDCode ", it.NDCode));
                    cmd.Parameters.Add(new SqlParameter("NDDauTu", it.NDDauTu));
                    cmd.Parameters.Add(new SqlParameter("PTDauTu", decimal.Parse(it.PTDauTu)));
                    cmd.Parameters.Add(new SqlParameter("GiaTriDT", decimal.Parse(it.GiaTriDT)));
                    cmd.Parameters.Add(new SqlParameter("DieuKien", it.DieuKien));
                    cmd.Parameters.Add(new SqlParameter("DKDoanhSoCode", it.DKDoanhSoCode));
                    cmd.Parameters.Add(new SqlParameter("DKDoanhSo", it.DKDoanhSo));
                    cmd.Parameters.Add(new SqlParameter("type ", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createTradeMarketingKy");
                    return false;
                }
            }
        }

        public static bool TTTM_createDMSP(string userid, DMSP it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createDMSP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaHang ", it.MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", it.TenHang));
                    cmd.Parameters.Add(new SqlParameter("VAT", decimal.Parse(it.VAT)));
                    cmd.Parameters.Add(new SqlParameter("GiaADCK", decimal.Parse(it.GiaADCK)));
                    cmd.Parameters.Add(new SqlParameter("PTCK", decimal.Parse(it.PTCK)));
                    cmd.Parameters.Add(new SqlParameter("GiaSauCK", decimal.Parse(it.GiaSauCK)));
                    cmd.Parameters.Add(new SqlParameter("ThuongDH", decimal.Parse(it.ThuongDH)));
                    cmd.Parameters.Add(new SqlParameter("RangeReview", it.RangeReview));
                    cmd.Parameters.Add(new SqlParameter("type", it.type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createDMSP");
                    return false;
                }
            }
        }

        public static bool TTTM_createThoaThuan(string userid, ThoaThuan it)
        {
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("TTTM_createThoaThuan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("SoHopDong ", it.SoHopDong));
                    cmd.Parameters.Add(new SqlParameter("ToDateHD ", it.ToDateHD));
                    cmd.Parameters.Add(new SqlParameter("FromDateHD ", it.FromDateHD));
                    cmd.Parameters.Add(new SqlParameter("SoPhuLuc ", it.SoPhuLuc));
                    cmd.Parameters.Add(new SqlParameter("ToDatePL ", it.ToDatePL));
                    cmd.Parameters.Add(new SqlParameter("FromDatePL ", it.FromDatePL));
                    cmd.Parameters.Add(new SqlParameter("TenDDBBM ", it.TenDDBBM));
                    cmd.Parameters.Add(new SqlParameter("DaiDienBBM ", it.DaiDienBBM));
                    cmd.Parameters.Add(new SqlParameter("TenDDDoiTac ", it.TenDDDoiTac));
                    cmd.Parameters.Add(new SqlParameter("DaiDienDoiTac ", it.DaiDienDoiTac));
                    cmd.Parameters.Add(new SqlParameter("MaNCC ", it.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC ", it.TenNCC));
                    cmd.Parameters.Add(new SqlParameter("TinhTrang ", Int32.Parse(it.TinhTrang)));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM_createThoaThuan");
                    return false;
                }
            }
        }
    }
}