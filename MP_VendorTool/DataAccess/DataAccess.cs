using MP_VendorTool.Models.Account;
using MP_VendorTool.Models.DataType;
using MP_VendorTool.Models.Seminar;
using MP_VendorTool.Models.Tradingterm;
using MP_VendorTool.Models.TradingTermVendor;
using MP_VendorTool.Models.Vendor;
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
using ProductAllTool.Models.SourceProduct;
using ProductAllTool.Models.Product;

namespace MP_VendorTool.DataAccess
{
    public class DataAccess
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConnSpac = ConfigurationManager.AppSettings.Get("strConnSpac");

        #region báo cáo CongNo
        // News  17/05
        public static List<objSumTradingtem> SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        {
            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objSumTradingtem it = new objSumTradingtem
                        {
                            Name = reader["Name"].ToString(),
                            PhanTram = reader["PhanTram"].ToString(),
                            Total = reader["Total"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01");
                    return it_r;
                }
            }
        }
        public static List<objSumTradingtem> SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02(string ContractNo, string TypeTab, string SumDoanhSoVATDSThang, string SumDoanhSoDSThang)
        {
            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVATDSThang", SumDoanhSoVATDSThang));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoDSThang", SumDoanhSoDSThang));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objSumTradingtem it = new objSumTradingtem
                        {
                            Name = reader["Name"].ToString(),
                            PhanTram = reader["PhanTram"].ToString(),
                            Total = reader["Total"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02");
                    return it_r;
                }
            }
        }
        //End
        public static List<objSumTradingtem> SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui(string ContractNo, string TypeTab, string MinPostingDate, string MaxMinPostingDate)
        {
            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    cmd.Parameters.Add(new SqlParameter("MinPostingDate", MinPostingDate));
                    cmd.Parameters.Add(new SqlParameter("MaxMinPostingDate", MaxMinPostingDate));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objSumTradingtem it = new objSumTradingtem
                        {
                            Name = reader["Name"].ToString(),
                            PhanTram = reader["PhanTram"].ToString(),
                            Total = reader["Total"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui");
                    return it_r;
                }
            }
        }
        public static List<objSumTradingtem> SP_TRADTERM_LIST_DISCOUNT_SALES_ReportDeposit_CongNo(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        {
            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_DISCOUNT_SALES_ReportDeposit_CongNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objSumTradingtem it = new objSumTradingtem
                        {
                            Name = reader["Name"].ToString(),
                            PhanTram = reader["PhanTram"].ToString(),
                            Total = reader["Total"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui");
                    return it_r;
                }
            }
        }
        public static List<objSumTradingtem> SP_TRADTERM_LIST_LINE_BONUS_KyGui(string ContractNo, string TypeTab)
        {
            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LINE_BONUS_KyGui", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objSumTradingtem it = new objSumTradingtem
                        {
                            Name = reader["Name"].ToString(),
                            PhanTram = reader["PhanTram"].ToString(),
                            DieuKienDoanhSo = reader["DieuKienDoanhSo"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LINE_BONUS_KyGui");
                    return it_r;
                }
            }
        }
        public static List<objSumTradingtem> SP_TRADTERM_LIST_MKT_BONUS_CongNo(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        {
            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_MKT_BONUS_CongNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objSumTradingtem it = new objSumTradingtem
                        {
                            Name = reader["Name"].ToString(),
                            PhanTram = reader["PhanTram"].ToString(),
                            Total = reader["Total"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_MKT_BONUS_CongNo");
                    return it_r;
                }
            }
        }
        public static List<objSumTradingtem> SP_TRADTERM_LIST_BRAND_BONUS_CongNo(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        {
            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_BRAND_BONUS_CongNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objSumTradingtem it = new objSumTradingtem
                        {
                            Name = reader["Name"].ToString(),
                            PhanTram = reader["PhanTram"].ToString(),
                            Total = reader["Total"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_BRAND_BONUS_CongNo");
                    return it_r;
                }
            }
        }
        public static List<objSumTradingtem> SP_TRADTERM_LIST_CUSTOMER_BONUS_CongNo(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        {
            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_CUSTOMER_BONUS_CongNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objSumTradingtem it = new objSumTradingtem
                        {
                            Name = reader["Name"].ToString(),
                            PhanTram = reader["PhanTram"].ToString(),
                            Total = reader["Total"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_CUSTOMER_BONUS_CongNo");
                    return it_r;
                }
            }
        }
        public static List<objSumTradingtem> SP_TRADTERM_LIST_CHIPHIVANHANH_CongNo(string ContractNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo, string MinPostingDate, string MaxMinPostingDate)
        {
            List<objSumTradingtem> it_r = new List<objSumTradingtem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_CHIPHIVANHANH_CongNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSoVAT", SumDoanhSoVAT));
                    cmd.Parameters.Add(new SqlParameter("SumDoanhSo", SumDoanhSo));
                    cmd.Parameters.Add(new SqlParameter("MinPostingDate", MinPostingDate));
                    cmd.Parameters.Add(new SqlParameter("MaxMinPostingDate", MaxMinPostingDate));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objSumTradingtem it = new objSumTradingtem
                        {
                            Name = reader["Name"].ToString(),
                            PhanTram = reader["PhanTram"].ToString(),
                            Total = reader["Total"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_CHIPHIVANHANH_CongNo");
                    return it_r;
                }
            }
        }
        public static List<ReportDeposit_TradingTemMienBN> GetList_TBL_BBM_ReportDeposit_TradingTem(string VendorNo, string KyCongNo, string Nam, string TypeMien, string TypeBy_NCC_BBM)
        {
            List<ReportDeposit_TradingTemMienBN> it_r = new List<ReportDeposit_TradingTemMienBN>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_TBL_BBM_ReportDeposit_TradingTem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyCongNo", KyCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
                    cmd.Parameters.Add(new SqlParameter("TypeMien", TypeMien));
                    cmd.Parameters.Add(new SqlParameter("TypeBy_NCC_BBM", TypeBy_NCC_BBM));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ReportDeposit_TradingTemMienBN it = new ReportDeposit_TradingTemMienBN
                        {
                            Tieude = reader["Tieude"].ToString(),
                            Total = reader["Total"].ToString(),
                            SoHD = reader["SoHD"].ToString(),
                            NgayHD = reader["NgayHD"].ToString(),
                            GhiChu = reader["GhiChu"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_TBL_BBM_ReportDeposit_TradingTem");
                    return it_r;
                }
            }
        }
        #endregion

        #region trandingTern
        public static List<obj_TRADTERM_LEADTIME_View> SP_TRADTERM_LIST_LeadTime_View(string ContractNo, string TypeTab)
        {
            List<obj_TRADTERM_LEADTIME_View> it_r = new List<obj_TRADTERM_LEADTIME_View>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LeadTime_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        obj_TRADTERM_LEADTIME_View it = new obj_TRADTERM_LEADTIME_View
                        {
                            Leadtimesx = reader["Leadtimesx"].ToString(),
                            ThoiGianKyHD = reader["ThoiGianKyHD"].ToString(),
                            ThanhToan = reader["ThanhToan"].ToString(),
                            DongCongVaHQXuat = reader["DongCongVaHQXuat"].ToString(),
                            DiBien = reader["DiBien"].ToString(),
                            ThuTucHQDauNhap = reader["ThuTucHQDauNhap"].ToString(),
                            TongLeadtime = reader["TongLeadtime"].ToString(),
                            TypeTab = reader["TypeTab"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LeadTime_View");
                    return it_r;
                }
            }
        }
        public static List<DoiTraHang_Show> SP_TRADTERM_LIST_DoiTraHang_Show(string ContractNo)
        {
            List<DoiTraHang_Show> it_r = new List<DoiTraHang_Show>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_DoiTraHang_Show", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DoiTraHang_Show it = new DoiTraHang_Show
                        {
                            TongSo = Convert.ToInt32(reader["TongSo"].ToString())
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_DoiTraHang_Show");
                    return it_r;
                }
            }
        }
        public static List<objPAYMENT> SP_TRADTERM_LIST_PAYMENT(string ContractNo)
        {
            List<objPAYMENT> it_r = new List<objPAYMENT>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_PAYMENT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo ", ContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objPAYMENT it = new objPAYMENT
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            TypeOrder = reader["TypeOrder"].ToString(),
                            PaymentPeriod = reader["PaymentPeriod"].ToString(),
                            OnDay = reader["OnDay"].ToString(),
                            AndDay = reader["AndDay"].ToString(),
                            ApplyFor = reader["ApplyFor"].ToString(),
                            Content = reader["Content"].ToString(),
                            TypeTab = reader["TypeTab"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_PAYMENT");
                    return it_r;
                }
            }
        }
        public static List<objLINEBONUS> SP_TRADTERM_LIST_LINE_BONUS(string ContractNo)
        {
            List<objLINEBONUS> it_r = new List<objLINEBONUS>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LINE_BONUS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo ", ContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objLINEBONUS it = new objLINEBONUS
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            BonusType = reader["BonusType"].ToString(),
                            SalesLevel = reader["SalesLevel"].ToString(),
                            SalesLevelDen = reader["SalesLevelDen"].ToString(),
                            SalesConditions = reader["SalesConditions"].ToString(),
                            DiscountPercent = reader["DiscountPercent"].ToString(),
                            DiscountAmountNoVAT = reader["DiscountAmountNoVAT"].ToString(),
                            Description = reader["Description"].ToString(),
                            DKDSTinhThuong = reader["DKDSTinhThuong"].ToString(),
                            TypeTab = reader["TypeTab"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LINE_BONUS");
                    return it_r;
                }
            }
        }
        public static List<objCombox_DoiTra> SP_TRADTERM_DoiTra()
        {
            List<objCombox_DoiTra> it_r = new List<objCombox_DoiTra>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_DoiTra", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox_DoiTra it = new objCombox_DoiTra
                        {
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_DoiTra");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_BARCODE(string ItemNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_BARCODE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("itemNo", ItemNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_BARCODE");
                    return it_r;
                }
            }
        }
        public static priceOffer Get_Price_HopDongThoaThuan_DeXuatDoiGia(string VendorNo, string MaHang)
        {
            priceOffer itr = new priceOffer();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_Price_HopDongThoaThuan_DeXuatDoiGia", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        priceOffer it = new priceOffer
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaTruocThayDoiPlus = reader["GiaTruocThayDoiPlus"].ToString()
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_Price_HopDongThoaThuan_DeXuatDoiGia");
                    return itr;
                }
            }
        }
        public static List<objCombox> Get_List_OfferPrice_All_NCC()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_List_OfferPrice_All_NCC", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_OfferPrice_All_NCC");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_Vendor_CongNO()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor_CongNo", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_Vendor_CongNo");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_Vendor_Purchase_Order()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_Purchase_Order", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getallVendor_Purchase_Order");
                    return it_r;
                }
            }
        }
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
        #endregion

        #region order
        public static List<objItem> GET_Detail_Order_All(string vendorNo, string purchaseorderNo)
        {
            List<objItem> it_r = new List<objItem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_get_PurchaseOrders_Detail_All", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Vendor", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("purchaseorderNo", purchaseorderNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objItem it = new objItem
                        {
                            NgayGiaoHang = reader["f_DeliveryDate"].ToString(),
                            MaHH = reader["Item No_"].ToString(),
                            TenHangHoa = reader["ItemName"].ToString(),
                            MaKho = reader["LocationCode"].ToString(),
                            DonGia = decimal.Parse(reader["DirectUnitCost"].ToString()),
                            SLDat = decimal.Parse(reader["Quantity"].ToString()),
                            SLGiao = decimal.Parse(reader["Qty_ to Receive"].ToString()),
                       
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GET_Detail_Order_All");
                    return it_r;
                }
            }
        }
        public static List<objItem> GET_Detail_Order(string vendorNo, string OrderNo, string itemNo, string itemName)
        {
            List<objItem> it_r = new List<objItem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_get_PurchaseOrders_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("Vendor", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("PurchaseOrderNo", OrderNo));
                    cmd.Parameters.Add(new SqlParameter("itemNo", itemNo));
                    cmd.Parameters.Add(new SqlParameter("itemName", itemName));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objItem it = new objItem
                        {
                            NgayGiaoHang = reader["f_DeliveryDate"].ToString(),
                            MaHH = reader["Item No_"].ToString(),
                            TenHangHoa = reader["ItemName"].ToString(),
                            MaKho = reader["LocationCode"].ToString(),
                            DonGia = decimal.Parse(reader["DirectUnitCost"].ToString()),
                            SLDat = decimal.Parse(reader["Quantity"].ToString()),
                            SLGiao = decimal.Parse(reader["Qty_ to Receive"].ToString()),
                            lineDiscout = reader["lineDiscout"].ToString(),
                            ThanhTienTruVAT = reader["ThanhTienTruVAT"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GET_Detail_Order");
                    return it_r;
                }
            }
        }
        public static bool UpdatePurchaseOrder(string Url, string VendorID, string DocumentNo, string locationCode, string ItemNo, string LineNo, string QtyToReceive, DateTime DeliveryDate, string ExpectedReceiptTime, string Note, string SoLo, string NgaySanXuat, string NgayHetHan)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdatePurchaseOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("VendorID", VendorID));
                    cmd.Parameters.Add(new SqlParameter("DocumentNo", DocumentNo));
                    cmd.Parameters.Add(new SqlParameter("LocationCode", locationCode));
                    cmd.Parameters.Add(new SqlParameter("ItemNo", ItemNo));
                    cmd.Parameters.Add(new SqlParameter("LineNo", LineNo));
                    if (ExpectedReceiptTime.Length > 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("DeliveryDate", DeliveryDate.Date.Add(TimeSpan.Parse(ExpectedReceiptTime))));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DeliveryDate", DeliveryDate.Date.Add(TimeSpan.Parse("00:00"))));
                    }
                    cmd.Parameters.Add(new SqlParameter("QtytoReceive", int.Parse(QtyToReceive)));
                    cmd.Parameters.Add(new SqlParameter("Note", Note));

                    cmd.Parameters.Add(new SqlParameter("SoLo", SoLo));
                    if (String.IsNullOrWhiteSpace(NgaySanXuat))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaySanXuat", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaySanXuat", DateTime.Parse(NgaySanXuat)));
                    }
                    if (String.IsNullOrWhiteSpace(NgayHetHan))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHetHan", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHetHan", DateTime.Parse(NgayHetHan)));
                    }


                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "UpdatePurchaseOrder");
                    return false;
                }
            }
        }
        public static int CheckIfPoEditable(string poNo)
        {
            int rt = 0;
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_checkIfPoEditable", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("poNo", poNo));

                    var reader = cmd.ExecuteScalar();
                    con.Close();

                    return int.Parse(reader.ToString());
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CheckIfPoEditable");
                    return rt;
                }
            }
        }
        public static bool sp_Vendor_Update_PurchaseOrder(string VendorID, string DocumentNo, string locationCode, string ItemNo, string LineNo, decimal PRQtty, DateTime EReceiptDate)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Vendor_Update_PurchaseOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("VendorID", VendorID));
                    cmd.Parameters.Add(new SqlParameter("DocumentNo", DocumentNo));
                    cmd.Parameters.Add(new SqlParameter("LocationCode", locationCode));
                    cmd.Parameters.Add(new SqlParameter("ItemNo", ItemNo));
                    cmd.Parameters.Add(new SqlParameter("LineNo", LineNo));
                    cmd.Parameters.Add(new SqlParameter("ExpectedReceiptDate", EReceiptDate));
                    cmd.Parameters.Add(new SqlParameter("QtytoReceive", PRQtty));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Vendor_Update_PurchaseOrder");
                    return false;
                }
            }
        }
        public static List<objPurchaseOrder> sp_get_detail_Purchase_Order_header(string vendorId, string orderId)
        {
            List<objPurchaseOrder> it_r = new List<objPurchaseOrder>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_get_detail_Purchase_Order_header", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("vendorId", vendorId));
                    cmd.Parameters.Add(new SqlParameter("orderId", orderId));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objPurchaseOrder it = new objPurchaseOrder
                        {
                            No_ = reader["No_"].ToString(),
                            OrderDate = reader["Order Date"].ToString(),
                            status = reader["Status"].ToString(),
                            locationCode = reader["Location Code"].ToString(),
                            PROrderNo = reader["PR_OrderNo"].ToString(),
                            StoreName = reader["StoreName"].ToString(),
                            VendorName = reader["VendorName"].ToString(),
                            NgayXacNhanDonHang = reader["NgayXacNhanDonHang"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_get_detail_Purchase_Order_header");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBM_ShowTrangThai_TraLaiKhoHang(string Vendor)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_ShowTrangThai_TraLaiKhoHang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000000;
                    cmd.Parameters.Add(new SqlParameter("Vendor", Vendor));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Tong"].ToString(),
                            Name = reader["Tong"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ShowTrangThai_TraLaiKhoHang");
                    return it_r;
                }
            }
        }
        public static bool TraLaiKhoHang_Count_Save(string Vendor)
        {
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_ShowTrangThai_TraLaiKhoHang_Count_Save", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Vendor", Vendor));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_CancelPurchaseOrder");
                    return false;
                }
            }
        }

        public static bool sp_CancelPurchaseOrder(string documentNo, string noteCancel)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Vendor_Cancel_PurchaseOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("DocumentNo", documentNo));
                    cmd.Parameters.Add(new SqlParameter("NoteCancel", noteCancel));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_CancelPurchaseOrder");
                    return false;
                }
            }
        }
        public static DataTable sp_GetDetailOrder(string Vendor, string PurchaseOrderNo, string itemNo, string itemName)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_get_PurchaseOrders_Detail_V1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    //cmd.Parameters.Add(new SqlParameter("dateFill", dateFill));

                    cmd.Parameters.Add(new SqlParameter("Vendor", Vendor));
                    cmd.Parameters.Add(new SqlParameter("PurchaseOrderNo", PurchaseOrderNo));
                    cmd.Parameters.Add(new SqlParameter("itemNo", itemNo));
                    cmd.Parameters.Add(new SqlParameter("itemName", itemName));

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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetDetailOrder");
                return ds.Tables[0];
            }
        }
        public static DataTable sp_GetListOrder(string Vendor, string Region, string City, string Status, string Store, string PurchaseOrderNo, string OrderDate)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_get_PurchaseOrders_Header", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300000;
                    //cmd.Parameters.Add(new SqlParameter("dateFill", dateFill));

                    cmd.Parameters.Add(new SqlParameter("Vendor", Vendor));
                    cmd.Parameters.Add(new SqlParameter("Region", Region));
                    cmd.Parameters.Add(new SqlParameter("City", City));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("Store", Store));
                    cmd.Parameters.Add(new SqlParameter("PurchaseOrderNo", PurchaseOrderNo));
                    cmd.Parameters.Add(new SqlParameter("OrderDate", OrderDate));
                    //if (OrderDate == null || OrderDate == "")
                    //{[BBM_SPACEMAN]
                    //    cmd.Parameters.Add(new SqlParameter("OrderDate", OrderDate));
                    //}
                    //else
                    //{
                    //    DateTime tmp;
                    //    DateTime.TryParse(OrderDate, out tmp);
                    //    cmd.Parameters.Add(new SqlParameter("OrderDate", tmp.ToString(Constants.SQLDateFormat)));
                    //}
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListOrder");
                return ds.Tables[0];
            }
        }
        public static List<objCombox> sp_BBM_MP_VendorTool_getStoreLocation()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_getStoreLocation", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_getStoreLocation");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_TinhThanh_MD_Sub_get(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_TinhThanh_MD_Sub_get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_TinhThanh_MD_Sub_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_BBM_MP_VendorTool_getKho()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_getKho_DonHang", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_getKho");
                    return it_r;
                }
            }
        }
        #endregion

        #region Vendor
        public static List<typeItem> sp_BBM_MP_VendorTool_UoMERPType_get()
        {
            List<typeItem> it_r = new List<typeItem>();

            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_UoMERPType_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        typeItem it = new typeItem
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_UoMERPType_get");
                    return it_r;
                }
            }
        }
        #region VendorInfo
        public static List<VendorInfo> sp_BBM_MP_VendorTool_VendorInfo_get_MaNCC(string Lang, string MaNCC)
        {
            List<VendorInfo> it_r = new List<VendorInfo>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorInfo_get_MaNCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        VendorInfo it = new VendorInfo
                        {
                            id = reader["id"].ToString(),
                            businessType = reader["businessType"].ToString(),
                            firmName = reader["firmName"].ToString(),
                            Address = reader["Address"].ToString(),
                            phoneNo = reader["phoneNo"].ToString(),
                            website = reader["website"].ToString(),
                            email = reader["email"].ToString(),
                            facebook = reader["facebook"].ToString(),
                            industryType = reader["industryType"].ToString(),
                            registrationBusiness = reader["registrationBusiness"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            bankAccount = reader["bankAccount"].ToString(),
                            atBank = reader["atBank"].ToString(),
                            E_Invoice = reader["E_Invoice"].ToString(),
                            ERP_Name = reader["ERP_Name"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            Vendor_No = reader["Vendor_No"].ToString(),
                            VendorContact_ID = reader["VendorContact_ID"].ToString(),
                            businessName = reader["businessName"].ToString(),
                            industryName = reader["industryName"].ToString(),
                            bankName = reader["bankName"].ToString(),
                            ERP_Name_SS = reader["ERP_Name_SS"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorInfo_get");
                    return it_r;
                }
            }
        }
        public static List<VendorInfo> sp_BBM_MP_VendorTool_VendorInfo_get(string Lang, int type, string registrationTax)
        {
            List<VendorInfo> it_r = new List<VendorInfo>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorInfo_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        //var sub_ERP = reader["ERP_Name"].ToString().Split('|');

                        VendorInfo it = new VendorInfo
                        {
                            id = reader["id"].ToString(),
                            businessType = reader["businessType"].ToString(),
                            firmName = reader["firmName"].ToString(),
                            Address = reader["Address"].ToString(),
                            phoneNo = reader["phoneNo"].ToString(),
                            website = reader["website"].ToString(),
                            email = reader["email"].ToString(),
                            facebook = reader["facebook"].ToString(),
                            industryType = reader["industryType"].ToString(),
                            registrationBusiness = reader["registrationBusiness"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            bankAccount = reader["bankAccount"].ToString(),
                            atBank = reader["atBank"].ToString(),
                            E_Invoice = reader["E_Invoice"].ToString(),
                            ERP_Name = reader["ERP_Name"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            Vendor_No = reader["Vendor_No"].ToString(),
                            VendorContact_ID = reader["VendorContact_ID"].ToString(),
                            businessName = reader["businessName"].ToString(),
                            industryName = reader["industryName"].ToString(),
                            bankName = reader["bankName"].ToString(),
                            ERP_Name_SS = reader["ERP_Name_SS"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorInfo_get");
                    return it_r;
                }
            }
        }
        public static bool sp_BBM_MP_VendorTool_VendorInfo_add(VendorInfo it)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorInfo_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("businessType", it.businessType));
                    cmd.Parameters.Add(new SqlParameter("firmName", it.firmName));
                    cmd.Parameters.Add(new SqlParameter("Address", it.Address != null ? it.Address : ""));
                    cmd.Parameters.Add(new SqlParameter("phoneNo", it.phoneNo != null ? it.phoneNo : ""));
                    cmd.Parameters.Add(new SqlParameter("website", it.website != null ? it.website : ""));
                    cmd.Parameters.Add(new SqlParameter("email", it.email != null ? it.email : ""));
                    cmd.Parameters.Add(new SqlParameter("facebook", it.facebook != null ? it.facebook : ""));
                    cmd.Parameters.Add(new SqlParameter("industryType", it.industryType));
                    cmd.Parameters.Add(new SqlParameter("registrationBusiness", it.registrationBusiness != null ? it.registrationBusiness : ""));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", it.registrationTax));
                    cmd.Parameters.Add(new SqlParameter("bankAccount", it.bankAccount != null ? it.bankAccount : ""));
                    cmd.Parameters.Add(new SqlParameter("atBank", it.atBank != null ? it.atBank : ""));
                    cmd.Parameters.Add(new SqlParameter("E_Invoice", it.E_Invoice));
                    cmd.Parameters.Add(new SqlParameter("ERP_Name", it.ERP_Name != null ? it.ERP_Name : ""));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorInfo_add");
                    return false;
                }
            }
        }
        public static bool sp_BBM_MP_VendorTool_VendorInfo_Update(VendorInfo it, string id, string BBM_Code)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorInfo_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("id", id));
                    cmd.Parameters.Add(new SqlParameter("BBM_Code", BBM_Code));
                    cmd.Parameters.Add(new SqlParameter("businessType", it.businessType != null ? it.businessType : ""));
                    cmd.Parameters.Add(new SqlParameter("firmName", it.firmName != null ? it.firmName : ""));
                    cmd.Parameters.Add(new SqlParameter("Address", it.Address != null ? it.Address : ""));
                    cmd.Parameters.Add(new SqlParameter("phoneNo", it.phoneNo != null ? it.phoneNo : ""));
                    cmd.Parameters.Add(new SqlParameter("website", it.website != null ? it.website : ""));
                    cmd.Parameters.Add(new SqlParameter("email", it.email != null ? it.email : ""));
                    cmd.Parameters.Add(new SqlParameter("facebook", it.facebook != null ? it.facebook : ""));
                    cmd.Parameters.Add(new SqlParameter("industryType", it.industryType != null ? it.industryType : ""));
                    cmd.Parameters.Add(new SqlParameter("registrationBusiness", it.registrationBusiness != null ? it.registrationBusiness : ""));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", it.registrationTax));
                    cmd.Parameters.Add(new SqlParameter("bankAccount", it.bankAccount != null ? it.bankAccount : ""));
                    cmd.Parameters.Add(new SqlParameter("atBank", it.atBank != null ? it.atBank : ""));
                    cmd.Parameters.Add(new SqlParameter("E_Invoice", it.E_Invoice != null ? it.E_Invoice : ""));
                    cmd.Parameters.Add(new SqlParameter("ERP_Name", it.ERP_Name != null ? it.ERP_Name : ""));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorInfo_Update");
                    return false;
                }
            }
        }
        public static bool sp_BBM_MP_VendorTool_VendorInfo_edit(VendorInfo it)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorInfo_edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("businessType", it.businessType));
                    cmd.Parameters.Add(new SqlParameter("firmName", it.firmName));
                    cmd.Parameters.Add(new SqlParameter("Address", it.Address != null ? it.Address : ""));
                    cmd.Parameters.Add(new SqlParameter("phoneNo", it.phoneNo != null ? it.phoneNo : ""));
                    cmd.Parameters.Add(new SqlParameter("website", it.website != null ? it.website : ""));
                    cmd.Parameters.Add(new SqlParameter("email", it.email != null ? it.email : ""));
                    cmd.Parameters.Add(new SqlParameter("facebook", it.facebook != null ? it.facebook : ""));
                    cmd.Parameters.Add(new SqlParameter("industryType", it.industryType));
                    cmd.Parameters.Add(new SqlParameter("registrationBusiness", it.registrationBusiness != null ? it.registrationBusiness : ""));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", it.registrationTax));
                    cmd.Parameters.Add(new SqlParameter("bankAccount", it.bankAccount != null ? it.bankAccount : ""));
                    cmd.Parameters.Add(new SqlParameter("atBank", it.atBank != null ? it.atBank : ""));
                    cmd.Parameters.Add(new SqlParameter("E_Invoice", it.E_Invoice));
                    cmd.Parameters.Add(new SqlParameter("ERP_Name", it.ERP_Name != null ? it.ERP_Name : ""));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorInfo_edit");
                    return false;
                }
            }
        }
        #endregion

        #region VendorCapability
        public static List<VendorCapability> sp_BBM_MP_VendorTool_VendorCapability_get(string Lang, string registrationTax)
        {
            List<VendorCapability> it_r = new List<VendorCapability>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorCapability_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //var sub_coverageMarket = reader["coverageMarket"].ToString().Split('|');

                        //var sub_competencyCore = reader["competencyCore"].ToString().Split('|');

                        VendorCapability it = new VendorCapability
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            yearActive = reader["yearActive"].ToString(),
                            yearActiveName = reader["yearActiveName"].ToString(),
                            employeesScale = reader["employeesScale"].ToString(),
                            coverageMarket = reader["coverageMarket"].ToString(),
                            coverageMarket_Name = reader["coverageMarket_Name"].ToString(),
                            previousRevenue = reader["previousRevenue"].ToString(),
                            competencyCore = reader["competencyCore"].ToString(),
                            competencyCore_Name = reader["competencyCore_Name"].ToString(),
                            customerKey = reader["customerKey"].ToString(),
                            warehouseAcreage = reader["warehouseAcreage"].ToString(),
                            truckQuantity = int.Parse(reader["truckQuantity"].ToString()),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            previousRevenue_Name = reader["previousRevenue_Name"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorCapability_get");
                    return it_r;
                }
            }

        }
        public static List<VendorCapability> sp_BBM_MP_VendorTool_VendorCapability_get_MaNCC(string Lang, string MaNCC)
        {
            List<VendorCapability> it_r = new List<VendorCapability>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorCapability_get_MaNCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        VendorCapability it = new VendorCapability
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            yearActive = reader["yearActive"].ToString(),
                            yearActiveName = reader["yearActiveName"].ToString(),
                            employeesScale = reader["employeesScale"].ToString(),
                            coverageMarket = reader["coverageMarket"].ToString(),
                            coverageMarket_Name = reader["coverageMarket_Name"].ToString(),
                            previousRevenue = reader["previousRevenue"].ToString(),
                            competencyCore = reader["competencyCore"].ToString(),
                            competencyCore_Name = reader["competencyCore_Name"].ToString(),
                            customerKey = reader["customerKey"].ToString(),
                            warehouseAcreage = reader["warehouseAcreage"].ToString(),
                            truckQuantity = int.Parse(reader["truckQuantity"].ToString()),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            previousRevenue_Name = reader["previousRevenue_Name"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorCapability_get_MaNCC");
                    return it_r;
                }
            }

        }
        public static bool sp_BBM_MP_VendorTool_VendorCapability_add(VendorCapability it)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorCapability_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("registrationTax", it.registrationTax));
                    cmd.Parameters.Add(new SqlParameter("yearActive", it.yearActive));
                    cmd.Parameters.Add(new SqlParameter("employeesScale", it.employeesScale.Replace(",", "") != null ? it.employeesScale.Replace(",", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("coverageMarket", it.coverageMarket != null ? it.coverageMarket : ""));
                    cmd.Parameters.Add(new SqlParameter("previousRevenue", it.previousRevenue));
                    cmd.Parameters.Add(new SqlParameter("competencyCore", it.competencyCore != null ? it.competencyCore : ""));
                    cmd.Parameters.Add(new SqlParameter("customerKey", it.customerKey != null ? it.customerKey : ""));
                    cmd.Parameters.Add(new SqlParameter("warehouseAcreage", Decimal.Parse(it.warehouseAcreage.Replace(",", ""), NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("fr-FR"))));
                    cmd.Parameters.Add(new SqlParameter("truckQuantity", it.truckQuantity.ToString().Replace(",", "")));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorCapability_add");
                    return false;
                }
            }
        }
        public static bool sp_BBM_MP_VendorTool_VendorCapability_edit(VendorCapability it)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorCapability_edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("registrationTax", it.registrationTax));
                    cmd.Parameters.Add(new SqlParameter("yearActive", it.yearActive));
                    cmd.Parameters.Add(new SqlParameter("employeesScale", it.employeesScale.Replace(",", "") != null ? it.employeesScale.Replace(",", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("coverageMarket", it.coverageMarket != null ? it.coverageMarket : ""));
                    cmd.Parameters.Add(new SqlParameter("previousRevenue", it.previousRevenue));
                    cmd.Parameters.Add(new SqlParameter("competencyCore", it.competencyCore != null ? it.competencyCore : ""));
                    cmd.Parameters.Add(new SqlParameter("customerKey", it.customerKey != null ? it.customerKey : ""));
                    cmd.Parameters.Add(new SqlParameter("warehouseAcreage", Decimal.Parse(it.warehouseAcreage.Replace(",", ""), NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("fr-FR"))));
                    cmd.Parameters.Add(new SqlParameter("truckQuantity", it.truckQuantity.ToString().Replace(",", "")));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorCapability_edit");
                    return false;
                }
            }
        }
        public static bool sp_BBM_MP_VendorTool_VendorCapability_Update(VendorCapability it, string id, string BBM_Code)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorCapability_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("id", id));
                    cmd.Parameters.Add(new SqlParameter("BBM_Code", BBM_Code));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", it.registrationTax));
                    cmd.Parameters.Add(new SqlParameter("yearActive", it.yearActive));
                    cmd.Parameters.Add(new SqlParameter("employeesScale", it.employeesScale.Replace(",", "") != null ? it.employeesScale.Replace(",", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("coverageMarket", it.coverageMarket != null ? it.coverageMarket : ""));
                    cmd.Parameters.Add(new SqlParameter("previousRevenue", it.previousRevenue != null ? it.previousRevenue : ""));
                    cmd.Parameters.Add(new SqlParameter("competencyCore", it.competencyCore != null ? it.competencyCore : ""));
                    cmd.Parameters.Add(new SqlParameter("customerKey", it.customerKey != null ? it.customerKey : ""));
                    cmd.Parameters.Add(new SqlParameter("warehouseAcreage", Decimal.Parse(it.warehouseAcreage.Replace(",", ""), NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("fr-FR"))));
                    cmd.Parameters.Add(new SqlParameter("truckQuantity", it.truckQuantity.ToString().Replace(",", "")));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorCapability_Update");
                    return false;
                }
            }
        }
        #endregion

        #region VendorContact
        public static List<VendorContact> sp_BBM_MP_VendorTool_VendorContact_get_login(string Lang, string BBM_Code)
        {
            List<VendorContact> it_r = new List<VendorContact>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorContact_get_Login", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));
                    cmd.Parameters.Add(new SqlParameter("BBM_Code", BBM_Code));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        VendorContact it = new VendorContact
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            BBM_Code = reader["BBM_Code"].ToString(),
                            representativeName = reader["representativeName"].ToString(),
                            representativeEmail = reader["representativeEmail"].ToString(),
                            representativePosition = reader["representativePosition"].ToString(),
                            representativePhone = reader["representativePhone"].ToString(),
                            contactName = reader["contactName"].ToString(),
                            contactEmail = reader["contactEmail"].ToString(),
                            contactPosition = reader["contactPosition"].ToString(),
                            contactPhone = reader["contactPhone"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            contactPosition_Name = reader["contactPosition_Name"].ToString(),
                            representativePosition_Name = reader["representativePosition_Name"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorContact_get");
                    return it_r;
                }
            }

        }
        public static List<VendorContact> sp_BBM_MP_VendorTool_VendorContact_get(string Lang, int type, string registrationTax, string BBM_Code)
        {
            List<VendorContact> it_r = new List<VendorContact>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorContact_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    cmd.Parameters.Add(new SqlParameter("BBM_Code", BBM_Code));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        VendorContact it = new VendorContact
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            BBM_Code = reader["BBM_Code"].ToString(),
                            representativeName = reader["representativeName"].ToString(),
                            representativeEmail = reader["representativeEmail"].ToString(),
                            representativePosition = reader["representativePosition"].ToString(),
                            representativePhone = reader["representativePhone"].ToString(),
                            contactName = reader["contactName"].ToString(),
                            contactEmail = reader["contactEmail"].ToString(),
                            contactPosition = reader["contactPosition"].ToString(),
                            contactPhone = reader["contactPhone"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            contactPosition_Name = reader["contactPosition_Name"].ToString(),
                            representativePosition_Name = reader["representativePosition_Name"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorContact_get");
                    return it_r;
                }
            }

        }
        public static user_Item BBM_MP_VendorTool_Change_pass(user_Item it)
        {
            user_Item itr = new user_Item();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("BBM_MP_VendorTool_Change_pass", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userName", it.userName));
                    cmd.Parameters.Add(new SqlParameter("password", it.password));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user_Item su = new user_Item
                        {
                            userName = reader["userName"].ToString(),
                            password = reader["password"].ToString(),
                        };
                        itr = su;
                    }
                    con.Close();
                    return itr;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_MP_VendorTool_Change_pass");
                return itr;
            }
        }
        public static user_Item BBM_MP_VendorTool_Change_pass_PhongBan(user_Item it)
        {
            user_Item itr = new user_Item();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("BBM_MP_VendorTool_Change_pass_PhongBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userName", it.userName));
                    cmd.Parameters.Add(new SqlParameter("password", it.password));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user_Item su = new user_Item
                        {
                            userName = reader["userName"].ToString(),
                            password = reader["password"].ToString(),
                        };
                        itr = su;
                    }
                    con.Close();
                    return itr;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_MP_VendorTool_Change_pass_PhongBan");
                return itr;
            }
        }


        public static bool Log_ResetPass_Vendor_add(string MaNCC, string Email, string newpass, string chuoi, string Type)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Log_ResetPass_Vendor_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("Email", Email));
                    cmd.Parameters.Add(new SqlParameter("newpass", newpass));
                    cmd.Parameters.Add(new SqlParameter("chuoi", chuoi));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Log_ResetPass_Vendor_add");
                    return false;
                }
            }
        }
        public static List<objCombox> sp_BBM_MP_VendorTool_VendorEmail_get(string BBM_Code)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorEmail_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("BBM_Code", BBM_Code));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Name = reader["Code"].ToString(),
                            Code = reader["Type"].ToString(),

                            //Name = "dungnv@bibomart.net",
                            //Code = "1",

                            //Code = "dungnv@bibomart.net",
                            // Code = "vanhth@bibomart.net",
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorEmail_get");
                    return it_r;
                }
            }

        }
        public static List<VendorContact> sp_BBM_MP_VendorTool_VendorContact_get_MaNCC(string Lang, string MaNCC)
        {
            List<VendorContact> it_r = new List<VendorContact>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorContact_get_MaNCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        VendorContact it = new VendorContact
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            BBM_Code = reader["BBM_Code"].ToString(),
                            representativeName = reader["representativeName"].ToString(),
                            representativeEmail = reader["representativeEmail"].ToString(),
                            representativePosition = reader["representativePosition"].ToString(),
                            representativePhone = reader["representativePhone"].ToString(),
                            contactName = reader["contactName"].ToString(),
                            contactEmail = reader["contactEmail"].ToString(),
                            contactPosition = reader["contactPosition"].ToString(),
                            contactPhone = reader["contactPhone"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            contactPosition_Name = reader["contactPosition_Name"].ToString(),
                            representativePosition_Name = reader["representativePosition_Name"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorContact_get_MaNCC");
                    return it_r;
                }
            }

        }
        public static string sp_BBM_MP_VendorTool_VendorContact_add(VendorContact it, string uid)
        {
            string rt = "";
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorContact_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("id", int.Parse(it.id)));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", it.registrationTax));
                    cmd.Parameters.Add(new SqlParameter("BBM_Code", it.BBM_Code != null ? it.BBM_Code : ""));

                    cmd.Parameters.Add(new SqlParameter("representativeName", it.representativeName));
                    cmd.Parameters.Add(new SqlParameter("representativeEmail", it.representativeEmail));
                    cmd.Parameters.Add(new SqlParameter("representativePosition", it.representativePosition));
                    cmd.Parameters.Add(new SqlParameter("representativePhone", it.representativePhone));

                    cmd.Parameters.Add(new SqlParameter("contactName", it.contactName));
                    cmd.Parameters.Add(new SqlParameter("contactEmail", it.contactEmail));
                    cmd.Parameters.Add(new SqlParameter("contactPosition", it.contactPosition));
                    cmd.Parameters.Add(new SqlParameter("contactPhone", it.contactPhone));


                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        rt = reader["id"].ToString();
                    }
                    con.Close();

                    return rt;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorContact_add");
                    return rt;
                }
            }
        }
        public static string sp_BBM_MP_VendorTool_VendorContact_edit(VendorContact it, string uid)
        {
            string rt = "";
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorContact_edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("id", int.Parse(it.id)));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", it.registrationTax));
                    cmd.Parameters.Add(new SqlParameter("BBM_Code", it.BBM_Code != null ? it.BBM_Code : ""));

                    cmd.Parameters.Add(new SqlParameter("representativeName", it.representativeName));
                    cmd.Parameters.Add(new SqlParameter("representativeEmail", it.representativeEmail));
                    cmd.Parameters.Add(new SqlParameter("representativePosition", it.representativePosition));
                    cmd.Parameters.Add(new SqlParameter("representativePhone", it.representativePhone));

                    cmd.Parameters.Add(new SqlParameter("contactName", it.contactName));
                    cmd.Parameters.Add(new SqlParameter("contactEmail", it.contactEmail));
                    cmd.Parameters.Add(new SqlParameter("contactPosition", it.contactPosition));
                    cmd.Parameters.Add(new SqlParameter("contactPhone", it.contactPhone));



                    var reader = cmd.ExecuteScalar();


                    con.Close();

                    return reader.ToString();
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorContact_edit");
                    return rt;
                }
            }
        }
        public static string sp_BBM_MP_VendorTool_VendorContact_Update(VendorContact it, string uid)
        {
            string rt = "";
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_VendorContact_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("id", int.Parse(it.id)));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", it.registrationTax != null ? it.registrationTax : ""));
                    cmd.Parameters.Add(new SqlParameter("BBM_Code", it.BBM_Code != null ? it.BBM_Code : ""));

                    cmd.Parameters.Add(new SqlParameter("representativeName", it.representativeName != null ? it.representativeName : ""));
                    cmd.Parameters.Add(new SqlParameter("representativeEmail", it.representativeEmail != null ? it.representativeEmail : ""));
                    cmd.Parameters.Add(new SqlParameter("representativePosition", it.representativePosition != null ? it.representativePosition : ""));
                    cmd.Parameters.Add(new SqlParameter("representativePhone", it.representativePhone != null ? it.representativePhone : ""));

                    cmd.Parameters.Add(new SqlParameter("contactName", it.contactName != null ? it.contactName : ""));
                    cmd.Parameters.Add(new SqlParameter("contactEmail", it.contactEmail != null ? it.contactEmail : ""));
                    cmd.Parameters.Add(new SqlParameter("contactPosition", it.contactPosition != null ? it.contactPosition : ""));
                    cmd.Parameters.Add(new SqlParameter("contactPhone", it.contactPhone != null ? it.contactPhone : ""));
                    var reader = cmd.ExecuteScalar();
                    con.Close();

                    return reader.ToString();
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_VendorContact_Update");
                    return rt;
                }
            }
        }
        #endregion

        #endregion

        #region Product
        public static List<objCombox> SP_ProductGET_Vendor(string ID)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ProductGET_Vendor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ProductGET_Vendor");
                    return it_r;
                }
            }
        }
        //Request.Cookies["culture"].Value, "0", VendorContact_ID
        public static DataTable GetListPro(string Status, string Name, string Lang, string MaNCC)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ProductInfo_get__New_MNCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("Name", Name));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListPro");
                return ds.Tables[0];
            }
        }
        public static bool SetStatus_pro(string ID, string HanhDong)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SetStatus_pro", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SetStatus_pro");
                    return false;
                }
            }
        }
        public static List<ProductInfo> sp_BBM_MP_VendorTool_ProductInfo_Detail(string Lang, string id)
        {
            List<ProductInfo> it_r = new List<ProductInfo>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ProductInfo_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("id", id));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductInfo it = new ProductInfo
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            BBM_Code = reader["BBM_Code"].ToString(),
                            divisionCode = reader["divisionCode"].ToString(),
                            categoryCode = reader["categoryCode"].ToString(),
                            groupCode = reader["groupCode"].ToString(),
                            functionCode = reader["functionCode"].ToString(),
                            name = reader["name"].ToString(),
                            brand = reader["brand"].ToString(),
                            manufactureCode = reader["manufactureCode"].ToString(),
                            UoM = reader["UoM"].ToString(),
                            weight = reader["weight"].ToString(),
                            dimensionLength = reader["dimensionLength"].ToString(),
                            dimensionWidth = reader["dimensionWidth"].ToString(),
                            dimensionHeight = reader["dimensionHeight"].ToString(),
                            QtyBox = reader["QtyBox"].ToString(),
                            boxLength = reader["boxLength"].ToString(),
                            boxWidth = reader["boxWidth"].ToString(),
                            boxHeight = reader["boxHeight"].ToString(),
                            imgLink = reader["imgLink"].ToString(),
                            url = reader["url"].ToString(),
                            barcode = reader["barcode"].ToString(),
                            priceRetail = reader["priceRetail"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            priceCost = reader["priceCost"].ToString(),
                            faceQty = reader["faceQty"].ToString(),
                            MOQ = reader["MOQ"].ToString(),
                            realityInventories = reader["realityInventories"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            statusAppr = reader["statusAppr"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            description = reader["description"].ToString(),
                            VendorContact_ID = reader["VendorContact_ID"].ToString(),
                            categoryName = reader["categoryName"].ToString(),
                            divisionName = reader["divisionName"].ToString(),
                            functionName = reader["functionName"].ToString(),
                            groupName = reader["groupName"].ToString(),
                            UoM_Name = reader["UoM_Name"].ToString(),
                            manufactureName = reader["manufactureName"].ToString(),
                            MaNCC = reader["MaNCC"].ToString(),

                            GiaBanNiemYet = reader["GiaBanNiemYet"].ToString(),
                            Conten = reader["Conten"].ToString(),
                            GenProPostingGroupCode = reader["GenProPostingGroupCode"].ToString(),
                            SeasonCode = reader["SeasonCode"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_ProductInfo_get");
                    return it_r;
                }
            }

        }
        public static List<ProductInfo> sp_BBM_MP_VendorTool_ProductInfo_get(string Lang, int type, string registrationTax)
        {
            List<ProductInfo> it_r = new List<ProductInfo>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ProductInfo_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductInfo it = new ProductInfo
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            BBM_Code = reader["BBM_Code"].ToString(),
                            divisionCode = reader["divisionCode"].ToString(),
                            categoryCode = reader["categoryCode"].ToString(),
                            groupCode = reader["groupCode"].ToString(),
                            functionCode = reader["functionCode"].ToString(),
                            name = reader["name"].ToString(),
                            brand = reader["brand"].ToString(),
                            manufactureCode = reader["manufactureCode"].ToString(),
                            UoM = reader["UoM"].ToString(),
                            weight = reader["weight"].ToString(),
                            dimensionLength = reader["dimensionLength"].ToString(),
                            dimensionWidth = reader["dimensionWidth"].ToString(),
                            dimensionHeight = reader["dimensionHeight"].ToString(),
                            QtyBox = reader["QtyBox"].ToString(),
                            boxLength = reader["boxLength"].ToString(),
                            boxWidth = reader["boxWidth"].ToString(),
                            boxHeight = reader["boxHeight"].ToString(),
                            imgLink = reader["imgLink"].ToString(),
                            url = reader["url"].ToString(),
                            barcode = reader["barcode"].ToString(),
                            priceRetail = reader["priceRetail"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            priceCost = reader["priceCost"].ToString(),
                            faceQty = reader["faceQty"].ToString(),
                            MOQ = reader["MOQ"].ToString(),
                            realityInventories = reader["realityInventories"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            statusAppr = reader["statusAppr"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            description = reader["description"].ToString(),
                            VendorContact_ID = reader["VendorContact_ID"].ToString(),
                            categoryName = reader["categoryName"].ToString(),
                            divisionName = reader["divisionName"].ToString(),
                            functionName = reader["functionName"].ToString(),
                            groupName = reader["groupName"].ToString(),
                            UoM_Name = reader["UoM_Name"].ToString(),
                            manufactureName = reader["manufactureName"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_ProductInfo_get");
                    return it_r;
                }
            }

        }
        public static List<ProductInfo> sp_BBM_MP_VendorTool_ProductInfo_get_Detail(string Lang, int type, string productId)
        {
            List<ProductInfo> it_r = new List<ProductInfo>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ProductInfo_get_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));
                    cmd.Parameters.Add(new SqlParameter("productId", productId));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductInfo it = new ProductInfo
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            BBM_Code = reader["BBM_Code"].ToString(),
                            divisionCode = reader["divisionCode"].ToString(),
                            categoryCode = reader["categoryCode"].ToString(),
                            groupCode = reader["groupCode"].ToString(),
                            functionCode = reader["functionCode"].ToString(),
                            name = reader["name"].ToString(),
                            brand = reader["brand"].ToString(),
                            manufactureCode = reader["manufactureCode"].ToString(),
                            UoM = reader["UoM"].ToString(),
                            weight = reader["weight"].ToString(),
                            dimensionLength = reader["dimensionLength"].ToString(),
                            dimensionWidth = reader["dimensionWidth"].ToString(),
                            dimensionHeight = reader["dimensionHeight"].ToString(),
                            QtyBox = reader["QtyBox"].ToString(),
                            boxLength = reader["boxLength"].ToString(),
                            boxWidth = reader["boxWidth"].ToString(),
                            boxHeight = reader["boxHeight"].ToString(),
                            imgLink = reader["imgLink"].ToString(),
                            url = reader["url"].ToString(),
                            barcode = reader["barcode"].ToString(),
                            priceRetail = reader["priceRetail"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            priceCost = reader["priceCost"].ToString(),
                            faceQty = reader["faceQty"].ToString(),
                            MOQ = reader["MOQ"].ToString(),
                            realityInventories = reader["realityInventories"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            statusAppr = reader["statusAppr"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            description = reader["description"].ToString(),
                            VendorContact_ID = reader["VendorContact_ID"].ToString(),
                            categoryName = reader["categoryName"].ToString(),
                            divisionName = reader["divisionName"].ToString(),
                            functionName = reader["functionName"].ToString(),
                            groupName = reader["groupName"].ToString(),
                            UoM_Name = reader["UoM_Name"].ToString(),
                            manufactureName = reader["manufactureName"].ToString(),
                            MaNCC = reader["MaNCC"].ToString(),

                            GenProPostingGroupCode = reader["GenProPostingGroupCode"].ToString(),
                            SeasonCode = reader["SeasonCode"].ToString(),
                            Conten = reader["Conten"].ToString(),
                            GiaBanNiemYet = reader["GiaBanNiemYet"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_ProductInfo_get");
                    return it_r;
                }
            }

        }
        public static List<ProductInfo> sp_BBM_MP_VendorTool_ProductInfo_MaNCC_get(string Lang, string MaNCC)
        {
            List<ProductInfo> it_r = new List<ProductInfo>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ProductInfo_MaNCC_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductInfo it = new ProductInfo
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            BBM_Code = reader["BBM_Code"].ToString(),
                            divisionCode = reader["divisionCode"].ToString(),
                            categoryCode = reader["categoryCode"].ToString(),
                            groupCode = reader["groupCode"].ToString(),
                            functionCode = reader["functionCode"].ToString(),
                            name = reader["name"].ToString(),
                            brand = reader["brand"].ToString(),
                            manufactureCode = reader["manufactureCode"].ToString(),
                            UoM = reader["UoM"].ToString(),
                            weight = reader["weight"].ToString(),
                            dimensionLength = reader["dimensionLength"].ToString(),
                            dimensionWidth = reader["dimensionWidth"].ToString(),
                            dimensionHeight = reader["dimensionHeight"].ToString(),
                            QtyBox = reader["QtyBox"].ToString(),
                            boxLength = reader["boxLength"].ToString(),
                            boxWidth = reader["boxWidth"].ToString(),
                            boxHeight = reader["boxHeight"].ToString(),
                            imgLink = reader["imgLink"].ToString(),
                            url = reader["url"].ToString(),
                            barcode = reader["barcode"].ToString(),
                            priceRetail = reader["priceRetail"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            priceCost = reader["priceCost"].ToString(),
                            faceQty = reader["faceQty"].ToString(),
                            MOQ = reader["MOQ"].ToString(),
                            realityInventories = reader["realityInventories"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            statusAppr = reader["statusAppr"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            description = reader["description"].ToString(),
                            VendorContact_ID = reader["VendorContact_ID"].ToString(),
                            categoryName = reader["categoryName"].ToString(),
                            divisionName = reader["divisionName"].ToString(),
                            functionName = reader["functionName"].ToString(),
                            groupName = reader["groupName"].ToString(),
                            UoM_Name = reader["UoM_Name"].ToString(),
                            manufactureName = reader["manufactureName"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_ProductInfo_MaNCC_get");
                    return it_r;
                }
            }

        }
        //
        public static List<ChangeProductInfo> sp_BBM_MP_VendorTool_ProductInfo_getChange(string Lang, string uID)
        {
            List<ChangeProductInfo> it_r = new List<ChangeProductInfo>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ProductInfo_getChange", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.Add(new SqlParameter("type", type));
                    //cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));
                    cmd.Parameters.Add(new SqlParameter("UserID", uID));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ChangeProductInfo it = new ChangeProductInfo
                        {
                            ApproveID = int.Parse(reader["ApproveID"].ToString()),
                            ChangeType = reader["ChangeType"].ToString(),
                            VendorContactID = reader["VendorContactID"].ToString(),
                            VendorCode = reader["VendorCode"].ToString(),
                            VendorName = reader["VendorName"].ToString(),
                            BBM_Code = reader["BBM_Code"].ToString(),
                            ProductName = reader["ProductName"].ToString(),
                            Oldprice = reader["Oldprice"].ToString(),
                            NewPrice = reader["NewPrice"].ToString(),
                            Status = reader["Status"].ToString(),
                            StatusName = reader["StatusName"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_ProductInfo_get");
                    return it_r;
                }
            }

        }
        public static List<ProductInfo> sp_BBM_MP_VendorTool_ProductInfo_getapprove(string Lang, int type, string registrationTax)
        {
            List<ProductInfo> it_r = new List<ProductInfo>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ProductInfo_getapprove", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductInfo it = new ProductInfo
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            BBM_Code = reader["BBM_Code"].ToString(),
                            divisionCode = reader["divisionCode"].ToString(),
                            categoryCode = reader["categoryCode"].ToString(),
                            groupCode = reader["groupCode"].ToString(),
                            functionCode = reader["functionCode"].ToString(),
                            name = reader["name"].ToString(),
                            brand = reader["brand"].ToString(),
                            manufactureCode = reader["manufactureCode"].ToString(),
                            UoM = reader["UoM"].ToString(),
                            weight = reader["weight"].ToString(),
                            dimensionLength = reader["dimensionLength"].ToString(),
                            dimensionWidth = reader["dimensionWidth"].ToString(),
                            dimensionHeight = reader["dimensionHeight"].ToString(),
                            QtyBox = reader["QtyBox"].ToString(),
                            boxLength = reader["boxLength"].ToString(),
                            boxWidth = reader["boxWidth"].ToString(),
                            boxHeight = reader["boxHeight"].ToString(),
                            imgLink = reader["imgLink"].ToString(),
                            url = reader["url"].ToString(),
                            barcode = reader["barcode"].ToString(),
                            priceRetail = reader["priceRetail"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            priceCost = reader["priceCost"].ToString(),
                            faceQty = reader["faceQty"].ToString(),
                            MOQ = reader["MOQ"].ToString(),
                            realityInventories = reader["realityInventories"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            description = reader["description"].ToString(),
                            VendorContact_ID = reader["VendorContact_ID"].ToString(),
                            categoryName = reader["categoryName"].ToString(),
                            divisionName = reader["divisionName"].ToString(),
                            functionName = reader["functionName"].ToString(),
                            groupName = reader["groupName"].ToString(),
                            UoM_Name = reader["UoM_Name"].ToString(),
                            manufactureName = reader["manufactureName"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_ProductInfo_get");
                    return it_r;
                }
            }

        }
        public static bool sp_BBM_MP_VendorTool_ProductInfo_add(ProductInfo it, String MaNCC, string uid, string registrationTax)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ProductInfo_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    // cmd.Parameters.Add(new SqlParameter("BBM_Code", it.BBM_Code != null ? it.BBM_Code : "")); là mã sản phẩm sẽ có sau khi đẩy lên ERP
                    cmd.Parameters.Add(new SqlParameter("divisionCode", it.divisionCode));
                    cmd.Parameters.Add(new SqlParameter("categoryCode", it.categoryCode));
                    cmd.Parameters.Add(new SqlParameter("groupCode", it.groupCode));
                    cmd.Parameters.Add(new SqlParameter("functionCode", it.functionCode));
                    cmd.Parameters.Add(new SqlParameter("name", it.name));
                    cmd.Parameters.Add(new SqlParameter("brand", it.brand != null ? it.brand : ""));
                    cmd.Parameters.Add(new SqlParameter("manufactureCode", it.manufactureCode != null ? it.manufactureCode : ""));
                    cmd.Parameters.Add(new SqlParameter("UoM", it.UoM != null ? it.UoM : ""));
                    cmd.Parameters.Add(new SqlParameter("weight", Decimal.Parse(it.weight != null ? it.weight : "0")));
                    cmd.Parameters.Add(new SqlParameter("dimensionLength", Decimal.Parse(it.dimensionLength != null ? it.dimensionLength : "0")));
                    cmd.Parameters.Add(new SqlParameter("dimensionWidth", Decimal.Parse(it.dimensionWidth != null ? it.dimensionWidth : "0")));
                    cmd.Parameters.Add(new SqlParameter("dimensionHeight", Decimal.Parse(it.dimensionHeight != null ? it.dimensionHeight : "0")));
                    cmd.Parameters.Add(new SqlParameter("QtyBox", it.QtyBox));
                    cmd.Parameters.Add(new SqlParameter("boxLength", Decimal.Parse(it.boxLength != null ? it.boxLength : "0")));
                    cmd.Parameters.Add(new SqlParameter("boxWidth", Decimal.Parse(it.boxWidth != null ? it.boxWidth : "0")));
                    cmd.Parameters.Add(new SqlParameter("boxHeight", Decimal.Parse(it.boxHeight != null ? it.boxHeight : "0")));
                    cmd.Parameters.Add(new SqlParameter("imgLink", it.imgLink));
                    cmd.Parameters.Add(new SqlParameter("url", it.url != null ? it.url : ""));
                    cmd.Parameters.Add(new SqlParameter("barcode", it.barcode != null ? it.barcode : ""));
                    cmd.Parameters.Add(new SqlParameter("priceRetail", Decimal.Parse(it.priceRetail != null ? it.priceRetail.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("VAT", it.VAT));
                    cmd.Parameters.Add(new SqlParameter("priceCost", it.priceCost));
                    cmd.Parameters.Add(new SqlParameter("faceQty", Decimal.Parse(it.faceQty != null ? it.faceQty : "0")));
                    cmd.Parameters.Add(new SqlParameter("MOQ", it.MOQ));
                    cmd.Parameters.Add(new SqlParameter("realityInventories", it.realityInventories));
                    cmd.Parameters.Add(new SqlParameter("VendorContact_ID", it.VendorContact_ID));

                    cmd.Parameters.Add(new SqlParameter("GenProPostingGroupCode", it.GenProPostingGroupCode));
                    cmd.Parameters.Add(new SqlParameter("SeasonCode", it.SeasonCode));
                    cmd.Parameters.Add(new SqlParameter("Conten", it.Conten != null ? it.Conten : ""));
                    cmd.Parameters.Add(new SqlParameter("GiaBanNiemYet", Decimal.Parse(it.GiaBanNiemYet != null ? it.GiaBanNiemYet.Replace(",", "") : "0")));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_ProductInfo_add");
                    return false;
                }
            }
        }
        public static bool sp_BBM_MP_VendorTool_ProductInfo_edit(ProductInfo it, string MaNCC, string uid, string registrationTax)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ProductInfo_Edit_New", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("id", it.id));
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    // cmd.Parameters.Add(new SqlParameter("BBM_Code", it.BBM_Code != null ? it.BBM_Code : "")); là mã sản phẩm sẽ có sau khi đẩy lên ERP
                    cmd.Parameters.Add(new SqlParameter("divisionCode", it.divisionCode));
                    cmd.Parameters.Add(new SqlParameter("categoryCode", it.categoryCode));
                    cmd.Parameters.Add(new SqlParameter("groupCode", it.groupCode));
                    cmd.Parameters.Add(new SqlParameter("functionCode", it.functionCode));
                    cmd.Parameters.Add(new SqlParameter("name", it.name));
                    cmd.Parameters.Add(new SqlParameter("brand", it.brand != null ? it.brand : ""));
                    cmd.Parameters.Add(new SqlParameter("manufactureCode", it.manufactureCode != null ? it.manufactureCode : ""));
                    cmd.Parameters.Add(new SqlParameter("UoM", it.UoM != null ? it.UoM : ""));
                    cmd.Parameters.Add(new SqlParameter("weight", Decimal.Parse(it.weight != null ? it.weight : "0")));
                    cmd.Parameters.Add(new SqlParameter("dimensionLength", Decimal.Parse(it.dimensionLength != null ? it.dimensionLength : "0")));
                    cmd.Parameters.Add(new SqlParameter("dimensionWidth", Decimal.Parse(it.dimensionWidth != null ? it.dimensionWidth : "0")));
                    cmd.Parameters.Add(new SqlParameter("dimensionHeight", Decimal.Parse(it.dimensionHeight != null ? it.dimensionHeight : "0")));
                    cmd.Parameters.Add(new SqlParameter("QtyBox", it.QtyBox));
                    cmd.Parameters.Add(new SqlParameter("boxLength", Decimal.Parse(it.boxLength != null ? it.boxLength : "0")));
                    cmd.Parameters.Add(new SqlParameter("boxWidth", Decimal.Parse(it.boxWidth != null ? it.boxWidth : "0")));
                    cmd.Parameters.Add(new SqlParameter("boxHeight", Decimal.Parse(it.boxHeight != null ? it.boxHeight : "0")));
                    cmd.Parameters.Add(new SqlParameter("imgLink", it.imgLink));
                    cmd.Parameters.Add(new SqlParameter("url", it.url != null ? it.url : ""));
                    cmd.Parameters.Add(new SqlParameter("barcode", it.barcode != null ? it.barcode : ""));
                    cmd.Parameters.Add(new SqlParameter("priceRetail", Decimal.Parse(it.priceRetail != null ? it.priceRetail.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("VAT", it.VAT));
                    cmd.Parameters.Add(new SqlParameter("priceCost", it.priceCost));
                    cmd.Parameters.Add(new SqlParameter("faceQty", Decimal.Parse(it.faceQty != null ? it.faceQty : "0")));
                    cmd.Parameters.Add(new SqlParameter("MOQ", it.MOQ));
                    cmd.Parameters.Add(new SqlParameter("realityInventories", it.realityInventories));
                    cmd.Parameters.Add(new SqlParameter("VendorContact_ID", it.VendorContact_ID));
                    string chuoi = "0";
                    if (it.status == "1")// nếu sp đã được duyệt thì khi update cho trạng thái bằng 4 = gửi duyệt lại
                    {
                        chuoi = "4";
                    }
                    else if (it.status == "2")// nếu sp đã gửi duyệt mà sửa thì vẫn là 2 gửi duyệt
                    {
                        chuoi = "2";
                    }
                    else if (it.status == "3")// nếu sp đã bị từ chối mà sửa thì vẫn là 2 gửi duyệt
                    {
                        chuoi = "2";
                    }
                    else if (it.status == "4")
                    {
                        chuoi = "4";
                    }
                    cmd.Parameters.Add(new SqlParameter("Status", chuoi));


                    cmd.Parameters.Add(new SqlParameter("GenProPostingGroupCode", it.GenProPostingGroupCode));
                    cmd.Parameters.Add(new SqlParameter("SeasonCode", it.SeasonCode));
                    cmd.Parameters.Add(new SqlParameter("Conten", it.Conten));
                    cmd.Parameters.Add(new SqlParameter("GiaBanNiemYet", Decimal.Parse(it.GiaBanNiemYet != null ? it.GiaBanNiemYet.Replace(",", "") : "0")));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_ProductInfo_add");
                    return false;
                }
            }
        }
        public static string sp_BBM_MP_VendorTool_Approve_Reject(string uid, int approveid, string rejectnote)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_Approve_Reject", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("UserId", uid));
                    cmd.Parameters.Add(new SqlParameter("ApproveID", approveid));
                    cmd.Parameters.Add(new SqlParameter("RejectNote", rejectnote));



                    var reader = cmd.ExecuteScalar();


                    con.Close();

                    return reader.ToString();
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_Approve_Reject");
                    return "Error";
                }
            }
        }
        public static string sp_BBM_MP_VendorTool_Approve_Approve(string uid, int approveid, string approvenote)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_Approve_Approve", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("UserId", uid));
                    cmd.Parameters.Add(new SqlParameter("ApproveID", approveid));
                    cmd.Parameters.Add(new SqlParameter("ApproveNote", approvenote));



                    var reader = cmd.ExecuteScalar();


                    con.Close();

                    return reader.ToString();
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_Approve_Approve");
                    return "Error";
                }
            }
        }
        public static List<objCombox> SP_BBS_QLHH_Status_HH(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetWay_QLHH_Status_HH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
                    cmd.CommandTimeout = 3000;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox its = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };
                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_QLHH_Status_HH");
                    return it_r;
                }

            }
        }
        public static List<objCombox> sp_bbs_getlistCH()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlistCH", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlistCH");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_getWay_CuaHang(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_getWay_CuaHang", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getWay_CuaHang");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_VendorTool_MD_Sub_get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_VendorTool_MD_Sub_get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VendorTool_MD_Sub_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_HangTraLai_MD_Sub_get(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_HangTraLai_MD_Sub_get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_HangTraLai_MD_Sub_get");
                    return it_r;
                }
            }
        }
        public static bool SP_TRADTERM_DELETE_Pro(string ID)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_DELETE_Pro", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_DELETE_Pro");
                    return false;
                }
            }
        }

        // AR - ITEM
        public static bool sp_Pro_createupdate_AR_ITEM(string userid, AR_ITEM info)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pro_createupdate_AR_ITEM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("Store_Code", info.Store_Code));
                    cmd.Parameters.Add(new SqlParameter("Store_Name", info.Store_Name));

                    cmd.Parameters.Add(new SqlParameter("ACMCode", info.ACMCode));
                    cmd.Parameters.Add(new SqlParameter("ACMName", info.ACMName));
                    cmd.Parameters.Add(new SqlParameter("PhamViCode", info.PhamViCode));
                    cmd.Parameters.Add(new SqlParameter("PhamViName", info.PhamViName));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pro_createupdate_Orientation_Bonus");
                    return false;
                }
            }
        }
        public static AR_ITEM Listget_AR_ITEM(string ID)
        {
            AR_ITEM itr = new AR_ITEM();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_AR_ITEM_ID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AR_ITEM it = new AR_ITEM
                        {
                            ID = reader["ID"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            MaNCC = reader["MaNCC"].ToString(),
                            Store_Code = reader["Store_Code"].ToString(),
                            Store_Name = reader["Store_Name"].ToString(),
                            ACMCode = reader["ACMCode"].ToString(),
                            ACMName = reader["ACMName"].ToString(),
                            PhamViCode = reader["PhamViCode"].ToString(),
                            PhamViName = reader["PhamViName"].ToString(),
                            Status = reader["Status"].ToString()

                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_AR_ITEM_ID");
                    return itr;
                }
            }
        }
        public static List<objCombox> sp_Pushsale_GAP_get(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_ThuongNhanVien_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VendorTool_MD_Sub_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_Pushsale_GAP_ThuongNhanVien_get(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_ThuongNhanVien_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_ThuongNhanVien_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_Pushsale_GAP_GiaTangTrungBay_get(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_GiaTangTrungBay_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_GiaTangTrungBay_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_Pushsale_GAP_TruongTrinhKhuyenMai_get(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_TruongTrinhKhuyenMai_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_TruongTrinhKhuyenMai_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_Pushsale_GAP_Discount_Offer_get(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_Discount_Offer_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_Discount_Offer_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_Pushsale_GAP_MixMatch_get(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_MixMatch_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_MixMatch_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_Pushsale_GAP_Total_Discount_get(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_Total_Discount_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_Total_Discount_get");
                    return it_r;
                }
            }
        }
        #endregion

        #region Tradingterm

        #region TradingtermHeader
        public static List<TradingtermHeader> sp_BBM_MP_VendorTool_TradingtermHeader_get(string Lang, int type, string registrationTax)
        {
            List<TradingtermHeader> it_r = new List<TradingtermHeader>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_TradingtermHeader_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TradingtermHeader it = new TradingtermHeader
                        {
                            id = reader["id"].ToString(),
                            registrationTax = reader["registrationTax"].ToString(),
                            cooperateType = reader["cooperateType"].ToString(),
                            listingQty = int.Parse(reader["listingQty"].ToString()),
                            faceAcreage_total = reader["faceAcreage_total"].ToString(),
                            guaranteeMinimum = reader["guaranteeMinimum"].ToString(),
                            discount = reader["discount"].ToString(),
                            salesCost = reader["salesCost"].ToString(),
                            marketingCost = reader["marketingCost"].ToString(),
                            operatingCost = reader["operatingCost"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            status = reader["status"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            description = reader["description"].ToString(),
                            VendorContact_ID = reader["VendorContact_ID"].ToString(),
                            cooperateName = reader["cooperateName"].ToString(),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_TradingtermHeader_get");
                    return it_r;
                }
            }

        }
        public static string sp_BBM_MP_VendorTool_TradingtermHeader_add(TradingtermHeader it, string uid, string registrationTax)
        {
            string rt = "";
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_TradingtermHeader_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("VendorContact_ID", it.VendorContact_ID));
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    cmd.Parameters.Add(new SqlParameter("cooperateType", it.cooperateType));
                    cmd.Parameters.Add(new SqlParameter("listingQty", it.listingQty));
                    cmd.Parameters.Add(new SqlParameter("faceAcreage_total", Decimal.Parse(it.faceAcreage_total.Replace('.', ','), NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("fr-FR"))));
                    cmd.Parameters.Add(new SqlParameter("guaranteeMinimum", Decimal.Parse(it.guaranteeMinimum.Replace('.', ','), NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("fr-FR"))));
                    cmd.Parameters.Add(new SqlParameter("discount", Decimal.Parse(it.discount.Replace('.', ','), NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("fr-FR"))));
                    cmd.Parameters.Add(new SqlParameter("salesCost", Decimal.Parse(it.salesCost.Replace('.', ','), NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("fr-FR"))));
                    cmd.Parameters.Add(new SqlParameter("marketingCost", Decimal.Parse(it.marketingCost.Replace('.', ','), NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("fr-FR"))));
                    cmd.Parameters.Add(new SqlParameter("operatingCost", Decimal.Parse(it.operatingCost.Replace('.', ','), NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("fr-FR"))));



                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        rt = reader["id"].ToString();
                    }

                    con.Close();

                    return rt;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_TradingtermHeader_add");
                    return rt;
                }
            }
        }
        public static bool sp_BBM_MP_VendorTool_TradingtermHeader_update(string tradingtermId, int refundDay)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_TradingtermHeader_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("tradingtermId", tradingtermId));
                    cmd.Parameters.Add(new SqlParameter("refundDay", refundDay));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_TradingtermHeader_update");
                    return false;
                }
            }
        }
        #endregion
        #region TradingtermLine
        public static List<TradingtermLine> sp_BBM_MP_VendorTool_TradingtermLine_get(string registrationTax, string tradingtermId)
        {
            List<TradingtermLine> it_r = new List<TradingtermLine>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_TradingtermLine_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));
                    cmd.Parameters.Add(new SqlParameter("tradingtermId", tradingtermId));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TradingtermLine it = new TradingtermLine
                        {
                            tradingterm_Id = reader["tradingterm_Id"].ToString(),
                            productID = reader["productID"].ToString(),
                            BBM_Code = reader["BBM_Code"].ToString(),
                            productName = reader["productName"].ToString(),
                            faceQty = reader["faceQty"].ToString(),
                            margin = reader["margin"].ToString(),


                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_TradingtermLine_get");
                    return it_r;
                }
            }

        }
        public static bool sp_BBM_MP_VendorTool_TradingtermLine_add(string tradingterm_Id, TradingtermLine it)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_TradingtermLine_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("tradingterm_Id", tradingterm_Id));
                    cmd.Parameters.Add(new SqlParameter("product_Id", it.productID));
                    cmd.Parameters.Add(new SqlParameter("margin", Decimal.Parse(it.margin, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("fr-FR"))));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_TradingtermLine_add");
                    return false;
                }
            }
        }
        #endregion

        #region TradingtermLeadtime
        public static List<TradingtermLeadtime> sp_BBM_MP_VendorTool_TradingtermLeadtime_get(string tradingterm_Id)
        {
            List<TradingtermLeadtime> it_r = new List<TradingtermLeadtime>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_TradingtermLeadtime_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("tradingterm_Id", tradingterm_Id));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TradingtermLeadtime it = new TradingtermLeadtime
                        {
                            tradingterm_Id = reader["tradingterm_Id"].ToString(),
                            Address = reader["Address"].ToString(),
                            leadtimeType = reader["leadtimeType"].ToString(),
                            leadtimeName = reader["leadtimeName"].ToString(),
                            leadtimeValue = reader["leadtimeValue"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_TradingtermLeadtime_get");
                    return it_r;
                }
            }
        }
        public static bool sp_BBM_MP_VendorTool_TradingtermLeadtime_add(string tradingterm_Id, TradingtermLeadtime it)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_TradingtermLeadtime_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("tradingterm_Id", tradingterm_Id));
                    cmd.Parameters.Add(new SqlParameter("Address", it.Address));
                    cmd.Parameters.Add(new SqlParameter("leadtimeType", it.leadtimeType));
                    cmd.Parameters.Add(new SqlParameter("leadtimeValue", it.leadtimeValue));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_TradingtermLeadtime_add");
                    return false;
                }
            }
        }
        #endregion

        #region Tradringterm_GP
        public static List<TradingtermGP> sp_BBM_MP_VendorTool_GP_get(string registrationTax)
        {
            List<TradingtermGP> it_r = new List<TradingtermGP>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_GP_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("registrationTax", registrationTax));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TradingtermGP it = new TradingtermGP
                        {
                            registrationTax = reader["registrationTax"].ToString(),
                            TypeCost = reader["TypeCost"].ToString(),
                            TypeName = reader["TypeName"].ToString(),
                            Year = reader["Year"].ToString(),
                            value = decimal.Parse(reader["value"].ToString()),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_GP_get");
                    return it_r;
                }
            }
        }
        #endregion

        #endregion

        #region DataType
        public static List<objCombox> sp_BBM_MP_VendorTool_UoMType_get(string Lang)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_UoMType_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_UoMType_get");
                    return it_r;
                }
            }
        }
        public static List<typeItem> sp_BBM_MP_VendorTool_Type_get(string Lang, string AttributeCode)
        {
            List<typeItem> it_r = new List<typeItem>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_" + AttributeCode + "Type_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("Lang", Lang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        typeItem it = new typeItem
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_" + AttributeCode + "Type_get");
                    return it_r;
                }
            }
        }
        public static List<typeItem> sp_BBM_MP_VendorTool_ProductType(string type, string key)
        {
            List<typeItem> it_r = new List<typeItem>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ProductType", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("key", key));


                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        typeItem it = new typeItem
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_ProductType");
                    return it_r;
                }
            }
        }
        #endregion

        #region Account
        public static bool Create_Vender_User_Department(string MaNCC, string Password, string PassNoMD5, string Type)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Create_Vender_User_Department", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("UserName", MaNCC + Type));
                    cmd.Parameters.Add(new SqlParameter("Password", Password));
                    cmd.Parameters.Add(new SqlParameter("PassNoMD5", PassNoMD5));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Create_Vender_User_Department");
                    return false;
                }
            }
        }
        public static user_Item BBM_MP_VendorTool_User_get(int way, int type, user_Item it)
        {
            user_Item itr = new user_Item();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("BBM_MP_VendorTool_User_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("way", way));
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("userName", it.userName));
                    cmd.Parameters.Add(new SqlParameter("password", it.password));
                    cmd.Parameters.Add(new SqlParameter("token", it.token != null ? it.token.Replace(" ", "+") : ""));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user_Item su = new user_Item
                        {
                            userName = reader["userName"].ToString(),
                            password = reader["password"].ToString(),
                            token = reader["token"].ToString(),
                        };
                        itr = su;
                    }
                    con.Close();
                    return itr;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_MP_VendorTool_User_get");
                return itr;
            }
        }
        public static user_Role BBM_MP_VendorTool_Department_User_get(string userName, string password)
        {
            user_Role itr = new user_Role();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("BBM_MP_VendorTool_Department_User_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userName", userName));
                    cmd.Parameters.Add(new SqlParameter("password", password));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user_Role su = new user_Role
                        {
                            userName = reader["userName"].ToString(),
                            password = reader["password"].ToString(),
                            URole = reader["URole"].ToString()
                        };
                        itr = su;
                    }
                    con.Close();
                    return itr;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_MP_VendorTool_Department_User_get");
                return itr;
            }
        }
        public static List<IsCheck_IPV4> BBM_MP_VendorTool_Department_IsCheck_IPV4(string userName)
        {
            List<IsCheck_IPV4> it_r = new List<IsCheck_IPV4>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("BBM_MP_VendorTool_Department_IsCheck_IPV4", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userName", userName));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        IsCheck_IPV4 it = new IsCheck_IPV4
                        {
                            UserName = reader["UserName"].ToString(),
                            DiaChiIPV4 = reader["DiaChiIPV4"].ToString(),
                            DiaChiIP = reader["DiaChiIP"].ToString(),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_MP_VendorTool_Department_IsCheck_IPV4");
                    return it_r;
                }
            }
        }


        public static user_Item Vender_User_Department_get(string MaNCC, string Type, string password, string passwordNew)
        {
            user_Item itr = new user_Item();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Vender_User_Department_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("password", password));
                    cmd.Parameters.Add(new SqlParameter("passwordNew", passwordNew));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user_Item su = new user_Item
                        {
                            userName = reader["userName"].ToString(),
                        };
                        itr = su;
                    }
                    con.Close();
                    return itr;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Vender_User_Department_get");
                return itr;
            }
        }
        public static List<RoleItem> sp_BBM_MP_VendorTool_UserRole_get(string uid)
        {
            List<RoleItem> it_r = new List<RoleItem>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_UserRole_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        RoleItem it = new RoleItem
                        {
                            BBM_Code = reader["BBM_Code"].ToString(),
                            roleCode = reader["roleCode"].ToString(),
                            controlCode = reader["controlCode"].ToString(),
                            create_act = reader["create_act"].ToString(),
                            view_act = reader["view_act"].ToString(),
                            edit_act = reader["edit_act"].ToString(),
                            accept_act = reader["accept_act"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_UserRole_get");
                    return it_r;
                }
            }
        }

        public static List<Company> sp_GetWay_info_Company_get(string MaNCC)
        {
            List<Company> it_r = new List<Company>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetWay_info_Company_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC ", MaNCC));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Company it = new Company
                        {
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            Address = reader["Address"].ToString(),
                            Masothue = reader["Masothue"].ToString(),
                            Dienthoai = reader["Dienthoai"].ToString(),
                            NguoiLienHe = reader["NguoiLienHe"].ToString(),
                            Email = reader["Email"].ToString(),
                            website = reader["website"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetWay_info_Company_get");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_GetWay_info_Company_SLSanPham_get(string MaNCC)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetWay_info_Company_SLSanPham_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC ", MaNCC));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["TongSanPham"].ToString(),
                            Name = reader["TongSanPham"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Seminar_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_GetWay_info_Company_NganhHang_get(string MaNCC)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetWay_info_Company_NganhHang_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC ", MaNCC));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["NganhHang"].ToString(),
                            Name = reader["NganhHang"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Seminar_get");
                    return it_r;
                }
            }
        }

        // News
        public static List<permissioninfo> sp_getWay_getPermissionbyUser(string uid)
        {
            List<permissioninfo> it_r = new List<permissioninfo>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_getWay_getPermissionbyUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        permissioninfo it = new permissioninfo
                        {
                            fcode = reader["fcode"].ToString(),
                            fname = reader["fname"].ToString(),
                            parentcode = reader["parentcode"].ToString(),
                            action = reader["action"].ToString(),
                            controller = reader["controller"].ToString(),
                            icon = reader["icon"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getWay_getPermissionbyUser");
                    return it_r;
                }
            }
        }
        public static List<permissioninfo> sp_getWay_getPermissionby_PhongBan(string uid)
        {
            List<permissioninfo> it_r = new List<permissioninfo>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_getWay_getPermissionby_PhongBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        permissioninfo it = new permissioninfo
                        {
                            fcode = reader["fcode"].ToString(),
                            fname = reader["fname"].ToString(),
                            parentcode = reader["parentcode"].ToString(),
                            action = reader["action"].ToString(),
                            controller = reader["controller"].ToString(),
                            icon = reader["icon"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getWay_getPermissionby_PhongBan");
                    return it_r;
                }
            }
        }
        public static List<permissioninfo> sp_getWay_getPermissionby_NCC()
        {
            List<permissioninfo> it_r = new List<permissioninfo>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_getWay_getPermissionby_NCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        permissioninfo it = new permissioninfo
                        {
                            fcode = reader["fcode"].ToString(),
                            fname = reader["fname"].ToString(),
                            parentcode = reader["parentcode"].ToString(),
                            action = reader["action"].ToString(),
                            controller = reader["controller"].ToString(),
                            icon = reader["icon"].ToString(),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getWay_getPermissionby_NCC");
                    return it_r;
                }
            }
        }

        #endregion

        #region DataAcction

        #region RSA
        public static string genKey()
        {
            // Generate a public/private key using RSA  
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            // Read public key in a string  
            string str = RSA.ToXmlString(true);
            return str;
        }
        public static string Encryption(string strText/*, string publicKey*/)
        {
            var publicKey = "<RSAKeyValue><Modulus>7SoV7Cuwlxr5geCk+7NAgZHJr1X4SIjCM2vF0kFFtyJW2m3G09njBUZToVHtkfaT3w8SWymjvsQEukYWFid8KmzdY88OjMjK9KXsiPMj0jM2ST2pATP9CoYyBCGQQqJeYrRzwFK+z6/xlQX8KBMt59JuNmlWYhST75C918psZyE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    // client encrypting data with public key issued by server                    
                    rsa.FromXmlString(publicKey.ToString());

                    var encryptedData = rsa.Encrypt(testData, true);

                    var base64Encrypted = Convert.ToBase64String(encryptedData);

                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        public static string Decryption(string strText/*, string privateKey*/)
        {
            var privateKey = "<RSAKeyValue><Modulus>7SoV7Cuwlxr5geCk+7NAgZHJr1X4SIjCM2vF0kFFtyJW2m3G09njBUZToVHtkfaT3w8SWymjvsQEukYWFid8KmzdY88OjMjK9KXsiPMj0jM2ST2pATP9CoYyBCGQQqJeYrRzwFK+z6/xlQX8KBMt59JuNmlWYhST75C918psZyE=</Modulus><Exponent>AQAB</Exponent><P>+4kCJRufYu5t/f8V+nfnolh8Jpo2MPmxYTM0yrdlSZGNaOQCv43rr4X09F4NpZv98Tab/2YevLbPoB2xeg+LDw==</P><Q>8V/Ghc6uRIbREZRXAnNwWWn/eeSSrh3XwjmP1sDDG3x0XjphzfCiv9lTlFzMKG9ug0osb5MOxvSmdTB97k2qzw==</Q><DP>pTGw3/AJOG8Ae9yocYuH694TA0MqLfX+oaiAllXlxnA6H9YHXAh37hma61ZNviL5nw5PW2eU7jldmHmH0nMczw==</DP><DQ>42LRl350R1QmIoR3T3TGs0UbCo6c6/BrMKqfabUgWIVu7tHbD3IRL+ChTxP4tGL9XiuDHv0Pn7gcFCxBhjyemw==</DQ><InverseQ>5psU4Iv4l8tXBh61bzKEdf6eqx4WMYkn9kBP268El4YzvAov1p5qQfZr6JlR95DZsz6G8Y/r5Kde5NshGyoCag==</InverseQ><D>SffOTpJxyS8IkpFV44rMm5y0opLVlQnSR+ddE254J9316LpEQN68B3EftDixN80H4ZH5z6T1BRJtxwsE6HP4LUl7KMfk5iunZ7M0p5vrkXKqE37pJBiWW/xKOLviyIxG/XQII08p8zAIcQK/04GMd52b56kmWLa5SupMsN+kjWE=</D></RSAKeyValue>";

            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var base64Encrypted = strText;

                    // server decrypting data with private key                    
                    rsa.FromXmlString(privateKey);

                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        #endregion
        public static string genPassword(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuv0123456789@#&";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        #endregion

        #region Seminar
        public static List<Seminar_Item> sp_Seminar_get(string ls_pack)
        {
            List<Seminar_Item> it_r = new List<Seminar_Item>();


            using (var con = new SqlConnection(strConn))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_Seminar_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("ls_pack ", ls_pack));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Seminar_Item it = new Seminar_Item
                        {
                            code = reader["code"].ToString(),
                            NameCode = reader["NameCode"].ToString(),
                            id = int.Parse(reader["id"].ToString()),
                            Name = reader["Name"].ToString(),
                            UoM = reader["UoM"].ToString(),
                            packId = reader["packId"].ToString(),
                            namePack = reader["namePack"].ToString(),
                            headerID = reader["headerID"].ToString(),
                            qty = reader["qty"].ToString(),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Seminar_get");
                    return it_r;
                }
            }
        }
        #endregion

        #region Email_Action
        public static List<EmailTemp> ls_Email_Temp()
        {
            List<EmailTemp> lt = new List<EmailTemp>();
            try
            {
                //StreamReader sw = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Content\\DataTemp\\EmailTemp.json", true);
                //string line = sw.ReadToEnd();
                //JArray arr = JArray.Parse(line.Replace("\n",""));
                JArray arr = JArray.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Content\\DataTemp\\EmailTemp.json"));
                if (arr.Count > 0)
                {
                    foreach (var i in arr)
                    {
                        var sub = JObject.Parse(JsonConvert.SerializeObject(i));
                        EmailTemp it = new EmailTemp
                        {
                            code = sub["code"].ToString(),
                            title = sub["title"].ToString(),
                            content = sub["content"].ToString().Replace(@"\/", @"\"),
                        };

                        lt.Add(it);
                    }
                }
            }
            catch (Exception ex)
            {

                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ls_Email_Temp");
            }

            return lt;
        }
        public static bool EmailSend_AMZ(string emailAddress, string str_title, string str_content)
        {
            String FROM = "cskh@bibomart.com.vn";
            String FROMNAME = "CSKH BiboMart";

            String TO = emailAddress;


            // Replace smtp_username with your Amazon SES SMTP user name.
            String SMTP_USERNAME = ConfigurationManager.AppSettings.Get("AMZ_USERNAME");

            // Replace smtp_password with your Amazon SES SMTP user name.
            String SMTP_PASSWORD = ConfigurationManager.AppSettings.Get("AMZ_PASSWORD");


            String HOST = "email-smtp.us-east-1.amazonaws.com";

            int PORT = 587;

            // The subject line of the email
            String SUBJECT = str_title;

            // The body of the email
            String BODY = str_content;

            // Create and build a new MailMessage object
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            //message.Bcc.Add(new MailAddress("trinhngoctran.tnt@gmail.com"));
            message.Subject = SUBJECT;
            message.Body = BODY;
            // Comment or delete the next line if you are not using a configuration set
            //message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                // Pass SMTP credentials
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.
                try
                {
                    client.Send(message);
                    LogBuild.CreateLogger(emailAddress + "Mail done", "_sendmail");
                    return true;
                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(ex.ToString(), "_sendmail");
                    return false;
                }
            }


        }
        public static bool sendEmail(string emailAddress, string str_title, string str_content)
        {
            try
            {

                LogBuild.CreateLogger("Start send", "_sendmail");
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.bibomart.net");
                mail.From = new MailAddress("trinhtn@bibomart.net");

                mail.To.Add(emailAddress);

                //var mail_body = ob["mail_body"].ToString();


                mail.Subject = str_title;

                mail.IsBodyHtml = true;
                mail.Body = str_content;

                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("trinhtn@bibomart.net", "ab2175Dx5");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                LogBuild.CreateLogger("Mail done", "_sendmail");

                return true;
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(ex.ToString(), "_sendmail");
                return false;
            }
        }
        #endregion

        #region Certificate
        public static bool sp_BBM_MP_VendorTool_Certificate_Link_add(Certificate_Item it)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_Certificate_Link_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("ApproveID", it.ApproveID));
                    cmd.Parameters.Add(new SqlParameter("VendorCode", it.VendorCode));
                    cmd.Parameters.Add(new SqlParameter("VendorContactID", it.VendorContactID));
                    cmd.Parameters.Add(new SqlParameter("ChangeType", it.ChangeType));
                    cmd.Parameters.Add(new SqlParameter("attributeCode", it.attributeCode));
                    cmd.Parameters.Add(new SqlParameter("attributeName", it.attributeName != null ? it.attributeName : ""));
                    cmd.Parameters.Add(new SqlParameter("Filename", it.Filename));
                    cmd.Parameters.Add(new SqlParameter("link", it.link));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_Certificate_Link_add");
                    return false;
                }
            }
        }
        public static bool sp_BBM_MP_VendorTool_ScheduleEmail_add(string tempcode, string mailto, string param, int requestid)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_ScheduleEmail_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("tempcode", tempcode));
                    cmd.Parameters.Add(new SqlParameter("mailto", mailto));
                    cmd.Parameters.Add(new SqlParameter("param", param));
                    cmd.Parameters.Add(new SqlParameter("requestid", requestid));

                    var reader = cmd.ExecuteNonQuery();


                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_ScheduleEmail_add");
                    return false;
                }
            }
        }
        public static List<Certificate_Item> sp_BBM_MP_VendorTool_Certificate_Link_get(string UserID, int ApproveID)
        {
            using (var con = new SqlConnection(strConn))
            {
                List<Certificate_Item> it_r = new List<Certificate_Item>();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_Certificate_Link_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("UserID", UserID));
                    cmd.Parameters.Add(new SqlParameter("ApproveId", ApproveID));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Certificate_Item it = new Certificate_Item
                        {
                            link = reader["link"].ToString(),
                            Filename = reader["Filename"].ToString(),
                            attributeName = reader["attributeName"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_Certificate_Link_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> get_ChiPhiVanHanh()
        {
            using (var con = new SqlConnection(strConn))
            {
                List<objCombox> it_r = new List<objCombox>();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("get_ChiPhiVanHanh", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "get_ChiPhiVanHanh");
                    return it_r;
                }
            }
        }
        #endregion

        #region Vendor

        public static List<objCombox> Get_GeneralProductPotingGroupErp()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_GeneralProductPotingGroupErp", con);//Get_GeneralProductPotingGroupErp
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_GeneralProductPotingGroupErp");
                    return it_r;
                }
            }
        }
        public static List<objCombox> Get_Sub_SeasonsErp()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_Sub_SeasonsErp", con);//Get_GeneralProductPotingGroupErp
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_Sub_SeasonsErp");
                    return it_r;
                }
            }
        }
        public static List<objCombox> Get_Product_Posting_Groups()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_Product_Posting_Groups", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_Product_Posting_Groups");
                    return it_r;
                }
            }
        }
        public static List<objCombox> Get_Sub_BrandErp()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_VendorTool_MD_Sub_BrandErp", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_VendorTool_MD_Sub_BrandErp");
                    return it_r;
                }
            }
        }

        // Orientation_Bonus
        public static bool sp_Pro_createupdate_Orientation_Bonus(string userid, Orientation_Bonus info)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pro_createupdate_Orientation_Bonus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("Brand", info.Brand));

                    cmd.Parameters.Add(new SqlParameter("ACMCode", info.ACMCode));
                    cmd.Parameters.Add(new SqlParameter("ACMName", info.ACMName));
                    cmd.Parameters.Add(new SqlParameter("Bonus", info.Bonus.ToString().Replace(",", "").Replace(".", "")));
                    cmd.Parameters.Add(new SqlParameter("PhamViCode", info.PhamViCode));
                    cmd.Parameters.Add(new SqlParameter("PhamViName", info.PhamViName));
                    cmd.Parameters.Add(new SqlParameter("NgayBatDau", DateTime.Parse(info.NgayBatDau)));
                    cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DateTime.Parse(info.NgayKetThuc)));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pro_createupdate_Orientation_Bonus");
                    return false;
                }
            }
        }
        public static Orientation_Bonus Listget_Orientation_Bonus(string ID)
        {
            Orientation_Bonus itr = new Orientation_Bonus();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_Orientation_Bonus_ID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Orientation_Bonus it = new Orientation_Bonus
                        {
                            ID = reader["ID"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            MaNCC = reader["MaNCC"].ToString(),
                            Brand = reader["Brand"].ToString(),
                            ACMCode = reader["ACMCode"].ToString(),
                            ACMName = reader["ACMName"].ToString(),
                            Bonus = decimal.Parse(reader["Bonus"].ToString()),
                            PhamViCode = reader["PhamViCode"].ToString(),
                            PhamViName = reader["PhamViName"].ToString(),
                            NgayBatDau = reader["NgayBatDau"].ToString(),
                            NgayKetThuc = reader["NgayKetThuc"].ToString(),
                            Status = reader["Status"].ToString()

                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_Orientation_Bonus_ID");
                    return itr;
                }
            }
        }

        public static objCombox sp_BBM_MP_Get_MD_Item_NCC_get(string MaHang)
        {
            objCombox itr = new objCombox();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_MP_Get_MD_Item_NCC_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()

                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_MP_Get_MD_Item_NCC_get");
                    return itr;
                }
            }
        }
        public static List<objCombox> sp_VendorTool_ACM_get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_VendorTool_ACM_get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VendorTool_ACM_get");
                    return it_r;
                }
            }
        }

        #endregion

        #region DebtDeposit
        public static DataTable Sp_get_DebtDeposit(string MaHang, string Thang)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_DebtDeposit_GET_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_DebtDeposit_GET_LIST");
                return ds.Tables[0];
            }
        }

        public static DataTable Sp_GETLIST_Sales_Vendor(string MaHang, string Thang, string Nam, string vendorNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Gateway_GetList_Report_SalesVendor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Gateway_GetList_Report_SalesVendor");
                return ds.Tables[0];
            }
        }

        public static DataTable Sp_get_DebtDeposit_vendorNo(string MaHang, string Thang, string Nam, string vendorNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_DebtDeposit_vendorNo_Fiter_GET_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_DebtDeposit_vendorNo_Fiter_GET_LIST");
                return ds.Tables[0];
            }
        }
        public static bool SP_Status_DebtDeposit_UPDATE(string ID, string Status)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Status_DebtDeposit_UPDATE", con);//SP_Status_DebtDeposit_UPDATE
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Status_DebtDeposit_UPDATE");
                    return false;
                }
            }
        }

        #endregion


        #region CTKM
        public static DataTable SP_CTKM_vendorNo_GET_LIST(string MaHang, string Thang, string vendorNo, string Mien, string LoaiCTKM)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CTKM_vendorNo_GET_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("Mien", Mien));
                    cmd.Parameters.Add(new SqlParameter("LoaiCTKM", LoaiCTKM));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_CTKM_vendorNo_GET_LIST");
                return ds.Tables[0];
            }
        }
        #endregion


        #region ThuongDinhHuong
        public static DataTable SP_ThuongDinhHuong_vendorNo_GET_LIST(string MaHang, string Thang, string vendorNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ThuongDinhHuong_vendorNo_GET_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ThuongDinhHuong_vendorNo_GET_LIST");
                return ds.Tables[0];
            }
        }
        #endregion

        #region Login
        public static List<objCombox> List_TaiKhoan()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_BBM_MP_VendorTool_User", con);
                    cmd.CommandType = CommandType.Text;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Name = reader["BBM_Code"].ToString(),
                            Code = reader["PasND"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "List_TaiKhoan");
                    return it_r;
                }
            }
        }

        public static bool List_TaiKhoanUpdate(string MNCC, string PasND, string passwordND)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("update tbl_BBM_MP_VendorTool_User set PasND=N'" + PasND.Trim() + "',passwordND=N'" + passwordND.Trim() + "' where BBM_Code='" + MNCC + "' ", con);
                    cmd.CommandType = CommandType.Text;
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "List_TaiKhoanUpdate");
                    return false;
                }
            }
        }
        public static List<objCombox> BBM_MP_VendorTool_User_ChangePassword(string BBM_Code)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("BBM_MP_VendorTool_User_ChangePassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("BBM_Code", BBM_Code.ToString()));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Name = reader["Ngay"].ToString(),
                            Code = reader["Ngay"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_MP_VendorTool_User_ChangePassword");
                    return it_r;
                }
            }
        }
        public static List<objCombox> BBM_MP_VendorTool_User_ChangePassword_PhongBan(string BBM_Code)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("BBM_MP_VendorTool_User_ChangePassword_PhongBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("BBM_Code", BBM_Code.ToString()));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Name = reader["Ngay"].ToString(),
                            Code = reader["Ngay"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_MP_VendorTool_User_ChangePassword_PhongBan");
                    return it_r;
                }
            }
        }
        public static user_Item BBM_MP_TradingTern_Login_User(int way, int type, user_Item it)
        {
            user_Item itr = new user_Item();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("BBM_MP_TradingTern_Login_User", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("UserId", it.userName));
                    cmd.Parameters.Add(new SqlParameter("Password", it.password));
                    //cmd.Parameters.Add(new SqlParameter("token", it.token != null ? it.token.Replace(" ", "+") : ""));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user_Item su = new user_Item
                        {
                            userName = reader["userName"].ToString(),
                            password = reader["password"].ToString()
                        };
                        itr = su;
                    }
                    con.Close();
                    return itr;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_MP_TradingTern_Login_User");
                return itr;
            }
        }

        public static List<objCombox> SP_TRADTERM_GET_Vendor_VendorCode(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor_VendorCode", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
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
        public static List<objCombox> SP_TRADTERM_GET_PhanQuyen_VendorCode(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_PhanQuyen_VendorCode", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode.ToString()));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_PhanQuyen_VendorCode");
                    return it_r;
                }
            }
        }
        #endregion

        public static List<DanhMucHoangHoa> Get_SetApDungGia(string MaHang)
        {
            List<DanhMucHoangHoa> it_r = new List<DanhMucHoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_SetApDungGia", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DanhMucHoangHoa it = new DanhMucHoangHoa
                        {
                            GiaApDungCK = reader["GiaApDungCK"].ToString(),
                            PTCKDon = reader["PTCKDon"].ToString(),
                            VAT = reader["VAT"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_SetApDungGia");
                    return it_r;
                }
            }
        }


        #region PUSH_SALES_NCC 
        public static List<objContracNo> SP_PUSHSALE_CONTRACT_DETAIL(string ContractNo)
        {
            List<objContracNo> it_r = new List<objContracNo>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_PUSHSALE_CONTRACT_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ContractNo ", ContractNo));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objContracNo it = new objContracNo
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            VendorName = reader["VendorName"].ToString(),
                            SoCHKinhDoanh = reader["SoCHKinhDoanh"].ToString(),
                            DoanhSoY1 = reader["DoanhSoY1"].ToString(),
                            DoanhSoYTD = reader["DoanhSoYTD"].ToString(),
                            NgayTonKho = reader["NgayTonKho"].ToString(),
                            GPM2F = reader["GPM2F"].ToString(),
                            GPThucDat = reader["GPThucDat"].ToString(),
                            GAP = reader["GAP"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_PUSHSALE_CONTRACT_DETAIL");
                    return it_r;
                }
            }
        }
        public static string ShowMaxID()
        {
            string chuoi = "0";
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("select ISNULL(max(ID),0) as MAXID from [dbo].[TBL_PushSaleNCC_Header]", con);
                    cmd.CommandType = CommandType.Text;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        chuoi = reader["MAXID"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    return chuoi;
                }
            }
            return chuoi;
        }
        public static bool Create_PushSale_NCC_Header(PUSHSALES_Header info, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PUSHSALES_Header", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC));
                    cmd.Parameters.Add(new SqlParameter("SoCHKinhDoanh", info.SoCHKinhDoanh != null ? info.SoCHKinhDoanh : ""));
                    cmd.Parameters.Add(new SqlParameter("DoanhSoY1", info.DoanhSoY1 != null ? info.DoanhSoY1 : ""));
                    cmd.Parameters.Add(new SqlParameter("DoanhSoYTD", info.DoanhSoYTD != null ? info.DoanhSoYTD : ""));
                    if (String.IsNullOrWhiteSpace(info.NgayTonKho))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayTonKho", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayTonKho", DateTime.Parse(info.NgayTonKho)));
                    }
                    cmd.Parameters.Add(new SqlParameter("GPToiThieuNam", info.GPToiThieuNam != null ? info.GPToiThieuNam : ""));
                    cmd.Parameters.Add(new SqlParameter("GPThucDatNam", info.GPThucDatNam != null ? info.GPThucDatNam : ""));
                    cmd.Parameters.Add(new SqlParameter("GAP", Decimal.Parse(info.GAP.Replace(",", "") != "" ? info.GAP.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PUSHSALES_Header");
                    return false;
                }
            }
        }
        public static bool SP_SAVE_PUSHSALES_ThuongNhanVien(PUSHSALES_ThuongNhanVien info, string MaxID, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_SAVE_PUSHSALES_ThuongNhanVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDPushSale", MaxID));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC));
                    cmd.Parameters.Add(new SqlParameter("CodeDiv", info.CodeDiv));
                    cmd.Parameters.Add(new SqlParameter("NameDiv", info.NameDiv));
                    cmd.Parameters.Add(new SqlParameter("CodeBrand", info.CodeBrand));
                    cmd.Parameters.Add(new SqlParameter("NameBrand", info.NameBrand));
                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang));
                    cmd.Parameters.Add(new SqlParameter("Bonus", Decimal.Parse(info.Bonus.Replace(",", "") != "" ? info.Bonus.Replace(",", "") : "0")));
                    if (String.IsNullOrWhiteSpace(info.FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(info.FromDay)));
                    }
                    if (String.IsNullOrWhiteSpace(info.ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(info.ToDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("CodePhamVi", info.CodePhamVi));
                    cmd.Parameters.Add(new SqlParameter("NamePhamVi", info.NamePhamVi));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PUSHSALES_ThuongDinhHuong");
                    return false;
                }
            }
        }
        public static bool SP_PushSale_DELETE_ThuongNhanVien(string ID)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_PushSale_DELETE_ThuongNhanVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_PushSale_DELETE_ThuongNhanVien");
                    return false;
                }
            }
        }
        public static bool Update_Status_ThuongNhanVien(string ID, string HanhDong)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_ThuongNhanVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_ThuongNhanVien");
                    return false;
                }
            }
        }
        public static List<objCombox> SP_Pushsale_getVendorBrand(string Div)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Pushsale_getVendorBrand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Div", Div));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Pushsale_getVendorBrand");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_Pushsale_getDiv()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pushsale_NCC_DivCatGroupFunc_get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_NCC_DivCatGroupFunc_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_Pushsale_getDiv_MaNCC(string MaNCC)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Pushsale_getDiv_MaNCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Pushsale_getDiv_MaNCC");
                    return it_r;
                }
            }
        }
        public static DataTable Get_List_ThuongNhanVien(string MaHang, string PhamVi, string ThoiGian, string Status, string GAP, string VendorNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Get_List_ThuongNhanVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("PhamVi", PhamVi));
                    cmd.Parameters.Add(new SqlParameter("ThoiGian", ThoiGian));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("GAP", GAP));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_ThuongNhanVien");
                return ds.Tables[0];
            }
        }
        public static PUSHSALES_ThuongNhanVien Listget_ThuongNhanVien_PopUp(string ID)
        {
            PUSHSALES_ThuongNhanVien itr = new PUSHSALES_ThuongNhanVien();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Listget_ThuongNhanVien_PopUp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PUSHSALES_ThuongNhanVien it = new PUSHSALES_ThuongNhanVien
                        {
                            ID = reader["ID"].ToString(),
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            CodeDiv = reader["CodeDiv"].ToString(),
                            NameDiv = reader["NameDiv"].ToString(),
                            CodeBrand = reader["CodeBrand"].ToString(),
                            NameBrand = reader["NameBrand"].ToString(),

                            CodePhamVi = reader["CodePhamVi"].ToString(),
                            NamePhamVi = reader["NamePhamVi"].ToString(),

                            ToDay = reader["ToDay"].ToString(),
                            FromDay = reader["FromDay"].ToString(),
                            Bonus = reader["Bonus"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_ThuongNhanVien_PopUp");
                    return itr;
                }
            }
        }
        public static bool Update_ThuongNhanVien(PUSHSALES_ThuongNhanVien info)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_ThuongNhanVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("Bonus", Decimal.Parse(info.Bonus.Replace(",", "") != "" ? info.Bonus.Replace(",", "") : "0")));
                    if (String.IsNullOrWhiteSpace(info.ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(info.ToDay)));
                    }
                    if (String.IsNullOrWhiteSpace(info.FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(info.FromDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("CodePhamVi", info.CodePhamVi));
                    cmd.Parameters.Add(new SqlParameter("NamePhamVi", info.NamePhamVi));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_ThuongNhanVien");
                    return false;
                }
            }
        }
        public static List<objCombox> SP_Pushsale_getVendorBrandok(string Div, string MaNCC)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_Pushsale_getVendorBrand_NCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("Div", Div));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Pushsale_getVendorBrand");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_Pushsale_Brand_NCC_get(string brand, string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_Pushsale_Brand_NCC_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("brand", brand));
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_NCC_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_Pushsale_NCC_get(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_Pushsale_NCC_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_NCC_get");
                    return it_r;
                }
            }
        }

        // Gia tăng trưng bày
        public static bool SP_SAVE_PUSHSALES_GiaTangTrungBay(PUSHSALES_GiaTangTrungBay info, string MaxID, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PUSHSALES_GiaTangTrungBay", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDPushSale", MaxID));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC));
                    cmd.Parameters.Add(new SqlParameter("CodeDiv", info.CodeDiv));
                    cmd.Parameters.Add(new SqlParameter("NameDiv", info.NameDiv));
                    cmd.Parameters.Add(new SqlParameter("CodeBrand", info.CodeBrand));
                    cmd.Parameters.Add(new SqlParameter("NameBrand", info.NameBrand));
                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang));
                    cmd.Parameters.Add(new SqlParameter("SoCuaHang", Decimal.Parse(info.SoCuaHang.Replace(",", "") != "" ? info.SoCuaHang.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SoMatHangTrungBay", Decimal.Parse(info.SoMatHangTrungBay.Replace(",", "") != "" ? info.SoMatHangTrungBay.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DonGiaCHMTB", Decimal.Parse(info.DonGiaCHMTB.Replace(",", "") != "" ? info.DonGiaCHMTB.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PUSHSALES_ThuongDinhHuong");
                    return false;
                }
            }
        }
        public static DataTable Get_List_GiaTangTrungBay(string MaHang, string Status, string GAP, string VendorNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Get_List_GiaTangTrungBay", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("GAP", GAP));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_ThuongNhanVien");
                return ds.Tables[0];
            }
        }
        public static bool SP_PushSale_DELETE_GiaTangTrungBay(string ID)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_PushSale_DELETE_GiaTangTrungBay", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_PushSale_DELETE_GiaTangTrungBay");
                    return false;
                }
            }
        }
        public static bool Update_Status_GiaTangTrungBay(string ID, string HanhDong)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_GiaTangTrungBay", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_GiaTangTrungBay");
                    return false;
                }
            }
        }
        public static PUSHSALES_GiaTangTrungBay Listget_GiaTangTrungBay_PopUp(string ID)
        {
            PUSHSALES_GiaTangTrungBay itr = new PUSHSALES_GiaTangTrungBay();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Listget_GiaTangTrungBay_PopUp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PUSHSALES_GiaTangTrungBay it = new PUSHSALES_GiaTangTrungBay
                        {
                            ID = reader["ID"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            CodeDiv = reader["CodeDiv"].ToString(),
                            NameDiv = reader["NameDiv"].ToString(),
                            CodeBrand = reader["CodeBrand"].ToString(),
                            NameBrand = reader["NameBrand"].ToString(),
                            SoCuaHang = reader["SoCuaHang"].ToString(),
                            SoMatHangTrungBay = reader["SoMatHangTrungBay"].ToString(),
                            DonGiaCHMTB = reader["DonGiaCHMTB"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_GiaTangTrungBay_PopUp");
                    return itr;
                }
            }
        }
        public static bool Update_GiaTangTrungBay(PUSHSALES_GiaTangTrungBay info)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_GiaTangTrungBay", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("SoCuaHang", Decimal.Parse(info.SoCuaHang.Replace(",", "") != "" ? info.SoCuaHang.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SoMatHangTrungBay", Decimal.Parse(info.SoMatHangTrungBay.Replace(",", "") != "" ? info.SoMatHangTrungBay.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DonGiaCHMTB", Decimal.Parse(info.DonGiaCHMTB.Replace(",", "") != "" ? info.DonGiaCHMTB.Replace(",", "") : "0")));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_GiaTangTrungBay");
                    return false;
                }
            }
        }

        //25/12 
        public static List<Exel_TTChung_ThueKe> Get_SetApDung_TTChung_ThueKe(string VendorNCC)
        {
            List<Exel_TTChung_ThueKe> it_r = new List<Exel_TTChung_ThueKe>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_SetApDung_TTChung_ThueKe", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNCC", VendorNCC));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Exel_TTChung_ThueKe it = new Exel_TTChung_ThueKe
                        {
                            SoCuaHangThue = reader["SoCuaHangThue"].ToString(),
                            SoThang = reader["SoThang"].ToString(),
                            M2FThueCuaHang = reader["M2FThueCuaHang"].ToString(),
                            ChiPhiThueThangVAT = reader["ChiPhiThueThangVAT"].ToString(),
                            TongChiPhiThueThangVAT = reader["TongChiPhiThueThangVAT"].ToString(),
                            TongChiPhiThueNam = reader["TongChiPhiThueNam"].ToString(),
                            DSCamKetCuaHang = reader["DSCamKetCuaHang"].ToString(),
                            Mien = reader["Mien"].ToString(),
                            NgayKyHD = reader["NgayKyHD"].ToString(),
                            NgayHetHanHD = reader["NgayHetHanHD"].ToString(),
                            NgaybatDauThue = reader["NgaybatDauThue"].ToString(),
                            NgayDieuChinhKetThuc = reader["NgayDieuChinhKetThuc"].ToString(),
                            CheckTuDongGiaHan = reader["CheckTuDongGiaHan"].ToString(),
                            CheckHieuLuc = reader["CheckHieuLuc"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_SetApDung_TTChung_ThueKe");
                    return it_r;
                }
            }
        }
        public static List<TBL_TRADTERM_Exel_SKU_THUEKE> SetApDung_SKU_ThueKe(string MaHang)
        {
            List<TBL_TRADTERM_Exel_SKU_THUEKE> it_r = new List<TBL_TRADTERM_Exel_SKU_THUEKE>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SetApDung_SKU_ThueKe", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TBL_TRADTERM_Exel_SKU_THUEKE it = new TBL_TRADTERM_Exel_SKU_THUEKE
                        {
                            M2netSP = reader["M2netSP"].ToString(),
                            M2FGrossSP = reader["M2FGrossSP"].ToString(),
                            SoCuaHangPhu = reader["SoCuaHangPhu"].ToString(),
                            SoMatTBCH = reader["SoMatTBCH"].ToString(),
                            Mien = reader["Mien"].ToString(),
                            NgayBatDau = reader["NgayBatDau"].ToString(),
                            NgayKetThuc = reader["NgayKetThuc"].ToString(),
                            NgaybatDauThue = reader["NgaybatDauThue"].ToString(),
                            NgayDieuChinhKetThuc = reader["NgayDieuChinhKetThuc"].ToString(),
                            CheckTuDongGiaHan = reader["CheckTuDongGiaHan"].ToString(),
                            CheckHieuLuc = reader["CheckHieuLuc"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SetApDung_SKU_ThueKe");
                    return it_r;
                }
            }
        }

        #endregion

        #region ReturnedGoods
        public static DataTable SP_GetWay_QLHH_getlstCH_NCC(string NCC, string Tinh, string Kho, string MaHang, string TinhTrang, string TrangThai, string VendorCode, string GiaoHang)
        {
            string Sql = "";
            if (GiaoHang == "1")
            {
                Sql = "SP_GetWay_QLHH_getlstCH_NCC_Noi2Bang_RangeReview_ReturnedGood_Loc2Mien";
            }
            else if (GiaoHang == "2")
            {
                Sql = "SP_GetWay_QLHH_getlstCH_NCC_Noi2Bang_RangeReview_ReturnedGood_KhoTongMienBac";
            }
            else if (GiaoHang == "3")
            {
                Sql = "SP_GetWay_QLHH_getlstCH_NCC_Noi2Bang_RangeReview_ReturnedGood_KhoTongMienNam";
            }
            else if (GiaoHang == "4")
            {
                Sql = "SP_GetWay_QLHH_getlstCH_NCC_Noi2Bang_RangeReview_ReturnedGood_TungCuaHang";
            }

            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnSpac))
                {
                    con.Open();
                    //  SqlCommand cmd = new SqlCommand("SP_GetWay_QLHH_getlstCH_NCC_Noi2Bang_RangeReview_ReturnedGood", con);//SP_GetWay_QLHH_getlstCH_NCC -------và---------- sp_hangtralainhacung

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("NCC", NCC));
                    cmd.Parameters.Add(new SqlParameter("Tinh", Tinh));
                    cmd.Parameters.Add(new SqlParameter("Kho", Kho));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("TinhTrang", TinhTrang));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GetWay_QLHH_getlstCH_NCC");
                return ds.Tables[0];
            }
        }
        public static bool Update_ReturnedGoods(string userid, string MaCH, string MaHang, string Parent_ID, string NCC, string HisDateRRV, string SoLuong)
        {
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_ReturnedGoods_XacNhan_New", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("Parent_ID", Parent_ID.Trim()));
                    cmd.Parameters.Add(new SqlParameter("NCC", NCC.Trim()));
                    cmd.Parameters.Add(new SqlParameter("MaCH", MaCH.Trim()));
                    cmd.Parameters.Add(new SqlParameter("Item", MaHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", userid));
                    cmd.Parameters.Add(new SqlParameter("HisDateRRV", HisDateRRV));
                    cmd.Parameters.Add(new SqlParameter("SoLuong", SoLuong.Trim()));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_ReturnedGoods_XacNhan_New");
                    return false;
                }
            }
        }
        public static List<objCombox> SP_ReturnedGoods_Vender()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetWay_QLHH_ReturnedGood_NhaCungCap", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GetWay_QLHH_ReturnedGood_NhaCungCap");
                    return it_r;
                }
            }
        }
        #endregion


        #region Discount_Offer
        public static string ShowMaxID_Discount_Offer()
        {
            string chuoi = "0";
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_PushSaleNCC_Discount_Offer_TAO_MACTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        chuoi = reader["MaCTKM"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    return chuoi;
                }
            }
            return chuoi;
        }
        public static List<objCombox> Get_Discount_Offer_TAO_MACTKM()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_PushSaleNCC_Discount_Offer_TAO_MACTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["MaCTKM"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TBL_PushSaleNCC_Discount_Offer_TAO_MACTKM");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_PushSale_Coupon_DETAIL()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_PushSale_Coupon_DETAIL", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_PushSale_Coupon_DETAIL");
                    return it_r;
                }
            }
        }
        public static List<objCombox> GetCustomerPriceGroup()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ERP_CustomerPriceGroup_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Value"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetCustomerPriceGroup");
                    return it_r;
                }
            }
        }
        public static bool SP_SAVE_PushSaleNCC_Discount_Offer(string IDPushSale, string MaNCC, string TenNCC, string MaCTKM, string FromDay, string ToDay, string CouponCode, string CouponName, string PriceGroupCode, string PriceGroupName, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PushSaleNCC_Discount_Offer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDPushSale", IDPushSale));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    if (String.IsNullOrWhiteSpace(ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(ToDay)));
                    }
                    if (String.IsNullOrWhiteSpace(FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(FromDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));
                    cmd.Parameters.Add(new SqlParameter("CouponName", CouponName));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupCode", PriceGroupCode));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupName", PriceGroupName));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PushSaleNCC_Discount_Offer");
                    return false;
                }
            }
        }
        public static bool SP_UPDATE_PushSaleNCC_Discount_Offer(string ID, string MaCTKM, string FromDay, string ToDay, string CouponCode, string CouponName, string PriceGroupCode, string PriceGroupName, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_UPDATE_PushSaleNCC_Discount_Offer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    if (String.IsNullOrWhiteSpace(ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(ToDay)));
                    }
                    if (String.IsNullOrWhiteSpace(FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(FromDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));
                    cmd.Parameters.Add(new SqlParameter("CouponName", CouponName));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupCode", PriceGroupCode));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupName", PriceGroupName));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_UPDATE_PushSaleNCC_Discount_Offer");
                    return false;
                }
            }
        }
        public static bool SP_SAVE_PushSaleNCC_Discount_Line(string MaNCC, string TenNCC, string MaCTKM, string Type, string ProductName, string ProductCode, string DiscStdPrice, string DiscAmountStdPrice, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PushSaleNCC_Discount_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("ProductName", ProductName));
                    cmd.Parameters.Add(new SqlParameter("ProductCode", ProductCode));
                    cmd.Parameters.Add(new SqlParameter("DiscStdPrice", DiscStdPrice));
                    cmd.Parameters.Add(new SqlParameter("DiscAmountStdPrice", DiscAmountStdPrice));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PushSaleNCC_Discount_Line");
                    return false;
                }
            }
        }
        public static bool SP_Discount_Offer_DELETE_UPDATE(string MaCTKM)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Discount_Offer_DELETE_UPDATE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Discount_Offer_DELETE_UPDATE");
                    return false;
                }
            }
        }
        public static List<Obj_Discount_Offer> SP_TRADTERM_Discount_Offer_View(string MaCTKM)
        {
            List<Obj_Discount_Offer> it_r = new List<Obj_Discount_Offer>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_Discount_Offer_get_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_Discount_Offer it = new Obj_Discount_Offer
                        {
                            MaCTKM = reader["MaCTKM"].ToString(),
                            FromDay = reader["FromDay"].ToString(),
                            ToDay = reader["ToDay"].ToString(),
                            CouponCode = reader["CouponCode"].ToString(),
                            CouponName = reader["CouponName"].ToString(),
                            PriceGroupCode = reader["PriceGroupCode"].ToString(),
                            PriceGroupName = reader["PriceGroupName"].ToString(),
                            Status = reader["status"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_Discount_Offer_View");
                    return it_r;
                }
            }
        }
        public static List<Obj_Discount_Offer_Line> SP_TRADTERM_Discount_Line_Offer_View(string MaCTKM)
        {
            List<Obj_Discount_Offer_Line> it_r = new List<Obj_Discount_Offer_Line>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_Discount_Offer_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_Discount_Offer_Line it = new Obj_Discount_Offer_Line
                        {
                            Type = reader["Type"].ToString(),
                            ProductName = reader["ProductName"].ToString(),
                            ProductCode = reader["ProductCode"].ToString(),
                            DiscStdPrice = reader["DiscStdPrice"].ToString(),
                            DiscAmountStdPrice = reader["DiscAmountStdPrice"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_Discount_Offer_View");
                    return it_r;
                }
            }
        }

        #endregion

        #region PUSH_SALES_CTKM_MixMatch
        public static List<objCombox> Get_Discount_Offer_TAO_MACTKM_MixMatch()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_Discount_Offer_TAO_MACTKM_MixMatch", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["MaCTKM"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_Discount_Offer_TAO_MACTKM_MixMatch");
                    return it_r;
                }
            }
        }
        public static string ShowMaxID_MixMatch()
        {
            string chuoi = "0";
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_Discount_Offer_TAO_MACTKM_MixMatch", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        chuoi = reader["MaCTKM"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    return chuoi;
                }
            }
            return chuoi;
        }
        public static bool SP_SAVE_PushSaleNCC_MixMatch(string IDPushSale, string MaNCC, string TenNCC, string MaCTKM, string CouponCode, string CouponName, string FromDay, string ToDay, string PriceGroupCode, string PriceGroupName, string NoOfLeastItem, string Leastexp, string Same_DifLine, string Mix_DiscountType, string DealPriceValue, string DiscValue, string DiscountAmoutValue, string NoTimeApp, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PushSaleNCC_MixMatch", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDPushSale", IDPushSale));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    if (String.IsNullOrWhiteSpace(ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(ToDay)));
                    }
                    if (String.IsNullOrWhiteSpace(FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(FromDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));
                    cmd.Parameters.Add(new SqlParameter("CouponName", CouponName));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupCode", PriceGroupCode));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupName", PriceGroupName));

                    cmd.Parameters.Add(new SqlParameter("NoOfLeastItem", Decimal.Parse(NoOfLeastItem.Replace(",", "") != "" ? NoOfLeastItem.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Leastexp", Decimal.Parse(Leastexp.Replace(",", "") != "" ? Leastexp.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Same_DifLine", Same_DifLine));
                    cmd.Parameters.Add(new SqlParameter("Mix_DiscountType", Mix_DiscountType));
                    cmd.Parameters.Add(new SqlParameter("DealPriceValue", Decimal.Parse(DealPriceValue.Replace(",", "") != "" ? DealPriceValue.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DiscValue", Decimal.Parse(DiscValue.Replace(",", "") != "" ? DiscValue.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DiscountAmoutValue", Decimal.Parse(DiscountAmoutValue.Replace(",", "") != "" ? DiscountAmoutValue.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("NoTimeApp", Decimal.Parse(NoTimeApp.Replace(",", "") != "" ? NoTimeApp.Replace(",", "") : "0")));

                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PushSaleNCC_MixMatch");
                    return false;
                }
            }
        }
        public static bool SP_UPDATE_PushSaleNCC_MixMatch(string ID, string MaCTKM, string CouponCode, string CouponName, string FromDay, string ToDay, string PriceGroupCode, string PriceGroupName, string NoOfLeastItem, string Leastexp, string Same_DifLine, string Mix_DiscountType, string DealPriceValue, string DiscValue, string DiscountAmoutValue, string NoTimeApp, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_UPDATE_PushSaleNCC_MixMatch", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    if (String.IsNullOrWhiteSpace(ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(ToDay)));
                    }
                    if (String.IsNullOrWhiteSpace(FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(FromDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));
                    cmd.Parameters.Add(new SqlParameter("CouponName", CouponName));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupCode", PriceGroupCode));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupName", PriceGroupName));

                    cmd.Parameters.Add(new SqlParameter("NoOfLeastItem", Decimal.Parse(NoOfLeastItem.Replace(",", "") != "" ? NoOfLeastItem.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Leastexp", Decimal.Parse(Leastexp.Replace(",", "") != "" ? Leastexp.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Same_DifLine", Same_DifLine));
                    cmd.Parameters.Add(new SqlParameter("Mix_DiscountType", Mix_DiscountType));
                    cmd.Parameters.Add(new SqlParameter("DealPriceValue", Decimal.Parse(DealPriceValue.Replace(",", "") != "" ? DealPriceValue.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DiscValue", Decimal.Parse(DiscValue.Replace(",", "") != "" ? DiscValue.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DiscountAmoutValue", Decimal.Parse(DiscountAmoutValue.Replace(",", "") != "" ? DiscountAmoutValue.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("NoTimeApp", Decimal.Parse(NoTimeApp.Replace(",", "") != "" ? NoTimeApp.Replace(",", "") : "0")));
                    // cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_UPDATE_PushSaleNCC_MixMatch");
                    return false;
                }
            }
        }
        public static bool SP_SAVE_PushSaleNCC_MixMatch_Line(string MaNCC, string TenNCC, string MaCTKM, string Type, string ProductName, string ProductCode, string NoItemNeeded, string DealPriceDiscPercent, string DiscType, string LineGroup, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PushSaleNCC_MixMatch_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("ProductName", ProductName));
                    cmd.Parameters.Add(new SqlParameter("ProductCode", ProductCode));
                    cmd.Parameters.Add(new SqlParameter("NoItemNeeded", Decimal.Parse(NoItemNeeded.Replace(",", "") != "" ? NoItemNeeded.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DealPriceDiscPercent", Decimal.Parse(DealPriceDiscPercent.Replace(",", "") != "" ? DealPriceDiscPercent.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DiscType", DiscType));
                    cmd.Parameters.Add(new SqlParameter("LineGroup", LineGroup));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PushSaleNCC_Discount_Line");
                    return false;
                }
            }
        }
        public static bool SP_SAVE_PushSaleNCC_MixMatch_Line_Group(string MaNCC, string TenNCC, string MaCTKM, string MixDiscountType, string LineGroupCode, string lineGroupType, string value1, string value2, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PushSaleNCC_MixMatch_Line_Group", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("MixDiscountType", MixDiscountType));
                    cmd.Parameters.Add(new SqlParameter("LineGroupCode", LineGroupCode));
                    cmd.Parameters.Add(new SqlParameter("lineGroupType", lineGroupType));
                    cmd.Parameters.Add(new SqlParameter("value1", Decimal.Parse(value1.Replace(",", "") != "" ? value1.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("value2", Decimal.Parse(value2.Replace(",", "") != "" ? value2.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PushSaleNCC_MixMatch_Line_Group");
                    return false;
                }
            }
        }
        public static List<Obj_MixMatch> Mix_Match_View(string MaCTKM)
        {
            List<Obj_MixMatch> it_r = new List<Obj_MixMatch>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_Mix_Match_get_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_MixMatch it = new Obj_MixMatch
                        {
                            MaCTKM = reader["MaCTKM"].ToString(),
                            FromDay = reader["FromDay"].ToString(),
                            ToDay = reader["ToDay"].ToString(),
                            CouponCode = reader["CouponCode"].ToString(),
                            CouponName = reader["CouponName"].ToString(),
                            PriceGroupCode = reader["PriceGroupCode"].ToString(),
                            PriceGroupName = reader["PriceGroupName"].ToString(),

                            NoOfLeastItem = reader["NoOfLeastItem"].ToString(),
                            Leastexp = reader["Leastexp"].ToString(),
                            Same_DifLine = reader["Same_DifLine"].ToString(),
                            Mix_DiscountType = reader["Mix_DiscountType"].ToString(),
                            DealPriceValue = reader["DealPriceValue"].ToString(),
                            DiscValue = reader["DiscValue"].ToString(),
                            DiscountAmoutValue = reader["DiscountAmoutValue"].ToString(),
                            NoTimeApp = reader["NoTimeApp"].ToString(),
                            Status = reader["Status"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_Mix_Match_get_View");
                    return it_r;
                }
            }
        }
        public static List<Obj_MixMatch_Line_Groups> MixMatch_Line_View(string MaCTKM)
        {
            List<Obj_MixMatch_Line_Groups> it_r = new List<Obj_MixMatch_Line_Groups>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("MixMatch_Line_Groups_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_MixMatch_Line_Groups it = new Obj_MixMatch_Line_Groups
                        {
                            LineGroupCode = reader["LineGroupCode"].ToString(),
                            lineGroupType = reader["lineGroupType"].ToString(),
                            lineGroupType1 = reader["lineGroupType1"].ToString(),
                            value1 = reader["value1"].ToString(),
                            value2 = reader["value2"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "MixMatch_Line_View");
                    return it_r;
                }
            }
        }
        public static List<Obj_MixMatch_Line> MixMatch_Line_Groups_View(string MaCTKM)
        {
            List<Obj_MixMatch_Line> it_r = new List<Obj_MixMatch_Line>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("MixMatch_Line_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_MixMatch_Line it = new Obj_MixMatch_Line
                        {
                            Type = reader["Type"].ToString(),
                            ProductCode = reader["ProductCode"].ToString(),
                            ProductName = reader["ProductName"].ToString(),
                            NoItemNeeded = reader["NoItemNeeded"].ToString(),
                            DealPriceDiscPercent = reader["DealPriceDiscPercent"].ToString(),
                            DiscType = reader["DiscType"].ToString(),
                            DiscType1 = reader["DiscType1"].ToString(),
                            LineGroup = reader["LineGroup"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "MixMatch_Line_Groups_View");
                    return it_r;
                }
            }
        }
        public static bool SP_MixMatch_DELETE_UPDATE(string MaCTKM)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_MixMatch_DELETE_UPDATE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_MixMatch_DELETE_UPDATE");
                    return false;
                }
            }
        }
        #endregion


        #region TotalDiscount
        public static string ShowMaxID_Total_Discount()
        {
            string chuoi = "0";
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_PushSaleNCC_TotalDiscount_TAO_MACTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        chuoi = reader["MaCTKM"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    return chuoi;
                }
            }
            return chuoi;
        }
        public static List<objCombox> GetCodeCTKMPushSale_TotalDiscount()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_PushSaleNCC_TotalDiscount_TAO_MACTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["MaCTKM"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_PushSaleNCC_TotalDiscount_TAO_MACTKM");
                    return it_r;
                }
            }
        }
        public static bool SP_SAVE_PushSaleNCC_TotalDiscount(string IDPushSale, string MaNCC, string TenNCC, string MaCTKM, string CouponCode, string CouponName, string FromDay, string ToDay, string PriceGroupCode, string PriceGroupName, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PushSaleNCC_TotalDiscount", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDPushSale", IDPushSale));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    if (String.IsNullOrWhiteSpace(ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(ToDay)));
                    }
                    if (String.IsNullOrWhiteSpace(FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(FromDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));
                    cmd.Parameters.Add(new SqlParameter("CouponName", CouponName));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupCode", PriceGroupCode));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupName", PriceGroupName));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PushSaleNCC_TotalDiscount");
                    return false;
                }
            }
        }
        public static bool SP_UPDATE_PushSaleNCC_TotalDiscount(string ID, string MaCTKM, string CouponCode, string CouponName, string FromDay, string ToDay, string PriceGroupCode, string PriceGroupName, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_UPDATE_PushSaleNCC_TotalDiscount", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    // cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    // cmd.Parameters.Add(new SqlParameter("TenNCC", TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    if (String.IsNullOrWhiteSpace(ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(ToDay)));
                    }
                    if (String.IsNullOrWhiteSpace(FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(FromDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));
                    cmd.Parameters.Add(new SqlParameter("CouponName", CouponName));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupCode", PriceGroupCode));
                    cmd.Parameters.Add(new SqlParameter("PriceGroupName", PriceGroupName));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_UPDATE_PushSaleNCC_TotalDiscount");
                    return false;
                }
            }
        }
        public static bool SP_TotalDiscount_DELETE_UPDATE(string MaCTKM)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TotalDiscount_DELETE_UPDATE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TotalDiscount_DELETE_UPDATE");
                    return false;
                }
            }
        }
        public static bool SP_SAVE_PushSaleNCC_TotalDiscount_Line(string MaNCC, string TenNCC, string MaCTKM, string Type, string ProductName, string ProductCode, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PushSaleNCC_TotalDiscount_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("ProductName", ProductName));
                    cmd.Parameters.Add(new SqlParameter("ProductCode", ProductCode));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PushSaleNCC_TotalDiscount_Line");
                    return false;
                }
            }
        }
        public static bool SP_SAVE_PushSaleNCC_TotalDiscount_Benefits(string MaNCC, string TenNCC, string MaCTKM, string StepAmount, string Type, string ProductName, string ProductCode, string ValueType, string Value, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PushSaleNCC_TotalDiscount_Benefits", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("StepAmount", StepAmount));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("ProductName", ProductName));
                    cmd.Parameters.Add(new SqlParameter("ProductCode", ProductCode));
                    cmd.Parameters.Add(new SqlParameter("ValueType", ValueType));
                    cmd.Parameters.Add(new SqlParameter("Value", Decimal.Parse(Value.Replace(",", "").Replace("null", "") != "" ? Value.Replace(",", "").Replace("null", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PushSaleNCC_TotalDiscount_Benefits");
                    return false;
                }
            }
        }
        public static List<Obj_Total_Discount> Total_Discount_View(string MaCTKM)
        {
            List<Obj_Total_Discount> it_r = new List<Obj_Total_Discount>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Total_Discount_get_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_Total_Discount it = new Obj_Total_Discount
                        {
                            MaCTKM = reader["MaCTKM"].ToString(),
                            FromDay = reader["FromDay"].ToString(),
                            ToDay = reader["ToDay"].ToString(),
                            CouponCode = reader["CouponCode"].ToString(),
                            CouponName = reader["CouponName"].ToString(),
                            PriceGroupCode = reader["PriceGroupCode"].ToString(),
                            PriceGroupName = reader["PriceGroupName"].ToString(),
                            Status = reader["Status"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Total_Discount_get_View");
                    return it_r;
                }
            }
        }
        public static List<Obj_Total_Discount_Line> Total_Discount_Line_View(string MaCTKM)
        {
            List<Obj_Total_Discount_Line> it_r = new List<Obj_Total_Discount_Line>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Total_Discount_Line_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_Total_Discount_Line it = new Obj_Total_Discount_Line
                        {
                            Type = reader["Type"].ToString(),
                            ProductName = reader["ProductName"].ToString(),
                            ProductCode = reader["ProductCode"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Total_Discount_Line_View");
                    return it_r;
                }
            }
        }
        public static List<Obj_Total_Discount_Line_Benefits> Total_Discount_Line_Benefits_View(string MaCTKM)
        {
            List<Obj_Total_Discount_Line_Benefits> it_r = new List<Obj_Total_Discount_Line_Benefits>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Total_Discount_GEWAY__Line_Benefits_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_Total_Discount_Line_Benefits it = new Obj_Total_Discount_Line_Benefits
                        {
                            StepAmount = reader["StepAmount"].ToString(),
                            Type = reader["Type"].ToString(),
                            ProductName = reader["ProductName"].ToString(),
                            ProductCode = reader["ProductCode"].ToString(),
                            ValueType = reader["ValueType"].ToString(),
                            ValueType1 = reader["ValueType1"].ToString(),
                            Value = reader["Value"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Total_Discount_Line_Benefits_View");
                    return it_r;
                }
            }
        }
        #endregion

        #region ChuongTrinhKhuyenMai
        public static DataTable Get_List_ChuongTrinhKhuyenMai(string LoaiCTKM, string Status, string GAP, string VendorNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_LIST_PUSHSALE_CTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("LoaiCTKM", LoaiCTKM));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("GAP", GAP));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_LIST_PUSHSALE_CTKM");
                return ds.Tables[0];
            }
        }
        public static bool SP_PushSale_DELETE_ChuongTrinhKhuyenMai(string MaCTKM)
        {
            string[] Type = MaCTKM.Split('-');
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_PushSale_DELETE_ChuongTrinhKhuyenMai", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", Type[1].Trim()));
                    cmd.Parameters.Add(new SqlParameter("LoaiCTKM", Type[0].Trim()));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_PushSale_DELETE_ChuongTrinhKhuyenMai");
                    return false;
                }
            }
        }
        public static bool Update_Status_ChuongTrinhKhuyenMai(string MaCTKM, string HanhDong)
        {
            string[] Type = MaCTKM.Split('-');
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_ChuongTrinhKhuyenMai", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", Type[1].Trim()));
                    cmd.Parameters.Add(new SqlParameter("LoaiCTKM", Type[0].Trim()));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_ChuongTrinhKhuyenMai");
                    return false;
                }
            }
        }
        #endregion

        #region OfferPrice
        public static DataTable Get_List_OfferPrice(string NhaCC, string MaHang, string Status, string VendorNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Get_List_OfferPrice", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("NhaCC", NhaCC));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_OfferPrice");
                return ds.Tables[0];
            }
        }
        public static bool SP_SAVE_OfferPrice(Obj_PriceOffer info, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_OfferPrice", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang));
                    cmd.Parameters.Add(new SqlParameter("Barcode", info.Barcode != null ? info.Barcode : ""));

                    if (info.GiaTruocThayDoi != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaTruocThayDoi", Decimal.Parse(info.GiaTruocThayDoi.Replace(",", "") != "" ? info.GiaTruocThayDoi.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaTruocThayDoi", "0"));
                    }
                    cmd.Parameters.Add(new SqlParameter("GiaSauThayDoi", Decimal.Parse(info.GiaSauThayDoi.Replace(",", "") != "" ? info.GiaSauThayDoi.Replace(",", "") : "0")));

                    if (info.GiaTruocThayDoiPlus != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaTruocThayDoiPlus", Decimal.Parse(info.GiaTruocThayDoiPlus.Replace(",", "") != "" ? info.GiaTruocThayDoiPlus.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaTruocThayDoiPlus", "0"));
                    }
                    cmd.Parameters.Add(new SqlParameter("GiaSauThayDoiPlus", Decimal.Parse(info.GiaSauThayDoiPlus.Replace(",", "") != "" ? info.GiaSauThayDoiPlus.Replace(",", "") : "0")));

                    cmd.Parameters.Add(new SqlParameter("VAT", Decimal.Parse(info.VAT.Replace(",", "") != "" ? info.VAT.Replace(",", "") : "0")));


                    if (String.IsNullOrWhiteSpace(info.ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(info.ToDay)));
                    }

                    if (String.IsNullOrWhiteSpace(info.FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(info.FromDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("Link", info.Link != null ? info.Link : ""));

                    ///
                    cmd.Parameters.Add(new SqlParameter("GiaBanNYKhuyenNghi", Decimal.Parse(info.GiaBanNYKhuyenNghi != null ? info.GiaBanNYKhuyenNghi.Replace(",", "") : "0")));
                    if (String.IsNullOrWhiteSpace(info.NgayThongBaoChinhThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DateTime.Parse(info.NgayThongBaoChinhThuc)));
                    }
                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc_ThoaThuanHD", info.NgayHieuLuc_ThoaThuanHD != null ? info.NgayHieuLuc_ThoaThuanHD : "0"));
                    cmd.Parameters.Add(new SqlParameter("Status", info.Status));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_OfferPrice");
                    return false;
                }
            }
        }
        public static bool SP_Update_OfferPrice(Obj_PriceOffer info)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_OfferPrice", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("GiaTruocThayDoi", Decimal.Parse(info.GiaTruocThayDoi.Replace(",", "") != "" ? info.GiaTruocThayDoi.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("GiaSauThayDoi", Decimal.Parse(info.GiaSauThayDoi.Replace(",", "") != "" ? info.GiaSauThayDoi.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("GiaSauThayDoiPlus", Decimal.Parse(info.GiaSauThayDoiPlus.Replace(",", "") != "" ? info.GiaSauThayDoiPlus.Replace(",", "") : "0")));
                    if (String.IsNullOrWhiteSpace(info.ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(info.ToDay)));
                    }
                    if (String.IsNullOrWhiteSpace(info.FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(info.FromDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("Link", info.Link != null ? info.Link : ""));

                    ///
                    cmd.Parameters.Add(new SqlParameter("GiaBanNYKhuyenNghi", Decimal.Parse(info.GiaBanNYKhuyenNghi != null ? info.GiaBanNYKhuyenNghi.Replace(",", "") : "0")));
                    if (String.IsNullOrWhiteSpace(info.NgayThongBaoChinhThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DateTime.Parse(info.NgayThongBaoChinhThuc)));
                    }
                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc_ThoaThuanHD", info.NgayHieuLuc_ThoaThuanHD != null ? info.NgayHieuLuc_ThoaThuanHD : "0"));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Update_OfferPrice");
                    return false;
                }
            }
        }
        public static bool Delete_OfferPrice(string ID)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_DELETE_OfferPrice", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_OfferPrice");
                    return false;
                }
            }
        }
        public static bool Update_Status_OfferPrice(string ID, string HanhDong)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_OfferPrice", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_OfferPrice");
                    return false;
                }
            }
        }
        public static bool Update_GiaSauThayDoi_OfferPrice(string ID, string Price)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_GiaSauThayDoi_OfferPrice", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("Price", Price));
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
        public static Obj_PriceOffer Listget_PriceOffer_PopUp(string ID)
        {
            Obj_PriceOffer itr = new Obj_PriceOffer();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Listget_PriceOffer_BIBO_PopUp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Obj_PriceOffer it = new Obj_PriceOffer
                        {
                            ID = reader["ID"].ToString(),
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            Barcode = reader["Barcode"].ToString(),
                            GiaTruocThayDoi = reader["GiaTruocThayDoi"].ToString(),
                            GiaSauThayDoi = reader["GiaSauThayDoi"].ToString(),
                            GiaTruocThayDoiPlus = reader["GiaTruocThayDoiPlus"].ToString(),
                            GiaSauThayDoiPlus = reader["GiaSauThayDoiPlus"].ToString(),
                            VAT = reader["VAT_"].ToString(),
                            ToDay = reader["ToDay"].ToString(),
                            FromDay = reader["FromDay"].ToString(),
                            Link = reader["Link"].ToString(),
                            Status = reader["Status"].ToString(),
                            GiaBanNYKhuyenNghi = reader["GiaBanNYKhuyenNghi"].ToString(),
                            NgayThongBaoChinhThuc = reader["NgayThongBaoChinhThuc"].ToString(),
                            // NgayHieuLuc_ThoaThuanHD = reader["NgayHieuLuc_ThoaThuanHD"].ToString()
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_PriceOffer_PopUp");
                    return itr;
                }
            }
        }
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

        #endregion

        #region TangCuongNhanDien
        public static DataTable Get_List_TangCuongNhanDien(string HangMuc, string Status, string GAP, string VendorNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Get_List_TangCuongNhanDien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("HangMuc", HangMuc));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("GAP", GAP));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_TangCuongNhanDien");
                return ds.Tables[0];
            }
        }
        public static bool SP_SAVE_PUSHSALES_TangCuongNhanDien(obj_TangCuongNhanDien info, string MaxID, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_PUSHSALES_TangCuongNhanDien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDPushSale", MaxID));
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC));
                    cmd.Parameters.Add(new SqlParameter("HangMuc", info.HangMuc));
                    cmd.Parameters.Add(new SqlParameter("DonVi", info.DonVi));
                    cmd.Parameters.Add(new SqlParameter("DonGia", info.DonGia));
                    cmd.Parameters.Add(new SqlParameter("SoLuong", info.SoLuong));
                    if (String.IsNullOrWhiteSpace(info.FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(info.FromDay)));
                    }
                    if (String.IsNullOrWhiteSpace(info.ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(info.ToDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("ThanhTien", info.ThanhTien));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_PUSHSALES_TangCuongNhanDien");
                    return false;
                }
            }
        }
        public static List<objCombox> sp_Pushsale_GAP_TangCuongNhanDien_get(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Pushsale_GAP_TangCuongNhanDien_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_TangCuongNhanDien_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> Get_List_TangCuongNhanDien_HangMuc(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_List_TangCuongNhanDien_HangMuc", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo ", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_TangCuongNhanDien_HangMuc");
                    return it_r;
                }
            }
        }
        public static bool Update_Status_TangCuongNhanDien(string ID, string HanhDong)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_TangCuongNhanDien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_TangCuongNhanDien");
                    return false;
                }
            }
        }
        public static bool SP_PushSale_DELETE_TangCuongNhanDien(string ID)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_PushSale_DELETE_TangCuongNhanDien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_PushSale_DELETE_TangCuongNhanDien");
                    return false;
                }
            }
        }
        public static obj_TangCuongNhanDien Listget_TangCuongNhanDien_PopUp(string ID)
        {
            obj_TangCuongNhanDien itr = new obj_TangCuongNhanDien();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Listget_TangCuongNhanDien_PopUp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        obj_TangCuongNhanDien it = new obj_TangCuongNhanDien
                        {
                            ID = reader["ID"].ToString(),
                            HangMuc = reader["HangMuc"].ToString(),
                            DonVi = reader["DonVi"].ToString(),
                            DonGia = reader["DonGia"].ToString(),
                            SoLuong = reader["SoLuong"].ToString(),
                            FromDay = reader["FromDay"].ToString(),
                            ToDay = reader["ToDay"].ToString(),
                            ThanhTien = reader["ThanhTien"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_TangCuongNhanDien_PopUp");
                    return itr;
                }
            }
        }
        public static bool Update_TangCuongNhanDien(obj_TangCuongNhanDien info)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_TangCuongNhanDien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("HangMuc", info.HangMuc));
                    cmd.Parameters.Add(new SqlParameter("DonVi", info.DonVi));
                    cmd.Parameters.Add(new SqlParameter("DonGia", Decimal.Parse(info.DonGia.Replace(",", "") != "" ? info.DonGia.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SoLuong", Decimal.Parse(info.SoLuong.Replace(",", "") != "" ? info.SoLuong.Replace(",", "") : "0")));
                    if (String.IsNullOrWhiteSpace(info.ToDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDay", DateTime.Parse(info.ToDay)));
                    }
                    if (String.IsNullOrWhiteSpace(info.FromDay))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDay", DateTime.Parse(info.FromDay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("ThanhTien", Decimal.Parse(info.ThanhTien.Replace(",", "") != "" ? info.ThanhTien.Replace(",", "") : "0")));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_TangCuongNhanDien");
                    return false;
                }
            }
        }
        #endregion


        #region DebtPurchase
        public static DataTable GetList_DebtPurchase(string vendorNo, string KyTinhCongNo, string Nam)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetList_DebtPurchase", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_DebtPurchase");
                return ds.Tables[0];
            }
        }
        public static DataTable GetList_DebtPurchase_Header(string vendorNo, string KyCongNo, string Nam, string Trangthai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetList_DebtPurchase_Header", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyCongNo", KyCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
                    cmd.Parameters.Add(new SqlParameter("Trangthai", Trangthai));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_DebtPurchase_Header");
                return ds.Tables[0];
            }
        }
        public static List<objCombox> GetList_Debtpurchase_KyTinhCongNo(string vendorNo, string Nam)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_Debtpurchase_KyTinhCongNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_KyTinhCongNo");
                    return it_r;
                }
            }
        }
        public static List<objCombox> GetList_Debtpurchase_ApDungCho(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_Debtpurchase_ApDungCho", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_ApDungCho");
                    return it_r;
                }
            }
        }
        public static List<DebtPurchase_Fillter> SP_DEBTPURCHASE_GET_INFO_VENDOR(string vendorNo, string KyTinhCongNo, string Nam)
        {
            List<DebtPurchase_Fillter> it_r = new List<DebtPurchase_Fillter>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_DEBTPURCHASE_GET_INFO_VENDOR", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DebtPurchase_Fillter it = new DebtPurchase_Fillter
                        {
                            HanThanhToanKyNay = reader["HanThanhToanKyNay"].ToString(),
                            DieuKhoanThanhToan = reader["DieuKhoanThanhToan"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_DEBTPURCHASE_GET_INFO_VENDOR");
                    return it_r;
                }
            }
        }
        public static List<Detail_DebtPurchase> GetList_Debtpurchase_XacNhanBBM(string vendorNo, string KyTinhCongNo, string Nam)
        {
            List<Detail_DebtPurchase> it_r = new List<Detail_DebtPurchase>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_Debtpurchase_XacNhanBBM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Detail_DebtPurchase it = new Detail_DebtPurchase
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            NgayLapDeNghi = reader["NgayLapDeNghi"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_XacNhanBBM");
                    return it_r;
                }
            }
        }
        public static List<Detail_DebtPurchase> GetList_Debtpurchase_XacNhanNCC(string vendorNo, string KyTinhCongNo, string Nam)
        {
            List<Detail_DebtPurchase> it_r = new List<Detail_DebtPurchase>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_Debtpurchase_XacNhanNCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Detail_DebtPurchase it = new Detail_DebtPurchase
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            NgayLapDeNghi = reader["NgayLapDeNghi"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_XacNhanNCC");
                    return it_r;
                }
            }
        }
        public static bool Save_DebtPurchase_Header_XacNhan(DebtPurchase_header info, string NCCNguoiDuyet, string NewID)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_DebtPurchase_Header_XacNhan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC != null ? info.MaNCC : ""));
                    cmd.Parameters.Add(new SqlParameter("RcptNo", info.RcptNo != null ? info.RcptNo : ""));
                    cmd.Parameters.Add(new SqlParameter("GhiChu", info.GhiChu != null ? info.GhiChu : ""));
                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", info.KyTinhCongNo != null ? info.KyTinhCongNo : ""));
                    cmd.Parameters.Add(new SqlParameter("NCCNguoiDuyet", NCCNguoiDuyet));
                    cmd.Parameters.Add(new SqlParameter("NewID", NewID));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_DebtPurchase_Header_XacNhan");
                    return false;
                }
            }
        }
        #endregion


        #region ReportDepositDetail
        public static List<objCombox> GetList_ReportDeposit_NgayBan(string vendorNo, string Nam)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_NgayBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_NgayBan");
                    return it_r;
                }
            }
        }
        public static List<objCombox> GetList_ReportDeposit_KyTinhCongNo(string vendorNo, string Nam)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_KyTinhCongNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_KyTinhCongNo");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_ReportDeposit_KyGui()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_ReportDeposit_KyGui", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_ReportDeposit_KyGui");
                    return it_r;
                }
            }
        }
        public static List<DebtPurchase_Fillter> SP_ReportDeposit_GET_INFO_VENDOR(string vendorNo, string KyTinhCongNo, string Nam)
        {
            List<DebtPurchase_Fillter> it_r = new List<DebtPurchase_Fillter>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ReportDeposit_GET_INFO_VENDOR", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DebtPurchase_Fillter it = new DebtPurchase_Fillter
                        {
                            HanThanhToanKyNay = reader["HanThanhToanKyNay"].ToString(),
                            DieuKhoanThanhToan = reader["DieuKhoanThanhToan"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ReportDeposit_GET_INFO_VENDOR");
                    return it_r;
                }
            }
        }
        public static DataTable GetList_ReportDepositDetail(string vendorNo, string KyTinhCongNo, string Nam, string Thang)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetList_ReportDepositDetail_getways", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDepositDetail_getway");
                return ds.Tables[0];
            }
        }
        public static bool Save_ReportDeposit_Header_XacNhan_NCC(ReportDeposit_header info, string NCCNguoiDuyet, string NewID)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_ReportDeposit_Header_XacNhan_NCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC != null ? info.MaNCC : ""));
                    cmd.Parameters.Add(new SqlParameter("ItemNo", info.ItemNo != null ? info.ItemNo : ""));
                    cmd.Parameters.Add(new SqlParameter("GhiChu", info.GhiChu != null ? info.GhiChu : ""));
                    if (String.IsNullOrWhiteSpace(info.KyTinhCongNo))
                    {
                        cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", DateTime.Parse(info.KyTinhCongNo)));
                    }
                    cmd.Parameters.Add(new SqlParameter("NCCNguoiDuyet", NCCNguoiDuyet));
                    cmd.Parameters.Add(new SqlParameter("NewID", NewID));
                    cmd.Parameters.Add(new SqlParameter("Ngayban", info.Ngayban != null ? info.Ngayban : ""));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_ReportDeposit_Header_XacNhan");
                    return false;
                }
            }
        }
        public static List<Detail_DebtPurchase> GetList_ReportDeposit_XacNhanBBM(string vendorNo, string KyTinhCongNo, string Nam)
        {
            List<Detail_DebtPurchase> it_r = new List<Detail_DebtPurchase>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_XacNhanBBM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Detail_DebtPurchase it = new Detail_DebtPurchase
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            NgayLapDeNghi = reader["NgayLapDeNghi"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_XacNhanBBM");
                    return it_r;
                }
            }
        }
        public static List<Detail_DebtPurchase> GetList_ReportDeposit_XacNhanNCC(string vendorNo, string KyTinhCongNo, string Nam)
        {
            List<Detail_DebtPurchase> it_r = new List<Detail_DebtPurchase>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_XacNhanNCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyTinhCongNo", KyTinhCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Detail_DebtPurchase it = new Detail_DebtPurchase
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            NgayLapDeNghi = reader["NgayLapDeNghi"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_XacNhanNCC");
                    return it_r;
                }
            }
        }
        public static List<objCombox> GetList_ReportDeposit_ApDungCho(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_ApDungCho", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_ApDungCho");
                    return it_r;
                }
            }
        }
        public static DataTable GetList_ReportDeposit_Header(string vendorNo, string KyCongNo, string Nam, string Trangthai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetList_ReportDeposit_Header", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("KyCongNo", KyCongNo));
                    cmd.Parameters.Add(new SqlParameter("Nam", Nam));
                    cmd.Parameters.Add(new SqlParameter("Trangthai", Trangthai));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_Header");
                return ds.Tables[0];
            }
        }
        public static bool Save_ReportDeposit_TradingTem(ReportDeposit_TradingTemMienBN info, string CreateBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_ReportDeposit_TradingTem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC != null ? info.MaNCC : ""));
                    cmd.Parameters.Add(new SqlParameter("Nam", info.Nam != null ? info.Nam : ""));
                    cmd.Parameters.Add(new SqlParameter("KyCongNo", info.KyCongNo != null ? info.KyCongNo : ""));
                    cmd.Parameters.Add(new SqlParameter("Tieude", info.Tieude != null ? info.Tieude : ""));
                    cmd.Parameters.Add(new SqlParameter("Total", info.Total != null ? info.Total : ""));
                    cmd.Parameters.Add(new SqlParameter("SoHD", info.SoHD != null ? info.SoHD : ""));
                    if (String.IsNullOrWhiteSpace(info.NgayHD))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHD", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHD", DateTime.Parse(info.NgayHD)));
                    }
                    cmd.Parameters.Add(new SqlParameter("GhiChu", info.GhiChu != null ? info.GhiChu : ""));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    cmd.Parameters.Add(new SqlParameter("TypeBy_NCC_BBM", info.TypeBy_NCC_BBM != null ? info.TypeBy_NCC_BBM : ""));
                    cmd.Parameters.Add(new SqlParameter("TypeMien", info.TypeMien != null ? info.TypeMien : ""));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_ReportDeposit_TradingTem");
                    return false;
                }
            }
        }
        #endregion


        #region Bình ổn giá
        public static List<objCombox> SP_BinhOnGia_Vender(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BinhOnGia_Vender", con);

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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BinhOnGia_Vender");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_BinhOnGia_Vender_ITEM_Vendor(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BinhOnGia_Vender_ITEM_Vendor", con);

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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BinhOnGia_Vender_ITEM_Vendor");
                    return it_r;
                }
            }
        }
        public static DataTable Getway_BinhOnGia_ThiTruong(string NhaCC, string MaHang, string NgayCapNhat)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnSpac))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Getway_BinhOnGia_ThiTruong", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("NhaCC", NhaCC));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("NgayCapNhat", NgayCapNhat));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Getway_BinhOnGia_ThiTruong");
                return ds.Tables[0];
            }
        }

        public static bool Add_BinhOnGia_ThiTruong_Vender_Item(string userid, BinhOnGia_ThiTruong po)
        {
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Add_BinhOnGia_ThiTruong_Vender_Item", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("NCC", po.NCC.Trim()));
                    cmd.Parameters.Add(new SqlParameter("MaHang", po.MaHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("TenHang", po.TenHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("Images", po.Images.Trim()));

                    cmd.Parameters.Add(new SqlParameter("GiaBanAll", po.GiaBanAll.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("GiaDoiThu", po.GiaDoiThu.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("TenDoiThu", po.TenDoiThu.Trim()));
                    cmd.Parameters.Add(new SqlParameter("GiaGoiY", po.GiaGoiY.Trim().Replace(",", "")));

                    cmd.Parameters.Add(new SqlParameter("GiaDieuChinh", po.GiaDieuChinh.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("GiaMuaNet", po.GiaMuaNet.Trim().Replace(",", "")));
                    if (po.PhanTramGPMoi.Trim() != "")
                    {
                        cmd.Parameters.Add(new SqlParameter("PhanTramGPMoi", po.PhanTramGPMoi.Trim()));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("PhanTramGPMoi", DBNull.Value));
                    }

                    cmd.Parameters.Add(new SqlParameter("CreateBy", userid));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Add_BinhOnGia_ThiTruong_Vender_Item");
                    return false;
                }
            }
        }

        public static DataTable Getway_BinhOnGia_ThiTruong_Arp(string NhaCC, string MaHang, string NgayCapNhat, string TrangThai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnSpac))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Getway_BinhOnGia_ThiTruong_Arp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("NhaCC", NhaCC));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("NgayCapNhat", NgayCapNhat));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Getway_BinhOnGia_ThiTruong_Arp");
                return ds.Tables[0];
            }
        }

        #endregion
        public static List<objCombox> sp_SourceProduct_NguonNhap_ProNew()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SourceProduct_NguonNhap_ProNew", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_SourceProduct_NguonNhap_ProNew");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_qlkd_getVendor()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getVendor", con);//sp_qlkd_getVendor
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_getVendor");
                    return it_r;
                }
            }
        }
        public static List<DivCatGroupFunc> sp_ProductTool_SourceProduct_DivCatGroupFunc_v2_get(string uid)
        {
            List<DivCatGroupFunc> it_r = new List<DivCatGroupFunc>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SourceProduct_DivCatGroupFunc_v2_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DivCatGroupFunc it = new DivCatGroupFunc
                        {
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SourceProduct_DivCatGroupFunc_v2_get");
                    return it_r;
                }
            }

        }
        public static List<DivCatGroupFunc> sp_SourceProduct_DivCatGroupFunc_v2_get_ProNew()
        {
            List<DivCatGroupFunc> it_r = new List<DivCatGroupFunc>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SourceProduct_DivCatGroupFunc_v2_get_ProNew", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DivCatGroupFunc it = new DivCatGroupFunc
                        {
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_SourceProduct_DivCatGroupFunc_v2_get_ProNew");
                    return it_r;
                }
            }

        }
        public static List<objCombox> sp_Sub_VAT_Product_Posting_Groups(string code, string Price)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Sub_VAT_Product_Posting_Groups", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("code", code));
                    cmd.Parameters.Add(new SqlParameter("Price", Price));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Sub_VAT_Product_Posting_Groups");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_Sub_VAT_Product_Posting_Groups_CongVAT(string code, string Price)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Sub_VAT_Product_Posting_Groups_CongVAT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("code", code));
                    cmd.Parameters.Add(new SqlParameter("Price", Price));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Sub_VAT_Product_Posting_Groups_CongVAT");
                    return it_r;
                }
            }
        }
    }
}