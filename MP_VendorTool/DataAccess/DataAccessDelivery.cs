using MP_VendorTool.Models.Order;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MP_VendorTool.Models.Delivery;

namespace MP_VendorTool.DataAccess
{
    public class DataAccessDelivery
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConnSpac = ConfigurationManager.AppSettings.Get("strConnSpac");
        public static DataTable SP_TRADTERM_Info_GiaoHang_Header_Delivery(string vendorNo, string TrangThai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_Info_GiaoHang_Header_Delivery", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_Info_GiaoHang_Header_Delivery");
                return ds.Tables[0];
            }
        }
        public static DataTable SP_Delivery_listProductsCheck(string MaHang, string vendorNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Delivery_listProductsCheck", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Delivery_listProductsCheck");
                return ds.Tables[0];
            }
        }
        public static DataTable SP_Delivery_listProductsCheck_Detail(string IDHeader)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Delivery_listProductsCheck_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("IDHeader", IDHeader));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Delivery_listProductsCheck_Detail");
                return ds.Tables[0];
            }
        }
        public static DataTable BBM_TradingTern_Delivery_listAdd_Store(string Store, string Mien, string TinhThanh)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("BBM_TradingTern_Delivery_listAdd_Store", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("Store", Store));
                    cmd.Parameters.Add(new SqlParameter("Mien", Mien));
                    cmd.Parameters.Add(new SqlParameter("TinhThanh", TinhThanh));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_Info_GiaoHang_Header_Delivery");
                return ds.Tables[0];
            }
        }
        public static DataTable BBM_TradingTern_Delivery_listAdd_Store_Detail(string IDHeader)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("BBM_TradingTern_Delivery_listAdd_Store_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("IDHeader", IDHeader));
                    //cmd.Parameters.Add(new SqlParameter("Store", Store));
                    // cmd.Parameters.Add(new SqlParameter("Mien", Mien));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_TradingTern_Delivery_listAdd_Store_Detail");
                return ds.Tables[0];
            }
        }
        public static bool Update_Header_Delivery(string uid, string MaHang, string TenHang, string NCC, string Moq, string MoqThung)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Header_Delivery", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", TenHang));

                    cmd.Parameters.Add(new SqlParameter("NCC", NCC));
                    cmd.Parameters.Add(new SqlParameter("Moq", Moq));
                    cmd.Parameters.Add(new SqlParameter("MoqThung", MoqThung));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_GiaSauThayDoi_OfferPrice");
                    return false;
                }
            }
        }
        public static List<objCombox> BBM_TradingTern_Delivery_listAdd_Mien()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("BBM_TradingTern_Delivery_listAdd_Mien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_TradingTern_Delivery_listAdd_Mien");
                    return it_r;
                }
            }
        }
        public static bool Save_Delivery_Add_Store(Delivery_Add_Store info, string IDHeader, string VendorCode, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_Delivery_Add_Store", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("IDHeader", IDHeader != null ? IDHeader : ""));
                    cmd.Parameters.Add(new SqlParameter("NCC", VendorCode != null ? VendorCode : ""));
                    cmd.Parameters.Add(new SqlParameter("MaKho", info.MaKho != null ? info.MaKho : ""));
                    cmd.Parameters.Add(new SqlParameter("TenKho", info.TenKho != null ? info.TenKho : ""));
                    cmd.Parameters.Add(new SqlParameter("DiaChi", info.DiaChi != null ? info.DiaChi : ""));

                    cmd.Parameters.Add(new SqlParameter("ThoiGianXuatKho", info.ThoiGianXuatKho != null ? info.ThoiGianXuatKho : "0"));
                    cmd.Parameters.Add(new SqlParameter("LeaderTime", info.LeaderTime != null ? info.LeaderTime : "0"));

                    cmd.Parameters.Add(new SqlParameter("LichGHT2", info.LichGHT2 != null ? info.LichGHT2 : "0"));
                    cmd.Parameters.Add(new SqlParameter("LichGHT3", info.LichGHT3 != null ? info.LichGHT3 : "0"));
                    cmd.Parameters.Add(new SqlParameter("LichGHT4", info.LichGHT4 != null ? info.LichGHT4 : "0"));
                    cmd.Parameters.Add(new SqlParameter("LichGHT5", info.LichGHT5 != null ? info.LichGHT5 : "0"));
                    cmd.Parameters.Add(new SqlParameter("LichGHT6", info.LichGHT6 != null ? info.LichGHT6 : "0"));
                    cmd.Parameters.Add(new SqlParameter("LichGHT7", info.LichGHT7 != null ? info.LichGHT7 : "0"));

                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_Delivery_Add_Store");
                    return false;
                }
            }
        }
        public static bool Save_Delivery_Products_Add_Store(Delivery_Add_Productrs info, string IDHeader, string VendorCode, string CreateBy, string BackColor)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_Delivery_Products_Add_Store", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDHeader", IDHeader != null ? IDHeader : ""));
                    cmd.Parameters.Add(new SqlParameter("NCC", VendorCode != null ? VendorCode : ""));
                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang != null ? info.MaHang : ""));
                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang != null ? info.TenHang : ""));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    cmd.Parameters.Add(new SqlParameter("BackColor", BackColor));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_Delivery_Products_Add_Store");
                    return false;
                }
            }
        }
        public static bool Delete_Header_Delivery(string NCC)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete_Header_Delivery", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("NCC", NCC));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_Header_Delivery");
                    return false;
                }
            }
        }
        public static List<objCombox> SP_Delivery_Color()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Delivery_Color", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["colorid"].ToString(),
                            Name = reader["colorvalue"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Delivery_Color");
                    return it_r;
                }
            }
        }

        public static List<objCombox> BBM_TradingTern_Delivery_listAdd_TinhThanh()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("BBM_TradingTern_Delivery_listAdd_TinhThanh", con);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_TradingTern_Delivery_listAdd_TinhThanh");
                    return it_r;
                }
            }
        }

        public static List<objCombox> Get_List_Delivery_TinhThanh(string VungMien)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_List_Delivery_TinhThanh", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VungMien", VungMien));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_Delivery_TinhThanh");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_Delivery_Vender()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Delivery_Vender", con);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Delivery_Vender");
                    return it_r;
                }
            }
        }

        //public static List<InfoNewoffer> sp_VendorTool_InfoNewoffer_get(string VendorCode)
        //{
        //    List<InfoNewoffer> it_r = new List<InfoNewoffer>();
        //    using (var con = new SqlConnection(strConn))
        //    {
        //        con.Open();
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_VendorTool_InfoNewoffer_get", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = 30000;
        //            cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //            var reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                InfoNewoffer it = new InfoNewoffer
        //                {
        //                    LoaiHinhHopTacCode = reader["LoaiHinhHopTacCode"].ToString(),
        //                    LoaiHinhHopTac = reader["LoaiHinhHopTac"].ToString(),
        //                    TenDoanhNghiep = reader["TenDoanhNghiep"].ToString(),
        //                    DiaChi = reader["DiaChi"].ToString(),
        //                    SoDienThoai = reader["SoDienThoai"].ToString(),
        //                    Email = reader["Email"].ToString(),
        //                    Website = reader["Website"].ToString(),
        //                    Facebook = reader["Facebook"].ToString(),
        //                    LinhVucHoatDong = reader["LinhVucHoatDong"].ToString(),
        //                    LinhVucHoatDongCode = reader["LinhVucHoatDongCode"].ToString(),
        //                    SoDKKD = reader["SoDKKD"].ToString(),
        //                    MaSoThue = reader["MaSoThue"].ToString(),
        //                    SoTaiKhoan = reader["SoTaiKhoan"].ToString(),
        //                    TaiNganHangCode = reader["TaiNganHangCode"].ToString(),
        //                    TaiNganHang = reader["TaiNganHang"].ToString(),
        //                    Invoice = reader["Invoice"].ToString(),

        //                    Status = reader["Status"].ToString(),
        //                    CreatedBy = reader["CreatedBy"].ToString(),
        //                    CreatedDate = reader["CreatedDate"].ToString(),
        //                    ModifiedBy = reader["ModifiedBy"].ToString(),
        //                    ModifiedDate = reader["ModifiedDate"].ToString(),
        //                };
        //                it_r.Add(it);
        //            }
        //            con.Close();
        //            return it_r;
        //        }
        //        catch (Exception ex)
        //        {
        //            con.Close();
        //            LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VendorTool_InfoNewoffer_get");
        //            return it_r;
        //        }
        //    }
        //}
    }
}