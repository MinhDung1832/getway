using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Account;
using MP_VendorTool.Models.Vendor;
using Newtonsoft.Json;
using MP_VendorTool.Models.Tradingterm;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using MP_VendorTool.Common;
using MP_VendorTool.Models.Promotion;
using MP_VendorTool.Models.Vendors;
using System.Threading.Tasks;
using MP_VendorTool.Models.Newoffer;
using MP_VendorTool.Models.Delivery;

namespace MP_VendorTool.Controllers
{
    public class DeliveryController : MyController
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        public ActionResult DeliveryStore()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {

                var list_Mien = DataAccess.DataAccessDelivery.BBM_TradingTern_Delivery_listAdd_Mien();
                ViewBag.list_Mien = list_Mien;

                var list_vendor = DataAccess.DataAccessDelivery.SP_Delivery_Vender();
                ViewBag.list_vendor = list_vendor;

                var list_TinhThanh = DataAccess.DataAccessDelivery.BBM_TradingTern_Delivery_listAdd_TinhThanh();
                ViewBag.list_TinhThanh = list_TinhThanh;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult InfoDelivery()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list_vendor = DataAccess.DataAccessDelivery.SP_Delivery_Vender();
                ViewBag.list_vendor = list_vendor;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult StoreDetail(string id)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                ViewBag.IDHeader = id;
                var list_Mien = DataAccess.DataAccessDelivery.BBM_TradingTern_Delivery_listAdd_Mien();
                ViewBag.list_Mien = list_Mien;

                var list_vendor = DataAccess.DataAccessDelivery.SP_Delivery_Vender();
                ViewBag.list_vendor = list_vendor;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult GetList_Delivery(string VendorCode, string TrangThai)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    System.Data.DataTable table = DataAccess.DataAccessDelivery.SP_TRADTERM_Info_GiaoHang_Header_Delivery(VendorCode.ToString(), TrangThai);
                    return PartialView("~/Views/Delivery/Partial/__InfoDelivery.cshtml", table);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Delivery");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult GetList_Delivery_Store()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["Delivery_VendorCode"] != null && Session["Delivery_VendorCode"].ToString().Length > 0)
                    {
                        System.Data.DataTable table = DataAccess.DataAccessDelivery.SP_Delivery_listProductsCheck(Session["Delivery_XacNhan"].ToString(), Session["Delivery_VendorCode"].ToString());
                        return PartialView("~/Views/Delivery/Partial/__InfoDeliveryStore.cshtml", table);
                    }
                    else
                    {
                        return RedirectToAction("InfoDelivery", "Delivery");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Delivery");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult GetList_Delivery_Store_Detail(string IDHeader)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    System.Data.DataTable table = DataAccess.DataAccessDelivery.SP_Delivery_listProductsCheck_Detail(IDHeader.ToString());
                    return PartialView("~/Views/Delivery/Partial/__InfoDeliveryStore_Detail.cshtml", table);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Delivery");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult GetList_Delivery_listAdd_Store(string Store, string Mien, string TinhThanh)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    System.Data.DataTable table = DataAccess.DataAccessDelivery.BBM_TradingTern_Delivery_listAdd_Store(Store, Mien, TinhThanh);
                    return PartialView("~/Views/Delivery/Partial/__InfoDeliveryStoreAdd.cshtml", table);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Delivery");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult GetList_Delivery_listAdd_Store_Detail(string IDHeader)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {

                    System.Data.DataTable table = DataAccess.DataAccessDelivery.BBM_TradingTern_Delivery_listAdd_Store_Detail(IDHeader.ToString());
                    return PartialView("~/Views/Delivery/Partial/__InfoDeliveryStoreAdd_Detail.cshtml", table);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Delivery");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        public ActionResult Update_Header_Delivery(string MaHang, string TenHang, string NCC, string Moq, string MoqThung)
        {
            try
            {
                var item = DataAccess.DataAccessDelivery.Update_Header_Delivery(Session["uid"].ToString(), MaHang, TenHang, NCC, Moq, MoqThung);
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_GiaSauThayDoi_OfferPrice");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult Update_Header_Delivery_XacNhan(string ID, string VendorCode)
        {
            try
            {
                Session["Delivery_XacNhan"] = ID;
                Session["Delivery_VendorCode"] = VendorCode;
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                Session["Delivery_XacNhan"] = "";
                Session["Delivery_VendorCode"] = "";
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_GiaSauThayDoi_OfferPrice");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult Save_Delivery_Store_Producst(DeliveryAdd obj)
        {
            var err = new RouteInfo();
            try
            {
                if (Session["Delivery_VendorCode"] != null && Session["Delivery_VendorCode"].ToString().Length > 0)
                {
                    // DataAccess.DataAccessDelivery.Delete_Header_Delivery(Session["Delivery_VendorCode"].ToString());
                    var BackColor = DataAccess.DataAccessDelivery.SP_Delivery_Color();

                    var IDHeader = Guid.NewGuid().ToString();
                    var model = JsonConvert.DeserializeObject<List<Delivery_Add_Store>>(obj.SourceStore);
                    var modelPro = JsonConvert.DeserializeObject<List<Delivery_Add_Productrs>>(obj.SourceSanPham);
                    if (model.Count() > 0 && modelPro.Count() > 0)
                    {
                        foreach (var item in model)
                        {
                            var result = DataAccess.DataAccessDelivery.Save_Delivery_Add_Store(item, IDHeader, Session["Delivery_VendorCode"].ToString(), Session["uid"].ToString());
                        }
                        if (modelPro.Count() > 0)
                        {
                            foreach (var item in modelPro)
                            {
                                var result = DataAccess.DataAccessDelivery.Save_Delivery_Products_Add_Store(item, IDHeader, Session["Delivery_VendorCode"].ToString(), Session["uid"].ToString(), BackColor[0].Name.ToString());
                            }
                        }
                        err.RespId = 0;
                        err.RespMsg = "Xác nhận thông tin thành công.";
                    }
                    else
                    {
                        err.RespId = -1;
                        err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại";
                    }
                    return Json(err);
                }
                else
                {
                    return RedirectToAction("InfoDelivery", "Delivery");
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            return Json(err);
        }

        [HttpPost]
        public ActionResult Get_List_TinhThanh(string VungMien)
        {
            try
            {
                var bn = DataAccess.DataAccessDelivery.Get_List_Delivery_TinhThanh(VungMien);
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

    }
}
