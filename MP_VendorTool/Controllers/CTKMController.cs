using MP_VendorTool.Common;
using MP_VendorTool.DataAccess;
using Newtonsoft.Json;
using ProductAllTool.DataAccess;
using ProductAllTool.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace ProductAllTool.Controllers
{
    public class CTKMController : Controller
    {
        // GET: CTKM
        public ActionResult CreateCTKM()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    //var list_code = DataAccess.DataAccessCTKM.CBKM_autocode();
                    //ViewBag.list_code = list_code[0].MaCTKM;
                    var list_ncc = DataAccess.DataAccessCTKM.CTKM_cboNCC(Session["uid"].ToString());
                    ViewBag.list_ncc = list_ncc;

                    //var listCofde = DataAccess.DataAccessCTKM.CBKM_autocode();
                    //ViewBag.listCofde = listCofde[0].MaCTKM;
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("CTKM", "CreateCTKM");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                SystemFunctions.SaveSession("CTKM", "CreateCTKM");
               LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CreateCTKM");
                return RedirectToAction("Logout", "Account");
            }
        }

        public ActionResult getHangMua(string NCC)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessCTKM.CTKM_getSPMua(Session["uid"].ToString(), NCC);

                return PartialView("~/Views/CTKM/tables/__tblMuaHang.cshtml", table);
            }
            SystemFunctions.SaveSession("CTKM", "CreateCTKM");
            return RedirectToAction("Login", "Account");
        }

        public ActionResult getHangTang(string TongTien)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessCTKM.CTKM_getSPTang(Session["uid"].ToString(), TongTien);

                return PartialView("~/Views/CTKM/tables/__tblQuaTang.cshtml", table);
            }
            SystemFunctions.SaveSession("CTKM", "CreateCTKM");
            return RedirectToAction("Login", "Account");
        }

        //[HttpPost]
        //public ActionResult AddHangMua(List<CTKMModel> lst)
        //{
        //    try
        //    {
        //        if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
        //        {
        //            foreach (CTKMModel ar in lst)
        //            {
        //                DataAccess.DataAccessCTKM.CTKM_AddHangMua(Session["uid"].ToString(), ar.MaHang, ar.TenHang, ar.DonGia, ar.SLMua, ar.PTQua, ar.MaCTKM);
        //            }
        //            return Json(1);
        //        }
        //        return RedirectToAction("Login", "Account");
        //    }
        //    catch (Exception ex)
        //    {
        //        LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AddHangMua");
        //        return Json(null);
        //    }
        //}

        //[HttpPost]
        //public ActionResult AddHangTang(List<CTKMModel> lst)
        //{
        //    try
        //    {
        //        if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
        //        {
        //            foreach (CTKMModel ar in lst)
        //            {
        //                DataAccess.DataAccessCTKM.CTKM_AddHangTang(Session["uid"].ToString(), ar.MaHang, ar.TenHang, ar.DonGia, ar.SLQua, ar.MaCTKM);
        //            }
        //            return Json(1);
        //        }
        //        return RedirectToAction("Login", "Account");
        //    }
        //    catch (Exception ex)
        //    {
        //        LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AddHangTang");
        //        return Json(null);
        //    }
        //}

        //public ActionResult AddCBKM(CBKMModel it)
        //{
        //    try
        //    {
        //        if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
        //        {
        //            string rs = DataAccess.DataAccessCTKM.CTKM_AddCBKM(Session["uid"].ToString(), it);

        //            return Json(new { result = rs });
        //        }
        //        return RedirectToAction("Login", "Account");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { result = ex.Message });
        //    }
        //}

        //[HttpPost]
        //public ActionResult SaveCTKM(AddCBKM obj)
        //{
        //    var err = new RouteInfo();
        //    try
        //    {
        //        //var lst = DataAccess.DataAccessCTKM.CBKM_autocode();
        //        //var MaChienDich = lst[0].MaCTKM.Trim();

        //        var model = JsonConvert.DeserializeObject<List<CBKMModel>>(obj.CTKM);
        //        var modelHangMua = JsonConvert.DeserializeObject<List<CBKM_MuaHang>>(obj.HangMua);
        //        var modelHangTang = JsonConvert.DeserializeObject<List<CBKM_HangTang>>(obj.HangTang);

        //        //var listHeader = DataAccess.DataAccessCTKM.CTKM_AddCBKM(Session["uid"].ToString());
        //        //if (listHeader.Count() > 0)
        //        //{
        //        //    err.RespId = 0;
        //        //    err.RespMsg = "Mã CTKM đã tồn tại !";
        //        //}
        //        //else
        //        //{
        //        if (model.Count() > 0)
        //        {
        //            foreach (var item in model)
        //            {
        //                var result = DataAccess.DataAccessCTKM.CTKM_AddCBKM(Session["uid"].ToString(),item);
        //            }
        //            if (modelHangMua.Count() > 0 && modelHangTang.Count() > 0)
        //            {
        //                foreach (var item1 in modelHangMua)
        //                {
        //                    var result = DataAccess.DataAccessCTKM.CTKM_AddHangMua(Session["uid"].ToString(), item1);
        //                }
        //                foreach (var item2 in modelHangTang)
        //                {
        //                    var result = DataAccess.DataAccessCTKM.CTKM_AddHangTang(Session["uid"].ToString(), item2);
        //                }
        //            }
        //            err.RespId = 0;
        //            err.RespMsg = "Thêm mới thành công!";
        //        }
        //        else
        //        {
        //            err.RespId = -1;
        //            err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại";
        //        }
        //        //}
        //        return Json(err);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex);
        //    }
        //    return Json(err);
        //}

        [HttpPost]
        public ActionResult getautocode()
        {
            try
            {
                List<CBKMModel> list = DataAccess.DataAccessCTKM.CBKM_autocode();
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getautocode");
                return Json(null);
            }
        }

        #region DuyetCTKM

        public ActionResult DuyetCTKM()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    //var list_code = DataAccess.DataAccessCTKM.CBKM_autocode();
                    //ViewBag.list_code = list_code[0].MaCTKM;
                    var list_ncc = DataAccess.DataAccessCTKM.CTKM_cboNCC(Session["uid"].ToString());
                    ViewBag.list_ncc = list_ncc;

                    //var listCofde = DataAccess.DataAccessCTKM.CBKM_autocode();
                    //ViewBag.listCofde = listCofde[0].MaCTKM;
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("CTKM", "DuyetCTKM");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                SystemFunctions.SaveSession("CTKM", "DuyetCTKM");
               LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DuyetCTKM");
                return RedirectToAction("Logout", "Account");
            }
        }

        public ActionResult getDuyetCBKM(string NCC, string NgayTao, string TrangThai, string MaCTKM)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessCTKM.CTKM_getDuyetCBKM(Session["uid"].ToString(), NCC, NgayTao, TrangThai, MaCTKM);

                return PartialView("~/Views/CTKM/tables/__DuyetCBKM.cshtml", table);
            }
            SystemFunctions.SaveSession("CTKM", "DuyetCTKM");
            return RedirectToAction("Login", "Account");
        }

        public ActionResult deleteCBKM(List<CBKMUpdate> lst)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    foreach (CBKMUpdate po in lst)
                    {
                        DataAccess.DataAccessCTKM.CBKM_deleteCBKM(Session["uid"].ToString(), po.ID, po.MaCTKM);
                    }
                    return Json(1);
                }
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "deleteCBKM");
                return Json(null);
            }
        }
        public ActionResult UpdateTrangThai(int type, string MaCTKM)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list = DataAccess.DataAccessCTKM.CBKM_setTrangThai(Session["uid"].ToString(), type, MaCTKM);
                    return Json(list);
                }
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "UpdateTrangThai");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult CBKMGetHangMua(string MaCTKM)
        {
            try
            {
                List<CBKM_MuaHang> list = DataAccess.DataAccessCTKM.CBKM_getHangMua(Session["uid"].ToString(), MaCTKM);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CBKMGetHangMua");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult CBKMGetHangTang(string MaCTKM)
        {
            try
            {
                List<CBKM_HangTang> list = DataAccess.DataAccessCTKM.CBKM_getHangTang(Session["uid"].ToString(), MaCTKM);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CBKMGetHangTang");
                return Json(null);
            }
        }

        #endregion DuyetCTKM
    }
}