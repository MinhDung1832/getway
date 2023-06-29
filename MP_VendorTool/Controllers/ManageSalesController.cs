using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using MP_VendorTool.Common;
using MP_VendorTool.DataAccess;
using Lib.Utils.Package;
using System.Configuration;
using MP_VendorTool.Models.Order;
using MP_VendorTool.Models;
using MP_VendorTool.Models.ObjTrungBayNH;

namespace MP_VendorTool.Controllers
{
    public class ManageSalesController : Controller
    {
        #region TangTruongNH
        public async Task<ActionResult> TangTruongNH()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("ManageSales", "TangTruongNH")) return RedirectToAction("Index", "Home");
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        // var json = await BaseApiClient.CallAsync_API<objCombox>("/api/Promotion/Get_Vendor?VendorCode=" + Session["VendorCode"].ToString());
                        // ViewBag.list_vendor = json.Items;

                        var list_vendor = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConn"), "SP_Gateway_Vender", Session["VendorCode"].ToString());
                        ViewBag.list_vendor = list_vendor;

                    }
                    else
                    {
                        // var json = await BaseApiClient.CallAsync_API<objCombox>("/api/Promotion/Get_Vendor");
                        //  ViewBag.list_vendor = json.Items;

                        var list_vendor = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConn"), "SP_Gateway_Vender", "");
                        ViewBag.list_vendor = list_vendor;

                    }


                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("ManageSales", "TangTruongNH");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TangTruongNH");
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Login", "Account");
        }
        public async Task<ActionResult> GetList_TangTruongNH(string vendorNo, string MaHang, string Brand)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                //var table = await BaseApiClient.CallAsync_API<GetWay_HHOA_KGUI>("/api/Promotion2/GetListComboHangMua?vendorNo=" + NhaCC);
                //return PartialView("~/Views/ManageSales/Partial/__TangTruongNH.cshtml", table.Items);

                DataTable table = SqlHelper.ExecuteTable(ConfigurationManager.AppSettings.Get("strConnSpac"), "sp_GetList_QuanLyTangTruong_631_NganhHang_gateway", vendorNo, MaHang, Brand != null ? Brand : "");
                return PartialView("~/Views/ManageSales/Partial/__TangTruongNH.cshtml", table);
            }
            SystemFunctions.SaveSession("ManageSales", "TangTruongNH");
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult GetList_NCC_Produts_NganhHang(string NCC)
        {
            try
            {
                var bn = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConnSpac"), "sp_GetList_QuanLyTangTruong_631_NganhHang_gateway_Item", NCC);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_NCC_Produts");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetList_TangTruongNH_Brand(string NCC)
        {
            try
            {
                var bn = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConnSpac"), "TangTruongNH_Brand", NCC);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_NCC_Produts");
                return Json(null);
            }
        }
        #endregion

        #region TrungBayHH
        public async Task<ActionResult> TrungBayHH()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("ManageSales", "TrungBayHH")) return RedirectToAction("Index", "Home");
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var json = await BaseApiClient.CallAsync_API<objCombox>("/api/TrungBayHH/List_Vender?VendorCode=" + Session["VendorCode"].ToString());
                        ViewBag.list_vendor = json.Items;
                        // var list_vendor = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConn"), "SP_Gateway_Vender", Session["VendorCode"].ToString());
                        // ViewBag.list_vendor = list_vendor;
                    }
                    else
                    {
                        var json = await BaseApiClient.CallAsync_API<objCombox>("/api/TrungBayHH/List_Vender");
                        ViewBag.list_vendor = json.Items;
                        //var list_vendor = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConn"), "SP_Gateway_Vender", "");
                        //ViewBag.list_vendor = list_vendor;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("ManageSales", "TrungBayHH");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TrungBayHH");
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Login", "Account");
        }
        public async Task<ActionResult> GetList_TrungBayHH(string vendorNo, string MaHang, string TrangThai, string XucTien)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var request = new TrungBayHH_gateway()
                {
                    MaNCC = vendorNo,
                    MaHang = MaHang,
                    Trangthai = TrangThai,
                    Xuctien = XucTien
                };
                var table = await BaseApiClient.PostAsync_Param_API<QuanLyTrungBayHH_gateway, TrungBayHH_gateway>("/api/TrungBayHH/QuanLyTrungBayHH_gateway", request);
                return PartialView("~/Views/ManageSales/Partial/__TrungBayHH.cshtml", table.Items);

                // DataTable table = SqlHelper.ExecuteTable(ConfigurationManager.AppSettings.Get("strConnSpac"), "QuanLyTrungBayHH_gateway", vendorNo, MaHang, TrangThai, XucTien);
                // return PartialView("~/Views/ManageSales/Partial/__TrungBayHH.cshtml", table);
            }
            SystemFunctions.SaveSession("ManageSales", "TrungBayHH");
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> GetList_NCC_Produts(string NCC)
        {
            try
            {
                var bn = await BaseApiClient.CallAsync_API<objCombox>("/api/TrungBayHH/List_ITEM_Vendor?VendorCode=" + NCC);
                return Json(JsonConvert.SerializeObject(bn.Items));
                // var bn = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConn"), "SP_Gateway_Vender_ITEM_Vendor", NCC);
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
        #endregion

        #region MoRongKD PopUp
        public async Task<ActionResult> GetList_MoRongTrungBayHH(string MaNCC, string MaHang, string CuaHang, string TinhThanh, string Mien)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var request = new SearchMoRongKD()
                {
                    MaNCC = MaNCC,
                    MaHang = MaHang,
                    CuaHang = CuaHang,
                    TinhThanh = TinhThanh,
                    Mien = Mien
                };

                var table = await BaseApiClient.PostAsync_Param_API<MoRongTrungBayHH, SearchMoRongKD>("/api/TrungBayHH/GetAll_MoRongKD", request);
                return PartialView("~/Views/ManageSales/Partial/__MoRongKD.cshtml", table.Items);

                // DataTable table = SqlHelper.ExecuteTable(ConfigurationManager.AppSettings.Get("strConnSpac"), "QuanLyTrungBayHH_gateway_MoRongKD", MaNCC, MaHang, CuaHang != null ? CuaHang : "", TinhThanh != null ? TinhThanh : "", Mien != null ? Mien : "");
                // return PartialView("~/Views/ManageSales/Partial/__MoRongKD.cshtml", table);
            }
            SystemFunctions.SaveSession("ManageSales", "MoRongKD");
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> GateWay_TrungBayNganhHang_CuaHang(string MaNCC, string MaHang)
        {
            try
            {
                var bn = await BaseApiClient.CallAsync_API<objCombox>("/api/TrungBayHH/List_CuaHang?MaNCC=" + MaNCC + "&MaHang=" + MaHang + "");
                return Json(JsonConvert.SerializeObject(bn.Items));

                //var bn = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConnSpac"), "GateWay_TrungBayNganhHang_CuaHang", MaNCC, MaHang);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GateWay_TrungBayNganhHang_CuaHang");
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<ActionResult> GateWay_TrungBayNganhHang_Mien(string MaNCC, string MaHang)
        {
            try
            {
                var bn = await BaseApiClient.CallAsync_API<objCombox>("/api/TrungBayHH/List_Mien?MaNCC=" + MaNCC + "&MaHang=" + MaHang + "");
                return Json(JsonConvert.SerializeObject(bn.Items));

                //var bn = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConnSpac"), "GateWay_TrungBayNganhHang_Mien", MaNCC, MaHang);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GateWay_TrungBayNganhHang_Mien");
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<ActionResult> GateWay_TrungBayNganhHang_TinhThanh(string MaNCC, string MaHang)
        {
            try
            {
                var bn = await BaseApiClient.CallAsync_API<objCombox>("/api/TrungBayHH/List_TinhThanh?MaNCC=" + MaNCC + "&MaHang=" + MaHang + "");
                return Json(JsonConvert.SerializeObject(bn.Items));

                //var bn = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConnSpac"), "GateWay_TrungBayNganhHang_TinhThanh", MaNCC, MaHang);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GateWay_TrungBayNganhHang_TinhThanh");
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create_TrungBayNgangHang_MoRong(List<obj_TrungBayNgangHang> lst)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var bn = await BaseApiClient.CallAsync_API<objCombox>("/api/TrungBayHH/Auto_MaCT?MaNCC=" + lst[0].MaNCC);
                //  var bn = SqlHelper.ExecuteList<objCombox>(ConfigurationManager.AppSettings.Get("strConnSpac"), "TrungBayNgangHang_auto_MaCT", lst[0].MaNCC);
                if (bn != null)
                {
                    //await DataAccess.DataAccessManageSales.Create_TrungBayNgangHang_Header(Session["uid"].ToString(), bn.Items[0].Code, lst[0]);
                    lst[0].CreateBy = Session["uid"].ToString();
                    lst[0].MaAutoCT = bn.Items[0].Code;
                    await BaseApiClient.PostAsync_API<obj_TrungBayNgangHang>("/api/TrungBayHH/Create_Header", lst[0]);

                    foreach (obj_TrungBayNgangHang po in lst)
                    {
                        if (DateTime.Parse(po.DenNgay.ToString()) <= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                        {
                            return Json(new { code = 0, message = "" });
                        }
                        po.MaAutoCT = bn.Items[0].Code;
                        // await DataAccess.DataAccessManageSales.Create_TrungBayNgangHang_Line(po);
                        await BaseApiClient.PostAsync_API<obj_TrungBayNgangHang>("/api/TrungBayHH/Create_Line", po);
                        // var ii = DatabaseConnec.Execute_Update_Insert<obj_TrungBayNgangHang>("strConn", "Create_TrungBayNgangHang_Line", po);
                    }
                    return Json(new { code = 1, message = "" });
                }
                return Json(new { code = 0, message = "" });
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> TrungBayNganhHang_Detail(string MaNCC, string MaCT, string CuaHang, string Mien, string TinhThanh)
        {
            try
            {
                var request = new obj_TrungBayNHDetail()
                {
                    MaNCC = MaNCC,
                    MaCT = MaCT,
                    CuaHang = CuaHang,
                    TinhThanh = TinhThanh,
                    Mien = Mien
                };
                var json = await BaseApiClient.PostAsync_Param_API<TrungBayNganhHang_Detail, obj_TrungBayNHDetail>("/api/TrungBayHH/QuanLyTrungBayHH_Detail", request);
                return Json(json.Items);

                //  var Items = SqlHelper.ExecuteList<obj_TrungBayNgangHang>(ConfigurationManager.AppSettings.Get("strConn"), "QuanLyTrungBayHH_Detail", MaNCC, MaCT, CuaHang != null ? CuaHang.Trim() : "", Mien != null ? Mien.Trim() : "", TinhThanh != null ? TinhThanh.Trim() : "");
                // return Json(Items);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetDetailItemCombo");
                return Json(null);
            }
        }
        #endregion
    }

}