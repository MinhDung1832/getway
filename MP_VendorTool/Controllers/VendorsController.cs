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
using Lib.Utils.Package;

namespace MP_VendorTool.Controllers
{
    public class VendorsController : MyController
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        public ActionResult InfoConpany()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("Vendors", "InfoConpany")) return RedirectToAction("Index", "Home");
                    var ls_info = DataAccessVendors.sp_VendorTool_InfoCompany_get(Session["uid"].ToString());
                    if (ls_info.Count() > 0)
                    {
                        Response.Redirect("/Vendors/InfoConpanyEdit");
                    }

                    var ls_business = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "Business");
                    ViewBag.ls_business = ls_business;

                    var ls_industry = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "industry");
                    ViewBag.ls_industry = ls_industry;

                    var ls_employeesScale = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "employeesScale");
                    ViewBag.ls_employeesScale = ls_employeesScale;

                    var ls_coverageMarket = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "coverageMarket");
                    ViewBag.ls_coverageMarket = ls_coverageMarket;

                    var ls_previousRevenue = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "previousRevenue");
                    ViewBag.ls_previousRevenue = ls_previousRevenue;

                    var ls_position = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "position");
                    ViewBag.ls_position = ls_position;

                    var ls_bank = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "Bank");
                    ViewBag.ls_bank = ls_bank;

                    var ls_erp = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "ERP");
                    ViewBag.ls_erp = ls_erp;

                    var ls_yearActive = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "YearActive");
                    ViewBag.ls_yearActive = ls_yearActive;

                    var ls_compe = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "competencyCore");
                    ViewBag.ls_compe = ls_compe;

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Vendors", "InfoConpany");
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult InfoConpanyEdit()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("Vendors", "InfoConpany")) return RedirectToAction("Index", "Home");

                    var ls_business = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "Business");
                    ViewBag.ls_business = ls_business;

                    var ls_industry = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "industry");
                    ViewBag.ls_industry = ls_industry;

                    var ls_employeesScale = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "employeesScale");
                    ViewBag.ls_employeesScale = ls_employeesScale;

                    var ls_coverageMarket = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "coverageMarket");
                    ViewBag.ls_coverageMarket = ls_coverageMarket;

                    var ls_previousRevenue = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "previousRevenue");
                    ViewBag.ls_previousRevenue = ls_previousRevenue;

                    var ls_position = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "position");
                    ViewBag.ls_position = ls_position;

                    var ls_bank = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "Bank");
                    ViewBag.ls_bank = ls_bank;

                    var ls_erp = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "ERP");
                    ViewBag.ls_erp = ls_erp;

                    var ls_yearActive = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "YearActive");
                    ViewBag.ls_yearActive = ls_yearActive;

                    var ls_compe = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "competencyCore");
                    ViewBag.ls_compe = ls_compe;

                    var ls_info = DataAccessVendors.sp_VendorTool_InfoCompany_get(Session["uid"].ToString());
                    if (ls_info.Count() < 0)
                    {
                        Response.Redirect("/Vendors/InfoConpany");
                    }
                    else
                    {
                        ViewBag.ls_info = new List<InfoCompany>
                        {
                            ls_info[0]
                        };
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Vendors", "InfoConpany");
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult InfoCompany_Save(InfoCompany info)
        {
            var err = new RouteInfo();
            try
            {
                //var query1 = BaseConnectionSql.ExecuteList_Helper<objCombox>("strConn", "Api_Register_ischeck_SoDKKD", info.SoDKKD);
                //if (query1.Count() > 0)
                //{
                //    err.RespId = -1;
                //    err.RespMsg = "Số đăng ký kinh doanh đã tồn tại trong hệ thống";
                //    return Json(err);
                //}
                //var query2 = BaseConnectionSql.ExecuteList_Helper<objCombox>("strConn", "Api_Register_ischeck_MaSoThue", info.MaSoThue);
                //if (query2.Count() > 0)
                //{
                //    err.RespId = -1;
                //    err.RespMsg = "Mã số thuế đã tồn tại trong hệ thống";
                //    return Json(err);
                //}

                var result = DataAccessVendors.InfoCompany_Save(info, Session["uid"].ToString());
                if (result)
                {
                    err.RespId = 0;
                    err.RespMsg = "Đăng ký thông tin doang nghiệp thành công";
                }
                else
                {
                    err.RespId = -1;
                    err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại";
                }
                return Json(err);
            }
            catch (Exception ex)
            {
                err.RespId = -1;
                err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại";
                return Json(err);
            }
            return Json(err);
        }

        //BusinessRegistration
        public ActionResult RegisterPartner()
        {
            try
            {
                // if (!Constants.checkpermission("Vendors", "InfoConpany")) return RedirectToAction("Index", "Home");
                // var ls_info = DataAccessVendors.sp_VendorTool_InfoCompany_get(Session["uid"].ToString());

                var ls_business = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "Business");
                ViewBag.ls_business = ls_business;

                var ls_industry = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "industry");
                ViewBag.ls_industry = ls_industry;

                var ls_employeesScale = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "employeesScale");
                ViewBag.ls_employeesScale = ls_employeesScale;

                var ls_coverageMarket = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "coverageMarket");
                ViewBag.ls_coverageMarket = ls_coverageMarket;

                var ls_previousRevenue = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "previousRevenue");
                ViewBag.ls_previousRevenue = ls_previousRevenue;

                var ls_position = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "position");
                ViewBag.ls_position = ls_position;

                var ls_bank = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "Bank");
                ViewBag.ls_bank = ls_bank;

                var ls_erp = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "ERP");
                ViewBag.ls_erp = ls_erp;

                var ls_yearActive = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "YearActive");
                ViewBag.ls_yearActive = ls_yearActive;

                var ls_compe = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "competencyCore");
                ViewBag.ls_compe = ls_compe;

                return View();

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        

        [HttpPost]
        public ActionResult Show_Info_MD_Vendor(string MaSoThue)
        {
            try
            {
                var bn = SqlHelper.ExecuteList<Info_MD_Vendor>(ConfigurationManager.AppSettings.Get("strConnSpac"), "Show_Info_MD_Vendor", MaSoThue);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Show_Info_MD_Vendor");
                return Json(null);
            }
        }
    }

}
