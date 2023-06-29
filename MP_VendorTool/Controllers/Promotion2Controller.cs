using Newtonsoft.Json;
using MP_VendorTool.Models.Promotion;
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
using MP_VendorTool.Models.Promotion2;

namespace MP_VendorTool.Controllers
{
    public class Promotion2Controller : Controller
    {
        #region ComboKhuyenMai
        public async Task<ActionResult> ComboKhuyenMai()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    // if (!Constants.checkpermission("ComboKhuyenMai", "Index")) return RedirectToAction("Index", "Home");
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var json = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/Promotion/Get_Vendor?VendorCode=" + Session["VendorCode"].ToString());
                        ViewBag.list_vendor = json.Items;
                    }
                    else
                    {
                        var json = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/Promotion/Get_Vendor");
                        ViewBag.list_vendor = json.Items;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Promotion2", "ComboKhuyenMai");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ComboKhuyenMai");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        public async Task<ActionResult> GetListComboHangMua(string NhaCC)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var table = await BaseApiClient.CallAsync_API<GetWay_HHOA_KGUI>("/api/Promotion2/GetListComboHangMua?vendorNo=" + NhaCC);
                return PartialView("~/Views/Promotion2/Partial/__ComboHangMua.cshtml", table.Items);

                // DataTable table = SqlHelper.ExecuteTable(ConfigurationManager.AppSettings.Get("strConnSpac"), "SP_HanTangHang_GetWay_HHOA_KGUI", NhaCC);
                // return PartialView("~/Views/Promotion2/Partial/__ComboHangMua.cshtml", table);
            }
            SystemFunctions.SaveSession("Promotion2", "ComboKhuyenMai");
            return RedirectToAction("Login", "Account");
        }
        public async Task<ActionResult> GetListHangTang(string NhaCC, string SumTotal)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var table = await BaseApiClient.CallAsync_API<TangHang_GetWay_HHOA_KGUI>("/api/Promotion2/GetListHangTang?SumTotalPushSales=" + SumTotal + "&vendorNo=" + NhaCC);
                return PartialView("~/Views/Promotion2/Partial/__ComboHangTang.cshtml", table.Items);

                // DataTable table = SqlHelper.ExecuteTable(ConfigurationManager.AppSettings.Get("strConnSpac"), "SP_HanTangHang_TangHang_GetWay_HHOA_KGUI", NhaCC, SumTotal);
                // return PartialView("~/Views/Promotion2/Partial/__ComboHangTang.cshtml", table);
            }
            SystemFunctions.SaveSession("Promotion", "ComboKhuyenMai");
            return RedirectToAction("Login", "Account");
        }
        public async Task<ActionResult> ComboKhuyenMai_Auto_MaCT(string VendorCode)
        {
            try
            {
                var lst = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/Promotion2/Auto_MaCT?VendorCode=" + VendorCode);
                //var lst = DataAccessPromotion2.ComboKhuyenMai_Auto_MaCT(VendorCode);
                return Json(lst.Items);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateComboKM(ObjPromotionSource obj)
        {
            var err = new RouteInfo();
            try
            {
                var model = JsonConvert.DeserializeObject<List<ComboKhuyenMai_Header>>(obj.SourceHeader);
                var MuaHang = JsonConvert.DeserializeObject<List<ComboKhuyenMai_MuaHang>>(obj.SourceHangMua);
                var TangHang = JsonConvert.DeserializeObject<List<ComboKhuyenMai_TangHang>>(obj.SourceHangTang);

                var listHeader = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/Promotion2/Detail_Check?MaCT=" + model[0].MaCT + "&VendorCode=" + model[0].MaNCC);
                //var listHeader = DataAccessPromotion2.ComboKhuyenMai_Header_Detail_Check(model[0].MaCT, model[0].MaNCC);
                if (listHeader.Items != null)
                {
                    err.RespId = 0;
                    err.RespMsg = "Mã CT đã tồn tại. Vui lòng tải lại trang.!";
                }
                else
                {
                    if (model.Count() > 0 && MuaHang.Count > 0 && TangHang.Count > 0)
                    {
                        foreach (var item in model)
                        {
                            item.CreateBy = Session["uid"].ToString();
                            var json = await BaseApiClient.PostAsync_API<ComboKhuyenMai_Header>("/api/Promotion2/ComboKhuyenMai_Header_Insert", item);
                            //var result = DataAccessPromotion2.ComboKhuyenMai_Header_Insert(item, Session["uid"].ToString());
                        }
                        if (MuaHang.Count() > 0)
                        {
                            foreach (var item in MuaHang)
                            {
                                var json = await BaseApiClient.PostAsync_API<ComboKhuyenMai_MuaHang>("/api/Promotion2/ComboKhuyenMai_Line_MuaHang_Insert", item);
                                // var result = DataAccessPromotion2.ComboKhuyenMai_Line_MuaHang_Insert(item);
                            }
                        }
                        if (TangHang.Count() > 0)
                        {
                            foreach (var item in TangHang)
                            {
                                var json = await BaseApiClient.PostAsync_API<ComboKhuyenMai_TangHang>("/api/Promotion2/ComboKhuyenMai_Line_TangHang_Insert", item);
                                // var result = DataAccessPromotion2.ComboKhuyenMai_Line_TangHang_Insert(item);
                            }
                        }
                        err.RespId = 0;
                        err.RespMsg = "Thêm mới chiến dịch thành công";
                    }
                    else
                    {
                        err.RespId = -1;
                        err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại";
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
        #endregion

        #region ComboKhuyenMaiApr
        // Ar
        public async Task<ActionResult> ComboKhuyenMaiApr()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    //if (!Constants.checkpermission("ComboKhuyenMaiApr", "Index")) return RedirectToAction("Index", "Home");
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var json = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/Promotion/Get_Vendor?VendorCode=" + Session["VendorCode"].ToString());
                        ViewBag.list_vendor = json.Items;
                    }
                    else
                    {
                        var json = await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/Promotion/Get_Vendor");
                        ViewBag.list_vendor = json.Items;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Promotion2", "ComboKhuyenMaiApr");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ComboKhuyenMaiApr");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> GetList_ComboKhuyenMaiApr(string TenCT, string VendorCode, string TrangThai, string NgayTao)
        {
            try
            {
                var request = new Search_Detail()
                {
                    TenCT = TenCT,
                    VendorCode = VendorCode,
                    TrangThai = TrangThai,
                    NgayTao = NgayTao
                };

                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        request.VendorCode = Session["VendorCode"].ToString();
                        var table = await BaseApiClient.PostAsync_Param_API<Header_Detail, Search_Detail>("/api/Promotion2/ComboKhuyenMai_Header_Detail", request);
                        return PartialView("~/Views/Promotion2/Partial/__ComboKhuyenMaiApr.cshtml", table.Items);

                        //System.Data.DataTable table = DataAccess.DataAccessPromotion2.ComboKhuyenMai_Header_Detail(TenCT, Session["VendorCode"].ToString(), TrangThai, NgayTao);
                        //return PartialView("~/Views/Promotion2/Partial/__ComboKhuyenMaiApr.cshtml", table);
                    }
                    else
                    {
                        var table = await BaseApiClient.PostAsync_Param_API<Header_Detail, Search_Detail>("/api/Promotion2/ComboKhuyenMai_Header_Detail", request);
                        return PartialView("~/Views/Promotion2/Partial/__ComboKhuyenMaiApr.cshtml", table.Items);
                        //System.Data.DataTable table = DataAccess.DataAccessPromotion2.ComboKhuyenMai_Header_Detail(TenCT, VendorCode, TrangThai, NgayTao);
                        //return PartialView("~/Views/Promotion2/Partial/__ComboKhuyenMaiApr.cshtml", table);
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
        public async Task<ActionResult> ComboKhuyenMai_MuaHang_Detail(string MaCTKM, string VendorCode)
        {
            try
            {
                var json = await BaseApiClient.CallAsync_API<ComboKhuyenMai_MuaHang>("/api/Promotion2/ComboKhuyenMai_MuaHang_Detail?MaCTKM=" + MaCTKM.ToString() + "&VendorCode=" + VendorCode.ToString());

               // var Items = SqlHelper.ExecuteList<ComboKhuyenMai_MuaHang>(ConfigurationManager.AppSettings.Get("strConn"), "ComboKhuyenMai_MuaHang_Detail", MaCTKM, VendorCode);
                return Json(json.Items);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetDetailItemCombo");
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ComboKhuyenMai_TangHang_Detail(string MaCTKM, string VendorCode)
        {
            try
            {
                var json = await BaseApiClient.CallAsync_API<ComboKhuyenMai_TangHang>("/api/Promotion2/ComboKhuyenMai_TangHang_Detail?MaCTKM=" + MaCTKM.ToString()+ "&VendorCode=" + VendorCode.ToString());
               // var Items = SqlHelper.ExecuteList<ComboKhuyenMai_TangHang>(ConfigurationManager.AppSettings.Get("strConn"), "ComboKhuyenMai_TangHang_Detail", MaCTKM, VendorCode);
                return Json(json.Items);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetDetailItemCombo");
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ComboKhuyenMai_Delete(string[] ID)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    await BaseApiClient.CallAsync_API<MP_VendorTool.Models.Order.objCombox>("/api/Promotion2/ComboKhuyenMai_Delete?MaCTKM=" + ID[i].ToString());
                    //var item = DataAccess.DataAccessPromotion2.ComboKhuyenMai_Delete(ID[i].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ComboKhuyenMai_Delete");
                return Json(new { code = 1, message = "" });
            }
        }

        #endregion

    }

}