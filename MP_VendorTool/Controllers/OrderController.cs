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
using MP_VendorTool.Models.Tradingterm;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using MP_VendorTool.Common;
using Newtonsoft.Json.Linq;
using System.Globalization;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using System.Text;

namespace MP_VendorTool.Controllers
{
    public class OrderController : Controller
    {

        public void ExportExcelAll()
        {
            var strDate = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;
            string Namefile = "Order_" + DateTime.Now.ToString("ddMMMyyyy");
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
            sb.Append("       <tr height=\"50\" >");
            sb.Append("             <td style=\" text-align:center; font-size:22px\" colspan=\"11\" ><strong>PHIẾU XUẤT KHO</strong></td>");
            sb.Append("     </tr>");
            sb.Append("     <tr height =\"20\" style=\"height:15.0pt\">");
            sb.Append("         <td class=\"auto-style2\" colspan=\"11\" height=\"20\" style=\" text-align:center; font-size:13px\"><strong>" + strDate + "</strong></td>");
            sb.Append("     </tr>");
            sb.Append("     <tr height =\"20\" style=\"height:15.0pt\">");
            sb.Append("         <td height =\"20\" colspan =\"11\" style=\"height:15.0pt\"></td>");
            sb.Append("     </tr>");
            sb.Append("     <tr height =\"30\" style=\"height:15.0pt;\">");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>STT</strong></td>");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>Ngày đặt hàng</strong></td>");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>Mã PO</strong></td>");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>CH nhận</strong></td>");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>Ngày giao hàng</strong></td>");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>Mã sản phẩm</strong></td>");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>Tên sản phẩm</strong></td>");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>Đơn giá</strong></td>");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>Số lượng đặt</strong></td>");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>Số lượng giao</strong></td>");
            sb.Append("         <td  style=\"background: #afa9a9;\"><strong>Thành tiền</strong></td>");
            sb.Append("     </tr>");

            decimal TotalTienHang = 0;
            int i = 1;
            List<obj_Order_Exel> Litem = (List<obj_Order_Exel>)Session["onExpOrder"];
            foreach (var item in Litem)
            {
                var Items = DataAccess.DataAccess.GET_Detail_Order_All(Session["OrderNhaCC"].ToString(), item.No_);
                if (Items.Count() > 0)
                {
                    foreach (var item1 in Items)
                    {
                        var total = item1.DonGia * item1.SLGiao;
                        var ThanhTien = string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", item1.DonGia * item1.SLGiao);
                        TotalTienHang += total;
                        sb.Append("     <tr height =\"60\" style=\"height:45.0pt\">");
                        sb.Append("         <td style=\" text-align:center;width:50px\">" + i++ + "</td>");
                        sb.Append("         <td style=\" text-align:left;width:110px\" >" + item.OrderDate + "</td>");
                        sb.Append("         <td style=\" text-align:left;width:110px\" >" + item.No_ + "</td>");
                        sb.Append("         <td style=\" text-align:left;width:110px\" >" + item.LocationCode + "</td>");
                        sb.Append("         <td style=\" text-align:left;width:110px\" >" + item1.NgayGiaoHang + "</td>");
                        sb.Append("         <td style=\" text-align:left;width:110px\" >" + item1.MaHH + "</td>");
                        sb.Append("         <td style=\" text-align:left;width:310px\"  >" + item1.TenHangHoa + "</td>");
                        sb.Append("         <td style=\" text-align:right;width:110px\" >" + item1.DonGia + "</td>");
                        sb.Append("         <td style=\" text-align:right;width:110px\" >" + item1.SLDat + "</td>");
                        sb.Append("         <td style=\" text-align:right;width:110px\" >" + item1.SLGiao + "</td>");
                        sb.Append("         <td style=\" text-align:right;width:110px\" >" + ThanhTien + "</td>");
                        sb.Append("     </tr>");
                    }
                }
            }
            sb.Append("     <tr height =\"20\" style=\"height:15.0pt\">");
            sb.Append("         <td  height=\"20\"></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td  width=\"103\"></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td  colspan=\"2\"  style=\" text-align:right\"><strong>Tiền hàng:</strong></td>");
            sb.Append("         <td style=\" text-align:right\">" + string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", TotalTienHang) + "</td>");
            sb.Append("     </tr>");
            sb.Append("     <tr height =\"20\" style=\"height:15.0pt\">");
            sb.Append("         <td  height=\"20\"></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td  width=\"103\"></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td  colspan=\"2\"  style=\" text-align:right\"><strong>Tiền thuế GTGT:</strong></td>");
            sb.Append("         <td style=\" text-align:right\">0</td>");
            sb.Append("     </tr>");
            sb.Append("     <tr height =\"20\" style=\"height:15.0pt\">");
            sb.Append("         <td  height=\"20\"></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td  width=\"103\"></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td  colspan=\"2\"  style=\" text-align:right\"><strong>Tiền chiết khấu:</strong></td>");
            sb.Append("         <td  style=\" text-align:right\">0</td>");
            sb.Append("     </tr>");
            sb.Append("     <tr height =\"20\" style=\"height:15.0pt\">");
            sb.Append("         <td  height=\"20\"></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td  width=\"103\"></td>");
            sb.Append("         <td ></td>");
            sb.Append("         <td  colspan=\"2\" style=\" text-align:right\"><strong>Thanh toán:</strong></strong></td>");
            sb.Append("         <td style=\" text-align:right\">" + string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", TotalTienHang) + "</td>");
            sb.Append("     </tr>");
            sb.Append("     <tr height =\"20\" style=\"height:15.0pt\">");
            sb.Append("         <td height =\"20\" style=\"height:15.0pt\"></td>");
            sb.Append("         <td height =\"20\" colspan =\"11\" style=\"height:15.0pt\"></td>");
            sb.Append("     </tr>");
            sb.Append("     <tr height =\"20\" style=\"height:15.0pt\">");
            sb.Append("         <td height =\"20\"  colspan =\"2\" style=\"height:15.0pt\"><strong>Yêu cầu:</strong></td>");
            sb.Append("         <td colspan =\"5\">KH kiểm tra hàng trước khi NV giao hàng về.</td>");
            //sb.Append("         <td></td>");
            //sb.Append("         <td></td>");
            //sb.Append("         <td></td>");
            sb.Append("         <td></td>");
            sb.Append("         <td></td>");
            sb.Append("         <td></td>");
            sb.Append("         <td></td>");
            sb.Append("     </tr>");
            sb.Append("     <tr height =\"20\" style=\"height:15.0pt\">");
            sb.Append("         <td height =\"20\" colspan =\"11\" style=\"height:15.0pt\"></td>");
            sb.Append("     </tr>");
            sb.Append("     <tr height =\"20\" style=\"height:15.0pt\">");
            sb.Append("         <td colspan=\"3\" height=\"20\"><strong>Người nhận hàng</strong></td>");
            sb.Append("         <td colspan=\"3\"><strong>Người giao hàng</strong></td>");
            sb.Append("         <td colspan=\"3\"><strong>Người lập phiếu</strong></td>");
            sb.Append("         <td colspan=\"2\"><strong>Thủ kho</strong></td>");
            sb.Append("     </tr>");
            sb.Append("     </table>");

            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

        public void ExportExcel(string OrderNo)
        {

            var Order = DataAccess.DataAccess.sp_get_detail_Purchase_Order_header(Session["OrderNhaCC"].ToString(), OrderNo);
            var Items = DataAccess.DataAccess.GET_Detail_Order(Session["OrderNhaCC"].ToString(), OrderNo, "", "");

            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("Sheet 1");

            XSSFFont font = workbook.CreateFont() as XSSFFont;
            font.Boldweight = (short)FontBoldWeight.Bold;

            sheet1.SetColumnWidth(1, 25 * 200);
            sheet1.SetColumnWidth(2, 25 * 200);
            sheet1.SetColumnWidth(3, 25 * 300);
            sheet1.SetColumnWidth(4, 25 * 200);
            sheet1.SetColumnWidth(5, 25 * 200);
            sheet1.SetColumnWidth(6, 25 * 150);
            sheet1.SetColumnWidth(7, 25 * 150);
            sheet1.SetColumnWidth(8, 25 * 180);

            ICellStyle styleCenter = workbook.CreateCellStyle();
            styleCenter.Alignment = HorizontalAlignment.Center;
            styleCenter.SetFont(font);

            ICellStyle styleLeft = workbook.CreateCellStyle();
            styleLeft.WrapText = true;
            styleLeft.BorderTop = BorderStyle.Thin;
            styleLeft.BorderBottom = BorderStyle.Thin;
            styleLeft.BorderLeft = BorderStyle.Thin;
            styleLeft.BorderRight = BorderStyle.Thin;
            styleLeft.Alignment = HorizontalAlignment.Left;

            ICellStyle styleRight = workbook.CreateCellStyle();
            styleRight.Alignment = HorizontalAlignment.Right;

            ICellStyle styleAll = workbook.CreateCellStyle();
            styleAll.BorderTop = BorderStyle.Thin;
            styleAll.BorderBottom = BorderStyle.Thin;
            styleAll.BorderLeft = BorderStyle.Thin;
            styleAll.BorderRight = BorderStyle.Thin;
            styleAll.Alignment = HorizontalAlignment.Center;

            ICellStyle styleAllHeader = workbook.CreateCellStyle();
            styleAllHeader.BorderTop = BorderStyle.Thin;
            styleAllHeader.BorderBottom = BorderStyle.Thin;
            styleAllHeader.BorderLeft = BorderStyle.Thin;
            styleAllHeader.BorderRight = BorderStyle.Thin;
            styleAllHeader.Alignment = HorizontalAlignment.Center;
            styleAllHeader.SetFont(font);

            ICellStyle styleAll2 = workbook.CreateCellStyle();
            styleAll2.BorderTop = BorderStyle.Thin;
            styleAll2.BorderBottom = BorderStyle.Thin;
            styleAll2.BorderLeft = BorderStyle.Thin;
            styleAll2.BorderRight = BorderStyle.Thin;
            styleAll2.Alignment = HorizontalAlignment.Right;

            var strDate = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;

            //Tạo row 0
            var row0 = sheet1.CreateRow(0);
            row0.CreateCell(0).CellStyle = styleCenter;
            CellRangeAddress cellMerge = new CellRangeAddress(0, 0, 0, 7);
            sheet1.AddMergedRegion(cellMerge);
            row0.GetCell(0).SetCellValue("PHIẾU XUẤT KHO");

            var row1 = sheet1.CreateRow(1);
            // Merge lại row đầu 8 cột
            row1.CreateCell(0).CellStyle = styleCenter; // tạo ra cell trc khi merge
            CellRangeAddress cellMerge1 = new CellRangeAddress(1, 1, 0, 7);
            sheet1.AddMergedRegion(cellMerge1);
            row1.GetCell(0).SetCellValue(strDate);

            var row2 = sheet1.CreateRow(2);
            row2.CreateCell(0); // tạo ra cell trc khi merge
            CellRangeAddress cellMerge2 = new CellRangeAddress(2, 2, 0, 1);
            sheet1.AddMergedRegion(cellMerge2);
            row2.GetCell(0).SetCellValue("Ngày đặt hàng:");
            row2.CreateCell(2);
            row2.GetCell(2).SetCellValue(Order[0].OrderDate);

            var row3 = sheet1.CreateRow(3);
            row3.CreateCell(0); // tạo ra cell trc khi merge
            CellRangeAddress cellMerge3 = new CellRangeAddress(3, 3, 0, 1);
            sheet1.AddMergedRegion(cellMerge3);
            row3.GetCell(0).SetCellValue("Đơn vị:");
            row3.CreateCell(2); // tạo ra cell trc khi merge 
            row3.GetCell(2).SetCellValue(Order[0].VendorName);

            var row4 = sheet1.CreateRow(4);
            row4.CreateCell(0); // tạo ra cell trc khi merge
            CellRangeAddress cellMerge4 = new CellRangeAddress(4, 4, 0, 1);
            sheet1.AddMergedRegion(cellMerge4);
            row4.GetCell(0).SetCellValue("Địa chỉ nhận hàng:");
            row4.CreateCell(2); // tạo ra cell trc khi merge            
            row4.GetCell(2).SetCellValue(Order[0].locationCode + " - " + Order[0].StoreName);

            var row5 = sheet1.CreateRow(5);
            row5.CreateCell(0); // tạo ra cell trc khi merge
            CellRangeAddress cellMerge5 = new CellRangeAddress(5, 5, 0, 1);
            sheet1.AddMergedRegion(cellMerge5);
            row5.GetCell(0).SetCellValue("Nội dung:");
            row5.CreateCell(2); // tạo ra cell trc khi merge            
            row5.GetCell(2).SetCellValue("Mua hàng");
            row5.CreateCell(3); // tạo ra cell trc khi merge            
            row5.GetCell(3).SetCellValue("Số PO:");
            row5.CreateCell(4); // tạo ra cell trc khi merge            
            row5.GetCell(4).SetCellValue(Order[0].No_.ToString());


            IRow row7 = sheet1.CreateRow(7);
            ICell cell_header_s1_m1 = row7.CreateCell(0);
            cell_header_s1_m1.CellStyle = styleAllHeader;
            cell_header_s1_m1.SetCellValue("STT");

            ICell cell_header_s1_m2 = row7.CreateCell(1);
            cell_header_s1_m2.CellStyle = styleAllHeader;
            cell_header_s1_m2.SetCellValue("Ngày giao hàng");

            ICell cell_header_s1_m3 = row7.CreateCell(2);
            cell_header_s1_m3.CellStyle = styleAllHeader;
            cell_header_s1_m3.SetCellValue("Mã sản phẩm");

            ICell cell_header_s1_m4 = row7.CreateCell(3);
            cell_header_s1_m4.CellStyle = styleAllHeader;
            cell_header_s1_m4.SetCellValue("Tên sản phẩm");

            ICell cell_header_s1_m5 = row7.CreateCell(4);
            cell_header_s1_m5.CellStyle = styleAllHeader;
            cell_header_s1_m5.SetCellValue("Đơn giá (-VAT)");

            ICell cell_header_s1_m6 = row7.CreateCell(5);
            cell_header_s1_m6.CellStyle = styleAllHeader;
            cell_header_s1_m6.SetCellValue("% Line Discount");

            ICell cell_header_s1_m7 = row7.CreateCell(6);
            cell_header_s1_m7.CellStyle = styleAllHeader;
            cell_header_s1_m7.SetCellValue("Số lượng đặt");

            ICell cell_header_s1_m8 = row7.CreateCell(7);
            cell_header_s1_m8.CellStyle = styleAllHeader;
            cell_header_s1_m8.SetCellValue("Số lượng giao");

            ICell cell_header_s1_m9 = row7.CreateCell(8);
            cell_header_s1_m9.CellStyle = styleAllHeader;
            cell_header_s1_m9.SetCellValue("Thành tiền(-VAT)");

            int ri = 0;
            Double TotalTienHang = 0;
            if (Items.Count() > 0)
            {
                int k = 1;
                for (int i = 0; i < Items.Count(); i++)
                {
                    ri = i + 9;
                    try
                    {
                        IRow row = sheet1.CreateRow(i + 9);
                        ICell cell_m1 = row.CreateCell(0);
                        cell_m1.CellStyle = styleAll;
                        cell_m1.SetCellValue(k + i);

                        ICell cell_m2 = row.CreateCell(1);
                        cell_m2.CellStyle = styleAll;
                        cell_m2.SetCellValue(Items[i].NgayGiaoHang);

                        ICell cell_m3 = row.CreateCell(2);
                        cell_m3.CellStyle = styleAll;
                        cell_m3.SetCellValue(Items[i].MaHH);

                        ICell cell_m4 = row.CreateCell(3);
                        cell_m4.CellStyle = styleLeft;
                        cell_m4.SetCellValue(Items[i].TenHangHoa);

                        ICell cell_m5 = row.CreateCell(4);
                        cell_m5.CellStyle = styleAll2;
                        cell_m5.SetCellValue(string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", Items[i].DonGia));

                        ICell cell_m6 = row.CreateCell(5);
                        cell_m6.CellStyle = styleAll;
                        cell_m6.SetCellValue(Items[i].lineDiscout.ToString());

                        ICell cell_m7 = row.CreateCell(6);
                        cell_m7.CellStyle = styleAll;
                        cell_m7.SetCellValue(Items[i].SLDat.ToString());

                        ICell cell_m8 = row.CreateCell(7);
                        cell_m8.CellStyle = styleAll;
                        cell_m8.SetCellValue(Items[i].SLGiao.ToString());

                        //var ThanhTien = string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", Items[i].DonGia * Items[i].SLGiao);
                        TotalTienHang += Convert.ToDouble(Items[i].ThanhTienTruVAT.Replace(",", ""));

                        ICell cell_m9 = row.CreateCell(8);
                        cell_m9.CellStyle = styleAll;
                        cell_m9.SetCellValue(Items[i].ThanhTienTruVAT.ToString());

                    }
                    catch (Exception ex)
                    {
                        DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(Items[i]), "ExportExcel");
                        DataAccess.LogBuild.CreateLogger(ex.ToString(), "ExportExcel");
                    }
                }
            }

            var row8 = sheet1.CreateRow(ri + 1);
            row8.CreateCell(0).CellStyle = styleRight; // tạo ra cell trc khi merge
            CellRangeAddress cellMerge8 = new CellRangeAddress(ri + 1, ri + 1, 0, 7);
            sheet1.AddMergedRegion(cellMerge8);

            row8.GetCell(0).SetCellValue("Tiền hàng:");
            row8.CreateCell(8).CellStyle = styleRight; // tạo ra cell trc khi merge            
            row8.GetCell(8).SetCellValue(string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", TotalTienHang));


            var row9 = sheet1.CreateRow(ri + 2);
            row9.CreateCell(0).CellStyle = styleRight; // tạo ra cell trc khi merge
            CellRangeAddress cellMerge9 = new CellRangeAddress(ri + 2, ri + 2, 0, 7);
            sheet1.AddMergedRegion(cellMerge9);
            row9.GetCell(0).SetCellValue("Tiền thuế GTGT:");
            row9.CreateCell(8).CellStyle = styleRight;
            row9.GetCell(8).SetCellValue("0");

            var row10 = sheet1.CreateRow(ri + 3);
            row10.CreateCell(0).CellStyle = styleRight; // tạo ra cell trc khi merge
            CellRangeAddress cellMerge10 = new CellRangeAddress(ri + 3, ri + 3, 0, 7);
            sheet1.AddMergedRegion(cellMerge10);
            row10.GetCell(0).SetCellValue("Tiền chiết khấu:");
            row10.CreateCell(8).CellStyle = styleRight;
            row10.GetCell(8).SetCellValue("0");

            var row11 = sheet1.CreateRow(ri + 4);
            row11.CreateCell(0).CellStyle = styleRight; // tạo ra cell trc khi merge
            CellRangeAddress cellMerge11 = new CellRangeAddress(ri + 4, ri + 4, 0, 7);
            sheet1.AddMergedRegion(cellMerge11);
            row11.GetCell(0).SetCellValue("Thanh toán:");
            row11.CreateCell(8).CellStyle = styleRight;
            row11.GetCell(8).SetCellValue(string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", TotalTienHang));


            var row12 = sheet1.CreateRow(ri + 6);
            row12.CreateCell(0); // tạo ra cell trc khi merge
            row12.GetCell(0).SetCellValue("Yêu cầu:");
            row12.CreateCell(1); // tạo ra cell trc khi merge
            row12.GetCell(1).SetCellValue("KH kiểm tra hàng trước khi NV giao hàng về.");

            var row13 = sheet1.CreateRow(ri + 8);
            row13.CreateCell(0).CellStyle = styleCenter; // tạo ra cell trc khi merge
            CellRangeAddress cellMerge13 = new CellRangeAddress(ri + 8, ri + 8, 0, 1);
            sheet1.AddMergedRegion(cellMerge13);
            row13.GetCell(0).SetCellValue("Người nhận hàng");

            row13.CreateCell(2).CellStyle = styleCenter;
            CellRangeAddress cellMerge14 = new CellRangeAddress(ri + 8, ri + 8, 2, 3);
            sheet1.AddMergedRegion(cellMerge14);
            row13.GetCell(2).SetCellValue("Người giao hàng");

            row13.CreateCell(4).CellStyle = styleCenter;
            CellRangeAddress cellMerge15 = new CellRangeAddress(ri + 8, ri + 8, 4, 5);
            sheet1.AddMergedRegion(cellMerge15);
            row13.GetCell(4).SetCellValue("Người lập phiếu");

            row13.CreateCell(6).CellStyle = styleCenter;
            CellRangeAddress cellMerge16 = new CellRangeAddress(ri + 8, ri + 8, 6, 7);
            sheet1.AddMergedRegion(cellMerge16);
            row13.GetCell(6).SetCellValue("Thủ kho");

            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "DonHang_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @".xlsx"));
                Response.BinaryWrite(exportData.ToArray());
                Response.End();
            }
        }

        public ActionResult Index()
        {
            try
            {
                if (Session["uid"] != null)// if (Session["all_us_role"] != null)
                {
                    if (!Constants.checkpermission("Order", "Index")) return RedirectToAction("Index", "Home");

                    if (Session["OrderNhaCC"] != null)
                    {
                        ViewBag.OrderNhaCC = Session["OrderNhaCC"];

                        try
                        {
                            var bn_hangtralai = DataAccess.DataAccess.SP_BBM_ShowTrangThai_TraLaiKhoHang(Session["OrderNhaCC"].ToString());
                            ViewBag.Show_hangtralai = bn_hangtralai[0].Code.ToString().Trim();
                        }
                        catch (Exception)
                        { }
                    }

                    //RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");
                    //Session["us_role"] = us_role;
                    //Session["roleCode"] = us_role.roleCode;

                    //List<VendorInfo> ls_info = new List<VendorInfo>();

                    //if (Session["Vendor_con"] != null && us_role.roleCode == "R001")
                    //{
                    //    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 2, ((VendorContact)Session["Vendor_con"]).id);
                    //    //return RedirectToAction("Detail", new { registrationTax = ls_info[0].registrationTax, VendorContact_ID = ls_info[0].VendorContact_ID });
                    //    ViewBag.ls_info = new List<VendorInfo>
                    //    {
                    //        ls_info[0]
                    //    };
                    //}
                    //else
                    //{
                    //    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 0, "");
                    //    ViewBag.ls_info = ls_info;
                    //}

                    var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_Purchase_Order();
                    ViewBag.list_vendor = list_vendor;

                    var list_province = DataAccess.DataAccess.sp_BBM_MP_VendorTool_getStoreLocation();
                    ViewBag.province = list_province;
                    var list_warehouse = DataAccess.DataAccess.sp_BBM_MP_VendorTool_getKho();
                    ViewBag.warehouse = list_warehouse;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "OrderController_Index");
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Detail(string id)
        {
            try
            {
                if (Session["uid"] != null)// if (Session["all_us_role"] != null)
                {
                    //RoleItem us_role = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");
                    //Session["us_role"] = us_role;
                    //Session["roleCode"] = us_role.roleCode;
                    //List<VendorInfo> ls_info = new List<VendorInfo>();
                    //if (Session["Vendor_con"] != null && us_role.roleCode == "R001")
                    //{
                    //    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 2, ((VendorContact)Session["Vendor_con"]).id);
                    //    //return RedirectToAction("Detail", new { registrationTax = ls_info[0].registrationTax, VendorContact_ID = ls_info[0].VendorContact_ID });
                    //    ViewBag.ls_info = new List<VendorInfo>
                    //    {
                    //        ls_info[0]
                    //    };
                    //}
                    //else
                    //{
                    //    ls_info = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorInfo_get(Request.Cookies["culture"].Value, 0, "");
                    //    ViewBag.ls_info = ls_info;
                    //}

                    var bn_hangtralai = DataAccess.DataAccess.SP_BBM_ShowTrangThai_TraLaiKhoHang(Session["OrderNhaCC"].ToString());
                    ViewBag.Show_hangtralai = bn_hangtralai[0].Code.ToString().Trim();

                    ViewBag.orderId = id;
                    var bn_info = DataAccess.DataAccess.sp_get_detail_Purchase_Order_header(Session["OrderNhaCC"].ToString(), id);
                    ViewBag.Status = bn_info[0].status;
                    ViewBag.textDate = bn_info[0].OrderDate;
                    ViewBag.locationCode = bn_info[0].locationCode;
                    ViewBag.PROrderNo = bn_info[0].PROrderNo;
                    ViewBag.StoreName = bn_info[0].StoreName;
                    ViewBag.VendorName = bn_info[0].VendorName;
                    ViewBag.TotalOutstanding = bn_info[0].TotalOutstanding;
                    ViewBag.NgayXacNhanDonHang = bn_info[0].NgayXacNhanDonHang;

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "OrderController_Index");
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult UpdatePO(objUpdatePurchaseOrder po)
        {
            try
            {
                var DocumentNo = po.DocumentNo;
                var locationCode = po.locationCode;
                var items = JArray.Parse(po.SourceOrder);
                var VendorID = Session["OrderNhaCC"].ToString();
                if (Session["uid"] != null)// if (Session["all_us_role"] != null)
                {
                    if (items.Count > 0)
                    {
                        foreach (var item in items)
                        {
                            string Url = Request.Url.Authority + Request.RawUrl.ToString();

                            DateTime DeliveryDate = item["DeliveryDate"].ToString().Length > 0 ? DateTime.ParseExact(item["DeliveryDate"].ToString(), "dd/MM/yyyy", null) : DateTime.Parse("1900-01-01");
                            var bn_info = DataAccess.DataAccess.UpdatePurchaseOrder(Url, VendorID, DocumentNo, locationCode, item["ItemNo"].ToString(), item["LineNo"].ToString(), item["QtyToReceive"].ToString(), DeliveryDate, item["ExpectedReceiptTime"].ToString(), item["Note"].ToString(), item["SoLo"].ToString(), item["NgaySanXuat"].ToString(), item["NgayHetHan"].ToString());
                        }
                    }
                    return Json("true");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "UpdatePO");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult UpdatePurchaseOrder(objUpdatePurchaseOrder obj)
        {
            try
            {
                var DocumentNo = obj.DocumentNo;
                var locationCode = obj.locationCode;
                var items = JArray.Parse(obj.SourceOrder);
                var VendorID = Session["uid"].ToString();
                if (Session["uid"] != null)// if (Session["all_us_role"] != null)
                {

                    if (items.Count > 0)
                    {
                        foreach (var item in items)
                        {
                            DateTime EReceiptDate = item["EReceiptDate"].ToString().Length > 0 ? DateTime.ParseExact(item["EReceiptDate"].ToString(), "dd/MM/yyyy", null) : DateTime.Parse("1900-01-01");
                            var bn_info = DataAccess.DataAccess.sp_Vendor_Update_PurchaseOrder(VendorID, DocumentNo, locationCode, item["ItemNo"].ToString(), item["LineNo"].ToString(), decimal.Parse(item["PRQtty"].ToString()), EReceiptDate);
                        }
                    }
                    return Json("true");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "UpdatePurchaseOrder");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult CancelPurchaseOrder(string documentNo, string noteCancel)
        {
            try
            {
                if (Session["uid"] != null)// if (Session["all_us_role"] != null)
                {
                    var bn_info = DataAccess.DataAccess.sp_CancelPurchaseOrder(documentNo, noteCancel);
                    if (bn_info != true)
                    {
                        return Json(@"Có lỗi xẩy ra xin vui lòng thử lại sau !");
                    }
                    else
                    {
                        return Json(@"Hủy đơn hàng thành công!");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CancelPurchaseOrder");
                return Json(null);
            }
        }
        [HttpPost]
        public ActionResult GetListOrder(string Region, string City, string Status, string Store, string PurchaseOrderNo, string OrderDate, string NhaCC)
        {
            try
            {
                if (Session["uid"] != null)// if (Session["all_us_role"] != null)
                {
                    if (NhaCC != "")
                    {
                        Session["OrderNhaCC"] = NhaCC;
                    }
                    if (Session["OrderNhaCC"] == null)
                    {
                        Session["OrderNhaCC"] = "";
                    }

                    DataTable table = DataAccess.DataAccess.sp_GetListOrder(Session["OrderNhaCC"].ToString(), Region, City, Status, Store, PurchaseOrderNo, OrderDate);
                    var obj = (from DataRow dr in table.Rows
                               select new objPurchaseOrder()
                               {
                                   TotalProductNum = decimal.Parse(dr["TotalProductNum"].ToString().Replace(",", "")),
                                   TotalOrderQtty = decimal.Parse(dr["TotalOrderQtty"].ToString().Replace(",", "")),
                                   TotalOrdersVolume = decimal.Parse(dr["TotalOrdersVolume"].ToString().Replace(",", "")),
                                   sumTongTien = decimal.Parse(dr["TongTien"].ToString().Replace(",", "")),
                                   TotalSLGiao = decimal.Parse(dr["TotalSLGiao"].ToString()),
                                   TotalTongSLDaGiaoHang = decimal.Parse(dr["TongSLDaGiaoHang"].ToString()),
                               }).ToList();

                    var onExp = (from DataRow dr in table.Rows
                                 select new obj_Order_Exel()
                                 {
                                     No_ = dr["No_"].ToString(),
                                     LocationCode = dr["Location Code"].ToString(),
                                     OrderDate = dr["Order Date"].ToString()
                                 }).ToList();

                    Session["onExpOrder"] = onExp;


                    var TotalProductNum = obj.Select(s => s.TotalProductNum).ToList().Sum();
                    ViewBag.TotalProductNum = Commond.FormatMoney_VND(TotalProductNum.ToString());

                    var TotalOrderQtty = obj.Select(s => s.TotalOrderQtty).ToList().Sum();
                    ViewBag.TotalOrderQtty = Commond.FormatMoney_VND(TotalOrderQtty.ToString());

                    var TotalOrdersVolume = obj.Select(s => s.TotalOrdersVolume).ToList().Sum();
                    ViewBag.TotalOrdersVolume = Commond.FormatMoney_VND(TotalOrdersVolume.ToString());

                    var sumTongTien = obj.Select(s => s.sumTongTien).ToList().Sum();
                    ViewBag.sumTongTien = Commond.FormatMoney_VND(sumTongTien.ToString());

                    var TotalSLGiao = obj.Select(s => s.TotalSLGiao).ToList().Sum();
                    ViewBag.TotalSLGiao = Commond.FormatMoney_VND(TotalSLGiao.ToString());

                    var TotalTongSLDaGiaoHang = obj.Select(s => s.TotalTongSLDaGiaoHang).ToList().Sum();
                    ViewBag.TotalTongSLDaGiaoHang = Commond.FormatMoney_VND(TotalTongSLDaGiaoHang.ToString());

                    return PartialView(Constants.Partial_Order_Index, table);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListOrder");
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetDetailOrder(string itemNo, string itemName, string orderId)
        {
            try
            {
                if (Session["uid"] != null)// if (Session["all_us_role"] != null)
                {
                    var PurchaseOrderNo = orderId;
                    DataTable table = DataAccess.DataAccess.sp_GetDetailOrder(Session["OrderNhaCC"].ToString(), PurchaseOrderNo, itemNo, itemName);
                    var obj = (from DataRow dr in table.Rows
                               select new objPurchaseOrder()
                               {
                                   TotalDirectUnitCost = decimal.Parse(dr["DirectUnitCost"].ToString()),
                                   DirectUnitCostTruVAT = decimal.Parse(dr["DirectUnitCostTruVAT"].ToString()),
                                   DirectUnitCostCongVAT = decimal.Parse(dr["DirectUnitCostCongVAT"].ToString()),
                                   TotalQuantity = decimal.Parse(dr["Quantity"].ToString()),

                                   TotalTongTienTruVAT_No_Active = decimal.Parse(dr["TongTienTruVAT_No_Active"].ToString()),
                                   TotalTongTienTruVAT_Active = decimal.Parse(dr["TongTienTruVAT_Active"].ToString()),
                                   TotalTongTienCongVAT_No_Active = decimal.Parse(dr["TongTienCongVAT_No_Active"].ToString()),
                                   TotalTongTienCongVAT_Active = decimal.Parse(dr["TongTienCongVAT_Active"].ToString()),
                                   //  TotalSLGiao = decimal.Parse(dr["TotalSLGiao"].ToString()),
                                   TotalTongSLDaGiaoHang = decimal.Parse(dr["TongSLDaGiaoHang"].ToString()),


                               }).ToList();

                    var TotalDirectUnitCost = obj.Select(s => s.TotalDirectUnitCost).ToList().Sum();
                    Commond.FormatMoney_VND(TotalDirectUnitCost.ToString());

                    var DirectUnitCostTruVAT = obj.Select(s => s.DirectUnitCostTruVAT).ToList().Sum();
                    ViewBag.TotalDirectUnitCostTruVAT = Commond.FormatMoney_VND(DirectUnitCostTruVAT.ToString());

                    var DirectUnitCostCongVAT = obj.Select(s => s.DirectUnitCostCongVAT).ToList().Sum();
                    ViewBag.TotalDirectUnitCostCongVAT = Commond.FormatMoney_VND(DirectUnitCostCongVAT.ToString());

                    var TotalQuantity = obj.Select(s => s.TotalQuantity).ToList().Sum();
                    ViewBag.TotalQuantity = Commond.FormatMoney_VND(TotalQuantity.ToString());

                    // -VAT
                    var TotalTongTienTruVAT_No_Active = obj.Select(s => s.TotalTongTienTruVAT_No_Active).ToList().Sum();
                    ViewBag.TotalTongTienTruVAT_No_Active = Commond.FormatMoney_VND(TotalTongTienTruVAT_No_Active.ToString());

                    var TotalTongTienTruVAT_Active = obj.Select(s => s.TotalTongTienTruVAT_Active).ToList().Sum();
                    ViewBag.TotalTongTienTruVAT_Active = string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", TotalTongTienTruVAT_Active);

                    // + VAT
                    var TotalTongTienCongVAT_No_Active = obj.Select(s => s.TotalTongTienCongVAT_No_Active).ToList().Sum();
                    ViewBag.TotalTongTienCongVAT_No_Active = Commond.FormatMoney_VND(TotalTongTienCongVAT_No_Active.ToString());

                    var TotalTongTienCongVAT_Active = obj.Select(s => s.TotalTongTienCongVAT_Active).ToList().Sum();
                    ViewBag.TotalTongTienCongVAT_Active = Commond.FormatMoney_VND(TotalTongTienCongVAT_Active.ToString());

                    // var TotalSLGiao = obj.Select(s => s.TotalSLGiao).ToList().Sum();
                    //ViewBag.TotalSLGiao = string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:#,##0}", TotalSLGiao);

                    var TotalTongSLDaGiaoHang = obj.Select(s => s.TotalTongSLDaGiaoHang).ToList().Sum();
                    ViewBag.TotalTongSLDaGiaoHang = Commond.FormatMoney_VND(TotalTongSLDaGiaoHang.ToString());

                    return PartialView(Constants.Partial_Order_Detail, table);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetDetailOrder");
                return Json(null);
            }
        }

        #region ReturnedGoods
        public ActionResult ReturnedGoods()
        {
            try
            {
                if (Session["uid"] != null)// if (Session["all_us_role"] != null)
                {
                    if (!Constants.checkpermission("Order", "ReturnedGoods")) return RedirectToAction("Index", "Home");

                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        var list_datalist_Mien = DataAccess.DataAccess.sp_HangTraLai_MD_Sub_get(Session["VendorCode"].ToString());
                        ViewBag.list_datalist_Mien = list_datalist_Mien;

                        var list_province = DataAccess.DataAccess.sp_TinhThanh_MD_Sub_get(Session["VendorCode"].ToString());
                        ViewBag.province = list_province;

                        var lst_store = DataAccess.DataAccess.sp_getWay_CuaHang(Session["VendorCode"].ToString());
                        ViewBag.lst_store = lst_store;

                        var list_Status = DataAccess.DataAccess.SP_BBS_QLHH_Status_HH(Session["VendorCode"].ToString());
                        ViewBag.listStatus = list_Status;
                    }
                    else
                    {
                        var list_vendor = DataAccess.DataAccess.SP_ReturnedGoods_Vender();
                        ViewBag.list_vendor = list_vendor;


                        var list_datalist_Mien = DataAccess.DataAccess.sp_HangTraLai_MD_Sub_get("");
                        ViewBag.list_datalist_Mien = list_datalist_Mien;

                        var list_province = DataAccess.DataAccess.sp_TinhThanh_MD_Sub_get("");
                        ViewBag.province = list_province;

                        var lst_store = DataAccess.DataAccess.sp_getWay_CuaHang("");
                        ViewBag.lst_store = lst_store;

                        var list_Status = DataAccess.DataAccess.SP_BBS_QLHH_Status_HH("");
                        ViewBag.listStatus = list_Status;
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ReturnedGoods");
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult GetList_ReturnedGoods(string NCC, string Tinh, string Kho, string MaHang, string TinhTrang, string TrangThai, string GiaoHang)
        {
            try
            {
                if (Session["uid"] != null)// if (Session["all_us_role"] != null)
                {
                    if (Session["VendorCode"] != null && Session["VendorCode"].ToString().Length > 0)
                    {
                        System.Data.DataTable table = DataAccess.DataAccess.SP_GetWay_QLHH_getlstCH_NCC(NCC, Tinh, Kho, MaHang, TinhTrang, TrangThai, Session["VendorCode"].ToString(), GiaoHang);
                        return PartialView("~/Views/Order/Partial/__ReturnedGoods.cshtml", table);
                    }
                    else
                    {
                        System.Data.DataTable table = DataAccess.DataAccess.SP_GetWay_QLHH_getlstCH_NCC(NCC, Tinh, Kho, MaHang, TinhTrang, TrangThai, "", GiaoHang);
                        return PartialView("~/Views/Order/Partial/__ReturnedGoods.cshtml", table);
                    }
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
        public ActionResult Update_ReturnedGoods(List<ReturnedGoods> lst)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                foreach (ReturnedGoods po in lst)
                {
                    DataAccess.DataAccess.Update_ReturnedGoods(Session["uid"].ToString(), po.MaCH, po.MaHang, po.ID, po.NCC, po.HisDateRRV, po.SoLuong);
                }
                return Json(1);
            }
            return RedirectToAction("Login", "Account");
        }
        #endregion

    }
}