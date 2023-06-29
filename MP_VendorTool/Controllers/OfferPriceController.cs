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
using MP_VendorTool.Models.PriceSell;
using MP_VendorTool.Models.Order;

namespace MP_VendorTool.Controllers
{
    public class OfferPriceController : MyController
    {
        #region Index
        public ActionResult Index()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    //if (!Constants.checkpermission("OfferPrice", "Index")) return RedirectToAction("Index", "Home");

                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var lstItem = DataAccess.DataAccess.SP_getWay_DeXuatGia(Session["VendorCode"].ToString());
                        ViewBag.List_Mahang = lstItem;
                    }
                    else
                    {
                        var list_vendor = DataAccess.DataAccess.Get_List_OfferPrice_All_NCC();
                        ViewBag.list_vendor = list_vendor;

                        var lstItem = DataAccess.DataAccess.SP_getWay_DeXuatGia("");
                        ViewBag.List_Mahang = lstItem;
                    }
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "OfferPrice");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Get_List_OfferPrice(string NhaCC, string MaHang, string Status)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        System.Data.DataTable table = DataAccess.DataAccess.Get_List_OfferPrice(NhaCC, MaHang, Status, Session["VendorCode"].ToString());
                        return PartialView("~/Views/OfferPrice/Partial/__Index.cshtml", table);
                    }
                    else
                    {
                        System.Data.DataTable table = DataAccess.DataAccess.Get_List_OfferPrice(NhaCC, MaHang, Status, "");
                        return PartialView("~/Views/OfferPrice/Partial/__Index.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_OfferPrice");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Delete_OfferPrice(string[] ID)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    var item = DataAccess.DataAccess.Delete_OfferPrice(ID[i].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_OfferPrice");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult Update_Status_OfferPrice(string[] ID, string HanhDong)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    var item = DataAccess.DataAccess.Update_Status_OfferPrice(ID[i].ToString(), HanhDong);
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_OfferPrice");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult Update_GiaSauThayDoi_OfferPrice(string ID, string Price)
        {
            try
            {
                var item = DataAccess.DataAccess.Update_GiaSauThayDoi_OfferPrice(ID.ToString(), Price);
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_GiaSauThayDoi_OfferPrice");
                return Json(new { code = 1, message = "" });
            }
        }
        #endregion

        #region PriceOffer
        public ActionResult PriceOffer()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                   // if (!Constants.checkpermission("OfferPrice", "PriceOffer")) return RedirectToAction("Index", "Home");
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var lstItem = DataAccess.DataAccessKM.SP_getWay_Pro_ITEM_Vendor(Session["VendorCode"].ToString());
                        ViewBag.List_Mahang = lstItem;
                    }
                    else
                    {
                        var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor();
                        ViewBag.list_vendor = list_vendor;

                        var lstItem = DataAccess.DataAccessKM.SP_getWay_Pro_ITEM_Vendor("");
                        ViewBag.List_Mahang = lstItem;

                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("OfferPrice", "PriceOffer");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PriceOffer");
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Create_OfferPrice(Obj_PriceOffer info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    bool rs = DataAccess.DataAccess.SP_SAVE_OfferPrice(info, Session["uid"].ToString());
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

        public ActionResult Update_OfferPrice(Obj_PriceOffer info)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    bool rs = DataAccess.DataAccess.SP_Update_OfferPrice(info);
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


        //[HttpPost]
        //public ActionResult UploadFile()
        //{
        //    try
        //    {
        //        var file = System.Web.HttpContext.Current.Request.Files["MyImages"];
        //        string filename = Regex.Replace(Path.GetFileName(Server.MapPath(file.FileName)), @"[^0-9a-zA-Z:,.-]+", "");
        //        string str_dir = HttpContext.Server.MapPath("~/Images/") + DateTime.Now.ToString("yyyy") + @"\" + DateTime.Now.ToString("MM");
        //        if (!Directory.Exists(str_dir))
        //        {
        //            Directory.CreateDirectory(str_dir);
        //        }

        //        #region save raw
        //        string link = str_dir + @"/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_imp_" + filename;
        //        file.SaveAs(link);
        //        #endregion

        //        var matP = Regex.Split(link.Replace("\\", "/"), "Images");
        //        // return Json(new { code = 1, link = "/Images/" + matP[1] });
        //        return Json(new { code = 1, link = "/Images/" + matP[1], showfie = "/image/iconpdf.png" });
        //    }
        //    catch (Exception ex)
        //    {
        //        DataAccess.LogBuild.CreateLogger(ex.ToString(), "uploadImg");
        //        return Json(@"{""code"":""0"",""link"":""""}");
        //    }
        //}

        async public Task<ActionResult> UploadFile(string foldername)
        {
            try
            {
                var file = System.Web.HttpContext.Current.Request.Files["MyImages"];
                string linkres = await SystemFunctions.Upload_File_Direct("OfferPrice", file);
                if (linkres.Contains("media.bibomart.net"))
                {
                    return Json(new { code = 1, link = linkres, showfie = "/image/iconpdf.png" });
                }
                else
                    return Json(new { code = 0, link = linkres, showfie = "" });
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(ex.ToString(), "OfferPrice");
                return Json(new { code = 0, link = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult GetListBarcode(string itemNo)
        {
            try
            {
                var bn = DataAccess.DataAccess.SP_TRADTERM_GET_BARCODE(itemNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListBarcode");
                return Json(null);
            }
        }


        [HttpPost]
        public ActionResult GetList_NCC_Produts(string NCC)
        {
            try
            {
                var bn = DataAccess.DataAccessKM.SP_getWay_Pro_ITEM_Vendor(NCC);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListBarcode");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult get_NgayHieuLuc_ThoaThuanHD(string NCC)
        {
            try
            {
                var list = DataAccess.DataAccessKM.get_NgayHieuLuc_ThoaThuanHD(NCC);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "get_NgayHieuLuc_ThoaThuanHD");
                return Json(null);
            }
        }


        [HttpPost]
        public ActionResult SetNgay(string NgayThongBaoChinhThuc, string NgayHieuLuc_ThoaThuanHD)
        {
            try
            {
                if (NgayThongBaoChinhThuc.Length > 0)
                {
                    DateTime NgayHienTai = Convert.ToDateTime(NgayThongBaoChinhThuc.ToString());
                    TimeSpan duration = new TimeSpan(Convert.ToInt32(NgayHieuLuc_ThoaThuanHD), 0, 0, 0); //Adding 7 days from date today
                    DateTime result = NgayHienTai.Add(duration);
                    return Json(new { NgayCan = result.ToString("yyyy-MM-dd") });
                }
                return Json(new { NgayCan = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "get_NgayHieuLuc_ThoaThuanHD");
                return Json(null);
            }
        }


        [HttpPost]
        public ActionResult Get_Price_HopDongThoaThuan_DeXuatDoiGia(string VendorNo, string MaHang)
        {
            try
            {
                var bn = DataAccess.DataAccess.Get_Price_HopDongThoaThuan_DeXuatDoiGia(VendorNo, MaHang);
                return Json(bn);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_Price_HopDongThoaThuan_DeXuatDoiGia");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult Listget_PriceOffer_PopUp(string ID)
        {
            try
            {
                var list = DataAccess.DataAccess.Listget_PriceOffer_PopUp(ID);
                return Json(list);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_PriceOffer_PopUp");
                return Json(null);
            }
        }

        #endregion

        #region BinhOnGia_ThiTruong
        public ActionResult BinhOnGia()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    //if (!Constants.checkpermission("OfferPrice", "BinhOnGia")) return RedirectToAction("Index", "Home");

                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var list_vendor = DataAccess.DataAccess.SP_BinhOnGia_Vender(Session["VendorCode"].ToString());
                        ViewBag.list_vendor = list_vendor;
                    }
                    else
                    {
                        var list_vendor = DataAccess.DataAccess.SP_BinhOnGia_Vender("");
                        ViewBag.list_vendor = list_vendor;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("OfferPrice", "BinhOnGia");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "OfferPrice");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult GetList_NCC_Produts_BinhOnGia(string NCC)
        {
            try
            {
                var bn = DataAccess.DataAccess.SP_BinhOnGia_Vender_ITEM_Vendor(NCC);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BinhOnGia_Vender_ITEM_Vendor");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult Getway_BinhOnGia_ThiTruong(string NhaCC, string MaHang, string NgayCapNhat)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        System.Data.DataTable table = DataAccess.DataAccess.Getway_BinhOnGia_ThiTruong(Session["VendorCode"].ToString(), MaHang, NgayCapNhat);
                        return PartialView("~/Views/OfferPrice/Partial/__BinhOnGia.cshtml", table);
                    }
                    else
                    {
                        System.Data.DataTable table = DataAccess.DataAccess.Getway_BinhOnGia_ThiTruong(NhaCC, MaHang, NgayCapNhat);
                        return PartialView("~/Views/OfferPrice/Partial/__BinhOnGia.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_OfferPrice");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Add_BinhOnGia_ThiTruong_Vender_Item(List<BinhOnGia_ThiTruong> lst)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                foreach (BinhOnGia_ThiTruong po in lst)
                {
                    DataAccess.DataAccess.Add_BinhOnGia_ThiTruong_Vender_Item(Session["uid"].ToString(), po);
                }
                return Json(new { code = 1, message = "" });
            }
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region BinhOnGia_ThiTruong_ARP
        public ActionResult BinhOnGiaArp()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                   // if (!Constants.checkpermission("OfferPrice", "BinhOnGiaArp")) return RedirectToAction("Index", "Home");
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var list_vendor = DataAccess.DataAccess.SP_BinhOnGia_Vender(Session["VendorCode"].ToString());
                        ViewBag.list_vendor = list_vendor;
                    }
                    else
                    {
                        var list_vendor = DataAccess.DataAccess.SP_BinhOnGia_Vender("");
                        ViewBag.list_vendor = list_vendor;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("OfferPrice", "BinhOnGia");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "OfferPrice");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Getway_BinhOnGia_ThiTruong_Arp(string NhaCC, string MaHang, string NgayCapNhat, string TrangThai)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        System.Data.DataTable table = DataAccess.DataAccess.Getway_BinhOnGia_ThiTruong_Arp(Session["VendorCode"].ToString(), MaHang, NgayCapNhat, TrangThai);
                        return PartialView("~/Views/OfferPrice/Partial/__BinhOnGiaApr.cshtml", table);
                    }
                    else
                    {
                        System.Data.DataTable table = DataAccess.DataAccess.Getway_BinhOnGia_ThiTruong_Arp(NhaCC, MaHang, NgayCapNhat, TrangThai);
                        return PartialView("~/Views/OfferPrice/Partial/__BinhOnGiaApr.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_OfferPrice");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region PriceSell
        public async Task<ActionResult> PriceSell()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    //if (!Constants.checkpermission("OfferPrice", "PriceSell")) return RedirectToAction("Index", "Home");

                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var lst = await BaseApiClient.CallAsync_API<objCombox>("/api/PriceAll/PriceSell_Vender?VendorCode=" + Session["VendorCode"].ToString());
                        ViewBag.list_vendor = lst.Items;

                        //var list_vendor = DataAccess.DataAccessPriceSell.SP_PriceSell_Vender(Session["VendorCode"].ToString());
                        //ViewBag.list_vendor = list_vendor;
                    }
                    else
                    {
                        var lst = await BaseApiClient.CallAsync_API<objCombox>("/api/PriceAll/PriceSell_Vender");
                        ViewBag.list_vendor = lst.Items;

                        //  var list_vendor = DataAccess.DataAccessPriceSell.SP_PriceSell_Vender("");
                        //   ViewBag.list_vendor = list_vendor;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("OfferPrice", "PriceSell");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PriceSell");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> GetList_PriceSell(Obj_PriceSell it)
        {
            try
            {
                var request = new Obj_PriceSell()
                {
                    vendorNo = it.vendorNo,
                    MaHang = it.MaHang,
                    Barcode = it.Barcode,
                };

                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        request.vendorNo = Session["VendorCode"].ToString();
                        // System.Data.DataTable table = DataAccess.DataAccessPriceSell.SP_PriceSell_HHOA_KGUI(Session["VendorCode"].ToString(), MaHang, Barcode);
                        var table = await BaseApiClient.PostAsync_Param_API<Obj_PriceSell_GetAll, Obj_PriceSell>("/api/PriceAll/PriceSell_GetAll", request);
                        return PartialView("~/Views/OfferPrice/Partial/__PriceSell.cshtml", table.Items);
                    }
                    else
                    {
                        var table = await BaseApiClient.PostAsync_Param_API<Obj_PriceSell_GetAll, Obj_PriceSell>("/api/PriceAll/PriceSell_GetAll", request);
                        return PartialView("~/Views/OfferPrice/Partial/__PriceSell.cshtml", table.Items);

                        //System.Data.DataTable table = DataAccess.DataAccessPriceSell.SP_PriceSell_HHOA_KGUI(vendorNo, MaHang, Barcode);
                        //return PartialView("~/Views/OfferPrice/Partial/__PriceSell.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_PriceSell");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<ActionResult> GetListBarcode_PriceSell(string itemNo)
        {
            try
            {
                var bn = await BaseApiClient.CallAsync_API<objCombox>("/api/PriceAll/PriceSell_Barcode?itemNo=" + itemNo);
                // var bn = DataAccess.DataAccessPriceSell.SP_PriceSell_Vender_BARCODE(itemNo);
                return Json(JsonConvert.SerializeObject(bn.Items));
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListBarcode_PriceSell");
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetList_NCC_Produts_PriceSell(string VendorCode)
        {
            try
            {
                var bn = await BaseApiClient.CallAsync_API<objCombox>("/api/PriceAll/PriceSell_Produts?VendorCode=" + VendorCode);
                return Json(JsonConvert.SerializeObject(bn.Items));
                //var bn = DataAccess.DataAccessPriceSell.SP_PriceSell_Vender_ITEM_Vendor(VendorCode);
                //if (bn.Count > 0)
                //{
                //    return Json(JsonConvert.SerializeObject(bn));
                //}
                //else
                //{
                //    return Json(null);
                //}
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_NCC_Produts_PriceSell");
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Save_PriceSell_Vender_Item(List<PriceSell> lst)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                foreach (PriceSell po in lst)
                {
                    po.CreateBy = Session["uid"].ToString();
                    await BaseApiClient.PostAsync_API<PriceSell>("/api/PriceAll/Save_PriceSell", po);
                    //  DataAccess.DataAccessPriceSell.Save_PriceSell_Vender_Item(Session["uid"].ToString(), po);
                }
                return Json(new { code = 1, message = "" });
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region PriceSellAr
        public async Task<ActionResult> PriceSellAr()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    //if (!Constants.checkpermission("OfferPrice", "PriceSellAr")) return RedirectToAction("Index", "Home");

                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var lst = await BaseApiClient.CallAsync_API<objCombox>("/api/PriceAll/PriceSellAr_GetAll?VendorCode=" + Session["VendorCode"].ToString());
                        ViewBag.list_vendor = lst.Items;

                        //var list_vendor = DataAccess.DataAccessPriceSell.SP_PriceSell_Vender(Session["VendorCode"].ToString());
                        //ViewBag.list_vendor = list_vendor;
                    }
                    else
                    {
                        var lst = await BaseApiClient.CallAsync_API<objCombox>("/api/PriceAll/PriceSell_Vender");
                        ViewBag.list_vendor = lst.Items;

                        //  var list_vendor = DataAccess.DataAccessPriceSell.SP_PriceSell_Vender("");
                        //   ViewBag.list_vendor = list_vendor;
                    }
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("OfferPrice", "PriceSellAr");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PriceSellAr");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> GetList_PriceSellAr(Obj_PriceSellAr it)
        {
            try
            {
                var request = new Obj_PriceSellAr()
                {
                    vendorNo = it.vendorNo,
                    MaHang = it.MaHang,
                    Barcode = it.Barcode,
                    TrangThai = it.TrangThai,
                };

                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        request.vendorNo = Session["VendorCode"].ToString();
                        var table = await BaseApiClient.PostAsync_Param_API<Obj_PriceSell_GetAll_Ar, Obj_PriceSellAr>("/api/PriceAll/PriceSellAr_GetAll", request);
                        return PartialView("~/Views/OfferPrice/Partial/__PriceSellAr.cshtml", table.Items);

                        // System.Data.DataTable table = DataAccess.DataAccessPriceSell.SP_PriceSell_HHOA_KGUI_AR_Getwway(Session["VendorCode"].ToString(), MaHang, Barcode, TrangThai);
                        //  return PartialView("~/Views/OfferPrice/Partial/__PriceSellAr.cshtml", table);
                    }
                    else
                    {
                        var table = await BaseApiClient.PostAsync_Param_API<Obj_PriceSell_GetAll_Ar, Obj_PriceSellAr>("/api/PriceAll/PriceSellAr_GetAll", request);
                        return PartialView("~/Views/OfferPrice/Partial/__PriceSellAr.cshtml", table.Items);

                        //   System.Data.DataTable table = DataAccess.DataAccessPriceSell.SP_PriceSell_HHOA_KGUI_AR_Getwway(vendorNo, MaHang, Barcode, TrangThai);
                        //  return PartialView("~/Views/OfferPrice/Partial/__PriceSellAr.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_PriceSellAr");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        #endregion
    }
}