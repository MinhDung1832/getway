using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Order
{
    public class objCombox
    {
        public string Code { set; get; }
        public string Name { set; get; }
    }
    public class objCombox_DoiTra
    {
        public string Name { set; get; }
    }
    public class ReturnedGoods
    {
        public string MaHang { set; get; }
        public string MaCH { set; get; }
        public string ID { set; get; }
        public string NCC { set; get; }
        public string NgayTraHang { set; get; }
        public string MoTa { set; get; }
        public string HisDateRRV { set; get; }
        public string SoLuong { set; get; }

    }

}