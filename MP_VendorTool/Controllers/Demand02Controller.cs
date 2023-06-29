using MP_VendorTool.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MP_VendorTool.Models.Vendor;
using MP_VendorTool.Models.OfferPrice;
using System.Data;
using MP_VendorTool.Common;

namespace MP_VendorTool.Controllers
{
    public class Demand02Controller : MyController
    {


        public ActionResult DubaoSLnhaphangD45()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                   
                      //  var list_vendor = DataAccess.DataAccess.sp_BBM_MP_Get_MD_Item_NCC_get();
                      //  ViewBag.list_vendor = list_vendor;
                        return View();
                }
                else
                {
                    SystemFunctions.SaveSession("OfferPrice", "Index");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DubaoSLnhaphangD45");
                return Json(null);
            }
        }

        public ActionResult getlist_dubaonhaphang(string Mancc)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                   
                        DataTable table = DataAccess.DataAccessDemand02.bbs_getlist_dubaonhaphang(Session["uid"].ToString(),Mancc);
                        return PartialView("~/Views/Demand02/Partial/__DubaoSLnhaphangD45.cshtml", table);
                }
                else
                {
                    SystemFunctions.SaveSession("Demand02", "DubaoSLnhaphangD45");
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getlist_dubaonhaphang");
                return Json(null);
            }
        }
        
        public ActionResult create_purchaseprice(string Mancc, string Mahang, string Tenhang, decimal Price, decimal VAT, decimal PriceVAT, decimal SLton, string DateSP)
        {
            try
            {
               
                    var item = DataAccess.DataAccessDemand02.bbs_create_purchaseprice_ncc(Session["uid"].ToString(), Mancc, Mahang, Tenhang, Price, VAT, PriceVAT, SLton, DateSP);
               
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "create_purchaseprice");
                return Json(new { code = 1, message = "" });
            }
        }





    }
}