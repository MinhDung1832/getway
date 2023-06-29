using MP_VendorTool.Common;
using MP_VendorTool.DataAccess;
using Newtonsoft.Json;
using ProductAllTool.DataAccess;
using ProductAllTool.Models.DeXuatGiaBan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProductAllTool.Controllers
{
    public class DeXuatGiaBanController : Controller
    {
        //private bool checkpermission(string action)
        //{
        //    List<permissioninfo> ls = (List<permissioninfo>)Session["permission"];
        //    if (ls.Where(x => x.controller == "DeXuatGiaBan" && x.action == action).Count() > 0)
        //        return true;
        //    else return false;
        //}

        // GET: DeXuatGiaBan
        public ActionResult DeXuat()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    //if (!checkpermission("DeXuat")) return RedirectToAction("Index", "Home");

                    var list_vendor = DataAccess.DataAccessGateway.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    var lstItem = DataAccess.DataAccessGateway.SP_getWay_Pro_ITEM_Vendor("");
                    ViewBag.List_Mahang = lstItem;

              
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("DeXuatGiaBan", "DeXuat");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DeXuat");
                return RedirectToAction("Menu", "Home");
            }
        }

        [HttpPost]
        public ActionResult SalesPrice_ThayDoiGiaAll(string MaHang)
        {
            try
            {
                var list = DataAccess.DataAccessPrice.SalesPrice_ThayDoiGiaAll(MaHang);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SalesPrice_ThayDoiGiaAll");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult GiaMua_DeXuatGiaBan(string MaHang, string Vendor)
        {
            try
            {
                var list = DataAccess.DataAccessPrice.GiaMua_DeXuatGiaBan(MaHang, Vendor);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GiaMua_DeXuatGiaBan");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult PTGPFunction_DeXuatGiaBan(string MaHang)
        {
            try
            {
                var list = DataAccess.DataAccessPrice.PTGPFunction_DeXuatGiaBan(MaHang);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PTGPFunction_DeXuatGiaBan");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult SP_DeXuqatGiaBan_Pro_ITEM_Vendor(string NCC)
        {
            try
            {
                var bn = DataAccess.DataAccessPrice.SP_DeXuqatGiaBan_Pro_ITEM_Vendor(NCC);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_DeXuqatGiaBan_Pro_ITEM_Vendor");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListBarcode(string itemNo)
        {
            try
            {
                var bn = DataAccess.DataAccessPrice.SP_TRADTERM_GET_BARCODE(itemNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_BARCODE");
                return Json(null);
            }
        }

        public ActionResult Create_DeXuatGiaBan(Obj_DeXuatGiaBan info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    bool rs = DataAccess.DataAccessPrice.SP_SAVE_DeXuatGiaBan(info, Session["uid"].ToString());
                    return Json(rs);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Create_OfferPrice");
                return null;
            }
        }

        [HttpPost]
        public ActionResult Get_List_DeXuatGiaBan(string NhaCC, string MaHang, string Status)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccessPrice.Get_List_DeXuatGiaBan(NhaCC, MaHang, Status, "");
                    return PartialView("~/Views/DeXuatGiaBan/Partial/__Index.cshtml", table);
                }
                else
                {
                    return RedirectToAction("Menu", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_OfferPrice");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Index()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list_vendor = DataAccess.DataAccessGateway.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    var lstItem = DataAccess.DataAccessGateway.SP_getWay_DeXuatGia("");
                    ViewBag.List_Mahang = lstItem;
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("DeXuatGiaBan", "Index");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DeXuatGiaBan");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Delete_DeXuatGiaBan(string[] ID)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    var item = DataAccess.DataAccessPrice.Delete_DeXuatGiaBan(ID[i].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_DeXuatGiaBan");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult Update_Status_DeXuatGiaBan(string[] ID, string HanhDong)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    var item = DataAccess.DataAccessPrice.Update_Status_DeXuatGiaBan(ID[i].ToString(), HanhDong);
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_DeXuatGiaBan");
                return Json(new { code = 1, message = "" });
            }
        }


        // ERP
        

        [HttpPost]
        public ActionResult Listget_DeXuatGiaBan_PopUp_BIBO(string ID)
        {
            try
            {
                var list = DataAccess.DataAccessPrice.Listget_DeXuatGiaBan_PopUp_BIBO(ID);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_DeXuatGiaBan_PopUp_BIBO");
                return Json(null);
            }
        }

        public ActionResult Update_DeXuatGiaBan(Obj_DeXuatGiaBan info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    bool rs = DataAccess.DataAccessPrice.SP_Update_DeXuatGiaBan(info);
                    return Json(rs);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_DeXuatGiaBan");
                return null;
            }
        }

        //async public Task<ActionResult> UploadFile(string foldername)
        //{
        //    try
        //    {
        //        var file = System.Web.HttpContext.Current.Request.Files["MyImages"];
        //        string linkres = await SystemFunctions.Upload_File_Direct("OfferPrice", file);
        //        if (linkres.Contains("media.bibomart.net"))
        //        {
        //            return Json(new { code = 1, link = linkres, showfie = "/image/iconpdf.png" });
        //        }
        //        else
        //            return Json(new { code = 0, link = linkres, showfie = "" });
        //    }
        //    catch (Exception ex)
        //    {
        //        DataAccess.LogBuild.CreateLogger(ex.ToString(), "OfferPrice");
        //        return Json(new { code = 0, link = ex.Message });
        //    }
        //}


    }

}