using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using MP_VendorTool.Models.Report;
using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Order;

namespace ProductAllTool.DataAccess
{
    public class DataAccessGateway
    {
        private static string APIDomain = ConfigurationManager.AppSettings.Get("APIDomain");
        private static string strConn = ConfigurationManager.AppSettings.Get("strConnTrading");
        private static string strCon_SPACEMAN = ConfigurationManager.AppSettings.Get("strConn");
        //        #region DebtDeposit
        //        public static DataTable Sp_get_DebtDeposit(string MaHang, string Thang)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("SP_DebtDeposit_GET_LIST", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_DebtDeposit_GET_LIST");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static DataTable Sp_get_DebtDeposit_vendorNo(string MaHang, string Thang, string vendorNo)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("SP_DebtDeposit_vendorNo_GET_LIST", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_DebtDeposit_GET_LIST");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool SP_Status_DebtDeposit_UPDATE(string ID, string Status)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_Status_DebtDeposit_UPDATE", con);//SP_Status_DebtDeposit_UPDATE
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Status_DebtDeposit_UPDATE");
        //                    return false;
        //                }
        //            }
        //        }

        //        #endregion

        //        #region CTKM
        //        public static DataTable SP_CTKM_vendorNo_GET_LIST(string MaHang, string Thang, string vendorNo, string Mien, string LoaiCTKM)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("SP_CTKM_vendorNo_GET_LIST", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("Mien", Mien));
        //                    cmd.Parameters.Add(new SqlParameter("LoaiCTKM", LoaiCTKM));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_CTKM_vendorNo_GET_LIST");
        //                return ds.Tables[0];
        //            }
        //        }
        //        #endregion

        //        #region ThuongDinhHuong
        //        public static DataTable SP_ThuongDinhHuong_vendorNo_GET_LIST(string MaHang, string Thang, string vendorNo)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("SP_ThuongDinhHuong_vendorNo_GET_LIST", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ThuongDinhHuong_vendorNo_GET_LIST");
        //                return ds.Tables[0];
        //            }
        //        }
        //        #endregion

        //        #region ThuongNhanVien
        //        public static List<objCombox> sp_Pushsale_NCC_get(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_Pushsale_NCC_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_NCC_get");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static bool Update_Status_ThuongNhanVien_userid(string ID, string HanhDong, string userid)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_Status_ThuongNhanVien_userid", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));
        //                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
        //                    cmd.Parameters.Add(new SqlParameter("userid", userid));

        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_ThuongNhanVien");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static DataTable Get_List_ThuongNhanVien(string MaHang, string PhamVi, string ThoiGian, string Status, string GAP, string VendorNo)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("Get_List_BIBO_ThuongNhanVien", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("PhamVi", PhamVi));
        //                    cmd.Parameters.Add(new SqlParameter("ThoiGian", ThoiGian));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("GAP", GAP));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_ThuongNhanVien");
        //                return ds.Tables[0];
        //            }
        //        }

        //        public static List<VendorContact> NCC_PushSale_VendorContact_get(string BBM_Code)
        //        {
        //            List<VendorContact> it_r = new List<VendorContact>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();

        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_NCC_PushSale_VendorContact_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("BBM_Code", BBM_Code));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        VendorContact it = new VendorContact
        //                        {
        //                            id = reader["id"].ToString(),
        //                            BBM_Code = reader["BBM_Code"].ToString()
        //                        };

        //                        it_r.Add(it);
        //                    }
        //                    con.Close();

        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_NCC_PushSale_VendorContact_get");
        //                    return it_r;
        //                }
        //            }

        //        }
        //        #endregion

        //        #region GiaTangTrungBay
        //        public static DataTable Get_List_GiaTangTrungBay(string MaHang, string Status, string GAP, string VendorNo)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("Get_List_BIBO_GiaTangTrungBay", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("GAP", GAP));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_GiaTangTrungBay");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool Update_Status_GiaTangTrungBay_userid(string ID, string HanhDong, string userid)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_Status_GiaTangTrungBay_userid", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));
        //                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
        //                    cmd.Parameters.Add(new SqlParameter("userid", userid));

        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_GiaTangTrungBay_userid");
        //                    return false;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region Tab Chương trình khuyến mãi PushSale
        //        //Total_Discount
        //        public static List<Obj_Total_Discount> Total_Discount_View(string MaCTKM)
        //        {
        //            List<Obj_Total_Discount> it_r = new List<Obj_Total_Discount>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_Total_Discount_get_View", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_Total_Discount it = new Obj_Total_Discount
        //                        {
        //                            MaCTKM = reader["MaCTKM"].ToString(),
        //                            FromDay = reader["FromDay"].ToString(),
        //                            ToDay = reader["ToDay"].ToString(),
        //                            CouponCode = reader["CouponCode"].ToString(),
        //                            CouponName = reader["CouponName"].ToString(),
        //                            PriceGroupCode = reader["PriceGroupCode"].ToString(),
        //                            PriceGroupName = reader["PriceGroupName"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Total_Discount_get_View");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<Obj_Total_Discount_Line> Total_Discount_Line_View(string MaCTKM)
        //        {
        //            List<Obj_Total_Discount_Line> it_r = new List<Obj_Total_Discount_Line>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Total_Discount_Line_View", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_Total_Discount_Line it = new Obj_Total_Discount_Line
        //                        {
        //                            Type = reader["Type"].ToString(),
        //                            ProductName = reader["ProductName"].ToString(),
        //                            ProductCode = reader["ProductCode"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Total_Discount_Line_View");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<Obj_Total_Discount_Line_Benefits> Total_Discount_Line_Benefits_View(string MaCTKM)
        //        {
        //            List<Obj_Total_Discount_Line_Benefits> it_r = new List<Obj_Total_Discount_Line_Benefits>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Total_Discount_Line_Benefits_View", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_Total_Discount_Line_Benefits it = new Obj_Total_Discount_Line_Benefits
        //                        {
        //                            StepAmount = reader["StepAmount"].ToString(),
        //                            Type = reader["Type"].ToString(),
        //                            ProductName = reader["ProductName"].ToString(),
        //                            ProductCode = reader["ProductCode"].ToString(),
        //                            ValueType = reader["ValueType"].ToString(),
        //                            Value = reader["Value"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Total_Discount_Line_Benefits_View");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static List<Obj_Total_Discount_Line_Benefits> SP_GETWAY_KM_LINE_Benefits_DETAIL(string MaCTKM)
        //        {
        //            List<Obj_Total_Discount_Line_Benefits> it_r = new List<Obj_Total_Discount_Line_Benefits>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_GETWAY_KM_LINE_Benefits_DETAIL", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_Total_Discount_Line_Benefits it = new Obj_Total_Discount_Line_Benefits
        //                        {
        //                            StepAmount = reader["StepAmount"].ToString(),
        //                            Type = reader["Type"].ToString(),
        //                            ProductName = reader["ProductName"].ToString(),
        //                            ProductCode = reader["ProductCode"].ToString(),
        //                            ValueType = reader["ValueType"].ToString(),
        //                            Value = reader["Value"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GETWAY_KM_LINE_Benefits_DETAIL");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<Obj_Total_Discount> SP_GETWAY_KM_PROMOTION_Total_Discount_DETAIL(string MaCTKM)
        //        {
        //            List<Obj_Total_Discount> it_r = new List<Obj_Total_Discount>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_GETWAY_KM_PROMOTION_Total_Discount_DETAIL", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_Total_Discount it = new Obj_Total_Discount
        //                        {
        //                            MaCTKM = reader["MaCTKM"].ToString(),
        //                            FromDay = reader["FromDay"].ToString(),
        //                            ToDay = reader["ToDay"].ToString(),
        //                            CouponCode = reader["CouponCode"].ToString(),
        //                            CouponName = reader["CouponName"].ToString(),
        //                            PriceGroupCode = reader["PriceGroupCode"].ToString(),
        //                            PriceGroupName = reader["PriceGroupName"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GETWAY_KM_PROMOTION_Total_Discount_DETAIL");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<Obj_Total_Discount_Line> SP_GETWAY_KM_LINE_Total_Discount_Line_DETAIL(string MaCTKM)
        //        {
        //            List<Obj_Total_Discount_Line> it_r = new List<Obj_Total_Discount_Line>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_GETWAY_KM_LINE_Total_Discount_Line_DETAIL", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_Total_Discount_Line it = new Obj_Total_Discount_Line
        //                        {
        //                            Type = reader["Type"].ToString(),
        //                            ProductName = reader["ProductName"].ToString(),
        //                            ProductCode = reader["ProductCode"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GETWAY_KM_LINE_Total_Discount_Line_DETAIL");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        //MixMatch
        //        public static List<Obj_MixMatch> Mix_Match_View(string MaCTKM)
        //        {
        //            List<Obj_MixMatch> it_r = new List<Obj_MixMatch>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_Mix_Match_get_View", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_MixMatch it = new Obj_MixMatch
        //                        {
        //                            MaCTKM = reader["MaCTKM"].ToString(),
        //                            FromDay = reader["FromDay"].ToString(),
        //                            ToDay = reader["ToDay"].ToString(),
        //                            CouponCode = reader["CouponCode"].ToString(),
        //                            CouponName = reader["CouponName"].ToString(),
        //                            PriceGroupCode = reader["PriceGroupCode"].ToString(),
        //                            PriceGroupName = reader["PriceGroupName"].ToString(),

