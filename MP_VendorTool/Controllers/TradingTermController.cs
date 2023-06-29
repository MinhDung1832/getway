using Microsoft.Ajax.Utilities;
using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Account;
using MP_VendorTool.Models.Tradingterm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MP_VendorTool.Controllers
{
    public class TradingTermController : MyController
    {

        #region V1
        public ActionResult Index(string registrationTax="", string VendorContact_ID="")
        {
            try
            {
                if (Session["all_us_role"] != null)
                {
                    //gte role form session

                    RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C003");
                    Session["us_role"] = us_role;

                    if (registrationTax.Length > 0)
                    {
                        Session["registrationTax"] = registrationTax;
                    }

                    if (VendorContact_ID.Length > 0)
                    {
                        Session["on_VendorContact_ID"] = VendorContact_ID;
                    }

                    var ls_tra = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermHeader_get(Request.Cookies["culture"].Value, 0, VendorContact_ID);
                    ViewBag.ls_tra = ls_tra;

                    return View();
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TradingTermController_Index");
                 return RedirectToAction("Index", "Home");

            }
        }

        public ActionResult Detail(string registrationTax, string tradingtermId)
        {
            try
            {
                var ls_cooperate = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "cooperate");
                ViewBag.ls_cooperate = ls_cooperate;

                var ls_he = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermHeader_get(Request.Cookies["culture"].Value, 1, tradingtermId);
                ViewBag.head = ls_he[0];

                var ls_line = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermLine_get(Session["on_VendorContact_ID"].ToString(), tradingtermId);
                ViewBag.ls_line = ls_line;

                var ls_lead = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermLeadtime_get(tradingtermId);
                ViewBag.ls_lead = ls_lead;

                //set GP line
                var ls_GP = DataAccess.DataAccess.sp_BBM_MP_VendorTool_GP_get(registrationTax);
                ViewBag.ls_GP = ls_GP;

                List<string> ls_Ye = ls_GP.Select(s => s.Year).Distinct().ToList();
                ViewBag.ls_Ye = ls_Ye;

                List<TradingtermGP> ls_ty = ls_GP.Select(s => new TradingtermGP { TypeCost = s.TypeCost, TypeName = s.TypeName }).DistinctBy(s => s.TypeCost).ToList();
                ViewBag.ls_ty = ls_ty;

                //cal Gap
                var year = DateTime.Now.ToString("yyyy");

                List<TradingtermGP> gp = new List<TradingtermGP>();

                foreach (var i in ls_ty)
                {
                    try
                    {
                        var diff_1 = ls_GP.First(s => int.Parse(s.Year) == int.Parse(year) - 1 && s.TypeCost == i.TypeCost).value;
                        var diff_2 = ls_GP.First(s => int.Parse(s.Year) == int.Parse(year) && s.TypeCost == i.TypeCost).value;

                        var ssp = new TradingtermGP
                        {
                            TypeCost = i.TypeCost,
                            value = diff_1 - diff_2
                        };

                        gp.Add(ssp);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

                ViewBag.gp = gp;

                return View();
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TradingTermController_Detail");
                 return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Create()
        {
            try
            {
                var ls_leadtime = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "leadtime");
                ViewBag.ls_leadtime = ls_leadtime;

                var ls_cooperate = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "cooperate");
                ViewBag.ls_cooperate = ls_cooperate;

                var ls_prd = DataAccess.DataAccess.sp_BBM_MP_VendorTool_ProductInfo_get(Request.Cookies["culture"].Value, 0,Session["on_VendorContact_ID"].ToString());
                ViewBag.ls_prd = ls_prd;

                return View();
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TradingTermController_Create");
                 return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Edit(string registrationTax, string tradingtermId)
        {
            try
            {
                var ls_leadtime = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "leadtime");
                ViewBag.ls_leadtime = ls_leadtime;

                var ls_cooperate = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "cooperate");
                ViewBag.ls_cooperate = ls_cooperate;

                var ls_he = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermHeader_get(Request.Cookies["culture"].Value, 1, tradingtermId);
                ViewBag.head = ls_he[0];

                var ls_line = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermLine_get(Session["on_VendorContact_ID"].ToString(), tradingtermId);
                ViewBag.ls_line = ls_line;

                var ls_lead = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermLeadtime_get(tradingtermId);
                ViewBag.ls_lead = ls_lead;

                //set GP line
                var ls_GP = DataAccess.DataAccess.sp_BBM_MP_VendorTool_GP_get(registrationTax);
                ViewBag.ls_GP = ls_GP;

                List<string> ls_Ye = ls_GP.Select(s => s.Year).Distinct().ToList();
                ViewBag.ls_Ye = ls_Ye;

                List<TradingtermGP> ls_ty = ls_GP.Select(s => new TradingtermGP { TypeCost = s.TypeCost, TypeName = s.TypeName }).DistinctBy(s => s.TypeCost).ToList();
                ViewBag.ls_ty = ls_ty;

                //cal Gap
                var year = DateTime.Now.ToString("yyyy");

                List<TradingtermGP> gp = new List<TradingtermGP>();

                foreach (var i in ls_ty)
                {
                    try
                    {
                        var diff_1 = ls_GP.First(s => int.Parse(s.Year) == int.Parse(year) - 1 && s.TypeCost == i.TypeCost).value;
                        var diff_2 = ls_GP.First(s => int.Parse(s.Year) == int.Parse(year) && s.TypeCost == i.TypeCost).value;

                        var ssp = new TradingtermGP
                        {
                            TypeCost = i.TypeCost,
                            value = diff_1 - diff_2
                        };

                        gp.Add(ssp);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

                ViewBag.gp = gp;

                return View();
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TradingTermController_Edit");
                 return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Policy(string tradingtermId)
        {
            try
            {
                ViewBag.tradingtermId = tradingtermId;
                return View();
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TradingTermController_Edit");
                 return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult addTradingterm(TradingtermHeader head, List<TradingtermLine> lines, List<TradingtermLeadtime> lead)
        {
            try
            {
                head.VendorContact_ID = Session["on_VendorContact_ID"].ToString();
                var bn_header = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermHeader_add(head, Session["BBM_Code"] != null ? Session["BBM_Code"].ToString() : "guest", Session["registrationTax"].ToString());
                if (bn_header.Length > 0)
                {
                    if (lead != null)
                    {
                        //add leadTime

                        foreach (var i in lead)
                        {
                            try
                            {
                                var bn_lead = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermLeadtime_add(bn_header, i);
                            }
                            catch (Exception ex1)
                            {
                                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex1), "sp_BBM_MP_VendorTool_TradingtermLeadtime_add");
                                continue;
                            }
                        }
                    }

                    

                    if (lines != null)
                    {
                        //add itemLine
                        foreach (var i in lines)
                        {
                            try
                            {
                                var bn_line = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermLine_add(bn_header, i);
                            }
                            catch (Exception ex2)
                            {
                                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex2), "TradingTermController_addTradingterm_addLine");
                                continue;
                            }
                        }
                    }

                    

                    return Json( new {code= 1,message=bn_header,link=""});
                }
                else
                {
                    return Json(new {code=-1,message="Error",link=""});
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TradingTermController_addTradingterm");
                return Json(new { code = 0, message = "Error", link = "" });
            }
        }

        [HttpPost]

        public ActionResult addDayRefund(string tradingtermId, int dayQty)
        {
            try
            {
                var bn = DataAccess.DataAccess.sp_BBM_MP_VendorTool_TradingtermHeader_update(tradingtermId, dayQty);
                if (bn == true)
                {
                    return Json(new { code = 0, message = "Done", link = "" });
                }
                else
                {
                    return Json(new { code = -1, message = "Error", link = "" });
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TradingTermController_addDayRefund");
                return Json(new { code = 1, message = "Error", link = "" });
            }
        }

        #endregion


        #region V2

        public ActionResult CreateV2()
        {
            try
            {
                return View();
            }
            catch (Exception ex )
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CreateV2");

                return RedirectToAction("Logout", "Account");
            }
        }

        #endregion
    }
}