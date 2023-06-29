using Microsoft.Ajax.Utilities;
using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Account;
using MP_VendorTool.Models.Dashboard;
using MP_VendorTool.Models.MutiLanguage;
using MP_VendorTool.Models.Seminar;
using MP_VendorTool.Models.Vendor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MP_VendorTool.Controllers
{
    public class HomeController : MyController
    {
        public ActionResult Index(string NamDS)
        {
            ViewBag.lang = Request.Cookies["culture"].Value;
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    // DataAccess.DataAccess.TraLaiKhoHang_Count_Save(Session["uid"].ToString());

                    //var ls_Company = DataAccess.DataAccess.sp_GetWay_info_Company_get(Session["uid"].ToString());
                    //if (ls_Company.Count > 0)
                    //{
                    //    ViewBag.ls_Company = ls_Company[0];
                    //}
                    //var ls_SLSP = DataAccess.DataAccess.sp_GetWay_info_Company_SLSanPham_get(Session["uid"].ToString());
                    //if (ls_SLSP.Count > 0)
                    //{
                    //    ViewBag.ls_SLSP = ls_SLSP[0].Code;
                    //}
                    //var ls_sem = DataAccess.DataAccess.sp_GetWay_info_Company_NganhHang_get(Session["uid"].ToString());
                    //if (ls_sem.Count > 0)
                    //{
                    //    foreach (var item in ls_sem)
                    //    {
                    //        ViewBag.ls_sem += " <span>" + item.Code + "</span>";
                    //    }
                    //}


                    #region Year
                    var namDs = NamDS != null ? NamDS : DateTime.Now.Year.ToString();
                    var yearOptions = new StringBuilder();

                    for (int i = 2019; i <= DateTime.Now.Year; i++)
                    {
                        yearOptions.Append("<option");
                        if (namDs == i.ToString() || (NamDS == "" && DateTime.Now.Year == i))
                        {
                            yearOptions.Append(" selected");
                        }
                        yearOptions.AppendFormat(" value=\"{0}\">Năm {0}</option>", i);
                    }

                    ViewBag.YearDoanhSoThang = yearOptions.ToString();
                    #endregion


                    #region Lấy doanh số năm
                    
                    #endregion

                    #region Lấy doanh số các tháng
                    
                    #endregion

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<ActionResult> fillNamDoanhSoThang(string namDs)
        {
            try
            {
               
                return Json(new { data_CacThang = 0, labels_CacThang = 0 });
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        public ActionResult Menu()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var ls_Company = DataAccess.DataAccess.sp_GetWay_info_Company_get(Session["uid"].ToString());
                    if (ls_Company.Count > 0)
                    {
                        ViewBag.ls_Company = ls_Company[0];
                    }
                    var ls_SLSP = DataAccess.DataAccess.sp_GetWay_info_Company_SLSanPham_get(Session["uid"].ToString());
                    if (ls_SLSP.Count > 0)
                    {
                        ViewBag.ls_SLSP = ls_SLSP[0].Code;
                    }
                    var ls_sem = DataAccess.DataAccess.sp_GetWay_info_Company_NganhHang_get(Session["uid"].ToString());
                    if (ls_sem.Count > 0)
                    {
                        foreach (var item in ls_sem)
                        {
                            ViewBag.ls_sem += " <span>" + item.Code + "</span>";
                        }
                    }

                    //// check ngày hết hạn 7 ngày thì bắt đổi mật khẩu
                    //var it = DataAccess.DataAccess.BBM_MP_VendorTool_User_ChangePassword(Session["uid"].ToString());
                    //if (Convert.ToInt32(it[0].Code) >= 7)
                    //{
                    //    return RedirectToAction("ChangePassword", "Account");
                    //}

                    RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");
                    if (us_role.roleCode != null && us_role.roleCode.Length > 0)
                    {
                        Session["us_role"] = us_role;
                        Session["roleCode"] = us_role.roleCode;
                        List<VendorInfo> ls_info = new List<VendorInfo>();

                        //if (Session["Vendor_con"] != null && us_role.roleCode == "R001")
                        //{
                        //    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 2, ((VendorContact)Session["Vendor_con"]).id);
                        //    ViewBag.ls_info = new List<VendorInfo>
                        //    {
                        //        ls_info[0]
                        //    };
                        //    Session["registrationTax"] = ls_info[0].registrationTax;
                        //    Session["on_VendorContact_ID"] = ls_info[0].VendorContact_ID;
                        //}
                        //else
                        //{
                        //    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 0, "");
                        //    ViewBag.ls_info = ls_info;
                        //    Session["registrationTax"] = "";
                        //    Session["on_VendorContact_ID"] = "";

                        //}
                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //public ActionResult Menu()
        //{
        //    ViewBag.lang = "Menu";
        //    {
        //        try
        //        {
        //            if (Session["all_us_role"] != null)
        //            {
        //                //gte role form session

        //                RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");
        //                Session["us_role"] = us_role;
        //                Session["roleCode"] = us_role.roleCode;

        //                List<VendorInfo> ls_info = new List<VendorInfo>();

        //                if (Session["Vendor_con"] != null && us_role.roleCode == "R001")
        //                {
        //                    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 2, ((VendorContact)Session["Vendor_con"]).id);
        //                    //return RedirectToAction("Detail", new { registrationTax = ls_info[0].registrationTax, VendorContact_ID = ls_info[0].VendorContact_ID });
        //                    ViewBag.ls_info = new List<VendorInfo>
        //                {
        //                    ls_info[0]
        //                };
        //                }
        //                else
        //                {
        //                    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 0, "");
        //                    ViewBag.ls_info = ls_info;
        //                }

        //                //ViewBag.ls_info = ls_info;

        //                return View();
        //            }
        //            else
        //            {
        //                return RedirectToAction("Start", "Vendor");
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //      //      LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "VendorController_Index");
        //             return RedirectToAction("Index", "Home");
        //        }
        //    }
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SeminarDetail()
        {
            var ls_sem = DataAccess.DataAccess.sp_Seminar_get("");

            ViewBag.ls_sem = ls_sem;

            var ls_hea = ls_sem.Select(s => new Seminar_Item { code = s.code, NameCode = s.NameCode, id = s.id, Name = s.Name, headerID = s.headerID, UoM = s.UoM }).DistinctBy(s => s.headerID).OrderBy(s => s.code).ThenBy(s => s.id).ToList();

            ViewBag.ls_hea = ls_hea;

            var ls_pack = ls_sem.Select(s => new Seminar_Item { packId = s.packId, namePack = s.namePack }).DistinctBy(s => s.packId).ToList();
            ViewBag.ls_pack = ls_pack;


            return View();
        }

        public ActionResult getSem(string ls_pack)
        {
            try
            {
                var ls = DataAccess.DataAccess.sp_Seminar_get(ls_pack);

                return Json(ls);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult getBantin()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    List<Bantininfo> lst = new List<Bantininfo>();
                    return Json(lst);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }

            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getBantin");
                return null;
            }
        }
    }
}