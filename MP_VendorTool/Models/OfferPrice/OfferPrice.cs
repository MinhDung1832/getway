using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.OfferPrice
{
    public class Obj_PriceOffer
    {
        public string MaCTKM { get; set; }
        public string ID { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string Barcode { get; set; }
        public string GiaTruocThayDoi { get; set; }
        public string GiaSauThayDoi { get; set; }
        public string GiaTruocThayDoiPlus { get; set; }
        public string GiaSauThayDoiPlus { get; set; }
        public string VAT { get; set; }
        public string ToDay { get; set; }
        public string FromDay { get; set; }
        public string Link { get; set; }
        public string GhiChu { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string NgayGuiDuyet { get; set; }
        public string NgayDieuChinhHieuLuc { get; set; }
        public string NgayHieuLuc_ThoaThuanHD { get; set; }
        public string GiaBanNYKhuyenNghi { get; set; }
        public string NgayThongBaoChinhThuc { get; set; }

    }
    public class priceOffer
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string VAT { set; get; }
        public string GiaTruocThayDoiPlus { set; get; }
    }

    public class BinhOnGia_ThiTruong
    {
        public string ID { get; set; }
        public string NCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string Images { get; set; }
        public string GiaBanAll { get; set; }
        public string GiaDoiThu { get; set; }
        public string TenDoiThu { get; set; }
        public string GiaGoiY { get; set; }
        public string GiaDieuChinh { get; set; }
        public string GiaMuaNet { get; set; }
        public string PhanTramGPMoi { get; set; }
        public string TrangThai { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
