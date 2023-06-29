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

namespace MP_VendorTool.DataAccess
{
    public class DataAccessTrading
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
       // private static string strConn101 = ConfigurationManager.AppSettings.Get("strConn101");
        private static string strConnSpac = ConfigurationManager.AppSettings.Get("strConnSpac");

        #region trandingTern
        //public static List<objCombox> SP_TRADTERM_GET_INFO_VENDOR()
        //{
        //    List<objCombox> it_r = new List<objCombox>();
        //    using (var con = new SqlConnection(strConn))
        //    {
        //        con.Open();
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_KyThanhToan", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            var reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                objCombox it = new objCombox
        //                {
        //                    Code = reader["Value"].ToString(),
        //                    Name = reader["Text"].ToString()
        //                };
        //                it_r.Add(it);
        //            }
        //            con.Close();
        //            return it_r;
        //        }
        //        catch (Exception ex)
        //        {
        //            con.Close();
        //            LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_KyThanhToan");
        //            return it_r;
        //        }
        //    }
        //}
        public static List<obj_TRADTERM_LEADTIME_View> SP_TRADTERM_LIST_LeadTime_View(string IDContractNo, string TypeTab)
        {
            List<obj_TRADTERM_LEADTIME_View> it_r = new List<obj_TRADTERM_LEADTIME_View>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LeadTime_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
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
        public static List<obj_TRADTERM_CHIPHIVANHANH> SP_TRADTERM_LIST_CHIPHIVANHANH(string IDContractNo, string TypeTab)
        {
            List<obj_TRADTERM_CHIPHIVANHANH> it_r = new List<obj_TRADTERM_CHIPHIVANHANH>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_CHIPHIVANHANH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        obj_TRADTERM_CHIPHIVANHANH it = new obj_TRADTERM_CHIPHIVANHANH
                        {
                            NoiDungDauTu = reader["NoiDungDauTu"].ToString(),
                            PTDauTu = reader["PTDauTu"].ToString(),
                            GiaTriDauTu = reader["GiaTriDauTu"].ToString(),
                            DieuKien = reader["DieuKien"].ToString(),
                            salesConditions = reader["salesConditions"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_CHIPHIVANHANH");
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
        public static List<objCONTENT_RETURNS_GOODS_View> SP_TRADTERM_LIST_DoiTraHang_View(string IDContractNo, string TypeTab)
        {
            List<objCONTENT_RETURNS_GOODS_View> it_r = new List<objCONTENT_RETURNS_GOODS_View>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_DoiTraHang_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCONTENT_RETURNS_GOODS_View it = new objCONTENT_RETURNS_GOODS_View
                        {
                            contentApply = reader["contentApply"].ToString(),
                            changeReturns = reader["changeReturns"].ToString(),
                            refundTerm = reader["refundTerm"].ToString(),
                            Penalty = reader["Penalty"].ToString(),
                            Satus = reader["Satus"].ToString(),
                            Conten = reader["Conten"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_DoiTraHang_View");
                    return it_r;
                }
            }
        }
        public static List<objPAYMENT_View> SP_TRADTERM_LIST_PAYMENT_View(string IDContractNo, string TypeTab)
        {
            List<objPAYMENT_View> it_r = new List<objPAYMENT_View>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_PAYMENT_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objPAYMENT_View it = new objPAYMENT_View
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            TypeOrder = reader["TypeOrder"].ToString(),
                            PaymentPeriod = reader["PaymentPeriod"].ToString(),
                            OnDay = reader["OnDay"].ToString(),
                            AndDay = reader["AndDay"].ToString(),
                            ApplyFor = reader["ApplyFor"].ToString(),
                            Content = reader["Content"].ToString(),
                            Text = reader["Text"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_PAYMENT_View");
                    return it_r;
                }
            }
        }
        public static List<objPAYMENT> SP_TRADTERM_LIST_PAYMENT(string IDContractNo)
        {
            List<objPAYMENT> it_r = new List<objPAYMENT>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_PAYMENT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
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
        public static List<objMKTBONUS> SP_TRADTERM_LIST_MKT_BONUS(string IDContractNo)
        {
            List<objMKTBONUS> it_r = new List<objMKTBONUS>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_MKT_BONUS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objMKTBONUS it = new objMKTBONUS
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            content_invest = reader["content_invest"].ToString(),
                            percent_invest = reader["percent_invest"].ToString(),
                            invest_value = reader["invest_value"].ToString(),
                            Description = reader["Description"].ToString(),
                            salesConditions = reader["salesConditions"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_MKT_BONUS");
                    return it_r;
                }
            }
        }
        public static List<objLINEBONUS> SP_TRADTERM_LIST_LINE_BONUS_View(string IDContractNo, string TypeTab)
        {
            List<objLINEBONUS> it_r = new List<objLINEBONUS>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LINE_BONUS_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab ", TypeTab));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LINE_BONUS_View");
                    return it_r;
                }
            }
        }
        public static List<objLINEBONUS> SP_TRADTERM_LIST_LINE_BONUS(string IDContractNo)
        {
            List<objLINEBONUS> it_r = new List<objLINEBONUS>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_LINE_BONUS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
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
        public static List<objDISCOUNTSALES> SP_TRADTERM_LIST_DISCOUNT_SALES(string IDContractNo)
        {
            List<objDISCOUNTSALES> it_r = new List<objDISCOUNTSALES>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_DISCOUNT_SALES", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objDISCOUNTSALES it = new objDISCOUNTSALES
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            Co_OperateTypeID = reader["Co_OperateTypeID"].ToString(),
                            DiscountSalesType = reader["DiscountSalesType"].ToString(),
                            HinhThucThanhToan = reader["HinhThucThanhToan"].ToString(),

                            DiscountAmount = reader["DiscountAmount"].ToString(),
                            DiscountPercent = reader["DiscountPercent"].ToString(),
                            OrderValue = reader["OrderValue"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_DISCOUNT_SALES");
                    return it_r;
                }
            }
        }
        public static List<objDISCOUNTQTTY> SP_TRADTERM_LIST_DISCOUNT_QTTY(string IDContractNo)
        {
            List<objDISCOUNTQTTY> it_r = new List<objDISCOUNTQTTY>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_DISCOUNT_QTTY", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objDISCOUNTQTTY it = new objDISCOUNTQTTY
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            Co_OperateTypeID = reader["Co_OperateTypeID"].ToString(),
                            quantityBuy = reader["quantityBuy"].ToString(),
                            QuantityGifts = reader["QuantityGifts"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_DISCOUNT_QTTY");
                    return it_r;
                }
            }
        }
        public static List<objCUSTOMERBONUS> SP_TRADTERM_LIST_CUSTOMER_BONUS(string IDContractNo)
        {
            List<objCUSTOMERBONUS> it_r = new List<objCUSTOMERBONUS>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_CUSTOMER_BONUS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCUSTOMERBONUS it = new objCUSTOMERBONUS
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            content_invest = reader["content_invest"].ToString(),
                            percent_invest = reader["percent_invest"].ToString(),
                            invest_value = reader["invest_value"].ToString(),
                            Description = reader["Description"].ToString(),
                            salesConditions = reader["salesConditions"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_CUSTOMER_BONUS");
                    return it_r;
                }
            }
        }
        public static List<objCooperationOther> SP_TRADTERM_LIST_COOPERATION_OTHER(string IDContractNo)
        {
            List<objCooperationOther> it_r = new List<objCooperationOther>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_COOPERATION_OTHER", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCooperationOther it = new objCooperationOther
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            content1 = reader["content1"].ToString(),
                            content2 = reader["content2"].ToString(),
                            content3 = reader["content3"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_COOPERATION_OTHER");
                    return it_r;
                }
            }
        }
        public static List<objCooperationOther> SP_TRADTERM_LIST_COOPERATION_OTHER_View(string IDContractNo, string TypeTab)
        {
            List<objCooperationOther> it_r = new List<objCooperationOther>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_COOPERATION_OTHER_View", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("TypeTab ", TypeTab));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCooperationOther it = new objCooperationOther
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            content1 = reader["content1"].ToString(),
                            content2 = reader["content2"].ToString(),
                            content3 = reader["content3"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_COOPERATION_OTHER_View");
                    return it_r;
                }
            }
        }
        public static List<objBrandBonus> SP_TRADTERM_LIST_BRAND_BONUS(string IDContractNo)
        {
            List<objBrandBonus> it_r = new List<objBrandBonus>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_BRAND_BONUS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objBrandBonus it = new objBrandBonus
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            content_invest = reader["content_invest"].ToString(),
                            percent_invest = reader["percent_invest"].ToString(),
                            invest_value = reader["invest_value"].ToString(),
                            Description = reader["Description"].ToString(),
                            salesConditions = reader["salesConditions"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_BRAND_BONUS");
                    return it_r;
                }
            }
        }
        public static List<objApplyReturnProduct> SP_TRADTERM_LIST_APPLY_RETURN_PRODUCT(string IDContractNo)
        {
            List<objApplyReturnProduct> it_r = new List<objApplyReturnProduct>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_APPLY_RETURN_PRODUCT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objApplyReturnProduct it = new objApplyReturnProduct
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            confirmChange = reader["confirmChange"].ToString(),
                            Conten = reader["Conten"].ToString(),
                            Satus = reader["Satus"].ToString(),
                            refundTerm = reader["refundTerm"].ToString(),
                            Penalty = reader["Penalty"].ToString(),
                            TypeTab = reader["TypeTab"].ToString(),
                            BaoTruocNgay = reader["BaoTruocNgay"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_APPLY_RETURN_PRODUCT");
                    return it_r;
                }
            }
        }
        public static List<objProduct> SP_TRADTERM_LIST_VENDORS_PRODUCT(string IDContractNo)
        {
            List<objProduct> it_r = new List<objProduct>();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_VENDORS_PRODUCT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objProduct it = new objProduct
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            productcode = reader["productcode"].ToString(),
                            productname = reader["productname"].ToString(),
                            barcode = reader["barcode"].ToString(),
                            p_CoopType = reader["p_CoopType"].ToString(),
                            p_Vat = reader["p_Vat"].ToString(),
                            TypeTab = reader["TypeTab"].ToString(),
                            //p_PriceDiscount = reader["p_PriceDiscount"].ToString(),
                            p_PriceDiscount = reader["p_PriceDiscount"].ToString(),
                            p_PercentDiscountBill = reader["p_PercentDiscountBill"].ToString(),
                            //p_PriceAfterDiscountBasic = reader["p_PriceAfterDiscountBasic"].ToString()
                            p_PriceAfterDiscountBasic = reader["p_PriceAfterDiscountBasic"].ToString(),

                            Images = reader["Images"].ToString(),
                            RangeReviewName = reader["RangeReviewName"].ToString(),
                            TinhTrang = reader["TinhTrang"].ToString(),

                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_VENDORS_PRODUCT");
                    return it_r;
                }
            }
        }
        public static List<objProductFunction> SP_TRADTERM_LIST_VENDORS_PRODUCT_FUNCTION(string IDContractNo)
        {
            List<objProductFunction> it_r = new List<objProductFunction>();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_VENDORS_PRODUCT_FUNCTION", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objProductFunction it = new objProductFunction
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            hinhthucht = reader["hinhthucht"].ToString(),
                            p_Vat = reader["p_Vat"].ToString(),
                            TypeTab = reader["TypeTab"].ToString(),
                            p_PriceDiscount = double.Parse(reader["p_PriceDiscount"].ToString()).ToString("#,###", cul.NumberFormat),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_VENDORS_PRODUCT_FUNCTION");
                    return it_r;
                }
            }
        }
        public static List<objProductBrand> SP_TRADTERM_LIST_VENDORS_PRODUCT_BRAND(string IDContractNo)
        {
            List<objProductBrand> it_r = new List<objProductBrand>();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_VENDORS_PRODUCT_BRAND", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objProductBrand it = new objProductBrand
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            hinhthucht = reader["hinhthucht"].ToString(),
                            p_Vat = reader["p_Vat"].ToString(),
                            TypeTab = reader["TypeTab"].ToString(),
                            p_PriceDiscount = double.Parse(reader["p_PriceDiscount"].ToString()).ToString("#,###", cul.NumberFormat),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_VENDORS_PRODUCT_BRAND");
                    return it_r;
                }
            }
        }
        public static List<objContract> SP_TRADTERM_CONTRACT_DETAIL(string IDContractNo)
        {
            List<objContract> it_r = new List<objContract>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_CONTRACT_DETAIL_News", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objContract it = new objContract
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            VendorName = reader["VendorName"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            FromDate = reader["FromDate"].ToString(),
                            ToDate = reader["ToDate"].ToString(),
                            AutoExtentContract = reader["AutoExtentContract"].ToString(),
                            ACM = reader["ACM"].ToString(),
                            CM = reader["CM"].ToString(),
                            SupplyManager = reader["SupplyManager"].ToString(),
                            priceChangeDate = reader["priceChangeDate"].ToString(),
                            ID = reader["ID"].ToString(),
                            Status = reader["Status"].ToString(),
                            IDContractNo = reader["ID"].ToString(),
                            Type = reader["Type"].ToString(),
                            TrangThaiDuyet = reader["TrangThaiDuyet"].ToString(),

                            TuNgay = reader["TuNgay"].ToString(),
                            DenNgay = reader["DenNgay"].ToString(),
                            SoHopDong = reader["SoHopDong"].ToString(),
                            FileSoHopDong = reader["FileSoHopDong"].ToString(),
                            FilePhuLucHopDong = reader["FilePhuLucHopDong"].ToString(),

                            TinhTrang = reader["TinhTrang"].ToString(),
                            NguoiDaiDienBBM = reader["NguoiDaiDienBBM"].ToString(),
                            NguoiDaiDienNCC = reader["NguoiDaiDienNCC"].ToString(),
                            AutoExtentContractSoHopDong = reader["AutoExtentContractSoHopDong"].ToString(),
                            SoPhuLuc = reader["SoPhuLuc"].ToString(),
                            TinhTrangHD = reader["TinhTrangHD"].ToString(),

                            DaiDienBBM = reader["DaiDienBBM"].ToString(),
                            DaiDienNCC = reader["DaiDienNCC"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_CONTRACT_DETAIL");
                    return it_r;
                }
            }
        }
        public static List<objContract> SP_TRADTERM_CONTRACT_DETAIL_VendorNo(string VendorNo)
        {
            List<objContract> it_r = new List<objContract>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_CONTRACT_DETAIL_VendorNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objContract it = new objContract
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            VendorName = reader["VendorName"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            FromDate = reader["FromDate"].ToString(),
                            ToDate = reader["ToDate"].ToString(),
                            AutoExtentContract = reader["AutoExtentContract"].ToString(),
                            ACM = reader["ACM"].ToString(),
                            CM = reader["CM"].ToString(),
                            SupplyManager = reader["SupplyManager"].ToString(),
                            priceChangeDate = reader["priceChangeDate"].ToString(),
                            ID = reader["ID"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_CONTRACT_DETAIL_VendorNo");
                    return it_r;
                }
            }
        }
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
        public static DataTable sp_GetListContractNo_ACM(string ContractNo, string Status, string vendorNo, string NguonNhap, string userid, string LoaiHoptac, string SoHopDong)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_LIST_CONTRACT_ACM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("status", Status));
                    //cmd.Parameters.Add(new SqlParameter("isvendor", isvendor));
                    cmd.Parameters.Add(new SqlParameter("NguonNhap", NguonNhap));

                    cmd.Parameters.Add(new SqlParameter("LoaiHoptac", LoaiHoptac));
                    cmd.Parameters.Add(new SqlParameter("SoHopDong", SoHopDong));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListContractNo");
                return ds.Tables[0];
            }
        }
        public static DataTable sp_GetListContractNo(string ContractNo, string Status, string vendorNo, string NgayHieuLuc)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_LIST_CONTRACT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    //cmd.Parameters.Add(new SqlParameter("dateFill", dateFill));

                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("status", Status));
                    //cmd.Parameters.Add(new SqlParameter("isvendor", isvendor));
                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", NgayHieuLuc));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListContractNo");
                return ds.Tables[0];
            }
        }
        public static DataTable sp_GetList_TRADING_TERM_Duyet(string ContractNo, string Status, string vendorNo, string NgayHieuLuc)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();

                    // Luu y: con này ko có trên con db test và ko có quyền tạo các db từ con 42 và 51
                    SqlCommand cmd = new SqlCommand("SP_TRADING_BIBO_Duyet_TERM_Duyet", con);//SP_TRADING_TERM_Duyet
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("status", Status));
                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", NgayHieuLuc));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADING_TERM_Duyet");
                return ds.Tables[0];
            }
        }
        public static DataTable ApproveTradingTerm(string ContractNo, string Status, string vendorNo, string NgayHieuLuc)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();

                    // Luu y: con này ko có trên con db test và ko có quyền tạo các db từ con 42 và 51
                    SqlCommand cmd = new SqlCommand("SP_TRADING_BIBO_Duyet_TERM_Duyet2", con);//SP_TRADING_TERM_Duyet
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("status", Status));
                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", NgayHieuLuc));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADING_BIBO_Duyet_TERM_Duyet2");
                return ds.Tables[0];
            }
        }
        public static bool SP_Status_Trading_Term_UPDATE(string ID, string Status)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Status_Trading_Term_UPDATE", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Status_Trading_Term_UPDATE");
                    return false;
                }
            }
        }
        public static bool Update_Status_TradingTermVendor_Chang02(string ID, string Status, string NguoiGuiDuyet)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_TradingTermVendor_Chang02", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("NguoiGuiDuyet", NguoiGuiDuyet));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_TradingTermVendor_Chang02");
                    return false;
                }
            }
        }
        public static bool Update_Status_TradingTermVendor_Chang_Duyet(string ID, string Status, string NguoiGuiDuyet)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_TradingTermVendor_Chang_Duyet", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("NguoiGuiDuyet", NguoiGuiDuyet));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_TradingTermVendor_Chang_Duyet");
                    return false;
                }
            }
        }

        //public static user_Item BBM_MP_TradingTern_Login_User(int way, int type, user_Item it)
        //{
        //    LogBuild.CreateLogger(way.ToString(), "BBM_MP_TradingTern_Login_User");
        //    LogBuild.CreateLogger(type.ToString(), "BBM_MP_TradingTern_Login_User");
        //    LogBuild.CreateLogger(JsonConvert.SerializeObject(it), "BBM_MP_TradingTern_Login_User");

        //    user_Item itr = new user_Item();
        //    try
        //    {
        //        using (var con = new SqlConnection(strConn))
        //        {
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand("BBM_MP_TradingTern_Login_User", con);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add(new SqlParameter("UserId", it.userName));
        //            cmd.Parameters.Add(new SqlParameter("Password", it.password));
        //            //cmd.Parameters.Add(new SqlParameter("token", it.token != null ? it.token.Replace(" ", "+") : ""));

        //            var reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                user_Item su = new user_Item
        //                {
        //                    userName = reader["userName"].ToString(),
        //                    password = reader["password"].ToString()
        //                };
        //                itr = su;
        //            }
        //            con.Close();
        //            return itr;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "BBM_MP_TradingTern_Login_User");
        //        return itr;
        //    }
        //}
        public static List<objCoopInfoVendor> SP_TRADTERM_GET_COOP_INFO_VENDOR(string vendorNo)
        {
            List<objCoopInfoVendor> it_r = new List<objCoopInfoVendor>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_khancap_20211230", con);//SP_TRADTERM_GET_COOP_INFO_VENDOR
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCoopInfoVendor it = new objCoopInfoVendor
                        {
                            Sale_LastYear = reader["DTY_1"].ToString(),
                            SaleYTD = reader["DTYTD"].ToString(),
                            SalesEstimateCurrYear = reader["DTFullYear"].ToString(),
                            CountItem_Store = reader["SoCHCaiAR"].ToString(),
                            SalesLossOOS = reader["SaleLost"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_COOP_INFO_VENDOR");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_ApDung()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_ApDung", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_ApDung");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_KyThanhToan()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_KyThanhToan", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_KyThanhToan");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_LoaiDonHang()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_LoaiDonHang", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_LoaiDonHang");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_TT_PhatTrienThuongHieu()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_TT_PhatTrienThuongHieu", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_TT_PhatTrienThuongHieu");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_TT_PhatTrienKhachHang()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_TT_PhatTrienKhachHang", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_TT_PhatTrienKhachHang");
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
        public static List<objCombox> SP_MD_TT_Thuong()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_MD_TT_Thuong", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_MD_TT_Thuong");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_TT_ChiPhiBanHang()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_TT_ChiPhiBanHang", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_TT_ChiPhiBanHang");
                    return it_r;
                }
            }
        }
        public static List<objCONTENT_RETURNS_GOODS> SP_TRADTERM_GET_CONTENT_RETURNS_GOODS()
        {
            List<objCONTENT_RETURNS_GOODS> it_r = new List<objCONTENT_RETURNS_GOODS>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_CONTENT_RETURNS_GOODS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCONTENT_RETURNS_GOODS it = new objCONTENT_RETURNS_GOODS
                        {
                            contentApply = reader["contentApply"].ToString(),
                            changeReturns = reader["changeReturns"].ToString(),
                            refundTerm = reader["refundTerm"].ToString(),
                            Penalty = reader["Penalty"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_CONTENT_RETURNS_GOODS");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_TT_LOAIPO()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_TT_LOAIPO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_TT_LOAIPO");
                    return it_r;
                }
            }
        }
        public static List<objCombox> Get_M2FGross_ThueKe(string MaHang)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_M2FGross_ThueKe", con);
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
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_M2FGross_ThueKe");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_TT_THUONG()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_TT_THUONG", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_TT_THUONG");
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
        public static bool SP_TRADTERM_INSERT_COOPERATION_OTHER(string IDContractNo, string ContractNo, string VendorNo, string content1, string content2, string content3, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_COOPERATION_OTHER", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("content1", content1));
                    cmd.Parameters.Add(new SqlParameter("content2", content2));
                    cmd.Parameters.Add(new SqlParameter("content3", content3));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_COOPERATION_OTHER");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_PAYMENT(string IDContractNo, string ContractNo, string VendorNo, string TypeOrder, string PaymentPeriod, string OnDay, string AndDay, string ApplyFor, string Content, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_PAYMENT", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("TypeOrder", TypeOrder));
                    cmd.Parameters.Add(new SqlParameter("PaymentPeriod", PaymentPeriod));
                    cmd.Parameters.Add(new SqlParameter("OnDay", OnDay));
                    cmd.Parameters.Add(new SqlParameter("AndDay", AndDay));
                    cmd.Parameters.Add(new SqlParameter("ApplyFor", ApplyFor));
                    cmd.Parameters.Add(new SqlParameter("Content", Content));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_PAYMENT");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_APPLY_RETURN_PRODUCT(string IDContractNo, string ContractNo, string VendorNo, string Satus, string refundTerm, string Penalty, string confirmChange, string Conten, string BaoTruocNgay, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_APPLY_RETURN_PRODUCT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("confirmChange", confirmChange));
                    cmd.Parameters.Add(new SqlParameter("Conten", Conten));
                    cmd.Parameters.Add(new SqlParameter("BaoTruocNgay", BaoTruocNgay));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    cmd.Parameters.Add(new SqlParameter("Satus", Satus));
                    cmd.Parameters.Add(new SqlParameter("refundTerm", refundTerm));
                    cmd.Parameters.Add(new SqlParameter("Penalty", Penalty));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_APPLY_RETURN_PRODUCT");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_CUSTOMER_BONUS(string IDContractNo, string ContractNo, string VendorNo, string content_invest, string percent_invest, string invest_value, string Description, string salesConditions, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_CUSTOMER_BONUS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("content_invest", content_invest));
                    cmd.Parameters.Add(new SqlParameter("percent_invest", Decimal.Parse(percent_invest.Replace(",", "") != "" ? percent_invest.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("invest_value", Decimal.Parse(invest_value.Replace(",", "") != "" ? invest_value.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Description", Description));
                    cmd.Parameters.Add(new SqlParameter("salesConditions", salesConditions));

                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_CUSTOMER_BONUS");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_BRAND_BONUS(string IDContractNo, string ContractNo, string VendorNo, string content_invest, string percent_invest, string invest_value, string Description, string salesConditions, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_BRAND_BONUS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("content_invest", content_invest));
                    cmd.Parameters.Add(new SqlParameter("percent_invest", Decimal.Parse(percent_invest.Replace(",", "") != "" ? percent_invest.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("invest_value", Decimal.Parse(invest_value.Replace(",", "") != "" ? invest_value.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Description", Description));
                    cmd.Parameters.Add(new SqlParameter("salesConditions", salesConditions));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_BRAND_BONUS");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_MKT_BONUS(string IDContractNo, string ContractNo, string VendorNo, string content_invest, string percent_invest, string invest_value, string Description, string salesConditions, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_MKT_BONUS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));

                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("content_invest", content_invest));
                    cmd.Parameters.Add(new SqlParameter("percent_invest", Decimal.Parse(percent_invest.Replace(",", "") != "" ? percent_invest.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("invest_value", Decimal.Parse(invest_value.Replace(",", "") != "" ? invest_value.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Description", Description));
                    cmd.Parameters.Add(new SqlParameter("salesConditions", salesConditions));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_MKT_BONUS");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_LEADTIME(string IDContractNo, string ContractNo, string VendorNo, string Leadtimesx, string ThoiGianKyHD, string ThanhToan, string DongCongVaHQXuat, string DiBien, string ThuTucHQDauNhap, string TongLeadtime, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_LEADTIME", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("Leadtimesx", Leadtimesx));
                    cmd.Parameters.Add(new SqlParameter("ThoiGianKyHD", ThoiGianKyHD));
                    cmd.Parameters.Add(new SqlParameter("ThanhToan", ThanhToan));
                    cmd.Parameters.Add(new SqlParameter("DongCongVaHQXuat", DongCongVaHQXuat));
                    cmd.Parameters.Add(new SqlParameter("DiBien", DiBien));
                    cmd.Parameters.Add(new SqlParameter("ThuTucHQDauNhap", ThuTucHQDauNhap));
                    cmd.Parameters.Add(new SqlParameter("TongLeadtime", TongLeadtime));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_LEADTIME");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_CHIPHIVANHANH(string IDContractNo, string ContractNo, string VendorNo, string NoiDungDauTu, string PTDauTu, string GiaTriDauTu, string DieuKien, string salesConditions, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_CHIPHIVANHANH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("NoiDungDauTu", NoiDungDauTu));
                    cmd.Parameters.Add(new SqlParameter("PTDauTu", PTDauTu));
                    cmd.Parameters.Add(new SqlParameter("GiaTriDauTu", GiaTriDauTu));
                    cmd.Parameters.Add(new SqlParameter("DieuKien", DieuKien));
                    cmd.Parameters.Add(new SqlParameter("salesConditions", salesConditions));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_CHIPHIVANHANH");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_LINE_BONUS(string IDContractNo, string ContractNo, string VendorNo, string BonusType, string SalesLevel, string SalesLevelDen, string SalesConditions, string DiscountPercent, string DiscountAmountNoVAT, string Description, string DKDSTinhThuong, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_LINE_BONUS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("BonusType", BonusType));
                    cmd.Parameters.Add(new SqlParameter("SalesLevel", Decimal.Parse(SalesLevel.Replace(",", "") != "" ? SalesLevel.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SalesLevelDen", Decimal.Parse(SalesLevelDen.Replace(",", "") != "" ? SalesLevelDen.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SalesConditions", SalesConditions));
                    cmd.Parameters.Add(new SqlParameter("DiscountPercent", Decimal.Parse(DiscountPercent.Replace(",", "") != "" ? DiscountPercent.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DiscountAmountNoVAT", Decimal.Parse(DiscountAmountNoVAT.Replace(",", "") != "" ? DiscountAmountNoVAT.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Description", Description));
                    cmd.Parameters.Add(new SqlParameter("DKDSTinhThuong", DKDSTinhThuong));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_LINE_BONUS");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_DISCOUNT_QTTY(string IDContractNo, string ContractNo, string VendorNo, string quantityBuy, string QuantityGifts, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_DISCOUNT_QTTY", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("quantityBuy", int.Parse(quantityBuy.Replace(",", "") != "" ? quantityBuy.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("QuantityGifts", int.Parse(QuantityGifts.Replace(",", "") != "" ? QuantityGifts.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_DISCOUNT_QTTY");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_DISCOUNT_SALES(string IDContractNo, string ContractNo, string VendorNo, string DiscountSalesType, string HinhThucThanhToan, string DiscountAmount, string DiscountPercent, string OrderValue, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_DISCOUNT_SALES", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("DiscountSalesType", DiscountSalesType.ToString()));
                    cmd.Parameters.Add(new SqlParameter("HinhThucThanhToan", HinhThucThanhToan.ToString()));
                    cmd.Parameters.Add(new SqlParameter("DiscountAmount", Decimal.Parse(DiscountAmount.Replace(",", "") != "" ? DiscountAmount.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DiscountPercent", DiscountPercent));
                    cmd.Parameters.Add(new SqlParameter("OrderValue", Decimal.Parse(OrderValue.Replace(",", "") != "" ? OrderValue.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_DISCOUNT_SALES");
                    return false;
                }
            }
        }

        // BOXUNG IDContractNo

        public static bool SP_TRADTERM_INSERT_VENDORS_PRODUCT(string IDContractNo, string ContractNo, string VendorNo, string productCode, string productname, string barcode, string p_CoopType, string p_Vat, string p_PriceDiscount, string p_PercentDiscountBill, string p_PriceAfterDiscountBasic, string CreatedBy, string TypeTab, string TinhTrang, string RangeReviewCode, string RangeReviewName, string ThuongDinhHuong)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_VENDORS_PRODUCT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("productCode", productCode));
                    cmd.Parameters.Add(new SqlParameter("productname", productname));
                    cmd.Parameters.Add(new SqlParameter("barcode", barcode));
                    cmd.Parameters.Add(new SqlParameter("p_CoopType", p_CoopType));
                    cmd.Parameters.Add(new SqlParameter("p_Vat", Decimal.Parse(p_Vat.Replace(",", "") != "" ? p_Vat.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("p_PriceDiscount", Decimal.Parse(p_PriceDiscount.Replace(",", ""))));
                    cmd.Parameters.Add(new SqlParameter("p_PercentDiscountBill", Decimal.Parse(p_PercentDiscountBill)));
                    cmd.Parameters.Add(new SqlParameter("p_PriceAfterDiscountBasic", Decimal.Parse(p_PriceAfterDiscountBasic.Replace(",", ""))));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));

                    cmd.Parameters.Add(new SqlParameter("TinhTrang", TinhTrang));
                    cmd.Parameters.Add(new SqlParameter("RangeReviewCode", RangeReviewCode));
                    cmd.Parameters.Add(new SqlParameter("RangeReviewName", RangeReviewName));
                    cmd.Parameters.Add(new SqlParameter("ThuongDinhHuong", Decimal.Parse(ThuongDinhHuong.Replace(",", ""))));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_VENDORS_PRODUCT");
                    return false;
                }
            }
        }

        //IDContractNo
        public static bool SP_TRADTERM_INSERT_VENDORS_PRODUCT_FUNCTION(string IDContractNo, string ContractNo, string VendorNo, string FunctionCode, string FunctionName, string hinhthucht, string p_Vat, string p_PriceDiscount, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_VENDORS_PRODUCT_FUNCTION", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode));
                    cmd.Parameters.Add(new SqlParameter("FunctionName", FunctionName));
                    cmd.Parameters.Add(new SqlParameter("hinhthucht", hinhthucht));
                    cmd.Parameters.Add(new SqlParameter("p_Vat", Decimal.Parse(p_Vat.Replace(",", "").Replace(".", "") != "" ? p_Vat.Replace(",", "").Replace(".", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("p_PriceDiscount", Decimal.Parse(p_PriceDiscount.Replace(".", ""))));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_VENDORS_PRODUCT_FUNCTION");
                    return false;
                }
            }
        }

        public static bool SP_TRADTERM_INSERT_VENDORS_PRODUCT_BRAND(string IDContractNo, string ContractNo, string VendorNo, string BrandCode, string BrandName, string hinhthucht, string p_Vat, string p_PriceDiscount, string CreatedBy, string TypeTab)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_VENDORS_PRODUCT_BRAND", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("BrandName", BrandName));
                    cmd.Parameters.Add(new SqlParameter("hinhthucht", hinhthucht));
                    cmd.Parameters.Add(new SqlParameter("p_Vat", Decimal.Parse(p_Vat.Replace(",", "").Replace(".", "") != "" ? p_Vat.Replace(",", "").Replace(".", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("p_PriceDiscount", Decimal.Parse(p_PriceDiscount.Replace(".", ""))));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("TypeTab", TypeTab));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_VENDORS_PRODUCT_BRAND");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_DELETE_UPDATE(string IDContractNo)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_DELETE_UPDATE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_DELETE_UPDATE");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_DELETE_ContractNo(string IDContractNo)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_DELETE_ContractNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_DELETE_ContractNo");
                    return false;
                }
            }
        }
        public static bool Update_Status_TradingTermVendor(string ID, string HanhDong)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_TradingTermVendor", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_TradingTermVendor");
                    return false;
                }
            }
        }
        public static bool Update_Status_TradingTermVendor_Chang_Send(string ID, string HanhDong, string NguoiGuiDuyet)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_TradingTermVendor_Chang01", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    cmd.Parameters.Add(new SqlParameter("NguoiGuiDuyet", NguoiGuiDuyet));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_TradingTermVendor_Chang_Send");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_UPDATE_CONTRACT(string IDContractNo, string ACM, string CM, string SupplyManager, string priceChangeDate, string ModifiedBy, string FromDate, string ToDate, string TuNgay, string DenNgay)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_UPDATE_CONTRACT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("ACM", ACM));
                    cmd.Parameters.Add(new SqlParameter("CM", CM));
                    cmd.Parameters.Add(new SqlParameter("SupplyManager", SupplyManager));
                    cmd.Parameters.Add(new SqlParameter("priceChangeDate", priceChangeDate));
                    cmd.Parameters.Add(new SqlParameter("ModifiedBy", ModifiedBy));
                    if (String.IsNullOrWhiteSpace(FromDate))
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDate", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("FromDate", DateTime.Parse(FromDate)));
                    }
                    if (String.IsNullOrWhiteSpace(ToDate))
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDate", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ToDate", DateTime.Parse(ToDate)));
                    }
                    if (String.IsNullOrWhiteSpace(TuNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DateTime.Parse(TuNgay)));
                    }
                    if (String.IsNullOrWhiteSpace(DenNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DateTime.Parse(DenNgay)));
                    }
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_UPDATE_CONTRACT");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_UPDATE_CONTRACT_File(string ID, string FilePDF)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_UPDATE_CONTRACT_File", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("FilePDF", FilePDF));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_UPDATE_CONTRACT");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_CONTRACT(string VendorNo, string ContractNo, string FromDate, string ToDate, string ACM, string CM, string SupplyManager, string AutoExtentContract, string AutoExtentContractSoHopDong, string priceChangeDate, string CreatedBy, string Type, string SoPhuLuc, string SoHopDong, string TuNgay, string DenNgay, string FileSoHopDong, string FilePhuLucHopDong, string NguoiDaiDienBBM, string NguoiDaiDienNCC, string TinhTrang, string DaiDienBBM, string DaiDienNCC)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_CONTRACT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", VendorNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("contactNo", ContractNo));
                    if (String.IsNullOrWhiteSpace(FromDate))
                    {
                        cmd.Parameters.Add(new SqlParameter("fdate", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("fdate", DateTime.Parse(FromDate)));
                    }
                    if (String.IsNullOrWhiteSpace(ToDate))
                    {
                        cmd.Parameters.Add(new SqlParameter("tdate", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("tdate", DateTime.Parse(ToDate)));
                    }
                    cmd.Parameters.Add(new SqlParameter("ACM", ACM));
                    cmd.Parameters.Add(new SqlParameter("CM", CM));
                    cmd.Parameters.Add(new SqlParameter("SupplyManager", SupplyManager));
                    cmd.Parameters.Add(new SqlParameter("AutoExtentContract", Int64.Parse(AutoExtentContract)));
                    cmd.Parameters.Add(new SqlParameter("AutoExtentContractSoHopDong", Int64.Parse(AutoExtentContractSoHopDong)));
                    cmd.Parameters.Add(new SqlParameter("priceChangeDate", priceChangeDate));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("SoPhuLuc", SoPhuLuc));
                    cmd.Parameters.Add(new SqlParameter("SoHopDong", SoHopDong));
                    if (String.IsNullOrWhiteSpace(TuNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DateTime.Parse(TuNgay)));
                    }
                    if (String.IsNullOrWhiteSpace(DenNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DateTime.Parse(DenNgay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("FileSoHopDong", FileSoHopDong));
                    cmd.Parameters.Add(new SqlParameter("FilePhuLucHopDong", FilePhuLucHopDong));

                    cmd.Parameters.Add(new SqlParameter("NguoiDaiDienBBM", NguoiDaiDienBBM));
                    cmd.Parameters.Add(new SqlParameter("NguoiDaiDienNCC", NguoiDaiDienNCC));
                    cmd.Parameters.Add(new SqlParameter("TinhTrang", TinhTrang));

                    cmd.Parameters.Add(new SqlParameter("DaiDienBBM", DaiDienBBM));
                    cmd.Parameters.Add(new SqlParameter("DaiDienNCC", DaiDienNCC));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_CONTRACT");
                    return false;
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

        public static List<objCombox> SP_TRADTERM_GET_VendorName_Contract()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_VendorName_Contract", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_VendorName_Contract");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_TRADTERM_GET_Vendor_Contract()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor_Contract", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_Vendor_Contract");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_Vendor_Contract_VendorNo(string VendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor_Contract_VendorNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_Vendor_Contract_VendorNo");
                    return it_r;
                }
            }
        }


        public static List<objCombox> SP_TRADTERM_GET_Vendor_Contract_SoHD()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor_Contract_SoHD", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_Vendor_Contract_SoHD");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_TRADTERM_GET_Vendor_Contract_SoHD_VendorNo(string VendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor_Contract_SoHD_VendorNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_Vendor_Contract_SoHD_VendorNo");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_TRADTERM_GET_Vendor_NguonNhap()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor_NguonNhap", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_Vendor_NguonNhap");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_TRADTERM_GETLIST_ITEM(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GETLIST_ITEM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GETLIST_ITEM");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_TRADTERM_GETLIST_ITEM_HangHoa_KyGui(string vendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GETLIST_ITEM_HangHoa_KyGui", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GETLIST_ITEM_HangHoa_KyGui");
                    return it_r;
                }
            }
        }

        public static List<HoangHoa> GetListItemVendor_Function_ThueKe(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Function_ThueKe", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function_ThueKe");
                    return it_r;
                }
            }
        }
        public static List<HoangHoa> GetListItemVendor_Function_Create(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Function_Create", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function_Create");
                    return it_r;
                }
            }
        }

        public static List<HoangHoa> GetListItemVendor_Function_ThueKe_Create(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Function_ThueKe_Create", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function_ThueKe_Create");
                    return it_r;
                }
            }
        }
        public static List<HoangHoa> GetListItemVendor_Function_KyGui_Create(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Function_KyGui_Create", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function_KyGui_Create");
                    return it_r;
                }
            }
        }
        public static List<HoangHoa> GetListItemVendor_Function(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Function", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function");
                    return it_r;
                }
            }
        }
        public static List<HoangHoa> GetListItemVendor_Function_KyGui(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Function_KyGui", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function_KyGui");
                    return it_r;
                }
            }
        }
        public static List<HoangHoa> GetListItemVendor_Brand_ThueKe(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Brand_ThueKe", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Brand_ThueKe");
                    return it_r;
                }
            }
        }

        public static List<HoangHoa> GetListItemVendor_MuaBan_Brand_Create(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_MuaBan_Brand_Create", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_MuaBan_Brand_Create");
                    return it_r;
                }
            }
        }
        public static List<HoangHoa> GetListItemVendor_Brand(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Brand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Brand");
                    return it_r;
                }
            }
        }
        public static List<HoangHoa> GetListItemVendor_Brand_KyGui_Create(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Brand_KyGui_Create", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Brand_KyGui_Create");
                    return it_r;
                }
            }
        }
        public static List<HoangHoa> GetListItemVendor_Brand_ThueKe_Create(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Brand_ThueKe_Create", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Brand_ThueKe_Create");
                    return it_r;
                }
            }
        }
        public static List<HoangHoa> GetListItemVendor_Product_ThueKe_Create(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Product_ThueKe_Create", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Product_ThueKe_Create");
                    return it_r;
                }
            }
        }
        public static List<HoangHoa> GetListItemVendor_Brand_KyGui(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_Brand_KyGui", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Brand_KyGui");
                    return it_r;
                }
            }
        }
        //BOXUNG
        public static List<APDung_HoangHoa_New> GetListItemVendor_HangHoa_ThueKe(string vendorNo)
        {
            List<APDung_HoangHoa_New> it_r = new List<APDung_HoangHoa_New>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_HangHoa_ThueKe", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        APDung_HoangHoa_New it = new APDung_HoangHoa_New
                        {
                            MaSP = reader["MaSP"].ToString(),
                            NameProduct = reader["NameProduct"].ToString(),
                            Barcode = reader["Barcode"].ToString(),
                            M2netSP = reader["M2netSP"].ToString(),
                            M2FGrossSP = reader["M2FGrossSP"].ToString(),
                            SoCHPhu = reader["SoCHPhu"].ToString(),
                            SoMatTBCH = reader["SoMatTBCH"].ToString(),
                            Mien = reader["Mien"].ToString(),
                            NgayBatDau = reader["NgayBatDau"].ToString(),
                            NgayKetThuc = reader["NgayKetThuc"].ToString(),
                            NgaybatDauThue = reader["NgaybatDauThue"].ToString(),
                            NgayDieuChinhKetThuc = reader["NgayDieuChinhKetThuc"].ToString(),
                            TuDongGiaHan = reader["TuDongGiaHan"].ToString(),
                            HieuLuc = reader["HieuLuc"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_HangHoa_ThueKe");
                    return it_r;
                }
            }
        }

        // BXUNG
        public static DataTable SP_TRADTERM_ApDungSp_HHOA_TK_KGUI(string vendorNo, string Type, string MaSpSKU, string TenSpSKU, string RangeReview)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_ApDungSp_HHOA_TK_KGUI", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("MaSP", MaSpSKU));
                    cmd.Parameters.Add(new SqlParameter("TenSP", TenSpSKU));
                    cmd.Parameters.Add(new SqlParameter("RangeReview", RangeReview));

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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_ApDungSp_HHOA_TK_KGUI");
                return ds.Tables[0];
            }
        }

        public static DataTable SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_Detail_Edit(string vendorNo, string IDContractNo, string Type, string MaSpSKU, string TenSpSKU, string RangeReview)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_Detail_Edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("MaSP", MaSpSKU));
                    cmd.Parameters.Add(new SqlParameter("TenSP", TenSpSKU));
                    cmd.Parameters.Add(new SqlParameter("RangeReview", RangeReview));

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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_Detail_Edit");
                return ds.Tables[0];
            }
        }



        //public static List<APDung_HoangHoa> SP_TRADTERM_ApDungSp_HHOA_TK_KGUI(string vendorNo, string Type)
        //{
        //    List<APDung_HoangHoa> it_r = new List<APDung_HoangHoa>();
        //    using (var con = new SqlConnection(strConn))
        //    {
        //        con.Open();
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("SP_TRADTERM_ApDungSp_HHOA_TK_KGUI", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
        //            cmd.Parameters.Add(new SqlParameter("Type", Type));
        //            var reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                APDung_HoangHoa it = new APDung_HoangHoa
        //                {
        //                    MaSP = reader["MaSP"].ToString(),
        //                    TenSP = reader["TenSP"].ToString(),
        //                    Barcode = reader["Barcode"].ToString(),
        //                    VAT = reader["VAT"].ToString(),
        //                    Price = reader["Price"].ToString(),
        //                    PhanTramCK = reader["PhanTramCK"].ToString()
        //                };
        //                it_r.Add(it);
        //            }
        //            con.Close();
        //            return it_r;
        //        }
        //        catch (Exception ex)
        //        {
        //            con.Close();
        //            LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_ApDungSp_HHOA_TK_KGUI");
        //            return it_r;
        //        }
        //    }
        //}
        public static List<HoangHoa> GetListItemVendor_KyGui(string vendorNo)
        {
            List<HoangHoa> it_r = new List<HoangHoa>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListItemVendor_KyGui", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HoangHoa it = new HoangHoa
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            GiaApDungCK = reader["GiaApDungCK"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_KyGui");
                    return it_r;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_RENT_PRODUCT(string IDContractNo, string ContractNo, string VendorNo, string productCode, string productname, string barcode, string M2netSP, string M2FGrossSP, string CoatingShop, string NumberFace, string Mien, string NgayBatDau, string NgayKetThuc, string NgaybatDauThue, string NgayDieuChinhKetThuc, string TuDongGiaHan, string HieuLuc, string CreatedBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_RENT_PRODUCT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));

                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("productCode", productCode));
                    cmd.Parameters.Add(new SqlParameter("productname", productname));
                    cmd.Parameters.Add(new SqlParameter("barcode", barcode));

                    cmd.Parameters.Add(new SqlParameter("M2netSP", Decimal.Parse(M2netSP.Replace(",", "") != "" ? M2netSP.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("M2FGrossSP", Decimal.Parse(M2FGrossSP.Replace(",", "") != "" ? M2FGrossSP.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("CoatingShop", Decimal.Parse(CoatingShop.Replace(",", "") != "" ? CoatingShop.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("NumberFace", Decimal.Parse(NumberFace.Replace(",", "") != "" ? NumberFace.Replace(",", "") : "0")));

                    cmd.Parameters.Add(new SqlParameter("Mien", Mien));

                    if (String.IsNullOrWhiteSpace(NgayBatDau))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayBatDau", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayBatDau", DateTime.Parse(NgayBatDau)));
                    }
                    if (String.IsNullOrWhiteSpace(NgayKetThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DateTime.Parse(NgayKetThuc)));
                    }
                    //--
                    if (String.IsNullOrWhiteSpace(NgaybatDauThue))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaybatDauThue", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaybatDauThue", DateTime.Parse(NgaybatDauThue)));
                    }
                    if (String.IsNullOrWhiteSpace(NgayDieuChinhKetThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayDieuChinhKetThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayDieuChinhKetThuc", DateTime.Parse(NgayDieuChinhKetThuc)));
                    }
                    cmd.Parameters.Add(new SqlParameter("TuDongGiaHan", TuDongGiaHan));

                    cmd.Parameters.Add(new SqlParameter("HieuLuc", HieuLuc));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_VENDORS_PRODUCT");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_BRAND_THUEKE_PRODUCT(string IDContractNo, string ContractNo, string VendorNo, string BrandCode, string BrandName, string SoCuaHangThue, string SoThang, string M2FThueCuaHang, string ChiPhiThueThangVAT, string TongChiPhiThueThangVAT, string TongChiPhiThueNam, string DSCamKetCuaHang, string NgayKyHD, string NgayHetHanHD, string NgaybatDauThue, string NgayDieuChinhKetThuc, string checkTuDongGiaHan, string HieuLuc, string CreatedBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_BRAND_THUEKE_PRODUCT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("BrandName", BrandName));

                    cmd.Parameters.Add(new SqlParameter("SoCuaHangThue", SoCuaHangThue));
                    cmd.Parameters.Add(new SqlParameter("SoThang", SoThang));
                    cmd.Parameters.Add(new SqlParameter("M2FThueCuaHang", M2FThueCuaHang));

                    cmd.Parameters.Add(new SqlParameter("ChiPhiThueThangVAT", ChiPhiThueThangVAT));
                    cmd.Parameters.Add(new SqlParameter("TongChiPhiThueThangVAT", TongChiPhiThueThangVAT));
                    cmd.Parameters.Add(new SqlParameter("TongChiPhiThueNam", TongChiPhiThueNam));
                    cmd.Parameters.Add(new SqlParameter("DSCamKetCuaHang", DSCamKetCuaHang));

                    if (String.IsNullOrWhiteSpace(NgayKyHD))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKyHD", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKyHD", DateTime.Parse(NgayKyHD)));
                    }

                    if (String.IsNullOrWhiteSpace(NgayHetHanHD))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHetHanHD", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHetHanHD", DateTime.Parse(NgayHetHanHD)));
                    }
                    if (String.IsNullOrWhiteSpace(NgaybatDauThue))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaybatDauThue", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaybatDauThue", DateTime.Parse(NgaybatDauThue)));
                    }

                    if (String.IsNullOrWhiteSpace(NgayDieuChinhKetThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayDieuChinhKetThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayDieuChinhKetThuc", DateTime.Parse(NgayDieuChinhKetThuc)));
                    }
                    cmd.Parameters.Add(new SqlParameter("checkTuDongGiaHan", checkTuDongGiaHan));

                    cmd.Parameters.Add(new SqlParameter("HieuLuc", HieuLuc));

                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_BRAND_THUEKE_PRODUCT");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_FUNCTION_THUEKE_PRODUCT(string IDContractNo, string ContractNo, string VendorNo, string FunctionCode, string FunctionName, string barcode, string M2netSP, string M2FGrossSP, string CoatingShop, string NumberFace, string NgayBatDau, string NgayKetThuc, string HieuLuc, string CreatedBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_FUNCTION_THUEKE_PRODUCT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode));
                    cmd.Parameters.Add(new SqlParameter("FunctionName", FunctionName));
                    cmd.Parameters.Add(new SqlParameter("barcode", barcode));

                    cmd.Parameters.Add(new SqlParameter("M2netSP", Decimal.Parse(M2netSP.Replace(",", "") != "" ? M2netSP.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("M2FGrossSP", Decimal.Parse(M2FGrossSP.Replace(",", "") != "" ? M2FGrossSP.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("CoatingShop", Decimal.Parse(CoatingShop.Replace(",", "") != "" ? CoatingShop.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("NumberFace", Decimal.Parse(NumberFace.Replace(",", "") != "" ? NumberFace.Replace(",", "") : "0")));

                    if (String.IsNullOrWhiteSpace(NgayBatDau))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayBatDau", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayBatDau", DateTime.Parse(NgayBatDau)));
                    }
                    if (String.IsNullOrWhiteSpace(NgayKetThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DateTime.Parse(NgayKetThuc)));
                    }

                    cmd.Parameters.Add(new SqlParameter("HieuLuc", HieuLuc));

                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_FUNCTION_THUEKE_PRODUCT");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_INSERT_THUEKE_THONGTINCHUNG(string IDContractNo, string ContractNo, string VendorNo, string SoCuaHangThue, string SoThang, string M2FThueCuaHang, string ChiPhiThueThangVAT, string TongChiPhiThueThangVAT, string TongChiPhiThueNam, string DSCamKetCuaHang, string Mien, string NgayKyHD, string NgayHetHanHD, string NgaybatDauThue, string NgayDieuChinhKetThuc, string checkTuDongGiaHan, string HieuLuc, string CreatedBy)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_INSERT_THUEKE_THONGTINCHUNG", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo.ToString()));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo.ToString()));

                    cmd.Parameters.Add(new SqlParameter("SoCuaHangThue", Decimal.Parse(SoCuaHangThue.Replace(",", "") != "" ? SoCuaHangThue.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SoThang", Decimal.Parse(SoThang.Replace(",", "") != "" ? SoThang.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("M2FThueCuaHang", Decimal.Parse(M2FThueCuaHang.Replace(",", "") != "" ? M2FThueCuaHang.Replace(",", "") : "0")));

                    cmd.Parameters.Add(new SqlParameter("ChiPhiThueThangVAT", Decimal.Parse(ChiPhiThueThangVAT.Replace(",", "") != "" ? ChiPhiThueThangVAT.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("TongChiPhiThueThangVAT", Decimal.Parse(TongChiPhiThueThangVAT.Replace(",", "") != "" ? TongChiPhiThueThangVAT.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("TongChiPhiThueNam", Decimal.Parse(TongChiPhiThueNam.Replace(",", "") != "" ? TongChiPhiThueNam.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DSCamKetCuaHang", Decimal.Parse(DSCamKetCuaHang.Replace(",", "") != "" ? DSCamKetCuaHang.Replace(",", "") : "0")));

                    cmd.Parameters.Add(new SqlParameter("Mien", Mien));

                    if (String.IsNullOrWhiteSpace(NgayKyHD))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKyHD", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKyHD", DateTime.Parse(NgayKyHD)));
                    }

                    if (String.IsNullOrWhiteSpace(NgayHetHanHD))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHetHanHD", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHetHanHD", DateTime.Parse(NgayHetHanHD)));
                    }
                    if (String.IsNullOrWhiteSpace(NgaybatDauThue))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaybatDauThue", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaybatDauThue", DateTime.Parse(NgaybatDauThue)));
                    }

                    if (String.IsNullOrWhiteSpace(NgayDieuChinhKetThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayDieuChinhKetThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayDieuChinhKetThuc", DateTime.Parse(NgayDieuChinhKetThuc)));
                    }
                    cmd.Parameters.Add(new SqlParameter("checkTuDongGiaHan", checkTuDongGiaHan));
                    cmd.Parameters.Add(new SqlParameter("HieuLuc", HieuLuc));

                    cmd.Parameters.Add(new SqlParameter("CreatedBy", CreatedBy));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_INSERT_FUNCTION_THUEKE_PRODUCT");
                    return false;
                }
            }
        }
        public static List<objRentProduct> SP_TRADTERM_LIST_RENT_PRODUCT(string IDContractNo)
        {
            List<objRentProduct> it_r = new List<objRentProduct>();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_RENT_PRODUCT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objRentProduct it = new objRentProduct
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            productcode = reader["productcode"].ToString(),
                            productname = reader["productname"].ToString(),
                            barcode = reader["barcode"].ToString(),
                            M2netSP = reader["M2netSP"].ToString(),
                            M2FGrossSP = reader["M2FGrossSP"].ToString(),
                            CoatingShop = reader["CoatingShop"].ToString(),
                            NumberFace = reader["NumberFace"].ToString(),
                            Mien = reader["Mien"].ToString(),
                            NgayBatDau = reader["NgayBatDau"].ToString(),
                            NgayKetThuc = reader["NgayKetThuc"].ToString(),
                            NgaybatDauThue = reader["NgaybatDauThue"].ToString(),
                            NgayDieuChinhKetThuc = reader["NgayDieuChinhKetThuc"].ToString(),
                            TuDongGiaHan = reader["TuDongGiaHan"].ToString(),
                            HieuLuc = reader["HieuLuc"].ToString()

                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_RENT_PRODUCT");
                    return it_r;
                }
            }
        }
        public static List<objRentProduct_Brand> SP_TRADTERM_LIST_BRAND_PRODUCT_THUEKE(string IDContractNo)
        {
            List<objRentProduct_Brand> it_r = new List<objRentProduct_Brand>();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_BRAND_PRODUCT_THUEKE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objRentProduct_Brand it = new objRentProduct_Brand
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            SoCuaHangThue = reader["SoCuaHangThue"].ToString(),
                            SoThang = reader["SoThang"].ToString(),
                            M2FThueCuaHang = reader["M2FThueCuaHang"].ToString(),
                            ChiPhiThueThangVAT = reader["ChiPhiThueThangVAT"].ToString(),
                            TongChiPhiThueThangVAT = reader["TongChiPhiThueThangVAT"].ToString(),
                            TongChiPhiThueNam = reader["TongChiPhiThueNam"].ToString(),
                            DSCamKetCuaHang = reader["DSCamKetCuaHang"].ToString(),
                            NgayKyHD = reader["NgayKyHD"].ToString(),
                            NgayHetHanHD = reader["NgayHetHanHD"].ToString(),
                            NgaybatDauThue = reader["NgaybatDauThue"].ToString(),
                            NgayDieuChinhKetThuc = reader["NgayDieuChinhKetThuc"].ToString(),
                            checkTuDongGiaHan = reader["checkTuDongGiaHan"].ToString(),
                            HieuLuc = reader["HieuLuc"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_BRAND_PRODUCT_THUEKE");
                    return it_r;
                }
            }
        }
        public static List<objThongTinChung> SP_TRADTERM_LIST_THUEKE_THONGTINCHUNG(string IDContractNo)
        {
            List<objThongTinChung> it_r = new List<objThongTinChung>();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_THUEKE_THONGTINCHUNG", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objThongTinChung it = new objThongTinChung
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
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
                            checkTuDongGiaHan = reader["checkTuDongGiaHan"].ToString(),
                            HieuLuc = reader["HieuLuc"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_THUEKE_THONGTINCHUNG");
                    return it_r;
                }
            }
        }
        public static List<objRentProduct_Function> SP_TRADTERM_LIST_FUNCTION_PRODUCT_THUEKE(string IDContractNo)
        {
            List<objRentProduct_Function> it_r = new List<objRentProduct_Function>();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_LIST_FUNCTION_PRODUCT_THUEKE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo ", IDContractNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objRentProduct_Function it = new objRentProduct_Function
                        {
                            VendorNo = reader["VendorNo"].ToString(),
                            ContractNo = reader["ContractNo"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            barcode = reader["barcode"].ToString(),
                            M2netSP = reader["M2netSP"].ToString(),
                            M2FGrossSP = reader["M2FGrossSP"].ToString(),
                            CoatingShop = reader["CoatingShop"].ToString(),
                            NumberFace = reader["NumberFace"].ToString(),
                            NgayBatDau = reader["NgayBatDau"].ToString(),
                            NgayKetThuc = reader["NgayKetThuc"].ToString(),
                            HieuLuc = reader["HieuLuc"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_FUNCTION_PRODUCT_THUEKE");
                    return it_r;
                }
            }
        }



        public static List<objCombox> Get_ID_TRADTERM_CONTRACT_ContractNo(string vendorNo, string ContractNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_ID_TRADTERM_CONTRACT_ContractNo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_ID_TRADTERM_CONTRACT_ContractNo");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_SoPhuLuc_Vendor(string VendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_SoPhuLuc_Vendor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_SoPhuLuc_Vendor");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_SKU_RangeReview()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_SKU_RangeReview", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_SKU_RangeReview");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_Vendor_detail(string VendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_GET_Vendor_detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
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
        public static List<ThongTinChung> SP_TRADTERM_ThongTinChungTheKe_ApDung(string VendorNo)
        {
            List<ThongTinChung> it_r = new List<ThongTinChung>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_ThongTinChungTheKe_ApDung", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ThongTinChung it = new ThongTinChung
                        {
                            SoCHThue = reader["SoCHThue"].ToString(),
                            SoThang = reader["SoThang"].ToString(),

                            M2FThue = reader["M2FThue"].ToString(),
                            CpThueCHThang = reader["CpThueCHThang"].ToString(),
                            TongPhiThueThang = reader["TongPhiThueThang"].ToString(),
                            TongPhiThueNam = reader["TongPhiThueNam"].ToString(),
                            DScamketThangCH = reader["DScamketThangCH"].ToString(),
                            Mien = reader["Mien"].ToString(),
                            NgayKyHD = reader["NgayKyHD"].ToString(),


                            NgayHetHan = reader["NgayHetHan"].ToString(),
                            NgayBatDauTinhTienThue = reader["NgayBatDauTinhTienThue"].ToString(),
                            NgayDieuChinhKetThuc = reader["NgayDieuChinhKetThuc"].ToString(),
                            TuDongGiaHan = reader["TuDongGiaHan"].ToString(),
                            HieuLuc = reader["HieuLuc"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_ThongTinChungTheKe_ApDung");
                    return it_r;
                }
            }
        }
        public static List<DanhMucSanPham_ApDung> SP_TRADTERM_DanhMuCSanPham_ApDung(string VendorNo)
        {
            List<DanhMucSanPham_ApDung> it_r = new List<DanhMucSanPham_ApDung>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_DanhMuCSanPham_ApDung", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DanhMucSanPham_ApDung it = new DanhMucSanPham_ApDung
                        {

                            MaSP = reader["MaSP"].ToString(),
                            NameProduct = reader["NameProduct"].ToString(),
                            Barcode = reader["Barcode"].ToString(),
                            M2netSP = reader["M2netSP"].ToString(),
                            M2FGrossSP = reader["M2FGrossSP"].ToString(),
                            SoCHPhu = reader["SoCHPhu"].ToString(),
                            SoMatTBCH = reader["SoMatTBCH"].ToString(),
                            Mien = reader["Mien"].ToString(),
                            NgayBatDau = reader["NgayBatDau"].ToString(),
                            NgayKetThuc = reader["NgayKetThuc"].ToString(),

                            NgaybatDauThue = reader["NgaybatDauThue"].ToString(),
                            NgayDieuChinhKetThuc = reader["NgayDieuChinhKetThuc"].ToString(),
                            TuDongGiaHan = reader["TuDongGiaHan"].ToString(),
                            HieuLuc = reader["HieuLuc"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_DanhMuCSanPham_ApDung");
                    return it_r;
                }
            }
        }
        public static bool SP_TRADTERM_SanPham_ThueKe_VietDung(string IDContractNo, string ContractNo, string VendorNo)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_SanPham_ThueKe_VietDung", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_SanPham_ThueKe_VietDung");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_TTCHUNG_ThueKe_VietDung(string IDContractNo, string ContractNo, string VendorNo)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_TTCHUNG_ThueKe_VietDung", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_TTCHUNG_ThueKe_VietDung");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_N1(string IDContractNo, string ContractNo, string VendorNo, string Type)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_N1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_N1");
                    return false;
                }
            }
        }
        public static bool SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_N2_KG(string IDContractNo, string ContractNo, string VendorNo, string Type)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_N2_KG", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDContractNo", IDContractNo));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_N2_KG");
                    return false;
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
        public static List<objCombox> sp_VendorTool_MD_Sub_get_tradingtem()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_VendorTool_MD_Sub_get_tradingtem", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VendorTool_MD_Sub_get_tradingtem");
                    return it_r;
                }
            }
        }
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
                    cmd.CommandTimeout = 3000000;
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


    }
}