        //                            NoOfLeastItem = reader["NoOfLeastItem"].ToString(),
        //                            Leastexp = reader["Leastexp"].ToString(),
        //                            Same_DifLine = reader["Same_DifLine"].ToString(),
        //                            Mix_DiscountType = reader["Mix_DiscountType"].ToString(),
        //                            DealPriceValue = reader["DealPriceValue"].ToString(),
        //                            DiscValue = reader["DiscValue"].ToString(),
        //                            DiscountAmoutValue = reader["DiscountAmoutValue"].ToString(),
        //                            NoTimeApp = reader["NoTimeApp"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_Mix_Match_get_View");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static List<Obj_MixMatch_Line_Groups> MixMatch_Line_View(string MaCTKM)
        //        {
        //            List<Obj_MixMatch_Line_Groups> it_r = new List<Obj_MixMatch_Line_Groups>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("MixMatch_Line_Groups_View", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_MixMatch_Line_Groups it = new Obj_MixMatch_Line_Groups
        //                        {
        //                            LineGroupCode = reader["LineGroupCode"].ToString(),
        //                            lineGroupType = reader["lineGroupType"].ToString(),
        //                            value1 = reader["value1"].ToString(),
        //                            value2 = reader["value2"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "MixMatch_Line_View");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static List<Obj_MixMatch_Line> MixMatch_Line_Groups_View(string MaCTKM)
        //        {
        //            List<Obj_MixMatch_Line> it_r = new List<Obj_MixMatch_Line>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("MixMatch_Line_View", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_MixMatch_Line it = new Obj_MixMatch_Line
        //                        {
        //                            Type = reader["Type"].ToString(),
        //                            ProductCode = reader["ProductCode"].ToString(),
        //                            ProductName = reader["ProductName"].ToString(),
        //                            NoItemNeeded = reader["NoItemNeeded"].ToString(),
        //                            DealPriceDiscPercent = reader["DealPriceDiscPercent"].ToString(),
        //                            DiscType = reader["DiscType"].ToString(),
        //                            LineGroup = reader["LineGroup"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "MixMatch_Line_Groups_View");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static List<Obj_MixMatch> SP_GETWAY_KM_PROMOTION_MixMatch_DETAIL(string MaCTKM)
        //        {
        //            List<Obj_MixMatch> it_r = new List<Obj_MixMatch>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_GETWAY_KM_PROMOTION_MixMatch_DETAIL", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_MixMatch it = new Obj_MixMatch
        //                        {
        //                            MaCTKM = reader["MaCTKM"].ToString(),
        //                            FromDay = reader["FromDay"].ToString(),
        //                            ToDay = reader["ToDay"].ToString(),
        //                            CouponCode = reader["CouponCode"].ToString(),
        //                            CouponName = reader["CouponName"].ToString(),
        //                            PriceGroupCode = reader["PriceGroupCode"].ToString(),
        //                            PriceGroupName = reader["PriceGroupName"].ToString(),
        //                            NoOfLeastItem = reader["NoOfLeastItem"].ToString(),
        //                            Leastexp = reader["Leastexp"].ToString(),
        //                            Same_DifLine = reader["Same_DifLine"].ToString(),
        //                            Mix_DiscountType = reader["Mix_DiscountType"].ToString(),
        //                            DealPriceValue = reader["DealPriceValue"].ToString(),
        //                            DiscValue = reader["DiscValue"].ToString(),
        //                            DiscountAmoutValue = reader["DiscountAmoutValue"].ToString(),
        //                            NoTimeApp = reader["NoTimeApp"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GETWAY_KM_PROMOTION_Discount_Offer_DETAIL");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static List<Obj_MixMatch_Line> SP_GETWAY_KM_LINE_MixMatchLine_DETAIL(string MaCTKM)
        //        {
        //            List<Obj_MixMatch_Line> it_r = new List<Obj_MixMatch_Line>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_GETWAY_KM_LINE_MixMatchLine_DETAIL", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_MixMatch_Line it = new Obj_MixMatch_Line
        //                        {
        //                            Type = reader["Type"].ToString(),
        //                            ProductCode = reader["ProductCode"].ToString(),
        //                            ProductName = reader["ProductName"].ToString(),
        //                            NoItemNeeded = reader["NoItemNeeded"].ToString(),
        //                            DealPriceDiscPercent = reader["DealPriceDiscPercent"].ToString(),
        //                            DiscType = reader["DiscType"].ToString(),
        //                            LineGroup = reader["LineGroup"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GETWAY_KM_LINE_MixMatchLine_DETAIL");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static List<Obj_MixMatch_Line_Groups> SP_GETWAY_KM_LINE_MixMatch_LineGroup_DETAIL(string MaCTKM)
        //        {
        //            List<Obj_MixMatch_Line_Groups> it_r = new List<Obj_MixMatch_Line_Groups>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_GETWAY_KM_LINE_MixMatch_LineGroup_DETAIL", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_MixMatch_Line_Groups it = new Obj_MixMatch_Line_Groups
        //                        {
        //                            LineGroupCode = reader["LineGroupCode"].ToString(),
        //                            lineGroupType = reader["lineGroupType"].ToString(),
        //                            value1 = reader["value1"].ToString(),
        //                            value2 = reader["value2"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GETWAY_KM_LINE_MixMatch_LineGroup_DETAIL");
        //                    return it_r;
        //                }
        //            }
        //        }



        //        //Discount_Offer

