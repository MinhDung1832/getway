using MP_VendorTool.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MP_VendorTool.Models.Report;
using MP_VendorTool.Common;
using OfficeOpenXml;
using System.IO;
using NPOI.XSSF.UserModel;
using MP_VendorTool.Models.Promotion;
using System.Net;

namespace MP_VendorTool.Controllers
{
    public class ReportController : Controller
    {
        public void ExportExcelSalesVendor()
        {
            string Namefile = "Bao_Cao_danh_so_NCC_" + DateTime.Now.ToString("ddMMMyyyy");
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + Namefile + ".xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            sb.Append("<table border='1' bgcolor='#ffffff' bordercolor='#dedede' cellspacing='0' cellpadding='0' style='font-size:12px; font-family:Arial; background:white;'>");
            sb.Append("<tr>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b>Mã hàng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:400px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b> Tên hàng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b>Mã NCC</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:400px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b>Tên NCC</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>SL Bán MB</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>SL Bán MN</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>SL Tổng</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Doanh thu MB</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Doanh thu MN</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Doanh thu tổng</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Chi phí CTKM MB</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Chi phí CTKM MN</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Chi phí CTKM Tổng</b>");
            sb.Append("  </th>");


            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Thưởng ĐH MB</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Thưởng ĐH MN</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Thưởng ĐH tổng</b>");
            sb.Append("  </th>");
            sb.Append("  </tr>");
            try
            {
                List<CongNo> Litem = (List<CongNo>)Session["onExpSalesVendor"];
                foreach (var item in Litem)
                {
                    sb.Append("<tr>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item.MaHang + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:400px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item.Tenhang + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item.MaNCC + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:400px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item.NccName + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.QuantityMB + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.QuantityMN + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.Quantity + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.AmountMB + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.AmountMN + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.Amount + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.DiscountAmountMB + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.DiscountAmountMN + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.DiscountAmount + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.AmountDHMB + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.AmountDHMN + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.AmountDH + "");
                    sb.Append("  </td>");

                    sb.Append("  </tr>");
                }
            }
            catch (Exception)
            { }
            sb.Append("</table>");
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

        [HttpPost]
        public ActionResult GetList_SalesVendor(string MaHang, string Thang, string Nam)
        {
            System.Data.DataTable table;
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        table = DataAccess.DataAccess.Sp_GETLIST_Sales_Vendor(MaHang, Thang, Nam, Session["VendorCode"].ToString());
                    }
                    else
                    {
                        table = DataAccess.DataAccess.Sp_GETLIST_Sales_Vendor(MaHang, Thang, Nam, "");
                    }
                    var onExp = (from DataRow dr in table.Rows
                                 select new CongNo()
                                 {
                                     MaHang = dr["MaHang"].ToString(),
                                     Tenhang = dr["Tenhang"].ToString(),
                                     MaNCC = dr["MaNCC"].ToString(),
                                     HHKGTKE = dr["HHKGTKE"].ToString(),
                                     NccName = dr["NccName"].ToString(),
                                     Giaban = dr["Giaban"].ToString(),

                                     QuantityMB = dr["QuantityMB"].ToString(),
                                     QuantityMN = dr["QuantityMN"].ToString(),

                                     Quantity = dr["Quantity"].ToString(),
                                     AmountMB = dr["AmountMB"].ToString(),
                                     AmountMN = dr["AmountMN"].ToString(),
                                     Amount = dr["Amount"].ToString(),

                                     DiscountAmountMB = dr["DiscountAmountMB"].ToString(),
                                     DiscountAmountMN = dr["DiscountAmountMN"].ToString(),
                                     DiscountAmount = dr["DiscountAmount"].ToString(),

                                     AmountDHMB = dr["AmountDHMB"].ToString(),
                                     AmountDHMN = dr["AmountDHMN"].ToString(),
                                     AmountDH = dr["AmountDH"].ToString(),

                                 }).ToList();
                    Session["onExpSalesVendor"] = onExp;
                    if (Thang != "")
                        return PartialView("~/Views/Report/Partial/__ReportSalesVendor.cshtml", table);
                    else
                        return PartialView("~/Views/Report/Partial/__ReportSalesVendor.cshtml", null);
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_SalesVendor");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        // GET: CTKM
        public ActionResult ReportSalesVendor()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("Report", "ReportSalesVendor")) return RedirectToAction("Index", "Home");

                    #region Year
                    for (int i = 2021; i < (DateTime.Now.Year + 1); i++)
                    {
                        if (DateTime.Now.Year.ToString() == i.ToString())
                            ViewBag.ShowNam += "<option selected value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                        else
                            ViewBag.ShowNam += "<option value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                    }
                    #endregion
                    return View();
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ReportSalesVendor");
                 return RedirectToAction("Index", "Home");
            }
        }

        #region DebtDeposit
        public ActionResult DebtDeposit()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("Report", "DebtDeposit")) return RedirectToAction("Index", "Home");

                    var list_vendor = DataAccess.DataAccessDelivery.SP_Delivery_Vender();
                    ViewBag.list_vendor = list_vendor;
                    #region Year
                    for (int i = 2021; i < (DateTime.Now.Year + 1); i++)
                    {
                        if (DateTime.Now.Year.ToString() == i.ToString())
                            ViewBag.ShowNam += "<option selected value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                        else
                            ViewBag.ShowNam += "<option value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                    }
                    #endregion
                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Report", "DebtDeposit");
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DebtDeposit");
                 return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult GetList_DebtDeposit(string MaHang, string Thang, string Nam,string VendorCode)
        {
            try
            {
                System.Data.DataTable table;
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        table = DataAccess.DataAccess.Sp_get_DebtDeposit_vendorNo(MaHang, Thang, Nam, Session["VendorCode"].ToString());
                    }
                    else
                    {
                        table = DataAccess.DataAccess.Sp_get_DebtDeposit_vendorNo(MaHang, Thang, Nam, VendorCode);
                    }

                    var onExp = (from DataRow dr in table.Rows
                                 select new obj_DebtDeposit()
                                 {
                                     MaHang = dr["MaHang"].ToString(),
                                     Tenhang = dr["Tenhang"].ToString(),
                                     NccName = dr["NccName"].ToString(),
                                     MaNCC = dr["MaNCC"].ToString(),
                                     QuantityMB = dr["QuantityMB"].ToString(),
                                     QuantityMN = dr["QuantityMN"].ToString(),

                                     SLTong = dr["SLTong"].ToString(),
                                     AmountMB = dr["AmountMB"].ToString(),
                                     AmountMN = dr["AmountMN"].ToString(),
                                     PhiTong = dr["PhiTong"].ToString(),
                                     CPDinhHuong = dr["CPDinhHuong"].ToString(),
                                     TrangThai = dr["TrangThai"].ToString(),
                                 }).ToList();
                    Session["onExpDebtDeposit"] = onExp;

                    if (Thang != "")
                        return PartialView("~/Views/Report/Partial/__DebtDeposit.cshtml", table);
                    else
                        return PartialView("~/Views/Report/Partial/__DebtDeposit.cshtml", null);
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_DebtDeposit");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
       
        [HttpPost]
        public ActionResult PostStatusDebtDeposit(string[] ID, string status)
        {
            try
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    var item = DataAccess.DataAccess.SP_Status_DebtDeposit_UPDATE(ID[i].ToString(), status);
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PostStatusDebtDeposit");
                return Json(new { code = 1, message = "" });
            }
        }

        public void ExportExcelDebtDeposit()
        {
            string Namefile = "Bao_Cao_Doanh_So_Ky_Gui_" + DateTime.Now.ToString("ddMMMyyyy");
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + Namefile + ".xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            sb.Append("<table border='1' bgcolor='#ffffff' bordercolor='#dedede' cellspacing='0' cellpadding='0' style='font-size:12px; font-family:Arial; background:white;'>");
            sb.Append("<tr>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b>Mã hàng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:400px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b> Tên hàng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b>Mã NCC</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:400px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b>Tên NCC</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>SL Bán MB</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>SL Bán MN</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>SL Tổng</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>MB Doanh thu MB</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>MB Doanh thu MN</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Doanh thu tổng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>CP định hướng</b>");
            sb.Append("  </th>");
            sb.Append("  </tr>");
            try
            {
                List<obj_DebtDeposit> Litem = (List<obj_DebtDeposit>)Session["onExpDebtDeposit"];
                foreach (var item in Litem)
                {
                    sb.Append("<tr>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item.MaHang + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:400px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item.Tenhang + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item.MaNCC + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:400px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item.NccName + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.QuantityMB + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.QuantityMN + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.SLTong + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.AmountMB + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.AmountMN + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.PhiTong + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.CPDinhHuong + "");
                    sb.Append("  </td>");
                    sb.Append("  </tr>");
                }
            }
            catch (Exception)
            { }
            sb.Append("</table>");
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion

        #region CTKM
        public ActionResult CTKM()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("Report", "CTKM")) return RedirectToAction("Index", "Home");

                    var list_datalist_Mien = DataAccess.DataAccess.sp_VendorTool_MD_Sub_get();
                    ViewBag.list_datalist_Mien = list_datalist_Mien;

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Report", "CTKM");
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM");
                 return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult GetList_CTKM(string MaHang, string TrangThai, string Mien, string LoaiCTKM)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    Session["MaHangDe"] = MaHang;
                    Session["TrangThai"] = TrangThai;
                    Session["Mien"] = Mien;
                    Session["LoaiCTKM"] = LoaiCTKM;

                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        System.Data.DataTable table = DataAccess.DataAccess.SP_CTKM_vendorNo_GET_LIST(MaHang, TrangThai, Session["VendorCode"].ToString(), Mien, LoaiCTKM);
                        return PartialView("~/Views/Report/Partial/__CTKM.cshtml", table);
                    }
                    else
                    {
                        System.Data.DataTable table = DataAccess.DataAccess.SP_CTKM_vendorNo_GET_LIST(MaHang, TrangThai, "", Mien, LoaiCTKM);
                        if (TrangThai != "")
                            return PartialView("~/Views/Report/Partial/__CTKM.cshtml", table);
                        else
                            return PartialView("~/Views/Report/Partial/__CTKM.cshtml", null);
                    }
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        public void ExportExcel_CTKM()
        {
            string Namefile = "Bao_Cao_CTKM_" + DateTime.Now.ToString("ddMMMyyyy");
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + Namefile + ".xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            sb.Append("<table border='1' bgcolor='#ffffff' bordercolor='#dedede' cellspacing='0' cellpadding='0' style='font-size:12px; font-family:Arial; background:white;'>");
            sb.Append("<tr>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b>Mã hàng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:400px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b> Tên hàng</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>SL Bán</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Loại CTKM</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Giảm giá</b>");
            sb.Append("  </th>");


            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Hàng tặng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Số lượng tặng</b>");
            sb.Append("  </th>");


            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Sl Coupon</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Giá trị Coupon</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:130px; vertical-align:middle;\">");
            sb.Append("    <b> Tổng chi phí </b>");
            sb.Append("  </th>");
            sb.Append("  </tr>");

            string MaHangDe = "";
            string TrangThai = "";
            string Mien = "";
            string LoaiCTKM = "";
            if (Session["MaHangDe"] != null && Session["MaHangDe"].ToString().Length > 0)
            {
                MaHangDe = Session["MaHangDe"].ToString();
            }
            if (Session["TrangThai"] != null && Session["TrangThai"].ToString().Length > 0)
            {
                TrangThai = Session["TrangThai"].ToString();
            }
            if (Session["Mien"] != null && Session["Mien"].ToString().Length > 0)
            {
                Mien = Session["Mien"].ToString();
            }
            if (Session["LoaiCTKM"] != null && Session["LoaiCTKM"].ToString().Length > 0)
            {
                LoaiCTKM = Session["LoaiCTKM"].ToString();
            }
            try
            {
                System.Data.DataTable table = new System.Data.DataTable();
                if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                {
                    table = DataAccess.DataAccess.SP_CTKM_vendorNo_GET_LIST(MaHangDe, TrangThai, Session["VendorCode"].ToString(), Mien, LoaiCTKM);
                }
                else
                {
                    table = DataAccess.DataAccess.SP_CTKM_vendorNo_GET_LIST(MaHangDe, TrangThai, "", Mien, LoaiCTKM);
                }
                foreach (DataRow item in table.Rows)
                {
                    sb.Append("<tr>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item["MaHang"] + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:400px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item["Tenhang"] + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item["Tenhang"] + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item["Tenhang"] + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item["Tenhang"] + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:130px; vertical-align:middle;\">");
                    sb.Append("    " + item["Tenhang"] + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:130px; vertical-align:middle;\">");
                    sb.Append("    " + item["Tenhang"] + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:130px; vertical-align:middle;\">");
                    sb.Append("    " + item["Tenhang"] + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:130px; vertical-align:middle;\">");
                    sb.Append("    " + item["Tenhang"] + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:130px; vertical-align:middle;\">");
                    sb.Append("    " + item["Tenhang"] + "");
                    sb.Append("  </td>");
                    sb.Append("  </tr>");
                }
            }
            catch (Exception)
            { }
            sb.Append("</table>");
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

        #endregion

        #region ThuongDinhHuong
        public ActionResult ThuongDinhHuong()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("Report", "ThuongDinhHuong")) return RedirectToAction("Index", "Home");

