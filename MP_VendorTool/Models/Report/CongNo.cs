using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Report
{
    public class CongNo
    {
        public string thang { set; get; }
        public string nam { set; get; }
        public string MaNCC { set; get; }
        public string HHKGTKE { set; get; }
        public string NccName { set; get; }
        public string MaHang { set; get; }
        public string Giaban { set; get; }
        public string Tenhang { set; get; }
        public string QuantityMB { set; get; }
        public string QuantityMN { set; get; }
        public string Quantity { set; get; }
        public string AmountMB { set; get; }
        public string AmountMN { set; get; }
        public string Amount { set; get; }
        public string DiscountAmountMB { set; get; }
        public string DiscountAmountMN { set; get; }
        public string DiscountAmount { set; get; }
        public string QuantityDHMB { set; get; }
        public string QuantityDHMN { set; get; }
        public string QuantityDH { set; get; }
        public string AmountDHMB { set; get; }
        public string AmountDHMN { set; get; }
        public string AmountDH { set; get; }
        public string Status { set; get; }

    }

    public class obj_ThuongDinhHuong
    {
        public string MaHang { set; get; }
        public string Tenhang { set; get; }
        public string QuantityMB { set; get; }
        public string QuantityMN { set; get; }
        public string SLTong { set; get; }
        public string AmountMN { set; get; }
        
    }
    public class obj_DebtDeposit
    {
        public string MaHang { set; get; }
        public string Tenhang { set; get; }
        public string NccName { set; get; }
        public string MaNCC { set; get; }
        public string QuantityMB { set; get; }
        public string QuantityMN { set; get; }
        public string SLTong { set; get; }
        public string AmountMB { set; get; }
        public string AmountMN { set; get; }
        public string PhiTong { set; get; }
        public string CPDinhHuong { set; get; }
        public string TrangThai { set; get; }
    }
}