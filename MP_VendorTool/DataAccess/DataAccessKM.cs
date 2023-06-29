using Lib.Utils.Package;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using MP_VendorTool.Models;
using MP_VendorTool.Models.Promotion;
using Newtonsoft.Json;

namespace MP_VendorTool.DataAccess
{
    public class DataAccessKM
    {
        private static string strCon = ConfigurationManager.AppSettings.Get("strConnSpac");
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        public static List<objCombox> GetCodeCTKM()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_TAO_MACTKM", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetCodeCTKM");
                    return it_r;
                }
            }
        }

        public static List<ObjComboxCTKM> SP_BIBOSMART_KM_LIST_COMBOX_FROM()
        {
            List<ObjComboxCTKM> it_r = new List<ObjComboxCTKM>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LIST_COMBOX_FROM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjComboxCTKM it = new ObjComboxCTKM
                        {
                            Store_GType_Value = reader["Store_GType_Value"].ToString(),
                            Store_GType_Name = reader["Store_GType_Name"].ToString(),
                            StoreGroup_Value = reader["StoreGroup_Value"].ToString(),
                            StoreGroup_Name = reader["StoreGroup_Name"].ToString(),
                            DiscountType_Value = reader["DiscountType_Value"].ToString(),
                            DiscountType_Name = reader["DiscountType_Name"].ToString(),
                            LineSpecific_Value = reader["LineSpecific_Value"].ToString(),
                            LineSpecific_Name = reader["LineSpecific_Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LIST_COMBOX_FROM");
                    return it_r;
                }
            }
        }

        public static bool SP_BIBOSMART_TongHopKhuyenMai_ChangeStatus(string MaCTKM, string status)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_TongHopKhuyenMai_ChangeStatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("status", int.Parse(status)));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_TongHopKhuyenMai_ChangeStatus");
                    return false;
                }
            }
        }


        public static bool SP_BIBOSMART_KM_DuyetAllPromotion(string codeKM, string CreateBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_DuyetAllPromotion", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM", codeKM));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_DuyetAllPromotion");
                    return false;
                }
            }
        }
        public static bool SP_BIBOSMART_DELETE_PROMOTION_TABLE(string CodeKM)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_DELETE_PROMOTION_TABLE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_DELETE_PROMOTION_TABLE");
                    return false;
                }
            }
        }


        public static bool SP_BIBOSMART_PROMOTION_HEADER_UPDATE(
              string TypeCTKM,
            string TargetCTKM,
            string CodeKM,
            string NameKM,
            string ToDate,
            string FrDate,
            string Vonglap_DKy,
            string Range,
            string StoreGroupType,
            string StoreGroup,
            string StoreChannel,
            string POSPopupMessage1,
            string POSPopupMessage2,
            string POSPopupMessage3,
            string CustomerDiscGroup,
            string CusPriceGroup,
            string CouponCode,
            string CouponQtyNeeded,
            string SalesTypeFilter,
            string AmountToTrigger,
            string MemberType,
            string MemberValue,
            string MemberAttibute,
            string MemberAttibuteValue,
            string TenderTypeCode,
            string TenderTypeValue,
            string createBy
        )
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_PROMOTION_HEADER_UPDATE", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("TargetCTKM", TargetCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("NameKM", NameKM));
                    cmd.Parameters.Add(new SqlParameter("ToDate", ToDate));
                    cmd.Parameters.Add(new SqlParameter("FrDate", FrDate));
                    cmd.Parameters.Add(new SqlParameter("VonglapDKy", Vonglap_DKy));
                    cmd.Parameters.Add(new SqlParameter("Range", Range));
                    cmd.Parameters.Add(new SqlParameter("StoreGroupType", StoreGroupType));
                    cmd.Parameters.Add(new SqlParameter("StoreGroup", StoreGroup));
                    cmd.Parameters.Add(new SqlParameter("StoreChannel", StoreChannel));
                    cmd.Parameters.Add(new SqlParameter("POSPopupMessage1", POSPopupMessage1));
                    cmd.Parameters.Add(new SqlParameter("POSPopupMessage2", POSPopupMessage2));
                    cmd.Parameters.Add(new SqlParameter("POSPopupMessage3", POSPopupMessage3));
                    cmd.Parameters.Add(new SqlParameter("PriceGroup", CusPriceGroup));
                    cmd.Parameters.Add(new SqlParameter("CustomerDiscGroup", CustomerDiscGroup));
                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));
                    cmd.Parameters.Add(new SqlParameter("CouponQtyNeeded", int.Parse(CouponQtyNeeded != "" ? CouponQtyNeeded : "0")));
                    cmd.Parameters.Add(new SqlParameter("SalesTypeFilter", SalesTypeFilter));
                    cmd.Parameters.Add(new SqlParameter("AmountToTrigger", int.Parse(AmountToTrigger != "" ? AmountToTrigger : "0")));
                    cmd.Parameters.Add(new SqlParameter("MemberType", MemberType));
                    cmd.Parameters.Add(new SqlParameter("MemberValue", MemberValue));
                    cmd.Parameters.Add(new SqlParameter("MemberAttibute", MemberAttibute));
                    cmd.Parameters.Add(new SqlParameter("MemberAttibuteValue", MemberAttibuteValue));
                    cmd.Parameters.Add(new SqlParameter("TenderTypeCode", TenderTypeCode));
                    cmd.Parameters.Add(new SqlParameter("TenderTypeValue", int.Parse(TenderTypeValue != "" ? TenderTypeValue : "0")));
                    cmd.Parameters.Add(new SqlParameter("ModifyBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_ADD_PROMOTION_HEADER");
                    return false;
                }
            }
        }
        public static List<objTotalDiscountOffer> SP_BIBOSMART_KM_LINE_TotalDiscountOffer_DETAIL(string CodeKM)
        {
            List<objTotalDiscountOffer> it_r = new List<objTotalDiscountOffer>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_TotalDiscountOffer_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objTotalDiscountOffer it = new objTotalDiscountOffer
                        {
                            StepAmount = reader["StepAmount"].ToString(),
                            Type = reader["Type"].ToString(),
                            No = reader["No"].ToString(),
                            Description = reader["Name"].ToString(),
                            ValueType = reader["ValueType"].ToString(),
                            Value = reader["Value"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_TotalDiscountOffer_DETAIL");
                    return it_r;
                }
            }
        }


        public static List<objTotalDiscountOffer> SP_BIBOSMART_KM_LINE_TotalDiscountOfferLine_DETAIL(string CodeKM)
        {
            List<objTotalDiscountOffer> it_r = new List<objTotalDiscountOffer>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_TotalDiscountOfferLine_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objTotalDiscountOffer it = new objTotalDiscountOffer
                        {
                            Type = reader["Type"].ToString(),
                            No = reader["No"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_TotalDiscountOfferLine_DETAIL");
                    return it_r;
                }
            }
        }

        public static List<TenderTypeOffer> SP_BIBOSMART_KM_LINE_TenderTypeOffer_DETAIL(string CodeKM)
        {
            List<TenderTypeOffer> it_r = new List<TenderTypeOffer>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_TenderTypeOffer_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TenderTypeOffer it = new TenderTypeOffer
                        {
                            TenderOffer = reader["TenderOffer"].ToString(),
                            TenderOfferAmount = reader["TenderOfferAmount"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_TenderTypeOffer_DETAIL");
                    return it_r;
                }
            }
        }

        public static List<ObjPromotions> SP_BIBOSMART_KM_LINE_Promotions_DETAIL(string CodeKM)
        {
            List<ObjPromotions> it_r = new List<ObjPromotions>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_DiscountOffer_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjPromotions it = new ObjPromotions
                        {
                            MaHang = reader["MaHang"].ToString(),
                            Type = reader["Type"].ToString(),
                            Name = reader["Name"].ToString(),
                            DiscStdPrice = reader["DiscStdPrice"].ToString(),
                            DiscAmountStdPrice = reader["DiscAmountStdPrice"].ToString(),
                            phuongphap = reader["phuongphap"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_Promotions_DETAIL");
                    return it_r;
                }
            }
        }

        public static List<ObjMultibuyDiscounts> SP_BIBOSMART_KM_LINE_MultibuyDiscounts_DETAIL(string CodeKM)
        {
            List<ObjMultibuyDiscounts> it_r = new List<ObjMultibuyDiscounts>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_MultibuyDiscounts_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjMultibuyDiscounts it = new ObjMultibuyDiscounts
                        {
                            DiscType = reader["DiscType"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            Name = reader["Name"].ToString(),
                            SLMuaTT = reader["SLMuaTT"].ToString(),
                            percentDown = reader["percentDown"].ToString(),
                            valueDown = reader["valueDown"].ToString(),
                            valueDeal = reader["valueDeal"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_MultibuyDiscounts_DETAIL");
                    return it_r;
                }
            }
        }
        public static List<ObjMixMatchLine> SP_BIBOSMART_KM_LINE_MixMatchLine_DETAIL(string CodeKM)
        {
            List<ObjMixMatchLine> it_r = new List<ObjMixMatchLine>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_MixMatchLine_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjMixMatchLine it = new ObjMixMatchLine
                        {
                            codeKM = reader["codeKM"].ToString(),
                            Type = reader["Type"].ToString(),
                            No = reader["No"].ToString(),
                            Description = reader["Description"].ToString(),
                            NoItemNeeded = reader["NoItemNeeded"].ToString(),
                            DealPriceDiscPercent = reader["DealPriceDiscPercent"].ToString(),
                            DiscType = reader["DiscType"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_MixMatchLine_DETAIL");
                    return it_r;
                }
            }
        }
        public static List<ObjMixMatchLineGroup> SP_BIBOSMART_KM_LINE_MixMatch_LineGroup_DETAIL(string CodeKM)
        {
            List<ObjMixMatchLineGroup> it_r = new List<ObjMixMatchLineGroup>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_MixMatch_LineGroup_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjMixMatchLineGroup it = new ObjMixMatchLineGroup
                        {
                            MixDiscountType = reader["MixDiscountType"].ToString(),
                            GroupNo = reader["GroupNo"].ToString(),
                            LineGroupCode = reader["LineGroupCode"].ToString(),
                            lineGroupType = reader["lineGroupType"].ToString(),
                            Value1 = reader["Value1"].ToString(),
                            Value2 = reader["Value2"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_MixMatch_LineGroup_DETAIL");
                    return it_r;
                }
            }
        }

        public static List<ObjMixMatch> SP_BIBOSMART_KM_LINE_MixMatch_DETAIL(string CodeKM)
        {
            List<ObjMixMatch> it_r = new List<ObjMixMatch>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_MixMatch_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjMixMatch it = new ObjMixMatch
                        {
                            discountType = reader["discountType"].ToString(),
                            dealPriceValue = reader["dealPriceValue"].ToString(),
                            discValue = reader["discValue"].ToString(),
                            discountAmoutValue = reader["discountAmoutValue"].ToString(),
                            noOfLeastItem = reader["noOfLeastItem"].ToString(),
                            Leastexp = reader["Leastexp"].ToString(),
                            SameDifLine = reader["SameDifLine"].ToString(),
                            NoTimeApp = reader["NoTimeApp"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_MixMatch_DETAIL");
                    return it_r;
                }
            }
        }

        public static List<ObjItemPointOffer> SP_BIBOSMART_KM_LINE_ItemPointOffer_DETAIL(string CodeKM)
        {
            List<ObjItemPointOffer> it_r = new List<ObjItemPointOffer>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_ItemPointOffer_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjItemPointOffer it = new ObjItemPointOffer
                        {
                            CodeKM = reader["CodeKM"].ToString(),
                            MemberPoint = reader["MemberPoint"].ToString(),
                            DiscAmount = reader["DiscAmount"].ToString(),
                            Discount = reader["Discount"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_ItemPointOffer_DETAIL");
                    return it_r;
                }
            }
        }

        public static List<ObjDiscountOffer> SP_BIBOSMART_KM_LINE_DiscountOffer_DETAIL(string CodeKM)
        {
            List<ObjDiscountOffer> it_r = new List<ObjDiscountOffer>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_DiscountOffer_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjDiscountOffer it = new ObjDiscountOffer
                        {
                            Type = reader["Type"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            Name = reader["Name"].ToString(),
                            DiscStdPrice = reader["DiscStdPrice"].ToString(),
                            DiscAmountStdPrice = reader["DiscAmountStdPrice"].ToString(),
                            phuongphap = reader["phuongphap"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_DiscountOffer_DETAIL");
                    return it_r;
                }
            }
        }

        public static List<ObjMemberPointOffer> SP_BIBOSMART_KM_LINE_MemberPointOffer_DETAIL(string CodeKM)
        {
            List<ObjMemberPointOffer> it_r = new List<ObjMemberPointOffer>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_MemberPointOffer_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjMemberPointOffer it = new ObjMemberPointOffer
                        {
                            TypeCTKM = reader["TypeCTKM"].ToString(),
                            CodeKM = reader["CodeKM"].ToString(),
                            LineSpecific = reader["LineSpecific"].ToString(),
                            ValueType = reader["ValueType"].ToString(),
                            PointOfferValue = reader["PointOfferValue"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_MemberPointOffer_DETAIL");
                    return it_r;
                }
            }
        }

        public static List<ObjDKHCKHUYENMAI> SP_BIBOSMART_KM_DKHCKHUYENMAI_LINE_DETAIL(string CodeKM)
        {
            List<ObjDKHCKHUYENMAI> it_r = new List<ObjDKHCKHUYENMAI>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_DKHCKHUYENMAI_LINE_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjDKHCKHUYENMAI it = new ObjDKHCKHUYENMAI
                        {
                            CodeKM = reader["CodeKM"].ToString(),
                            Content = reader["Content"].ToString(),
                            Note = reader["Note"].ToString(),
                            Promotion = reader["Promotion"].ToString(),
                            DiscountOffer = reader["DiscountOffer"].ToString(),
                            LineDiscOffer = reader["LineDiscOffer"].ToString(),
                            MultibuyDiscount = reader["MultibuyDiscount"].ToString(),
                            MixMatch = reader["MixMatch"].ToString(),
                            TotalDiscOffer = reader["TotalDiscOffer"].ToString(),
                            TenderTypeOffer = reader["TenderTypeOffer"].ToString(),
                            MemberPointOffer = reader["MemberPointOffer"].ToString(),
                            ItemPointOffer = reader["ItemPointOffer"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_DKHCKHUYENMAI_LINE_DETAIL");
                    return it_r;
                }
            }
        }

        public static List<ObjGroupSPKM> SP_BIBOSMART_KM_LINE_GroupSPKM_DETAIL(string CodeKM)
        {
            List<ObjGroupSPKM> it_r = new List<ObjGroupSPKM>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_LINE_GroupSPKM_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjGroupSPKM it = new ObjGroupSPKM
                        {
                            MaCTKM = reader["CodeKM"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            Name = reader["Name"].ToString(),
                            xh361 = reader["xh361"].ToString(),
                            lineGroup = reader["lineGroup"].ToString(),
                            range = reader["range"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_LINE_GroupSPKM_DETAIL");
                    return it_r;
                }
            }
        }
        public static List<ObjPromotionHeader> SP_BIBOSMART_KM_TonghopKhuyenMai_Detail(string MaCTKM)
        {
            List<ObjPromotionHeader> it_r = new List<ObjPromotionHeader>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_TonghopKhuyenMai_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM ", MaCTKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjPromotionHeader it = new ObjPromotionHeader
                        {
                            TypeCTKM = reader["OfferType"].ToString(),
                            CodeKM = reader["MaCTKM"].ToString(),
                            NameKM = reader["TenCTKM"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_TonghopKhuyenMai_Detail");
                    return it_r;
                }
            }
        }
        public static List<ObjPromotionHeader> SP_BIBOSMART_KM_PROMOTION_HEADER_DETAIL(string CodeKM)
        {
            List<ObjPromotionHeader> it_r = new List<ObjPromotionHeader>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_PROMOTION_HEADER_DETAIL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CodeKM ", CodeKM));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ObjPromotionHeader it = new ObjPromotionHeader
                        {
                            TypeCTKM = reader["TypeCTKM"].ToString(),
                            TargetCTKM = reader["TargetCTKM"].ToString(),
                            CodeKM = reader["CodeKM"].ToString(),
                            NameKM = reader["NameKM"].ToString(),
                            ToDate = reader["ToDate"].ToString(),
                            FrDate = reader["FrDate"].ToString(),
                            Vonglap_DKy = reader["Vonglap_DKy"].ToString(),
                            Range = reader["Range"].ToString(),
                            StoreGroupType = reader["StoreGroupType"].ToString(),
                            StoreGroup = reader["StoreGroup"].ToString(),
                            StoreChannel = reader["StoreChannel"].ToString(),
                            POSPopupMessage1 = reader["POSPopupMessage1"].ToString(),
                            POSPopupMessage2 = reader["POSPopupMessage2"].ToString(),
                            POSPopupMessage3 = reader["POSPopupMessage3"].ToString(),
                            PriceGroup = reader["PriceGroup"].ToString(),
                            CustomerDiscGroup = reader["CustomerDiscGroup"].ToString(),
                            CouponCode = reader["CouponCode"].ToString(),
                            CouponQtyNeeded = reader["CouponQtyNeeded"].ToString(),
                            SalesTypeFilter = reader["SalesTypeFilter"].ToString(),
                            AmountToTrigger = reader["AmountToTrigger"].ToString(),
                            MemberType = reader["MemberType"].ToString(),
                            MemberValue = reader["MemberValue"].ToString(),
                            MemberAttibute = reader["MemberAttibute"].ToString(),
                            MemberAttibuteValue = reader["MemberAttibuteValue"].ToString(),
                            TenderTypeCode = reader["TenderTypeCode"].ToString(),
                            TenderTypeValue = reader["TenderTypeValue"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_PROMOTION_HEADER_DETAIL");
                    return it_r;
                }
            }
        }

        public static bool SP_BIBOSMART_KM_ChangeStatusCTKM(string CreateBy, string MaCTKM, string status)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ChangeStatusCTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("status", int.Parse(status)));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_UPDATE_LINE_GroupSPKM");
                    return false;
                }
            }
        }

        public static DataTable SP_BIBOSMART_KM_GetListKM(string MaHang, string MaCTKM)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_GetListKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_GetListKM");
                return ds.Tables[0];
            }
        }

        public static bool SP_BIBOSMART_KM_ADD_LINE_TotalDiscountOfferLine(string CodeKM, string Type, string No, string Description)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_TotalDiscountOfferLine", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("No", No));
                    cmd.Parameters.Add(new SqlParameter("Description", Description));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_TotalDiscountOfferLine");
                    return false;
                }
            }
        }

        public static bool SP_BIBOSMART_KM_ADD_LINE_TotalDiscountOffer(string TypeCTKM, string CodeKM, string StepAmount, string Type, string No, string ValueType, string value, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_TotalDiscountOffer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("StepAmount", decimal.Parse(StepAmount != "" ? StepAmount : "0")));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("No", No));
                    cmd.Parameters.Add(new SqlParameter("ValueType", ValueType));
                    cmd.Parameters.Add(new SqlParameter("value", decimal.Parse(value != "" ? value : "0")));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_TotalDiscountOffer");
                    return false;
                }
            }
        }
        public static bool SP_BIBOSMART_KM_ADD_LINE_TenderTypeOffer(string TypeCTKM, string CodeKM, string TenderOffer, string TenderOfferAmount, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_TenderTypeOffer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("TenderOffer", decimal.Parse(TenderOffer != "" ? TenderOffer : "0")));
                    cmd.Parameters.Add(new SqlParameter("TenderOfferAmount", decimal.Parse(TenderOfferAmount != "" ? TenderOfferAmount : "0")));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_TenderTypeOffer");
                    return false;
                }
            }
        }

        public static bool SP_BIBOSMART_KM_ADD_LINE_Promotions(string TypeCTKM, string CodeKM, string MaHang, string xh361, string range, string DiscStdPrice, string DiscAmountStdPrice, string phuongphap, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_Promotions", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("xh361", decimal.Parse(xh361 != "" ? xh361 : "0")));
                    cmd.Parameters.Add(new SqlParameter("range", range));
                    cmd.Parameters.Add(new SqlParameter("DiscStdPrice", decimal.Parse(DiscStdPrice != "" ? DiscStdPrice : "0")));
                    cmd.Parameters.Add(new SqlParameter("DiscAmountStdPrice", decimal.Parse(DiscAmountStdPrice != "" ? DiscAmountStdPrice : "0")));
                    cmd.Parameters.Add(new SqlParameter("phuongphap", phuongphap));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_Promotions");
                    return false;
                }
            }
        }

        public static bool SP_BIBOSMART_KM_ADD_LINE_MultibuyDiscounts(string TypeCTKM, string CodeKM, string DiscType, string MaHang, string SLMuaTT, string percentDown, string valueDown, string valueDeal, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_MultibuyDiscounts", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("DiscType", DiscType));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("SLMuaTT", decimal.Parse(SLMuaTT != "" ? SLMuaTT : "0")));
                    cmd.Parameters.Add(new SqlParameter("percentDown", decimal.Parse(percentDown != "" ? percentDown : "0")));
                    cmd.Parameters.Add(new SqlParameter("valueDown", decimal.Parse(valueDown != "" ? valueDown : "0")));
                    cmd.Parameters.Add(new SqlParameter("valueDeal", decimal.Parse(valueDeal != "" ? valueDeal : "0")));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_MultibuyDiscounts");
                    return false;
                }
            }
        }

        public static bool SP_BIBOSMART_KM_ADD_LINE_PriceGroup(string TypeCTKM, string CodeKM, string Code, string Description, string AllLineDisc, string AllInvoiceDisc, string PriceIncludesVAT, string vatBusPostingGroup, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_PriceGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("Code", Code));
                    cmd.Parameters.Add(new SqlParameter("Description", Description));
                    cmd.Parameters.Add(new SqlParameter("AllLineDisc", AllLineDisc));
                    cmd.Parameters.Add(new SqlParameter("AllInvoiceDisc", AllInvoiceDisc));
                    cmd.Parameters.Add(new SqlParameter("PriceIncludesVAT", PriceIncludesVAT));
                    cmd.Parameters.Add(new SqlParameter("vatBusPostingGroup", vatBusPostingGroup));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_PriceGroup");
                    return false;
                }
            }
        }
        public static bool SP_BIBOSMART_KM_ADD_LINE_MixMatchLine(string codeKM, string Type, string No, string Description, string NoItemNeeded, string DealPriceDiscPercent, string DiscType, string LineGroup, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_MixMatchLine", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("codeKM", codeKM));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("No", No));
                    cmd.Parameters.Add(new SqlParameter("Description", Description));
                    cmd.Parameters.Add(new SqlParameter("NoItemNeeded", decimal.Parse(NoItemNeeded != "" ? NoItemNeeded : "0")));
                    cmd.Parameters.Add(new SqlParameter("DealPriceDiscPercent", decimal.Parse(DealPriceDiscPercent != "" ? DealPriceDiscPercent : "0")));
                    cmd.Parameters.Add(new SqlParameter("DiscType", DiscType));
                    cmd.Parameters.Add(new SqlParameter("LineGroup", LineGroup));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_MixMatchLine");
                    return false;
                }
            }
        }
        public static bool SP_BIBOSMART_KM_ADD_LINE_MixMatch_LineGroup(string codeKM, string MixDiscountType, string GroupNo, string LineGroupCode, string lineGroupType, string value1, string value2, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_MixMatch_LineGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("CodeKM", codeKM));
                    cmd.Parameters.Add(new SqlParameter("MixDiscountType", MixDiscountType));
                    cmd.Parameters.Add(new SqlParameter("GroupNo", GroupNo));
                    cmd.Parameters.Add(new SqlParameter("LineGroupCode", LineGroupCode));
                    cmd.Parameters.Add(new SqlParameter("LineGroupType", lineGroupType));
                    cmd.Parameters.Add(new SqlParameter("Value1", decimal.Parse(value1 != "" ? value1 : "0")));
                    cmd.Parameters.Add(new SqlParameter("Value2", decimal.Parse(value2 != "" ? value2 : "0")));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_MixMatch_LineGroup");
                    return false;
                }
            }
        }

        public static bool SP_BIBOSMART_KM_ADD_LINE_MixMatch(string TypeCTKM, string CodeKM, string discountType, string dealPriceValue, string discValue, string discountAmoutValue, string noOfLeastItem, string Leastexp, string SameDifLine, string NoTimeApp, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_MixMatch", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("discountType", discountType));
                    cmd.Parameters.Add(new SqlParameter("dealPriceValue", decimal.Parse(dealPriceValue != "" ? dealPriceValue : "0")));
                    cmd.Parameters.Add(new SqlParameter("discValue", decimal.Parse(discValue != "" ? discValue : "0")));
                    cmd.Parameters.Add(new SqlParameter("discountAmoutValue", decimal.Parse(discountAmoutValue != "" ? discountAmoutValue : "0")));
                    cmd.Parameters.Add(new SqlParameter("noOfLeastItem", decimal.Parse(noOfLeastItem != "" ? noOfLeastItem : "0")));
                    cmd.Parameters.Add(new SqlParameter("Leastexp", decimal.Parse(Leastexp != "" ? Leastexp : "0")));
                    cmd.Parameters.Add(new SqlParameter("SameDifLine", SameDifLine));
                    cmd.Parameters.Add(new SqlParameter("NoTimeApp", int.Parse(NoTimeApp != "" ? NoTimeApp : "0")));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_MixMatch");
                    return false;
                }
            }
        }

        public static bool SP_BIBOSMART_KM_ADD_LINE_MemberPointOffer(string TypeCTKM, string CodeKM, string LineSpecific, string ValueType, string PointOfferValue, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_MemberPointOffer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("LineSpecific", LineSpecific));
                    cmd.Parameters.Add(new SqlParameter("ValueType", decimal.Parse(ValueType != "" ? ValueType : "0")));
                    cmd.Parameters.Add(new SqlParameter("PointOfferValue", decimal.Parse(PointOfferValue != "" ? PointOfferValue : "0")));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_MemberPointOffer");
                    return false;
                }
            }
        }


        public static bool SP_BIBOSMART_KM_ADD_LINE_ItemPointOffer(string TypeCTKM, string CodeKM, string MemberPoint, string DiscAmount, string Discount, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_ItemPointOffer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("MemberPoint", MemberPoint));
                    cmd.Parameters.Add(new SqlParameter("DiscAmount", decimal.Parse(DiscAmount != "" ? DiscAmount : "0")));
                    cmd.Parameters.Add(new SqlParameter("Discount", decimal.Parse(Discount != "" ? Discount : "0")));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_DiscountOffer");
                    return false;
                }
            }
        }

        public static bool SP_BIBOSMART_KM_ADD_LINE_DiscountOffer(string TypeCTKM, string CodeKM, string Type, string MaHang, string DiscStdPrice, string DiscAmountStdPrice, string phuongphap)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_DiscountOffer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("Type", Type));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("DiscStdPrice", decimal.Parse(DiscStdPrice != "" ? DiscStdPrice : "0")));
                    cmd.Parameters.Add(new SqlParameter("DiscAmountStdPrice", decimal.Parse(DiscAmountStdPrice != "" ? DiscAmountStdPrice : "0")));
                    cmd.Parameters.Add(new SqlParameter("phuongphap", phuongphap));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_DiscountOffer");
                    return false;
                }
            }
        }

        public static bool SP_BIBOSMART_KM_ADD_LINE_DKHCKHUYENMAI_LINE(string TypeCTKM, string CodeKM, string Content, string Note, string Promotion, string DiscountOffer, string LineDiscOffer, string MultibuyDiscount, string MixMatch, string TotalDiscOffer, string TenderTypeOffer, string MemberPointOffer, string ItemPointOffer, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_DKHCKHUYENMAI_LINE", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("Content", Content));
                    cmd.Parameters.Add(new SqlParameter("Note", Note));
                    cmd.Parameters.Add(new SqlParameter("Promotion", Promotion));
                    cmd.Parameters.Add(new SqlParameter("DiscountOffer", DiscountOffer));
                    cmd.Parameters.Add(new SqlParameter("LineDiscOffer", LineDiscOffer));
                    cmd.Parameters.Add(new SqlParameter("MultibuyDiscount", MultibuyDiscount));
                    cmd.Parameters.Add(new SqlParameter("MixMatch", MixMatch));
                    cmd.Parameters.Add(new SqlParameter("TotalDiscOffer", TotalDiscOffer));
                    cmd.Parameters.Add(new SqlParameter("TenderTypeOffer", TenderTypeOffer));
                    cmd.Parameters.Add(new SqlParameter("MemberPointOffer", MemberPointOffer));
                    cmd.Parameters.Add(new SqlParameter("ItemPointOffer", ItemPointOffer));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_DKHCKHUYENMAI_LINE");
                    return false;
                }
            }
        }

        public static bool SP_BIBOSMART_KM_ADD_LINE_GroupSPKM(string TypeCTKM, string CodeKM, string MaHang, string xh361, string range, string lineGroup, string createBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ADD_LINE_GroupSPKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("xh361", xh361));
                    cmd.Parameters.Add(new SqlParameter("range", range));
                    cmd.Parameters.Add(new SqlParameter("lineGroup", lineGroup));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_ADD_LINE_GroupSPKM");
                    return false;
                }
            }
        }
        public static bool SP_BIBOSMART_ADD_PROMOTION_HEADER(
            string TypeCTKM,
            string TargetCTKM,
            string CodeKM,
            string NameKM,
            string ToDate,
            string FrDate,
            string Vonglap_DKy,
            string Range,
            string StoreGroupType,
            string StoreGroup,
            string StoreChannel,
            string POSPopupMessage1,
            string POSPopupMessage2,
            string POSPopupMessage3,
            string CustomerDiscGroup,
            string CusPriceGroup,
            string CouponCode,
            string CouponQtyNeeded,
            string SalesTypeFilter,
            string AmountToTrigger,
            string MemberType,
            string MemberValue,
            string MemberAttibute,
            string MemberAttibuteValue,
            string TenderTypeCode,
            string TenderTypeValue,
            string createBy
        )
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_ADD_PROMOTION_HEADER", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("TargetCTKM", TargetCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", CodeKM));
                    cmd.Parameters.Add(new SqlParameter("NameKM", NameKM));
                    cmd.Parameters.Add(new SqlParameter("ToDate", ToDate));
                    cmd.Parameters.Add(new SqlParameter("FrDate", FrDate));
                    cmd.Parameters.Add(new SqlParameter("VonglapDKy", Vonglap_DKy));
                    cmd.Parameters.Add(new SqlParameter("Range", Range));
                    cmd.Parameters.Add(new SqlParameter("StoreGroupType", StoreGroupType));
                    cmd.Parameters.Add(new SqlParameter("StoreGroup", StoreGroup));
                    cmd.Parameters.Add(new SqlParameter("StoreChannel", StoreChannel));
                    cmd.Parameters.Add(new SqlParameter("POSPopupMessage1", POSPopupMessage1));
                    cmd.Parameters.Add(new SqlParameter("POSPopupMessage2", POSPopupMessage2));
                    cmd.Parameters.Add(new SqlParameter("POSPopupMessage3", POSPopupMessage3));
                    cmd.Parameters.Add(new SqlParameter("PriceGroup", CusPriceGroup));
                    cmd.Parameters.Add(new SqlParameter("CustomerDiscGroup", CustomerDiscGroup));
                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));
                    cmd.Parameters.Add(new SqlParameter("CouponQtyNeeded", int.Parse(CouponQtyNeeded != "" ? CouponQtyNeeded : "0")));
                    cmd.Parameters.Add(new SqlParameter("SalesTypeFilter", SalesTypeFilter));
                    cmd.Parameters.Add(new SqlParameter("AmountToTrigger", int.Parse(AmountToTrigger != "" ? AmountToTrigger : "0")));
                    cmd.Parameters.Add(new SqlParameter("MemberType", MemberType));
                    cmd.Parameters.Add(new SqlParameter("MemberValue", MemberValue));
                    cmd.Parameters.Add(new SqlParameter("MemberAttibute", MemberAttibute));
                    cmd.Parameters.Add(new SqlParameter("MemberAttibuteValue", MemberAttibuteValue));
                    cmd.Parameters.Add(new SqlParameter("TenderTypeCode", TenderTypeCode));
                    cmd.Parameters.Add(new SqlParameter("TenderTypeValue", int.Parse(TenderTypeValue != "" ? TenderTypeValue : "0")));
                    cmd.Parameters.Add(new SqlParameter("Status", 1));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_ADD_PROMOTION_HEADER");
                    return false;
                }
            }
        }

        public static List<objCombox> GetCustomerPriceGroup()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
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

        public static List<objCombox> SP_BIBOSMART_ERP_Coupon_DETAIL()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_ERP_Coupon_DETAIL", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_ERP_Coupon_DETAIL");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_getWay_Pro_ITEM_Vendor(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
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
        public static List<objCombox> SP_BIBOSMART_KM_ITEM()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_ITEM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
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

        public static DataTable SP_BIBOSMART_KM_GET_LIST_HISTORYCTKM(string TargetCTKM, string MaCTKM, string TypeCTKM, string NameKM)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_GET_LIST_HISTORYCTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("TargetCTKM", TargetCTKM));
                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("NameKM", NameKM));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_GET_LIST_HISTORYCTKM");
                return ds.Tables[0];
            }
        }

        public static DataTable SP_BIBOSMART_KM_GET_LIST_DUYETCTKM(string TargetCTKM, string MaCTKM, string TypeCTKM, string NameKM)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_GET_LIST_DUYETCTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("TargetCTKM", TargetCTKM));
                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("NameKM", NameKM));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_GET_LIST_DUYETCTKM");
                return ds.Tables[0];
            }
        }

        public static DataTable SP_BIBOSMART_KM_GET_LIST_DSCTKM(string TargetCTKM, string MaCTKM, string TypeCTKM, string NameKM)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_GET_LIST_DSCTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("TargetCTKM", TargetCTKM));
                    cmd.Parameters.Add(new SqlParameter("TypeCTKM", TypeCTKM));
                    cmd.Parameters.Add(new SqlParameter("CodeKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("NameKM", NameKM));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_GET_LIST_DSCTKM");
                return ds.Tables[0];
            }
        }

        public static DataTable SP_GET_LISTCTKM(string Function, string Div, string Brand, string MaCTKM, string typeCTKM, string status)
        {
            DataSet ds = new DataSet();

            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_KM_GET_LISTCTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("Function", Function));
                    cmd.Parameters.Add(new SqlParameter("Div", Div));
                    cmd.Parameters.Add(new SqlParameter("Brand", Brand));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("typeCTKM", typeCTKM));
                    cmd.Parameters.Add(new SqlParameter("status", status));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_GET_LISTCTKM");
                return ds.Tables[0];
            }
        }

        public static DataTable sp_GetListKhuyenMai(string userid, string MaCTKM, string TenCTKM, string LoaiCaiDat, string ItemNo, string VendorNo)
        {
            DataSet ds = new DataSet();

            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetListKhuyenMai", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("TenCTKM", TenCTKM));
                    cmd.Parameters.Add(new SqlParameter("OfferType", LoaiCaiDat));
                    cmd.Parameters.Add(new SqlParameter("ItemNo", ItemNo));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetListKhuyenMai");
                return ds.Tables[0];
            }
        }

        public static List<objCTKM> sp_BBSmart_GetDetailPromotion(string MaCTKM, string MaHang)
        {
            List<objCTKM> it_r = new List<objCTKM>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetDetailPromotion", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCTKM it = new objCTKM
                        {
                            MaCTKM = reader["MaCTKM"].ToString(),
                            TenCTKM = reader["TenCTKM"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            stepAmount = reader["stepAmount"].ToString(),
                            MaQua = reader["MaQua"].ToString(),
                            DealPriceDisc = decimal.Parse(reader["DealPriceDisc"].ToString()),
                            DiscountAmountInVAT = decimal.Parse(reader["DiscountAmountInVAT"].ToString()),
                            NoOfItemsNeeded = decimal.Parse(reader["NoOfItemsNeeded"].ToString()),
                            SL_Hang = decimal.Parse(reader["SL_Hang"].ToString())
                        };

                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetDetailPromotion");
                    return it_r;
                }
            }
        }


        public static List<objCTKM> sp_BBSmart_KM_Item_CTKM(string MaHang)
        {
            List<objCTKM> it_r = new List<objCTKM>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_KM_Item_CTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCTKM it = new objCTKM
                        {
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            XH631 = decimal.Parse(reader["XH631"] != null ? reader["XH631"].ToString() : "0"),
                            Range = reader["Range"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_KM_Item_CTKM");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_BBM_SMART_KM_GetList_DieuKienHCKM()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_KM_GetList_DieuKienHCKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;

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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_KM_GetList_DieuKienHCKM");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_BBSmart_Promotion_getVendor(string MaCTKM)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_Promotion_getVendor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));

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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_Promotion_getVendor");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_BBSmart_Promotion_getBrand(string MaCTKM)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_Promotion_getBrand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_Promotion_getBrand");
                    return it_r;
                }
            }
        }


        public static List<objCombox> sp_BBSmart_GetListKhuyenMai()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetListKhuyenMai", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["MaCTKM"].ToString(),
                            Name = reader["TenCTKM"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetListKhuyenMai");
                    return it_r;
                }
            }
        }
        public static DataTable sp_GetListTonghopKM(string userid, string LoaiCaiDat, string TenCTKM, string MaCTKM, string vendorNo, string BrandCode)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetListTonghopKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("OfferType", LoaiCaiDat));
                    cmd.Parameters.Add(new SqlParameter("TenCTKM", TenCTKM));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", MaCTKM));
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetListTonghopKM");
                return ds.Tables[0];
            }
        }
        public static List<objCombox> sp_BBSmart_GetList_CTKM()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetListTonghopKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["MaCTKM"].ToString(),
                            Name = reader["TenCTKM"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetListTonghopKM");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_qlkd_Sub_LoaiCTKM()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_Sub_LoaiCTKM", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_Sub_LoaiCTKM");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_qlkd_Sub_LoaiCaiDatCTKM()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_Sub_LoaiCaiDatCTKM", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_Sub_LoaiCaiDatCTKM");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_GetListTenCTKM()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetListComboxCTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Name = reader["TenCTKM"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetListTonghopKM");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_GetListTenCTKM1()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetListKhuyenMai", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Name = reader["TenCTKM"].ToString(),
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetListKhuyenMai");
                    return it_r;
                }
            }
        }

        public static List<objCombox> get_NgayHieuLuc_ThoaThuanHD(string MaNCC)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("get_NgayHieuLuc_ThoaThuanHD", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["VendorNo"].ToString(),
                            Name = reader["NgayHieuLuc_ThoaThuanHD"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "get_NgayHieuLuc_ThoaThuanHD");
                    return it_r;
                }
            }
        }
    }
}