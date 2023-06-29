using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Order
{
    public class objPurchaseOrder
    {
        public string No_ { set; get; }
        public string OrderDate { set; get; }
        public string status { set; get; }
        public string locationCode { set; get; }
        public string PROrderNo { set; get; }
        public string StoreName { set; get; }
        public string VendorName { set; get; }
        public int TotalOutstanding { set; get; }

        public decimal TotalProductNum { set; get; }
        public decimal TotalOrderQtty { set; get; }
        public decimal TotalOrdersVolume { set; get; }
        public decimal TotalDirectUnitCost { set; get; }
        public decimal TotalQuantity { set; get; }
        public string NgayXacNhanDonHang { set; get; }
        public decimal sumTongTien { set; get; }

        public decimal DirectUnitCostTruVAT { set; get; }
        public decimal DirectUnitCostCongVAT { set; get; }


        public decimal TotalTongTienTruVAT_No_Active { set; get; }
        public decimal TotalTongTienTruVAT_Active { set; get; }
        public decimal TotalTongTienCongVAT_No_Active { set; get; }
        public decimal TotalTongTienCongVAT_Active { set; get; }
        public decimal TotalSLGiao { set; get; }

        public decimal TotalTongSLDaGiaoHang { set; get; }
    }
    public class obj_Order_Exel
    {
        public string No_ { set; get; }
        public string LocationCode { set; get; }
        public string OrderDate { set; get; }
    }
    public class objItem
    {
        public string NgayGiaoHang { set; get; }
        public string MaHH { set; get; }
        public string TenHangHoa { set; get; }
        public string MaKho { set; get; }
        public decimal DonGia { set; get; }
        public decimal SLDat { set; get; }
        public decimal SLGiao { set; get; }
        public string ThanhTienTruVAT { set; get; }
        public string lineDiscout { set; get; }

    }
}