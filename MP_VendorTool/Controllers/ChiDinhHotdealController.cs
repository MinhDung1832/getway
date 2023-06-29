using MP_VendorTool.Common;
using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Account;
using MP_VendorTool.Models.Promotion;
using MP_VendorTool.Models.ChiDinhHotdeal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace MP_VendorTool.Controllers
{
    public class ChiDinhHotdealController : Controller
    {
        #region Chỉ định khuyến mãi ChiDinhHotdeal
        public async Task<ActionResult> Index()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("Chidinhhotdeal", "Index")) return RedirectToAction("Index", "Home");
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        //   var list_vendor = DataAccess.DataAccessChiDinhHotdeal.SP_ChiDinhHotdeal_Vender(Session["VendorCode"].ToString());
                        // ViewBag.list_vendor = list_vendor;

                        var list_vendor = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/ChiDinhHotdeal/Get_Vendor?VendorCode=" + Session["VendorCode"].ToString());
                        ViewBag.list_vendor = list_vendor.Items;

                    }
                    else
                    {
                        //   var list_vendor = DataAccess.DataAccessChiDinhHotdeal.SP_ChiDinhHotdeal_Vender("");
                        //  ViewBag.list_vendor = list_vendor;

                        var list_vendor = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/ChiDinhHotdeal/Get_Vendor");
                        ViewBag.list_vendor = list_vendor.Items;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("ChiDinhHotdeal", "Index");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ChiDinhHotdealNCC");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> GetList_ChiDinhHotdeal(string vendorNo, string MaHang, string Barcode)
        {
            try
            {
                var request = new Obj_fillter_Ar()
                {
                    vendorNo = vendorNo,
                    MaHang = MaHang,
                    Barcode = Barcode,
                };

                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        request.vendorNo = Session["VendorCode"].ToString();
                        var table = await BaseApiClient.PostAsync_Param_API<ChiDinhHotdeal_HHOA_KGUI, Obj_fillter_Ar>("/api/ChiDinhHotdeal/GetList_ChiDinhHotdeal", request);
                        return PartialView("~/Views/ChiDinhHotdeal/Partial/__Index.cshtml", table.Items);

                        //System.Data.DataTable table = DataAccess.DataAccessChiDinhHotdeal.SP_CTKM_ChiDinhHotdeal_HHOA_KGUI(Session["VendorCode"].ToString(), MaHang, Barcode);
                        //return PartialView("~/Views/ChiDinhHotdeal/Partial/__Index.cshtml", table);
                    }
                    else
                    {
                        var table = await BaseApiClient.PostAsync_Param_API<ChiDinhHotdeal_HHOA_KGUI, Obj_fillter_Ar>("/api/ChiDinhHotdeal/GetList_ChiDinhHotdeal", request);
                        return PartialView("~/Views/ChiDinhHotdeal/Partial/__Index.cshtml", table.Items);

                        //System.Data.DataTable table = DataAccess.DataAccessChiDinhHotdeal.SP_CTKM_ChiDinhHotdeal_HHOA_KGUI(vendorNo, MaHang, Barcode);
                        //  return PartialView("~/Views/ChiDinhHotdeal/Partial/__Index.cshtml", table);
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
        public async Task<ActionResult> GetListBarcode(string itemNo)
        {
            try
            {
                var lst = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/ChiDinhHotdeal/GetListBarcode");
                return Json(JsonConvert.SerializeObject(lst.Items));
                //var bn = DataAccess.DataAccessChiDinhHotdeal.SP_ChiDinhHotdeal_Vender_BARCODE(itemNo);
                //if (bn.Count > 0)
                //{
                //    return Json(JsonConvert.SerializeObject(bn));
                //}
                //else
                //{
                //    return Json(null);
                //}
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListBarcode");
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetList_NCC_Produts(string NCC)
        {
            try
            {
                var lst = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/ChiDinhHotdeal/GetList_NCC_Produts?NCC=" + NCC + "");
                return Json(JsonConvert.SerializeObject(lst.Items));

                //var bn = DataAccess.DataAccessChiDinhHotdeal.SP_ChiDinhHotdeal_Vender_ITEM_Vendor(NCC);
                //if (bn.Count > 0)
                //{
                //    return Json(JsonConvert.SerializeObject(bn));
                //}
                //else
                //{
                //    return Json(null);
                //}
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_NCC_Produts");
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add_PushSale_Vender_Item_Vender_Item(List<Obj_ChiDinhHotdeal> lst)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                foreach (Obj_ChiDinhHotdeal po in lst)
                {
                    if (DateTime.Parse(po.NgayKetThuc.ToString()) <= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        return Json(new { code = 0, message = "" });
                    }
                    po.userid = Session["uid"].ToString();
                    var json = await BaseApiClient.PostAsync_API<Obj_ChiDinhHotdeal>("/api/ChiDinhHotdeal/Add_ChiDinhHotdeal", po);
                    //  await DataAccess.DataAccessChiDinhHotdeal.Add_ChiDinhHotdeal_Vender_Item(Session["uid"].ToString(), po);
                }
                return Json(new { code = 1, message = "" });
            }
            return RedirectToAction("Login", "Account");
        }



        #endregion

        #region QL Chỉ định khuyến mãi ChiDinhHotdealApr
        public async Task<ActionResult> ChiDinhHotdealApr()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("Chidinhhotdeal", "ChiDinhHotdealApr")) return RedirectToAction("Index", "Home");
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        //  var list_vendor = DataAccess.DataAccessChiDinhHotdeal.SP_ChiDinhHotdeal_Vender(Session["VendorCode"].ToString());
                        // ViewBag.list_vendor = list_vendor;

                        var list_vendor = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/ChiDinhHotdeal/Get_Vendor?VendorCode=" + Session["VendorCode"].ToString());
                        ViewBag.list_vendor = list_vendor.Items;
                    }
                    else
                    {
                        //var list_vendor = DataAccess.DataAccessChiDinhHotdeal.SP_ChiDinhHotdeal_Vender("");
                        //ViewBag.list_vendor = list_vendor;

                        var list_vendor = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/ChiDinhHotdeal/Get_Vendor");
                        ViewBag.list_vendor = list_vendor.Items;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("ChiDinhHotdeal", "ChiDinhHotdealApr");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ChiDinhHotdealNCC");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> GetList_ChiDinhHotdealApr(string vendorNo, string MaHang, string TrangThai)
        {
            try
            {
                var request = new Obj_HotdealApr()
                {
                    vendorNo = vendorNo,
                    MaHang = MaHang,
                    TrangThai = TrangThai,
                };


                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        request.vendorNo = Session["VendorCode"].ToString();
                        var table = await BaseApiClient.PostAsync_Param_API<Obj_ChiDinhHotdealApr, Obj_HotdealApr>("/api/ChiDinhHotdeal/GetList_ChiDinhHotdealAr", request);
                        return PartialView("~/Views/ChiDinhHotdeal/Partial/__ChiDinhHotdealApr.cshtml", table.Items);

                        // System.Data.DataTable table = DataAccess.DataAccessChiDinhHotdeal.ChiDinhHotdealApr(Session["VendorCode"].ToString(), MaHang, TrangThai);
                        // return PartialView("~/Views/ChiDinhHotdeal/Partial/__ChiDinhHotdealApr.cshtml", table);
                    }
                    else
                    {
                        var table = await BaseApiClient.PostAsync_Param_API<Obj_ChiDinhHotdealApr, Obj_HotdealApr>("/api/ChiDinhHotdeal/GetList_ChiDinhHotdealAr", request);
                        return PartialView("~/Views/ChiDinhHotdeal/Partial/__ChiDinhHotdealApr.cshtml", table.Items);

                        //System.Data.DataTable table = DataAccess.DataAccessChiDinhHotdeal.ChiDinhHotdealApr(vendorNo, MaHang, TrangThai);
                        //return PartialView("~/Views/ChiDinhHotdeal/Partial/__ChiDinhHotdealApr.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ChiDinhHotdealApr");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> Update_PushSale_Vender_Item_Vender_Item(List<ChiDinhHotdeal_Vender_Item> lst)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                foreach (ChiDinhHotdeal_Vender_Item po in lst)
                {
                    if (DateTime.Parse(po.NgayKetThuc.ToString()) <= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        return Json(new { code = 0, message = "" });
                    }
                    po.CreateBy = Session["uid"].ToString();
                    var json = await BaseApiClient.PostAsync_API<ChiDinhHotdeal_Vender_Item>("/api/ChiDinhHotdeal/Update_PushSale_Item_Ar", po);
                    // DataAccess.DataAccessChiDinhHotdeal.Update_ChiDinhHotdeal_Vender_Item(Session["uid"].ToString(), po);
                }
                return Json(new { code = 1, message = "" });
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion

    }
}