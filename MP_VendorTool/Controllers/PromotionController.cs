using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using MP_VendorTool.Models.ERP_API;
using MP_VendorTool.Models.Promotion;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Text.RegularExpressions;
using System.Drawing;
using System.Net.Http;
using System.Net;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
namespace MP_VendorTool.Controllers
{
    public class PromotionController : Controller
    {
        private string uid;
        #region system function
        #endregion

        public async Task<ActionResult> ChangeStatusCTKM(string No, string flag)
        {
            var err = new RouteInfo();
            try
            {
                //Dừng các CTKM tạo trên bibosmart
                if (flag == "CTKM_NEW")
                {
                    var listPHD = DataAccess.DataAccessKM.SP_BIBOSMART_KM_PROMOTION_HEADER_DETAIL(No);
                    if (listPHD.Count() > 0)
                    {
                        Models.ERP_API.Promotion.objChangeStatus it = new Models.ERP_API.Promotion.objChangeStatus
                        {
                            No = No,
                            Type = listPHD[0].TypeCTKM.ToString()
                        };

                        var data = await DataAccess.ERP_API_Promorion_DataAccess.API_ChangeStatusCTKM(it);
                        if (data.codeReturn)
                        {
                            DataAccess.DataAccessKM.SP_BIBOSMART_KM_ChangeStatusCTKM(Session["uid"].ToString(), No, "5");
                            err.RespId = 0;
                            err.RespMsg = "Dừng chương trình thành công !";
                        }
                        else
                        {
                            err.RespId = -1;
                            err.RespMsg = "Có lỗi xẩy ra. Bạn vui lòng thử lại sau !";
                        }
                    }
                }
                // Dừng CTKM đồng bộ trên phần mềm ERP
                else if (flag == "CTKM_OLD")
                {
                    var listPHD = DataAccess.DataAccessKM.SP_BIBOSMART_KM_TonghopKhuyenMai_Detail(No);
                    if (listPHD.Count() > 0)
                    {
                        Models.ERP_API.Promotion.objChangeStatus it = new Models.ERP_API.Promotion.objChangeStatus
                        {
                            No = No,
                            Type = listPHD[0].TypeCTKM.ToString()
                        };
                        var data = await DataAccess.ERP_API_Promorion_DataAccess.API_ChangeStatusCTKM(it);
                        if (data.codeReturn)
                        {
                            DataAccess.DataAccessKM.SP_BIBOSMART_TongHopKhuyenMai_ChangeStatus(No, "0");
                            err.RespId = 0;
                            err.RespMsg = "Dừng chương trình thành công !";
                        }
                        else
                        {
                            err.RespId = -1;
                            err.RespMsg = "Có lỗi xẩy ra. Bạn vui lòng thử lại sau !";
                        }
                    }
                }
                return Json(err);
            }
            catch (Exception ex)
            {
                MP_VendorTool.DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ChangeStatusCTKM");
                return Json(null);
            }
        }

