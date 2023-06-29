using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Product
{
    public class Products_Vender
    {
        public string ID { get; set; }
        public string IDProducst { get; set; }
        public string VendorName { get; set; }
        public string VendorCode { get; set; }
        public string TenSanPham { get; set; }
        public string Barcode { get; set; }
        public string FunctionName { get; set; }
        public string FunctionCode { get; set; }
        public string DivisionName { get; set; }
        public string DivisionCode { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public string DivisionERPName { get; set; }
        public string DivisionERPCode { get; set; }
        public string CategoryERPName { get; set; }
        public string CategoryERPCode { get; set; }
        public string GroupERPCode { get; set; }
        public string GroupERPName { get; set; }
        public string HHKG { get; set; }
        public string MuaVuCode { get; set; }
        public string MuaVuName { get; set; }
        public string ThuongHieuCode { get; set; }
        public string ThuongHieuName { get; set; }
        public string NguonNhapCode { get; set; }
        public string NguonNhapName { get; set; }
        public string XuatXuCode { get; set; }
        public string XuatXuName { get; set; }
        public string DonViTinhCode { get; set; }
        public string DonViTinhName { get; set; }
        public string TrongLuong { get; set; }
        public string KichThuocDai { get; set; }
        public string KichThuocRong { get; set; }
        public string KichThuocCao { get; set; }
        public string QuyCachDGSanPhamCode { get; set; }
        public string QuyCachDGSanPhamName { get; set; }
        public string QuyCachDGSanPham { get; set; }
        public string QuyCachDGSanPhamLocCode { get; set; }
        public string QuyCachDGSanPhamLocName { get; set; }
        public string QuyCachDGSanPhamLoc { get; set; }
        public string QuyCachDGSanPhamThungCode { get; set; }
        public string QuyCachDGSanPhamThungName { get; set; }
        public string QuyCachDGSanPhamThung { get; set; }
        public string KichThuocDaiCm { get; set; }
        public string KichThuocRongCm { get; set; }
        public string KichThuocCaoCm { get; set; }
        public string GiaMuaTruVat { get; set; }
        public string LineDiscount { get; set; }
        public string PTVAT { get; set; }
        public string GiaMuaCongVAT { get; set; }
        public string GiaBanNiemYet { get; set; }
        public string LinkSanPham { get; set; }
        public string MoTaSanPham { get; set; }
        public string AnhSanPham { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string NgayGuiDuyetERP { get; set; }
        public string NguoiDuyetERRP { get; set; }
        public string JsonAPI { get; set; }
        public string IsCheckMauThu { get; set; }
        public string IsCheckPhanLoaiHHoa { get; set; }
        public string SLTonHienCo { get; set; }
        public string KhoXuatHang { get; set; }
        public string ThoiGianGiaoHang { get; set; }
        public string SLToiThieu { get; set; }
        public string IsCheckChinhSach { get; set; }

    }
    public class Update_Products_Vender
    {
        public string ID { get; set; }
        public string Status { get; set; }
        public string ModifyBy { get; set; }
    }
    public class Update_Products_Vender_New
    {
        public string IDProducst { get; set; }
        public string Status { get; set; }
        public string ModifyBy { get; set; }
    }

    public class Products_Vender_Size_Color
    {
        public string NameSize { get; set; }
        public string NameMau { get; set; }
        public string Barcode { get; set; }
    }
    public class Products_Vender_SentFile
    {
        public string ID { get; set; }
        public string IDProducst { get; set; }
        public string VendorNo { get; set; }
        public string NoiDung { get; set; }
        public string NguoiDanhGia { get; set; }
        public string GhiChu { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string KieuGui { get; set; }
        public string TrangThai { get; set; }
    }
}