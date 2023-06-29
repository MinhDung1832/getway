using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.Product
{
    public class API_Product
    {
        public string Item_Registration_No { get; set; }
        public string Vendor_No { get; set; }
        public string Country_of_Origin { get; set; }
        public string New_Items_No_Series { get; set; }
        public string Barcode_Mask { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Vietnamese_Description { get; set; }
        public string Division { get; set; }
        public string Category { get; set; }
        public string Product_Group { get; set; }
        public string SubClass { get; set; }
        public string Brand { get; set; }
        public string Base_Unit_of_Measure { get; set; }
        public string VAT_Input { get; set; }
        public string VAT_Output { get; set; }
        public string Gen_Product_Posting_Group { get; set; }
        public string Vendor_Item_No { get; set; }
        public decimal Sales_Price_Incl_VAT { get; set; }
        public string Sale_StartDate { get; set; }
        public string Sale_EndDate { get; set; }
        public string Inv_Posting_Group { get; set; }
        public decimal Purchase_Price { get; set; }
        public string Purchase_StartDate { get; set; }
        public string Purchase_EndDate { get; set; }
        public string Season_Code { get; set; }

        public string BarcodeHeader { get; set; }
    }

    public class Retun_Product
    {
        public bool codeReturn { set; get; }
        public string message { set; get; }

    }
    public class ChangeProductInfo
    {
        public int ApproveID { set; get; }
        public string VendorCode { set; get; }
        public string ChangeType { set; get; }
        public string VendorContactID { set; get; }
        public string VendorName { set; get; }
        public string BBM_Code { set; get; }
        public string ProductName { set; get; }
        public string Oldprice { set; get; }
        public string NewPrice { set; get; }
        public string Status { set; get; }
        public string StatusName { set; get; }
    }
    public class Product_add
    {
        public string SourceHeader { set; get; }
        public string SourceLine { set; get; }
    }
    public class Product_Size
    {
        public string IDProducst { set; get; }
        public string NCC { set; get; }
        public string Size { set; get; }
        public string Mau { set; get; }
        public string SizeName { set; get; }
        public string MauName { set; get; }
        public string Barcode { set; get; }
    }

    public class Add_Products_Vender_QuyCach
    {
        public string DonViTinhCode { get; set; }
        public string DonViTinhName { get; set; }
        public string SoLuong { get; set; }
        public string TrongLuong { get; set; }
        public string KichThuocDai { get; set; }
        public string KichThuocRong { get; set; }
        public string KichThuocCao { get; set; }
    }
    public class Send_Products_Vender_QuyCach
    {
        public string productId { get; set; }
        public string VendorCode { get; set; }
        public string DonViTinhCode { get; set; }
        public string DonViTinhName { get; set; }
        public string SoLuong { get; set; }
        public string TrongLuong { get; set; }
        public string KichThuocDai { get; set; }
        public string KichThuocRong { get; set; }
        public string KichThuocCao { get; set; }
        public string CreateBy { get; set; }
    }
    public class Get_Products_Vender_QuyCach
    {
        public string productId { get; set; }
        public string VendorCode { get; set; }
        public string DonViTinhCode { get; set; }
        public string DonViTinhName { get; set; }
        public decimal SoLuong { get; set; }
        public decimal TrongLuong { get; set; }
        public decimal KichThuocDai { get; set; }
        public decimal KichThuocRong { get; set; }
        public decimal KichThuocCao { get; set; }
        public string CreateBy { get; set; }
    }
    public class ProductInfoERP
    {
        public string id { set; get; }
        public string functionCode { set; get; }
        public string MaNCC { set; get; }
        public string manufactureCode { set; get; }
        public string GenProPostingGroupCode { set; get; }
        public string name { set; get; }
        public string brand { set; get; }
        public string UoM { set; get; }
        public string priceRetail { set; get; }
        public string SeasonCode { set; get; }
        public string GiaBanNiemYet { set; get; }
        public string VAT { set; get; }
        public string groupCode { set; get; }
        public string categoryCode { set; get; }
        public string divisionCode { set; get; }
        public string New_Items_No_Series { set; get; }
        public string BarcodeMaskHeard { set; get; }
        public string barcodeHeard { set; get; }
        public string barcode { set; get; }
        public string Purchase_Price { set; get; }

    }


    public class ProductInfo
    {
        public string id { set; get; }
        public string MaNCC { set; get; }
        public string registrationTax { set; get; }
        public string BBM_Code { set; get; } = "";
        public string divisionCode { set; get; }
        public string divisionName { set; get; }
        public string categoryCode { set; get; }
        public string categoryName { set; get; }
        public string groupCode { set; get; }
        public string groupName { set; get; }
        public string functionCode { set; get; }
        public string functionName { set; get; }
        public string name { set; get; }
        public string brand { set; get; }
        public string manufactureCode { set; get; }
        public string manufactureName { set; get; }
        public string UoM { set; get; }
        public string UoM_Name { set; get; }
        public string weight { set; get; }
        public string dimensionLength { set; get; }
        public string dimensionWidth { set; get; }
        public string dimensionHeight { set; get; }
        public string QtyBox { set; get; }
        public string QtyBox1 { set; get; }
        public string QtyBox2 { set; get; }
        public string QtyBox3 { set; get; }
        public string UoM1 { set; get; }
        public string UoM2 { set; get; }
        public string UoM3 { set; get; }

        public string boxLength { set; get; }
        public string boxWidth { set; get; }
        public string boxHeight { set; get; }
        public string imgLink { set; get; }
        public string url { set; get; }
        public string barcode { set; get; }
        public string priceRetail { set; get; }
        public string VAT { set; get; }
        public string priceCost { set; get; }
        public string priceCost1 { set; get; }
        public string priceCost2 { set; get; }
        public string faceQty { set; get; }
        public string MOQ { set; get; }
        public string realityInventories { set; get; }
        public string createdDate { set; get; }
        public string status { set; get; }
        public string statusAppr { set; get; }
        public string modifyDate { set; get; }
        public string modifyBy { set; get; }
        public string description { set; get; }
        public string VendorContact_ID { set; get; }

        //
        public string NgayDuyet { set; get; }
        public string NguoiDuyet { set; get; }
        public string LyDo { set; get; }
        public string ThongBaoERP { set; get; }
        public string GenProPostingGroupCode { set; get; }
        public string SeasonCode { set; get; }
        public string Conten { set; get; }
        public string GiaBanNiemYet { set; get; }
        public string New_Items_No_Series { set; get; }
        public string BarcodeMaskHeard { set; get; }
        public string barcodeHeard { set; get; }
        public string Purchase_Price { set; get; }
        public string priceTruVAT { set; get; }


        //

        public string DivisionERP { set; get; }
        public string DivisionERPCode { set; get; }
        public string CategoryERP { set; get; }
        public string CategoryERPCode { set; get; }
        public string GroupERP { set; get; }
        public string GroupERPCode { set; get; }
        public string NguonNhap { set; get; }
        public string NguonNhapCode { set; get; }
        public string LineDiscount { set; get; }
        public string NhieuAnh { set; get; }
        public string IDProducst { set; get; }
    }

    public class Orientation_Bonus
    {
        public string ID { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string TenNCC { set; get; }
        public string MaNCC { set; get; }
        public string Brand { set; get; }
        public string ACMCode { set; get; }
        public string ACMName { set; get; }
        public decimal Bonus { set; get; }
        public string PhamViCode { set; get; }
        public string PhamViName { set; get; }
        public string NgayBatDau { set; get; }
        public string NgayKetThuc { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public string ModifyDate { set; get; }
    }
    public class AR_ITEM
    {
        public string ID { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string TenNCC { set; get; }
        public string MaNCC { set; get; }
        public string Store_Code { set; get; }
        public string Store_Name { set; get; }
        public string ACMCode { set; get; }
        public string ACMName { set; get; }
        public string PhamViCode { set; get; }
        public string PhamViName { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public string ModifyDate { set; get; }
    }
    public class ProductInfoAdd
    {
        public string ID { set; get; }
        public string IDProducst { set; get; }
    }
    public class ProductInfoNew
    {
        public string ID { set; get; }
        public string IDProducst { set; get; }
        public string VendorName { set; get; }
        public string VendorCode { set; get; }
        public string TenSanPham { set; get; }
        public string Barcode { set; get; }
        public string FunctionName { set; get; }
        public string FunctionCode { set; get; }
        public string DivisionName { set; get; }
        public string DivisionCode { set; get; }
        public string CategoryName { set; get; }
        public string CategoryCode { set; get; }
        public string GroupName { set; get; }
        public string GroupCode { set; get; }
        public string DivisionERPName { set; get; }
        public string DivisionERPCode { set; get; }
        public string CategoryERPName { set; get; }
        public string CategoryERPCode { set; get; }
        public string GroupERPCode { set; get; }
        public string GroupERPName { set; get; }
        public string HHKG { set; get; }
        public string MuaVuCode { set; get; }
        public string MuaVuName { set; get; }
        public string ThuongHieuCode { set; get; }
        public string ThuongHieuName { set; get; }
        public string NguonNhapCode { set; get; }
        public string NguonNhapName { set; get; }
        public string XuatXuCode { set; get; }
        public string XuatXuName { set; get; }
        public string DonViTinhCode { set; get; }
        public string DonViTinhName { set; get; }
        public string TrongLuong { set; get; }
        public string KichThuocDai { set; get; }
        public string KichThuocRong { set; get; }
        public string KichThuocCao { set; get; }
        public string QuyCachDGSanPhamCode { set; get; }
        public string QuyCachDGSanPhamName { set; get; }
        public string QuyCachDGSanPham { set; get; }
        public string QuyCachDGSanPhamLocCode { set; get; }
        public string QuyCachDGSanPhamLocName { set; get; }
        public string QuyCachDGSanPhamLoc { set; get; }
        public string QuyCachDGSanPhamThungCode { set; get; }
        public string QuyCachDGSanPhamThungName { set; get; }
        public string QuyCachDGSanPhamThung { set; get; }
        public string KichThuocDaiCm { set; get; }
        public string KichThuocRongCm { set; get; }
        public string KichThuocCaoCm { set; get; }
        public string GiaMuaTruVat { set; get; }
        public string LineDiscount { set; get; }
        public string PTVAT { set; get; }
        public string GiaMuaCongVAT { set; get; }
        public string GiaBanNiemYet { set; get; }
        public string LinkSanPham { set; get; }
        public string MoTaSanPham { set; get; }
        public string AnhSanPham { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }
        public string NgayGuiDuyetERP { set; get; }
        public string NguoiDuyetERRP { set; get; }
        public string JsonAPI { set; get; }
        public string SLTonHienCo { set; get; }
        public string KhoXuatHang { set; get; }
        public string ThoiGianGiaoHang { set; get; }
        public string SLToiThieu { set; get; }
        public string IsCheckChinhSach { set; get; }
        public string IsCheckPhanLoaiHHoa { set; get; }
    }
}