        //start ERP_API
        public async Task<ActionResult> GetAllCusPriceGroup()
        {
            List<objCombox> it_r = new List<objCombox>();
            try
            {
                var list = await DataAccess.ERP_API_Promorion_DataAccess.API_GetCusPriceGroup();
                var sub = list.Items;
                var items = JArray.Parse(sub);

                foreach (JObject i in sub)
                {
                    it_r.Add(new objCombox { Code = i["codeField"].ToString(), Name = i["descriptionField"].ToString() });
                }
                return Json(it_r);
            }
            catch (Exception ex)
            {
                MP_VendorTool.DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetAllCusPriceGroup");
                return Json(null);
            }
        }
        //public ActionResult GetAllStorePriceGroup()
        //{
        //    try
        //    {
        //        var data = DataAccess.ERP_API_Promorion_DataAccess.API_GetStorePriceGroup();
        //        return Json(data.Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        MP_VendorTool.DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetAllStorePriceGroup");
        //        return Json(null);
        //    }
        //}
        public ActionResult API_GetCodeCTKM(string typeCTKM)
        {
            try
            {
                //var data = DataAccess.ERP_API_Promorion_DataAccess.API_GenerateCodeKM(typeCTKM);
                List<objCombox> lst = new List<objCombox>();
                lst = DataAccess.DataAccessKM.GetCodeCTKM();
                return Json(lst);
            }
            catch (Exception ex)
            {
                MP_VendorTool.DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "API_GetCodeCTKM");
                return Json(null);
            }
        }
        public ActionResult API_AddDiscountOffer(Models.ERP_API.Promotion.DiscountOffer it)
        {
            try
            {
                var data = DataAccess.ERP_API_Promorion_DataAccess.API_createDiscountOffer(it);
                return Json(data.Result);
            }
            catch (Exception ex)
            {
                MP_VendorTool.DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "API_AddDiscountOffer");
                return Json(null);
            }
        }
        //end ERP_API
        private string RandomValidationPeriodID(string code)
        {
            Random rd = new Random();
            int rand_num = rd.Next(100, 500);
            string ValidationPeriodID = code + "_" + rand_num;
            return ValidationPeriodID;
        }
        public ActionResult GetListKM_ManagePromotion(string MaHang, string MaCTKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessKM.SP_BIBOSMART_KM_GetListKM(MaHang, MaCTKM);
                var obj = (from DataRow dr in table.Rows
                           select new objCTKM()
                           {
                               L4LSL = decimal.Parse(dr["L4LSL"].ToString()),
                               L4LDT = decimal.Parse(dr["L4LDT"].ToString()),
                               L4LGP = decimal.Parse(dr["L4LGP"].ToString())
                           }).ToList();

                var totalL4LSL = obj.Select(s => s.L4LSL).ToList().Sum();
                ViewBag.totalL4LSL = string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", totalL4LSL);

                var totalL4LDT = obj.Select(s => s.L4LDT).ToList().Sum();
                ViewBag.totalL4LDT = string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", totalL4LDT);

                var totalL4LGP = obj.Select(s => s.L4LGP).ToList().Sum();
                ViewBag.totalL4LGP = string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", totalL4LGP);

                return PartialView("~/Views/Promotion/Partial/__ManagePromotion.cshtml", table);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult GetListBrowserCTKM(string TargetCTKM, string MaCTKM, string TypeCTKM, string NameKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessKM.SP_BIBOSMART_KM_GET_LIST_DUYETCTKM(TargetCTKM, MaCTKM, TypeCTKM, NameKM);
                return PartialView("~/Views/Promotion/Partial/__BrowserCTKM.cshtml", table);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult GetListHistoryCTKM(string TargetCTKM, string MaCTKM, string TypeCTKM, string NameKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessKM.SP_BIBOSMART_KM_GET_LIST_HISTORYCTKM(TargetCTKM, MaCTKM, TypeCTKM, NameKM);
                return PartialView("~/Views/Promotion/Partial/__HistoryCTKM.cshtml", table);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult GetListDSCTKM(string TargetCTKM, string MaCTKM, string TypeCTKM, string NameKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessKM.SP_BIBOSMART_KM_GET_LIST_DSCTKM(TargetCTKM, MaCTKM, TypeCTKM, NameKM);
                var obj = (from DataRow dr in table.Rows
                           select new objCTKM()
                           {
                               L4LSL = decimal.Parse(dr["L4LSL"].ToString()),
                               L4LDS = decimal.Parse(dr["L4LDS"].ToString()),
                               L4LGP = decimal.Parse(dr["L4LGP"].ToString())
                           }).ToList();

                var totalL4LSL = obj.Select(s => s.L4LSL).ToList().Sum();
                ViewBag.totalL4LSL = string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", totalL4LSL);

                var totalL4LDT = obj.Select(s => s.L4LDS).ToList().Sum();
                ViewBag.totalL4LDT = string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", totalL4LDT);

                var totalL4LGP = obj.Select(s => s.L4LGP).ToList().Sum();
                ViewBag.totalL4LGP = string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", totalL4LGP);

                return PartialView("~/Views/Promotion/Partial/__DSCTKM.cshtml", table);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ChangeStatusCKTM(List<ObjGroupSPKM> arrItem, string status)
        {
            var err = new RouteInfo();
            bool result = false;
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    foreach (ObjGroupSPKM po in arrItem)
                    {
                        result = DataAccess.DataAccessKM.SP_BIBOSMART_KM_ChangeStatusCTKM(
                               Session["uid"].ToString(),
                               po.MaCTKM,
                               status
                        );
                    }
                    if (result)
                    {
                        err.RespId = 0;
                        if (status == "4")
                        {
                            err.RespMsg = "Gửi yêu cầu duyệt thành công";
                        }
                        else if (status == "3")
                        {
                            err.RespMsg = "Từ chối thành công";
                        }
                        else if (status == "5")
                        {
                            err.RespMsg = "Xóa thành công";
                        }
                    }
                    return Json(err);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }

            return Json(err);
        }

        public ActionResult DSCTKM()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                //if (!checkpermission("DSCTKM")) return RedirectToAction("Index", "Home");

                var list_LoaiCTKM = DataAccess.DataAccessKM.sp_qlkd_Sub_LoaiCTKM();
                ViewBag.listLoaiCTKM = list_LoaiCTKM;

                var list_LoaiCaiDatCTKM = DataAccess.DataAccessKM.sp_qlkd_Sub_LoaiCaiDatCTKM();
                ViewBag.listLoaiCaiDatCTKM = list_LoaiCaiDatCTKM;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult HistoryCTKM()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                //if (!checkpermission("HistoryCTKM")) return RedirectToAction("Index", "Home");

                var list_LoaiCTKM = DataAccess.DataAccessKM.sp_qlkd_Sub_LoaiCTKM();
                ViewBag.listLoaiCTKM = list_LoaiCTKM;

                var list_LoaiCaiDatCTKM = DataAccess.DataAccessKM.sp_qlkd_Sub_LoaiCaiDatCTKM();
                ViewBag.listLoaiCaiDatCTKM = list_LoaiCaiDatCTKM;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }



        public ActionResult PromotionSetCreate()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                //if (!checkpermission("PromotionSetCreate")) return RedirectToAction("Index", "Home");

                var lstItem = DataAccess.DataAccessKM.SP_BIBOSMART_KM_ITEM();
                ViewBag.lstItem = lstItem;

                var lstDKKM = DataAccess.DataAccessKM.sp_BBM_SMART_KM_GetList_DieuKienHCKM();
                ViewBag.lstDKKM = lstDKKM;

                var list_LoaiCTKM = DataAccess.DataAccessKM.sp_qlkd_Sub_LoaiCTKM();
                ViewBag.listLoaiCTKM = list_LoaiCTKM;

                var list_LoaiCaiDatCTKM = DataAccess.DataAccessKM.sp_qlkd_Sub_LoaiCaiDatCTKM();
                ViewBag.listLoaiCaiDatCTKM = list_LoaiCaiDatCTKM;

                var list_TenCTKM1 = DataAccess.DataAccessKM.sp_GetListTenCTKM();
                ViewBag.list_TenCTKM1 = list_TenCTKM1;

                var lststore = DataAccess.DataAccess.sp_bbs_getlistCH();
                ViewBag.lststore = lststore;

                var lstCombox = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LIST_COMBOX_FROM();
                ViewBag.lstCombox = lstCombox;

                var lstCusPriceGroup = DataAccess.DataAccessKM.GetCustomerPriceGroup();
                ViewBag.lstCusPriceGroup = lstCusPriceGroup;

                //var list_CusPriceGroup = GetAllCusPriceGroup();
                //ViewBag.listCusPriceGroup = list_CusPriceGroup;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult PromotionSetEdit(string id)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var lstItem = DataAccess.DataAccessKM.SP_BIBOSMART_KM_ITEM();
                ViewBag.lstItem = lstItem;

                var lstDKKM = DataAccess.DataAccessKM.sp_BBM_SMART_KM_GetList_DieuKienHCKM();
                ViewBag.lstDKKM = lstDKKM;

                var list_LoaiCTKM = DataAccess.DataAccessKM.sp_qlkd_Sub_LoaiCTKM();
                ViewBag.listLoaiCTKM = list_LoaiCTKM;

                var list_LoaiCaiDatCTKM = DataAccess.DataAccessKM.sp_qlkd_Sub_LoaiCaiDatCTKM();
                ViewBag.listLoaiCaiDatCTKM = list_LoaiCaiDatCTKM;

                var list_TenCTKM1 = DataAccess.DataAccessKM.sp_GetListTenCTKM();
                ViewBag.list_TenCTKM1 = list_TenCTKM1;

                var list_Pro_Header = DataAccess.DataAccessKM.SP_BIBOSMART_KM_PROMOTION_HEADER_DETAIL(id);
                ViewBag.listProHeader = list_Pro_Header;

                var listGroupSPKM = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_GroupSPKM_DETAIL(id);
                ViewBag.listGroupSPKM = listGroupSPKM;

                var list_KMDKHCKM = DataAccess.DataAccessKM.SP_BIBOSMART_KM_DKHCKHUYENMAI_LINE_DETAIL(id);
                ViewBag.listKMDKHCKM = list_KMDKHCKM;

                var lststore = DataAccess.DataAccess.sp_bbs_getlistCH();
                ViewBag.lststore = lststore;

                var list_MemberPointOffer = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_MemberPointOffer_DETAIL(id);
                if (list_MemberPointOffer.Count() > 0)
                {
                    ViewBag.LineSpecific = list_MemberPointOffer[0].LineSpecific;
                    ViewBag.PointOfferValue = list_MemberPointOffer[0].PointOfferValue;
                    ViewBag.ValueType = list_MemberPointOffer[0].ValueType;
                }


                var list_DiscountOffer = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_DiscountOffer_DETAIL(id);
                ViewBag.listDiscountOffer = list_DiscountOffer;


                var itemsMixMatchLine = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_MixMatchLine_DETAIL(id);
                ViewBag.ListMixMatchLine = itemsMixMatchLine;

                var list_ItemPointOffer = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_ItemPointOffer_DETAIL(id);
                if (list_ItemPointOffer.Count() > 0)
                {
                    ViewBag.MemberPoint = list_ItemPointOffer[0].MemberPoint;
                    ViewBag.DiscAmount = list_ItemPointOffer[0].DiscAmount;
                    ViewBag.Discount = list_ItemPointOffer[0].Discount;
                }

                var list_MixMatch = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_MixMatch_DETAIL(id);
                if (list_MixMatch.Count() > 0)
                {
                    ViewBag.discountType = list_MixMatch[0].discountType;
                    ViewBag.dealPriceValue = list_MixMatch[0].dealPriceValue;
                    ViewBag.discValue = list_MixMatch[0].discValue;
                    ViewBag.discountAmoutValue = list_MixMatch[0].discountAmoutValue;
                    ViewBag.noOfLeastItem = list_MixMatch[0].noOfLeastItem;
                    ViewBag.Leastexp = list_MixMatch[0].Leastexp;
                    ViewBag.SameDifLine = list_MixMatch[0].SameDifLine;
                    ViewBag.NoTimeApp = list_MixMatch[0].NoTimeApp;
                }

                var list_MixMatchLineGroup = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_MixMatch_LineGroup_DETAIL(id);
                ViewBag.listMixMatchLineGroup = list_MixMatchLineGroup;

                var list_MultibuyDiscounts = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_MultibuyDiscounts_DETAIL(id);
                ViewBag.listMultibuyDiscounts = list_MultibuyDiscounts;

                var list_Promotions = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_Promotions_DETAIL(id);
                ViewBag.listPromotions = list_Promotions;

                var list_TenderTypeOffer = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_TenderTypeOffer_DETAIL(id);
                if (list_TenderTypeOffer.Count() > 0)
                {

                    ViewBag.TenderOffer = list_TenderTypeOffer[0].TenderOffer;
                    ViewBag.TenderOfferAmount = list_TenderTypeOffer[0].TenderOfferAmount;
                }

                var list_TotalDiscountOffer = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_TotalDiscountOffer_DETAIL(id);
                ViewBag.listTotalDiscountOffer = list_TotalDiscountOffer;

                var list_TotalDOBeBefit = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_TotalDiscountOfferLine_DETAIL(id);
                ViewBag.listTotalDOBeBefit = list_TotalDOBeBefit;

                var lstCombox = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LIST_COMBOX_FROM();
                ViewBag.lstCombox = lstCombox;

                var lstCusPriceGroup = DataAccess.DataAccessKM.GetCustomerPriceGroup();
                ViewBag.lstCusPriceGroup = lstCusPriceGroup;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult GetInfoProduct_KM(string MaHang)
        {
            try
            {
                List<objCTKM> lst = new List<objCTKM>();
                lst = DataAccess.DataAccessKM.sp_BBSmart_KM_Item_CTKM(MaHang);
                //var ls_item = lst.Where(s => s.MaHang == MaHang).ToList();
                return Json(lst);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public ActionResult GetListItem_Group(string strMahang)
        {
            try
            {
                List<objCTKM> lst = new List<objCTKM>();
                if (strMahang.Length > 0)
                {
                    lst = DataAccess.DataAccessKM.sp_BBSmart_KM_Item_CTKM(strMahang);
                }
                return Json(lst);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public ActionResult GetListBrand(string MaCTKM)
        {
            try
            {
                List<objCombox> lst = new List<objCombox>();
                lst = DataAccess.DataAccessKM.sp_BBSmart_Promotion_getBrand(MaCTKM);
                return Json(lst);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public ActionResult GetListVendor(string MaCTKM)
        {
            try
            {
                List<objCombox> lst = new List<objCombox>();
                lst = DataAccess.DataAccessKM.sp_BBSmart_Promotion_getVendor(MaCTKM);
                return Json(lst);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public ActionResult getDetailPromotion(string MaCTKM, string MaHang)
        {
            try
            {
                List<objCTKM> lst = new List<objCTKM>();
                lst = DataAccess.DataAccessKM.sp_BBSmart_GetDetailPromotion(MaCTKM, MaHang);
                return Json(lst);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DuyetAllPromotion(string codeKM, string status)
        {
            var err = new RouteInfo();
            try
            {
                if (status == "2")
                {
                    //Accept và đẩy lên ERP
                    if (codeKM.Length > 0)
                    {
                        var listPHD = DataAccess.DataAccessKM.SP_BIBOSMART_KM_PROMOTION_HEADER_DETAIL(codeKM);
                        if (listPHD.Count > 0)
                        {
                            DateTime frdate = DateTime.Parse(listPHD[0].FrDate.ToString());
                            var StartingDate = frdate.ToString("MM/dd/yyyy");
                            DateTime toDate = DateTime.Parse(listPHD[0].ToDate.ToString());
                            var EndingDate = toDate.ToString("MM/dd/yyyy");

                            string ValidateID = RandomValidationPeriodID(codeKM);
                            Models.ERP_API.Promotion.ValidationPeriod subVP = new Models.ERP_API.Promotion.ValidationPeriod
                            {
                                ID = ValidateID,
                                Description = listPHD[0].NameKM.ToString(),
                                Starting_Date = StartingDate,
                                Ending_Date = EndingDate
                            };

                            var data_vp = await DataAccess.ERP_API_Promorion_DataAccess.API_CreateValidationPeriod(subVP);
                            var ValidationPeriodID = Regex.Replace(data_vp.ValidationPeriodID, "[@,\\.\";'\\\\]", string.Empty);
                            //var ValidationPeriodID = "KM2210";
                            // insert ERP Total Discount Offer
                            if (listPHD[0].TypeCTKM == "Total Discount Offer")
                            {
                                var list_DO = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_TotalDiscountOffer_DETAIL(codeKM);
                                var list_DOL = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_TotalDiscountOfferLine_DETAIL(codeKM);
                                if (list_DO.Count > 0 && list_DOL.Count > 0)
                                {
                                    List<Models.ERP_API.Promotion.TotalDiscountOfferLines> objLine = new List<Models.ERP_API.Promotion.TotalDiscountOfferLines>();
                                    List<Models.ERP_API.Promotion.BenefitListTotalDiscounts> objBene = new List<Models.ERP_API.Promotion.BenefitListTotalDiscounts>();

                                    foreach (var itemDO in list_DO)
                                    {
                                        Models.ERP_API.Promotion.BenefitListTotalDiscounts subDO = new Models.ERP_API.Promotion.BenefitListTotalDiscounts
                                        {
                                            Step_Amount = itemDO.StepAmount,
                                            Type = itemDO.Type,
                                            No = itemDO.No,
                                            Value_Type = itemDO.ValueType,
                                            Value = itemDO.Value
                                        };
                                        objBene.Add(subDO);
                                    }
                                    foreach (var itemDOL in list_DOL)
                                    {
                                        Models.ERP_API.Promotion.TotalDiscountOfferLines subDOL = new Models.ERP_API.Promotion.TotalDiscountOfferLines
                                        {
                                            Type = itemDOL.Type,
                                            No = itemDOL.No
                                        };
                                        objLine.Add(subDOL);
                                    }

                                    Models.ERP_API.Promotion.TotalDiscountOffer it = new Models.ERP_API.Promotion.TotalDiscountOffer
                                    {
                                        No = listPHD[0].CodeKM.Trim(),
                                        Description = listPHD[0].NameKM,
                                        Price_Group = listPHD[0].PriceGroup,
                                        Validation_Period_ID = ValidationPeriodID,
                                        TotalDiscountOfferLine = objLine.ToArray(),
                                        BenefitListTotalDiscount = objBene.ToArray()
                                    };

                                    var data = await DataAccess.ERP_API_Promorion_DataAccess.API_createTotalDiscountOffer(it);
                                    if (data.codeReturn)
                                    {
                                        //cập nhật trạng thái header
                                        var result = DataAccess.DataAccessKM.SP_BIBOSMART_KM_DuyetAllPromotion(codeKM, Session["uid"].ToString());
                                        err.RespId = 0;
                                        err.RespMsg = "Duyệt thành công !";
                                    }
                                    else
                                    {
                                        err.RespId = -1;
                                        err.RespMsg = "Có lỗi. Vui lòng thử lại sau !";
                                    }
                                }
                            }
                            // insert ERP Discount Offers
                            if (listPHD[0].TypeCTKM == "Discount Offers")
                            {
                                var listDisOffer = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_DiscountOffer_DETAIL(codeKM);
                                if (listDisOffer.Count > 0)
                                {
                                    List<Models.ERP_API.Promotion.DiscountOfferLine> objMXL = new List<Models.ERP_API.Promotion.DiscountOfferLine>();
                                    foreach (var item in listDisOffer)
                                    {
                                        Models.ERP_API.Promotion.DiscountOfferLine subDOL = new Models.ERP_API.Promotion.DiscountOfferLine
                                        {
                                            No = item.MaHang,
                                            Deal_Price_Disc_Percent = item.DiscStdPrice
                                        };
                                        objMXL.Add(subDOL);
                                    }

                                    Models.ERP_API.Promotion.DiscountOffer it = new Models.ERP_API.Promotion.DiscountOffer
                                    {
                                        No = codeKM,
                                        Description = listPHD[0].NameKM,
                                        Price_Group = listPHD[0].PriceGroup,
                                        Validation_Period_ID = ValidationPeriodID,
                                        DiscountOfferLine = objMXL.ToArray()
                                    };

                                    var data = await DataAccess.ERP_API_Promorion_DataAccess.API_createDiscountOffer(it);
                                    if (data.codeReturn)
                                    {
                                        //cập nhật trạng thái header
                                        var result = DataAccess.DataAccessKM.SP_BIBOSMART_KM_DuyetAllPromotion(codeKM, Session["uid"].ToString());
                                        err.RespId = 0;
                                        err.RespMsg = "Duyệt thành công !";
                                    }
                                    else
                                    {
                                        err.RespId = -1;
                                        err.RespMsg = "Có lỗi. Vui lòng thử lại sau !";
                                    }
                                }
                            }
                            if (listPHD[0].TypeCTKM == "Mix&Match")
                            {
                                var listMixMatch = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_MixMatch_DETAIL(codeKM);
                                if (listMixMatch.Count > 0)
                                {
                                    var itemsLineGroup = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_MixMatch_LineGroup_DETAIL(codeKM);
                                    var itemsMixMatchLine = DataAccess.DataAccessKM.SP_BIBOSMART_KM_LINE_MixMatchLine_DETAIL(codeKM);

                                    List<Models.ERP_API.Promotion.MixMatchLineGroup> objMixLineGroup = new List<Models.ERP_API.Promotion.MixMatchLineGroup>();
                                    if (itemsLineGroup.Count > 0)
                                    {
                                        foreach (var itemLG in itemsLineGroup)
                                        {
                                            Models.ERP_API.Promotion.MixMatchLineGroup subMixLG = new Models.ERP_API.Promotion.MixMatchLineGroup
                                            {
                                                Group_No = codeKM,
                                                Line_Group_Code = itemLG.LineGroupCode,
                                                Line_Group_Type = itemLG.lineGroupType,
                                                Value_1 = itemLG.Value1,
                                                Value_2 = itemLG.Value2
                                            };
                                            objMixLineGroup.Add(subMixLG);
                                        }
                                    }
                                    List<Models.ERP_API.Promotion.MixMatchLines> objMixLine = new List<Models.ERP_API.Promotion.MixMatchLines>();
                                    if (itemsMixMatchLine.Count > 0)
                                    {
                                        foreach (var itemMixLine in itemsMixMatchLine)
                                        {
                                            Models.ERP_API.Promotion.MixMatchLines subMixLine = new Models.ERP_API.Promotion.MixMatchLines
                                            {
                                                Item_No = itemMixLine.No,
                                                Line_Group = itemMixLine.LineGroup,
                                                No_of_Items_Needed = itemMixLine.NoItemNeeded,
                                                Type = itemMixLine.Type,
                                                Deal_Price_Disc_Percent = itemMixLine.DealPriceDiscPercent,
                                                Disc_Type = itemMixLine.DiscType
                                            };
                                            objMixLine.Add(subMixLine);
                                        }
                                    }
                                    Models.ERP_API.Promotion.MixMatch it = new Models.ERP_API.Promotion.MixMatch
                                    {
                                        No = codeKM,
                                        Description = listPHD[0].NameKM,
                                        Price_Group = listPHD[0].PriceGroup,
                                        Validation_Period_ID = ValidationPeriodID,
                                        Discount_Type = listMixMatch[0].discountType,
                                        Deal_Price_Value = listMixMatch[0].dealPriceValue,
                                        Discount_Percent_Value = listMixMatch[0].discValue,
                                        Discount_Amount_Value = listMixMatch[0].discountAmoutValue,
                                        No_of_Least_Expensive_Items = listMixMatch[0].noOfLeastItem,
                                        Disc_Percent_of_Least_Expensive = listMixMatch[0].Leastexp,
                                        No_of_Times_Applicable = listMixMatch[0].NoTimeApp,
                                        MixMatchLine = objMixLine.ToArray(),
                                        MixMatchLineGroup = objMixLineGroup
                                    };
                                    var data = await DataAccess.ERP_API_Promorion_DataAccess.API_createMixMatch(it);
                                    if (data.codeReturn)
                                    {
                                        //cập nhật trạng thái header
                                        var result = DataAccess.DataAccessKM.SP_BIBOSMART_KM_DuyetAllPromotion(codeKM, Session["uid"].ToString());
                                        err.RespId = 0;
                                        err.RespMsg = "Duyệt thành công !";
                                    }
                                    else
                                    {
                                        err.RespId = -1;
                                        err.RespMsg = "Có lỗi. Vui lòng thử lại sau !";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        err.RespId = -1;
                        err.RespMsg = "Có lỗi. Mã CTKM không tồn tại";
                    }
                }
                else if (status == "3")
                {
                    var result = DataAccess.DataAccessKM.SP_BIBOSMART_KM_ChangeStatusCTKM(
                            Session["uid"].ToString(),
                            codeKM,
                            status
                    );
                    if (result)
                    {
                        err.RespId = 0;
                        err.RespMsg = "Từ chối thành công";
                    }
                }
                return Json(err);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> savePromotion(ObjPromotion obj)
        {
            var err = new RouteInfo();
            try
            {
                var SourcePromotionHeader = JArray.Parse(obj.SourcePromotionHeader);
                var SourceDiscountOffers = JArray.Parse(obj.SourceDiscountOffers);
                var SourceMemberPointOffer = JArray.Parse(obj.SourceMemberPointOffer);
                var SourceItemPointOffer = JArray.Parse(obj.SourceItemPointOffer);
                var SourceMixMatch = JArray.Parse(obj.SourceMixMatch);
                var SourceMultibuyDiscount = JArray.Parse(obj.SourceMultibuyDiscount);
                var SourceTenderTypeOffer = JArray.Parse(obj.SourceTenderTypeOffer);
                var SourceTotalDiscountOffer = JArray.Parse(obj.SourceTotalDiscountOffer);
                var SourceTotalDiscountOfferLine = JArray.Parse(obj.SourceTotalDiscountOfferLine);
                var SourceDieuKien = JArray.Parse(obj.SourceDieuKien);
                //var SourceGroupKM = JArray.Parse(obj.SourceGroupKM);
                var SourcePopupMixMatch = JArray.Parse(obj.SourcePopupMixMatch);
                var SourcePromotion = JArray.Parse(obj.SourcePromotion);
                var SourceMixMaxLine = JArray.Parse(obj.SourceMixMaxLine);

                var typeCTKM = SourcePromotionHeader[0]["typeCTKM"].ToString();
                var codeKM = SourcePromotionHeader[0]["codeKM"].ToString();

                if (SourcePromotionHeader.Count() > 0)
                {
                    var listHeader = DataAccess.DataAccessKM.SP_BIBOSMART_KM_PROMOTION_HEADER_DETAIL(codeKM);

                    if (listHeader.Count() > 0)
                    {
                        err.RespId = 0;
                        err.RespMsg = "Mã CTKM đã tồn tại !";
                    }
                    else
                    {
                        if (DateTime.Parse(SourcePromotionHeader[0]["frdate"].ToString()) > DateTime.Parse(SourcePromotionHeader[0]["toDate"].ToString()))
                        {
                            err.RespId = 0;
                            err.RespMsg = "Ngày bắt đầu không thể lớn hơn ngày kết thúc. Vui lòng nhập lại !";
                            return Json(err);
                        }
                        if (typeCTKM == "Discount Offers" && SourceDiscountOffers.Count() <= 0)
                        {
                            err.RespId = 0;
                            err.RespMsg = "Bạn chưa nhập C.Line cho Loại CTKM giảm giá !";
                            return Json(err);
                        }
                        if (typeCTKM == "Mix&Match" && SourceMixMaxLine.Count() <= 0)
                        {
                            err.RespId = 0;
                            err.RespMsg = "Bạn chưa nhập C.Line cho CTKM nhiều điều kiện !";
                            return Json(err);
                        }
                        if (typeCTKM == "Total Discount Offer" && SourceTotalDiscountOfferLine.Count() <= 0)
                        {
                            err.RespId = 0;
                            err.RespMsg = "Bạn chưa nhập C.Line cho CTKM nhiều điều kiện !";
                            return Json(err);
                        }
                        if (typeCTKM == "Total Discount Offer" && SourceTotalDiscountOffer.Count() <= 0)
                        {
                            err.RespId = 0;
                            err.RespMsg = "Bạn chưa nhập D.Benefits cho CTKM nhiều điều kiện !";
                            return Json(err);
                        }

                        var result = DataAccess.DataAccessKM.SP_BIBOSMART_ADD_PROMOTION_HEADER(
                            SourcePromotionHeader[0]["typeCTKM"].ToString(),
                            SourcePromotionHeader[0]["target"].ToString(),
                            SourcePromotionHeader[0]["codeKM"].ToString(),
                            SourcePromotionHeader[0]["NameKM"].ToString(),
                            SourcePromotionHeader[0]["toDate"].ToString(),
                            SourcePromotionHeader[0]["frdate"].ToString(),
                            SourcePromotionHeader[0]["Dinhky_VongLap"].ToString(),
                            SourcePromotionHeader[0]["Range"].ToString(),
                            SourcePromotionHeader[0]["StoreGroupType"].ToString(),
                            SourcePromotionHeader[0]["StoreGroup"].ToString(),
                            SourcePromotionHeader[0]["Store_Channel"].ToString(),
                            SourcePromotionHeader[0]["Message1"].ToString(),
                            SourcePromotionHeader[0]["Message2"].ToString(),
                            SourcePromotionHeader[0]["Message3"].ToString(),
                            SourcePromotionHeader[0]["CusDisc"].ToString(),
                            SourcePromotionHeader[0]["CusPriceGroup"].ToString(),
                            SourcePromotionHeader[0]["CouponCode"].ToString(),
                            SourcePromotionHeader[0]["CouponQty"].ToString(),
                            SourcePromotionHeader[0]["SaleTypeFilter"].ToString(),
                            SourcePromotionHeader[0]["AmountTrigger"].ToString(),
                            SourcePromotionHeader[0]["MemberType"].ToString(),
                            SourcePromotionHeader[0]["MemberValue"].ToString(),
                            SourcePromotionHeader[0]["MemberAtt"].ToString(),
                            SourcePromotionHeader[0]["MemberAttValue"].ToString(),
                            SourcePromotionHeader[0]["TenderTypeCode"].ToString(),
                            SourcePromotionHeader[0]["TenderTypeValue"].ToString(),
                            Session["uid"].ToString()
                       );
                        if (result)
                        {

                            if (SourceDieuKien.Count() > 0)
                            {
                                foreach (var itemDK in SourceDieuKien)
                                {
                                    DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_DKHCKHUYENMAI_LINE(
                                            typeCTKM,
                                            codeKM,
                                            itemDK["contentCode"].ToString(),
                                            itemDK["contentName"].ToString(),
                                            itemDK["Promotion"].ToString(),
                                            itemDK["DiscountOffer"].ToString(),
                                            itemDK["LineDiscOffer"].ToString(),
                                            itemDK["MultibuyDiscount"].ToString(),
                                            itemDK["MixMatch"].ToString(),
                                            itemDK["TotalDiscOffer"].ToString(),
                                            itemDK["TenderTypeOffer"].ToString(),
                                            itemDK["MemberPointOffer"].ToString(),
                                            itemDK["ItemPointOffer"].ToString(),
                                            Session["uid"].ToString()
                                    );
                                }

                            }
                            // Giam gia
                            if (typeCTKM == "Discount Offers")
                            {
                                if (SourceDiscountOffers.Count() > 0)
                                {
                                    //Models.ERP_API.Promotion.DiscountOfferLine[] MXL;
                                    foreach (var itemDiscountOffers in SourceDiscountOffers)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_DiscountOffer(
                                              typeCTKM,
                                              codeKM,
                                              itemDiscountOffers["Type"].ToString(),
                                              itemDiscountOffers["MaHang"].ToString(),
                                              itemDiscountOffers["DiscStdPrice"].ToString(),
                                              itemDiscountOffers["DiscAmountStdPrice"].ToString(),
                                              itemDiscountOffers["phuongphap"].ToString()
                                        );
                                    }
                                }
                            }

                            if (typeCTKM == "Item Point Offer")
                            {
                                DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_ItemPointOffer(
                                   typeCTKM,
                                   codeKM,
                                   SourceItemPointOffer[0]["MemberPoint"].ToString(),
                                   SourceItemPointOffer[0]["DiscAmount"].ToString(),
                                   SourceItemPointOffer[0]["Discount"].ToString(),
                                   Session["uid"].ToString()
                               );
                            }
                            if (typeCTKM == "Member Point Offer")
                            {
                                DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_MemberPointOffer(
                                     typeCTKM,
                                     codeKM,
                                     SourceMemberPointOffer[0]["LineSpecific"].ToString(),
                                     SourceMemberPointOffer[0]["ValueType"].ToString(),
                                     SourceMemberPointOffer[0]["PointOfferValue"].ToString(),
                                     Session["uid"].ToString()
                               );
                            }
                            if (typeCTKM == "Mix&Match")
                            {
                                DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_MixMatch(
                                     typeCTKM,
                                     codeKM,
                                     SourceMixMatch[0]["MixDiscountType"].ToString(),
                                     SourceMixMatch[0]["DealPriceValue"].ToString(),
                                     SourceMixMatch[0]["DiscValue"].ToString(),
                                     SourceMixMatch[0]["DiscountAmoutValue"].ToString(),
                                     SourceMixMatch[0]["NoOfLeastItem"].ToString(),
                                     SourceMixMatch[0]["Leastexp"].ToString(),
                                     SourceMixMatch[0]["SameDifLine"].ToString(),
                                     SourceMixMatch[0]["NoTimeApp"].ToString(),
                                     Session["uid"].ToString()
                                );
                                if (SourcePopupMixMatch.Count() > 0)
                                {
                                    foreach (var itemPMixMatch in SourcePopupMixMatch)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_MixMatch_LineGroup(
                                          codeKM,
                                          itemPMixMatch["MixDiscountType"].ToString(),
                                          //itemPMixMatch["GroupNo"].ToString(),
                                          codeKM,
                                          itemPMixMatch["LineGroupCode"].ToString(),
                                          itemPMixMatch["lineGroupType"].ToString(),
                                          itemPMixMatch["value1"].ToString(),
                                          itemPMixMatch["value2"].ToString(),
                                          Session["uid"].ToString()
                                        );
                                    }
                                }
                                if (SourceMixMaxLine.Count() > 0)
                                {
                                    foreach (var itemMxLine in SourceMixMaxLine)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_MixMatchLine(
                                         codeKM,
                                         itemMxLine["Type"].ToString(),
                                         itemMxLine["No"].ToString(),
                                         itemMxLine["Description"].ToString(),
                                         itemMxLine["NoItemNeeded"].ToString(),
                                         itemMxLine["DealPriceDiscPercent"].ToString(),
                                         itemMxLine["DiscType"].ToString(),
                                         itemMxLine["LineGroup"].ToString(),
                                         Session["uid"].ToString()
                                       );
                                    }
                                }
                            }
                            if (typeCTKM == "Multibuy Discounts")
                            {
                                if (SourceMultibuyDiscount.Count() > 0)
                                {
                                    foreach (var itemMD in SourceMultibuyDiscount)
                                    {

                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_MultibuyDiscounts(
                                            typeCTKM,
                                            codeKM,
                                            itemMD["DiscType"].ToString(),
                                            itemMD["MaHang"].ToString(),
                                            itemMD["SLMuaTT"].ToString(),
                                            itemMD["percentDown"].ToString(),
                                            itemMD["valueDown"].ToString(),
                                            itemMD["valueDeal"].ToString(),
                                            Session["uid"].ToString()
                                       );
                                    }
                                }
                            }
                            ///en
                            if (typeCTKM == "Promotions")
                            {
                                if (SourcePromotion.Count() > 0)
                                {
                                    foreach (var itempro in SourcePromotion)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_Promotions(
                                               typeCTKM,
                                               codeKM,
                                               itempro["MaHang"].ToString(),
                                               itempro["xh361"].ToString(),
                                               itempro["range"].ToString(),
                                               itempro["DiscStdPrice"].ToString(),
                                               itempro["DiscAmountStdPrice"].ToString(),
                                               itempro["phuongphap"].ToString(),
                                               Session["uid"].ToString()
                                        );
                                    }
                                }
                            }
                            if (typeCTKM == "Tender Type Offer")
                            {
                                DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_TenderTypeOffer(
                                     typeCTKM,
                                     codeKM,
                                     SourceTenderTypeOffer[0]["TenderOffer"].ToString(),
                                     SourceTenderTypeOffer[0]["TenderOfferAmount"].ToString(),
                                     Session["uid"].ToString()
                                );
                            }
                            if (typeCTKM == "Total Discount Offer")
                            {
                                if (SourceTotalDiscountOffer.Count() > 0 && SourceTotalDiscountOfferLine.Count() > 0)
                                {
                                    foreach (var itemTotalDis in SourceTotalDiscountOffer)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_TotalDiscountOffer(
                                            typeCTKM,
                                            codeKM,
                                            itemTotalDis["StepAmount"].ToString(),
                                            itemTotalDis["Type"].ToString(),
                                            itemTotalDis["No"].ToString(),
                                            itemTotalDis["ValueType"].ToString(),
                                            itemTotalDis["value"].ToString(),
                                            Session["uid"].ToString()
                                        );
                                    }
                                    foreach (var itemsDOL in SourceTotalDiscountOfferLine)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_TotalDiscountOfferLine(
                                            codeKM,
                                            itemsDOL["Type"].ToString(),
                                            itemsDOL["No"].ToString(),
                                            itemsDOL["Description"].ToString()
                                        );
                                    }
                                }
                            }
                            err.RespId = 0;
                            err.RespMsg = "Lưu thông tin thành công";
                        }
                        else
                        {
                            err.RespId = -1;
                            err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại";
                        }
                    }
                }
                else
                {
                    err.RespId = -1;
                    err.RespMsg = "Bạn vui lòng tạo nhóm sp khuyến mại!";
                }
                return Json(err);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            return Json(err);
        }

        [HttpPost]
        public ActionResult UpdatePromotion(ObjPromotion obj)
        {
            var err = new RouteInfo();
            try
            {
                var SourcePromotionHeader = JArray.Parse(obj.SourcePromotionHeader);
                var SourceDiscountOffers = JArray.Parse(obj.SourceDiscountOffers);
                var SourceMemberPointOffer = JArray.Parse(obj.SourceMemberPointOffer);
                var SourceItemPointOffer = JArray.Parse(obj.SourceItemPointOffer);
                var SourceMixMatch = JArray.Parse(obj.SourceMixMatch);
                var SourceMultibuyDiscount = JArray.Parse(obj.SourceMultibuyDiscount);
                var SourceTenderTypeOffer = JArray.Parse(obj.SourceTenderTypeOffer);
                var SourceTotalDiscountOffer = JArray.Parse(obj.SourceTotalDiscountOffer);
                var SourceDieuKien = JArray.Parse(obj.SourceDieuKien);
                var SourcePopupMixMatch = JArray.Parse(obj.SourcePopupMixMatch);
                var SourcePromotion = JArray.Parse(obj.SourcePromotion);
                var SourceTotalDiscountOfferLine = JArray.Parse(obj.SourceTotalDiscountOfferLine);
                var SourceMixMaxLine = JArray.Parse(obj.SourceMixMaxLine);


                var typeCTKM = SourcePromotionHeader[0]["typeCTKM"].ToString();
                var codeKM = SourcePromotionHeader[0]["codeKM"].ToString();
                if (codeKM.Length > 0)
                {
                    var result = DataAccess.DataAccessKM.SP_BIBOSMART_PROMOTION_HEADER_UPDATE(
                       SourcePromotionHeader[0]["typeCTKM"].ToString(),
                       SourcePromotionHeader[0]["target"].ToString(),
                       SourcePromotionHeader[0]["codeKM"].ToString(),
                       SourcePromotionHeader[0]["NameKM"].ToString(),
                       SourcePromotionHeader[0]["toDate"].ToString(),
                       SourcePromotionHeader[0]["frdate"].ToString(),
                       SourcePromotionHeader[0]["Dinhky_VongLap"].ToString(),
                       SourcePromotionHeader[0]["Range"].ToString(),
                       SourcePromotionHeader[0]["StoreGroupType"].ToString(),
                       SourcePromotionHeader[0]["StoreGroup"].ToString(),
                       SourcePromotionHeader[0]["Store_Channel"].ToString(),
                       SourcePromotionHeader[0]["Message1"].ToString(),
                       SourcePromotionHeader[0]["Message2"].ToString(),
                       SourcePromotionHeader[0]["Message3"].ToString(),
                       SourcePromotionHeader[0]["CusDisc"].ToString(),
                       SourcePromotionHeader[0]["CusPriceGroup"].ToString(),
                       SourcePromotionHeader[0]["CouponCode"].ToString(),
                       SourcePromotionHeader[0]["CouponQty"].ToString(),
                       SourcePromotionHeader[0]["SaleTypeFilter"].ToString(),
                       SourcePromotionHeader[0]["AmountTrigger"].ToString(),
                       SourcePromotionHeader[0]["MemberType"].ToString(),
                       SourcePromotionHeader[0]["MemberValue"].ToString(),
                       SourcePromotionHeader[0]["MemberAtt"].ToString(),
                       SourcePromotionHeader[0]["MemberAttValue"].ToString(),
                       SourcePromotionHeader[0]["TenderTypeCode"].ToString(),
                       SourcePromotionHeader[0]["TenderTypeValue"].ToString(),
                       Session["uid"].ToString()
                    );
                    if (result)
                    {
                        var rsDelete = DataAccess.DataAccessKM.SP_BIBOSMART_DELETE_PROMOTION_TABLE(codeKM);
                        if (rsDelete)
                        {
                            if (SourceDieuKien.Count() > 0)
                            {
                                foreach (var itemDK in SourceDieuKien)
                                {
                                    DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_DKHCKHUYENMAI_LINE(
                                            typeCTKM,
                                            codeKM,
                                            itemDK["contentCode"].ToString(),
                                            itemDK["contentName"].ToString(),
                                            itemDK["Promotion"].ToString(),
                                            itemDK["DiscountOffer"].ToString(),
                                            itemDK["LineDiscOffer"].ToString(),
                                            itemDK["MultibuyDiscount"].ToString(),
                                            itemDK["MixMatch"].ToString(),
                                            itemDK["TotalDiscOffer"].ToString(),
                                            itemDK["TenderTypeOffer"].ToString(),
                                            itemDK["MemberPointOffer"].ToString(),
                                            itemDK["ItemPointOffer"].ToString(),
                                            Session["uid"].ToString()
                                    );
                                }
                            }
                            if (typeCTKM == "Discount Offers")
                            {
                                if (SourceDiscountOffers.Count() > 0)
                                {
                                    foreach (var itemDiscountOffers in SourceDiscountOffers)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_DiscountOffer(
                                              typeCTKM,
                                              codeKM,
                                              itemDiscountOffers["Type"].ToString(),
                                              itemDiscountOffers["MaHang"].ToString(),
                                              itemDiscountOffers["DiscStdPrice"].ToString(),
                                              itemDiscountOffers["DiscAmountStdPrice"].ToString(),
                                              itemDiscountOffers["phuongphap"].ToString()
                                        );
                                    }
                                }
                            }
                            if (typeCTKM == "Item Point Offer")
                            {
                                DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_ItemPointOffer(
                                   typeCTKM,
                                   codeKM,
                                   SourceItemPointOffer[0]["MemberPoint"].ToString(),
                                   SourceItemPointOffer[0]["DiscAmount"].ToString(),
                                   SourceItemPointOffer[0]["Discount"].ToString(),
                                   Session["uid"].ToString()
                               );
                            }
                            if (typeCTKM == "Member Point Offer")
                            {
                                DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_MemberPointOffer(
                                     typeCTKM,
                                     codeKM,
                                     SourceMemberPointOffer[0]["LineSpecific"].ToString(),
                                     SourceMemberPointOffer[0]["ValueType"].ToString(),
                                     SourceMemberPointOffer[0]["PointOfferValue"].ToString(),
                                     Session["uid"].ToString()
                               );
                            }

                            if (typeCTKM == "Mix&Match")
                            {
                                DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_MixMatch(
                                     typeCTKM,
                                     codeKM,
                                     SourceMixMatch[0]["MixDiscountType"].ToString(),
                                     SourceMixMatch[0]["DealPriceValue"].ToString(),
                                     SourceMixMatch[0]["DiscValue"].ToString(),
                                     SourceMixMatch[0]["DiscountAmoutValue"].ToString(),
                                     SourceMixMatch[0]["NoOfLeastItem"].ToString(),
                                     SourceMixMatch[0]["Leastexp"].ToString(),
                                     SourceMixMatch[0]["SameDifLine"].ToString(),
                                     SourceMixMatch[0]["NoTimeApp"].ToString(),
                                     Session["uid"].ToString()
                                );
                                if (SourcePopupMixMatch.Count() > 0)
                                {
                                    foreach (var itemPMixMatch in SourcePopupMixMatch)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_MixMatch_LineGroup(
                                          codeKM,
                                          itemPMixMatch["MixDiscountType"].ToString(),
                                          //itemPMixMatch["GroupNo"].ToString(),
                                          codeKM,
                                          itemPMixMatch["LineGroupCode"].ToString(),
                                          itemPMixMatch["lineGroupType"].ToString(),
                                          itemPMixMatch["value1"].ToString(),
                                          itemPMixMatch["value2"].ToString(),
                                          Session["uid"].ToString()
                                        );
                                    }
                                }
                                if (SourceMixMaxLine.Count() > 0)
                                {
                                    foreach (var itemMxLine in SourceMixMaxLine)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_MixMatchLine(
                                         codeKM,
                                         itemMxLine["Type"].ToString(),
                                         itemMxLine["No"].ToString(),
                                         itemMxLine["Description"].ToString(),
                                         itemMxLine["NoItemNeeded"].ToString(),
                                         itemMxLine["DealPriceDiscPercent"].ToString(),
                                         itemMxLine["DiscType"].ToString(),
                                         itemMxLine["LineGroup"].ToString(),
                                         Session["uid"].ToString()
                                       );
                                    }
                                }
                            }
                            if (typeCTKM == "Multibuy Discounts")
                            {
                                if (SourceMultibuyDiscount.Count() > 0)
                                {
                                    foreach (var itemMD in SourceMultibuyDiscount)
                                    {

                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_MultibuyDiscounts(
                                            typeCTKM,
                                            codeKM,
                                            itemMD["DiscType"].ToString(),
                                            itemMD["MaHang"].ToString(),
                                            itemMD["SLMuaTT"].ToString(),
                                            itemMD["percentDown"].ToString(),
                                            itemMD["valueDown"].ToString(),
                                            itemMD["valueDeal"].ToString(),
                                            Session["uid"].ToString()
                                       );
                                    }
                                }
                            }
                            ///en
                            if (typeCTKM == "Promotions")
                            {
                                if (SourcePromotion.Count() > 0)
                                {
                                    foreach (var itempro in SourcePromotion)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_Promotions(
                                               typeCTKM,
                                               codeKM,
                                               itempro["MaHang"].ToString(),
                                               itempro["xh361"].ToString(),
                                               itempro["range"].ToString(),
                                               itempro["DiscStdPrice"].ToString(),
                                               itempro["DiscAmountStdPrice"].ToString(),
                                               itempro["phuongphap"].ToString(),
                                               Session["uid"].ToString()
                                        );
                                    }
                                }
                            }
                            if (typeCTKM == "Tender Type Offer")
                            {
                                DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_TenderTypeOffer(
                                     typeCTKM,
                                     codeKM,
                                     SourceTenderTypeOffer[0]["TenderOffer"].ToString(),
                                     SourceTenderTypeOffer[0]["TenderOfferAmount"].ToString(),
                                     Session["uid"].ToString()
                                );
                            }
                            if (typeCTKM == "Total Discount Offer")
                            {
                                if (SourceTotalDiscountOffer.Count() > 0 && SourceTotalDiscountOfferLine.Count() > 0)
                                {
                                    foreach (var itemTotalDis in SourceTotalDiscountOffer)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_TotalDiscountOffer(
                                            typeCTKM,
                                            codeKM,
                                            itemTotalDis["StepAmount"].ToString(),
                                            itemTotalDis["Type"].ToString(),
                                            itemTotalDis["No"].ToString(),
                                            itemTotalDis["ValueType"].ToString(),
                                            itemTotalDis["value"].ToString(),
                                            Session["uid"].ToString()
                                        );
                                    }
                                    foreach (var itemsDOL in SourceTotalDiscountOfferLine)
                                    {
                                        DataAccess.DataAccessKM.SP_BIBOSMART_KM_ADD_LINE_TotalDiscountOfferLine(
                                            codeKM,
                                            itemsDOL["Type"].ToString(),
                                            itemsDOL["No"].ToString(),
                                            itemsDOL["Description"].ToString()
                                        );
                                    }
                                }
                            }

                            err.RespId = 0;
                            err.RespMsg = "Lưu thông tin thành công";
                        }
                    }
                }
                return Json(err);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            return Json(err);
        }
    }

}