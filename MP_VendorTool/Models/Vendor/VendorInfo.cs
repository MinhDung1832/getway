using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Vendor
{
    public class VendorInfo
    {
        public string id { set; get; }
        public string businessType { set; get; }
        public string businessName { set; get; }
        public string firmName { set; get; }
        public string Address { set; get; }
        public string phoneNo { set; get; }
        public string website { set; get; }
        public string email { set; get; }
        public string facebook { set; get; }
        public string industryType { set; get; }
        public string industryName { set; get; }
        public string registrationBusiness { set; get; }
        public string registrationTax { set; get; }
        public string bankAccount { set; get; }
        public string atBank { set; get; }
        public string bankName { set; get; }
        public string E_Invoice { set; get; }
        public string ERP_Name { set; get; }
        public string ERP_Name_SS { set; get; }
        public string createdDate { set; get; }
        public string status { set; get; }
        public string VendorContact_ID { set; get; }
        public string Vendor_No { set; get; }
    }

    public class HoangHoa
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string VAT { set; get; }
        public string GiaApDungCK { set; get; }
    }
    public class DanhMucHoangHoa
    {
        public string GiaApDungCK { set; get; }
        public string PTCKDon { set; get; }
        public string VAT { set; get; }
    }
    public class Exel_TTChung_ThueKe
    {
        public string SoCuaHangThue { set; get; }
        public string SoThang { set; get; }
        public string M2FThueCuaHang { set; get; }
        public string ChiPhiThueThangVAT { set; get; }
        public string TongChiPhiThueThangVAT { set; get; }
        public string TongChiPhiThueNam { set; get; }
        public string DSCamKetCuaHang { set; get; }
        public string Mien { set; get; }
        public string NgayKyHD { set; get; }
        public string NgayHetHanHD { set; get; }
        public string NgaybatDauThue { set; get; }
        public string NgayDieuChinhKetThuc { set; get; }
        public string CheckTuDongGiaHan { set; get; }
        public string CheckHieuLuc { set; get; }
    }
    public class TBL_TRADTERM_Exel_SKU_THUEKE
    {
        public string MaHang { set; get; }
        public string M2netSP { set; get; }
        public string M2FGrossSP { set; get; }
        public string SoCuaHangPhu { set; get; }
        public string SoMatTBCH { set; get; }
        public string Mien { set; get; }
        public string NgayBatDau { set; get; }
        public string NgayKetThuc { set; get; }
        public string NgaybatDauThue { set; get; }
        public string NgayDieuChinhKetThuc { set; get; }
        public string CheckTuDongGiaHan { set; get; }
        public string CheckHieuLuc { set; get; }

    }

}