        //        public static List<Obj_Discount_Offer> SP_TRADTERM_Discount_Offer_View(string MaCTKM)
        //        {
        //            List<Obj_Discount_Offer> it_r = new List<Obj_Discount_Offer>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_Discount_Offer_get_View", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_Discount_Offer it = new Obj_Discount_Offer
        //                        {
        //                            MaCTKM = reader["MaCTKM"].ToString(),
        //                            FromDay = reader["FromDay"].ToString(),
        //                            ToDay = reader["ToDay"].ToString(),
        //                            CouponCode = reader["CouponCode"].ToString(),
        //                            CouponName = reader["CouponName"].ToString(),
        //                            PriceGroupCode = reader["PriceGroupCode"].ToString(),
        //                            PriceGroupName = reader["PriceGroupName"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_Discount_Offer_View");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static List<Obj_Discount_Offer_Line> SP_TRADTERM_Discount_Line_Offer_View(string MaCTKM)
        //        {
        //            List<Obj_Discount_Offer_Line> it_r = new List<Obj_Discount_Offer_Line>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_Discount_Offer_View", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_Discount_Offer_Line it = new Obj_Discount_Offer_Line
        //                        {
        //                            Type = reader["Type"].ToString(),
        //                            ProductName = reader["ProductName"].ToString(),
        //                            ProductCode = reader["ProductCode"].ToString(),
        //                            DiscStdPrice = reader["DiscStdPrice"].ToString(),
        //                            DiscAmountStdPrice = reader["DiscAmountStdPrice"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_Discount_Offer_View");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable Get_List_ChuongTrinhKhuyenMai(string LoaiCTKM, string Status, string GAP, string VendorNo)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_BIBO_GET_LIST_PUSHSALE_CTKM", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("LoaiCTKM", LoaiCTKM));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("GAP", GAP));
        //                    //
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_LIST_PUSHSALE_CTKM");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool Update_Status_ChuongTrinhKhuyenMai(string MaCTKM, string HanhDong, string userid)
        //        {
        //            string[] Type = MaCTKM.Split('-');
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_Status_ChuongTrinhKhuyenMai_userid", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", Type[1].Trim()));
        //                    cmd.Parameters.Add(new SqlParameter("LoaiCTKM", Type[0].Trim()));
        //                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
        //                    cmd.Parameters.Add(new SqlParameter("userid", userid));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_ChuongTrinhKhuyenMai");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static List<Obj_Discount_Offer> SP_GETWAY_KM_PROMOTION_Discount_Offer_DETAIL(string MaCTKM)
        //        {
        //            List<Obj_Discount_Offer> it_r = new List<Obj_Discount_Offer>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_GETWAY_KM_PROMOTION_Discount_Offer_DETAIL", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("CodeKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_Discount_Offer it = new Obj_Discount_Offer
        //                        {
        //                            MaCTKM = reader["MaCTKM"].ToString(),
        //                            FromDay = reader["FromDay"].ToString(),
        //                            ToDay = reader["ToDay"].ToString(),
        //                            CouponCode = reader["CouponCode"].ToString(),
        //                            CouponName = reader["CouponName"].ToString(),
        //                            PriceGroupCode = reader["PriceGroupCode"].ToString(),
        //                            PriceGroupName = reader["PriceGroupName"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GETWAY_KM_PROMOTION_Discount_Offer_DETAIL");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<Obj_Discount_Offer_Line> SP_TRADTERM_Discount_Line_Offer_ERP(string MaCTKM)
        //        {
        //            List<Obj_Discount_Offer_Line> it_r = new List<Obj_Discount_Offer_Line>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_Discount_Line_Offer_ERP", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        Obj_Discount_Offer_Line it = new Obj_Discount_Offer_Line
        //                        {
        //                            Type = reader["Type"].ToString(),
        //                            ProductName = reader["ProductName"].ToString(),
        //                            ProductCode = reader["ProductCode"].ToString(),
        //                            DiscStdPrice = reader["DiscStdPrice"].ToString(),
        //                            DiscAmountStdPrice = reader["DiscAmountStdPrice"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_Discount_Line_Offer_ERP");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        #endregion

        //        #region PriceOffer
        //        public static List<objCombox> Select_MaHang_PriceOffer(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_PriceOffer_MahHang_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_PriceOffer_MahHang_get");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static DataTable Get_List_OfferPrice(string MaHang, string Status, string VendorNo, string DeXuat)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("Get_List_BiBo_OfferPrice", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang != null ? MaHang : ""));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("DeXuat", DeXuat));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_OfferPrice");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool Update_Status_OfferPrice(string ID, string HanhDong, string message, string NgayDieuChinhHieuLuc, string NoiDungTuChoi, string userid)
        //        {
        //            string[] Value = ID.Split('-');
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_Status_OfferPrice_userid", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", Value[0]));
        //                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
        //                    cmd.Parameters.Add(new SqlParameter("message", message));
        //                    if (String.IsNullOrWhiteSpace(NgayDieuChinhHieuLuc))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("NgayDieuChinhHieuLuc", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("NgayDieuChinhHieuLuc", DateTime.Parse(NgayDieuChinhHieuLuc)));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("NoiDungTuChoi", NoiDungTuChoi));
        //                    cmd.Parameters.Add(new SqlParameter("userid", userid));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_OfferPrice_userid");
        //                    return false;
        //                }
        //            }
        //        }

        //        //POST /api/PurchasePrices


        //        public static Obj_PriceOffer Listget_PriceOffer_PopUp(string ID)
        //        {
        //            Obj_PriceOffer itr = new Obj_PriceOffer();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Listget_PriceOffer_PopUp", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        Obj_PriceOffer it = new Obj_PriceOffer
        //                        {
        //                            ID = reader["ID"].ToString(),
        //                            MaNCC = reader["MaNCC"].ToString(),
        //                            TenNCC = reader["TenNCC"].ToString(),
        //                            MaHang = reader["MaHang"].ToString(),
        //                            TenHang = reader["TenHang"].ToString(),
        //                            Barcode = reader["Barcode"].ToString(),
        //                            GiaTruocThayDoi = reader["GiaTruocThayDoi"].ToString(),
        //                            GiaSauThayDoi = reader["GiaSauThayDoi"].ToString(),
        //                            ToDay = reader["ToDay"].ToString(),
        //                            FromDay = reader["FromDay"].ToString(),
        //                            Link = reader["Link"].ToString(),
        //                            Status = reader["Status"].ToString(),
        //                            NgayGuiDuyet = reader["NgayGuiDuyet"].ToString(),
        //                            NgayDieuChinhHieuLuc = reader["NgayDieuChinhHieuLuc"].ToString(),
        //                            NgayHieuLuc_ThoaThuanHD = reader["NgayHieuLuc_ThoaThuanHD"].ToString(),
        //                        };
        //                        itr = it;
        //                    }
        //                    con.Close();
        //                    return itr;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_PriceOffer_PopUp");
        //                    return itr;
        //                }
        //            }
        //        }
        //        public static objCombox SP_BBM_SalesPrice_ThayDoiGiaAll(string MaHang)
        //        {
        //            objCombox itr = new objCombox();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_BBM_SalesPrice_ThayDoiGiaAll", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Name = reader["Price"].ToString(),
        //                        };
        //                        itr = it;
        //                    }
        //                    con.Close();
        //                    return itr;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_SalesPrice_ThayDoiGiaAll");
        //                    return itr;
        //                }
        //            }
        //        }

        //        public static bool SP_SAVE_PriceERP_Request(Obj_PriceERP_Request info, string CreateBy)
        //        {
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_SAVE_PriceERP_Requests", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("Source", info.Source));
        //                    cmd.Parameters.Add(new SqlParameter("ItemNo", info.ItemNo));
        //                    cmd.Parameters.Add(new SqlParameter("SalesCode", info.SalesCode));
        //                    cmd.Parameters.Add(new SqlParameter("Price", info.Price));
        //                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_SalesPrice_ThayDoiGiaAll");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static bool SP_SAVE_PriceERP_Request_DeXuatGiaban(Obj_PriceERP_Request info, string NgayBatDau, string NgayKetThuc, string CreateBy)
        //        {
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_SAVE_PriceERP_Requests", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("Source", info.Source));
        //                    cmd.Parameters.Add(new SqlParameter("ItemNo", info.ItemNo));
        //                    cmd.Parameters.Add(new SqlParameter("SalesCode", info.SalesCode));
        //                    cmd.Parameters.Add(new SqlParameter("Price", info.Price));
        //                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));

        //                    // tạm thời 2 ngày này chưa sử dụng đến
        //                    //if (String.IsNullOrWhiteSpace(NgayBatDau))
        //                    //{
        //                    //    cmd.Parameters.Add(new SqlParameter("NgayBatDau", DBNull.Value));
        //                    //}
        //                    //else
        //                    //{
        //                    //    cmd.Parameters.Add(new SqlParameter("NgayBatDau", DateTime.Parse(NgayBatDau)));
        //                    //}

        //                    //if (String.IsNullOrWhiteSpace(NgayKetThuc))
        //                    //{
        //                    //    cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DBNull.Value));
        //                    //}
        //                    //else
        //                    //{
        //                    //    cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DateTime.Parse(NgayKetThuc)));
        //                    //}

        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_SalesPrice_ThayDoiGiaAll");
        //                    return false;
        //                }
        //            }
        //        }

        //        public static bool SP_SAVE_SalesPrice_ThayDoiGiaAll(Obj_SalesPrice_ThayDoiGiaAll info, string ThongBaoERP, string CreateBy)
        //        {
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_SAVE_SalesPrice_ThayDoiGiaAll", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC));
        //                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC));
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang));
        //                    cmd.Parameters.Add(new SqlParameter("GiaTruocDieuChinh", info.GiaTruocDieuChinh.Replace(",", "")));
        //                    cmd.Parameters.Add(new SqlParameter("GiaSauDieuChinh", info.GiaSauDieuChinh.Replace(",", "")));
        //                    if (String.IsNullOrWhiteSpace(info.NgayBatDau))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("NgayBatDau", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("NgayBatDau", DateTime.Parse(info.NgayBatDau)));
        //                    }

        //                    cmd.Parameters.Add(new SqlParameter("ThongBaoERP", ThongBaoERP));
        //                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_SalesPrice_ThayDoiGiaAll");
        //                    return false;
        //                }
        //            }
        //        }


        //        #endregion

        //        #region Gap_PushSale CTKM

        //        public static List<objCombox> sp_Pushsale_GAP_ThuongNhanVien_get(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_ThuongNhanVien_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_ThuongNhanVien_get");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static List<objCombox> sp_Pushsale_GAP_GiaTangTrungBay_get(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_GiaTangTrungBay_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_GiaTangTrungBay_get");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> sp_Pushsale_GAP_TruongTrinhKhuyenMai_get(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_TruongTrinhKhuyenMai_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_TruongTrinhKhuyenMai_get");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> sp_Pushsale_GAP_Discount_Offer_get(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_Discount_Offer_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_Discount_Offer_get");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> sp_Pushsale_GAP_MixMatch_get(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_MixMatch_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_MixMatch_get");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> sp_Pushsale_GAP_Total_Discount_get(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_Total_Discount_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_Total_Discount_get");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        #endregion


        //        #region TangCuongNhanDien
        //        public static DataTable Get_List_TangCuongNhanDien(string HangMuc, string Status, string GAP, string VendorNo)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("Get_List_BIBO_TangCuongNhanDien", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("HangMuc", HangMuc));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("GAP", GAP));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_TangCuongNhanDien");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static List<objCombox> sp_Pushsale_GAP_TangCuongNhanDien_get(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_TangCuongNhanDien_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_TangCuongNhanDien_get");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static bool Update_Status_TangCuongNhanDien(string ID, string HanhDong, string userid)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_Status_TangCuongNhanDien_userid", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));
        //                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
        //                    cmd.Parameters.Add(new SqlParameter("userid", userid));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_TangCuongNhanDien_userid");
        //                    return false;
        //                }
        //            }
        //        }

        //        public static Obj_TangCuongNhanDien Listget_TangCuongNhanDien_PopUp(string ID)
        //        {
        //            Obj_TangCuongNhanDien itr = new Obj_TangCuongNhanDien();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Listget_TangCuongNhanDien_PopUp", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        Obj_TangCuongNhanDien it = new Obj_TangCuongNhanDien
        //                        {
        //                            ID = reader["ID"].ToString(),
        //                            HangMuc = reader["HangMuc"].ToString(),
        //                            DonVi = reader["DonVi"].ToString(),
        //                            DonGia = reader["DonGia"].ToString(),
        //                            SoLuong = reader["SoLuong"].ToString(),
        //                            FromDay = reader["FromDay"].ToString(),
        //                            ToDay = reader["ToDay"].ToString(),
        //                            ThanhTien = reader["ThanhTien"].ToString(),
        //                            Status = reader["Status"].ToString()
        //                        };
        //                        itr = it;
        //                    }
        //                    con.Close();
        //                    return itr;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_TangCuongNhanDien_PopUp");
        //                    return itr;
        //                }
        //            }
        //        }

        //        public static List<objCombox> Get_List_TangCuongNhanDien_HangMuc(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Get_List_TangCuongNhanDien_HangMuc", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_TangCuongNhanDien_HangMuc");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region OfferPrice
        //        public static DataTable Get_List_OfferPrice_BIBO(string NhaCC, string MaHang, string Status, string VendorNo)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("Get_List_OfferPrice_BIBO", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("NhaCC", NhaCC));
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_OfferPrice");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool SP_SAVE_OfferPrice(Obj_PriceOffer info, string CreateBy)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_SAVE_OfferPrice", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC));
        //                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC));
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang));
        //                    cmd.Parameters.Add(new SqlParameter("Barcode", info.Barcode != null ? info.Barcode : ""));

        //                    if (info.GiaTruocThayDoi != null)
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("GiaTruocThayDoi", Decimal.Parse(info.GiaTruocThayDoi.Replace(",", "") != "" ? info.GiaTruocThayDoi.Replace(",", "") : "0")));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("GiaTruocThayDoi", "0"));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("GiaSauThayDoi", Decimal.Parse(info.GiaSauThayDoi.Replace(",", "") != "" ? info.GiaSauThayDoi.Replace(",", "") : "0")));

        //                    if (info.GiaTruocThayDoiPlus != null)
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("GiaTruocThayDoiPlus", Decimal.Parse(info.GiaTruocThayDoiPlus.Replace(",", "") != "" ? info.GiaTruocThayDoiPlus.Replace(",", "") : "0")));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("GiaTruocThayDoiPlus", "0"));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("GiaSauThayDoiPlus", Decimal.Parse(info.GiaSauThayDoiPlus.Replace(",", "") != "" ? info.GiaSauThayDoiPlus.Replace(",", "") : "0")));

        //                    cmd.Parameters.Add(new SqlParameter("VAT", Decimal.Parse(info.VAT.Replace(",", "") != "" ? info.VAT.Replace(",", "") : "0")));


        //                    if (String.IsNullOrWhiteSpace(info.ToDay))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(info.ToDay)));
        //                    }

        //                    if (String.IsNullOrWhiteSpace(info.FromDay))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(info.FromDay)));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("Link", info.Link != null ? info.Link : ""));

        //                    ///
        //                    cmd.Parameters.Add(new SqlParameter("GiaBanNYKhuyenNghi", Decimal.Parse(info.GiaBanNYKhuyenNghi != null ? info.GiaBanNYKhuyenNghi.Replace(",", "") : "0")));
        //                    if (String.IsNullOrWhiteSpace(info.NgayThongBaoChinhThuc))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DateTime.Parse(info.NgayThongBaoChinhThuc)));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc_ThoaThuanHD", info.NgayHieuLuc_ThoaThuanHD != null ? info.NgayHieuLuc_ThoaThuanHD : "0"));
        //                    cmd.Parameters.Add(new SqlParameter("Status", info.Status));
        //                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_OfferPrice");
        //                    return false;
        //                }
        //            }
        //        }

        //        public static bool SP_Update_OfferPrice(Obj_PriceOffer info)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_OfferPrice", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
        //                    cmd.Parameters.Add(new SqlParameter("GiaTruocThayDoi", Decimal.Parse(info.GiaTruocThayDoi.Replace(",", "") != "" ? info.GiaTruocThayDoi.Replace(",", "") : "0")));
        //                    cmd.Parameters.Add(new SqlParameter("GiaSauThayDoi", Decimal.Parse(info.GiaSauThayDoi.Replace(",", "") != "" ? info.GiaSauThayDoi.Replace(",", "") : "0")));
        //                    cmd.Parameters.Add(new SqlParameter("GiaSauThayDoiPlus", Decimal.Parse(info.GiaSauThayDoiPlus.Replace(",", "") != "" ? info.GiaSauThayDoiPlus.Replace(",", "") : "0")));
        //                    if (String.IsNullOrWhiteSpace(info.ToDay))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(info.ToDay)));
        //                    }
        //                    if (String.IsNullOrWhiteSpace(info.FromDay))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(info.FromDay)));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("Link", info.Link != null ? info.Link : ""));

        //                    ///
        //                    cmd.Parameters.Add(new SqlParameter("GiaBanNYKhuyenNghi", Decimal.Parse(info.GiaBanNYKhuyenNghi != null ? info.GiaBanNYKhuyenNghi.Replace(",", "") : "0")));
        //                    if (String.IsNullOrWhiteSpace(info.NgayThongBaoChinhThuc))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DateTime.Parse(info.NgayThongBaoChinhThuc)));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc_ThoaThuanHD", info.NgayHieuLuc_ThoaThuanHD != null ? info.NgayHieuLuc_ThoaThuanHD : "0"));

        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Update_OfferPrice");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static bool Delete_OfferPrice(string ID)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_DELETE_OfferPrice", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_OfferPrice");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static bool Update_Status_OfferPrice(string ID, string HanhDong)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_Status_OfferPrice", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));
        //                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_OfferPrice");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static bool Update_GiaSauThayDoi_OfferPrice(string ID, string Price)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_GiaSauThayDoi_OfferPrice", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));
        //                    cmd.Parameters.Add(new SqlParameter("Price", Price));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_GiaSauThayDoi_OfferPrice");
        //                    return false;
        //                }
        //            }
        //        }

        //        public static Obj_PriceOffer Listget_PriceOffer_PopUp_BIBO(string ID)
        //        {
        //            Obj_PriceOffer itr = new Obj_PriceOffer();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Listget_PriceOffer_BIBO_PopUp", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        Obj_PriceOffer it = new Obj_PriceOffer
        //                        {
        //                            ID = reader["ID"].ToString(),
        //                            MaNCC = reader["MaNCC"].ToString(),
        //                            TenNCC = reader["TenNCC"].ToString(),
        //                            MaHang = reader["MaHang"].ToString(),
        //                            TenHang = reader["TenHang"].ToString(),
        //                            Barcode = reader["Barcode"].ToString(),
        //                            GiaTruocThayDoi = reader["GiaTruocThayDoi"].ToString(),
        //                            GiaSauThayDoi = reader["GiaSauThayDoi"].ToString(),
        //                            GiaTruocThayDoiPlus = reader["GiaTruocThayDoiPlus"].ToString(),
        //                            GiaSauThayDoiPlus = reader["GiaSauThayDoiPlus"].ToString(),
        //                            VAT = reader["VAT_"].ToString(),
        //                            ToDay = reader["ToDay"].ToString(),
        //                            FromDay = reader["FromDay"].ToString(),
        //                            Link = reader["Link"].ToString(),
        //                            Status = reader["Status"].ToString(),
        //                            GiaBanNYKhuyenNghi = reader["GiaBanNYKhuyenNghi"].ToString(),
        //                            NgayThongBaoChinhThuc = reader["NgayThongBaoChinhThuc"].ToString(),
        //                            // NgayHieuLuc_ThoaThuanHD = reader["NgayHieuLuc_ThoaThuanHD"].ToString()
        //                        };
        //                        itr = it;
        //                    }
        //                    con.Close();
        //                    return itr;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_PriceOffer_PopUp");
        //                    return itr;
        //                }
        //            }
        //        }
        public static List<objCombox> SP_getWay_DeXuatGia(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_getWay_DeXuatGia", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_getWay_DeXuatGia");
                    return it_r;
                }
            }
        }


        //        //-------------
        //        public static priceOffer Get_Price_HopDongThoaThuan_DeXuatDoiGia(string VendorNo, string MaHang)
        //        {
        //            priceOffer itr = new priceOffer();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Get_Price_HopDongThoaThuan_DeXuatDoiGia", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        priceOffer it = new priceOffer
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                            VAT = reader["VAT"].ToString(),
        //                            GiaTruocThayDoiPlus = reader["GiaTruocThayDoiPlus"].ToString()
        //                        };
        //                        itr = it;
        //                    }
        //                    con.Close();
        //                    return itr;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_Price_HopDongThoaThuan_DeXuatDoiGia");
        //                    return itr;
        //                }
        //            }
        //        }
        public static List<objCombox> SP_getWay_Pro_ITEM_Vendor(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_getWay_Pro_ITEM_Vendor", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["MaHang"].ToString(),
                            Name = reader["TenHang"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ITEM");
                    return it_r;
                }
            }
        }
        //        public static List<objCombox> get_NgayHieuLuc_ThoaThuanHD(string MaNCC)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("get_NgayHieuLuc_ThoaThuanHD", con);

        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["VendorNo"].ToString(),
        //                            Name = reader["NgayHieuLuc_ThoaThuanHD"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "get_NgayHieuLuc_ThoaThuanHD");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> SP_TRADTERM_GET_BARCODE(string ItemNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_BARCODE", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("itemNo", ItemNo));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Value"].ToString(),
        //                            Name = reader["Text"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_BARCODE");
        //                    return it_r;
        //                }
        //            }
        //        }
        public static List<objCombox> SP_TRADTERM_GET_Vendor()
{
    List<objCombox> it_r = new List<objCombox>();
    using (var con = new SqlConnection(strConn))
    {
        con.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                objCombox it = new objCombox
                {
                    Code = reader["Value"].ToString(),
                    Name = reader["Text"].ToString()
                };
                it_r.Add(it);
            }
            con.Close();
            return it_r;
        }
        catch (Exception ex)
        {
            con.Close();
            LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_Vendor");
            return it_r;
        }
    }
}
        //        public static List<objCombox> Get_List_OfferPrice_All_NCC()
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Get_List_OfferPrice_All_NCC", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_OfferPrice_All_NCC");
        //                    return it_r;
        //                }
        //            }
        //        }


        //        #endregion

        //        #region DebtPurchase
        //        public static List<objCombox> SP_Staff_Infomartion(string uid)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_Staff_Infomartion", con);
        //                    cmd.Parameters.Add(new SqlParameter("uid", uid));
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Staff_Infomartion");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> SP_TRADTERM_GET_Vendor_VendorCode(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor_VendorCode", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode.ToString()));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Value"].ToString(),
        //                            Name = reader["Text"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_Vendor");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable GetList_DebtPurchase(string vendorNo, string KyTinhCongNo, string Nam)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("GetList_DebtPurchase", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_DebtPurchase");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static DataTable GetList_DebtPurchase_Header(string vendorNo, string KyCongNo, string Nam, string Trangthai)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("GetList_DebtPurchase_Header", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyCongNo", KyCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
        //                    cmd.Parameters.Add(new SqlParameter("Trangthai", Trangthai));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_DebtPurchase_Header");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static List<objCombox> GetList_Debtpurchase_ApDungCho(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("GetList_Debtpurchase_ApDungCho", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_ApDungCho");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> SP_TRADTERM_GET_Vendor_CongNO()
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor_CongNo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Value"].ToString(),
        //                            Name = reader["Text"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_Vendor_CongNo");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> GetList_Debtpurchase_KyTinhCongNo(string vendorNo, string Nam)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("GetList_Debtpurchase_KyTinhCongNo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_KyTinhCongNo");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<DebtPurchase_Fillter> SP_DEBTPURCHASE_GET_INFO_VENDOR(string vendorNo, string KyTinhCongNo, string Nam)
        //        {
        //            List<DebtPurchase_Fillter> it_r = new List<DebtPurchase_Fillter>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_DEBTPURCHASE_GET_INFO_VENDOR", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        DebtPurchase_Fillter it = new DebtPurchase_Fillter
        //                        {
        //                            HanThanhToanKyNay = reader["HanThanhToanKyNay"].ToString(),
        //                            DieuKhoanThanhToan = reader["DieuKhoanThanhToan"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_DEBTPURCHASE_GET_INFO_VENDOR");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<Detail_DebtPurchase> GetList_Debtpurchase_XacNhanBBM(string vendorNo, string KyTinhCongNo, string Nam)
        //        {
        //            List<Detail_DebtPurchase> it_r = new List<Detail_DebtPurchase>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("GetList_Debtpurchase_XacNhanBBM", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        Detail_DebtPurchase it = new Detail_DebtPurchase
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                            NgayLapDeNghi = reader["NgayLapDeNghi"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_XacNhanBBM");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<Detail_DebtPurchase> GetList_Debtpurchase_XacNhanNCC(string vendorNo, string KyTinhCongNo, string Nam)
        //        {
        //            List<Detail_DebtPurchase> it_r = new List<Detail_DebtPurchase>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("GetList_Debtpurchase_XacNhanNCC", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        Detail_DebtPurchase it = new Detail_DebtPurchase
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                            NgayLapDeNghi = reader["NgayLapDeNghi"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_XacNhanNCC");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static bool Save_DebtPurchase_Header_XacNhanBBM(DebtPurchase_header info, string BBMNNguoiDuyet, string NewID)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Save_DebtPurchase_Header_XacNhanBBM", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC != null ? info.MaNCC : ""));
        //                    cmd.Parameters.Add(new SqlParameter("RcptNo", info.RcptNo != null ? info.RcptNo : ""));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", info.KyTinhCongNo != null ? info.KyTinhCongNo : ""));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", info.Nam != null ? info.Nam : ""));
        //                    cmd.Parameters.Add(new SqlParameter("BBMNNguoiDuyet", BBMNNguoiDuyet));
        //                    cmd.Parameters.Add(new SqlParameter("NewID", NewID));

        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_DebtPurchase_Header_XacNhanBBM");
        //                    return false;
        //                }
        //            }
        //        }
        //        #endregion


        //        #region báo cáo CongNo
        //        // News  17/05
        //        public static List<objSumTradingtem> SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        //        {
        //            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
        //                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objSumTradingtem it = new objSumTradingtem
        //                        {
        //                            Name = reader["Name"].ToString(),
        //                            PhanTram = reader["PhanTram"].ToString(),
        //                            Total = reader["Total"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objSumTradingtem> SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02(string ContractNo, string TypeTab, string SumDoanhSoVATDSThang, string SumDoanhSoDSThang)
        //        {
        //            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
        //                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVATDSThang", SumDoanhSoVATDSThang));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoDSThang", SumDoanhSoDSThang));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objSumTradingtem it = new objSumTradingtem
        //                        {
        //                            Name = reader["Name"].ToString(),
        //                            PhanTram = reader["PhanTram"].ToString(),
        //                            Total = reader["Total"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        //End
        //        public static List<objSumTradingtem> SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui(string ContractNo, string TypeTab, string MinPostingDate, string MaxMinPostingDate)
        //        {
        //            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
        //                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
        //                    cmd.Parameters.Add(new SqlParameter("MinPostingDate", MinPostingDate));
        //                    cmd.Parameters.Add(new SqlParameter("MaxMinPostingDate", MaxMinPostingDate));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objSumTradingtem it = new objSumTradingtem
        //                        {
        //                            Name = reader["Name"].ToString(),
        //                            PhanTram = reader["PhanTram"].ToString(),
        //                            Total = reader["Total"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static List<objSumTradingtem> SP_TRADTERM_LIST_DISCOUNT_SALES_ReportDeposit_CongNo(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        //        {
        //            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_DISCOUNT_SALES_ReportDeposit_CongNo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
        //                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objSumTradingtem it = new objSumTradingtem
        //                        {
        //                            Name = reader["Name"].ToString(),
        //                            PhanTram = reader["PhanTram"].ToString(),
        //                            Total = reader["Total"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objSumTradingtem> SP_TRADTERM_LIST_LINE_BONUS_KyGui(string ContractNo, string TypeTab)
        //        {
        //            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LINE_BONUS_KyGui", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
        //                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objSumTradingtem it = new objSumTradingtem
        //                        {
        //                            Name = reader["Name"].ToString(),
        //                            PhanTram = reader["PhanTram"].ToString(),
        //                            DieuKienDoanhSo = reader["DieuKienDoanhSo"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LINE_BONUS_KyGui");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objSumTradingtem> SP_TRADTERM_LIST_MKT_BONUS_CongNo(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        //        {
        //            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_MKT_BONUS_CongNo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
        //                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objSumTradingtem it = new objSumTradingtem
        //                        {
        //                            Name = reader["Name"].ToString(),
        //                            PhanTram = reader["PhanTram"].ToString(),
        //                            Total = reader["Total"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_MKT_BONUS_CongNo");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objSumTradingtem> SP_TRADTERM_LIST_BRAND_BONUS_CongNo(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        //        {
        //            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_BRAND_BONUS_CongNo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
        //                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objSumTradingtem it = new objSumTradingtem
        //                        {
        //                            Name = reader["Name"].ToString(),
        //                            PhanTram = reader["PhanTram"].ToString(),
        //                            Total = reader["Total"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_BRAND_BONUS_CongNo");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objSumTradingtem> SP_TRADTERM_LIST_CUSTOMER_BONUS_CongNo(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        //        {
        //            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_CUSTOMER_BONUS_CongNo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
        //                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objSumTradingtem it = new objSumTradingtem
        //                        {
        //                            Name = reader["Name"].ToString(),
        //                            PhanTram = reader["PhanTram"].ToString(),
        //                            Total = reader["Total"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_CUSTOMER_BONUS_CongNo");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objSumTradingtem> SP_TRADTERM_LIST_CHIPHIVANHANH_CongNo(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo, string MinPostingDate, string MaxMinPostingDate)
        //        {
        //            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_CHIPHIVANHANH_CongNo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
        //                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
        //                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
        //                    cmd.Parameters.Add(new SqlParameter("MinPostingDate", MinPostingDate));
        //                    cmd.Parameters.Add(new SqlParameter("MaxMinPostingDate", MaxMinPostingDate));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objSumTradingtem it = new objSumTradingtem
        //                        {
        //                            Name = reader["Name"].ToString(),
        //                            PhanTram = reader["PhanTram"].ToString(),
        //                            Total = reader["Total"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_CHIPHIVANHANH_CongNo");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<ReportDeposit_TradingTemMienBN> GetList_TBL_BBM_ReportDeposit_TradingTem(string VendorNo, string KyCongNo, string Nam, string TypeMien, string TypeBy_NCC_BBM)
        //        {
        //            List<ReportDeposit_TradingTemMienBN> it_r = new List<ReportDeposit_TradingTemMienBN>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("GetList_TBL_BBM_ReportDeposit_TradingTem", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyCongNo", KyCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
        //                    cmd.Parameters.Add(new SqlParameter("TypeMien", TypeMien));
        //                    cmd.Parameters.Add(new SqlParameter("TypeBy_NCC_BBM", TypeBy_NCC_BBM));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        ReportDeposit_TradingTemMienBN it = new ReportDeposit_TradingTemMienBN
        //                        {
        //                            Tieude = reader["Tieude"].ToString(),
        //                            Total = reader["Total"].ToString(),
        //                            SoHD = reader["SoHD"].ToString(),
        //                            NgayHD = reader["NgayHD"].ToString(),
        //                            GhiChu = reader["GhiChu"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_TBL_BBM_ReportDeposit_TradingTem");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region ReportDepositDetail
        //        public static List<objCombox> GetList_ReportDeposit_KyTinhCongNo(string vendorNo, string Nam)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_KyTinhCongNo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_KyTinhCongNo");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> SP_TRADTERM_GET_ReportDeposit_KyGui()
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_ReportDeposit_KyGui", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Value"].ToString(),
        //                            Name = reader["Text"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_ReportDeposit_KyGui");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<DebtPurchase_Fillter> SP_ReportDeposit_GET_INFO_VENDOR(string vendorNo, string KyTinhCongNo, string Nam)
        //        {
        //            List<DebtPurchase_Fillter> it_r = new List<DebtPurchase_Fillter>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_ReportDeposit_GET_INFO_VENDOR", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        DebtPurchase_Fillter it = new DebtPurchase_Fillter
        //                        {
        //                            HanThanhToanKyNay = reader["HanThanhToanKyNay"].ToString(),
        //                            DieuKhoanThanhToan = reader["DieuKhoanThanhToan"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ReportDeposit_GET_INFO_VENDOR");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable GetList_ReportDepositDetail(string vendorNo, string KyTinhCongNo, string Nam, string Thang)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("GetList_ReportDepositDetail_getways", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
        //                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDepositDetail_getway");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool Save_ReportDeposit_Header_XacNhan_NCC(ReportDeposit_header info, string NCCNguoiDuyet, string NewID)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Save_ReportDeposit_Header_XacNhan_NCC", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC != null ? info.MaNCC : ""));
        //                    cmd.Parameters.Add(new SqlParameter("ItemNo", info.ItemNo != null ? info.ItemNo : ""));
        //                    cmd.Parameters.Add(new SqlParameter("GhiChu", info.GhiChu != null ? info.GhiChu : ""));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", info.KyTinhCongNo != null ? info.KyTinhCongNo : ""));
        //                    cmd.Parameters.Add(new SqlParameter("NCCNguoiDuyet", NCCNguoiDuyet));
        //                    cmd.Parameters.Add(new SqlParameter("NewID", NewID));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_ReportDeposit_Header_XacNhan");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static List<Detail_DebtPurchase> GetList_ReportDeposit_XacNhanBBM(string vendorNo, string KyTinhCongNo, string Nam)
        //        {
        //            List<Detail_DebtPurchase> it_r = new List<Detail_DebtPurchase>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_XacNhanBBM", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        Detail_DebtPurchase it = new Detail_DebtPurchase
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                            NgayLapDeNghi = reader["NgayLapDeNghi"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_XacNhanBBM");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<Detail_DebtPurchase> GetList_ReportDeposit_XacNhanNCC(string vendorNo, string KyTinhCongNo, string Nam)
        //        {
        //            List<Detail_DebtPurchase> it_r = new List<Detail_DebtPurchase>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_XacNhanNCC", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        Detail_DebtPurchase it = new Detail_DebtPurchase
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                            NgayLapDeNghi = reader["NgayLapDeNghi"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_XacNhanNCC");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable GetList_ReportDeposit_Header(string vendorNo, string KyCongNo, string Nam, string Trangthai)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_Header", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("KyCongNo", KyCongNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
        //                    cmd.Parameters.Add(new SqlParameter("Trangthai", Trangthai));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_Header");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool Save_ReportDeposit_Header_XacNhanBBM(ReportDeposit_XacNhanBBM info, string BBMNNguoiDuyet, string NewID)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Save_ReportDeposit_Header_XacNhanBBM", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC != null ? info.MaNCC : ""));
        //                    cmd.Parameters.Add(new SqlParameter("ItemNo", info.ItemNo != null ? info.ItemNo : ""));
        //                    if (String.IsNullOrWhiteSpace(info.KyTinhCongNo))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", DateTime.Parse(info.KyTinhCongNo)));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("BBMNNguoiDuyet", BBMNNguoiDuyet));
        //                    cmd.Parameters.Add(new SqlParameter("NewID", NewID));
        //                    cmd.Parameters.Add(new SqlParameter("Ngayban", info.Ngayban != null ? info.Ngayban : ""));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_ReportDeposit_Header_XacNhanBBM");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static List<objCombox> GetList_ReportDeposit_NgayBan(string vendorNo, string Nam)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_NgayBan", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_NgayBan");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static bool Save_ReportDeposit_TradingTem(ReportDeposit_TradingTemMienBN info, string CreateBy)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Save_ReportDeposit_TradingTem", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC != null ? info.MaNCC : ""));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", info.Nam != null ? info.Nam : ""));
        //                    cmd.Parameters.Add(new SqlParameter("KyCongNo", info.KyCongNo != null ? info.KyCongNo : ""));
        //                    cmd.Parameters.Add(new SqlParameter("Tieude", info.Tieude != null ? info.Tieude : ""));
        //                    cmd.Parameters.Add(new SqlParameter("Total", info.Total != null ? info.Total : ""));
        //                    cmd.Parameters.Add(new SqlParameter("SoHD", info.SoHD != null ? info.SoHD : ""));
        //                    if (String.IsNullOrWhiteSpace(info.NgayHD))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("NgayHD", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("NgayHD", DateTime.Parse(info.NgayHD)));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("GhiChu", info.GhiChu != null ? info.GhiChu : ""));
        //                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
        //                    cmd.Parameters.Add(new SqlParameter("TypeBy_NCC_BBM", info.TypeBy_NCC_BBM != null ? info.TypeBy_NCC_BBM : ""));
        //                    cmd.Parameters.Add(new SqlParameter("TypeMien", info.TypeMien != null ? info.TypeMien : ""));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_ReportDeposit_TradingTem");
        //                    return false;
        //                }
        //            }
        //        }

        //        #endregion

        //        #region ReturnedGoods
        //        public static List<objCombox> sp_HangTraLai_MD_Sub_get(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_HangTraLai_MD_Sub_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_HangTraLai_MD_Sub_get");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> sp_TinhThanh_MD_Sub_get(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_TinhThanh_MD_Sub_get", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_TinhThanh_MD_Sub_get");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> sp_getWay_CuaHang(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_getWay_CuaHang", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getWay_CuaHang");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> SP_BBS_QLHH_Status_HH(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();

        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_GetWay_QLHH_Status_HH", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    cmd.CommandTimeout = 300;
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox its = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(its);
        //                    }
        //                    con.Close();

        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_QLHH_Status_HH");
        //                    return it_r;
        //                }

        //            }
        //        }
        //        public static List<objCombox> SP_ReturnedGoods_Vender()
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_GetWay_QLHH_ReturnedGood_NhaCungCap", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GetWay_QLHH_ReturnedGood_NhaCungCap");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static List<objCombox> SP_BBS_QLHH_VendorCode()
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();

        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_BBS_QLHH_VendorCode", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 300;
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox its = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(its);
        //                    }
        //                    con.Close();

        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_QLHH_VendorCode");
        //                    return it_r;
        //                }

        //            }
        //        }
        //        public static DataTable SP_GetWay_QLHH_getlstCH_NCC(string Mien, string Tinh, string Kho, string MaHang, string TinhTrang, string TrangThai, string VendorCode)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strCon_SPACEMAN))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("SP_GetWay_QLHH_getlstCH_NCC_Noi2Bang_RangeReview_ReturnedGood_BIBO_Apr", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("Mien", Mien));
        //                    cmd.Parameters.Add(new SqlParameter("Tinh", Tinh));
        //                    cmd.Parameters.Add(new SqlParameter("Kho", Kho));
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("TinhTrang", TinhTrang));
        //                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GetWay_QLHH_getlstCH_NCC");
        //                return ds.Tables[0];
        //            }
        //        }
        //        #endregion

        //        #region Report_KyGui
        //        public static List<objCombox> Report_KyGui_ShowNam(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Report_KyGui_ShowNam", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Report_KyGui_ShowNam");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> Report_KyGui_ShowThang(string vendorNo, string Nam)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Report_KyGui_ShowThang", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Report_KyGui_ShowThang");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable Report_KyGui_KyDoiChieu(string vendorNo, string Nam, string Thang)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("Report_KyGui_KyDoiChieu", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
        //                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Report_KyGui_KyDoiChieu");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static List<ShowBenA_NCC> Report_KyGui_ShowBenA_NCC(string VendorNo)
        //        {
        //            List<ShowBenA_NCC> it_r = new List<ShowBenA_NCC>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Report_KyGui_ShowBenA_NCC", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        ShowBenA_NCC it = new ShowBenA_NCC
        //                        {
        //                            TenNCC = reader["TenNCC"].ToString(),
        //                            DiaChi = reader["DiaChi"].ToString(),
        //                            MaSoThue = reader["MaSoThue"].ToString(),
        //                            DaiDien = reader["DaiDien"].ToString(),
        //                            ChucVu = reader["ChucVu"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Report_KyGui_ShowBenA_NCC");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static bool Report_KyGui_DoiChieuCongNo_Header(DoiChieuCongNo_KyGui_Header info, string CreateBy)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Save_Report_KyGui_DoiChieuCongNo_Header", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", info.VendorNo != null ? info.VendorNo : ""));
        //                    cmd.Parameters.Add(new SqlParameter("Thang", info.Thang != null ? info.Thang : ""));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", info.Nam != null ? info.Nam : ""));
        //                    cmd.Parameters.Add(new SqlParameter("VendorName", info.VendorName != null ? info.VendorName : ""));
        //                    cmd.Parameters.Add(new SqlParameter("DiaChi", info.DiaChi != null ? info.DiaChi : ""));
        //                    cmd.Parameters.Add(new SqlParameter("MaSoThue", info.MaSoThue != null ? info.MaSoThue : ""));
        //                    cmd.Parameters.Add(new SqlParameter("SoTaiKhoan", info.SoTaiKhoan != null ? info.SoTaiKhoan : ""));
        //                    cmd.Parameters.Add(new SqlParameter("NganHang", info.NganHang != null ? info.NganHang : ""));
        //                    cmd.Parameters.Add(new SqlParameter("DaiDien", info.DaiDien != null ? info.DaiDien : ""));
        //                    cmd.Parameters.Add(new SqlParameter("ChucVu", info.ChucVu != null ? info.ChucVu : ""));

        //                    cmd.Parameters.Add(new SqlParameter("TenCongTyBBM", info.TenCongTyBBM != null ? info.TenCongTyBBM : ""));
        //                    cmd.Parameters.Add(new SqlParameter("DiaChiBBM", info.DiaChiBBM != null ? info.DiaChiBBM : ""));
        //                    cmd.Parameters.Add(new SqlParameter("MaSoThueBBM", info.MaSoThueBBM != null ? info.MaSoThueBBM : ""));
        //                    cmd.Parameters.Add(new SqlParameter("DaiDienBBM", info.DaiDienBBM != null ? info.DaiDienBBM : ""));
        //                    cmd.Parameters.Add(new SqlParameter("ChucVuBBM", info.ChucVuBBM != null ? info.ChucVuBBM : ""));
        //                    if (String.IsNullOrWhiteSpace(info.PaymentDate))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("PaymentDate", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("PaymentDate", DateTime.Parse(info.PaymentDate)));
        //                    }
        //                    if (String.IsNullOrWhiteSpace(info.MinNgayBan))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("MinNgayBan", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("MinNgayBan", DateTime.Parse(info.MinNgayBan)));
        //                    }
        //                    if (String.IsNullOrWhiteSpace(info.MaxNgayBan))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("MaxNgayBan", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("MaxNgayBan", DateTime.Parse(info.MaxNgayBan)));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Report_KyGui_DoiChieuCongNo_Header");
        //                    return false;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region Report_MuaBan
        //        public static List<objCombox> Report_MuaBan_NCC()
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Report_MuaBan_NCC", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Value"].ToString(),
        //                            Name = reader["Text"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_Vendor_CongNo");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<ShowBenA_NCC> Report_MuaBan_ShowBenA_NCC(string VendorNo)
        //        {
        //            List<ShowBenA_NCC> it_r = new List<ShowBenA_NCC>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Report_MuaBan_ShowBenA_NCC", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        ShowBenA_NCC it = new ShowBenA_NCC
        //                        {
        //                            TenNCC = reader["TenNCC"].ToString(),
        //                            DiaChi = reader["DiaChi"].ToString(),
        //                            MaSoThue = reader["MaSoThue"].ToString(),
        //                            DaiDien = reader["DaiDien"].ToString(),
        //                            ChucVu = reader["ChucVu"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Report_MuaBan_ShowBenA_NCC");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> Report_MuaBan_ShowNam(string vendorNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Report_MuaBan_ShowNam", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));

        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Report_MuaBan_ShowNam");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> Report_MuaBan_ShowThang(string vendorNo, string Nam)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Report_MuaBan_ShowThang", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Report_MuaBan_ShowThang");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static bool Report_MuaBan_DoiChieuCongNo_Header(DoiChieuCongNo_MuaBan_Header info, string CreateBy)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Save_Report_MuaBan_DoiChieuCongNo_Header", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", info.VendorNo != null ? info.VendorNo : ""));
        //                    cmd.Parameters.Add(new SqlParameter("Thang", info.Thang != null ? info.Thang : ""));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", info.Nam != null ? info.Nam : ""));
        //                    cmd.Parameters.Add(new SqlParameter("VendorName", info.VendorName != null ? info.VendorName : ""));
        //                    cmd.Parameters.Add(new SqlParameter("DiaChi", info.DiaChi != null ? info.DiaChi : ""));
        //                    cmd.Parameters.Add(new SqlParameter("MaSoThue", info.MaSoThue != null ? info.MaSoThue : ""));
        //                    cmd.Parameters.Add(new SqlParameter("SoTaiKhoan", info.SoTaiKhoan != null ? info.SoTaiKhoan : ""));
        //                    cmd.Parameters.Add(new SqlParameter("NganHang", info.NganHang != null ? info.NganHang : ""));
        //                    cmd.Parameters.Add(new SqlParameter("DaiDien", info.DaiDien != null ? info.DaiDien : ""));
        //                    cmd.Parameters.Add(new SqlParameter("ChucVu", info.ChucVu != null ? info.ChucVu : ""));

        //                    cmd.Parameters.Add(new SqlParameter("TenCongTyBBM", info.TenCongTyBBM != null ? info.TenCongTyBBM : ""));
        //                    cmd.Parameters.Add(new SqlParameter("DiaChiBBM", info.DiaChiBBM != null ? info.DiaChiBBM : ""));
        //                    cmd.Parameters.Add(new SqlParameter("MaSoThueBBM", info.MaSoThueBBM != null ? info.MaSoThueBBM : ""));
        //                    cmd.Parameters.Add(new SqlParameter("DaiDienBBM", info.DaiDienBBM != null ? info.DaiDienBBM : ""));
        //                    cmd.Parameters.Add(new SqlParameter("ChucVuBBM", info.ChucVuBBM != null ? info.ChucVuBBM : ""));
        //                    if (String.IsNullOrWhiteSpace(info.PaymentDate))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("PaymentDate", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("PaymentDate", DateTime.Parse(info.PaymentDate)));
        //                    }
        //                    if (String.IsNullOrWhiteSpace(info.KyTinhCongNo))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", DateTime.Parse(info.KyTinhCongNo)));
        //                    }
        //                    if (String.IsNullOrWhiteSpace(info.MinPostingDate))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("MinPostingDate", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("MinPostingDate", DateTime.Parse(info.MinPostingDate)));
        //                    }
        //                    if (String.IsNullOrWhiteSpace(info.MaxPostingDate))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("MaxPostingDate", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("MaxPostingDate", DateTime.Parse(info.MaxPostingDate)));
        //                    }

        //                    if (String.IsNullOrWhiteSpace(info.TuNgay))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("TuNgay", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("TuNgay", DateTime.Parse(info.TuNgay)));
        //                    }
        //                    if (String.IsNullOrWhiteSpace(info.DenNgay))
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("DenNgay", DBNull.Value));
        //                    }
        //                    else
        //                    {
        //                        cmd.Parameters.Add(new SqlParameter("DenNgay", DateTime.Parse(info.DenNgay)));
        //                    }
        //                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_Report_MuaBan_DoiChieuCongNo_Header");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static List<objCombox> Report_MuaBan_KyTinhCongNo(string VendorNo, string Nam, string Thang)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Report_MuaBan_KyTinhCongNo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
        //                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Report_MuaBan_KyTinhCongNo");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable Report_MuaBan_DoiChieuCongNo(string vendorNo, string Nam, string Thang, string KyTinhCongNo)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("Report_MuaBan_DoiChieuCongNo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
        //                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
        //                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Report_MuaBan_DoiChieuCongNo");
        //                return ds.Tables[0];
        //            }
        //        }

        //        #endregion



        //        #region Delivery
        //        public static List<objCombox> SP_Delivery_Vender()
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_Delivery_Vender", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Delivery_Vender");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable BBM_APR_Delivery(string VenderNo, string TrangThai, string CuaHang)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("BBM_APR_Delivery", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("VenderNo", VenderNo));
        //                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
        //                    cmd.Parameters.Add(new SqlParameter("CuaHang", CuaHang));

        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_APR_Delivery");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool Post_Status_Delivery(string ID, string Status, string uid)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Post_Status_Delivery", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("IDHeader", ID));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("uid ", uid));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Post_Status_Delivery");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static DataTable SP_Delivery_listProductsCheck_Detail(string IDHeader)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("SP_Delivery_listProductsCheck_BIBO_Detail", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("IDHeader", IDHeader));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Delivery_listProductsCheck_Detail");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static DataTable BBM_TradingTern_Delivery_listAdd_Store_Detail(string IDHeader)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("BBM_TradingTern_Delivery_listAdd_Store_Detail", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("IDHeader", IDHeader));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_TradingTern_Delivery_listAdd_Store_Detail");
        //                return ds.Tables[0];
        //            }
        //        }

        //        #endregion


        //        #region Chỉ định khuyến mãi PushSale
        //        public static List<objCombox> SP_PushSale_Vender(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_PushSale_Vender", con);

        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_PushSale_Vender");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable QL_SP_CTKM_PushSale_HHOA_KGUI(string vendorNo, string MaHang, string Barcode, string TrangThai)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strCon_SPACEMAN))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("QL_SP_CTKM_PushSale_HHOA_KGUI", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("Barcode", Barcode));
        //                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "QL_SP_CTKM_PushSale_HHOA_KGUI");
        //                return ds.Tables[0];
        //            }
        //        }

        //        public static List<objCombox> SP_PushSale_Vender_BARCODE(string ItemNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_PushSale_Vender_BARCODE", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("itemNo", ItemNo));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Value"].ToString(),
        //                            Name = reader["Text"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_PushSale_Vender_BARCODE");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> SP_PushSale_Vender_ITEM_Vendor(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_PushSale_Vender_ITEM_Vendor", con);

        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["MaHang"].ToString(),
        //                            Name = reader["TenHang"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_PushSale_Vender_ITEM_Vendor");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static bool Update_Status_PushSale(string ID, string HanhDong, string userid)
        //        {
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_Status_PushSale", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));
        //                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
        //                    cmd.Parameters.Add(new SqlParameter("userid", userid));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_PushSale");
        //                    return false;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region ChiDinhHotdealApr
        //        public static List<objCombox> SP_ChiDinhHotdeal_Vender(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_Chidinhhotdeal_Vender", con);

        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ChiDinhHotdeal_Vender");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> SP_ChiDinhHotdeal_Vender_BARCODE(string ItemNo)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_ChiDinhHotdeal_Vender_BARCODE", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("itemNo", ItemNo));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Value"].ToString(),
        //                            Name = reader["Text"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ChiDinhHotdeal_Vender_BARCODE");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> SP_ChiDinhHotdeal_Vender_ITEM_Vendor(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_ChiDinhHotdeal_Vender_ITEM_Vendor", con);

        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["MaHang"].ToString(),
        //                            Name = reader["TenHang"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ChiDinhHotdeal_Vender_ITEM_Vendor");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable ChiDinhHotdealApr(string vendorNo, string MaHang, string TrangThai)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strCon_SPACEMAN))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("BIBO_ChiDinhHotdeal_Apr_HHOA_KGUI", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BIBO_ChiDinhHotdeal_Apr_HHOA_KGUI");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool Update_Status_Gateway_Hotdel(string ID, string HanhDong, string userid)
        //        {
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_Status_Gateway_Hotdel", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));
        //                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
        //                    cmd.Parameters.Add(new SqlParameter("userid", userid));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_Gateway_Hotdel");
        //                    return false;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region Bình ổn giá
        //        public static List<objCombox> SP_BinhOnGia_Vender(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_BinhOnGia_Vender", con);

        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BinhOnGia_Vender");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> SP_BinhOnGia_Vender_ITEM_Vendor(string VendorCode)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_BinhOnGia_Vender_ITEM_Vendor", con);

        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["MaHang"].ToString(),
        //                            Name = reader["TenHang"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BinhOnGia_Vender_ITEM_Vendor");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable Getway_BinhOnGia_ThiTruong_Arp_Bibo(string NhaCC, string MaHang, string NgayCapNhat, string TrangThai)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strCon_SPACEMAN))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("Getway_BinhOnGia_ThiTruong_Arp_Bibo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("NhaCC", NhaCC));
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("NgayCapNhat", NgayCapNhat));
        //                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Getway_BinhOnGia_ThiTruong_Arp_Bibo");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool Update_Status_BinhOnGia_ERP(string ID, string MaHang, string Status, string uid)
        //        {
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Update_Status_BinhOnGia_ERP", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("ID", ID));
        //                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("NguoiTao", uid));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_BinhOnGia_ERP");
        //                    return false;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region CTKM Mua
        //        public static List<objCombox> SP_CTKM_Mua_Ar_Bibo_NCC()
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_CTKM_Mua_Ar_Bibo_NCC", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BinhOnGia_Vender");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<CTKM_Ql_GateWay> SP_CTKM_Ql_Bibo_Popup(string MaNCC, string MaCTKM)
        //        {
        //            List<CTKM_Ql_GateWay> it_r = new List<CTKM_Ql_GateWay>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_CTKM_Ql_Bibo_Popup", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    var reader = cmd.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        CTKM_Ql_GateWay it = new CTKM_Ql_GateWay
        //                        {
        //                            MaNCC = reader["MaNCC"].ToString(),
        //                            TenNCC = reader["TenNCC"].ToString(),
        //                            MaCTKM = reader["MaCTKM"].ToString(),
        //                            TenCTKM = reader["TenCTKM"].ToString(),
        //                            TuNgay = reader["TuNgay"].ToString(),
        //                            DenNgay = reader["DenNgay"].ToString(),
        //                            MaHang = reader["MaHang"].ToString(),
        //                            TenHang = reader["TenHang"].ToString(),
        //                            SLHang = reader["SLHang"].ToString(),
        //                            MaQua = reader["MaQua"].ToString(),
        //                            TenQua = reader["TenQua"].ToString(),
        //                            SLQua = reader["SLQua"].ToString(),
        //                            HinhAnh = reader["HinhAnh"].ToString(),
        //                            Status = reader["Status"].ToString(),
        //                            TrangThai = reader["TrangThai"].ToString(),
        //                            CreateDate = reader["CreateDate"].ToString(),
        //                            ModifyDate = reader["ModifyDate"].ToString()

        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_CTKM_Ql_Bibo_Popup");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static DataTable SP_CTKM_Mua_Ar_Bibo(string MaNCC, string MaCTKM, string Status, string TuNgay, string DenNgay)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("SP_CTKM_Mua_Ar_Bibo", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    cmd.Parameters.Add(new SqlParameter("TuNgay", TuNgay));
        //                    cmd.Parameters.Add(new SqlParameter("DenNgay", DenNgay));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_CTKM_Mua_Ar_Bibo");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool Post_Status_CTMK(string MaCTKM, string MaNCC, string Status, string Json, string uid)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Post_Status_CTMK", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("Json", Json));
        //                    cmd.Parameters.Add(new SqlParameter("uid ", uid));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Post_Status_CTMK");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static List<CTKM_BiBo_GateWay_Header> SP_CTKM_Mua_Detail_Header(string MaCTKM, string MaNCC)
        //        {
        //            List<CTKM_BiBo_GateWay_Header> it_r = new List<CTKM_BiBo_GateWay_Header>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_CTKM_Mua_Detail_Header", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM ", MaCTKM));
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC ", MaNCC));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        CTKM_BiBo_GateWay_Header it = new CTKM_BiBo_GateWay_Header
        //                        {
        //                            MaNCC = reader["MaNCC"].ToString(),
        //                            TenNCC = reader["TenNCC"].ToString(),
        //                            MaCTKM = reader["MaCTKM"].ToString(),
        //                            TenCTKM = reader["TenCTKM"].ToString(),
        //                            TuNgay = reader["TuNgay"].ToString(),
        //                            DenNgay = reader["DenNgay"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_CTKM_Mua_Detail_Header");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<CTKM_BiBo_GateWay_Line> SP_CTKM_Mua_Detail_Line(string MaCTKM, string MaNCC)
        //        {
        //            List<CTKM_BiBo_GateWay_Line> it_r = new List<CTKM_BiBo_GateWay_Line>();
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("SP_CTKM_Mua_Detail_Line", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM ", MaCTKM));
        //                    cmd.Parameters.Add(new SqlParameter("MaNCC ", MaNCC));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        CTKM_BiBo_GateWay_Line it = new CTKM_BiBo_GateWay_Line
        //                        {
        //                            MaNCC = reader["MaNCC"].ToString(),
        //                            TenNCC = reader["TenNCC"].ToString(),
        //                            MaCTKM = reader["MaCTKM"].ToString(),
        //                            MaHang = reader["MaHang"].ToString(),
        //                            TenHang = reader["TenHang"].ToString(),
        //                            HinhAnh = reader["HinhAnh"].ToString(),
        //                            SLHang = reader["SLHang"].ToString(),
        //                            MaQua = reader["MaQua"].ToString(),
        //                            TenQua = reader["TenQua"].ToString(),
        //                            SLQua = reader["SLQua"].ToString(),
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_CTKM_Mua_Detail_Line");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        #endregion

        //        #region ComboKhuyenMai
        //        public static DataTable ComboKhuyenMai_Header_Detail(string TenCT, string VendorCode, string TrangThai, string NgayTao)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strConn))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("ComboKhuyenMai_Header_Detail_Ar_BIBO", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("TenCT", TenCT));
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
        //                    cmd.Parameters.Add(new SqlParameter("NgayTao", NgayTao));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ComboKhuyenMai_Header_Detail_Ar_BIBO");
        //                return ds.Tables[0];
        //            }
        //        }
        //        public static bool ComboKhuyenMai_Update(string MaCTKM, string VendorCode, string Status, string ModifyBy)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("ComboKhuyenMai_Update", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("ModifyBy", ModifyBy));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ComboKhuyenMai_Update");
        //                    return false;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region ComboKhuyenMai
        //        public static bool QuanLyTrungBayHH_Update(string MaCTKM, string VendorCode, string Status, string ModifyBy)
        //        {
        //            using (var con = new SqlConnection(strConn))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("QuanLyTrungBayHH_Update", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
        //                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
        //                    cmd.Parameters.Add(new SqlParameter("Status", Status));
        //                    cmd.Parameters.Add(new SqlParameter("ModifyBy", ModifyBy));
        //                    var reader = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "QuanLyTrungBayHH_Update");
        //                    return false;
        //                }
        //            }
        //        }
        //        public static string sp_bbs_Approve_ChiDinhCaiAR_TrungBayNganhHang(string userid, string MaAutoCT, string mahang, string MaCuaHang, string status)
        //        {
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_bbs_Approve_ChiDinhCaiAR_TrungBayNganhHang_getWay", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("userid", userid));
        //                    cmd.Parameters.Add(new SqlParameter("MaAutoCT", @MaAutoCT));
        //                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));
        //                    cmd.Parameters.Add(new SqlParameter("MaCuaHang", MaCuaHang));
        //                    cmd.Parameters.Add(new SqlParameter("status", status));


        //                    var result = (string)cmd.ExecuteScalar();

        //                    con.Close();
        //                    return result;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_Approve_ChiDinhCaiAR_TrungBayNganhHang_getWay");
        //                    return "0";
        //                }
        //            }
        //        }
        //        #endregion

        //        #region Filter_Sql
        //        public static List<objCombox> sp_Fillter_Cha_Customer360New()
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("sp_Dynamic_Filters__Cha_Customer360New", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Dynamic_Filters__Cha_Customer360New");
        //                    return it_r;
        //                }
        //            }
        //        }
        //        public static List<objCombox> Select_TenCot_dynamic_filters_Customer360New(string TenCot)
        //        {
        //            List<objCombox> it_r = new List<objCombox>();
        //            using (var con = new SqlConnection(strCon_SPACEMAN))
        //            {
        //                con.Open();
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("Select_TenCot_dynamic_filters_Customer360New", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add(new SqlParameter("colName", TenCot));
        //                    var reader = cmd.ExecuteReader();

        //                    while (reader.Read())
        //                    {
        //                        objCombox it = new objCombox
        //                        {
        //                            Code = reader["Code"].ToString(),
        //                            Name = reader["Name"].ToString()
        //                        };
        //                        it_r.Add(it);
        //                    }
        //                    con.Close();
        //                    return it_r;
        //                }
        //                catch (Exception ex)
        //                {
        //                    con.Close();
        //                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Select_TenCot_dynamic_filters_Customer360New");
        //                    return it_r;
        //                }
        //            }
        //        }

        //        public static DataTable Select_LocAll_dynamic_filters_Customer360New(string Sql)
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                using (var con = new SqlConnection(strCon_SPACEMAN))
        //                {
        //                    con.Open();
        //                    SqlCommand cmd = new SqlCommand("Select_LocAll_dynamic_filters_Customer360New", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 30000;
        //                    cmd.Parameters.Add(new SqlParameter("Sql", Sql));
        //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                    {
        //                        sda.Fill(ds);
        //                    }
        //                    con.Close();
        //                    return ds.Tables[0];
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BIBO_ChiDinhHotdeal_Apr_HHOA_KGUI");
        //                return ds.Tables[0];
        //            }
        //        }

        //        #endregion

    }
}