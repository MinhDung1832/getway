using MP_VendorTool.Common;
using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Account;
using MP_VendorTool.Models.Promotion;
using MP_VendorTool.Models.PushSale;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MP_VendorTool.Controllers
{
    public class PushSaleController : Controller
    {
        #region Chỉ định khuyến mãi PushSale
        public ActionResult Index()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("PushSale", "Index")) return RedirectToAction("Index", "Home");

                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var list_vendor = DataAccess.DataAccessPushSale.SP_PushSale_Vender(Session["VendorCode"].ToString());
                        ViewBag.list_vendor = list_vendor;
                    }
                    else
                    {
                        var list_vendor = DataAccess.DataAccessPushSale.SP_PushSale_Vender("");
                        ViewBag.list_vendor = list_vendor;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("PushSale", "Index");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PushSaleNCC");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult GetList_PushSale(string vendorNo, string MaHang, string Barcode)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        System.Data.DataTable table = DataAccess.DataAccessPushSale.SP_CTKM_PushSale_HHOA_KGUI(Session["VendorCode"].ToString(), MaHang, Barcode);
                        return PartialView("~/Views/PushSale/Partial/__Index.cshtml", table);
                    }
                    else
                    {
                        System.Data.DataTable table = DataAccess.DataAccessPushSale.SP_CTKM_PushSale_HHOA_KGUI(vendorNo, MaHang, Barcode);
                        return PartialView("~/Views/PushSale/Partial/__Index.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_DebtDeposit");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult GetListBarcode(string itemNo)
        {
            try
            {
                var bn = DataAccess.DataAccessPushSale.SP_PushSale_Vender_BARCODE(itemNo);
                if (bn.Count > 0)
                {
                    return Json(JsonConvert.SerializeObject(bn));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListBarcode");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetList_NCC_Produts(string NCC)
        {
            try
            {
                var bn = DataAccess.DataAccessPushSale.SP_PushSale_Vender_ITEM_Vendor(NCC);
                if (bn.Count > 0)
                {
                    return Json(JsonConvert.SerializeObject(bn));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListBarcode");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult Update_PushSale_Vender_Item(List<PushSale_Vender_Item> lst)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {

                foreach (PushSale_Vender_Item po in lst)
                {
                    if (DateTime.Parse(po.NgayKetThuc.ToString()) <= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        return Json(new { code = 0, message = "" });
                    }

                    DataAccess.DataAccessPushSale.Update_PushSale_Vender_Item(Session["uid"].ToString(), po);
                }
                return Json(new { code = 1, message = "" });
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion
        #region QL Chỉ định khuyến mãi PushSale
        public ActionResult QLPushSale()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("PushSale", "QLPushSale")) return RedirectToAction("Index", "Home");

                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {

                        var list_vendor = DataAccess.DataAccessPushSale.SP_PushSale_Vender(Session["VendorCode"].ToString());
                        ViewBag.list_vendor = list_vendor;
                    }
                    else
                    {
                        var list_vendor = DataAccess.DataAccessPushSale.SP_PushSale_Vender("");
                        ViewBag.list_vendor = list_vendor;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("PushSale", "QLPushSale");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PushSaleNCC");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult GetList_QLPushSale(string vendorNo, string MaHang, string Barcode, string TrangThai)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                      
                        System.Data.DataTable table = DataAccess.DataAccessPushSale.QL_SP_CTKM_PushSale_HHOA_KGUI(Session["VendorCode"].ToString(), MaHang, Barcode, TrangThai);
                        return PartialView("~/Views/PushSale/Partial/__QLPushSale.cshtml", table);
                    }
                    else
                    {
                        System.Data.DataTable table = DataAccess.DataAccessPushSale.QL_SP_CTKM_PushSale_HHOA_KGUI(vendorNo, MaHang, Barcode, TrangThai);
                        return PartialView("~/Views/PushSale/Partial/__QLPushSale.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_DebtDeposit");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        #endregion


        public ActionResult PushSaleNCC()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var listDiv = DataAccess.DataAccess.SP_Pushsale_getDiv_MaNCC(Session["VendorCode"].ToString());
                        ViewBag.listDiv = listDiv;

                        var list_datalist_PhamVi = DataAccess.DataAccess.sp_VendorTool_MD_Sub_get();
                        ViewBag.list_datalist_PhamVi = list_datalist_PhamVi;

                        var lstItem = DataAccess.DataAccessKM.SP_getWay_Pro_ITEM_Vendor(Session["VendorCode"].ToString());
                        ViewBag.lstItem = lstItem;
                    }
                    else
                    {
                        var listDiv = DataAccess.DataAccess.SP_Pushsale_getDiv();
                        ViewBag.listDiv = listDiv;

                        var list_datalist_PhamVi = DataAccess.DataAccess.sp_VendorTool_MD_Sub_get();
                        ViewBag.list_datalist_PhamVi = list_datalist_PhamVi;

                        var lstItem = DataAccess.DataAccessKM.SP_getWay_Pro_ITEM_Vendor("");
                        ViewBag.lstItem = lstItem;
                    }

                    var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    var lstCusPriceGroup = DataAccess.DataAccess.GetCustomerPriceGroup();
                    ViewBag.lstCusPriceGroup = lstCusPriceGroup;
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("PushSale", "PushSaleNCC");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PushSaleNCC");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Create_PushSale_NCC_Header(PUSHSALES_Header info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    bool rs = DataAccess.DataAccess.Create_PushSale_NCC_Header(info, Session["uid"].ToString());
                    return Json(rs);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pro_createupdate_Orientation_Bonus");
                return null;
            }
        }

        #region ThuongNhanVien
        public ActionResult ThuongNhanVien()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var List_Mahang = DataAccess.DataAccess.sp_Pushsale_NCC_get(Session["VendorCode"].ToString());
                        ViewBag.List_Mahang = List_Mahang;

                        // popup
                        var listDiv = DataAccess.DataAccess.SP_Pushsale_getDiv_MaNCC(Session["VendorCode"].ToString());
                        ViewBag.listDiv = listDiv;
                    }
                    else
                    {
                        var List_Mahang = DataAccess.DataAccess.sp_Pushsale_NCC_get("");
                        ViewBag.List_Mahang = List_Mahang;

                        // popup
                        var listDiv = DataAccess.DataAccess.SP_Pushsale_getDiv();
                        ViewBag.listDiv = listDiv;
                    }

                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        ViewBag.VendorNo = Session["VendorCode"];
                        ViewBag.VendorName = Session["VendorName"];
                    }

                    var list_datalist_PhamVi = DataAccess.DataAccess.sp_VendorTool_MD_Sub_get();
                    ViewBag.list_datalist_PhamVi = list_datalist_PhamVi;

                    var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("PushSale", "ThuongNhanVien");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PushSaleNCC");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Get_List_ThuongNhanVien(string VendorCode, string MaHang, string PhamVi, string ThoiGian, string Status, string GAP)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");
                    // if (us_role.roleCode == "R001")
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        DataTable table = DataAccess.DataAccess.Get_List_ThuongNhanVien(MaHang, PhamVi, ThoiGian, Status, GAP, Session["VendorCode"].ToString());
                        return PartialView("~/Views/PushSale/Partial/__ThuongNhanVien.cshtml", table);
                    }
                    else
                    {
                        DataTable table = DataAccess.DataAccess.Get_List_ThuongNhanVien(MaHang, PhamVi, ThoiGian, Status, GAP, VendorCode);
                        return PartialView("~/Views/PushSale/Partial/__ThuongNhanVien.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_ThuongNhanVien");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Create_PushSale_NCC_ThuongNhanVien(PUSHSALES_ThuongNhanVien info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    string MaxID = DataAccess.DataAccess.ShowMaxID();
                    bool rs = DataAccess.DataAccess.SP_SAVE_PUSHSALES_ThuongNhanVien(info, MaxID, Session["uid"].ToString());
                    return Json(rs);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pro_createupdate_Orientation_Bonus");
                return null;
            }
        }

        [HttpPost]
        public ActionResult Delete_ThuongNhanVien(string[] IDPusSale)
        {
            try
            {
                for (int i = 0; i < IDPusSale.Length; i++)
                {
                    var item = DataAccess.DataAccess.SP_PushSale_DELETE_ThuongNhanVien(IDPusSale[i].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_ThuongNhanVien");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult Update_Status_ThuongNhanVien(string[] IDPusSale, string HanhDong)
        {
            try
            {
                for (int i = 0; i < IDPusSale.Length; i++)
                {
                    var item = DataAccess.DataAccess.Update_Status_ThuongNhanVien(IDPusSale[i].ToString(), HanhDong);
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_ThuongNhanVien");
                return Json(new { code = 1, message = "" });
            }
        }

        public ActionResult getBrandNCCDatalist(string Div, string MaNCC)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var lst_brand = DataAccess.DataAccess.SP_Pushsale_getVendorBrandok(Div, MaNCC);
                    return Json(lst_brand);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getBrandNCCDatalist");
                return Json(new { code = 1, message = "" });
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult sp_Pushsale_Brand_NCC_get(string brand, string VendorCode)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var lst_brand = DataAccess.DataAccess.sp_Pushsale_Brand_NCC_get(brand, VendorCode);
                    return Json(lst_brand);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getBrandNCCDatalist");
                return Json(new { code = 1, message = "" });
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult sp_Pushsale_GAP_ThuongNhanVien_get()
        {
            try
            {
                var Items = DataAccess.DataAccess.sp_Pushsale_GAP_ThuongNhanVien_get(Session["VendorCode"].ToString());
                return Json(Items);
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_ThuongNhanVien_get");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult Listget_ThuongNhanVien_PopUp(string ID)
        {
            try
            {
                var list = DataAccess.DataAccess.Listget_ThuongNhanVien_PopUp(ID);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_ThuongNhanVien_PopUp");
                return Json(null);
            }
        }
        public ActionResult Update_ThuongNhanVien(PUSHSALES_ThuongNhanVien info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    bool rs = DataAccess.DataAccess.Update_ThuongNhanVien(info);
                    return Json(rs);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_ThuongNhanVien");
                return null;
            }
        }
        #endregion

        #region GiaTangTrungBay
        public ActionResult GiaTangTrungBay()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var List_Mahang = DataAccess.DataAccess.sp_Pushsale_NCC_get(Session["VendorCode"].ToString());
                        ViewBag.List_Mahang = List_Mahang;
                    }
                    else
                    {
                        var List_Mahang = DataAccess.DataAccess.sp_Pushsale_NCC_get("");
                        ViewBag.List_Mahang = List_Mahang;
                    }
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        ViewBag.VendorNo = Session["VendorCode"];
                        ViewBag.VendorName = Session["VendorName"];
                    }

                    var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    var list_datalist_PhamVi = DataAccess.DataAccess.sp_VendorTool_MD_Sub_get();
                    ViewBag.list_datalist_PhamVi = list_datalist_PhamVi;

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("PushSale", "GiaTangTrungBay");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PushSaleNCC");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Create_PushSale_NCC_GiaTangTrungBay(PUSHSALES_GiaTangTrungBay info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    string MaxID = DataAccess.DataAccess.ShowMaxID();
                    bool rs = DataAccess.DataAccess.SP_SAVE_PUSHSALES_GiaTangTrungBay(info, MaxID, Session["uid"].ToString());
                    return Json(rs);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pro_createupdate_Orientation_Bonus");
                return null;
            }
        }

        [HttpPost]
        public ActionResult Get_List_GiaTangTrungBay(string VendorCode, string MaHang, string Status, string GAP)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        DataTable table = DataAccess.DataAccess.Get_List_GiaTangTrungBay(MaHang, Status, GAP, Session["VendorCode"].ToString());
                        return PartialView("~/Views/PushSale/Partial/__GiaTangTrungBay.cshtml", table);
                    }
                    else
                    {
                        DataTable table = DataAccess.DataAccess.Get_List_GiaTangTrungBay(MaHang, Status, GAP, VendorCode);
                        return PartialView("~/Views/PushSale/Partial/__GiaTangTrungBay.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_GiaTangTrungBay");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Delete_GiaTangTrungBay(string[] IDPusSale)
        {
            try
            {
                for (int i = 0; i < IDPusSale.Length; i++)
                {
                    var item = DataAccess.DataAccess.SP_PushSale_DELETE_GiaTangTrungBay(IDPusSale[i].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_GiaTangTrungBay");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult Update_Status_GiaTangTrungBay(string[] IDPusSale, string HanhDong)
        {
            try
            {
                for (int i = 0; i < IDPusSale.Length; i++)
                {
                    var item = DataAccess.DataAccess.Update_Status_GiaTangTrungBay(IDPusSale[i].ToString(), HanhDong);
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_GiaTangTrungBay");
                return Json(new { code = 1, message = "" });
            }
        }
        public ActionResult sp_Pushsale_GAP_GiaTangTrungBay_get()
        {
            try
            {
                var Items = DataAccess.DataAccess.sp_Pushsale_GAP_GiaTangTrungBay_get(Session["VendorCode"].ToString());
                return Json(Items);
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_GiaTangTrungBay_get");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult Listget_GiaTangTrungBay_PopUp(string ID)
        {
            try
            {
                var list = DataAccess.DataAccess.Listget_GiaTangTrungBay_PopUp(ID);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_GiaTangTrungBay_PopUp");
                return Json(null);
            }
        }
        public ActionResult Update_GiaTangTrungBay(PUSHSALES_GiaTangTrungBay info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    bool rs = DataAccess.DataAccess.Update_GiaTangTrungBay(info);
                    return Json(rs);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_GiaTangTrungBay");
                return null;
            }
        }

        #endregion

        #region Discount Offer
        public ActionResult SavePushSales_DiscountOffer(ObjPushSales_DiscountOffer obj)
        {
            var err = new RouteInfo();
            try
            {
                string MaxID = DataAccess.DataAccess.ShowMaxID();
                string MaCTKM = DataAccess.DataAccess.ShowMaxID_Discount_Offer();

                var SourceCTKM = JArray.Parse(obj.SourceCTKM);
                var SourceCTKMPrice = JArray.Parse(obj.SourceCTKMPrice);
                if (SourceCTKM.Count() <= 0)
                {
                    err.RespId = -1;
                    err.RespMsg = "Bạn vui lòng kiểm tra lại đầu vào !";
                    return Json(err);
                }
                var result = DataAccess.DataAccess.SP_SAVE_PushSaleNCC_Discount_Offer(
                             MaxID
                           , SourceCTKM[0]["MaNCC"].ToString()
                           , SourceCTKM[0]["TenNCC"].ToString()
                            , MaCTKM.Trim()
                           //, SourceCTKM[0]["MaCTKM"].ToString()
                           , SourceCTKM[0]["FromDay"].ToString()
                           , SourceCTKM[0]["ToDay"].ToString()
                           , SourceCTKM[0]["CouponCode"].ToString()
                           , SourceCTKM[0]["CouponName"].ToString()
                           , SourceCTKM[0]["PriceGroupCode"].ToString()
                           , SourceCTKM[0]["PriceGroupName"].ToString()
                           , Session["uid"].ToString()
                       );

                if (result == true)
                {
                    if (SourceCTKM.Count() > 0)
                    {
                        foreach (var item in SourceCTKMPrice)
                        {
                            DataAccess.DataAccess.SP_SAVE_PushSaleNCC_Discount_Line(
                            SourceCTKM[0]["MaNCC"].ToString(),
                            SourceCTKM[0]["TenNCC"].ToString(),
                            MaCTKM.Trim(),
                            //SourceCTKM[0]["MaCTKM"].ToString(),
                            item["Type"].ToString(),
                            item["ProductName"].ToString(),
                            item["ProductCode"].ToString(),
                            item["DiscStdPrice"].ToString(),
                            item["DiscAmountStdPrice"].ToString(),
                            Session["uid"].ToString()
                            );
                        }
                    }

                    err.RespId = 0;
                    err.RespMsg = "Lưu thông tin thành công";
                }
                else
                {
                    err.RespId = -1;
                    err.RespMsg = "Có lỗi xảy ra. Vui lòng thử lại sau !";
                }

                return Json(err);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            return Json(err);
        }

        public ActionResult Update_PushSales_DiscountOffer(ObjPushSales_DiscountOffer obj)
        {
            var err = new RouteInfo();
            try
            {
                var SourceCTKM = JArray.Parse(obj.SourceCTKM);
                var SourceCTKMPrice = JArray.Parse(obj.SourceCTKMPrice);
                if (SourceCTKM.Count() <= 0)
                {
                    err.RespId = -1;
                    err.RespMsg = "Bạn vui lòng kiểm tra lại đầu vào !";
                    return Json(err);
                }

                var result = DataAccess.DataAccess.SP_UPDATE_PushSaleNCC_Discount_Offer(
                            SourceCTKM[0]["ID"].ToString()
                           , SourceCTKM[0]["MaCTKM"].ToString()
                           , SourceCTKM[0]["FromDay"].ToString()
                           , SourceCTKM[0]["ToDay"].ToString()
                           , SourceCTKM[0]["CouponCode"].ToString()
                           , SourceCTKM[0]["CouponName"].ToString()
                           , SourceCTKM[0]["PriceGroupCode"].ToString()
                           , SourceCTKM[0]["PriceGroupName"].ToString()
                           , Session["uid"].ToString()
                       );

                if (result == true)
                {
                    // Xóa bảng Line
                    var result2 = DataAccess.DataAccess.SP_Discount_Offer_DELETE_UPDATE(SourceCTKM[0]["MaCTKM"].ToString());

                    if (SourceCTKM.Count() > 0)
                    {
                        foreach (var item in SourceCTKMPrice)
                        {
                            DataAccess.DataAccess.SP_SAVE_PushSaleNCC_Discount_Line(
                            SourceCTKM[0]["MaNCC"].ToString(),
                            SourceCTKM[0]["TenNCC"].ToString(),
                            SourceCTKM[0]["MaCTKM"].ToString(),
                            item["Type"].ToString(),
                            item["ProductName"].ToString(),
                            item["ProductCode"].ToString(),
                            item["DiscStdPrice"].ToString(),
                            item["DiscAmountStdPrice"].ToString(),
                            Session["uid"].ToString()
                            );
                        }
                    }

                    err.RespId = 0;
                    err.RespMsg = "Cập nhật thành công";
                }
                else
                {
                    err.RespId = -1;
                    err.RespMsg = "Có lỗi xảy ra. Vui lòng thử lại sau !";
                }

                return Json(err);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            return Json(err);
        }

        public ActionResult API_GetCodeCTKMPushSale()
        {
            try
            {
                var lst = DataAccess.DataAccess.Get_Discount_Offer_TAO_MACTKM();
                return Json(lst);
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "API_GetCodeCTKMPushSale");
                return Json(null);
            }
        }
        public ActionResult GetListNoTotalDisOffer()
        {
            try
            {
                var Items = DataAccess.DataAccess.SP_PushSale_Coupon_DETAIL();
                return Json(Items);
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListNoTotalDisOffer");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult Discount_Offer_View(string MaCTKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccess.SP_TRADTERM_Discount_Offer_View(MaCTKM);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Discount_Offer_Line_View(string MaCTKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccess.SP_TRADTERM_Discount_Line_Offer_View(MaCTKM);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region Mix & Match
        public ActionResult SavePushSales_MixMatch(ObjPushSales_MixMaxLine obj)
        {
            var err = new RouteInfo();
            try
            {
                string MaxID = DataAccess.DataAccess.ShowMaxID();
                string MaCTKM = DataAccess.DataAccess.ShowMaxID_MixMatch();

                var SourceMixMatch = JArray.Parse(obj.SourceMixMatch);
                var SourceMixMaxLine = JArray.Parse(obj.SourceMixMaxLine);
                var SourceMixMaxLineGroup = JArray.Parse(obj.SourceMixMaxLineGroup);

                if (SourceMixMatch.Count() <= 0)
                {
                    err.RespId = -1;
                    err.RespMsg = "Bạn vui lòng kiểm tra lại đầu vào !";
                    return Json(err);
                }
                var result = DataAccess.DataAccess.SP_SAVE_PushSaleNCC_MixMatch(
                             MaxID
                            , SourceMixMatch[0]["MaNCC"].ToString()
                           , SourceMixMatch[0]["TenNCC"].ToString()
                           , MaCTKM.Trim()
                           // , SourceMixMatch[0]["MaCTKM"].ToString()
                           , SourceMixMatch[0]["CouponCode"].ToString()
                           , SourceMixMatch[0]["CouponName"].ToString()
                           , SourceMixMatch[0]["FromDay"].ToString()
                           , SourceMixMatch[0]["ToDay"].ToString()
                           , SourceMixMatch[0]["PriceGroupCode"].ToString()
                           , SourceMixMatch[0]["PriceGroupName"].ToString()

                           , SourceMixMatch[0]["NoOfLeastItem"].ToString()
                           , SourceMixMatch[0]["Leastexp"].ToString()
                           , SourceMixMatch[0]["Same_DifLine"].ToString()
                           , SourceMixMatch[0]["Mix_DiscountType"].ToString()
                           , SourceMixMatch[0]["DealPriceValue"].ToString()
                           , SourceMixMatch[0]["DiscValue"].ToString()
                           , SourceMixMatch[0]["DiscountAmoutValue"].ToString()
                           , SourceMixMatch[0]["NoTimeApp"].ToString()
                           , Session["uid"].ToString()
                       );

                if (result == true)
                {
                    if (SourceMixMaxLine.Count() > 0)
                    {
                        foreach (var item in SourceMixMaxLine)
                        {
                            DataAccess.DataAccess.SP_SAVE_PushSaleNCC_MixMatch_Line(
                            SourceMixMatch[0]["MaNCC"].ToString(),
                            SourceMixMatch[0]["TenNCC"].ToString(),
                            //SourceMixMatch[0]["MaCTKM"].ToString(),
                            MaCTKM.Trim(),
                            item["Type"].ToString(),
                            item["ProductName"].ToString(),
                            item["ProductCode"].ToString(),
                            item["NoItemNeeded"].ToString(),
                            item["DealPriceDiscPercent"].ToString(),
                            item["DiscType"].ToString(),
                            item["LineGroup"].ToString(),
                            Session["uid"].ToString()
                            );
                        }
                    }
                    if (SourceMixMaxLineGroup.Count() > 0)
                    {
                        foreach (var item in SourceMixMaxLineGroup)
                        {
                            DataAccess.DataAccess.SP_SAVE_PushSaleNCC_MixMatch_Line_Group(
                            SourceMixMatch[0]["MaNCC"].ToString(),
                            SourceMixMatch[0]["TenNCC"].ToString(),
                            //SourceMixMatch[0]["MaCTKM"].ToString(),
                              MaCTKM.Trim(),
                            item["MixDiscountType"].ToString(),
                            item["LineGroupCode"].ToString(),
                            item["lineGroupType"].ToString(),
                            item["value1"].ToString(),
                            item["value2"].ToString(),
                            Session["uid"].ToString()
                            );
                        }
                    }
                    err.RespId = 0;
                    err.RespMsg = "Lưu thông tin thành công";
                }
                else
                {
                    err.RespId = -1;
                    err.RespMsg = "Có lỗi xảy ra. Vui lòng thử lại sau !";
                }

                return Json(err);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            return Json(err);
        }

        public ActionResult Update_PushSales_MixMatch(ObjPushSales_MixMaxLine obj)
        {
            var err = new RouteInfo();
            try
            {

                var SourceMixMatch = JArray.Parse(obj.SourceMixMatch);
                var SourceMixMaxLine = JArray.Parse(obj.SourceMixMaxLine);
                var SourceMixMaxLineGroup = JArray.Parse(obj.SourceMixMaxLineGroup);

                if (SourceMixMatch.Count() <= 0)
                {
                    err.RespId = -1;
                    err.RespMsg = "Bạn vui lòng kiểm tra lại đầu vào !";
                    return Json(err);
                }

                // viết update db
                var result = DataAccess.DataAccess.SP_UPDATE_PushSaleNCC_MixMatch(
                             SourceMixMatch[0]["ID"].ToString()
                           // , SourceMixMatch[0]["MaNCC"].ToString()
                           //, SourceMixMatch[0]["TenNCC"].ToString()
                           , SourceMixMatch[0]["MaCTKM"].ToString()
                           , SourceMixMatch[0]["CouponCode"].ToString()
                           , SourceMixMatch[0]["CouponName"].ToString()
                           , SourceMixMatch[0]["FromDay"].ToString()
                           , SourceMixMatch[0]["ToDay"].ToString()
                           , SourceMixMatch[0]["PriceGroupCode"].ToString()
                           , SourceMixMatch[0]["PriceGroupName"].ToString()

                           , SourceMixMatch[0]["NoOfLeastItem"].ToString()
                           , SourceMixMatch[0]["Leastexp"].ToString()
                           , SourceMixMatch[0]["Same_DifLine"].ToString()
                           , SourceMixMatch[0]["Mix_DiscountType"].ToString()
                           , SourceMixMatch[0]["DealPriceValue"].ToString()
                           , SourceMixMatch[0]["DiscValue"].ToString()
                           , SourceMixMatch[0]["DiscountAmoutValue"].ToString()
                           , SourceMixMatch[0]["NoTimeApp"].ToString()
                           , Session["uid"].ToString()
                       );

                if (result == true)
                {
                    // Xóa bảng Line & Group
                    var result2 = DataAccess.DataAccess.SP_MixMatch_DELETE_UPDATE(SourceMixMatch[0]["MaCTKM"].ToString());

                    if (SourceMixMaxLine.Count() > 0)
                    {
                        foreach (var item in SourceMixMaxLine)
                        {
                            DataAccess.DataAccess.SP_SAVE_PushSaleNCC_MixMatch_Line(
                            SourceMixMatch[0]["MaNCC"].ToString(),
                            SourceMixMatch[0]["TenNCC"].ToString(),
                            SourceMixMatch[0]["MaCTKM"].ToString(),
                            item["Type"].ToString(),
                            item["ProductName"].ToString(),
                            item["ProductCode"].ToString(),
                            item["NoItemNeeded"].ToString(),
                            item["DealPriceDiscPercent"].ToString(),
                            item["DiscType"].ToString(),
                            item["LineGroup"].ToString(),
                            Session["uid"].ToString()
                            );
                        }
                    }
                    if (SourceMixMaxLineGroup.Count() > 0)
                    {
                        foreach (var item in SourceMixMaxLineGroup)
                        {
                            DataAccess.DataAccess.SP_SAVE_PushSaleNCC_MixMatch_Line_Group(
                            SourceMixMatch[0]["MaNCC"].ToString(),
                            SourceMixMatch[0]["TenNCC"].ToString(),
                            SourceMixMatch[0]["MaCTKM"].ToString(),
                            item["MixDiscountType"].ToString(),
                            item["LineGroupCode"].ToString(),
                            item["lineGroupType"].ToString(),
                            item["value1"].ToString(),
                            item["value2"].ToString(),
                            Session["uid"].ToString()
                            );
                        }
                    }
                    err.RespId = 0;
                    err.RespMsg = "Cập nhật thông tin thành công";
                }
                else
                {
                    err.RespId = -1;
                    err.RespMsg = "Có lỗi xảy ra. Vui lòng thử lại sau !";
                }

                return Json(err);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            return Json(err);
        }
        public ActionResult API_GetCodeCTKMPushSale_MixMatch()
        {
            try
            {
                var lst = DataAccess.DataAccess.Get_Discount_Offer_TAO_MACTKM_MixMatch();
                return Json(lst);
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetCodeCTKMPushSale_MixMatch");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult Mix_Match_View(string MaCTKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccess.Mix_Match_View(MaCTKM);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult MixMatch_Line_View(string MaCTKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccess.MixMatch_Line_View(MaCTKM);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult MixMatch_Line_Groups_View(string MaCTKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccess.MixMatch_Line_Groups_View(MaCTKM);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region Total DisOffer
        public ActionResult GetListNoTotalDisOffer_TotalDiscount(string type)
        {
            try
            {
                List<objCombox> Items = new List<objCombox>();
                if (type == "Item")
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        Items = DataAccess.DataAccessKM.SP_getWay_Pro_ITEM_Vendor(Session["VendorCode"].ToString());
                    }
                    else
                    {
                        Items = DataAccess.DataAccessKM.SP_getWay_Pro_ITEM_Vendor("");
                    }
                }

                else if (type == "Coupon")
                {
                    Items = DataAccess.DataAccessKM.SP_BIBOSMART_ERP_Coupon_DETAIL();
                }
                return Json(Items);
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListNoTotalDisOffer");
                return Json(null);
            }
        }
        public ActionResult API_GetCodeCTKMPushSale_TotalDiscount()
        {
            try
            {
                var lst = DataAccess.DataAccess.GetCodeCTKMPushSale_TotalDiscount();
                return Json(lst);
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "API_GetCodeCTKMPushSale_TotalDiscount");
                return Json(null);
            }
        }
        public ActionResult SavePushSales_TotalDiscount(ObjPushSales_TotalDiscount obj)
        {
            var err = new RouteInfo();
            try
            {
                string MaxID = DataAccess.DataAccess.ShowMaxID();
                string MaCTKM = DataAccess.DataAccess.ShowMaxID_Total_Discount();

                var SourceTotalDiscount = JArray.Parse(obj.SourceTotalDiscount);
                var SourceTotalTotalDiscount = JArray.Parse(obj.SourceTotalTotalDiscount);
                var SourceTotalTotalDiscountLine = JArray.Parse(obj.SourceTotalTotalDiscountLine);

                if (SourceTotalDiscount.Count() <= 0)
                {
                    err.RespId = -1;
                    err.RespMsg = "Bạn vui lòng kiểm tra lại đầu vào !";
                    return Json(err);
                }
                var result = DataAccess.DataAccess.SP_SAVE_PushSaleNCC_TotalDiscount(
                    MaxID
                    , SourceTotalDiscount[0]["MaNCC"].ToString()
                           , SourceTotalDiscount[0]["TenNCC"].ToString()
                           , MaCTKM.Trim()
                           // , SourceTotalDiscount[0]["MaCTKM"].ToString() ko lấy từ giao diện nữa.
                           , SourceTotalDiscount[0]["CouponCode"].ToString()
                           , SourceTotalDiscount[0]["CouponName"].ToString()
                           , SourceTotalDiscount[0]["FromDay"].ToString()
                           , SourceTotalDiscount[0]["ToDay"].ToString()
                           , SourceTotalDiscount[0]["PriceGroupCode"].ToString()
                           , SourceTotalDiscount[0]["PriceGroupName"].ToString()
                           , Session["uid"].ToString()
                       );

                if (result == true)
                {
                    if (SourceTotalTotalDiscountLine.Count() > 0)
                    {
                        foreach (var item in SourceTotalTotalDiscountLine)
                        {
                            DataAccess.DataAccess.SP_SAVE_PushSaleNCC_TotalDiscount_Line(
                            SourceTotalDiscount[0]["MaNCC"].ToString(),
                            SourceTotalDiscount[0]["TenNCC"].ToString(),
                              // SourceTotalDiscount[0]["MaCTKM"].ToString(),
                              MaCTKM.Trim(),
                            item["Type"].ToString(),
                            item["ProductName"].ToString(),
                            item["ProductCode"].ToString(),
                            Session["uid"].ToString()
                            );
                        }
                    }
                    if (SourceTotalTotalDiscount.Count() > 0)
                    {
                        foreach (var item in SourceTotalTotalDiscount)
                        {
                            DataAccess.DataAccess.SP_SAVE_PushSaleNCC_TotalDiscount_Benefits(
                            SourceTotalDiscount[0]["MaNCC"].ToString(),
                            SourceTotalDiscount[0]["TenNCC"].ToString(),
                             // SourceTotalDiscount[0]["MaCTKM"].ToString(),
                             MaCTKM.Trim(),
                            item["StepAmount"].ToString(),
                            item["Type"].ToString(),
                            item["ProductName"].ToString(),
                            item["ProductCode"].ToString(),
                             item["ValueType"].ToString(),
                            item["Value"].ToString(),
                            Session["uid"].ToString()
                            );
                        }
                    }
                    err.RespId = 0;
                    err.RespMsg = "Lưu thông tin thành công";
                }
                else
                {
                    err.RespId = -1;
                    err.RespMsg = "Có lỗi xảy ra. Vui lòng thử lại sau !";
                }

                return Json(err);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            return Json(err);
        }

        public ActionResult Update_PushSales_TotalDiscount(ObjPushSales_TotalDiscount obj)
        {
            var err = new RouteInfo();
            try
            {

                var SourceTotalDiscount = JArray.Parse(obj.SourceTotalDiscount);
                var SourceTotalTotalDiscount = JArray.Parse(obj.SourceTotalTotalDiscount);
                var SourceTotalTotalDiscountLine = JArray.Parse(obj.SourceTotalTotalDiscountLine);

                if (SourceTotalDiscount.Count() <= 0)
                {
                    err.RespId = -1;
                    err.RespMsg = "Bạn vui lòng kiểm tra lại đầu vào !";
                    return Json(err);
                }
                var result = DataAccess.DataAccess.SP_UPDATE_PushSaleNCC_TotalDiscount(
                            SourceTotalDiscount[0]["ID"].ToString()
                            //, SourceTotalDiscount[0]["MaNCC"].ToString()
                            //, SourceTotalDiscount[0]["TenNCC"].ToString()
                            , SourceTotalDiscount[0]["MaCTKM"].ToString()
                           , SourceTotalDiscount[0]["CouponCode"].ToString()
                           , SourceTotalDiscount[0]["CouponName"].ToString()
                           , SourceTotalDiscount[0]["FromDay"].ToString()
                           , SourceTotalDiscount[0]["ToDay"].ToString()
                           , SourceTotalDiscount[0]["PriceGroupCode"].ToString()
                           , SourceTotalDiscount[0]["PriceGroupName"].ToString()
                           , Session["uid"].ToString()
                       );

                if (result == true)
                {
                    // Xóa bảng Line
                    var result2 = DataAccess.DataAccess.SP_TotalDiscount_DELETE_UPDATE(SourceTotalDiscount[0]["MaCTKM"].ToString());

                    if (SourceTotalTotalDiscountLine.Count() > 0)
                    {
                        foreach (var item in SourceTotalTotalDiscountLine)
                        {
                            DataAccess.DataAccess.SP_SAVE_PushSaleNCC_TotalDiscount_Line(
                            SourceTotalDiscount[0]["MaNCC"].ToString(),
                            SourceTotalDiscount[0]["TenNCC"].ToString(),
                            SourceTotalDiscount[0]["MaCTKM"].ToString(),
                            item["Type"].ToString(),
                            item["ProductName"].ToString(),
                            item["ProductCode"].ToString(),
                            Session["uid"].ToString()
                            );
                        }
                    }
                    if (SourceTotalTotalDiscount.Count() > 0)
                    {
                        foreach (var item in SourceTotalTotalDiscount)
                        {
                            DataAccess.DataAccess.SP_SAVE_PushSaleNCC_TotalDiscount_Benefits(
                            SourceTotalDiscount[0]["MaNCC"].ToString(),
                            SourceTotalDiscount[0]["TenNCC"].ToString(),
                             SourceTotalDiscount[0]["MaCTKM"].ToString(),
                            item["StepAmount"].ToString(),
                            item["Type"].ToString(),
                            item["ProductName"].ToString(),
                            item["ProductCode"].ToString(),
                             item["ValueType"].ToString(),
                            item["Value"].ToString(),
                            Session["uid"].ToString()
                            );
                        }
                    }
                    err.RespId = 0;
                    err.RespMsg = "Cập nhật thành công";
                }
                else
                {
                    err.RespId = -1;
                    err.RespMsg = "Có lỗi xảy ra. Vui lòng thử lại sau !";
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
        public ActionResult Total_Discount_View(string MaCTKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccess.Total_Discount_View(MaCTKM);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Total_Discount_Line_View(string MaCTKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccess.Total_Discount_Line_View(MaCTKM);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Total_Discount_Line_Benefits_View(string MaCTKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccess.Total_Discount_Line_Benefits_View(MaCTKM);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region ChuongTrinhKhuyenMai
        public ActionResult ChuongTrinhKhuyenMai()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        ViewBag.VendorNo = Session["VendorCode"];
                        ViewBag.VendorName = Session["VendorName"];

                        var lstItem = DataAccess.DataAccessKM.SP_getWay_Pro_ITEM_Vendor(Session["VendorCode"].ToString());
                        ViewBag.lstItem = lstItem;
                    }
                    else
                    {
                        var lstItem = DataAccess.DataAccessKM.SP_getWay_Pro_ITEM_Vendor("");
                        ViewBag.lstItem = lstItem;
                    }
                    var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;


                    var lstCusPriceGroup = DataAccess.DataAccess.GetCustomerPriceGroup();
                    ViewBag.lstCusPriceGroup = lstCusPriceGroup;

                    var lstCoupon = DataAccess.DataAccess.SP_PushSale_Coupon_DETAIL();
                    ViewBag.lstCoupon = lstCoupon;

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("PushSale", "ChuongTrinhKhuyenMai");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PushSaleNCC");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Get_List_ChuongTrinhKhuyenMai(string VendorNo, string LoaiCTKM, string Status, string GAP)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        DataTable table = DataAccess.DataAccess.Get_List_ChuongTrinhKhuyenMai(LoaiCTKM, Status, GAP, Session["VendorCode"].ToString());
                        return PartialView("~/Views/PushSale/Partial/__ChuongTrinhKhuyenMai.cshtml", table);
                    }
                    else
                    {
                        DataTable table = DataAccess.DataAccess.Get_List_ChuongTrinhKhuyenMai(LoaiCTKM, Status, GAP, VendorNo);
                        return PartialView("~/Views/PushSale/Partial/__ChuongTrinhKhuyenMai.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_ChuongTrinhKhuyenMai");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Delete_ChuongTrinhKhuyenMai(string[] IDPusSale)
        {
            try
            {
                for (int i = 0; i < IDPusSale.Length; i++)
                {
                    var item = DataAccess.DataAccess.SP_PushSale_DELETE_ChuongTrinhKhuyenMai(IDPusSale[i].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_ChuongTrinhKhuyenMai");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult Update_Status_ChuongTrinhKhuyenMai(string[] IDPusSale, string HanhDong)
        {
            try
            {
                for (int i = 0; i < IDPusSale.Length; i++)
                {
                    var item = DataAccess.DataAccess.Update_Status_ChuongTrinhKhuyenMai(IDPusSale[i].ToString(), HanhDong);
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_ChuongTrinhKhuyenMai");
                return Json(new { code = 1, message = "" });
            }
        }

        public ActionResult Get_GAP_CTKM_Type(string MaCTKM)
        {
            try
            {
                List<MP_VendorTool.Models.Order.objCombox> Items = new List<MP_VendorTool.Models.Order.objCombox>();
                switch (MaCTKM)
                {
                    case "Discount_Offer":
                        Items = DataAccess.DataAccess.sp_Pushsale_GAP_Discount_Offer_get(Session["VendorCode"].ToString());
                        break;
                    case "Mix_Match":
                        Items = DataAccess.DataAccess.sp_Pushsale_GAP_MixMatch_get(Session["VendorCode"].ToString());
                        break;
                    case "Total_Discount":
                        Items = DataAccess.DataAccess.sp_Pushsale_GAP_Total_Discount_get(Session["VendorCode"].ToString());
                        break;
                    default:
                        Items = DataAccess.DataAccess.sp_Pushsale_GAP_TruongTrinhKhuyenMai_get(Session["VendorCode"].ToString());
                        break;
                }
                return Json(Items);
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_GAP_CTKM_Type");
                return Json(null);
            }
        }

        #endregion

        #region TangCuongNhanDien
        public ActionResult TangCuongNhanDien()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {

                    }
                    else
                    {
                    }
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        ViewBag.VendorNo = Session["VendorCode"];
                        ViewBag.VendorName = Session["VendorName"];
                    }
                    var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("PushSale", "TangCuongNhanDien");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TangCuongNhanDien");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Get_List_TangCuongNhanDien(string VendorCode, string HangMuc, string Status, string GAP)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        DataTable table = DataAccess.DataAccess.Get_List_TangCuongNhanDien(HangMuc, Status, GAP, Session["VendorCode"].ToString());
                        return PartialView("~/Views/PushSale/Partial/__TangCuongNhanDien.cshtml", table);
                    }
                    else
                    {
                        DataTable table = DataAccess.DataAccess.Get_List_TangCuongNhanDien(HangMuc, Status, GAP, VendorCode);
                        return PartialView("~/Views/PushSale/Partial/__TangCuongNhanDien.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_TangCuongNhanDien");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        public ActionResult Get_List_TangCuongNhanDien_HangMuc(string NCC)
        {
            try
            {
                var bn = DataAccess.DataAccess.Get_List_TangCuongNhanDien_HangMuc(NCC);
                if (bn.Count > 0)
                {
                    return Json(JsonConvert.SerializeObject(bn));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListBarcode");
                return Json(null);
            }
        }

        public ActionResult Create_PushSale_NCC_TangCuongNhanDien(List<obj_TangCuongNhanDien> info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    string MaxID = DataAccess.DataAccess.ShowMaxID();
                    foreach (var item in info)
                    {
                        bool rs = DataAccess.DataAccess.SP_SAVE_PUSHSALES_TangCuongNhanDien(item, MaxID, Session["uid"].ToString());
                    }
                    return Json(new { code = 0, message = "" });
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pro_createupdate_Orientation_Bonus");
                return null;
            }
        }

        [HttpPost]
        public ActionResult Delete_TangCuongNhanDien(string[] IDPusSale)
        {
            try
            {
                for (int i = 0; i < IDPusSale.Length; i++)
                {
                    var item = DataAccess.DataAccess.SP_PushSale_DELETE_TangCuongNhanDien(IDPusSale[i].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_TangCuongNhanDien");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult Update_Status_TangCuongNhanDien(string[] IDPusSale, string HanhDong)
        {
            try
            {
                for (int i = 0; i < IDPusSale.Length; i++)
                {
                    var item = DataAccess.DataAccess.Update_Status_TangCuongNhanDien(IDPusSale[i].ToString(), HanhDong);
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_TangCuongNhanDien");
                return Json(new { code = 1, message = "" });
            }
        }
        [HttpPost]
        public ActionResult Listget_TangCuongNhanDien_PopUp(string ID)
        {
            try
            {
                var list = DataAccess.DataAccess.Listget_TangCuongNhanDien_PopUp(ID);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_TangCuongNhanDien_PopUp");
                return Json(null);
            }
        }
        public ActionResult sp_Pushsale_GAP_TangCuongNhanDien_get()
        {
            try
            {
                var Items = DataAccess.DataAccess.sp_Pushsale_GAP_TangCuongNhanDien_get(Session["VendorCode"].ToString());
                return Json(Items);
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Pushsale_GAP_TangCuongNhanDien_get");
                return Json(null);
            }
        }
        public ActionResult Update_TangCuongNhanDien(obj_TangCuongNhanDien info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    bool rs = DataAccess.DataAccess.Update_TangCuongNhanDien(info);
                    return Json(rs);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_TangCuongNhanDien");
                return null;
            }
        }

        #endregion



    }
}