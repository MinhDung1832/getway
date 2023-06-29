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

namespace MP_VendorTool.Controllers
{
    public class VendorController : MyController
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        public ActionResult Index()
        {
            try
            {
                if (Session["all_us_role"] != null)
                {
                    RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");
                    Session["us_role"] = us_role;

                    List<VendorInfo> ls_info = new List<VendorInfo>();

                    if (Session["Vendor_con"] != null && us_role.roleCode == "R001")
                    {
                        ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 2, ((VendorContact)Session["Vendor_con"]).id);
                        ViewBag.ls_info = new List<VendorInfo>
                        {
                            ls_info[0]
                        };
                    }
                    else
                    {
                        ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 0, "");
                        ViewBag.ls_info = ls_info;
                    }
                    return View();
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_Index");
                 return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Commingsoon()
        {
            return View();
        }

        public ActionResult Detail(string MaNCC)
        {
            try
            {
                //gte role form session
                // RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s=>s.controlCode=="C001");

                //core data
                //var ls_business = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get("Business");
                //ViewBag.ls_business = ls_business;

                //var ls_industry = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get("industry");
                //ViewBag.ls_industry = ls_industry;


                //var ls_employeesScale = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get("employeesScale");
                //ViewBag.ls_employeesScale = ls_employeesScale;

                //var ls_coverageMarket = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get("coverageMarket");
                //ViewBag.ls_coverageMarket = ls_coverageMarket;

                //var ls_previousRevenue = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get("previousRevenue");
                //ViewBag.ls_previousRevenue = ls_previousRevenue;

                //var ls_position = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get("position");
                //ViewBag.ls_position = ls_position;

                //RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");
                //Session["us_role"] = us_role;
                //Session["roleCode"] = us_role.roleCode;

                //    List<VendorInfo> ls_info = new List<VendorInfo>();
                //    //registrationTax kiểm tra bảng [tbl_BBM_MP_VendorTool_VendorInfo] ko có thì insert vào

                //    if (Session["Vendor_con"] != null && us_role.roleCode == "R001")
                //    {
                //        ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get_MaNCC(Request.Cookies["culture"].Value, MaNCC);
                //        if (ls_info.Count > 0)
                //        {
                //            ViewBag.ls_info = new List<VendorInfo>
                //        {
                //            ls_info[0]
                //        };
                //        }
                //    }
                //    else
                //    {
                //        ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 0, "");
                //        if (ls_info.Count > 0)
                //        {
                //            ViewBag.ls_info = ls_info;
                //        }
                //    }

                //}
                //catch (Exception)
                //{ }

                //info

                var vd_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get_MaNCC(Request.Cookies["culture"].Value, MaNCC);
                if (vd_info.Count > 0)
                {
                    ViewBag.vd_info = vd_info[0];
                }

                var vd_cap = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorCapability_get_MaNCC(Request.Cookies["culture"].Value, MaNCC);
                if (vd_cap.Count > 0)
                {
                    ViewBag.vd_cap = vd_cap[0];
                }
                else
                {
                    ViewBag.vd_cap = new VendorCapability();
                }

                var vd_con = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_get_MaNCC(Request.Cookies["culture"].Value, MaNCC);
                if (vd_con.Count > 0)
                {
                    ViewBag.vd_con = vd_con[0];
                }
                else
                {
                    ViewBag.vd_con = new VendorContact();
                }
                return View();
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_Detail");
                 return RedirectToAction("Index", "Home");
            }
        }

        // GET: Vendor
        public ActionResult Create()
        {
            try
            {
                //gte role form session
                if (Session["registrationTax"] != "" && Session["on_VendorContact_ID"] != "")
                {
                  //  Response.Redirect("/Vendor/Detail?registrationTax=" + Session["registrationTax"] + "&VendorContact_ID=" + Session["on_VendorContact_ID"] + "");
                }
                RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");

                Session["us_role"] = us_role;
                Session["roleCode"] = us_role.roleCode;

                List<VendorInfo> ls_info = new List<VendorInfo>();

                if (Session["Vendor_con"] != null && us_role.roleCode == "R001")
                {
                    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 2, ((VendorContact)Session["Vendor_con"]).id);
                    if (ls_info.Count > 0)
                    {
                        ViewBag.ls_info = new List<VendorInfo>
                        {
                            ls_info[0]
                        };
                    }
                }
                else
                {
                    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 0, "");
                    if (ls_info.Count > 0)
                    {
                        ViewBag.ls_info = ls_info;
                    }
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
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_Create");
                 return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Circle()
        {
            try
            {
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_Circle");
                 return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Start()
        {
            try
            {
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_Start");
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult New()
        {
            try
            {
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_New");
                 return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Strategy1()
        {
            {
                try
                {
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
                    string ID = Session["uid"].ToString();
                    return View();

                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_New");
                    return RedirectToAction("Login", "Account");
                }
            }
            //Session["on_VendorContact_ID"].ToString();
        }

        public ActionResult Strategy2()
        {
            {
                try
                {
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
                    string ID = Session["uid"].ToString();
                    return View();

                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_New");
                    return RedirectToAction("Login", "Account");
                }
            }
            //Session["on_VendorContact_ID"].ToString();
        }

        public ActionResult Strategy3()
        {
            {
                try
                {
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
                    string ID = Session["uid"].ToString();
                    return View();

                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_New");
                    return RedirectToAction("Login", "Account");
                }
            }
            //Session["on_VendorContact_ID"].ToString();
        }

        public ActionResult Strategy4()
        {
            {
                try
                {
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
                    string ID = Session["uid"].ToString();
                    return View();

                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_New");
                    return RedirectToAction("Login", "Account");
                }
            }
            //Session["on_VendorContact_ID"].ToString();
        }

        public ActionResult Strategy5()
        {
            {
                try
                {
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
                    string ID = Session["uid"].ToString();
                    return View();

                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_New");
                    return RedirectToAction("Login", "Account");
                }
            }
            //Session["on_VendorContact_ID"].ToString();
        }

        public ActionResult Strategy6()
        {
            {
                try
                {
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
                    string ID = Session["uid"].ToString();
                    return View();

                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_New");
                    return RedirectToAction("Login", "Account");
                }
            }
            //Session["on_VendorContact_ID"].ToString();
        }

        public ActionResult Strategy7()
        {
            {
                try
                {
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
                    string ID = Session["uid"].ToString();
                    return View();

                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_New");
                    return RedirectToAction("Login", "Account");
                }
            }
            //Session["on_VendorContact_ID"].ToString();
        }

        public ActionResult Leasing()
        {
            return View();
        }

        //GetData
        public ActionResult GetMinimumCostByBrand(string brandcode)
        {
            string VendorCode = Session["uid"].ToString();
            MinimumCost result = new MinimumCost();
            result.lstdetail = new List<MinimumCostDetail>();
            result.lststore = new List<MinimumCostDetailDSCH>();
            using (var con = new SqlConnection(strConn))
            {

                try
                {
                    con.Open();
                    SqlCommand cmd;
                    // Get master
                    cmd = new SqlCommand("sp_Vendor_MinimumCost_by_Vendor_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorcode", VendorCode));
                    cmd.Parameters.Add(new SqlParameter("brandcode", brandcode));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.ID = int.Parse(reader["ID"].ToString());
                        result.MasterID = reader["MasterID"].ToString();
                        result.VendorCode = reader["VendorCode"].ToString();
                        result.NoStore = int.Parse(reader["NoStore"].ToString());
                        result.BrandCode = reader["BrandCode"].ToString();
                        result.ChiPhiToiThieuYTD = (decimal)reader["ChiPhiToiThieuYTD"];
                        result.DoanhSoBan = (decimal)reader["DoanhSoBan"];
                        result.LaiGop = (decimal)reader["LaiGop"];
                        result.HieuQuaKinhDoanh = reader["HieuQuaKinhDoanh"].ToString();
                        result.Ranking = reader["Ranking"].ToString();
                    }
                    con.Close();
                    con.Open();
                    // Get detail
                    cmd = new SqlCommand("sp_Vendor_MinimumCostDetail_by_Vendor_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MasterID", result.MasterID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MinimumCostDetail product = new MinimumCostDetail();
                        {
                            product.ID = int.Parse(reader["ID"].ToString());
                            product.MasterID = reader["MasterID"].ToString();
                            product.VendorCode = reader["VendorCode"].ToString();
                            product.BrandCode = reader["BrandCode"].ToString();
                            product.BrandName = reader["BrandName"].ToString();
                            product.TenSanPham = reader["TenSanPham"].ToString();
                            product.HinhAnhSanPham = reader["HinhAnhSanPham"].ToString();
                            product.MatTbSpCh = int.Parse(reader["MatTbSpCh"].ToString());
                            product.ChiPhiToiThieu = (decimal)reader["ChiPhiToiThieu"];
                            product.GPToiThieu = (decimal)reader["GPToiThieu"];
                            product.GPHienHanh = (decimal)reader["GPHienHanh"];
                            product.HieuQuaKinhDoanh = (decimal)reader["HieuQuaKinhDoanh"];
                            product.HieuQuaKinhDoanhText = reader["HieuQuaKinhDoanhText"].ToString();
                            product.MucDauTu = (decimal)reader["MucDauTu"];
                        };

                        result.lstdetail.Add(product);

                    }
                    Session["LstProduct"] = result.lstdetail;
                    con.Close();
                    con.Open();
                    //Get detail store
                    cmd = new SqlCommand("sp_Vendor_MinimumCostDetailStore_by_Vendor_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MasterID", result.ID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MinimumCostDetailDSCH store = new MinimumCostDetailDSCH();
                        {
                            store.ID = int.Parse(reader["ID"].ToString());
                            store.MasterID = reader["MasterID"].ToString();
                            store.VendorCode = reader["VendorCode"].ToString();
                            store.BrandCode = reader["BrandCode"].ToString();
                            store.StoreCode = reader["StoreCode"].ToString();
                            store.StoreName = reader["StoreName"].ToString();
                        };

                        result.lststore.Add(store);
                    }

                    con.Close();
                    return JsonMax(result);
                }
                catch (Exception ex)
                {

                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Vendor_MinimumCost_by_Vendor_get");
                    return JsonMax(result);
                }
            }
        }

        public ActionResult GetKeHoachbyYear(string year)
        {
            string VendorCode = Session["uid"].ToString();
            KeHoach result = new KeHoach();
            using (var con = new SqlConnection(strConn))
            {

                try
                {
                    con.Open();
                    SqlCommand cmd;
                    // Get master
                    cmd = new SqlCommand("sp_Vendor_tbl_KeHoach_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorcode", VendorCode));
                    cmd.Parameters.Add(new SqlParameter("year", year));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.ID = int.Parse(reader["ID"].ToString());
                        result.VendorCode = reader["VendorCode"].ToString();
                        result.VendorName = reader["VendorName"].ToString();
                        result.Year = reader["Year"].ToString();
                        result.Thang1 = (decimal)reader["Thang1"];
                        result.Thang2 = (decimal)reader["Thang2"];
                        result.Thang3 = (decimal)reader["Thang3"];
                        result.Thang4 = (decimal)reader["Thang4"];
                        result.Thang5 = (decimal)reader["Thang5"];
                        result.Thang6 = (decimal)reader["Thang6"];
                        result.Thang7 = (decimal)reader["Thang7"];
                        result.Thang8 = (decimal)reader["Thang8"];
                        result.Thang9 = (decimal)reader["Thang9"];
                        result.Thang10 = (decimal)reader["Thang10"];
                        result.Thang11 = (decimal)reader["Thang11"];
                        result.Thang12 = (decimal)reader["Thang12"];
                        result.Quy1 = (decimal)reader["Quy1"];
                        result.Quy2 = (decimal)reader["Quy2"];
                        result.Quy3 = (decimal)reader["Quy3"];
                        result.Quy4 = (decimal)reader["Quy4"];
                        result.Mucdautu = (decimal)reader["Mucdautu"];
                    }
                    con.Close();
                    return JsonMax(result);
                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Vendor_tbl_KeHoach_get");
                    return JsonMax(result);
                }
            }
        }

        public ActionResult GetKeHoachKhac()
        {
            string VendorCode = Session["uid"].ToString();
            KeHoachKhac result = new KeHoachKhac();
            using (var con = new SqlConnection(strConn))
            {

                try
                {
                    con.Open();
                    SqlCommand cmd;
                    // Get master
                    cmd = new SqlCommand("sp_Vendor_tbl_KeHoachKhac_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorcode", VendorCode));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.ID = int.Parse(reader["ID"].ToString());
                        result.VendorCode = reader["VendorCode"].ToString();
                        result.VendorName = reader["VendorName"].ToString();
                        result.HangMuc11 = reader["HangMuc11"].ToString();
                        result.MucDauTu11 = (decimal)reader["MucDauTu11"];
                        result.HangMuc12 = reader["HangMuc12"].ToString();
                        result.MucDauTu12 = (decimal)reader["MucDauTu12"];
                        result.HangMuc13 = reader["HangMuc13"].ToString();
                        result.MucDauTu13 = (decimal)reader["MucDauTu13"];
                        result.TongNganSach1 = (decimal)reader["TongNganSach1"];

                        result.HangMuc21 = reader["HangMuc21"].ToString();
                        result.MucDauTu21 = (decimal)reader["MucDauTu21"];
                        result.HangMuc22 = reader["HangMuc22"].ToString();
                        result.MucDauTu22 = (decimal)reader["MucDauTu22"];
                        result.HangMuc23 = reader["HangMuc23"].ToString();
                        result.MucDauTu23 = (decimal)reader["MucDauTu23"];
                        result.TongNganSach2 = (decimal)reader["TongNganSach2"];

                        result.HangMuc31 = reader["HangMuc31"].ToString();
                        result.MucDauTu31 = (decimal)reader["MucDauTu31"];
                        result.HangMuc32 = reader["HangMuc32"].ToString();
                        result.MucDauTu32 = (decimal)reader["MucDauTu32"];
                        result.HangMuc33 = reader["HangMuc33"].ToString();
                        result.MucDauTu33 = (decimal)reader["MucDauTu33"];
                        result.TongNganSach3 = (decimal)reader["TongNganSach3"];

                        result.HangMuc41 = reader["HangMuc41"].ToString();
                        result.MucDauTu41 = (decimal)reader["MucDauTu41"];
                        result.HangMuc42 = reader["HangMuc42"].ToString();
                        result.MucDauTu42 = (decimal)reader["MucDauTu42"];
                        result.HangMuc43 = reader["HangMuc43"].ToString();
                        result.MucDauTu43 = (decimal)reader["MucDauTu43"];
                        result.TongNganSach4 = (decimal)reader["TongNganSach4"];

                    }
                    con.Close();
                    return JsonMax(result);
                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Vendor_tbl_KeHoachKhac_get");
                    return JsonMax(result);
                }
            }
        }

        public ActionResult GetAllStore()
        {
            List<StoreInfo> result = new List<StoreInfo>();
            using (var con = new SqlConnection(strConn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_getAllStore", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StoreInfo st = new StoreInfo();
                        {
                            st.StoreCode = reader["StoreNo"].ToString();
                            st.StoreName = reader["StoreName"].ToString();
                            st.PostCode = reader["PostCode"].ToString();
                            st.DateOpen = reader["DateOpen"].ToString();
                            st.DateClose = reader["DateClose"].ToString();
                            st.RegionCode = reader["RegionCode"].ToString();
                            st.RegionName = reader["RegionName"].ToString();
                            st.DistrictCode = reader["DistrictCode"].ToString();
                            st.DistrictName = reader["DistrictName"].ToString();
                        };
                        result.Add(st);
                    }
                    con.Close();
                    return JsonMax(result);
                }
                catch (Exception ex)
                {

                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getAllStore");
                    return JsonMax(result);
                }
            }
        }

        public ActionResult GetAllHangMuc()
        {
            List<HangMuc> result = new List<HangMuc>();
            using (var con = new SqlConnection(strConn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_getAllHangMuc", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        HangMuc hm = new HangMuc();
                        {
                            hm.HangMucCode = reader["HangMucCode"].ToString();
                            hm.HangMucName = reader["HangMucName"].ToString();
                        };
                        result.Add(hm);
                    }
                    con.Close();
                    return JsonMax(result);
                }
                catch (Exception ex)
                {

                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getAllStore");
                    return JsonMax(result);
                }
            }
        }

