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
using System.Threading.Tasks;
using MP_VendorTool.Models.Newoffer;

namespace MP_VendorTool.Controllers
{
    public class NewofferController : MyController
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        public ActionResult Index()
        {
            var ls_country = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get("vi", "Country");
            ViewBag.ls_country = ls_country;

            var ls_divison = DataAccess.DataAccess.sp_BBM_MP_VendorTool_ProductType("Division", "");
            ViewBag.ls_divison = ls_divison;
            
            var ls_business = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "Business");
            ViewBag.ls_business = ls_business;

            var ls_industry = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "industry");
            ViewBag.ls_industry = ls_industry;

            var ls_bank = DataAccess.DataAccess.sp_BBM_MP_VendorTool_Type_get(Request.Cookies["culture"].Value, "Bank");
            ViewBag.ls_bank = ls_bank;

            return View();
        }

        [HttpPost]
        public ActionResult Newoffer_Save(InfoNewoffer info)
        {
            var err = new RouteInfo();
            try
            {
                var result = DataAccessNewoffer.InfoNewoffer_Save(info, "All");
                if (result)
                {
                    err.RespId = 0;
                    err.RespMsg = "Lưu thông tin thành công";
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

        [HttpPost]
        async public Task<ActionResult> uploadImg(string foldername)
        {
            try
            {
                var file = System.Web.HttpContext.Current.Request.Files["MyImages"];
                string linkres = await SystemFunctions.UploadIMGDirect(foldername, file);
                if (linkres.Contains("media.bibomart.net"))
                {
                    return Json(new { code = 1, link = linkres });
                }
                else
                    return Json(new { code = 0, link = linkres });
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(ex.ToString(), "uploadImgProduct");
                return Json(new { code = 0, link = ex.Message });
            }
        }
    }
}
