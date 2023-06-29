using Microsoft.Ajax.Utilities;
using MP_VendorTool.Common;
using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Order;
using Newtonsoft.Json;
using ProductAllTool.DataAccess;
using ProductAllTool.Models.CNGNCC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace ProductAllTool.Controllers
{
    public class CNGNCCController : Controller
    {
        // GET: CNGNCC
        
        public ActionResult Update()
        {
            try
            {
                //if (Session["uid"] != null && "B15035".Length > 0)
                //{
                    var lst_NCC_SP = DataAccess.DataAccessCNGNCC.CNGNCC_cboNCC_SP("B15035");
                    Session["lst_NCC_SP"] = lst_NCC_SP;
                    var lst_NCC = lst_NCC_SP.Select(s => new objCombox { Code = s.MaNCC, Name = s.NCC }).DistinctBy(s => s.Code).OrderBy(s => s.Code).ToList();
                    ViewBag.lst_NCC = lst_NCC;
                    return View();
                //}
                //else
                //{
                //    SystemFunctions.SaveSession("CNGNCC", "Update");
                //    return RedirectToAction("Login", "Account");
                //}
            }
            catch (Exception ex)
            {
                SystemFunctions.SaveSession("CNGNCC", "Update");
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CNGNCC");
                return RedirectToAction("Logout", "Account");
            }
        }

        public ActionResult getTenHang(string fillter, string NCC)
        {
            try
            {
                List<CNGNCCModel> ls_vv = (List<CNGNCCModel>)Session["lst_NCC_SP"];

                if (fillter == "tenhang")
                {
                    var rt = ls_vv.Where(s => NCC == "" || s.MaNCC == NCC).Select(s => new objCombox { Code = s.MaHang, Name = s.TenHang }).DistinctBy(s => s.Code).OrderBy(s => s.Code).ToList();
                    return Json(rt);
                }

                return Json(null);
            }
            catch (Exception ex)
            {
               LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getTenHang");
                return Json(null);
            }
        }
        public ActionResult getTenHangDuyet(string fillter, string NCC)
        {
            try
            {
                List<CNGNCCModel> ls_vv = (List<CNGNCCModel>)Session["lst_NCC_SP_Duyet"];

                if (fillter == "tenhang")
                {
                    var rt = ls_vv.Where(s => NCC == "" || s.MaNCC == NCC).Select(s => new objCombox { Code = s.MaHang, Name = s.TenHang }).DistinctBy(s => s.Code).OrderBy(s => s.Code).ToList();
                    return Json(rt);
                }

                return Json(null);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getTenHangDuyet");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult getSP(string MaHang)
        {
            try
            {
                var list = DataAccess.DataAccessCNGNCC.CNGNCC_getSP(MaHang);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getSP");
                return Json(null);
            }
        }

        public ActionResult AddSPDuyet(List<Sp_Duyet_Model> lst)
        {
            try
            {
                //if (Session["uid"] != null && "B15035".Length > 0)
                //{
                    foreach (Sp_Duyet_Model ar in lst)
                    {
                        DataAccess.DataAccessCNGNCC.CNGNCC_Add("B15035", ar);
                    }
                    return Json(1);
                //}
                //return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AddSPDuyet");
                return Json(null);
            }
        }

        public ActionResult Duyet()
        {
            try
            {
                //if (Session["uid"] != null && "B15035".Length > 0)
                //{
                    var lst_NCC_SP_Duyet = DataAccess.DataAccessCNGNCC.CNGNCC_cboNCC_SP_Duyet("B15035");
                    Session["lst_NCC_SP_Duyet"] = lst_NCC_SP_Duyet;
                    var lst_NCC_Duyet = lst_NCC_SP_Duyet.Select(s => new objCombox { Code = s.MaNCC, Name = s.NCC }).DistinctBy(s => s.Code).OrderBy(s => s.Code).ToList();
                    ViewBag.lst_NCC_Duyet = lst_NCC_Duyet;
                    return View();
                //}
                //else
                //{
                //    SystemFunctions.SaveSession("CNGNCC", "Duyet");
                //    return RedirectToAction("Login", "Account");
                //}
            }
            catch (Exception ex)
            {
                SystemFunctions.SaveSession("CNGNCC", "Duyet");
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CNGNCC");
                return RedirectToAction("Logout", "Account");
            }
        }

        public ActionResult getDuyet(string NCC, string TenHang,string TrangThai)
        {
            //if (Session["uid"] != null && "B15035".Length > 0)
            //{
                DataTable table = DataAccess.DataAccessCNGNCC.CNGNCC_GetDuyet("B15035", NCC, TenHang, TrangThai);

                return PartialView("~/Views/CNGNCC/tables/__tblDuyet.cshtml", table);
            //}
            //SystemFunctions.SaveSession("CNGNCC", "Duyet");
            //return RedirectToAction("Login", "Account");
        }

        public ActionResult UpdateTrangThai(List<Sp_Duyet_Model> lst, string type)
        {
            try
            {
                //if (Session["uid"] != null && "B15035".Length > 0)
                //{
                    foreach (Sp_Duyet_Model ar in lst)
                    {
                        DataAccess.DataAccessCNGNCC.CNGNCC_setTrangThai("B15035", ar, type);
                    }
                    return Json(1);
                //}
                //return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "UpdateTrangThai");
                return Json(null);
            }
        }
        public ActionResult QuanLy()
        {
            
                //if (Session["uid"] != null && "B15035".Length > 0)
                //{
                    var lst_NCC_SP_Duyet = DataAccess.DataAccessCNGNCC.CNGNCC_cboNCC_SP_Duyet("B15035");
                    Session["lst_NCC_SP_Duyet"] = lst_NCC_SP_Duyet;
                    var lst_NCC_Duyet = lst_NCC_SP_Duyet.Select(s => new objCombox { Code = s.MaNCC, Name = s.NCC }).DistinctBy(s => s.Code).OrderBy(s => s.Code).ToList();
                    ViewBag.lst_NCC_Duyet = lst_NCC_Duyet;
                    return View();
                //}
                //else
                //{
                //    SystemFunctions.SaveSession("CNGNCC", "QuanLy");
                //    return RedirectToAction("Login", "Account");
                //}
            
        }
    }
}