using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Delivery
{
    public class DeliveryAdd
    {
        public string SourceSanPham { set; get; }
        public string SourceStore { set; get; }
    }

    public class Delivery_Add_Store
    {
        public string ID { set; get; }
        public string IDHeader { set; get; }
        public string NCC { set; get; }
        public string MaKho { set; get; }
        public string TenKho { set; get; }
        public string DiaChi { set; get; }
        public string ThoiGianXuatKho { set; get; }
        public string LeaderTime { set; get; }
        public string LichGHT2 { set; get; }
        public string LichGHT3 { set; get; }
        public string LichGHT4 { set; get; }
        public string LichGHT5 { set; get; }
        public string LichGHT6 { set; get; }
        public string LichGHT7 { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }
    }

    public class Delivery_Add_Productrs
    {
        public string ID { set; get; }
        public string IDHeader { set; get; }
        public string NCC { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }
    }
}