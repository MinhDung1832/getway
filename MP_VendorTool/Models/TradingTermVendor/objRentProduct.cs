using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.TradingTermVendor
{
    public class objRentProduct
    {
        public string ContractNo { get; set; }
        public string VendorNo { get; set; }
        public string productcode { get; set; }
        public string productname { get; set; }
        public string barcode { get; set; }
        public string M2netSP { get; set; }
        public string M2FGrossSP { get; set; }
        public string CoatingShop { get; set; }
        public string NumberFace { get; set; }
        public string Mien { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string NgaybatDauThue { get; set; }
        public string NgayDieuChinhKetThuc { get; set; }
        public string TuDongGiaHan { get; set; }
        public string HieuLuc { get; set; }
    }

    public class objRentProduct_Brand
    {
        public string ContractNo { get; set; }
        public string VendorNo { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string SoCuaHangThue { get; set; }
        public string SoThang { get; set; }
        public string M2FThueCuaHang { get; set; }
        public string ChiPhiThueThangVAT { get; set; }
        public string TongChiPhiThueThangVAT { get; set; }
        public string TongChiPhiThueNam { get; set; }
        public string DSCamKetCuaHang { get; set; }
        public string NgayKyHD { get; set; }
        public string NgayHetHanHD { get; set; }
        public string NgaybatDauThue { get; set; }
        public string NgayDieuChinhKetThuc { get; set; }
        public string checkTuDongGiaHan { get; set; }
        public string HieuLuc { get; set; }
    }
    public class objRentProduct_Function
    {
        public string ContractNo { get; set; }
        public string VendorNo { get; set; }
        public string FunctionCode { get; set; }
        public string FunctionName { get; set; }
        public string barcode { get; set; }
        public string M2netSP { get; set; }
        public string M2FGrossSP { get; set; }
        public string CoatingShop { get; set; }
        public string NumberFace { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string HieuLuc { get; set; }
    }

    public class objThongTinChung
    {
        public string ContractNo { get; set; }
        public string VendorNo { get; set; }
        public string SoCuaHangThue { get; set; }
        public string SoThang { get; set; }
        public string M2FThueCuaHang { get; set; }
        public string ChiPhiThueThangVAT { get; set; }
        public string TongChiPhiThueThangVAT { get; set; }
        public string TongChiPhiThueNam { get; set; }
        public string DSCamKetCuaHang { get; set; }
        public string Mien { get; set; }
        public string NgayKyHD { get; set; }
        public string NgayHetHanHD { get; set; }
        public string NgaybatDauThue { get; set; }
        public string NgayDieuChinhKetThuc { get; set; }
        public string checkTuDongGiaHan { get; set; }
        public string HieuLuc { get; set; }
    }
}