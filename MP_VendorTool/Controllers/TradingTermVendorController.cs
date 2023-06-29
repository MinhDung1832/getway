using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Account;
using MP_VendorTool.Models.Vendor;
using MP_VendorTool.Models.Order;
using Newtonsoft.Json;
using MP_VendorTool.Models.TradingTermVendor;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using MP_VendorTool.Common;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace MP_VendorTool.Controllers
{
    public class TradingTermVendorController : Controller
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        public ActionResult Index()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list_vendor = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    var list_NguonNhap = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor_NguonNhap();
                    ViewBag.list_NguonNhap = list_NguonNhap;

                    var list_VendorName = DataAccess.DataAccessTrading.SP_TRADTERM_GET_VendorName_Contract();
                    ViewBag.list_VendorName = list_VendorName;

                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var list_SoHD = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor_Contract_SoHD_VendorNo(Session["VendorCode"].ToString());
                        ViewBag.list_SoHD = list_SoHD;

                        var list_Contract = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor_Contract_VendorNo(Session["VendorCode"].ToString());
                        ViewBag.list_Contract = list_Contract;
                    }
                    else
                    {
                        var list_SoHD = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor_Contract_SoHD();
                        ViewBag.list_SoHD = list_SoHD;

                        var list_Contract = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor_Contract();
                        ViewBag.list_Contract = list_Contract;
                    }

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("TradingTermVendor", "Index");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Index");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult GetListContractNo(string ContractNo, string Status, string vendorNo, string NguonNhap, string LoaiHoptac, string SoHopDong)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccessTrading.sp_GetListContractNo_ACM(ContractNo, Status, vendorNo, NguonNhap, Session["uid"].ToString(), LoaiHoptac, SoHopDong);
                    return PartialView("~/Views/TradingTermVendor/Partial/__Index.cshtml", table);
                }
                else
                {
                    return RedirectToAction("", "");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListContractNo");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Create(string Type, string VendorNo)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Type != null && Type.ToString().Length > 0 && VendorNo != null && VendorNo.ToString().Length > 0)
                    {
                        ViewBag.Type = Type;
                        //  string[] ArrVendorNo = VendorNo.Split('-');

                        ViewBag.VendorNo = VendorNo;
                        ViewBag.VendorNo_Code = VendorNo;
                        var vendor = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor_detail(VendorNo);
                        if (vendor.Count > 0)
                        {
                            ViewBag.VendorNo_Name = vendor[0].Name;
                        }
                        ViewBag.TinhTrang = "Tạo mới";

                        //if (TinhTrang != "Ký mới")
                        //{
                        //    ViewBag.SoHopDong = "HĐ_" + ArrVendorNo[0] + "_" + DateTime.Now.ToString("ddMMyyyy");
                        //    var list_SoPhuLuc = DataAccess.DataAccessTrading.SP_TRADTERM_SoPhuLuc_Vendor(ArrVendorNo[0]);
                        //    ViewBag.SoPhuLuc = "HDNCC_" + ArrVendorNo[0] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_" + list_SoPhuLuc[0].Code.ToString().Trim();
                        //}
                        var list_ContractNo = DataAccess.DataAccessTrading.SP_TRADTERM_SoPhuLuc_Vendor(VendorNo);
                        ViewBag.ContractNo = "HDNCC_" + VendorNo + "_" + DateTime.Now.ToString("ddMMyyyy") + "_" + list_ContractNo[0].Code.ToString().Trim();

                        var list_ThongTinChungAD = DataAccess.DataAccessTrading.SP_TRADTERM_ThongTinChungTheKe_ApDung(VendorNo);
                        ViewBag.list_ThongTinChungAD = list_ThongTinChungAD;

                        var list_DanhMucSanPham_ThueKe_AD = DataAccess.DataAccessTrading.SP_TRADTERM_DanhMuCSanPham_ApDung(VendorNo);
                        ViewBag.list_DanhMucSanPham_ThueKe_AD = list_DanhMucSanPham_ThueKe_AD;
                    }
                    else
                    {
                        return RedirectToAction("Index", "TradingTermVendor");
                    }

                    var list_vendor = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    var list_typeBonus = DataAccess.DataAccessTrading.SP_TRADTERM_GET_TT_THUONG();
                    ViewBag.list_typeBonus = list_typeBonus;

                    var list_LoaiPo = DataAccess.DataAccessTrading.SP_TRADTERM_TT_LOAIPO();
                    ViewBag.list_LoaiPo = list_LoaiPo;

                    var list_ChiPhiBanHang = DataAccess.DataAccessTrading.SP_TRADTERM_TT_ChiPhiBanHang();
                    ViewBag.list_ChiPhiBanHang = list_ChiPhiBanHang;

                    var list_Thuong = DataAccess.DataAccessTrading.SP_MD_TT_Thuong();
                    ViewBag.list_Thuong = list_Thuong;

                    var list_phattrienKH = DataAccess.DataAccessTrading.SP_TRADTERM_TT_PhatTrienKhachHang();
                    ViewBag.list_phattrienKH = list_phattrienKH;

                    var list_phattrienTH = DataAccess.DataAccessTrading.SP_TRADTERM_TT_PhatTrienThuongHieu();
                    ViewBag.list_phattrienTH = list_phattrienTH;

                    var list_LoaiDonHang = DataAccess.DataAccessTrading.SP_TRADTERM_GET_LoaiDonHang();
                    ViewBag.list_LoaiDonHang = list_LoaiDonHang;

                    var list_KyThanhToan = DataAccess.DataAccessTrading.SP_TRADTERM_GET_KyThanhToan();
                    ViewBag.list_KyThanhToan = list_KyThanhToan;

                    var list_ApDung = DataAccess.DataAccessTrading.SP_TRADTERM_GET_ApDung();
                    ViewBag.list_ApDung = list_ApDung;

                    var list_CO_RE_GO = DataAccess.DataAccessTrading.SP_TRADTERM_GET_CONTENT_RETURNS_GOODS();
                    ViewBag.list_CO_RE_GO = list_CO_RE_GO;

                    var list_DoiTraHang = DataAccess.DataAccessTrading.SP_TRADTERM_DoiTra();
                    ViewBag.list_DoiTraHang = list_DoiTraHang;

                    var list_ChiPhiVanHanh = DataAccess.DataAccessTrading.get_ChiPhiVanHanh();
                    ViewBag.list_ChiPhiVanHanh = list_ChiPhiVanHanh;

                    var list_datalist_Mien = DataAccess.DataAccessTrading.sp_VendorTool_MD_Sub_get_tradingtem();
                    ViewBag.list_datalist_Mien = list_datalist_Mien;

                    var list_RangeReview = DataAccess.DataAccessTrading.SP_TRADTERM_SKU_RangeReview();
                    ViewBag.list_RangeReview = list_RangeReview;

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("TradingTermVendor", "Create");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Create");
                return RedirectToAction("", "");
            }
        }
        public ActionResult Detail(string id)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    Session["ChiPhiDauTu"] = "";

                    var list_vendor = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    var list_typeBonus = DataAccess.DataAccessTrading.SP_TRADTERM_GET_TT_THUONG();
                    ViewBag.list_typeBonus = list_typeBonus;

                    var list_LoaiPo = DataAccess.DataAccessTrading.SP_TRADTERM_TT_LOAIPO();
                    ViewBag.list_LoaiPo = list_LoaiPo;

                    var list_ChiPhiBanHang = DataAccess.DataAccessTrading.SP_TRADTERM_TT_ChiPhiBanHang();
                    ViewBag.list_ChiPhiBanHang = list_ChiPhiBanHang;

                    var list_Thuong = DataAccess.DataAccessTrading.SP_MD_TT_Thuong();
                    ViewBag.list_Thuong = list_Thuong;

                    var list_phattrienKH = DataAccess.DataAccessTrading.SP_TRADTERM_TT_PhatTrienKhachHang();
                    ViewBag.list_phattrienKH = list_phattrienKH;

                    var list_phattrienTH = DataAccess.DataAccessTrading.SP_TRADTERM_TT_PhatTrienThuongHieu();
                    ViewBag.list_phattrienTH = list_phattrienTH;

                    var list_LoaiDonHang = DataAccess.DataAccessTrading.SP_TRADTERM_GET_LoaiDonHang();
                    ViewBag.list_LoaiDonHang = list_LoaiDonHang;

                    var list_KyThanhToan = DataAccess.DataAccessTrading.SP_TRADTERM_GET_KyThanhToan();
                    ViewBag.list_KyThanhToan = list_KyThanhToan;

                    var list_ApDung = DataAccess.DataAccessTrading.SP_TRADTERM_GET_ApDung();
                    ViewBag.list_ApDung = list_ApDung;

                    var list_CO_RE_GO = DataAccess.DataAccessTrading.SP_TRADTERM_GET_CONTENT_RETURNS_GOODS();
                    ViewBag.list_CO_RE_GO = list_CO_RE_GO;

                    var list_RangeReview = DataAccess.DataAccessTrading.SP_TRADTERM_SKU_RangeReview();
                    ViewBag.list_RangeReview = list_RangeReview;

                    var list_contract = DataAccess.DataAccessTrading.SP_TRADTERM_CONTRACT_DETAIL(id);
                    ViewBag.VendorNo = list_contract[0].VendorNo;
                    ViewBag.VendorName = list_contract[0].VendorName;
                    ViewBag.ContractNo = list_contract[0].ContractNo;
                    ViewBag.FromDate = list_contract[0].FromDate;
                    ViewBag.ToDate = list_contract[0].ToDate;
                    ViewBag.ContractStatus = list_contract[0].Status;
                    ViewBag.IDContractNo = list_contract[0].IDContractNo;
                    ViewBag.Type = list_contract[0].Type;
                    ViewBag.TrangThaiDuyet = list_contract[0].TrangThaiDuyet;

                    ViewBag.AutoExtentContract = list_contract[0].AutoExtentContract;
                    ViewBag.ACM = list_contract[0].ACM;
                    ViewBag.CM = list_contract[0].CM;
                    ViewBag.SupplyManager = list_contract[0].SupplyManager;
                    ViewBag.priceChangeDate = list_contract[0].priceChangeDate;
                    ViewBag.ID = list_contract[0].ID;

                    ViewBag.TuNgay = list_contract[0].TuNgay;
                    ViewBag.DenNgay = list_contract[0].DenNgay;
                    ViewBag.SoHopDong = list_contract[0].SoHopDong;

                    //
                    ViewBag.TinhTrang = list_contract[0].TinhTrangHD;
                    ViewBag.NguoiDaiDienBBM = list_contract[0].NguoiDaiDienBBM;
                    ViewBag.NguoiDaiDienNCC = list_contract[0].NguoiDaiDienNCC;
                    ViewBag.AutoExtentContractSoHopDong = list_contract[0].AutoExtentContractSoHopDong;
                    ViewBag.SoPhuLuc = list_contract[0].SoPhuLuc;

                    ViewBag.DaiDienBBM = list_contract[0].DaiDienBBM;
                    ViewBag.DaiDienNCC = list_contract[0].DaiDienNCC;

                    if (list_contract[0].FileSoHopDong.Length > 0)
                    {
                        ViewBag.TaiFile01 = "<a id=\"Link\" href=\"" + list_contract[0].FileSoHopDong + "\" style=\"color: #fff;width: 100%;margin: 17px 4px;font-size: 12px;background: #c4c4c4 !important;padding: 6px 42px 6px 36px;\" target=\"_blank\">Tải File FDF</a>";
                    }
                    if (list_contract[0].FilePhuLucHopDong.Length > 0)
                    {
                        ViewBag.TaiFile02 = "<a id=\"Link\" href=\"" + list_contract[0].FilePhuLucHopDong + "\" style=\"color: #fff;width: 100%;margin: 17px 4px;font-size: 12px;background: #c4c4c4 !important;padding: 6px 42px 6px 36px;\" target=\"_blank\">Tải File FDF</a>";
                    }

                    var IDContractNo = list_contract[0].IDContractNo;
                    // var NoHD = list_contract[0].ContractNo;
                    var list_product = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_VENDORS_PRODUCT(IDContractNo);
                    if (list_contract[0].Type == "HHOA")
                    {
                        ViewBag.list_product = list_product.Where(s => s.TypeTab == "1").ToList();
                    }
                    else if (list_contract[0].Type == "KGUI")
                    {
                        ViewBag.list_product = list_product.Where(s => s.TypeTab == "2").ToList();
                    }
                    else
                    {
                        ViewBag.list_product = null;
                    }

                    var list_line_bonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_LINE_BONUS(IDContractNo);
                    ViewBag.list_line_bonus = list_line_bonus;

                    var list_mkt_bonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_MKT_BONUS(IDContractNo);
                    ViewBag.list_mkt_bonus = list_mkt_bonus;

                    var list_cusBonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_CUSTOMER_BONUS(IDContractNo);
                    ViewBag.list_cusBonus = list_cusBonus;

                    var list_app_reproduct = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_APPLY_RETURN_PRODUCT(IDContractNo);
                    ViewBag.list_app_reproduct = list_app_reproduct;

                    var list_brandBonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_BRAND_BONUS(IDContractNo);
                    ViewBag.list_brandBonus = list_brandBonus;

                    var list_coo_other = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_COOPERATION_OTHER(IDContractNo);
                    ViewBag.list_coo_other = list_coo_other;

                    var list_dis_Qtty = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_DISCOUNT_QTTY(IDContractNo);
                    ViewBag.list_dis_Qtty = list_dis_Qtty;

                    var list_dis_sales = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_DISCOUNT_SALES(IDContractNo);
                    ViewBag.list_dis_sales = list_dis_sales;

                    var list_payment = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_PAYMENT(IDContractNo);
                    ViewBag.list_payment = list_payment;

                    var list_Leadtime = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_LeadTime_View(IDContractNo, "");
                    ViewBag.list_Leadtime = list_Leadtime;

                    var list_ChiPhiVanChuyen = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_CHIPHIVANHANH(IDContractNo, "");
                    ViewBag.list_ChiPhiVanChuyen = list_ChiPhiVanChuyen;

                    var list_Rent_product = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_RENT_PRODUCT(IDContractNo);
                    ViewBag.list_Rent_product = list_Rent_product;

                    // News

                    var list_product_Function = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_VENDORS_PRODUCT_FUNCTION(IDContractNo);
                    ViewBag.list_product_Function = list_product_Function;

                    var list_product_Brand = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_VENDORS_PRODUCT_BRAND(IDContractNo);
                    ViewBag.list_product_Brand = list_product_Brand;

                    var list_Brand_product_ThueKe = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_BRAND_PRODUCT_THUEKE(IDContractNo);
                    ViewBag.list_Brand_product_ThueKe = list_Brand_product_ThueKe;

                    var list_Function_product_ThueKe = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_FUNCTION_PRODUCT_THUEKE(IDContractNo);
                    ViewBag.list_Function_product_ThueKe = list_Function_product_ThueKe;

                    var list_ThongTinChung_ThueKe = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_THUEKE_THONGTINCHUNG(IDContractNo);
                    ViewBag.list_ThongTinChung_ThueKe = list_ThongTinChung_ThueKe;

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TradingTermVendorController_Index");
                return RedirectToAction("", "");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Edit(string id)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list_vendor = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    var list_typeBonus = DataAccess.DataAccessTrading.SP_TRADTERM_GET_TT_THUONG();
                    ViewBag.list_typeBonus = list_typeBonus;

                    var list_LoaiPo = DataAccess.DataAccessTrading.SP_TRADTERM_TT_LOAIPO();
                    ViewBag.list_LoaiPo = list_LoaiPo;

                    var list_ChiPhiBanHang = DataAccess.DataAccessTrading.SP_TRADTERM_TT_ChiPhiBanHang();
                    ViewBag.list_ChiPhiBanHang = list_ChiPhiBanHang;

                    var list_Thuong = DataAccess.DataAccessTrading.SP_MD_TT_Thuong();
                    ViewBag.list_Thuong = list_Thuong;

                    var list_phattrienKH = DataAccess.DataAccessTrading.SP_TRADTERM_TT_PhatTrienKhachHang();
                    ViewBag.list_phattrienKH = list_phattrienKH;

                    var list_phattrienTH = DataAccess.DataAccessTrading.SP_TRADTERM_TT_PhatTrienThuongHieu();
                    ViewBag.list_phattrienTH = list_phattrienTH;

                    var list_LoaiDonHang = DataAccess.DataAccessTrading.SP_TRADTERM_GET_LoaiDonHang();
                    ViewBag.list_LoaiDonHang = list_LoaiDonHang;

                    var list_KyThanhToan = DataAccess.DataAccessTrading.SP_TRADTERM_GET_KyThanhToan();
                    ViewBag.list_KyThanhToan = list_KyThanhToan;

                    var list_ApDung = DataAccess.DataAccessTrading.SP_TRADTERM_GET_ApDung();
                    ViewBag.list_ApDung = list_ApDung;

                    var list_CO_RE_GO = DataAccess.DataAccessTrading.SP_TRADTERM_GET_CONTENT_RETURNS_GOODS();
                    ViewBag.list_CO_RE_GO = list_CO_RE_GO;

                    var list_RangeReview = DataAccess.DataAccessTrading.SP_TRADTERM_SKU_RangeReview();
                    ViewBag.list_RangeReview = list_RangeReview;

                    if (Session["ChiPhiDauTu"] != null)
                    {
                        ViewBag.ChiPhiDauTu = Session["ChiPhiDauTu"].ToString();
                    }

                    var list_contract = DataAccess.DataAccessTrading.SP_TRADTERM_CONTRACT_DETAIL(id);
                    ViewBag.VendorNo = list_contract[0].VendorNo;
                    ViewBag.VendorName = list_contract[0].VendorName;
                    ViewBag.ContractNo = list_contract[0].ContractNo;
                    ViewBag.FromDate = list_contract[0].FromDate;
                    ViewBag.ToDate = list_contract[0].ToDate;
                    ViewBag.AutoExtentContract = list_contract[0].AutoExtentContract;
                    ViewBag.ACM = list_contract[0].ACM;
                    ViewBag.CM = list_contract[0].CM;
                    ViewBag.SupplyManager = list_contract[0].SupplyManager;
                    ViewBag.priceChangeDate = list_contract[0].priceChangeDate;
                    ViewBag.ContractStatus = list_contract[0].Status;

                    ViewBag.IDContractNo = list_contract[0].IDContractNo;
                    ViewBag.Type = list_contract[0].Type;
                    ViewBag.TrangThaiDuyet = list_contract[0].TrangThaiDuyet;

                    ViewBag.TuNgay = list_contract[0].TuNgay;
                    ViewBag.DenNgay = list_contract[0].DenNgay;
                    ViewBag.SoHopDong = list_contract[0].SoHopDong;

                    //
                    ViewBag.TinhTrang = list_contract[0].TinhTrangHD;
                    ViewBag.NguoiDaiDienBBM = list_contract[0].NguoiDaiDienBBM;
                    ViewBag.NguoiDaiDienNCC = list_contract[0].NguoiDaiDienNCC;
                    ViewBag.AutoExtentContractSoHopDong = list_contract[0].AutoExtentContractSoHopDong;
                    ViewBag.SoPhuLuc = list_contract[0].SoPhuLuc;

                    ViewBag.DaiDienBBM = list_contract[0].DaiDienBBM;
                    ViewBag.DaiDienNCC = list_contract[0].DaiDienNCC;


                    if (list_contract[0].FileSoHopDong.Length > 0)
                    {
                        ViewBag.TaiFile01 = "<a id=\"Link\" href=\"" + list_contract[0].FileSoHopDong + "\" style=\"color: #fff;width: 100%;margin: 17px 4px;font-size: 12px;background: #c4c4c4 !important;padding: 6px 42px 6px 36px;\" target=\"_blank\">Tải File FDF</a>";
                    }
                    if (list_contract[0].FilePhuLucHopDong.Length > 0)
                    {
                        ViewBag.TaiFile02 = "<a id=\"Link\" href=\"" + list_contract[0].FilePhuLucHopDong + "\" style=\"color: #fff;width: 100%;margin: 17px 4px;font-size: 12px;background: #c4c4c4 !important;padding: 6px 42px 6px 36px;\" target=\"_blank\">Tải File FDF</a>";
                    }

                    var IDContractNo = list_contract[0].IDContractNo;
                    // var NoHD = list_contract[0].ContractNo;
                    var list_product = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_VENDORS_PRODUCT(IDContractNo);
                    ViewBag.list_product = list_product;

                    var list_line_bonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_LINE_BONUS(IDContractNo);
                    ViewBag.list_line_bonus = list_line_bonus;

                    var list_mkt_bonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_MKT_BONUS(IDContractNo);
                    ViewBag.list_mkt_bonus = list_mkt_bonus;

                    var list_cusBonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_CUSTOMER_BONUS(IDContractNo);
                    ViewBag.list_cusBonus = list_cusBonus;

                    var list_app_reproduct = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_APPLY_RETURN_PRODUCT(IDContractNo);
                    ViewBag.list_app_reproduct = list_app_reproduct;

                    var list_brandBonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_BRAND_BONUS(IDContractNo);
                    ViewBag.list_brandBonus = list_brandBonus;

                    var list_coo_otherMB = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_COOPERATION_OTHER_View(IDContractNo, "1");
                    ViewBag.list_coo_otherMB = list_coo_otherMB;

                    var list_coo_otherKG = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_COOPERATION_OTHER_View(IDContractNo, "2");
                    ViewBag.list_coo_otherKG = list_coo_otherKG;

                    var list_coo_otherTK = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_COOPERATION_OTHER_View(IDContractNo, "3");
                    ViewBag.list_coo_otherTK = list_coo_otherTK;

                    var list_dis_Qtty = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_DISCOUNT_QTTY(IDContractNo);
                    ViewBag.list_dis_Qtty = list_dis_Qtty;

                    var list_dis_sales = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_DISCOUNT_SALES(IDContractNo);
                    ViewBag.list_dis_sales = list_dis_sales;

                    var list_payment = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_PAYMENT(IDContractNo);
                    ViewBag.list_payment = list_payment;

                    var list_Leadtime = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_LeadTime_View(IDContractNo, "");
                    ViewBag.list_Leadtime = list_Leadtime;

                    var list_ChiPhiVanChuyen = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_CHIPHIVANHANH(IDContractNo, "");
                    ViewBag.list_ChiPhiVanChuyen = list_ChiPhiVanChuyen;

                    var list_Rent_product = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_RENT_PRODUCT(IDContractNo);
                    ViewBag.list_Rent_product = list_Rent_product;

                    var list_product_Function = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_VENDORS_PRODUCT_FUNCTION(IDContractNo);
                    ViewBag.list_product_Function = list_product_Function;

                    var list_product_Brand = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_VENDORS_PRODUCT_BRAND(IDContractNo);
                    ViewBag.list_product_Brand = list_product_Brand;

                    var list_Brand_product_ThueKe = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_BRAND_PRODUCT_THUEKE(IDContractNo);
                    ViewBag.list_Brand_product_ThueKe = list_Brand_product_ThueKe;

                    var list_Function_product_ThueKe = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_FUNCTION_PRODUCT_THUEKE(IDContractNo);
                    ViewBag.list_Function_product_ThueKe = list_Function_product_ThueKe;

                    var list_ThongTinChung_ThueKe = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_THUEKE_THONGTINCHUNG(IDContractNo);
                    ViewBag.list_ThongTinChung_ThueKe = list_ThongTinChung_ThueKe;

                    var list_DoiTraHang = DataAccess.DataAccessTrading.SP_TRADTERM_DoiTra();
                    ViewBag.list_DoiTraHang = list_DoiTraHang;

                    var list_ChiPhiVanHanh = DataAccess.DataAccessTrading.get_ChiPhiVanHanh();
                    ViewBag.list_ChiPhiVanHanh = list_ChiPhiVanHanh;

                    var list_datalist_Mien = DataAccess.DataAccessTrading.sp_VendorTool_MD_Sub_get_tradingtem();
                    ViewBag.list_datalist_Mien = list_datalist_Mien;

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TradingTermVendorController_Edit");
                return RedirectToAction("", "");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Copy(string id)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {

                    var list_vendor = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    var list_typeBonus = DataAccess.DataAccessTrading.SP_TRADTERM_GET_TT_THUONG();
                    ViewBag.list_typeBonus = list_typeBonus;

                    var list_LoaiPo = DataAccess.DataAccessTrading.SP_TRADTERM_TT_LOAIPO();
                    ViewBag.list_LoaiPo = list_LoaiPo;

                    var list_ChiPhiBanHang = DataAccess.DataAccessTrading.SP_TRADTERM_TT_ChiPhiBanHang();
                    ViewBag.list_ChiPhiBanHang = list_ChiPhiBanHang;

                    var list_Thuong = DataAccess.DataAccessTrading.SP_MD_TT_Thuong();
                    ViewBag.list_Thuong = list_Thuong;

                    var list_phattrienKH = DataAccess.DataAccessTrading.SP_TRADTERM_TT_PhatTrienKhachHang();
                    ViewBag.list_phattrienKH = list_phattrienKH;

                    var list_phattrienTH = DataAccess.DataAccessTrading.SP_TRADTERM_TT_PhatTrienThuongHieu();
                    ViewBag.list_phattrienTH = list_phattrienTH;

                    var list_LoaiDonHang = DataAccess.DataAccessTrading.SP_TRADTERM_GET_LoaiDonHang();
                    ViewBag.list_LoaiDonHang = list_LoaiDonHang;

                    var list_KyThanhToan = DataAccess.DataAccessTrading.SP_TRADTERM_GET_KyThanhToan();
                    ViewBag.list_KyThanhToan = list_KyThanhToan;

                    var list_ApDung = DataAccess.DataAccessTrading.SP_TRADTERM_GET_ApDung();
                    ViewBag.list_ApDung = list_ApDung;

                    var list_CO_RE_GO = DataAccess.DataAccessTrading.SP_TRADTERM_GET_CONTENT_RETURNS_GOODS();
                    ViewBag.list_CO_RE_GO = list_CO_RE_GO;

                    var list_RangeReview = DataAccess.DataAccessTrading.SP_TRADTERM_SKU_RangeReview();
                    ViewBag.list_RangeReview = list_RangeReview;

                    if (Session["ChiPhiDauTu"] != null)
                    {
                        ViewBag.ChiPhiDauTu = Session["ChiPhiDauTu"].ToString();
                    }

                    var list_contract = DataAccess.DataAccessTrading.SP_TRADTERM_CONTRACT_DETAIL(id);

                    var list_ContractNo = DataAccess.DataAccessTrading.SP_TRADTERM_SoPhuLuc_Vendor(list_contract[0].VendorNo);
                    ViewBag.ContractNo = "HDNCC_" + list_contract[0].VendorNo + "_" + DateTime.Now.ToString("ddMMyyyy") + "_" + list_ContractNo[0].Code.ToString().Trim();

                    var list_ThongTinChungAD = DataAccess.DataAccessTrading.SP_TRADTERM_ThongTinChungTheKe_ApDung(list_contract[0].VendorNo);
                    ViewBag.list_ThongTinChungAD = list_ThongTinChungAD;

                    var list_DanhMucSanPham_ThueKe_AD = DataAccess.DataAccessTrading.SP_TRADTERM_DanhMuCSanPham_ApDung(list_contract[0].VendorNo);
                    ViewBag.list_DanhMucSanPham_ThueKe_AD = list_DanhMucSanPham_ThueKe_AD;

                    ViewBag.TinhTrang = "Tạo mới";


                    ViewBag.VendorNo = list_contract[0].VendorNo;
                    ViewBag.VendorName = list_contract[0].VendorName;
                    // ViewBag.ContractNo = list_contract[0].ContractNo;
                    ViewBag.FromDate = list_contract[0].FromDate;
                    ViewBag.ToDate = list_contract[0].ToDate;
                    ViewBag.AutoExtentContract = list_contract[0].AutoExtentContract;
                    ViewBag.ACM = list_contract[0].ACM;
                    ViewBag.CM = list_contract[0].CM;
                    ViewBag.SupplyManager = list_contract[0].SupplyManager;
                    ViewBag.priceChangeDate = list_contract[0].priceChangeDate;
                    ViewBag.ContractStatus = list_contract[0].Status;

                    ViewBag.IDContractNo = list_contract[0].IDContractNo;
                    ViewBag.Type = list_contract[0].Type;
                    ViewBag.TrangThaiDuyet = list_contract[0].TrangThaiDuyet;

                    ViewBag.TuNgay = list_contract[0].TuNgay;
                    ViewBag.DenNgay = list_contract[0].DenNgay;
                    ViewBag.SoHopDong = list_contract[0].SoHopDong;

                    //

                    ViewBag.NguoiDaiDienBBM = list_contract[0].NguoiDaiDienBBM;
                    ViewBag.NguoiDaiDienNCC = list_contract[0].NguoiDaiDienNCC;
                    ViewBag.AutoExtentContractSoHopDong = list_contract[0].AutoExtentContractSoHopDong;
                    ViewBag.SoPhuLuc = list_contract[0].SoPhuLuc;
                    ViewBag.DaiDienBBM = list_contract[0].DaiDienBBM;
                    ViewBag.DaiDienNCC = list_contract[0].DaiDienNCC;




                    if (list_contract[0].FileSoHopDong.Length > 0)
                    {
                        ViewBag.TaiFile01 = "<a id=\"Link\" href=\"" + list_contract[0].FileSoHopDong + "\" style=\"color: #fff;width: 100%;margin: 17px 4px;font-size: 12px;background: #c4c4c4 !important;padding: 6px 42px 6px 36px;\" target=\"_blank\">Tải File FDF</a>";
                    }
                    if (list_contract[0].FilePhuLucHopDong.Length > 0)
                    {
                        ViewBag.TaiFile02 = "<a id=\"Link\" href=\"" + list_contract[0].FilePhuLucHopDong + "\" style=\"color: #fff;width: 100%;margin: 17px 4px;font-size: 12px;background: #c4c4c4 !important;padding: 6px 42px 6px 36px;\" target=\"_blank\">Tải File FDF</a>";
                    }

                    var IDContractNo = list_contract[0].IDContractNo;
                    // var NoHD = list_contract[0].ContractNo;
                    var list_product = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_VENDORS_PRODUCT(IDContractNo);
                    ViewBag.list_product = list_product;

                    var list_line_bonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_LINE_BONUS(IDContractNo);
                    ViewBag.list_line_bonus = list_line_bonus;

                    var list_mkt_bonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_MKT_BONUS(IDContractNo);
                    ViewBag.list_mkt_bonus = list_mkt_bonus;

                    var list_cusBonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_CUSTOMER_BONUS(IDContractNo);
                    ViewBag.list_cusBonus = list_cusBonus;

                    var list_app_reproduct = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_APPLY_RETURN_PRODUCT(IDContractNo);
                    ViewBag.list_app_reproduct = list_app_reproduct;

                    var list_brandBonus = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_BRAND_BONUS(IDContractNo);
                    ViewBag.list_brandBonus = list_brandBonus;

                    var list_coo_otherMB = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_COOPERATION_OTHER_View(IDContractNo, "1");
                    ViewBag.list_coo_otherMB = list_coo_otherMB;

                    var list_coo_otherKG = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_COOPERATION_OTHER_View(IDContractNo, "2");
                    ViewBag.list_coo_otherKG = list_coo_otherKG;

                    var list_coo_otherTK = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_COOPERATION_OTHER_View(IDContractNo, "3");
                    ViewBag.list_coo_otherTK = list_coo_otherTK;

                    var list_dis_Qtty = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_DISCOUNT_QTTY(IDContractNo);
                    ViewBag.list_dis_Qtty = list_dis_Qtty;

                    var list_dis_sales = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_DISCOUNT_SALES(IDContractNo);
                    ViewBag.list_dis_sales = list_dis_sales;

                    var list_payment = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_PAYMENT(IDContractNo);
                    ViewBag.list_payment = list_payment;

                    var list_Leadtime = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_LeadTime_View(IDContractNo, "");
                    ViewBag.list_Leadtime = list_Leadtime;

                    var list_ChiPhiVanChuyen = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_CHIPHIVANHANH(IDContractNo, "");
                    ViewBag.list_ChiPhiVanChuyen = list_ChiPhiVanChuyen;

                    var list_Rent_product = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_RENT_PRODUCT(IDContractNo);
                    ViewBag.list_Rent_product = list_Rent_product;

                    var list_product_Function = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_VENDORS_PRODUCT_FUNCTION(IDContractNo);
                    ViewBag.list_product_Function = list_product_Function;

                    var list_product_Brand = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_VENDORS_PRODUCT_BRAND(IDContractNo);
                    ViewBag.list_product_Brand = list_product_Brand;

                    var list_Brand_product_ThueKe = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_BRAND_PRODUCT_THUEKE(IDContractNo);
                    ViewBag.list_Brand_product_ThueKe = list_Brand_product_ThueKe;

                    var list_Function_product_ThueKe = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_FUNCTION_PRODUCT_THUEKE(IDContractNo);
                    ViewBag.list_Function_product_ThueKe = list_Function_product_ThueKe;

                    var list_ThongTinChung_ThueKe = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_THUEKE_THONGTINCHUNG(IDContractNo);
                    ViewBag.list_ThongTinChung_ThueKe = list_ThongTinChung_ThueKe;

                    var list_DoiTraHang = DataAccess.DataAccessTrading.SP_TRADTERM_DoiTra();
                    ViewBag.list_DoiTraHang = list_DoiTraHang;

                    var list_ChiPhiVanHanh = DataAccess.DataAccessTrading.get_ChiPhiVanHanh();
                    ViewBag.list_ChiPhiVanHanh = list_ChiPhiVanHanh;

                    var list_datalist_Mien = DataAccess.DataAccessTrading.sp_VendorTool_MD_Sub_get_tradingtem();
                    ViewBag.list_datalist_Mien = list_datalist_Mien;

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "TradingTermVendorController_Edit");
                return RedirectToAction("", "");
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult BONUS_View(string id, string KieuTab)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_LINE_BONUS_View(id, KieuTab);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult DoiTraHang_View(string id, string KieuTab)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_DoiTraHang_View(id, KieuTab);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult LeadTime_View(string id, string KieuTab)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_LeadTime_View(id, KieuTab);
                if (list != null)
                {
                    return Json(list);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult ThanhToan(string id, string KieuTab)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var list_payment = DataAccess.DataAccessTrading.SP_TRADTERM_LIST_PAYMENT_View(id, KieuTab);
                if (list_payment != null)
                {
                    return Json(list_payment);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult DuyetDamPhanTradingTerm(string vendorNo)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (vendorNo != null && vendorNo.ToString().Length > 0)
                    {
                        Session["vendorNo"] = vendorNo;
                    }
                    else
                    {
                        Session["vendorNo"] = "";
                    }
                    var list_vendor = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("TradingTermVendor", "DuyetDamPhanTradingTerm");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DuyetDamPhanTradingTerm");
                return RedirectToAction("", "");
            }
        }
        public ActionResult TradingTerm(string ContractNo, string Status, string vendorNo, string NgayHieuLuc)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["vendorNo"] != null && Session["vendorNo"].ToString().Length > 0)
                    {
                        DataTable table = DataAccess.DataAccessTrading.sp_GetList_TRADING_TERM_Duyet(ContractNo, Status, Session["vendorNo"].ToString(), NgayHieuLuc);
                        return PartialView("~/Views/TradingTermVendor/Partial/__TradingTerm.cshtml", table);
                    }
                    else
                    {
                        DataTable table = DataAccess.DataAccessTrading.sp_GetList_TRADING_TERM_Duyet(ContractNo, Status, vendorNo, NgayHieuLuc);
                        return PartialView("~/Views/TradingTermVendor/Partial/__TradingTerm.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DuyetDamPhanTradingTerm");
                return RedirectToAction("", "");
            }

        }

        [HttpPost]
        public ActionResult PostStatusTradingTerm(string[] ID, string status)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    var item = DataAccess.DataAccessTrading.SP_Status_Trading_Term_UPDATE(ID[i].ToString(), status);
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PostStatusTradingTerm");
                return Json(new { code = 1, message = "" });
            }
        }
        [HttpPost]
        public ActionResult Update_Status_TradingTermVendor_Chang02(string[] ID, string status)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    var item = DataAccess.DataAccessTrading.Update_Status_TradingTermVendor_Chang02(ID[i].ToString(), status, Session["uid"].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_TradingTermVendor_Chang02");
                return Json(new { code = 1, message = "" });
            }
        }
        [HttpPost]
        public ActionResult Update_Status_TradingTermVendor_Chang_Duyet(string[] ID, string status)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    var item = DataAccess.DataAccessTrading.Update_Status_TradingTermVendor_Chang_Duyet(ID[i].ToString(), status, Session["uid"].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_TradingTermVendor_Chang_Duyet");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult GetListCoopInfoVendors(string vendorNo)
        {
            try
            {
                var item = DataAccess.DataAccessTrading.SP_TRADTERM_GET_COOP_INFO_VENDOR(vendorNo);
                if (item.Count > 0)
                {
                    return Json(JsonConvert.SerializeObject(item));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListCoopInfoVendors");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListBarcode(string itemNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.SP_TRADTERM_GET_BARCODE(itemNo);
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
        public ActionResult GetListItemVendor(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.SP_TRADTERM_GETLIST_ITEM(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_HangHoa_KyGui(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.SP_TRADTERM_GETLIST_ITEM_HangHoa_KyGui(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_HangHoa_KyGui");
                return Json(null);
            }
        }

        //[HttpPost]
        //public ActionResult SP_TRADTERM_ApDungSp_HHOA_TK_KGUI(string vendorNo, string Type)
        //{
        //    try
        //    {
        //        var bn = DataAccess.DataAccessTrading.SP_TRADTERM_ApDungSp_HHOA_TK_KGUI(vendorNo, Type);
        //        if (bn.Count > 0)
        //        {
        //            return Json(JsonConvert.SerializeObject(bn));
        //        }
        //        else
        //        {
        //            return Json(null);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_HangHoa");
        //        return Json(null);
        //    }
        //}

        [HttpPost]
        public ActionResult GetListItemVendor_HangHoa_ThueKe(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_HangHoa_ThueKe(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_HangHoa_ThueKe");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult GetListItemVendor_KyGui(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_KyGui(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_KyGui");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Function_ThueKe(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Function_ThueKe(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function_ThueKe");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Function(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Function(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Function_Create(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Function_Create(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function_Create");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Function_KyGui_Create(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Function_KyGui_Create(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function_KyGui_Create");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Function_KyGui(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Function_KyGui(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function_KyGui");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Brand(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Brand(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Brand");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Brand_ThueKe(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Brand_ThueKe(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Brand_ThueKe");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Brand_KyGui(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Brand_KyGui(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Brand_KyGui");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Brand_KyGui_Create(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Brand_KyGui_Create(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Brand_KyGui_Create");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Brand_ThueKe_Create(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Brand_ThueKe_Create(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Brand_ThueKe_Create");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult GetListItemVendor_Product_ThueKe_Create(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Product_ThueKe_Create(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Product_ThueKe_Create");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_Function_ThueKe_Create(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_Function_ThueKe_Create(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_Function_ThueKe_Create");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetListItemVendor_MuaBan_Brand_Create(string vendorNo)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.GetListItemVendor_MuaBan_Brand_Create(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListItemVendor_MuaBan_Brand_Create");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult UpdatePostTradeRequest(ObjTradeRequest obj)
        {

            var err = new RouteInfo();
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var itemsContract = JArray.Parse(obj.SourceContract);
                    var itemsCoopInfoVendors = JArray.Parse(obj.SourceCoopInfoVendors);
                    var itemsHangHoa = JArray.Parse(obj.SourceHangHoa);

                    //  var itemsHangHoa_Function = JArray.Parse(obj.SourceHangHoaFunction);
                    // var itemsHangHoa_Brand = JArray.Parse(obj.SourceHangHoaBrand);

                    var itemsChietKhau = JArray.Parse(obj.SourceChietKhau);
                    var itemsHangTang = JArray.Parse(obj.SourceHangTang);
                    var itemsBonus = JArray.Parse(obj.SourceBonus);
                    var itemsTrade = JArray.Parse(obj.SourceTrade);

                    var itemsThuongHieu = JArray.Parse(obj.SourceThuongHieu);
                    var itemsCustomer = JArray.Parse(obj.SourceCustomer);
                    var itemsDoiTra = JArray.Parse(obj.SourceDoiTra);
                    var itemsThanhToan = JArray.Parse(obj.SourceThanhToan);
                    var itemsHopTacKhac = JArray.Parse(obj.SourceHopTacKhac);
                    var VendorNo = itemsContract[0]["VendorNo"].ToString();

                    var itemsLeaderTime = JArray.Parse(obj.SourceLeaderTime);
                    var itemsChiPhiVanHanh = JArray.Parse(obj.SourceChiPhiVanHanh);
                    var itemsHangThueKe = JArray.Parse(obj.SourceHangThueKe);

                    var itemsThueKeBrand = JArray.Parse(obj.SourceThueKeBrand);
                    var itemsThueKeFunction = JArray.Parse(obj.SourceThueKeFunction);

                    var itemsThongTinChung = JArray.Parse(obj.SourceThongTinChung);

                    if (itemsContract.Count > 0)
                    {
                        var result = DataAccess.DataAccessTrading.SP_TRADTERM_UPDATE_CONTRACT(
                            itemsContract[0]["IDContractNo"].ToString()
                            , itemsContract[0]["ACM"].ToString()
                            , itemsContract[0]["CM"].ToString()
                            , itemsContract[0]["SupplyManager"].ToString()
                            , itemsContract[0]["priceChangeDate"].ToString()
                            , Session["uid"].ToString()
                            , itemsContract[0]["FromDate"].ToString()
                            , itemsContract[0]["ToDate"].ToString()
                            , itemsContract[0]["TuNgay"].ToString()
                            , itemsContract[0]["DenNgay"].ToString()
                        );

                        if (result)
                        {
                            var result2 = DataAccess.DataAccessTrading.SP_TRADTERM_DELETE_UPDATE(
                                  itemsContract[0]["IDContractNo"].ToString()
                            );
                            if (result2)
                            {
                                if (itemsHangHoa.Count() > 0)
                                {
                                    foreach (var itemHH in itemsHangHoa)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_VENDORS_PRODUCT(
                                            itemsContract[0]["IDContractNo"].ToString(),
                                            itemsContract[0]["ContractNo"].ToString()
                                            , itemsContract[0]["VendorNo"].ToString()
                                            , itemHH["codeProduct"].ToString()
                                            , itemHH["nameProduct"].ToString()
                                            , itemHH["barcode"].ToString()
                                            , itemHH["hinhthucht"].ToString()
                                            , itemHH["vat"].ToString()
                                            , itemHH["discountPrice"].ToString()
                                            , itemHH["percentDiscount"].ToString()
                                            , itemHH["priceAfterDiscount"].ToString()
                                            , Session["uid"].ToString()
                                            , itemHH["typeTab"].ToString()
                                            , itemHH["TinhTrang"].ToString()
                                            , itemHH["RangeReviewCode"].ToString()
                                            , itemHH["RangeReviewName"].ToString()
                                            , itemHH["ThuongDinhHuong"].ToString()
                                       );
                                    }
                                }

                                //if (itemsHangHoa_Function.Count() > 0)
                                //{
                                //    foreach (var itemHH in itemsHangHoa_Function)
                                //    {
                                //        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_VENDORS_PRODUCT_FUNCTION(
                                //              itemsContract[0]["IDContractNo"].ToString(),
                                //            itemsContract[0]["ContractNo"].ToString()
                                //           , itemsContract[0]["VendorNo"].ToString()
                                //           , itemHH["FunctionCode"].ToString()
                                //           , itemHH["FunctionName"].ToString()
                                //           , itemHH["hinhthucht"].ToString()
                                //           , itemHH["vat"].ToString()
                                //           , itemHH["discountPrice"].ToString()
                                //           , Session["uid"].ToString()
                                //           , itemHH["typeTab"].ToString()
                                //       );
                                //    }
                                //}

                                //if (itemsHangHoa_Brand.Count() > 0)
                                //{
                                //    foreach (var itemHH in itemsHangHoa_Brand)
                                //    {
                                //        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_VENDORS_PRODUCT_BRAND(
                                //              itemsContract[0]["IDContractNo"].ToString(),
                                //            itemsContract[0]["ContractNo"].ToString()
                                //           , itemsContract[0]["VendorNo"].ToString()
                                //           , itemHH["BrandCode"].ToString()
                                //           , itemHH["BrandName"].ToString()
                                //           , itemHH["hinhthucht"].ToString()
                                //           , itemHH["vat"].ToString()
                                //           , itemHH["discountPrice"].ToString()
                                //           , Session["uid"].ToString()
                                //           , itemHH["typeTab"].ToString()
                                //       );
                                //    }
                                //}


                                if (itemsChietKhau.Count() > 0)
                                {
                                    foreach (var itemCK in itemsChietKhau)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_DISCOUNT_SALES(
                                            itemsContract[0]["IDContractNo"].ToString(),
                                            itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemCK["typeDiscount"].ToString()
                                           , itemCK["HinhThucThanhToan"].ToString()
                                           , itemCK["discountAmount"].ToString()
                                           , itemCK["percentDiscount"].ToString()
                                           , itemCK["OrderValue"].ToString()
                                           , Session["uid"].ToString()
                                           , itemCK["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsHangTang.Count() > 0)
                                {
                                    foreach (var itemHT in itemsHangTang)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_DISCOUNT_QTTY(
                                            itemsContract[0]["IDContractNo"].ToString(),
                                            itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemHT["quantityBuy"].ToString()
                                           , itemHT["orderQuantity"].ToString()
                                           , Session["uid"].ToString()
                                           , itemHT["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsBonus.Count() > 0)
                                {
                                    foreach (var itemBonus in itemsBonus)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_LINE_BONUS(
                                             itemsContract[0]["IDContractNo"].ToString(),
                                             itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemBonus["bonusType"].ToString()
                                           , itemBonus["salesLevel"].ToString()
                                           , itemBonus["salesLevelDen"].ToString()
                                           , itemBonus["salesConditions"].ToString()
                                           , itemBonus["discountPercent"].ToString()
                                           , itemBonus["DiscountAmountNoVAT"].ToString()
                                           , itemBonus["description"].ToString()
                                           , itemBonus["DKDSTinhThuong"].ToString()
                                           , Session["uid"].ToString()
                                           , itemBonus["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsTrade.Count() > 0)
                                {
                                    foreach (var itemTrade in itemsTrade)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_MKT_BONUS(
                                             itemsContract[0]["IDContractNo"].ToString(),
                                             itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemTrade["mktbonus_content_invest"].ToString()
                                           , itemTrade["mktbonus_percent_invest"].ToString()
                                           , itemTrade["mktbonus_invest_value"].ToString()
                                           , itemTrade["mktbonus_des"].ToString()
                                            , itemTrade["salesConditions"].ToString()
                                           , Session["uid"].ToString()
                                           , itemTrade["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsCustomer.Count() > 0)
                                {
                                    foreach (var itemCustomer in itemsCustomer)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_CUSTOMER_BONUS(
                                             itemsContract[0]["IDContractNo"].ToString(),
                                             itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemCustomer["cusbonus_content_invest"].ToString()
                                           , itemCustomer["cusbonus_percent_invest"].ToString()
                                           , itemCustomer["cusbonus_invest_value"].ToString()
                                           , itemCustomer["cusbonus_percent_des"].ToString()
                                           , itemCustomer["salesConditions"].ToString()
                                           , Session["uid"].ToString()
                                           , itemCustomer["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsThuongHieu.Count() > 0)
                                {
                                    foreach (var itemThuongHieu in itemsThuongHieu)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_BRAND_BONUS(
                                             itemsContract[0]["IDContractNo"].ToString(),
                                             itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemThuongHieu["brandbonus_content_invest"].ToString()
                                           , itemThuongHieu["brandbonus_percent_invest"].ToString()
                                           , itemThuongHieu["brandbonus_invest_value"].ToString()
                                           , itemThuongHieu["brandbonus_des"].ToString()
                                           , itemThuongHieu["salesConditions"].ToString()
                                           , Session["uid"].ToString()
                                           , itemThuongHieu["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsDoiTra.Count() > 0)
                                {
                                    foreach (var itemDoiTra in itemsDoiTra)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_APPLY_RETURN_PRODUCT(
                                             itemsContract[0]["IDContractNo"].ToString(),
                                             itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemDoiTra["Satus"].ToString()
                                           , itemDoiTra["refundTerm"].ToString()
                                           , itemDoiTra["Penalty"].ToString()
                                           , itemDoiTra["confirmChange"].ToString()
                                            , itemDoiTra["Conten"].ToString()
                                           , itemDoiTra["BaoTruocNgay"].ToString()
                                           , Session["uid"].ToString()
                                           , itemDoiTra["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsThanhToan.Count() > 0)
                                {
                                    foreach (var itemThanhToan in itemsThanhToan)
                                    {

                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_PAYMENT(
                                             itemsContract[0]["IDContractNo"].ToString(),
                                             itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemThanhToan["typeOrder"].ToString()
                                           , itemThanhToan["paymentPeriod"].ToString()
                                           , itemThanhToan["onDay"].ToString()
                                           , itemThanhToan["andDay"].ToString()
                                           , itemThanhToan["applyFor"].ToString()
                                           , itemThanhToan["Content"].ToString()
                                           , Session["uid"].ToString()
                                           , itemThanhToan["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsHopTacKhac.Count() > 0)
                                {
                                    foreach (var itemHopTacKhac in itemsHopTacKhac)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_COOPERATION_OTHER(
                                             itemsContract[0]["IDContractNo"].ToString(),
                                             itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemHopTacKhac["content1"].ToString()
                                           , itemHopTacKhac["content2"].ToString()
                                           , itemHopTacKhac["content3"].ToString()
                                           , Session["uid"].ToString()
                                           , itemHopTacKhac["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsLeaderTime.Count() > 0)
                                {
                                    foreach (var itemLeaderTime in itemsLeaderTime)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_LEADTIME(
                                             itemsContract[0]["IDContractNo"].ToString(),
                                             itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemLeaderTime["Leadtimesx"].ToString()
                                           , itemLeaderTime["ThoiGianKyHD"].ToString()
                                           , itemLeaderTime["ThanhToan"].ToString()
                                           , itemLeaderTime["DongCongVaHQXuat"].ToString()
                                           , itemLeaderTime["DiBien"].ToString()
                                           , itemLeaderTime["ThuTucHQDauNhap"].ToString()
                                           , itemLeaderTime["TongLeadtime"].ToString()
                                           , Session["uid"].ToString()
                                           , itemLeaderTime["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsChiPhiVanHanh.Count() > 0)
                                {
                                    foreach (var itemChiPhiVanHanh in itemsChiPhiVanHanh)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_CHIPHIVANHANH(
                                             itemsContract[0]["IDContractNo"].ToString(),
                                             itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemChiPhiVanHanh["NoiDungDauTu"].ToString()
                                           , itemChiPhiVanHanh["PTDauTu"].ToString()
                                           , itemChiPhiVanHanh["GiaTriDauTu"].ToString()
                                           , itemChiPhiVanHanh["DieuKien"].ToString()
                                            , itemChiPhiVanHanh["salesConditions"].ToString()
                                           , Session["uid"].ToString()
                                           , itemChiPhiVanHanh["typeTab"].ToString()
                                        );
                                    }
                                }

                                if (itemsHangThueKe.Count() > 0)
                                {
                                    foreach (var itemHangThueKe in itemsHangThueKe)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_RENT_PRODUCT(
                                            itemsContract[0]["IDContractNo"].ToString(),
                                            itemsContract[0]["ContractNo"].ToString()
                                           , itemsContract[0]["VendorNo"].ToString()
                                           , itemHangThueKe["codeProduct"].ToString()
                                           , itemHangThueKe["nameProduct"].ToString()
                                           , itemHangThueKe["barcode"].ToString()

                                           , itemHangThueKe["M2netSP"].ToString()
                                           , itemHangThueKe["M2FGrossSP"].ToString()

                                           , itemHangThueKe["CoatingShop"].ToString()
                                           , itemHangThueKe["NumberFace"].ToString()
                                           , itemHangThueKe["Mien"].ToString()

                                           , itemHangThueKe["NgayBatDau"].ToString()
                                           , itemHangThueKe["NgayKetThuc"].ToString()

                                            , itemHangThueKe["NgaybatDauThue"].ToString()
                                            , itemHangThueKe["NgayDieuChinhKetThuc"].ToString()
                                           , itemHangThueKe["TuDongGiaHan"].ToString()

                                           , itemHangThueKe["HieuLuc"].ToString()
                                           , Session["uid"].ToString()
                                        );
                                    }
                                }

                                if (itemsThueKeBrand.Count() > 0)
                                {
                                    foreach (var itemHangThueKe in itemsThueKeBrand)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_BRAND_THUEKE_PRODUCT(
                                            itemsContract[0]["IDContractNo"].ToString(),
                                            itemsContract[0]["ContractNo"].ToString()
                                            , itemsContract[0]["VendorNo"].ToString()
                                            , itemHangThueKe["codeProduct"].ToString()
                                            , itemHangThueKe["nameProduct"].ToString()

                                            , itemHangThueKe["SoCuaHangThue"].ToString()
                                            , itemHangThueKe["SoThang"].ToString()
                                            , itemHangThueKe["M2FThueCuaHang"].ToString()

                                            , itemHangThueKe["ChiPhiThueThangVAT"].ToString()
                                            , itemHangThueKe["TongChiPhiThueThangVAT"].ToString()
                                            , itemHangThueKe["TongChiPhiThueNam"].ToString()
                                            , itemHangThueKe["DSCamKetCuaHang"].ToString()

                                            , itemHangThueKe["NgayKyHD"].ToString()
                                            , itemHangThueKe["NgayHetHanHD"].ToString()
                                            , itemHangThueKe["NgaybatDauThue"].ToString()
                                            , itemHangThueKe["NgayDieuChinhKetThuc"].ToString()

                                            , itemHangThueKe["checkTuDongGiaHan"].ToString()

                                            , itemHangThueKe["HieuLuc"].ToString()
                                            , Session["uid"].ToString()
                                        );
                                    }
                                }


                                if (itemsThueKeFunction.Count() > 0)
                                {
                                    foreach (var itemHangThueKe in itemsThueKeFunction)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_FUNCTION_THUEKE_PRODUCT(
                                            itemsContract[0]["IDContractNo"].ToString(),
                                            itemsContract[0]["ContractNo"].ToString()
                                            , itemsContract[0]["VendorNo"].ToString()
                                            , itemHangThueKe["codeProduct"].ToString()
                                            , itemHangThueKe["nameProduct"].ToString()
                                            , itemHangThueKe["barcode"].ToString()
                                            , itemHangThueKe["M2netSP"].ToString()
                                            , itemHangThueKe["M2FGrossSP"].ToString()
                                            , itemHangThueKe["CoatingShop"].ToString()
                                            , itemHangThueKe["NumberFace"].ToString()
                                            , itemHangThueKe["NgayBatDau"].ToString()
                                            , itemHangThueKe["NgayKetThuc"].ToString()
                                            , itemHangThueKe["HieuLuc"].ToString()
                                            , Session["uid"].ToString()
                                        );
                                    }
                                }


                                if (itemsThongTinChung.Count() > 0)
                                {
                                    foreach (var itemTTChung in itemsThongTinChung)
                                    {
                                        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_THUEKE_THONGTINCHUNG(
                                        itemsContract[0]["IDContractNo"].ToString(),
                                        itemsContract[0]["ContractNo"].ToString()
                                        , itemsContract[0]["VendorNo"].ToString()
                                        , itemTTChung["SoCuaHangThue"].ToString()
                                        , itemTTChung["SoThang"].ToString()
                                        , itemTTChung["M2FThueCuaHang"].ToString()

                                        , itemTTChung["ChiPhiThueThangVAT"].ToString()
                                        , itemTTChung["TongChiPhiThueThangVAT"].ToString()
                                        , itemTTChung["TongChiPhiThueNam"].ToString()
                                        , itemTTChung["DSCamKetCuaHang"].ToString()

                                        , itemTTChung["Mien"].ToString()
                                        , itemTTChung["NgayKyHD"].ToString()
                                        , itemTTChung["NgayHetHanHD"].ToString()
                                        , itemTTChung["NgaybatDauThue"].ToString()
                                        , itemTTChung["NgayDieuChinhKetThuc"].ToString()

                                        , itemTTChung["checkTuDongGiaHan"].ToString()
                                        , itemTTChung["HieuLuc"].ToString()
                                        , Session["uid"].ToString()
                                        );
                                    }
                                }


                                err.RespId = 0;
                                err.RespMsg = "Chỉnh sửa thông tin thành công";
                            }
                        }
                        else
                        {
                            err.RespId = -1;
                            err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại";
                        }
                    }
                }
                return Json(err);
            }
            catch (Exception ex)
            {
                err.RespId = -1;
                err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại" + ex;
            }
            Session["ChiPhiDauTu"] = "";

            return Json(err);
        }

        [HttpPost]
        public ActionResult PostTradeRequest(ObjTradeRequest obj)
        {
            var err = new RouteInfo();
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var itemsContract = JArray.Parse(obj.SourceContract);
                    var itemsCoopInfoVendors = JArray.Parse(obj.SourceCoopInfoVendors);
                    var itemsHangHoa = JArray.Parse(obj.SourceHangHoa);

                    //var itemsHangHoa_Function = JArray.Parse(obj.SourceHangHoaFunction);
                    //var itemsHangHoa_Brand = JArray.Parse(obj.SourceHangHoaBrand);

                    var itemsChietKhau = JArray.Parse(obj.SourceChietKhau);
                    var itemsHangTang = JArray.Parse(obj.SourceHangTang);
                    var itemsBonus = JArray.Parse(obj.SourceBonus);
                    var itemsTrade = JArray.Parse(obj.SourceTrade);

                    var itemsThuongHieu = JArray.Parse(obj.SourceThuongHieu);
                    var itemsCustomer = JArray.Parse(obj.SourceCustomer);
                    var itemsDoiTra = JArray.Parse(obj.SourceDoiTra);
                    var itemsThanhToan = JArray.Parse(obj.SourceThanhToan);
                    var itemsHopTacKhac = JArray.Parse(obj.SourceHopTacKhac);

                    var VendorNo = itemsContract[0]["VendorNo"].ToString();

                    var itemsLeaderTime = JArray.Parse(obj.SourceLeaderTime);
                    var itemsChiPhiVanHanh = JArray.Parse(obj.SourceChiPhiVanHanh);
                    var itemsHangThueKe = JArray.Parse(obj.SourceHangThueKe);

                    var itemsThueKeBrand = JArray.Parse(obj.SourceThueKeBrand);
                    var itemsThueKeFunction = JArray.Parse(obj.SourceThueKeFunction);

                    var itemsThongTinChung = JArray.Parse(obj.SourceThongTinChung);

                    if (itemsContract.Count > 0)
                    {
                        //var cmd_2 = $"SELECT COUNT(1) FROM [TBL_TRADTERM_CONTRACT] WHERE [ContractNo] = N'{itemsContract[0]["ContractNo"].ToString()}'";
                        //var ret_2 = SqlHelper.ExecuteScalar(strConn, CommandType.Text, cmd_2).ToInt(0).Value;
                        using (var con = new SqlConnection(strConn))
                        {
                            con.Open();
                            var select = $"SELECT COUNT(1) FROM [TBL_TRADTERM_CONTRACT] WHERE [ContractNo] = N'{itemsContract[0]["ContractNo"].ToString()}'";
                            SqlCommand cmd = new SqlCommand(select, con);
                            var item = cmd.ExecuteScalar();
                            if (item.ToString() != "0")
                            {
                                err.RespId = -1;
                                err.RespMsg = $"Số hợp đồng <b>{ itemsContract[0]["ContractNo"].ToString()}</b> đã có trong hệ thống, Vui lòng nhập mã hợp đồng khác";
                                return Json(err);
                            }
                            con.Close();
                        }

                        var result = DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_CONTRACT(
                             itemsContract[0]["VendorNo"].ToString()
                            , itemsContract[0]["ContractNo"].ToString()
                            , itemsContract[0]["FromDate"].ToString()
                            , itemsContract[0]["ToDate"].ToString()
                            , itemsContract[0]["ACM"].ToString()
                            , itemsContract[0]["CM"].ToString()
                            , itemsContract[0]["SupplyManager"].ToString()
                            , itemsContract[0]["AutoExtentContract"].ToString()
                            , itemsContract[0]["AutoExtentContractSoHopDong"].ToString()
                            , itemsContract[0]["priceChangeDate"].ToString()
                            , Session["uid"].ToString()
                            , itemsContract[0]["Type"].ToString()
                            , itemsContract[0]["SoPhuLuc"].ToString()
                            , itemsContract[0]["SoHopDong"].ToString()
                            , itemsContract[0]["TuNgay"].ToString()
                            , itemsContract[0]["DenNgay"].ToString()
                            , itemsContract[0]["FileSoHopDong"].ToString()
                            , itemsContract[0]["FilePhuLucHopDong"].ToString()
                            , itemsContract[0]["NguoiDaiDienBBM"].ToString()
                            , itemsContract[0]["NguoiDaiDienNCC"].ToString()
                            , itemsContract[0]["TinhTrang"].ToString()
                            , itemsContract[0]["DaiDienBBM"].ToString()
                            , itemsContract[0]["DaiDienNCC"].ToString()
                        );

                        if (result)
                        {
                            string IDContractNo = "";
                            // Lấy ra ID để cho vào các bảng phụ
                            var bn = DataAccess.DataAccessTrading.Get_ID_TRADTERM_CONTRACT_ContractNo(itemsContract[0]["VendorNo"].ToString(), itemsContract[0]["ContractNo"].ToString());
                            if (bn.Count > 0)
                            {
                                IDContractNo = bn[0].Code;
                            }

                            if (itemsHangHoa.Count() > 0)
                            {
                                foreach (var itemHH in itemsHangHoa)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_VENDORS_PRODUCT(
                                        IDContractNo.ToString()
                                        , itemsContract[0]["ContractNo"].ToString()
                                        , itemsContract[0]["VendorNo"].ToString()
                                        , itemHH["codeProduct"].ToString()
                                        , itemHH["nameProduct"].ToString()
                                        , itemHH["barcode"].ToString()
                                        , itemHH["hinhthucht"].ToString()
                                        , itemHH["vat"].ToString()
                                        , itemHH["discountPrice"].ToString()
                                        , itemHH["percentDiscount"].ToString()
                                        , itemHH["priceAfterDiscount"].ToString()
                                        , Session["uid"].ToString()
                                        , itemHH["typeTab"].ToString()
                                        , itemHH["TinhTrang"].ToString()
                                        , itemHH["RangeReviewCode"].ToString()
                                        , itemHH["RangeReviewName"].ToString()
                                        , itemHH["ThuongDinhHuong"].ToString()
                                   );
                                }
                            }

                            //if (itemsHangHoa_Function.Count() > 0)
                            //{
                            //    foreach (var itemHH in itemsHangHoa_Function)
                            //    {
                            //        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_VENDORS_PRODUCT_FUNCTION(
                            //             IDContractNo.ToString()
                            //           , itemsContract[0]["ContractNo"].ToString()
                            //           , itemsContract[0]["VendorNo"].ToString()
                            //           , itemHH["FunctionCode"].ToString()
                            //           , itemHH["FunctionName"].ToString()
                            //           , itemHH["hinhthucht"].ToString()
                            //           , itemHH["vat"].ToString()
                            //           , itemHH["discountPrice"].ToString()
                            //           , Session["uid"].ToString()
                            //           , itemHH["typeTab"].ToString()
                            //       );
                            //    }
                            //}

                            //if (itemsHangHoa_Brand.Count() > 0)
                            //{
                            //    foreach (var itemHH in itemsHangHoa_Brand)
                            //    {
                            //        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_VENDORS_PRODUCT_BRAND(
                            //             IDContractNo.ToString()
                            //            , itemsContract[0]["ContractNo"].ToString()
                            //           , itemsContract[0]["VendorNo"].ToString()
                            //           , itemHH["BrandCode"].ToString()
                            //           , itemHH["BrandName"].ToString()
                            //           , itemHH["hinhthucht"].ToString()
                            //           , itemHH["vat"].ToString()
                            //           , itemHH["discountPrice"].ToString()
                            //           , Session["uid"].ToString()
                            //           , itemHH["typeTab"].ToString()
                            //       );
                            //    }
                            //}
                            if (itemsChietKhau.Count() > 0)
                            {
                                foreach (var itemCK in itemsChietKhau)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_DISCOUNT_SALES(
                                          IDContractNo.ToString()
                                        , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemCK["typeDiscount"].ToString()
                                       , itemCK["HinhThucThanhToan"].ToString()
                                       , itemCK["discountAmount"].ToString()
                                       , itemCK["percentDiscount"].ToString()
                                        , itemCK["OrderValue"].ToString()
                                       , Session["uid"].ToString()
                                       , itemCK["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsHangTang.Count() > 0)
                            {
                                foreach (var itemHT in itemsHangTang)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_DISCOUNT_QTTY(
                                          IDContractNo.ToString()
                                        , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemHT["quantityBuy"].ToString()
                                       , itemHT["orderQuantity"].ToString()
                                       , Session["uid"].ToString()
                                       , itemHT["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsBonus.Count() > 0)
                            {
                                foreach (var itemBonus in itemsBonus)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_LINE_BONUS(
                                        IDContractNo.ToString()
                                       , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemBonus["bonusType"].ToString()
                                       , itemBonus["salesLevel"].ToString()
                                       , itemBonus["salesLevelDen"].ToString()
                                       , itemBonus["salesConditions"].ToString()
                                       , itemBonus["discountPercent"].ToString()
                                       , itemBonus["DiscountAmountNoVAT"].ToString()
                                       , itemBonus["description"].ToString()
                                       , itemBonus["DKDSTinhThuong"].ToString()
                                       , Session["uid"].ToString()
                                       , itemBonus["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsTrade.Count() > 0)
                            {
                                foreach (var itemTrade in itemsTrade)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_MKT_BONUS(
                                         IDContractNo.ToString()
                                       , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemTrade["mktbonus_content_invest"].ToString()
                                       , itemTrade["mktbonus_percent_invest"].ToString()
                                       , itemTrade["mktbonus_invest_value"].ToString()
                                       , itemTrade["mktbonus_des"].ToString()
                                        , itemTrade["salesConditions"].ToString()
                                       , Session["uid"].ToString()
                                       , itemTrade["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsCustomer.Count() > 0)
                            {
                                foreach (var itemCustomer in itemsCustomer)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_CUSTOMER_BONUS(
                                         IDContractNo.ToString()
                                        , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemCustomer["cusbonus_content_invest"].ToString()
                                       , itemCustomer["cusbonus_percent_invest"].ToString()
                                       , itemCustomer["cusbonus_invest_value"].ToString()
                                       , itemCustomer["cusbonus_percent_des"].ToString()
                                        , itemCustomer["salesConditions"].ToString()
                                       , Session["uid"].ToString()
                                       , itemCustomer["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsThuongHieu.Count() > 0)
                            {
                                foreach (var itemThuongHieu in itemsThuongHieu)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_BRAND_BONUS(
                                          IDContractNo.ToString()
                                          , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemThuongHieu["brandbonus_content_invest"].ToString()
                                       , itemThuongHieu["brandbonus_percent_invest"].ToString()
                                       , itemThuongHieu["brandbonus_invest_value"].ToString()
                                       , itemThuongHieu["brandbonus_des"].ToString()
                                       , itemThuongHieu["salesConditions"].ToString()
                                       , Session["uid"].ToString()
                                       , itemThuongHieu["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsDoiTra.Count() > 0)
                            {
                                foreach (var itemDoiTra in itemsDoiTra)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_APPLY_RETURN_PRODUCT(
                                         IDContractNo.ToString()
                                         , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                        , itemDoiTra["Satus"].ToString()
                                       , itemDoiTra["refundTerm"].ToString()
                                       , itemDoiTra["Penalty"].ToString()
                                       , itemDoiTra["confirmChange"].ToString()
                                       , itemDoiTra["Conten"].ToString()
                                        , itemDoiTra["BaoTruocNgay"].ToString()
                                       , Session["uid"].ToString()
                                       , itemDoiTra["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsThanhToan.Count() > 0)
                            {
                                foreach (var itemThanhToan in itemsThanhToan)
                                {

                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_PAYMENT(
                                          IDContractNo.ToString(),
                                          itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemThanhToan["typeOrder"].ToString()
                                       , itemThanhToan["paymentPeriod"].ToString()
                                       , itemThanhToan["onDay"].ToString()
                                       , itemThanhToan["andDay"].ToString()
                                       , itemThanhToan["applyFor"].ToString()
                                       , itemThanhToan["Content"].ToString()
                                       , Session["uid"].ToString()
                                       , itemThanhToan["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsHopTacKhac.Count() > 0)
                            {
                                foreach (var itemHopTacKhac in itemsHopTacKhac)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_COOPERATION_OTHER(
                                          IDContractNo.ToString(),
                                         itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemHopTacKhac["content1"].ToString()
                                       , itemHopTacKhac["content2"].ToString()
                                       , itemHopTacKhac["content3"].ToString()
                                       , Session["uid"].ToString()
                                       , itemHopTacKhac["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsLeaderTime.Count() > 0)
                            {
                                foreach (var itemLeaderTime in itemsLeaderTime)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_LEADTIME(
                                         IDContractNo.ToString(),
                                         itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemLeaderTime["Leadtimesx"].ToString()
                                       , itemLeaderTime["ThoiGianKyHD"].ToString()
                                       , itemLeaderTime["ThanhToan"].ToString()
                                       , itemLeaderTime["DongCongVaHQXuat"].ToString()
                                       , itemLeaderTime["DiBien"].ToString()
                                       , itemLeaderTime["ThuTucHQDauNhap"].ToString()
                                       , itemLeaderTime["TongLeadtime"].ToString()
                                       , Session["uid"].ToString()
                                       , itemLeaderTime["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsChiPhiVanHanh.Count() > 0)
                            {
                                foreach (var itemChiPhiVanHanh in itemsChiPhiVanHanh)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_CHIPHIVANHANH(
                                         IDContractNo.ToString(),
                                         itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemChiPhiVanHanh["NoiDungDauTu"].ToString()
                                       , itemChiPhiVanHanh["PTDauTu"].ToString()
                                       , itemChiPhiVanHanh["GiaTriDauTu"].ToString()
                                       , itemChiPhiVanHanh["DieuKien"].ToString()
                                       , itemChiPhiVanHanh["salesConditions"].ToString()
                                       , Session["uid"].ToString()
                                       , itemChiPhiVanHanh["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsHangThueKe.Count() > 0)
                            {
                                foreach (var itemHangThueKe in itemsHangThueKe)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_RENT_PRODUCT(
                                          IDContractNo.ToString(),
                                        itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemHangThueKe["codeProduct"].ToString()
                                       , itemHangThueKe["nameProduct"].ToString()
                                       , itemHangThueKe["barcode"].ToString()

                                        , itemHangThueKe["M2netSP"].ToString()
                                        , itemHangThueKe["M2FGrossSP"].ToString()

                                        , itemHangThueKe["CoatingShop"].ToString()
                                        , itemHangThueKe["NumberFace"].ToString()
                                        , itemHangThueKe["Mien"].ToString()

                                        , itemHangThueKe["NgayBatDau"].ToString()
                                        , itemHangThueKe["NgayKetThuc"].ToString()

                                          , itemHangThueKe["NgaybatDauThue"].ToString()
                                          , itemHangThueKe["NgayDieuChinhKetThuc"].ToString()
                                          , itemHangThueKe["TuDongGiaHan"].ToString()

                                           , itemHangThueKe["HieuLuc"].ToString()
                                       , Session["uid"].ToString()
                                    );
                                }
                            }
                            if (itemsThueKeBrand.Count() > 0)
                            {
                                foreach (var itemHangThueKe in itemsThueKeBrand)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_BRAND_THUEKE_PRODUCT(
                                         IDContractNo.ToString(),
                                        itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemHangThueKe["codeProduct"].ToString()
                                       , itemHangThueKe["nameProduct"].ToString()

                                        , itemHangThueKe["SoCuaHangThue"].ToString()
                                        , itemHangThueKe["SoThang"].ToString()
                                        , itemHangThueKe["M2FThueCuaHang"].ToString()

                                        , itemHangThueKe["ChiPhiThueThangVAT"].ToString()
                                        , itemHangThueKe["TongChiPhiThueThangVAT"].ToString()
                                        , itemHangThueKe["TongChiPhiThueNam"].ToString()
                                        , itemHangThueKe["DSCamKetCuaHang"].ToString()

                                        , itemHangThueKe["NgayKyHD"].ToString()
                                        , itemHangThueKe["NgayHetHanHD"].ToString()
                                        , itemHangThueKe["NgaybatDauThue"].ToString()
                                        , itemHangThueKe["NgayDieuChinhKetThuc"].ToString()

                                        , itemHangThueKe["checkTuDongGiaHan"].ToString()

                                        , itemHangThueKe["HieuLuc"].ToString()
                                       , Session["uid"].ToString()
                                    );
                                }
                            }


                            if (itemsThueKeFunction.Count() > 0)
                            {
                                foreach (var itemHangThueKe in itemsThueKeFunction)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_FUNCTION_THUEKE_PRODUCT(
                                          IDContractNo.ToString(),
                                        itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemHangThueKe["codeProduct"].ToString()
                                       , itemHangThueKe["nameProduct"].ToString()
                                       , itemHangThueKe["barcode"].ToString()

                                       , itemHangThueKe["M2netSP"].ToString()
                                       , itemHangThueKe["M2FGrossSP"].ToString()

                                       , itemHangThueKe["CoatingShop"].ToString()
                                       , itemHangThueKe["NumberFace"].ToString()

                                       , itemHangThueKe["NgayBatDau"].ToString()
                                       , itemHangThueKe["NgayKetThuc"].ToString()
                                          , itemHangThueKe["HieuLuc"].ToString()
                                       , Session["uid"].ToString()
                                    );
                                }
                            }


                            if (itemsThongTinChung.Count() > 0)
                            {
                                foreach (var itemTTChung in itemsThongTinChung)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_THUEKE_THONGTINCHUNG(
                                           IDContractNo.ToString(),
                                        itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemTTChung["SoCuaHangThue"].ToString()
                                       , itemTTChung["SoThang"].ToString()
                                        , itemTTChung["M2FThueCuaHang"].ToString()

                                       , itemTTChung["ChiPhiThueThangVAT"].ToString()
                                       , itemTTChung["TongChiPhiThueThangVAT"].ToString()
                                       , itemTTChung["TongChiPhiThueNam"].ToString()
                                        , itemTTChung["DSCamKetCuaHang"].ToString()
                                        , itemTTChung["Mien"].ToString()
                                        , itemTTChung["NgayKyHD"].ToString()
                                        , itemTTChung["NgayHetHanHD"].ToString()
                                        , itemTTChung["NgaybatDauThue"].ToString()
                                        , itemTTChung["NgayDieuChinhKetThuc"].ToString()

                                       , itemTTChung["checkTuDongGiaHan"].ToString()
                                         , itemTTChung["HieuLuc"].ToString()
                                       , Session["uid"].ToString()
                                    );
                                }
                            }


                            //
                            err.RespId = 0;
                            err.RespMsg = "Lưu thông tin thành công";
                        }
                        else
                        {
                            err.RespId = -1;
                            err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại";
                        }
                    }
                }
                return Json(err);
            }
            catch (Exception ex)
            {
                err.RespId = -1;
                err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại" + ex;
            }
            return Json(err);
        }

        [HttpPost]
        public ActionResult Copy_TradeRequest(ObjTradeRequest obj)
        {
            var err = new RouteInfo();
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var itemsContract = JArray.Parse(obj.SourceContract);
                    var itemsCoopInfoVendors = JArray.Parse(obj.SourceCoopInfoVendors);
                    var itemsHangHoa = JArray.Parse(obj.SourceHangHoa);

                    //var itemsHangHoa_Function = JArray.Parse(obj.SourceHangHoaFunction);
                    //var itemsHangHoa_Brand = JArray.Parse(obj.SourceHangHoaBrand);

                    var itemsChietKhau = JArray.Parse(obj.SourceChietKhau);
                    var itemsHangTang = JArray.Parse(obj.SourceHangTang);
                    var itemsBonus = JArray.Parse(obj.SourceBonus);
                    var itemsTrade = JArray.Parse(obj.SourceTrade);

                    var itemsThuongHieu = JArray.Parse(obj.SourceThuongHieu);
                    var itemsCustomer = JArray.Parse(obj.SourceCustomer);
                    var itemsDoiTra = JArray.Parse(obj.SourceDoiTra);
                    var itemsThanhToan = JArray.Parse(obj.SourceThanhToan);
                    var itemsHopTacKhac = JArray.Parse(obj.SourceHopTacKhac);

                    var VendorNo = itemsContract[0]["VendorNo"].ToString();

                    var itemsLeaderTime = JArray.Parse(obj.SourceLeaderTime);
                    var itemsChiPhiVanHanh = JArray.Parse(obj.SourceChiPhiVanHanh);
                    var itemsHangThueKe = JArray.Parse(obj.SourceHangThueKe);

                    var itemsThueKeBrand = JArray.Parse(obj.SourceThueKeBrand);
                    var itemsThueKeFunction = JArray.Parse(obj.SourceThueKeFunction);

                    var itemsThongTinChung = JArray.Parse(obj.SourceThongTinChung);

                    if (itemsContract.Count > 0)
                    {
                        //var cmd_2 = $"SELECT COUNT(1) FROM [TBL_TRADTERM_CONTRACT] WHERE [ContractNo] = N'{itemsContract[0]["ContractNo"].ToString()}'";
                        //var ret_2 = SqlHelper.ExecuteScalar(strConn, CommandType.Text, cmd_2).ToInt(0).Value;
                        using (var con = new SqlConnection(strConn))
                        {
                            con.Open();
                            var select = $"SELECT COUNT(1) FROM [TBL_TRADTERM_CONTRACT] WHERE [ContractNo] = N'{itemsContract[0]["ContractNo"].ToString()}'";
                            SqlCommand cmd = new SqlCommand(select, con);
                            var item = cmd.ExecuteScalar();
                            if (item.ToString() != "0")
                            {
                                err.RespId = -1;
                                err.RespMsg = $"Số hợp đồng <b>{ itemsContract[0]["ContractNo"].ToString()}</b> đã có trong hệ thống, Vui lòng nhập mã hợp đồng khác";
                                return Json(err);
                            }
                            con.Close();
                        }

                        var result = DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_CONTRACT(
                             itemsContract[0]["VendorNo"].ToString()
                            , itemsContract[0]["ContractNo"].ToString()
                            , itemsContract[0]["FromDate"].ToString()
                            , itemsContract[0]["ToDate"].ToString()
                            , itemsContract[0]["ACM"].ToString()
                            , itemsContract[0]["CM"].ToString()
                            , itemsContract[0]["SupplyManager"].ToString()
                            , itemsContract[0]["AutoExtentContract"].ToString()
                            , itemsContract[0]["AutoExtentContractSoHopDong"].ToString()
                            , itemsContract[0]["priceChangeDate"].ToString()
                            , Session["uid"].ToString()
                            , itemsContract[0]["Type"].ToString()
                            , itemsContract[0]["SoPhuLuc"].ToString()
                            , itemsContract[0]["SoHopDong"].ToString()
                            , itemsContract[0]["TuNgay"].ToString()
                            , itemsContract[0]["DenNgay"].ToString()
                            , itemsContract[0]["FileSoHopDong"].ToString()
                            , itemsContract[0]["FilePhuLucHopDong"].ToString()
                            , itemsContract[0]["NguoiDaiDienBBM"].ToString()
                            , itemsContract[0]["NguoiDaiDienNCC"].ToString()
                            , itemsContract[0]["TinhTrang"].ToString()
                             , itemsContract[0]["DaiDienBBM"].ToString()
                            , itemsContract[0]["DaiDienNCC"].ToString()
                        );

                        if (result)
                        {
                            string IDContractNo = "";
                            // Lấy ra ID để cho vào các bảng phụ
                            var bn = DataAccess.DataAccessTrading.Get_ID_TRADTERM_CONTRACT_ContractNo(itemsContract[0]["VendorNo"].ToString(), itemsContract[0]["ContractNo"].ToString());
                            if (bn.Count > 0)
                            {
                                IDContractNo = bn[0].Code;
                            }

                            if (itemsHangHoa.Count() > 0)
                            {
                                foreach (var itemHH in itemsHangHoa)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_VENDORS_PRODUCT(
                                        IDContractNo.ToString()
                                        , itemsContract[0]["ContractNo"].ToString()
                                        , itemsContract[0]["VendorNo"].ToString()
                                        , itemHH["codeProduct"].ToString()
                                        , itemHH["nameProduct"].ToString()
                                        , itemHH["barcode"].ToString()
                                        , itemHH["hinhthucht"].ToString()
                                        , itemHH["vat"].ToString()
                                        , itemHH["discountPrice"].ToString()
                                        , itemHH["percentDiscount"].ToString()
                                        , itemHH["priceAfterDiscount"].ToString()
                                        , Session["uid"].ToString()
                                        , itemHH["typeTab"].ToString()
                                        , itemHH["TinhTrang"].ToString()
                                        , itemHH["RangeReviewCode"].ToString()
                                        , itemHH["RangeReviewName"].ToString()
                                        , itemHH["ThuongDinhHuong"].ToString()
                                   );
                                }
                            }

                            //if (itemsHangHoa_Function.Count() > 0)
                            //{
                            //    foreach (var itemHH in itemsHangHoa_Function)
                            //    {
                            //        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_VENDORS_PRODUCT_FUNCTION(
                            //             IDContractNo.ToString()
                            //           , itemsContract[0]["ContractNo"].ToString()
                            //           , itemsContract[0]["VendorNo"].ToString()
                            //           , itemHH["FunctionCode"].ToString()
                            //           , itemHH["FunctionName"].ToString()
                            //           , itemHH["hinhthucht"].ToString()
                            //           , itemHH["vat"].ToString()
                            //           , itemHH["discountPrice"].ToString()
                            //           , Session["uid"].ToString()
                            //           , itemHH["typeTab"].ToString()
                            //       );
                            //    }
                            //}

                            //if (itemsHangHoa_Brand.Count() > 0)
                            //{
                            //    foreach (var itemHH in itemsHangHoa_Brand)
                            //    {
                            //        DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_VENDORS_PRODUCT_BRAND(
                            //             IDContractNo.ToString()
                            //            , itemsContract[0]["ContractNo"].ToString()
                            //           , itemsContract[0]["VendorNo"].ToString()
                            //           , itemHH["BrandCode"].ToString()
                            //           , itemHH["BrandName"].ToString()
                            //           , itemHH["hinhthucht"].ToString()
                            //           , itemHH["vat"].ToString()
                            //           , itemHH["discountPrice"].ToString()
                            //           , Session["uid"].ToString()
                            //           , itemHH["typeTab"].ToString()
                            //       );
                            //    }
                            //}
                            if (itemsChietKhau.Count() > 0)
                            {
                                foreach (var itemCK in itemsChietKhau)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_DISCOUNT_SALES(
                                          IDContractNo.ToString()
                                        , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemCK["typeDiscount"].ToString()
                                       , itemCK["HinhThucThanhToan"].ToString()
                                       , itemCK["discountAmount"].ToString()
                                       , itemCK["percentDiscount"].ToString()
                                        , itemCK["OrderValue"].ToString()
                                       , Session["uid"].ToString()
                                       , itemCK["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsHangTang.Count() > 0)
                            {
                                foreach (var itemHT in itemsHangTang)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_DISCOUNT_QTTY(
                                          IDContractNo.ToString()
                                        , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemHT["quantityBuy"].ToString()
                                       , itemHT["orderQuantity"].ToString()
                                       , Session["uid"].ToString()
                                       , itemHT["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsBonus.Count() > 0)
                            {
                                foreach (var itemBonus in itemsBonus)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_LINE_BONUS(
                                        IDContractNo.ToString()
                                       , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemBonus["bonusType"].ToString()
                                       , itemBonus["salesLevel"].ToString()
                                       , itemBonus["salesLevelDen"].ToString()
                                       , itemBonus["salesConditions"].ToString()
                                       , itemBonus["discountPercent"].ToString()
                                       , itemBonus["DiscountAmountNoVAT"].ToString()
                                       , itemBonus["description"].ToString()
                                       , itemBonus["DKDSTinhThuong"].ToString()
                                       , Session["uid"].ToString()
                                       , itemBonus["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsTrade.Count() > 0)
                            {
                                foreach (var itemTrade in itemsTrade)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_MKT_BONUS(
                                         IDContractNo.ToString()
                                       , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemTrade["mktbonus_content_invest"].ToString()
                                       , itemTrade["mktbonus_percent_invest"].ToString()
                                       , itemTrade["mktbonus_invest_value"].ToString()
                                       , itemTrade["mktbonus_des"].ToString()
                                        , itemTrade["salesConditions"].ToString()
                                       , Session["uid"].ToString()
                                       , itemTrade["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsCustomer.Count() > 0)
                            {
                                foreach (var itemCustomer in itemsCustomer)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_CUSTOMER_BONUS(
                                         IDContractNo.ToString()
                                        , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemCustomer["cusbonus_content_invest"].ToString()
                                       , itemCustomer["cusbonus_percent_invest"].ToString()
                                       , itemCustomer["cusbonus_invest_value"].ToString()
                                       , itemCustomer["cusbonus_percent_des"].ToString()
                                        , itemCustomer["salesConditions"].ToString()
                                       , Session["uid"].ToString()
                                       , itemCustomer["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsThuongHieu.Count() > 0)
                            {
                                foreach (var itemThuongHieu in itemsThuongHieu)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_BRAND_BONUS(
                                          IDContractNo.ToString()
                                          , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemThuongHieu["brandbonus_content_invest"].ToString()
                                       , itemThuongHieu["brandbonus_percent_invest"].ToString()
                                       , itemThuongHieu["brandbonus_invest_value"].ToString()
                                       , itemThuongHieu["brandbonus_des"].ToString()
                                       , itemThuongHieu["salesConditions"].ToString()
                                       , Session["uid"].ToString()
                                       , itemThuongHieu["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsDoiTra.Count() > 0)
                            {
                                foreach (var itemDoiTra in itemsDoiTra)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_APPLY_RETURN_PRODUCT(
                                         IDContractNo.ToString()
                                         , itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                        , itemDoiTra["Satus"].ToString()
                                       , itemDoiTra["refundTerm"].ToString()
                                       , itemDoiTra["Penalty"].ToString()
                                       , itemDoiTra["confirmChange"].ToString()
                                       , itemDoiTra["Conten"].ToString()
                                        , itemDoiTra["BaoTruocNgay"].ToString()
                                       , Session["uid"].ToString()
                                       , itemDoiTra["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsThanhToan.Count() > 0)
                            {
                                foreach (var itemThanhToan in itemsThanhToan)
                                {

                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_PAYMENT(
                                          IDContractNo.ToString(),
                                          itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemThanhToan["typeOrder"].ToString()
                                       , itemThanhToan["paymentPeriod"].ToString()
                                       , itemThanhToan["onDay"].ToString()
                                       , itemThanhToan["andDay"].ToString()
                                       , itemThanhToan["applyFor"].ToString()
                                       , itemThanhToan["Content"].ToString()
                                       , Session["uid"].ToString()
                                       , itemThanhToan["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsHopTacKhac.Count() > 0)
                            {
                                foreach (var itemHopTacKhac in itemsHopTacKhac)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_COOPERATION_OTHER(
                                          IDContractNo.ToString(),
                                         itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemHopTacKhac["content1"].ToString()
                                       , itemHopTacKhac["content2"].ToString()
                                       , itemHopTacKhac["content3"].ToString()
                                       , Session["uid"].ToString()
                                       , itemHopTacKhac["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsLeaderTime.Count() > 0)
                            {
                                foreach (var itemLeaderTime in itemsLeaderTime)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_LEADTIME(
                                         IDContractNo.ToString(),
                                         itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemLeaderTime["Leadtimesx"].ToString()
                                       , itemLeaderTime["ThoiGianKyHD"].ToString()
                                       , itemLeaderTime["ThanhToan"].ToString()
                                       , itemLeaderTime["DongCongVaHQXuat"].ToString()
                                       , itemLeaderTime["DiBien"].ToString()
                                       , itemLeaderTime["ThuTucHQDauNhap"].ToString()
                                       , itemLeaderTime["TongLeadtime"].ToString()
                                       , Session["uid"].ToString()
                                       , itemLeaderTime["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsChiPhiVanHanh.Count() > 0)
                            {
                                foreach (var itemChiPhiVanHanh in itemsChiPhiVanHanh)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_CHIPHIVANHANH(
                                         IDContractNo.ToString(),
                                         itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemChiPhiVanHanh["NoiDungDauTu"].ToString()
                                       , itemChiPhiVanHanh["PTDauTu"].ToString()
                                       , itemChiPhiVanHanh["GiaTriDauTu"].ToString()
                                       , itemChiPhiVanHanh["DieuKien"].ToString()
                                       , itemChiPhiVanHanh["salesConditions"].ToString()
                                       , Session["uid"].ToString()
                                       , itemChiPhiVanHanh["typeTab"].ToString()
                                    );
                                }
                            }

                            if (itemsHangThueKe.Count() > 0)
                            {
                                foreach (var itemHangThueKe in itemsHangThueKe)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_RENT_PRODUCT(
                                          IDContractNo.ToString(),
                                        itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemHangThueKe["codeProduct"].ToString()
                                       , itemHangThueKe["nameProduct"].ToString()
                                       , itemHangThueKe["barcode"].ToString()

                                        , itemHangThueKe["M2netSP"].ToString()
                                        , itemHangThueKe["M2FGrossSP"].ToString()

                                        , itemHangThueKe["CoatingShop"].ToString()
                                        , itemHangThueKe["NumberFace"].ToString()
                                        , itemHangThueKe["Mien"].ToString()

                                        , itemHangThueKe["NgayBatDau"].ToString()
                                        , itemHangThueKe["NgayKetThuc"].ToString()

                                          , itemHangThueKe["NgaybatDauThue"].ToString()
                                          , itemHangThueKe["NgayDieuChinhKetThuc"].ToString()
                                          , itemHangThueKe["TuDongGiaHan"].ToString()

                                           , itemHangThueKe["HieuLuc"].ToString()
                                       , Session["uid"].ToString()
                                    );
                                }
                            }
                            if (itemsThueKeBrand.Count() > 0)
                            {
                                foreach (var itemHangThueKe in itemsThueKeBrand)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_BRAND_THUEKE_PRODUCT(
                                         IDContractNo.ToString(),
                                        itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemHangThueKe["codeProduct"].ToString()
                                       , itemHangThueKe["nameProduct"].ToString()

                                        , itemHangThueKe["SoCuaHangThue"].ToString()
                                        , itemHangThueKe["SoThang"].ToString()
                                        , itemHangThueKe["M2FThueCuaHang"].ToString()

                                        , itemHangThueKe["ChiPhiThueThangVAT"].ToString()
                                        , itemHangThueKe["TongChiPhiThueThangVAT"].ToString()
                                        , itemHangThueKe["TongChiPhiThueNam"].ToString()
                                        , itemHangThueKe["DSCamKetCuaHang"].ToString()

                                        , itemHangThueKe["NgayKyHD"].ToString()
                                        , itemHangThueKe["NgayHetHanHD"].ToString()
                                        , itemHangThueKe["NgaybatDauThue"].ToString()
                                        , itemHangThueKe["NgayDieuChinhKetThuc"].ToString()

                                        , itemHangThueKe["checkTuDongGiaHan"].ToString()

                                        , itemHangThueKe["HieuLuc"].ToString()
                                       , Session["uid"].ToString()
                                    );
                                }
                            }


                            if (itemsThueKeFunction.Count() > 0)
                            {
                                foreach (var itemHangThueKe in itemsThueKeFunction)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_FUNCTION_THUEKE_PRODUCT(
                                          IDContractNo.ToString(),
                                        itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemHangThueKe["codeProduct"].ToString()
                                       , itemHangThueKe["nameProduct"].ToString()
                                       , itemHangThueKe["barcode"].ToString()

                                       , itemHangThueKe["M2netSP"].ToString()
                                       , itemHangThueKe["M2FGrossSP"].ToString()

                                       , itemHangThueKe["CoatingShop"].ToString()
                                       , itemHangThueKe["NumberFace"].ToString()

                                       , itemHangThueKe["NgayBatDau"].ToString()
                                       , itemHangThueKe["NgayKetThuc"].ToString()
                                          , itemHangThueKe["HieuLuc"].ToString()
                                       , Session["uid"].ToString()
                                    );
                                }
                            }


                            if (itemsThongTinChung.Count() > 0)
                            {
                                foreach (var itemTTChung in itemsThongTinChung)
                                {
                                    DataAccess.DataAccessTrading.SP_TRADTERM_INSERT_THUEKE_THONGTINCHUNG(
                                           IDContractNo.ToString(),
                                        itemsContract[0]["ContractNo"].ToString()
                                       , itemsContract[0]["VendorNo"].ToString()
                                       , itemTTChung["SoCuaHangThue"].ToString()
                                       , itemTTChung["SoThang"].ToString()
                                        , itemTTChung["M2FThueCuaHang"].ToString()

                                       , itemTTChung["ChiPhiThueThangVAT"].ToString()
                                       , itemTTChung["TongChiPhiThueThangVAT"].ToString()
                                       , itemTTChung["TongChiPhiThueNam"].ToString()
                                        , itemTTChung["DSCamKetCuaHang"].ToString()
                                        , itemTTChung["Mien"].ToString()
                                        , itemTTChung["NgayKyHD"].ToString()
                                        , itemTTChung["NgayHetHanHD"].ToString()
                                        , itemTTChung["NgaybatDauThue"].ToString()
                                        , itemTTChung["NgayDieuChinhKetThuc"].ToString()

                                       , itemTTChung["checkTuDongGiaHan"].ToString()
                                         , itemTTChung["HieuLuc"].ToString()
                                       , Session["uid"].ToString()
                                    );
                                }
                            }


                            //
                            err.RespId = 0;
                            err.RespMsg = "Lưu thông tin thành công";
                        }
                        else
                        {
                            err.RespId = -1;
                            err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại";
                        }
                    }
                }
                return Json(err);
            }
            catch (Exception ex)
            {
                err.RespId = -1;
                err.RespMsg = "Có lỗi. Vui lòng kiểm tra lại" + ex;
            }
            return Json(err);
        }

        [HttpPost]
        public ActionResult Delete_ContractNo(string[] ID)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    var item = DataAccess.DataAccessTrading.SP_TRADTERM_DELETE_ContractNo(ID[i].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_ContractNo");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult Update_Status_TradingTermVendor_Chang_Send(string[] ID, string HanhDong)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    var item = DataAccess.DataAccessTrading.Update_Status_TradingTermVendor_Chang_Send(ID[i].ToString(), HanhDong, Session["uid"].ToString());
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_TradingTermVendor_Chang_Send");
                return Json(new { code = 1, message = "" });
            }
        }

        #region SetselectThuong
        public ActionResult SetselectThuong()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list_typeBonus = DataAccess.DataAccessTrading.SP_TRADTERM_GET_TT_THUONG();
                    return Json(list_typeBonus);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SetselectThuong");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult SetselectTRADEMARKETING()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list_ChiPhiBanHang = DataAccess.DataAccessTrading.SP_TRADTERM_TT_ChiPhiBanHang();
                    return Json(list_ChiPhiBanHang);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SetselectTRADEMARKETING");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult SetselectThuongHieu()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list_phattrienTH = DataAccess.DataAccessTrading.SP_TRADTERM_TT_PhatTrienThuongHieu();
                    return Json(list_phattrienTH);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SetselectThuongHieu");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult SetselectphattrienKH()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list_phattrienKH = DataAccess.DataAccessTrading.SP_TRADTERM_TT_PhatTrienKhachHang();
                    return Json(list_phattrienKH);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SetselectThuongHieu");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Setselect_ChiPhiVanHanh()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {

                    var list_ChiPhiVanHanh = DataAccess.DataAccessTrading.get_ChiPhiVanHanh();
                    return Json(list_ChiPhiVanHanh);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Setselect_ChiPhiVanHanh");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Setselect_Thuong()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list_Thuong = DataAccess.DataAccessTrading.SP_MD_TT_Thuong();
                    return Json(list_Thuong);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Setselect_Thuong");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Setselect_HinhThucHopTac()
        {
            try
            {
                var list_LoaiPo = DataAccess.DataAccessTrading.SP_TRADTERM_TT_LOAIPO();
                return Json(list_LoaiPo);
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Setselect_HinhThucHopTac");
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Get_M2FGross_ThueKe(string MaHang)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.Get_M2FGross_ThueKe(MaHang);
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
        public ActionResult Get_SetApDungGia(string MaHang)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.Get_SetApDungGia(MaHang);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_SetApDungGia");
                return Json(null);
            }
        }


        //25/12
        [HttpPost]
        public ActionResult Get_SetApDung_TTChung_ThueKe(string VendorNCC)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.Get_SetApDung_TTChung_ThueKe(VendorNCC);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_SetApDung_TTChung_ThueKe");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult SetApDung_SKU_ThueKe(string MaHang)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.SetApDung_SKU_ThueKe(MaHang);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SetApDung_SKU_ThueKe");
                return Json(null);
            }
        }
        #endregion

        async public Task<ActionResult> UploadFile(string foldername)
        {
            try
            {
                var file = System.Web.HttpContext.Current.Request.Files["MyImages"];
                string linkres = await SystemFunctions.Upload_File_Direct("TradingTermVendor", file);
                if (linkres.Contains("media.bibomart.net"))
                {
                    return Json(new { code = 1, link = linkres, showfie = "/image/iconpdf.png" });
                }
                else
                    return Json(new { code = 0, link = linkres, showfie = "" });
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(ex.ToString(), "TradingTermVendor");
                return Json(new { code = 0, link = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult UploadFileFile(string ID, string File)
        {
            try
            {
                var bn = DataAccess.DataAccessTrading.SP_TRADTERM_UPDATE_CONTRACT_File(ID, File);
                return Json(JsonConvert.SerializeObject(bn));
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SetApDung_SKU_ThueKe");
                return Json(null);
            }
        }

        async public Task<ActionResult> uploadTradingTerm(string foldername, string ID)
        {
            try
            {
                var file = System.Web.HttpContext.Current.Request.Files["MyImages"];
                string linkres = await SystemFunctions.Upload_File_Direct(foldername, file);
                if (linkres.Contains("media.bibomart.net"))
                {
                    var bn = DataAccess.DataAccessTrading.SP_TRADTERM_UPDATE_CONTRACT_File(ID, linkres);
                    return Json(new { code = 1, link = linkres });
                }
                else
                    return Json(new { code = 0, link = linkres });
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(ex.ToString(), "uploadTradingTerm");
                return Json(new { code = 0, link = ex.Message });
            }
        }

        public ActionResult ApproveTradingTerm(string vendorNo)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (vendorNo != null && vendorNo.ToString().Length > 0)
                    {
                        Session["vendorNo"] = vendorNo;
                    }
                    else
                    {
                        Session["vendorNo"] = "";
                    }
                    var list_vendor = DataAccess.DataAccessTrading.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("TradingTermVendor", "DuyetDamPhanTradingTerm");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DuyetDamPhanTradingTerm");
                return RedirectToAction("", "");
            }
        }

        public ActionResult Get_ApproveTradingTerm(string ContractNo, string Status, string vendorNo, string NgayHieuLuc)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["vendorNo"] != null && Session["vendorNo"].ToString().Length > 0)
                    {
                        DataTable table = DataAccess.DataAccessTrading.ApproveTradingTerm(ContractNo, Status, Session["vendorNo"].ToString(), NgayHieuLuc);
                        return PartialView("~/Views/TradingTermVendor/Partial/__ApproveTradingTerm.cshtml", table);
                    }
                    else
                    {
                        DataTable table = DataAccess.DataAccessTrading.ApproveTradingTerm(ContractNo, Status, vendorNo, NgayHieuLuc);
                        return PartialView("~/Views/TradingTermVendor/Partial/__ApproveTradingTerm.cshtml", table);
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DuyetDamPhanTradingTerm");
                return RedirectToAction("", "");
            }

        }

        // BOXUNG
        [HttpPost]
        public ActionResult SP_TRADTERM_ApDungSp_HHOA_TK_KGUI(string vendorNo, string Type, string MaSpSKU, string TenSpSKU, string RangeReview)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    System.Data.DataTable table = DataAccess.DataAccessTrading.SP_TRADTERM_ApDungSp_HHOA_TK_KGUI(vendorNo, Type, MaSpSKU, TenSpSKU, RangeReview);
                    return PartialView("~/Views/TradingTermVendor/tab/_tabMuaBan_KGUI_SKU.cshtml", table);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_ApDungSp_HHOA_TK_KGUI");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_Detail(string vendorNo, string IDContractNo, string Type, string MaSpSKU, string TenSpSKU, string RangeReview)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    System.Data.DataTable table = DataAccess.DataAccessTrading.SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_Detail_Edit(vendorNo, IDContractNo, Type, MaSpSKU, TenSpSKU, RangeReview);
                    return PartialView("~/Views/TradingTermVendor/tabDetail/_tabMuaBan_KGUI_SKU.cshtml", table);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_Detail_Edit");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_Edit(string vendorNo, string IDContractNo, string Type, string MaSpSKU, string TenSpSKU, string RangeReview)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    System.Data.DataTable table = DataAccess.DataAccessTrading.SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_Detail_Edit(vendorNo, IDContractNo, Type, MaSpSKU, TenSpSKU, RangeReview);
                    return PartialView("~/Views/TradingTermVendor/tabEdit/_tabMuaBan_KGUI_SKU.cshtml", table);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_ApDungSp_HHOA_TK_KGUI_Detail_Edit");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

    }
}
