using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Common
{
    public class TradingTerm
    {
        public static string Show_Status_DoiTra(string ContractNo)
        {
            var list = DataAccess.DataAccess.SP_TRADTERM_LIST_DoiTraHang_Show(ContractNo);
            if (list[0].TongSo > 1)
            {
                return "<a onclick=\"ShowDoiTraHang('" + ContractNo + "')\" class=\"btn_detail btn btn - secondary\">Yes</a>";
            }
            return "No";
        }
        public static string Show_Status_ThanhToan(string ContractNo)
        {
            var list = DataAccess.DataAccess.SP_TRADTERM_LIST_PAYMENT(ContractNo);
            if (list.Count > 0)
            {
                return "<a onclick=\"ShowCSThanhToan('" + ContractNo + "')\" class=\"btn_detail btn btn - secondary\">Yes</a>";
            }
            return "No";
        }
        public static string Show_Status_ChinhSachThuong(string ContractNo)
        {
            var list = DataAccess.DataAccess.SP_TRADTERM_LIST_LINE_BONUS(ContractNo);
            if (list.Count > 0)
            {
                return "<a onclick=\"showChinhSachThuong('" + ContractNo + "')\" class=\"btn_detail btn btn - secondary\">Yes</a>";
            }
            return "No";
        }
        public static string Show_Status_Leadtime(string ContractNo)
        {
            var list = DataAccess.DataAccess.SP_TRADTERM_LIST_LeadTime_View(ContractNo, "");
            if (list.Count > 0)
            {
                return "<a onclick=\"showLeadtime('" + ContractNo + "')\" class=\"btn_detail btn btn - secondary\">Yes</a>";
            }
            return "No";
        }
        public static string Load_Active_DoiTra(string IDActive)
        {
            string str = "";
            var dt = DataAccess.DataAccess.SP_TRADTERM_DoiTra();
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Name.ToString() == IDActive)
                    str += "<option  selected=\"selected\"  value=\"" + dt[i].Name.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
                else
                    str += "<option value=\"" + dt[i].Name.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
            }
            return str;
        }
        public static string DoFormat(double myNumber)
        {
            try
            {
                var s = string.Format("{0:0.00}", myNumber);

                if (s.EndsWith("00"))
                {
                    if (s == "0.00")
                    {
                        return "";
                    }
                    return ((int)myNumber).ToString();
                }
                else
                {
                    return s;
                }
            }
            catch (Exception)
            {
                return ((int)myNumber).ToString();
            }
        }


    }
    public class Commond
    {
        public static string Date(object date)
        {
            return (Convert.ToDateTime(date).ToString("yyyy-MM-dd"));
        }
        public static string FormatMoney_VND(string money)
        {
            try
            {
                if (money != "0")
                {
                    double value = Convert.ToDouble(money.ToString());
                    string str = value.ToString("#,##,##");
                    return str.Replace(",", ",");
                }
                else
                {
                    return "0";
                }

            }
            catch (Exception)
            { }
            return "0";
        }
    }
}