                    //var list_datalist_Mien = DataAccess.DataAccess.sp_VendorTool_MD_Sub_get();
                    //ViewBag.list_datalist_Mien = list_datalist_Mien;

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Report", "ThuongDinhHuong");
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ThuongDinhHuong");
                 return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult GetList_ThuongDinhHuong(string MaHang, string Thang)
        {
            try
            {
                System.Data.DataTable table;
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        table = DataAccess.DataAccess.SP_ThuongDinhHuong_vendorNo_GET_LIST(MaHang, Thang, Session["VendorCode"].ToString());
                    }
                    else
                    {
                        table = DataAccess.DataAccess.SP_ThuongDinhHuong_vendorNo_GET_LIST(MaHang, Thang, "");
                    }
                    var onExp = (from DataRow dr in table.Rows
                                 select new obj_ThuongDinhHuong()
                                 {
                                     MaHang = dr["MaHang"].ToString(),
                                     Tenhang = dr["Tenhang"].ToString(),
                                     QuantityMB = dr["QuantityMB"].ToString(),
                                     QuantityMN = dr["QuantityMN"].ToString(),
                                     SLTong = dr["SLTong"].ToString(),
                                     AmountMN = dr["AmountMN"].ToString()
                                 }).ToList();
                    Session["onExpThuongDinhHuong"] = onExp;
                    if (Thang != "")
                        return PartialView("~/Views/Report/Partial/__ThuongDinhHuong.cshtml", table);
                    else
                        return PartialView("~/Views/Report/Partial/__ThuongDinhHuong.cshtml", null);
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        public void ExportExcel_ThuongDinhHuong()
        {
            string Namefile = "Bao_Cao_Thuong_Dinh_Huong_" + DateTime.Now.ToString("ddMMMyyyy");
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + Namefile + ".xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            sb.Append("<table border='1' bgcolor='#ffffff' bordercolor='#dedede' cellspacing='0' cellpadding='0' style='font-size:12px; font-family:Arial; background:white;'>");
            sb.Append("<tr>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b>Mã hàng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:400px; vertical-align:middle;text-align: left;\">");
            sb.Append("    <b> Tên hàng</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>SL Bán MB</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>SL Bán MN</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:100px; vertical-align:middle;\">");
            sb.Append("    <b>Tổng bán</b>");
            sb.Append("  </th>");

            sb.Append("  <th style=\"width:130px; vertical-align:middle;\">");
            sb.Append("    <b> Thưởng định hướng </b>");
            sb.Append("  </th>");
            sb.Append("  </tr>");
            try
            {
                List<obj_ThuongDinhHuong> Litem = (List<obj_ThuongDinhHuong>)Session["onExpThuongDinhHuong"];
                foreach (var item in Litem)
                {
                    sb.Append("<tr>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item.MaHang + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:400px; vertical-align:middle;text-align: left;\">");
                    sb.Append("    " + item.Tenhang + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.QuantityMB + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.QuantityMN + "");
                    sb.Append("  </td>");
                    sb.Append("  <td style=\"widtd:100px; vertical-align:middle;\">");
                    sb.Append("    " + item.SLTong + "");
                    sb.Append("  </td>");

                    sb.Append("  <td style=\"widtd:130px; vertical-align:middle;\">");
                    sb.Append("    " + item.AmountMN + "");
                    sb.Append("  </td>");
                    sb.Append("  </tr>");
                }
            }
            catch (Exception)
            { }
            sb.Append("</table>");
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion

        #region DebtPurchase
        public ActionResult DebtPurchase()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("Report", "DebtPurchase")) return RedirectToAction("Index", "Home");

                    var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_CongNO();
                    ViewBag.list_vendor = list_vendor;

                    #region Year
                    for (int i = 2010; i < (DateTime.Now.Year + 1); i++)
                    {
                        if (DateTime.Now.Year.ToString() == i.ToString())
                            ViewBag.ShowNam += "<option selected value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                        else
                            ViewBag.ShowNam += "<option value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                    }
                    #endregion

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Report", "DebtPurchase");
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DebtPurchase");
                 return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult DebtPurchase_Detail(string KyTinhCongNo, string Nam, string Thang, string NCC)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_CongNO();
                    ViewBag.list_vendor = list_vendor;
                    ViewBag.KyTinhCongNo = KyTinhCongNo;
                    ViewBag.Nam = Nam;
                    ViewBag.Thang = Thang;

                    var list_vendors = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_VendorCode(NCC);
                    if (list_vendors.Count > 0)
                    {
                        ViewBag.NCC = list_vendors[0].Code + " - " + list_vendors[0].Name;
                    }

                    #region Year
                    for (int i = 2010; i < (DateTime.Now.Year + 1); i++)
                    {
                        if (DateTime.Now.Year.ToString() == i.ToString())
                            ViewBag.ShowNam += "<option selected value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                        else
                            ViewBag.ShowNam += "<option value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                    }
                    #endregion

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Report", "DebtPurchase");
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DebtPurchase");
                 return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult GetList_DebtPurchase(string vendorNo, string KyTinhCongNo, string Nam)
        {
            try
            {
                var list_vendors = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_VendorCode(vendorNo);
                if (list_vendors.Count > 0)
                {
                    Session["vendorNo"] = list_vendors[0].Code + " - " + list_vendors[0].Name;
                }
                else
                {
                    Session["vendorNo"] = "";
                }

                System.Data.DataTable table;
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    table = DataAccess.DataAccess.GetList_DebtPurchase(vendorNo, KyTinhCongNo, Nam);
                    var onExp = (from DataRow dr in table.Rows
                                 select new DebtPurchase()
                                 {
                                     PostingDate = dr["PostingDate"].ToString(),
                                     RcptNo = dr["RcptNo"].ToString(),
                                     AmountIncludingVAT = dr["AmountIncludingVAT"].ToString(),
                                     Amount = dr["Amount"].ToString(),
                                     VendorInvoiceNo = dr["VendorInvoiceNo"].ToString(),
                                     GhiChu = dr["GhiChu"].ToString(),
                                     sumAmountIncludingVATDSThang = dr["sumAmountIncludingVATDSThang"].ToString(),
                                     sumAmountIncludingVAT = dr["sumAmountIncludingVAT"].ToString(),
                                     sumAmount = dr["sumAmount"].ToString(),
                                     sumAmountDSThang = dr["sumAmountDSThang"].ToString(),
                                     MinPostingDate = dr["MinPostingDate"].ToString(),
                                     MaxMinPostingDate = dr["MaxMinPostingDate"].ToString(),

                                 }).ToList();

                    Session["onExpDebtPurchase"] = onExp;
                    Session["vendorNos"] = vendorNo;
                    return PartialView("~/Views/Report/Partial/__DebtPurchase_Detaill.cshtml", table);
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult GetList_DebtPurchase_Header(string vendorNo, string KyCongNo, string Nam, string TrangThai)
        {
            try
            {
                System.Data.DataTable table;
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    table = DataAccess.DataAccess.GetList_DebtPurchase_Header(vendorNo, KyCongNo, Nam, TrangThai);
                    return PartialView("~/Views/Report/Partial/__DebtPurchase.cshtml", table);
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult GetList_Debtpurchase_KyTinhCongNo(string vendorNo, string Nam)
        {
            try
            {
                var item = DataAccess.DataAccess.GetList_Debtpurchase_KyTinhCongNo(vendorNo, Nam);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_KyTinhCongNo");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetList_Debtpurchase_InfoVendors(string vendorNo, string KyTinhCongNo, string Nam)
        {
            try
            {
                var item = DataAccess.DataAccess.SP_DEBTPURCHASE_GET_INFO_VENDOR(vendorNo, KyTinhCongNo, Nam);
                if (item.Count > 0)
                {
                    Session["DieuKhoan"] = item[0].DieuKhoanThanhToan;
                    Session["HanThanhToanKyNay"] = item[0].HanThanhToanKyNay;
                    return Json(JsonConvert.SerializeObject(item));
                }
                else
                {
                    Session["DieuKhoan"] = "";
                    Session["HanThanhToanKyNay"] = "";
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
        public ActionResult GetList_Debtpurchase_ApDungCho(string vendorNo)
        {
            try
            {
                var item = DataAccess.DataAccess.GetList_Debtpurchase_ApDungCho(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_ApDungCho");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetList_Debtpurchase_XacNhanNCC(string vendorNo, string KyTinhCongNo, string Nam)
        {
            try
            {
                var item = DataAccess.DataAccess.GetList_Debtpurchase_XacNhanNCC(vendorNo, KyTinhCongNo, Nam);
                if (item.Count > 0)
                {
                    Session["NgayLapDeNghi"] = item[0].NgayLapDeNghi;

                    var list_vendors = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_VendorCode(vendorNo);
                    if (list_vendors.Count > 0)
                    {
                        Session["KyTinhCongNo"] = KyTinhCongNo;
                        Session["Nam"] = Nam;
                    }
                    return Json(JsonConvert.SerializeObject(item));
                }
                else
                {

                    Session["KyTinhCongNo"] = "";
                    Session["Nam"] = "";
                    Session["NgayLapDeNghi"] = DateTime.Now.ToString("dd-MM-yyyy");
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
        public ActionResult GetList_Debtpurchase_XacNhanBBM(string vendorNo, string KyTinhCongNo, string Nam)
        {
            try
            {
                var item = DataAccess.DataAccess.GetList_Debtpurchase_XacNhanBBM(vendorNo, KyTinhCongNo, Nam);
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

        // From Thứ 2
        [HttpPost]
        public ActionResult SP_TRADTERM_LIST_DISCOUNT_SALES_ReportDeposit_CongNo(string vendorNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        {
            try
            {
                var item = DataAccess.DataAccess.SP_TRADTERM_LIST_DISCOUNT_SALES_ReportDeposit_CongNo(vendorNo, TypeTab, SumDoanhSoVAT, SumDoanhSo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui(string vendorNo, string TypeTab, string MinPostingDate, string MaxMinPostingDate)
        {
            try
            {
                var item = DataAccess.DataAccess.SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui(vendorNo, TypeTab, MinPostingDate, MaxMinPostingDate);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01(string vendorNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        {
            try
            {
                var item = DataAccess.DataAccess.SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01(vendorNo, TypeTab, SumDoanhSoVAT, SumDoanhSo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02(string vendorNo, string TypeTab, string SumDoanhSoVATDSThang, string SumDoanhSoDSThang)
        {
            try
            {
                var item = DataAccess.DataAccess.SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02(vendorNo, TypeTab, SumDoanhSoVATDSThang, SumDoanhSoDSThang);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetList_Debtpurchase_TRADEMARKETING(string vendorNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        {
            try
            {
                var item = DataAccess.DataAccess.SP_TRADTERM_LIST_MKT_BONUS_CongNo(vendorNo, TypeTab, SumDoanhSoVAT, SumDoanhSo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_TRADEMARKETING");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult GetList_Debtpurchase_PhatTrienThuongHieu(string vendorNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        {
            try
            {
                var item = DataAccess.DataAccess.SP_TRADTERM_LIST_BRAND_BONUS_CongNo(vendorNo, TypeTab, SumDoanhSoVAT, SumDoanhSo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_PhatTrienThuongHieu");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult GetList_Debtpurchase_PhatTrienKhachHang(string vendorNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo)
        {
            try
            {
                var item = DataAccess.DataAccess.SP_TRADTERM_LIST_CUSTOMER_BONUS_CongNo(vendorNo, TypeTab, SumDoanhSoVAT, SumDoanhSo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_PhatTrienKhachHang");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult GetList_Debtpurchase_ChiPhivanHanh(string vendorNo, string TypeTab, string SumDoanhSoVAT, string SumDoanhSo, string MinPostingDate, string MaxMinPostingDate)
        {
            try
            {
                var item = DataAccess.DataAccess.SP_TRADTERM_LIST_CHIPHIVANHANH_CongNo(vendorNo, TypeTab, SumDoanhSoVAT, SumDoanhSo, MinPostingDate, MaxMinPostingDate);
                if (item.Count > 0)
                {
                    //(9828000*1)/100
                    return Json(JsonConvert.SerializeObject(item));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Debtpurchase_ChiPhivanHanh");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetList_TBL_BBM_ReportDeposit_TradingTem(string VendorNo, string KyCongNo, string Nam, string TypeMien, string TypeBy_NCC_BBM)
        {
            try
            {
                var item = DataAccess.DataAccess.GetList_TBL_BBM_ReportDeposit_TradingTem(VendorNo, KyCongNo, Nam, TypeMien, TypeBy_NCC_BBM);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_TBL_BBM_ReportDeposit_TradingTem");
                return Json(null);
            }
        }


        [HttpPost]
        public ActionResult Save_DebtPurchase_Header_XacNhan(DebtPurchaseSource obj)
        {
            var err = new RouteInfo();
            try
            {
                Guid NewID = Guid.NewGuid();
                var model = JsonConvert.DeserializeObject<List<DebtPurchase_header>>(obj.SourceOrder);
                if (model.Count() > 0)
                {
                    foreach (var item in model)
                    {
                        var result = DataAccess.DataAccess.Save_DebtPurchase_Header_XacNhan(item, Session["uid"].ToString(), NewID.ToString());
                    }
                    err.RespId = 0;
                    err.RespMsg = "Xác nhận đơn hàng thành công";
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
                return Json(ex);
            }
            return Json(err);
        }
        public void ExportExcel_DebtPurchase()
        {
            string Namefile = "Bao_Cao_Cong_No_Hang_Mua_Ban_" + DateTime.Now.ToString("ddMMMyyyy");
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + Namefile + ".xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            sb.Append("<head> <head> <style type=\"text/css\"> .auto-style1 { height: 56.25pt; width: 1154pt; color: windowtext; font-size: 20.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style2 { height: 23.25pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style3 { height: 23.25pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style4 { height: 23.25pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style5 { color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style6 { height: 25.5pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style7 { color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style8 { height: 18.0pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style9 { height: 24.75pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style10 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style11 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style12 { color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style13 { height: 18.0pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style14 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: right; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style15 { height: 20.25pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style16 { color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: right; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style17 { height: 30.75pt; width: 1154pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: italic; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style18 { height: 102.0pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: top; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style19 { color: windowtext; font-size: 11.0pt;  font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: top; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style20 { color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: right; vertical-align: top; white-space: nowrap; border-left: .5pt solid windowtext; border-right-width: medium; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style21 { height: 30.0pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style22 { width: 242pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: top; white-space: normal; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style23 { height: 75.0pt; width: 242pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: italic; text-decoration: underline; font-family: Arial, sans-serif; text-align: general; vertical-align: top; white-space: normal; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style24 { height: 22.5pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style25 { height: 20.25pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style26 { height: 17.25pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style27 { height: 27.0pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: middle; white-space: nowrap; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style28 { height: 22.5pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style29 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style30 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style31 { height: 18.75pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .font5 {color:windowtext; font-size:10.0pt; font-weight:400; font-style:normal; text-decoration:none; font-family:Arial, sans-serif; } .auto-style32 { width: 242pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: top; white-space: normal; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } </style> </head></head>");
            sb.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse:");
            sb.Append(" collapse;width:1154pt\" width=\"1536\">");
            sb.Append("    <colgroup>");
            sb.Append("        <col width=\"39\" />");
            sb.Append("        <col width=\"441\" />");
            sb.Append("        <col width=\"194\" />");
            sb.Append("        <col width=\"200\" />");
            sb.Append("        <col width=\"134\" />");
            sb.Append("        <col width=\"206\" />");
            sb.Append("        <col width=\"126\" />");
            sb.Append("        <col width=\"64\" />");
            sb.Append("        <col width=\"132\" />");
            sb.Append("    </colgroup>");
            sb.Append("    <tr height=\"75\">");
            sb.Append("        <td class=\"auto-style1\" colspan=\"9\" height=\"75\" width=\"1536\"><span style=\"mso-spacerun:yes\">&nbsp;</span>CÔNG NỢ HÀNG MUA BÁN<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\">");
            sb.Append("        <td class=\"auto-style2\" colspan=\"9\" height=\"31\">Họ và tên: " + Session["Admin"] + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\">");
            sb.Append("        <td class=\"auto-style2\" colspan=\"9\" height=\"31\">Ngày lập đơn đề nghị:  " + Session["NgayLapDeNghi"] + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\">");
            sb.Append("        <td class=\"auto-style3\" colspan=\"9\" height=\"31\">Tên NCC: " + Session["vendorNo"].ToString() + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\">");
            sb.Append("        <td class=\"auto-style2\" colspan=\"9\" height=\"31\">Kỳ tính công nợ:  Tháng " + Session["KyTinhCongNo"] + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\">");
            sb.Append("        <td class=\"auto-style2\" colspan=\"9\" height=\"31\">Điều khoản thanh toán:  " + Session["DieuKhoan"] + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\">");
            sb.Append("        <td class=\"auto-style2\" colspan=\"9\" height=\"31\">Hạn thanh toán kỳ này: " + Session["HanThanhToanKyNay"] + "</td>");
            sb.Append("    </tr>");

            sb.Append("    <tr height=\"31\">");
            sb.Append("        <td class=\"auto-style4\" height=\"31\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"34\">");
            sb.Append("        <td class=\"auto-style6\" height=\"34\">TT</td>");
            sb.Append("        <td class=\"auto-style7\">Ngày nhập kho</td>");
            sb.Append("        <td class=\"auto-style7\"><span style=\"mso-spacerun:yes\">&nbsp;</span>Số PNK<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("        <td class=\"auto-style7\"><span style=\"mso-spacerun:yes\">&nbsp;</span>Giá trị nhập kho<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("        <td class=\"auto-style7\"><span style=\"mso-spacerun:yes\">&nbsp;</span>Giá trị hóa đơn<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("        <td class=\"auto-style7\">Ngày HĐ</td>");
            sb.Append("        <td class=\"auto-style7\">Số Hóa đơn</td>");
            sb.Append("        <td class=\"auto-style7\">CL</td>");
            sb.Append("        <td class=\"auto-style7\">Ghi chú</td>");
            sb.Append("    </tr>");

            int i = 1;
            Double TotlaAmountIncludingVAT = 0;
            Double TotlsumAmount = 0;
            string sumAmountIncludingVATDSThang = "0";
            string sumAmountDSThang = "0";
            string MinPostingDate = "";
            string MaxMinPostingDate = "";

            List<DebtPurchase> Litem = (List<DebtPurchase>)Session["onExpDebtPurchase"];
            if (Litem.Count > 0)
            {
                sumAmountIncludingVATDSThang = Litem[0].sumAmountIncludingVATDSThang;
                sumAmountDSThang = Litem[0].sumAmountDSThang;

                MinPostingDate = Litem[0].MinPostingDate;
                MaxMinPostingDate = Litem[0].MaxMinPostingDate;
                foreach (var item in Litem)
                {
                    sb.Append("    <tr height=\"24\">");
                    sb.Append("        <td class=\"auto-style8\" height=\"24\">" + i + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + item.PostingDate + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + item.RcptNo + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + item.AmountIncludingVAT + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + item.AmountIncludingVAT + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + item.PostingDate + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + item.VendorInvoiceNo + "</td>");
                    sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
                    sb.Append("        <td class=\"auto-style5\">" + item.GhiChu + "</td>");
                    sb.Append("    </tr>");
                    TotlaAmountIncludingVAT += Convert.ToDouble(item.AmountIncludingVAT.Replace(",", ""));
                    TotlsumAmount += Convert.ToDouble(item.Amount.Replace(",", ""));
                    i++;
                }
            }
            sb.Append("    <tr height=\"33\">");
            sb.Append("        <td class=\"auto-style9\" height=\"33\">I</td>");
            sb.Append("        <td class=\"auto-style10\" colspan=\"2\">TỔNG CỘNG </td>");
            sb.Append("        <td class=\"auto-style11\"><span style=\"mso-spacerun:yes\">&nbsp;</span>" + Commond.FormatMoney_VND(TotlaAmountIncludingVAT.ToString()) + "<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("        <td class=\"auto-style11\"><span style=\"mso-spacerun:yes\">&nbsp;</span>" + Commond.FormatMoney_VND(TotlaAmountIncludingVAT.ToString()) + "<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("    </tr>");


            // chiết khấu 

            int k = 1;
            Double Total = 0;
            var item01 = DataAccess.DataAccess.SP_TRADTERM_LIST_DISCOUNT_SALES_KyGui(Session["vendorNos"].ToString(), "1", MinPostingDate, MaxMinPostingDate);
            if (item01.Count > 0)
            {
                foreach (var item in item01)
                {
                    Total += Convert.ToDouble(item.Total.Replace(",", ""));
                    string Tongs = item.Total;
                    sb.Append("    <tr height=\"24\">");
                    sb.Append("        <td class=\"auto-style8\" height=\"24\">" + k + "</td>");
                    sb.Append("        <td class=\"auto-style5\" colspan=\"2\" >" + item.Name + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tongs.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tongs.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("    </tr>");
                    k++;
                }
            }
            //THƯỞNG 1
            var item022 = DataAccess.DataAccess.SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01(Session["vendorNos"].ToString(), "1", TotlaAmountIncludingVAT.ToString(), TotlsumAmount.ToString());
            if (item022.Count > 0)
            {
                foreach (var item in item022)
                {
                    Total += Convert.ToDouble(item.Total.Replace(",", ""));
                    string Tongs = item.Total;
                    sb.Append("    <tr height=\"24\">");
                    sb.Append("        <td class=\"auto-style8\" height=\"24\">" + k + "</td>");
                    sb.Append("        <td class=\"auto-style5\" colspan=\"2\" >" + item.Name + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tongs.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tongs.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("    </tr>");
                    k++;
                }
            }
            //THƯỞNG 2
            var item023 = DataAccess.DataAccess.SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02(Session["vendorNos"].ToString(), "1", sumAmountIncludingVATDSThang, sumAmountDSThang);
            if (item023.Count > 0)
            {
                foreach (var item in item023)
                {
                    Total += Convert.ToDouble(item.Total.Replace(",", ""));
                    string Tongs = item.Total;
                    sb.Append("    <tr height=\"24\">");
                    sb.Append("        <td class=\"auto-style8\" height=\"24\">" + k + "</td>");
                    sb.Append("        <td class=\"auto-style5\" colspan=\"2\" >" + item.Name + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tongs.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tongs.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("    </tr>");
                    k++;
                }
            }

            // markerting
            var item1 = DataAccess.DataAccess.SP_TRADTERM_LIST_MKT_BONUS_CongNo(Session["vendorNos"].ToString(), "1", TotlaAmountIncludingVAT.ToString(), TotlsumAmount.ToString());
            if (item1.Count > 0)
            {
                foreach (var item in item1)
                {
                    string Tong = item.Total;
                    sb.Append("    <tr height=\"24\">");
                    sb.Append("        <td class=\"auto-style8\" height=\"24\">" + k + "</td>");
                    sb.Append("        <td class=\"auto-style5\" colspan=\"2\" >" + item.Name + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tong.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tong.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("    </tr>");
                    Total += Convert.ToDouble(item.Total.Replace(",", ""));
                    k++;
                }
            }

            //PhatTrienThuongHieu
            var item2 = DataAccess.DataAccess.SP_TRADTERM_LIST_BRAND_BONUS_CongNo(Session["vendorNos"].ToString(), "1", TotlaAmountIncludingVAT.ToString(), TotlsumAmount.ToString());
            if (item2.Count > 0)
            {
                foreach (var item in item2)
                {
                    string Tong = item.Total;
                    sb.Append("    <tr height=\"24\">");
                    sb.Append("        <td class=\"auto-style8\" height=\"24\">" + k + "</td>");
                    sb.Append("        <td class=\"auto-style5\" colspan=\"2\" >" + item.Name + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tong.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tong.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("    </tr>");
                    Total += Convert.ToDouble(item.Total.Replace(",", ""));
                    k++;
                }
            }
            var item3 = DataAccess.DataAccess.SP_TRADTERM_LIST_CUSTOMER_BONUS_CongNo(Session["vendorNos"].ToString(), "1", TotlaAmountIncludingVAT.ToString(), TotlsumAmount.ToString());
            if (item3.Count > 0)
            {
                foreach (var item in item3)
                {
                    string Tong = item.Total;
                    sb.Append("    <tr height=\"24\">");
                    sb.Append("        <td class=\"auto-style8\" height=\"24\">" + k + "</td>");
                    sb.Append("        <td class=\"auto-style5\" colspan=\"2\" >" + item.Name + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tong.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tong.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("    </tr>");
                    Total += Convert.ToDouble(item.Total.Replace(",", ""));
                    k++;
                }
            }
            var item4 = DataAccess.DataAccess.SP_TRADTERM_LIST_CHIPHIVANHANH_CongNo(Session["vendorNos"].ToString(), "1", TotlaAmountIncludingVAT.ToString(), TotlsumAmount.ToString(), MinPostingDate, MaxMinPostingDate);
            if (item4.Count > 0)
            {
                foreach (var item in item4)
                {
                    string Tong = item.Total;
                    sb.Append("    <tr height=\"24\">");
                    sb.Append("        <td class=\"auto-style8\" height=\"24\">" + k + "</td>");
                    sb.Append("        <td class=\"auto-style5\" colspan=\"2\" >" + item.Name + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tong.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\">" + (Tong.ToString()) + "</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
                    sb.Append("        <td class=\"auto-style5\"></td>");
                    sb.Append("    </tr>");
                    Total += Convert.ToDouble(item.Total.Replace(",", ""));
                    k++;
                }
            }
            sb.Append("    <tr height=\"24\">");
            sb.Append("        <td class=\"auto-style8\" height=\"24\"><b>II</b></td>");
            sb.Append("        <td class=\"auto-style5\" colspan=\"2\" ><b>TỔNG CHIẾT KHẤU</b></td>");
            sb.Append("        <td class=\"auto-style5\"><b>" + Commond.FormatMoney_VND(Total.ToString()) + " </b></td>");
            sb.Append("        <td class=\"auto-style5\"><b>" + Commond.FormatMoney_VND(Total.ToString()) + " </b></td>");
            sb.Append("        <td class=\"auto-style5\"></td>");
            sb.Append("        <td class=\"auto-style5\"></td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\"></td>");
            sb.Append("    </tr>");

            sb.Append("    <tr height=\"41\">");
            sb.Append("        <td class=\"auto-style17\" colspan=\"9\" height=\"41\" width=\"1536\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"136\">");
            sb.Append("        <td class=\"auto-style18\" colspan=\"2\" height=\"136\">Người đề nghị</td>");
            sb.Append("        <td class=\"auto-style19\" colspan=\"2\"><span style=\"mso-spacerun:yes\">&nbsp;</span>Trưởng phòng KTCN<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("        <td class=\"auto-style20\" colspan=\"2\"><span style=\"mso-spacerun:yes\">&nbsp;</span>K/T Kế toán trưởng<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("        <td class=\"auto-style20\" colspan=\"3\">Giám đốc</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"20\">");
            sb.Append("        <td class=\"auto-style21\" colspan=\"6\" height=\"40\">Thông tin chuyển khoản</td>");
            sb.Append("        <td class=\"auto-style32\" colspan=\"3\" rowspan=\"4\" width=\"322\">Kế Toán Thanh Toán<br />");
            sb.Append("            <font class=\"font5\">(Ký, ghi rõ họ tên)</font></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"30\">");
            sb.Append("        <td class=\"auto-style24\" colspan=\"2\" height=\"30\">Tên người hưởng thụ: --</td>");
            sb.Append("        <td class=\"auto-style5\" colspan=\"4\"><span style=\"mso-spacerun:yes\">&nbsp;</span>…<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"27\">");
            sb.Append("        <td class=\"auto-style25\" colspan=\"2\" height=\"27\">Số tài khoản: --</td>");
            sb.Append("        <td class=\"auto-style5\" colspan=\"4\"><span style=\"mso-spacerun:yes\">&nbsp;</span>…<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"23\">");
            sb.Append("        <td class=\"auto-style26\" colspan=\"2\" height=\"23\">Tên ngân hàng: --</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"4\"><span style=\"mso-spacerun:yes\">&nbsp;</span>Chi nhánh: --<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"36\">");
            sb.Append("        <td class=\"auto-style27\" colspan=\"9\" height=\"36\">List Hồ sơ:</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"30\">");
            sb.Append("        <td class=\"auto-style28\" height=\"30\">STT</td>");
            sb.Append("        <td class=\"auto-style29\" colspan=\"2\">TÊN CHỨNG TỪ</td>");
            sb.Append("        <td class=\"auto-style29\" colspan=\"2\">ĐỦ</td>");
            sb.Append("        <td class=\"auto-style30\">THIẾU</td>");
            sb.Append("        <td class=\"auto-style29\" colspan=\"3\">LÝ DO</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"25\">");
            sb.Append("        <td class=\"auto-style31\" height=\"25\">1</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">Biên bản đối chiếu công nợ với NCC</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"3\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"25\">");
            sb.Append("        <td class=\"auto-style31\" height=\"25\">2</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">Purchase invoice + P credit Memo (nếu có)</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"3\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"25\">");
            sb.Append("        <td class=\"auto-style31\" height=\"25\">3</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">Phiếu nhập kho</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"3\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"25\">");
            sb.Append("        <td class=\"auto-style31\" height=\"25\">4</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">Phiếu giao hàng hoặc biên bản giao hàng của NCC</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"3\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"25\">");
            sb.Append("        <td class=\"auto-style31\" height=\"25\">5</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">Hóa đơn NCC xuất</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"3\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"25\">");
            sb.Append("        <td class=\"auto-style31\" height=\"25\">6</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">Hóa đơn BBM xuất chiết khấu</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"2\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style5\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style12\" colspan=\"3\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion

        #region ReportDeposit
        public ActionResult ReportDeposit()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (!Constants.checkpermission("Report", "ReportDeposit")) return RedirectToAction("Index", "Home");

                    var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor();
                    ViewBag.list_vendor = list_vendor;

                    #region Year
                    for (int i = 2021; i < (DateTime.Now.Year + 1); i++)
                    {
                        if (DateTime.Now.Year.ToString() == i.ToString())
                            ViewBag.ShowNam += "<option selected value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                        else
                            ViewBag.ShowNam += "<option value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                    }
                    #endregion

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Report", "ReportDeposit");
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ReportDeposit");
                 return RedirectToAction("Index", "Home");
            }
        }

        //[HttpPost]
        //public ActionResult GetList_ReportDeposit(string MaHang, string Thang)
        //{
        //    try
        //    {
        //        System.Data.DataTable table;
        //        if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
        //        {
        //            if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
        //            {
        //                table = DataAccess.DataAccess.SP_ThuongDinhHuong_vendorNo_GET_LIST(MaHang, Thang, Session["VendorCode"].ToString());
        //            }
        //            else
        //            {
        //                table = DataAccess.DataAccess.SP_ThuongDinhHuong_vendorNo_GET_LIST(MaHang, Thang, "");
        //            }
        //            var onExp = (from DataRow dr in table.Rows
        //                         select new obj_ThuongDinhHuong()
        //                         {
        //                             MaHang = dr["MaHang"].ToString(),
        //                             Tenhang = dr["Tenhang"].ToString(),
        //                             QuantityMB = dr["QuantityMB"].ToString(),
        //                             QuantityMN = dr["QuantityMN"].ToString(),
        //                             SLTong = dr["SLTong"].ToString(),
        //                             AmountMN = dr["AmountMN"].ToString()
        //                         }).ToList();
        //            Session["onExpThuongDinhHuong"] = onExp;
        //            if (Thang != "")
        //                return PartialView("~/Views/Report/Partial/__ReportDeposit.cshtml", table);
        //            else
        //                return PartialView("~/Views/Report/Partial/__ReportDeposit.cshtml", null);
        //        }
        //        else
        //        {
        //             return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM");
        //        return Json(null);
        //    }
        //    return RedirectToAction("Login", "Account");
        //}

        #endregion

        #region ReportDepositDetail
        public ActionResult ReportDepositDetail(string KyTinhCongNo, string Nam, string Thang, string NCC)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_ReportDeposit_KyGui();
                    ViewBag.list_vendor = list_vendor;

                    if (KyTinhCongNo != "")
                    {
                        ViewBag.KyTinhCongNo = KyTinhCongNo;
                        Session["ShowEdit"] = NCC + ";" + KyTinhCongNo + ";" + Nam;
                    }
                    else
                    {
                        Session["ShowEdit"] = "";
                    }

                    ViewBag.Nam = Nam;
                    ViewBag.Thang = Thang;

                    var list_vendors = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_VendorCode(NCC);
                    if (list_vendors.Count > 0)
                    {
                        ViewBag.NCC = list_vendors[0].Code + " - " + list_vendors[0].Name;
                    }

                    #region Year
                    for (int i = 2010; i < (DateTime.Now.Year + 1); i++)
                    {
                        if (DateTime.Now.Year.ToString() == i.ToString())
                            ViewBag.ShowNam += "<option selected value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                        else
                            ViewBag.ShowNam += "<option value=\"" + i.ToString() + "\">Năm " + i.ToString() + "</option>";
                    }
                    #endregion

                    return View();
                }
                else
                {
                    SystemFunctions.SaveSession("Report", "ReportDeposit");
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ReportDeposit");
                 return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult GetList_ReportDepositDetail(string vendorNo, string KyTinhCongNo, string Nam, string Thang)
        {
            try
            {
                var list_vendors = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_VendorCode(vendorNo);
                if (list_vendors.Count > 0)
                {
                    Session["vendorNo"] = list_vendors[0].Code + " - " + list_vendors[0].Name;
                }
                else
                {
                    Session["vendorNo"] = "";
                }

                System.Data.DataTable table;
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    table = DataAccess.DataAccess.GetList_ReportDepositDetail(vendorNo, KyTinhCongNo, Nam, Thang);
                    var onExp = (from DataRow dr in table.Rows
                                 select new Obj_ReportDeposit()
                                 {
                                     MaHang = dr["MaHang"].ToString(),
                                     Tenhang = dr["Tenhang"].ToString(),
                                     Ton_DK = dr["Ton_DK"].ToString(),
                                     QuantityMB = dr["QuantityMB"].ToString(),
                                     QuantityMN = dr["QuantityMN"].ToString(),
                                     Nhap = dr["Nhap"].ToString(),
                                     XuatTra = dr["XuatTra"].ToString(),
                                     Ton_CK = dr["Ton_CK"].ToString(),
                                     Giaban = dr["Giaban"].ToString(),
                                     AmountMB = dr["AmountMB"].ToString(),
                                     AmountMN = dr["AmountMN"].ToString(),
                                     GhiChu = dr["GhiChu"].ToString(),
                                     SumDoanhSoVAT = dr["SumDoanhSoVAT"].ToString(),

                                     SumTon_DK = dr["SumTon_DK"].ToString(),
                                     SumQuantityMB = dr["SumQuantityMB"].ToString(),
                                     SumQuantityMN = dr["SumQuantityMN"].ToString(),
                                     SumNhap = dr["SumNhap"].ToString(),
                                     SumXuatTra = dr["SumXuatTra"].ToString(),
                                     SumTon_CK = dr["SumTon_CK"].ToString(),
                                     SumGiaban = dr["SumGiaban"].ToString(),
                                     SumAmountMB = dr["SumAmountMB"].ToString(),
                                     SumAmountMN = dr["SumAmountMN"].ToString(),
                                 }).ToList();
                    Session["onExpReportDeposit"] = onExp;
                    Session["vendorNos"] = vendorNo.Split('-')[0].ToString();
                    return PartialView("~/Views/Report/Partial/__ReportDepositDetail.cshtml", table);
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult GetList_ReportDeposit_KyTinhCongNo(string vendorNo, string Nam)
        {
            try
            {
                var item = DataAccess.DataAccess.GetList_ReportDeposit_KyTinhCongNo(vendorNo, Nam);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_KyTinhCongNo");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetList_ReportDeposit_NgayBan(string vendorNo, string Nam)
        {
            try
            {
                var item = DataAccess.DataAccess.GetList_ReportDeposit_NgayBan(vendorNo, Nam);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_NgayBan");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult SP_ReportDeposit_GET_INFO_VENDOR(string vendorNo, string KyTinhCongNo, string Nam)
        {
            try
            {
                var item = DataAccess.DataAccess.SP_ReportDeposit_GET_INFO_VENDOR(vendorNo, KyTinhCongNo, Nam);
                if (item.Count > 0)
                {
                    Session["DieuKhoan"] = item[0].DieuKhoanThanhToan;
                    Session["HanThanhToanKyNay"] = item[0].HanThanhToanKyNay;
                    return Json(JsonConvert.SerializeObject(item));
                }
                else
                {
                    Session["DieuKhoan"] = "";
                    Session["HanThanhToanKyNay"] = "";
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ReportDeposit_GET_INFO_VENDOR");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult GetList_ReportDeposit_ApDungCho(string vendorNo)
        {
            try
            {
                var item = DataAccess.DataAccess.GetList_ReportDeposit_ApDungCho(vendorNo);
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_ApDungCho");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult Save_ReportDeposit_Header_XacNhan_NCC(DebtPurchaseSource obj)
        {
            var err = new RouteInfo();
            try
            {
                Guid NewID = Guid.NewGuid();
                var model = JsonConvert.DeserializeObject<List<ReportDeposit_header>>(obj.SourceOrder);
                var modelMB = JsonConvert.DeserializeObject<List<ReportDeposit_TradingTemMienBN>>(obj.SourceMienBac);
                var modelMN = JsonConvert.DeserializeObject<List<ReportDeposit_TradingTemMienBN>>(obj.SourceMienNam);
                if (modelMB.Count() > 0)
                {
                    foreach (var item in modelMB)
                    {
                        var result = DataAccess.DataAccess.Save_ReportDeposit_TradingTem(item, Session["uid"].ToString());
                    }
                }
                if (modelMN.Count() > 0)
                {
                    foreach (var item in modelMN)
                    {
                        var result = DataAccess.DataAccess.Save_ReportDeposit_TradingTem(item, Session["uid"].ToString());
                    }
                }
                if (model.Count() > 0)
                {
                    foreach (var item in model)
                    {
                        var result = DataAccess.DataAccess.Save_ReportDeposit_Header_XacNhan_NCC(item, Session["uid"].ToString(), NewID.ToString());
                    }
                    err.RespId = 0;
                    err.RespMsg = "Xác nhận đơn hàng thành công";
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
                return Json(ex);
            }
            return Json(err);
        }
        public ActionResult GetList_ReportDeposit_XacNhanBBM(string vendorNo, string KyTinhCongNo, string Nam)
        {
            try
            {
                var item = DataAccess.DataAccess.GetList_ReportDeposit_XacNhanBBM(vendorNo, KyTinhCongNo, Nam);
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
        public ActionResult GetList_ReportDeposit_XacNhanNCC(string vendorNo, string KyTinhCongNo, string Nam)
        {
            try
            {
                var item = DataAccess.DataAccess.GetList_ReportDeposit_XacNhanNCC(vendorNo, KyTinhCongNo, Nam);
                if (item.Count > 0)
                {
                    Session["ShowEditBBM"] = "Show";
                    Session["NgayLapDeNghi"] = item[0].NgayLapDeNghi;
                    var list_vendors = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_VendorCode(vendorNo);
                    if (list_vendors.Count > 0)
                    {
                        Session["KyTinhCongNo"] = KyTinhCongNo;
                        Session["Nam"] = Nam;
                    }
                    return Json(JsonConvert.SerializeObject(item));
                }
                else
                {
                    Session["ShowEditBBM"] = null;
                    Session["KyTinhCongNo"] = "";
                    Session["Nam"] = "";
                    Session["NgayLapDeNghi"] = DateTime.Now.ToString("dd-MM-yyyy");
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_ReportDeposit_XacNhanNCC");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetList_ReportDeposit_Header(string vendorNo, string KyCongNo, string Nam, string TrangThai)
        {
            try
            {
                System.Data.DataTable table;
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    table = DataAccess.DataAccess.GetList_ReportDeposit_Header(vendorNo, KyCongNo, Nam, TrangThai);
                    return PartialView("~/Views/Report/Partial/__ReportDeposit.cshtml", table);
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CTKM");
                return Json(null);
            }
            return RedirectToAction("Login", "Account");
        }
        public void ExportExcel_ReportDeposit()
        {
            string Namefile = "Bao_Cao_Cong_No_Ky_Gui_" + DateTime.Now.ToString("ddMMMyyyy");
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + Namefile + ".xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            sb.Append("<head> <style type=\"text/css\"> .font5 {color:windowtext; font-size:10.0pt; font-weight:700; font-style:italic; text-decoration:none; font-family:Arial, sans-serif; } .auto-style1 { height: 56.25pt; width: 1048pt; color: windowtext; font-size: 20.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style2 { height: 23.25pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style3 { height: 23.25pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style4 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style5 { height: 23.25pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: left; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style6 { height: 69.75pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style7 { color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style8 { color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style9 { width: 84pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style10 { width: 74pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style11 { width: 72pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style12 { width: 67pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style13 { width: 71pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style14 { width: 82pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style15 { width: 68pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style16 { width: 108pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style17 { width: 125pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style18 { height: 18.0pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style19 { color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style20 { color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style21 { height: 24.75pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style22 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style23 { height: 24.75pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style24 { height: 18.0pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: top; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style25 { height: 31.5pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style26 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style27 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style28 { width: 125pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: normal; border-left: .5pt solid windowtext; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style29 { height: 24.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style30 { color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style31 { color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style32 { color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style33 { height: 25.5pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style34 { height: 20.25pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style35 { color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style36 { color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style37 { color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style38 { color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right: .5pt solid windowtext; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style39 { height: 24.0pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style40 { height: 21.0pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style41 { height: 19.5pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: top; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style42 { color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: top; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style43 { color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: top; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style44 { height: 97.5pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: top; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style45 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: top; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style46 { height: 19.5pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: top; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style47 { height: 20.25pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style48 { width: 233pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: top; white-space: normal; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style49 { height: 25.5pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style50 { height: 24.0pt; color: windowtext; font-size: 11.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: general; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style51 { height: 24.0pt; color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style52 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border-left: .5pt solid windowtext; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top: .5pt solid windowtext; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style53 { color: windowtext; font-size: 10.0pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #D9D9D9; } .auto-style54 { height: 22.5pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style55 { height: 20.25pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } .auto-style56 { height: 17.25pt; color: windowtext; font-size: 10.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial, sans-serif; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; } </style> </head>");
            sb.Append(" <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse:");
            sb.Append(" collapse;width:1048pt\" width=\"1397\">");
            sb.Append("    <colgroup>");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:1426;width:29pt\" width=\"39\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:3949;width:81pt\" width=\"108\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:9106;width:187pt\" width=\"249\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:4096;width:84pt\" width=\"112\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:3620;width:74pt\" width=\"99\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:3510;width:72pt\" width=\"96\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:3254;width:67pt\" width=\"89\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:3474;width:71pt\" width=\"95\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:3986;width:82pt\" width=\"109\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:3328;width:68pt\" width=\"91\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:5266;width:108pt\" width=\"144\" />");
            sb.Append("        <col style=\"mso-width-source:userset;mso-width-alt:6070;width:125pt\" width=\"166\" />");
            sb.Append("    </colgroup>");

            sb.Append("    <tr height=\"75\" style=\"mso-height-source:userset;height:56.25pt\">");
            sb.Append("        <td class=\"auto-style1\" colspan=\"12\" height=\"75\" width=\"1397\"><span style=\"mso-spacerun:yes\">&nbsp;</span>CÔNG NỢ KÝ GỬI<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\" style=\"mso-height-source:userset;height:23.25pt\">");
            sb.Append("        <td class=\"auto-style2\" colspan=\"12\" height=\"31\">Họ và tên: " + Session["Admin"] + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\" style=\"mso-height-source:userset;height:23.25pt\">");
            sb.Append("        <td class=\"auto-style3\" colspan=\"6\" height=\"31\">Ngày lập đơn đề nghị:  " + Session["NgayLapDeNghi"] + "</td>");
            sb.Append("        <td class=\"auto-style4\" colspan=\"6\">Mã NCC:" + Session["vendorNos"].ToString() + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\" style=\"mso-height-source:userset;height:23.25pt\">");
            sb.Append("        <td class=\"auto-style5\" colspan=\"12\" height=\"31\">Tên NCC: " + Session["vendorNo"].ToString() + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\" style=\"mso-height-source:userset;height:23.25pt\">");
            sb.Append("        <td class=\"auto-style2\" colspan=\"12\" height=\"31\">Điều khoản thanh toán:  " + Session["DieuKhoan"] + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\" style=\"mso-height-source:userset;height:23.25pt\">");
            sb.Append("        <td class=\"auto-style2\" colspan=\"12\" height=\"31\">Kỳ tính công nợ:  " + Session["KyTinhCongNo"] + "<td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\" style=\"mso-height-source:userset;height:23.25pt\">");
            sb.Append("        <td class=\"auto-style2\" colspan=\"12\" height=\"31\">Hạn thanh toán kỳ này:" + Session["HanThanhToanKyNay"] + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\" style=\"mso-height-source:userset;height:23.25pt\">");
            sb.Append("        <td class=\"auto-style2\" colspan=\"12\" height=\"31\">&nbsp;</td>");
            sb.Append("    </tr>");


            sb.Append("    <tr height=\"31\" style=\"mso-height-source:userset;height:23.25pt\">");
            sb.Append("        <td class=\"auto-style5\" colspan=\"12\" height=\"31\">I. Nhập - Xuất - Tồn trong kỳ</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"31\" style=\"mso-height-source:userset;height:23.25pt\">");
            sb.Append("        <td class=\"auto-style6\" height=\"93\">TT</td>");
            sb.Append("        <td class=\"auto-style7\">Mã hàng</td>");
            sb.Append("        <td class=\"auto-style8\"><span style=\"mso-spacerun:yes\">&nbsp;</span>Tên hàng<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("        <td class=\"auto-style9\" width=\"112\"><span style=\"mso-spacerun:yes\">&nbsp;</span>SL tồn<br />");
            sb.Append("            Đầu</td>");
            sb.Append("        <td class=\"auto-style10\" width=\"99\">SL<br />");
            sb.Append("            bán<br />");
            sb.Append("            HN</td>");
            sb.Append("        <td class=\"auto-style11\" width=\"96\">SL<br />");
            sb.Append("            bán<br />");
            sb.Append("            HCM</td>");
            sb.Append("        <td class=\"auto-style12\" width=\"89\">SL<br />");
            sb.Append("            nhập</td>");
            sb.Append("        <td class=\"auto-style13\" width=\"95\">SL<br />");
            sb.Append("            Trả</td>");
            sb.Append("        <td class=\"auto-style14\" width=\"109\">SL tồn kỳ cuối</td>");
            sb.Append("        <td class=\"auto-style15\" width=\"91\">Đơn giá bán Trong kỳ</td>");
            sb.Append("        <td class=\"auto-style16\" width=\"144\">Thành tiền<br />");
            sb.Append("            <span style=\"mso-spacerun:yes\">&nbsp;</span>(+VAT) MB</td>");
            sb.Append("        <td class=\"auto-style17\" width=\"166\">Thành tiền<br />");
            sb.Append("            (+VAT) MN</td>");
            sb.Append("    </tr>");


            int i = 1;
            string SumDoanhSoVAT = "0";
            string SumTon_DK = "0";
            string SumQuantityMB = "0";
            string SumQuantityMN = "0";
            string SumNhap = "0";
            string SumXuatTra = "0";
            string SumTon_CK = "0";
            string SumGiaban = "0";
            string SumAmountMB = "0";
            string SumAmountMN = "0";

            string MinPostingDate = "";
            string MaxMinPostingDate = "";

            List<Obj_ReportDeposit> Litem = (List<Obj_ReportDeposit>)Session["onExpReportDeposit"];
            if (Litem.Count > 0)
            {
                SumDoanhSoVAT = Litem[0].SumDoanhSoVAT.Replace(",", "");
                SumTon_DK = Litem[0].SumTon_DK;
                SumQuantityMB = Litem[0].SumQuantityMB;
                SumQuantityMN = Litem[0].SumQuantityMN;
                SumNhap = Litem[0].SumNhap;
                SumXuatTra = Litem[0].SumXuatTra;
                SumTon_CK = Litem[0].SumTon_CK;
                SumGiaban = Litem[0].SumGiaban;
                SumAmountMB = Litem[0].SumAmountMB;
                SumAmountMN = Litem[0].SumAmountMN;

                MinPostingDate = Litem[0].MinNgayBan;
                MaxMinPostingDate = Litem[0].MaxNgayBan;

                foreach (var item in Litem)
                {
                    sb.Append("    <tr height=\"24\" style=\"mso-height-source:userset;height:18.0pt\">");
                    sb.Append("        <td class=\"auto-style18\" height=\"24\">" + i + "</td>");
                    sb.Append("        <td class=\"auto-style19\">" + item.MaHang + "</td>");
                    sb.Append("        <td class=\"auto-style20\">" + item.Tenhang + "</td>");
                    sb.Append("        <td class=\"auto-style20\">" + item.Ton_DK + "</td>");
                    sb.Append("        <td class=\"auto-style20\">" + item.QuantityMB + "</td>");
                    sb.Append("        <td class=\"auto-style20\">" + item.QuantityMN + "</td>");
                    sb.Append("        <td class=\"auto-style20\">" + item.Nhap + "</td>");
                    sb.Append("        <td class=\"auto-style20\">" + item.XuatTra + "</td>");
                    sb.Append("        <td class=\"auto-style20\">" + item.Ton_CK + "</td>");
                    sb.Append("        <td class=\"auto-style20\">" + item.Giaban + "</td>");
                    sb.Append("        <td class=\"auto-style20\">" + item.AmountMB + "</td>");
                    sb.Append("        <td class=\"auto-style20\">" + item.AmountMN + "</td>");
                    sb.Append("    </tr>");
                    i++;
                }
                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style21\" colspan=\"3\" height=\"33\" style=\"float: left; text - align: left\">TỔNG CỘNG</td>");
                sb.Append("        <td class=\"auto-style22\"><span style=\"mso-spacerun:yes\">" + SumTon_DK + "</span></td>");
                sb.Append("        <td class=\"auto-style22\"><span style=\"mso-spacerun:yes\">" + SumQuantityMB + "</span></td>");
                sb.Append("        <td class=\"auto-style22\"><span style=\"mso-spacerun:yes\">" + SumQuantityMN + "</span></td>");
                sb.Append("        <td class=\"auto-style22\"><span style=\"mso-spacerun:yes\">" + SumNhap + "</span></td>");
                sb.Append("        <td class=\"auto-style22\"><span style=\"mso-spacerun:yes\">" + SumXuatTra + "</span></td>");
                sb.Append("        <td class=\"auto-style22\"><span style=\"mso-spacerun:yes\">" + SumTon_CK + "</span></td>");
                sb.Append("        <td class=\"auto-style22\"><span style=\"mso-spacerun:yes\">" + SumGiaban + "</span></td>");
                sb.Append("        <td class=\"auto-style22\"><span style=\"mso-spacerun:yes\">" + SumAmountMB + "</span></td>");
                sb.Append("        <td class=\"auto-style22\"><span style=\"mso-spacerun:yes\">" + SumAmountMN + "</span></td>");
                sb.Append("    </tr>");
            }

            sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
            sb.Append("        <td class=\"auto-style23\" colspan=\"12\" height=\"33\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"24\" style=\"mso-height-source:userset;height:18.0pt\">");
            sb.Append("        <td class=\"auto-style24\" colspan=\"12\" height=\"24\">II. THANH TOÁN</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"21\" style=\"mso-height-source:userset;height:15.75pt\">");
            sb.Append("        <td class=\"auto-style25\" height=\"42\">STT</td>");
            sb.Append("        <td class=\"auto-style26\" colspan=\"5\">Nội dung</td>");
            sb.Append("        <td class=\"auto-style28\" >Số tiền BBM</td>");
            sb.Append("        <td class=\"auto-style28\" >Số tiền HĐ	</td>");
            sb.Append("        <td class=\"auto-style28\" >Số HĐ	</td>");
            sb.Append("        <td class=\"auto-style28\" >Ngày HĐ	</td>");
            sb.Append("        <td class=\"auto-style28\" colspan=\"2\" >Ghi chú</td>");
            sb.Append("    </tr>");

            SumAmountMB = SumAmountMB.Replace(",", "");
            SumAmountMN = SumAmountMN.Replace(",", "");

            // chưa làm phần đã xác nhận . call edit lên
            if (Session["ShowEdit"] != null && Session["ShowEdit"].ToString().Length > 0 && Session["ShowEditBBM"] != null && Session["ShowEditBBM"].ToString().Length > 0)
            {
                #region ShowAll_TradingTemMB
                // chiết khấu 
                int L1 = 1;
                Double TotalE1 = 0;
                string Edit = Session["ShowEdit"].ToString();
                var itemE1 = DataAccess.DataAccess.GetList_TBL_BBM_ReportDeposit_TradingTem(Edit.Split(';')[0].ToString(), Edit.Split(';')[1].ToString(), Edit.Split(';')[2].ToString(), "MienBac", "NCC");
                if (itemE1.Count > 0)
                {
                    foreach (var item in itemE1)
                    {
                        TotalE1 += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + L1 + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Tieude + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + item.SoHD + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + item.NgayHD + "</td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'>" + item.GhiChu + "</td>");
                        sb.Append("    </tr>");
                        L1++;
                    }
                }

                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><b>TỔNG CK Miền Bắc</b></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(TotalE1.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(TotalE1.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style30\" colspan=\"4\" style=' border: .5pt solid windowtext;'></td>");
                sb.Append("    </tr>");

                Double AmountMBCKE1 = Convert.ToDouble(SumAmountMB);
                Double SumAmountMBCKE1 = AmountMBCKE1 - Convert.ToDouble(TotalE1);

                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><b>TỔNG BBM TT (Miền Bắc)</b></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumAmountMBCKE1.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumAmountMBCKE1.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style30\" colspan=\"4\"  style=' border: .5pt solid windowtext;'></td>");
                sb.Append("    </tr>");
                #endregion

                #region ShowAll_TradingTemMN
                // chiết khấu 
                int l2 = 1;
                Double TotalE2 = 0;
                var itemE2 = DataAccess.DataAccess.GetList_TBL_BBM_ReportDeposit_TradingTem(Edit.Split(';')[0].ToString(), Edit.Split(';')[1].ToString(), Edit.Split(';')[2].ToString(), "MienNam", "NCC");
                if (itemE2.Count > 0)
                {
                    foreach (var item in itemE2)
                    {
                        TotalE2 += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + l2 + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Tieude + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + item.SoHD + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + item.NgayHD + "</td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'>" + item.GhiChu + "</td>");
                        sb.Append("    </tr>");
                        l2++;
                    }
                }

                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><b>TỔNG CK Miền Nam</b></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(TotalE2.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(TotalE2.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style30\" colspan=\"4\" style=' border: .5pt solid windowtext;'></td>");
                sb.Append("    </tr>");

                Double AmountMNCKE2 = Convert.ToDouble(SumAmountMN);
                Double SumAmountMNCKE2 = AmountMNCKE2 - Convert.ToDouble(TotalE2);

                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><b>TỔNG BBM TT (Miền Nam)</b></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumAmountMNCKE2.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumAmountMNCKE2.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style30\" colspan=\"4\" style=' border: .5pt solid windowtext;'></td>");
                sb.Append("    </tr>");

                // TỔNG CỘNG PHẢI THANH TOÁN của 2 miền
                Double SumTongTT = SumAmountMNCKE2 + SumAmountMBCKE1;
                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><b>TỔNG CỘNG PHẢI THANH TOÁN</b></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumTongTT.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumTongTT.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style30\" colspan=\"4\" style=' border: .5pt solid windowtext;'></td>");
                sb.Append("    </tr>");
                #endregion
            }
            else
            {
                #region ShowAll_TradingTemMB
                // chiết khấu 
                int k = 1;
                Double Total = 0;
                var item01 = DataAccess.DataAccess.SP_TRADTERM_LIST_DISCOUNT_SALES_ReportDeposit_CongNo(Session["vendorNos"].ToString(), "2", SumAmountMB.ToString(), SumAmountMB.ToString());
                if (item01.Count > 0)
                {
                    foreach (var item in item01)
                    {
                        Total += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");
                        k++;
                    }
                }
                //THƯỞNG 1
                var item022 = DataAccess.DataAccess.SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01(Session["vendorNos"].ToString(), "2", SumAmountMB.ToString(), SumAmountMB.ToString());
                if (item022.Count > 0)
                {
                    foreach (var item in item022)
                    {
                        Total += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");
                        k++;
                    }
                }
                //THƯỞNG 2
                var item023 = DataAccess.DataAccess.SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02(Session["vendorNos"].ToString(), "2", SumAmountMB, SumAmountMB);
                if (item023.Count > 0)
                {
                    foreach (var item in item023)
                    {
                        Total += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");
                        k++;
                    }
                }

                // markerting
                var item1 = DataAccess.DataAccess.SP_TRADTERM_LIST_MKT_BONUS_CongNo(Session["vendorNos"].ToString(), "2", SumAmountMB.ToString(), SumAmountMB.ToString());
                if (item1.Count > 0)
                {
                    foreach (var item in item1)
                    {
                        Total += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");

                        k++;
                    }
                }

                //PhatTrienThuongHieu
                var item2 = DataAccess.DataAccess.SP_TRADTERM_LIST_BRAND_BONUS_CongNo(Session["vendorNos"].ToString(), "2", SumAmountMB.ToString(), SumAmountMB.ToString());
                if (item2.Count > 0)
                {
                    foreach (var item in item2)
                    {
                        Total += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");

                        k++;
                    }
                }

                var item3 = DataAccess.DataAccess.SP_TRADTERM_LIST_CUSTOMER_BONUS_CongNo(Session["vendorNos"].ToString(), "2", SumAmountMB.ToString(), SumAmountMB.ToString());
                if (item3.Count > 0)
                {
                    foreach (var item in item3)
                    {
                        Total += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");

                        k++;
                    }
                }
                var item4 = DataAccess.DataAccess.SP_TRADTERM_LIST_CHIPHIVANHANH_CongNo(Session["vendorNos"].ToString(), "2", SumAmountMB.ToString(), SumAmountMB.ToString(), MinPostingDate, MaxMinPostingDate);
                if (item4.Count > 0)
                {
                    foreach (var item in item4)
                    {
                        Total += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");

                        k++;
                    }
                }

                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><b>TỔNG CK Miền Bắc</b></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(Total.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(Total.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style30\" colspan=\"4\" style=' border: .5pt solid windowtext;'></td>");
                sb.Append("    </tr>");

                Double AmountMBCK = Convert.ToDouble(SumAmountMB);
                Double SumAmountMBCK = AmountMBCK - Convert.ToDouble(Total);

                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><b>TỔNG BBM TT (Miền Bắc)</b></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumAmountMBCK.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumAmountMBCK.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style30\" colspan=\"4\"  style=' border: .5pt solid windowtext;'></td>");
                sb.Append("    </tr>");
                #endregion

                #region ShowAll_TradingTemMN
                // chiết khấu 
                int l = 1;
                Double Total1 = 0;
                var item011 = DataAccess.DataAccess.SP_TRADTERM_LIST_DISCOUNT_SALES_ReportDeposit_CongNo(Session["vendorNos"].ToString(), "2", SumAmountMN.ToString(), SumAmountMN.ToString());
                if (item011.Count > 0)
                {
                    foreach (var item in item011)
                    {
                        Total1 += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");
                        l++;
                    }
                }
                //THƯỞNG 1
                var item02221 = DataAccess.DataAccess.SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_01(Session["vendorNos"].ToString(), "2", SumAmountMN.ToString(), SumAmountMN.ToString());
                if (item02221.Count > 0)
                {
                    foreach (var item in item02221)
                    {
                        Total1 += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");
                        l++;
                    }
                }
                //THƯỞNG 2
                var item0231 = DataAccess.DataAccess.SP_TRADTERM_LIST_LINE_BONUS_New_KyGui_MuaBan_02(Session["vendorNos"].ToString(), "2", SumAmountMN, SumAmountMN);
                if (item0231.Count > 0)
                {
                    foreach (var item in item0231)
                    {
                        Total1 += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");
                        l++;
                    }
                }

                // markerting
                var item11 = DataAccess.DataAccess.SP_TRADTERM_LIST_MKT_BONUS_CongNo(Session["vendorNos"].ToString(), "2", SumAmountMN.ToString(), SumAmountMN.ToString());
                if (item11.Count > 0)
                {
                    foreach (var item in item11)
                    {
                        Total1 += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");

                        l++;
                    }
                }

                //PhatTrienThuongHieu
                var item21 = DataAccess.DataAccess.SP_TRADTERM_LIST_BRAND_BONUS_CongNo(Session["vendorNos"].ToString(), "2", SumAmountMN.ToString(), SumAmountMN.ToString());
                if (item21.Count > 0)
                {
                    foreach (var item in item21)
                    {
                        Total1 += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");

                        l++;
                    }
                }

                var item31 = DataAccess.DataAccess.SP_TRADTERM_LIST_CUSTOMER_BONUS_CongNo(Session["vendorNos"].ToString(), "2", SumAmountMN.ToString(), SumAmountMN.ToString());
                if (item31.Count > 0)
                {
                    foreach (var item in item31)
                    {
                        Total1 += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");

                        l++;
                    }
                }

                var item41 = DataAccess.DataAccess.SP_TRADTERM_LIST_CHIPHIVANHANH_CongNo(Session["vendorNos"].ToString(), "2", SumAmountMN.ToString(), SumAmountMN.ToString(), MinPostingDate, MaxMinPostingDate);
                if (item41.Count > 0)
                {
                    foreach (var item in item41)
                    {
                        Total1 += Convert.ToDouble(item.Total.Replace(",", ""));
                        string Tongs = item.Total;
                        sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                        sb.Append("        <td class=\"auto-style29\" height=\"33\">" + k + "</td>");
                        sb.Append("        <td class=\"auto-style30\" colspan=\"5\">" + item.Name + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" >" + (Tongs.ToString()) + "</td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style30\" ></td>");
                        sb.Append("        <td class=\"auto-style31\" colspan=\"2\" style=' border: .5pt solid windowtext;'></td>");
                        sb.Append("    </tr>");

                        l++;
                    }
                }

                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><b>TỔNG CK Miền Nam</b></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(Total1.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(Total1.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style30\" colspan=\"4\" style=' border: .5pt solid windowtext;'></td>");
                sb.Append("    </tr>");

                Double AmountMNCK = Convert.ToDouble(SumAmountMN);
                Double SumAmountMNCK = AmountMNCK - Convert.ToDouble(Total1);

                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><b>TỔNG BBM TT (Miền Nam)</b></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumAmountMNCK.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumAmountMNCK.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style30\" colspan=\"4\" style=' border: .5pt solid windowtext;'></td>");
                sb.Append("    </tr>");

                // TỔNG CỘNG PHẢI THANH TOÁN của 2 miền
                Double SumTongTT = SumAmountMNCK + SumAmountMBCK;
                sb.Append("    <tr height=\"33\" style=\"mso-height-source:userset;height:24.75pt\">");
                sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><b>TỔNG CỘNG PHẢI THANH TOÁN</b></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumTongTT.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style31\" style=' border: .5pt solid windowtext;;font-weight:bold '><span style=\"mso-spacerun:yes\">" + Commond.FormatMoney_VND(SumTongTT.ToString()) + "</span></td>");
                sb.Append("        <td class=\"auto-style30\" colspan=\"4\" style=' border: .5pt solid windowtext;'></td>");
                sb.Append("    </tr>");

                #endregion
            }

            sb.Append("    <tr height=\"26\" style=\"mso-height-source:userset;height:19.5pt\">");
            sb.Append("        <td class=\"auto-style41\" colspan=\"12\" height=\"26\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"130\" style=\"mso-height-source:userset;height:97.5pt\">");
            sb.Append("        <td class=\"auto-style44\" colspan=\"3\" height=\"130\">Người đề nghị</td>");
            sb.Append("        <td class=\"auto-style43\" colspan=\"3\"><span style=\"mso-spacerun:yes\">&nbsp;</span>Trưởng nhóm<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("        <td class=\"auto-style43\" colspan=\"4\"><span style=\"mso-spacerun:yes\">&nbsp;</span>K/T Kế Toán Trưởng<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("        <td class=\"auto-style45\" colspan=\"2\">Giám Đốc</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"26\" style=\"mso-height-source:userset;height:19.5pt\">");
            sb.Append("        <td class=\"auto-style46\" colspan=\"12\" height=\"26\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"27\" style=\"mso-height-source:userset;height:20.25pt\">");
            sb.Append("        <td class=\"auto-style47\" colspan=\"10\" height=\"27\">Thông tin chuyển khoản</td>");
            sb.Append("        <td class=\"auto-style48\" colspan=\"2\" rowspan=\"4\" width=\"310\">Kế Toán Thanh Toán");
            sb.Append("            <br />");
            sb.Append("            <font class=\"font5\">(Ký, ghi rõ họ tên)</font></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"34\" style=\"mso-height-source:userset;height:25.5pt\">");
            sb.Append("        <td class=\"auto-style49\" colspan=\"4\" height=\"34\">Tên người hưởng thụ: --</td>");
            sb.Append("        <td class=\"auto-style30\" colspan=\"6\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"34\" style=\"mso-height-source:userset;height:25.5pt\">");
            sb.Append("        <td class=\"auto-style49\" colspan=\"4\" height=\"34\">Số tài khoản: --</td>");
            sb.Append("        <td class=\"auto-style30\" colspan=\"6\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"34\" style=\"mso-height-source:userset;height:25.5pt\">");
            sb.Append("        <td class=\"auto-style49\" colspan=\"4\" height=\"34\">Tên ngân hàng: --</td>");
            sb.Append("        <td class=\"auto-style30\" colspan=\"6\"><span style=\"mso-spacerun:yes\">&nbsp;</span>Chi nhánh: --<span style=\"mso-spacerun:yes\">&nbsp;</span></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"32\" style=\"mso-height-source:userset;height:24.0pt\">");
            sb.Append("        <td class=\"auto-style50\" colspan=\"12\" height=\"32\">List Hồ sơ:</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"32\" style=\"mso-height-source:userset;height:24.0pt\">");
            sb.Append("        <td class=\"auto-style51\" height=\"32\">STT</td>");
            sb.Append("        <td class=\"auto-style52\" colspan=\"8\">TÊN CHỨNG TỪ</td>");
            sb.Append("        <td class=\"auto-style53\">ĐỦ</td>");
            sb.Append("        <td class=\"auto-style53\">THIẾU</td>");
            sb.Append("        <td class=\"auto-style53\">LÝ DO</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"24\" style=\"mso-height-source:userset;height:18.0pt\">");
            sb.Append("        <td class=\"auto-style18\" height=\"24\">1</td>");
            sb.Append("        <td class=\"auto-style30\" colspan=\"8\">Doanh số từ hệ thống</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"30\" style=\"mso-height-source:userset;height:22.5pt\">");
            sb.Append("        <td class=\"auto-style54\" height=\"30\">2</td>");
            sb.Append("        <td class=\"auto-style30\" colspan=\"8\">Biên bản đối chiếu xác nhận của NCC</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"27\" style=\"mso-height-source:userset;height:20.25pt\">");
            sb.Append("        <td class=\"auto-style55\" height=\"27\">3</td>");
            sb.Append("        <td class=\"auto-style30\" colspan=\"8\">Hóa đơn của NCC và BBM xuất nếu có</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr height=\"23\" style=\"mso-height-source:userset;height:17.25pt\">");
            sb.Append("        <td class=\"auto-style56\" height=\"23\">4</td>");
            sb.Append("        <td class=\"auto-style30\" colspan=\"8\">Phiếu giao hàng + Phiếu nhập kho trong kỳ</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("        <td class=\"auto-style20\">&nbsp;</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion
    }
}
