using MP_VendorTool.Common;
using MP_VendorTool.DataAccess;
using Newtonsoft.Json;
using ProductAllTool.DataAccess;
using ProductAllTool.Models.TTTM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace ProductAllTool.Controllers
{
    public class TTTMController : Controller
    {
        

        // GET: TTTM
        public ActionResult TTTM(string Type)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    ViewBag.Type = Type;
                    var list_LoaiThuong = DataAccess.DataAccessTTTM.TTTM_cboLoaiThuong();
                    ViewBag.list_LoaiThuong = list_LoaiThuong;

                    var list_DKDSTarget = DataAccess.DataAccessTTTM.TTTM_cboDKDSTarget();
                    ViewBag.list_DKDSTarget = list_DKDSTarget;

                    var list_DKDSTinhThuong = DataAccess.DataAccessTTTM.TTTM_cboDKDSTinhThuong();
                    ViewBag.list_DKDSTinhThuong = list_DKDSTinhThuong;

                    var list_NDDauTu = DataAccess.DataAccessTTTM.TTTM_cboNDDauTu();
                    ViewBag.list_NDDauTu = list_NDDauTu;

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("TTTM", "TTTM");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                SystemFunctions.SaveSession("TTTM", "TTTM");
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTM");
                return RedirectToAction("Logout", "Account");
            }
        }

        public ActionResult getDMSP()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessTTTM.TTTM_getDMSP(Session["uid"].ToString());

                return PartialView("~/Views/TTTM/tabs/__DanhMucSP.cshtml", table);
            }
            SystemFunctions.SaveSession("TTTM", "TTTM");
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult TTTMGetLoaiThuong()
        {
            try
            {
                var list_LoaiThuong = DataAccess.DataAccessTTTM.TTTM_cboLoaiThuong();
                return Json(list_LoaiThuong);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TTTMGetLoaiThuong");
                return Json(null);
            }
        }

        public ActionResult __MuaBan()
        {
            return PartialView();
        }

        public ActionResult __KyGui()
        {
            return PartialView();
        }

        public ActionResult __KeThue()
        {
            return PartialView();
        }

        //[HttpPost]
        //public ActionResult SaveTTTM(OBJ obj)
        //{
        //    var err = new RouteInfo();
        //    try
        //    {
        //        var modelThoaThuan = JsonConvert.DeserializeObject<List<ThoaThuan>>(obj.ThoaThuan);
        //        var modelDMSP = JsonConvert.DeserializeObject<List<DMSP>>(obj.DMSP);
        //        var modelThuong = JsonConvert.DeserializeObject<List<Thuong>>(obj.SourceLineThuong);
        //        var modelTrade = JsonConvert.DeserializeObject<List<TradeMarketing>>(obj.SourceLineTrade);
        //        var modelCK = JsonConvert.DeserializeObject<List<ChietKhau>>(obj.SourceLineCK);
        //        var modelHTH = JsonConvert.DeserializeObject<List<HTH>>(obj.SourceLineHTH);
        //        if (modelThoaThuan.Count() > 0)
        //        {
        //            foreach (var item in modelThoaThuan)
        //            {
        //                var result = DataAccess.DataAccessTTTM.TTTM_createThoaThuan(Session["uid"].ToString(), item);
        //            }
        //            if (modelDMSP.Count() > 0)
        //            {
        //                foreach (var item1 in modelDMSP)
        //                {
        //                    var result1 = DataAccess.DataAccessTTTM.TTTM_createDMSP(Session["uid"].ToString(), item1);
        //                }
        //                if (modelThuong.Count() > 0 && modelTrade.Count() > 0 && modelCK.Count() > 0 && modelHTH.Count() > 0)
        //                {
        //                    foreach (var item2 in modelThuong)
        //                    {
        //                        var result = DataAccess.DataAccessTTTM.TTTM_createThuong(Session["uid"].ToString(), item2);
        //                    }
                            
        //                    foreach (var item3 in modelCK)
        //                    {
        //                        var result = DataAccess.DataAccessTTTM.TTTM_createChietKhau(Session["uid"].ToString(), item3);
        //                    }
                            
        //                    foreach (var item4 in modelHTH)
        //                    {
        //                        var result = DataAccess.DataAccessTTTM.TTTM_createHTH(Session["uid"].ToString(), item4);
        //                    }
                            
        //                    foreach (var item5 in modelTrade)
        //                    {
        //                        var result = DataAccess.DataAccessTTTM.TTTM_createTradeMarketing(Session["uid"].ToString(), item5);
        //                    }
                            
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
    }
}