        public ActionResult GetBrandbyVendor()
        {
            string VendorCode = Session["uid"].ToString();
            List<Brandinfo> result = new List<Brandinfo>();
            using (var con = new SqlConnection(strConn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_Vendor_MinimumCost_Brand_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("vendorcode", VendorCode));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Brandinfo br = new Brandinfo();
                        {
                            br.BrandCode = reader["BrandCode"].ToString();
                            br.BrandName = reader["BrandName"].ToString();
                        };
                        result.Add(br);
                    }
                    con.Close();
                    return JsonMax(result);
                }
                catch (Exception ex)
                {

                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getAllStore");
                    return JsonMax(result);
                }
            }
        }

        protected JsonResult JsonMax(object data)
        {
            JsonResult result = Json(data);
            result.MaxJsonLength = int.MaxValue;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult PostMinimumCostUpdateDetail()
        {
            List<MinimumCostDetail> lstproduct = (List<MinimumCostDetail>)Session["LstProduct"];
            using (var con = new SqlConnection(strConn))
            {
                try
                {
                    foreach (MinimumCostDetail item in lstproduct)
                    {
                        con.Open();
                        SqlCommand cmd;
                        cmd = new SqlCommand("sp_Vendor_MinimumCost_Detail_update", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("ID", item.ID));
                        cmd.Parameters.Add(new SqlParameter("MatTbSpCh", item.MatTbSpCh));
                        cmd.Parameters.Add(new SqlParameter("MucDauTu", item.MucDauTu));
                        cmd.ExecuteScalar();
                        con.Close();
                    }
                    return JsonMax(1);
                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Vendor_MinimumCost_Brand_get");
                    return JsonMax(0);
                }
            }
        }

        public ActionResult PostKeHoachUpdate(KeHoach kh)
        {
            using (var con = new SqlConnection(strConn))
            {
                try
                {

                    con.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_Vendor_tbl_KeHoach_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", kh.VendorCode));
                    cmd.Parameters.Add(new SqlParameter("Year", kh.Year));
                    cmd.Parameters.Add(new SqlParameter("Thang1", kh.Thang1));
                    cmd.Parameters.Add(new SqlParameter("Thang2", kh.Thang2));
                    cmd.Parameters.Add(new SqlParameter("Thang3", kh.Thang3));
                    cmd.Parameters.Add(new SqlParameter("Thang4", kh.Thang4));
                    cmd.Parameters.Add(new SqlParameter("Thang5", kh.Thang5));
                    cmd.Parameters.Add(new SqlParameter("Thang6", kh.Thang6));
                    cmd.Parameters.Add(new SqlParameter("Thang7", kh.Thang7));
                    cmd.Parameters.Add(new SqlParameter("Thang8", kh.Thang8));
                    cmd.Parameters.Add(new SqlParameter("Thang9", kh.Thang9));
                    cmd.Parameters.Add(new SqlParameter("Thang10", kh.Thang10));
                    cmd.Parameters.Add(new SqlParameter("Thang11", kh.Thang11));
                    cmd.Parameters.Add(new SqlParameter("Thang12", kh.Thang12));
                    cmd.Parameters.Add(new SqlParameter("Quy1", kh.Quy1));
                    cmd.Parameters.Add(new SqlParameter("Quy2", kh.Quy2));
                    cmd.Parameters.Add(new SqlParameter("Quy3", kh.Quy3));
                    cmd.Parameters.Add(new SqlParameter("Quy4", kh.Quy4));
                    cmd.Parameters.Add(new SqlParameter("Mucdautu", kh.Mucdautu));
                    cmd.ExecuteScalar();
                    con.Close();
                    return JsonMax(1);
                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Vendor_tbl_KeHoach_update");
                    return JsonMax(0);
                }
            }
        }

        public ActionResult PostKeHoachKhacUpdate(KeHoachKhac kh)
        {
            using (var con = new SqlConnection(strConn))
            {
                try
                {

                    con.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_Vendor_tbl_KeHoachKhac_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", kh.VendorCode));
                    cmd.Parameters.Add(new SqlParameter("HangMuc11", kh.HangMuc11));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu11", kh.MucDauTu11));
                    cmd.Parameters.Add(new SqlParameter("HangMuc12", kh.HangMuc12));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu12", kh.MucDauTu12));
                    cmd.Parameters.Add(new SqlParameter("HangMuc13", kh.HangMuc13));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu13", kh.MucDauTu13));

                    cmd.Parameters.Add(new SqlParameter("HangMuc21", kh.HangMuc21));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu21", kh.MucDauTu21));
                    cmd.Parameters.Add(new SqlParameter("HangMuc22", kh.HangMuc22));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu22", kh.MucDauTu22));
                    cmd.Parameters.Add(new SqlParameter("HangMuc23", kh.HangMuc23));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu23", kh.MucDauTu23));

                    cmd.Parameters.Add(new SqlParameter("HangMuc31", kh.HangMuc31));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu31", kh.MucDauTu31));
                    cmd.Parameters.Add(new SqlParameter("HangMuc32", kh.HangMuc32));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu32", kh.MucDauTu32));
                    cmd.Parameters.Add(new SqlParameter("HangMuc33", kh.HangMuc33));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu33", kh.MucDauTu33));

                    cmd.Parameters.Add(new SqlParameter("HangMuc41", kh.HangMuc41));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu41", kh.MucDauTu41));
                    cmd.Parameters.Add(new SqlParameter("HangMuc42", kh.HangMuc42));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu42", kh.MucDauTu42));
                    cmd.Parameters.Add(new SqlParameter("HangMuc43", kh.HangMuc43));
                    cmd.Parameters.Add(new SqlParameter("MucDauTu43", kh.MucDauTu43));

                    cmd.ExecuteScalar();
                    con.Close();
                    return JsonMax(1);
                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Vendor_tbl_KeHoach_update");
                    return JsonMax(0);
                }
            }
        }

        public ActionResult PostMinimumCostUpdateStore(int MasterID, List<MinimumCostDetailDSCH> lstStore)
        {
            using (var con = new SqlConnection(strConn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_Vendor_MinimumCost_Store_delete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MasterID", MasterID));
                    cmd.ExecuteScalar();
                    con.Close();

                    foreach (MinimumCostDetailDSCH item in lstStore)
                    {
                        con.Open();
                        cmd = new SqlCommand("sp_Vendor_MinimumCost_Store_insert", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("MasterID", MasterID));
                        cmd.Parameters.Add(new SqlParameter("StoreCode", item.StoreCode));
                        cmd.Parameters.Add(new SqlParameter("StoreName", item.StoreName));
                        cmd.ExecuteScalar();
                        con.Close();
                    }
                    return JsonMax(1);
                }
                catch (Exception ex)
                {

                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Vendor_MinimumCost_Brand_get");
                    return JsonMax(0);
                }
            }
        }

        public ActionResult Edit(string MaNCC)
        {
            try
            {

                //gte role form session
               
                RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");

                Session["us_role"] = us_role;
                Session["roleCode"] = us_role.roleCode;

                List<VendorInfo> ls_info = new List<VendorInfo>();

                if (Session["Vendor_con"] != null && us_role.roleCode == "R001")
                {
                    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 2, ((VendorContact)Session["Vendor_con"]).id);
                    ViewBag.ls_info = new List<VendorInfo>
                        {
                            ls_info[0]
                        };
                }
                else
                {
                    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 0, "");
                    ViewBag.ls_info = ls_info;
                }


                //core data
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

                //info

                var vd_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get_MaNCC(Request.Cookies["culture"].Value, MaNCC);
                if (vd_info.Count > 0)
                {
                    ViewBag.vd_info = vd_info[0];
                }

                var vd_cap = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorCapability_get_MaNCC(Request.Cookies["culture"].Value, MaNCC);
                if (vd_cap.Count > 0)
                {
                    ViewBag.vd_cap = vd_cap[0];
                }
                else
                {
                    ViewBag.vd_cap = new VendorCapability();
                }

                var vd_con = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_get_MaNCC(Request.Cookies["culture"].Value, MaNCC);
                if (vd_con.Count > 0)
                {
                    ViewBag.vd_con = vd_con[0];
                }
                else
                {
                    ViewBag.vd_con = new VendorContact();
                }


                //var vd_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 1, registrationTax);
                //ViewBag.vd_info = vd_info[0];

                //var vd_cap = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorCapability_get(Request.Cookies["culture"].Value, registrationTax);
                //if (vd_cap.Count > 0)
                //{
                //    ViewBag.vd_cap = vd_cap[0];
                //}
                //else
                //{
                //    ViewBag.vd_cap = new VendorCapability();
                //}

                ////var vd_con = new List<VendorContact>();
                ////if (us_role.roleCode == "R001")
                ////{
                //var vd_con = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_get(Request.Cookies["culture"].Value, 3, VendorContact_ID, us_role.BBM_Code);
                ////}
                ////else
                ////{
                ////    vd_con = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_get(0, registrationTax, "");
                ////}
                //ViewBag.vd_con = vd_con[0];

                return View();


            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_Edit");
                 return RedirectToAction("Index", "Home");
            }
        }

        public bool vendor_new_mail(VendorInfo info, VendorContact con)
        {
            try
            {
                string param = "";
                param += "vendorName;" + info.firmName;
                var bn = DataAccess.DataAccess.sp_BBM_MP_VendorTool_ScheduleEmail_add("vendorNew",
                        info.email, param, 0);
                return bn;
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "");
                return false;
            }
        }

        [HttpPost]
        public ActionResult addVendor(VendorInfo info, VendorCapability cap, VendorContact con)
        {
            try
            {

                //add Info
                var bn_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_add(info);
                if (bn_info != true)
                {
                    return Json(@"{""code"":""-1"",""message"":""Error"",""link"":""""}");
                }
                else
                {
                    var bn_cap = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorCapability_add(cap);
                    if (bn_cap != true)
                    {
                        return Json(@"{""code"":""-2"",""message"":""Error"",""link"":""""}");
                    }
                    else
                    {
                        var bn_con = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_add(con, "admin");
                        if (bn_con.Length == 0)
                        {

                            return Json(@"{""code"":""-3"",""message"":""Error"",""link"":""""}");
                        }
                        else
                        {
                            try
                            {
                                var vd_contact = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_get_login(Request.Cookies["culture"].Value, Session["uids"].ToString());
                                if (vd_contact.Count > 0)
                                {
                                    Session["Vendor_con"] = vd_contact[0];
                                    Session["registrationTax"] = vd_contact[0].registrationTax;
                                    Session["on_VendorContact_ID"] = vd_contact[0].id;
                                    Session["BBM_Code"] = "";
                                }
                                else
                                {
                                    Session["Vendor_con"] = null;
                                    Session["registrationTax"] = "";
                                    Session["on_VendorContact_ID"] = "";
                                    Session["BBM_Code"] = Session["uids"].ToString();
                                }
                            }
                            catch (Exception)
                            {
                                Session["registrationTax"] = info.registrationTax;
                                Session["on_VendorContact_ID"] = bn_con;
                            }
                            //Session["registrationTax"] = info.registrationTax;
                            //Session["on_VendorContact_ID"] = bn_con;
                            //gui mail
                            // vendor_new_mail(info, con);
                            return Json(@"{""code"":""1"",""message"":""Error"",""link"":""""}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_addVendor");
                return Json(@"{""code"":""0"",""message"":""Error"",""link"":""""}");
            }
        }

        public void vd_Admin_mail(string type, int ApproveID, string vendorcontactid)
        {
            try
            {
                string param = "";
                var ls_vendor = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_get(Request.Cookies["culture"].Value, 3, vendorcontactid, "");
                var ls_memberinfo = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 1, ls_vendor[0].registrationTax);

                param += "attributeName;" + ls_memberinfo[0].firmName;
                param += "|" + "vendorName;" + ls_memberinfo[0].firmName;
                param += "|" + "vendor_bbm_code;" + ls_vendor[0].BBM_Code;
                //genlink upload Cert
                var str_token = ApproveID.ToString() + "|" + ls_vendor[0].BBM_Code + "|" + "0" + "|vendor";
                string domainName = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));

                param += "|" + "url_upload;" + domainName + "/Vendor/Certificate?token=" + DataAccess.DataAccess.Encryption(str_token);
                var bn = DataAccess.DataAccess.sp_BBM_MP_VendorTool_ScheduleEmail_add(type,
                    ls_memberinfo[0].email, param, ApproveID);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "");
            }
        }

        public ActionResult editVendor(VendorInfo info, VendorCapability cap, VendorContact con)
        {
            try
            {
                var bn_con = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_edit(con, Session["uid"].ToString());
                if (bn_con.Contains("Success"))
                {
                    DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorCapability_edit(cap);
                    DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_edit(info);
                    // vd_Admin_mail("vendorAccept", int.Parse(bn_con.Split('|')[1]), con.id);
                    return Json(new { code = 0, message = "" });
                }
                else
                {
                    return Json(new { code = 2, message = bn_con });
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_editVendor");
                return Json(new { code = 1, message = "Có lỗi xảy ra, thử lại sau!" });
            }
        }

        public ActionResult editVendor_New(VendorInfo info, VendorCapability cap, VendorContact con)
        {
            try
            {
                try
                {
                    DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_Update(con, Session["uid"].ToString());
                    DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorCapability_Update(cap, con.id, con.BBM_Code);
                    DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_Update(info, con.id, con.BBM_Code);
                    return Json(new { code = 0, message = "" });
                }
                catch (Exception)
                {
                    return Json(new { code = 2, message = "Lỗi" });
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_editVendor");
                return Json(new { code = 1, message = "Có lỗi xảy ra, thử lại sau!" });
            }
        }

        [HttpPost]
        public ActionResult registrationTaxExist(string registrationTax)
        {
            try
            {
                var ls = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 1, registrationTax);
                if (ls.Count == 0)
                {
                    return Json(new { code = 0, message = "Error" });
                }
                else
                {
                    return Json(new { code = -1, message = "Error" });
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_registrationTaxExist");
                return Json(new { code = 1, message = "Error" });
            }
        }

        #region Certificate
        public ActionResult Certificate(string token = "")
        {
            try
            {
                if (token.Length > 0)
                {
                    var bn = DataAccess.DataAccess.Decryption(token.Replace(" ", "+"));
                    if (bn.Split('|')[3].ToString() == "product")
                    {
                        var ls_prd = DataAccess.DataAccess.sp_BBM_MP_VendorTool_ProductInfo_get(Request.Cookies["culture"].Value, 2, bn.Split('|')[2]);
                        ViewBag.Productname = ls_prd[0].name;
                    }
                    else
                    {
                        ViewBag.Productname = "";
                    }
                    ViewBag.token = token;
                }
                else
                {
                    ViewBag.token = "";
                }

                return View();
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Certificate");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult cer_Upload()
        {
            try
            {

                var file = Request.Files[0];
                //var file = System.Web.HttpContext.Current.Request.Files["MyImages"];

                string filename = Regex.Replace(Path.GetFileName(Server.MapPath(file.FileName)), @"[^0-9a-zA-Z:,.-]+", "");

                string str_dir = HttpContext.Server.MapPath("~/VendorCert/") + DateTime.Now.ToString("yyyy") + @"\" + DateTime.Now.ToString("MM");

                if (!Directory.Exists(str_dir))
                {
                    Directory.CreateDirectory(str_dir);
                }


                #region save raw

                string link = str_dir + @"/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_imp_" + filename;

                if (!filename.Contains("jpg") && !filename.Contains("png") && !filename.Contains("jpeg"))
                {

                    file.SaveAs(link);
                    var matP1 = Regex.Split(link.Replace("\\", "/"), "VendorCert");

                    //return Json(@"{""code"":""0"",""link"":"""+link+@"""}");
                    return Json(new { code = 1, link = "/VendorCert/" + matP1[1], message = "" });
                }



                #endregion

                #region save Resize

                System.Drawing.Image image = System.Drawing.Image.FromStream(file.InputStream);
                //System.Drawing.Image image = System.Drawing.Image.FromFile(link);
                float aspectRatio = (float)image.Size.Width / (float)image.Size.Height;
                int newHeight = 700;
                int newWidth = Convert.ToInt32(aspectRatio * newHeight);

                foreach (var prop in image.PropertyItems)
                {
                    if ((prop.Id == 0x0112 || prop.Id == 5029 || prop.Id == 274))
                    {
                        var value = (int)prop.Value[0];
                        if (value == 6)
                        {
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        }
                        else if (value == 8)
                        {
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        }
                        else if (value == 3)
                        {
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        }
                    }
                }


                System.Drawing.Bitmap thumbBitmap = new System.Drawing.Bitmap(newWidth, newHeight);
                System.Drawing.Graphics thumbGraph = System.Drawing.Graphics.FromImage(thumbBitmap);

                thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                var str_thumb = str_dir + @"/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_imp_thumb_" + filename;

                thumbBitmap.Save(str_thumb, System.Drawing.Imaging.ImageFormat.Jpeg);
                thumbGraph.Dispose();
                thumbBitmap.Dispose();

                #endregion

                var matP = Regex.Split(str_thumb.Replace("\\", "/"), "VendorCert");



                //return Json(@"{""code"":""0"",""link"":"""+link+@"""}");
                return Json(new { code = 1, link = "/VendorCert/" + matP[1], message = "" });
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(ex.ToString(), "uploadImg");
                return Json(new { code = 0, link = "", message = "Có lỗi xảy ra, thử lại sau!" });
            }
        }

        [HttpPost]
        public ActionResult cert_Save(string token, List<Certificate_Item> ls_cer)
        {
            try
            {
                if (ls_cer == null)
                {
                    return Json(new { code = 2, message = "Upload ít nhất 1 file" });
                }

                var str_vendor = DataAccess.DataAccess.Decryption(token.Replace(" ", "+"));
                var arr_vendor = str_vendor.Split('|');

                int s = 0, f = 0;
                foreach (var i in ls_cer)
                {
                    i.ApproveID = arr_vendor[0].ToString();
                    i.VendorCode = arr_vendor[1].ToString();
                    i.VendorContactID = "";
                    i.ChangeType = arr_vendor[3].ToString();
                    i.Filename = Path.GetFileName(i.link);
                    i.attributeCode = arr_vendor[3].ToString();

                    var bn = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Certificate_Link_add(i);
                    if (bn == true)
                    {
                        s++;
                    }
                    else
                    {
                        f++;
                    }
                }

                return Json(new { code = 0, message = "Thêm thành công " + s + " bản ghi!" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "cert_Save");
                return Json(new { code = 1, message = "" });
            }
        }
        #endregion
    }
}