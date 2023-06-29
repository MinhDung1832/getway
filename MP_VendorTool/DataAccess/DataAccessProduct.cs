using Lib.Utils.Package;
using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Order;
using Newtonsoft.Json;
using ProductAllTool.Models.Product;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace MP_VendorTool.DataAccess
{
    public class DataAccessProduct
    {
        private static string strCon = ConfigurationManager.AppSettings.Get("strConnSpac");
        public static List<objCombox> Get_AllNCC_Info_Products_Vender()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Get_AllNCC_Info_Products_Vender", con);//
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_AllNCC_Info_Products_Vender");
                    return it_r;
                }
            }
        }
        public static DataTable Get_List_Info_Products_Vender(string Status, string Name, string MaNCC, string Barcode)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Get_List_Info_Products_Vender_GetWay", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("Name", Name != null ? Name : ""));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("Barcode", Barcode));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_Info_Products_Vender");
                return ds.Tables[0];
            }
        }
        public static DataTable Get_List_Info_Products_Vender_Update(string Status, string Name, string MaNCC, string Barcode)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Get_List_Info_Products_Vender_GetWay_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", MaNCC));
                    cmd.Parameters.Add(new SqlParameter("Name", Name != null ? Name : ""));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("Barcode", Barcode));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_Info_Products_Vender");
                return ds.Tables[0];
            }
        }
        public static bool SP_BBM_Info_Products_Vender_Add(ProductInfoNew it, string uid, string IDProducst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_Info_Products_Vender_Add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("IDProducst", IDProducst != null ? IDProducst : ""));
                    cmd.Parameters.Add(new SqlParameter("VendorName", it.VendorName != null ? it.VendorName : ""));
                    cmd.Parameters.Add(new SqlParameter("VendorCode", it.VendorCode != null ? it.VendorCode : ""));
                    cmd.Parameters.Add(new SqlParameter("TenSanPham", it.TenSanPham != null ? it.TenSanPham : ""));
                    cmd.Parameters.Add(new SqlParameter("Barcode", it.Barcode != null ? it.Barcode : ""));

                    cmd.Parameters.Add(new SqlParameter("FunctionName", it.FunctionName != null ? it.FunctionName : ""));
                    cmd.Parameters.Add(new SqlParameter("FunctionCode", it.FunctionCode != null ? it.FunctionCode : ""));
                    cmd.Parameters.Add(new SqlParameter("DivisionName", it.DivisionName != null ? it.DivisionName : ""));
                    cmd.Parameters.Add(new SqlParameter("DivisionCode", it.DivisionCode != null ? it.DivisionCode : ""));
                    cmd.Parameters.Add(new SqlParameter("CategoryName", it.CategoryName != null ? it.CategoryName : ""));
                    cmd.Parameters.Add(new SqlParameter("CategoryCode", it.CategoryCode != null ? it.CategoryCode : ""));

                    cmd.Parameters.Add(new SqlParameter("GroupName", it.GroupName != null ? it.GroupName : ""));
                    cmd.Parameters.Add(new SqlParameter("GroupCode", it.GroupCode != null ? it.GroupCode : ""));
                    cmd.Parameters.Add(new SqlParameter("DivisionERPName", it.DivisionERPName != null ? it.DivisionERPName : ""));
                    cmd.Parameters.Add(new SqlParameter("DivisionERPCode", it.DivisionERPCode != null ? it.DivisionERPCode : ""));
                    cmd.Parameters.Add(new SqlParameter("CategoryERPName", it.CategoryERPName != null ? it.CategoryERPName : ""));
                    cmd.Parameters.Add(new SqlParameter("CategoryERPCode", it.CategoryERPCode != null ? it.CategoryERPCode : ""));
                    cmd.Parameters.Add(new SqlParameter("GroupERPCode", it.GroupERPCode != null ? it.GroupERPCode : ""));
                    cmd.Parameters.Add(new SqlParameter("GroupERPName", it.GroupERPName != null ? it.GroupERPName : ""));


                    cmd.Parameters.Add(new SqlParameter("HHKG", it.HHKG != null ? it.HHKG : ""));
                    cmd.Parameters.Add(new SqlParameter("MuaVuCode", it.MuaVuCode != null ? it.MuaVuCode : ""));
                    cmd.Parameters.Add(new SqlParameter("MuaVuName", it.MuaVuName != null ? it.MuaVuName : ""));
                    cmd.Parameters.Add(new SqlParameter("ThuongHieuCode", it.ThuongHieuCode != null ? it.ThuongHieuCode : ""));
                    cmd.Parameters.Add(new SqlParameter("ThuongHieuName", it.ThuongHieuName != null ? it.ThuongHieuName : ""));
                    cmd.Parameters.Add(new SqlParameter("NguonNhapCode", it.NguonNhapCode != null ? it.NguonNhapCode : ""));
                    cmd.Parameters.Add(new SqlParameter("NguonNhapName", it.NguonNhapName != null ? it.NguonNhapName : ""));
                    cmd.Parameters.Add(new SqlParameter("XuatXuCode", it.XuatXuCode != null ? it.XuatXuCode : ""));
                    cmd.Parameters.Add(new SqlParameter("XuatXuName", it.XuatXuName != null ? it.XuatXuName : ""));

                    cmd.Parameters.Add(new SqlParameter("DonViTinhCode", it.DonViTinhCode != null ? it.DonViTinhCode : "0"));
                    cmd.Parameters.Add(new SqlParameter("DonViTinhName", it.DonViTinhName != null ? it.DonViTinhName : "0"));
                    //cmd.Parameters.Add(new SqlParameter("TrongLuong", it.TrongLuong != null ? it.TrongLuong.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("KichThuocDai", it.KichThuocDai != null ? it.KichThuocDai.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("KichThuocRong", it.KichThuocRong != null ? it.KichThuocRong.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("KichThuocCao", it.KichThuocCao != null ? it.KichThuocCao.Replace(",", "") : "0"));

                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamCode", it.QuyCachDGSanPhamCode != null ? it.QuyCachDGSanPhamCode : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamName", it.QuyCachDGSanPhamName != null ? it.QuyCachDGSanPhamName : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPham", it.QuyCachDGSanPham != null ? it.QuyCachDGSanPham.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamLocCode", it.QuyCachDGSanPhamLocCode != null ? it.QuyCachDGSanPhamLocCode : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamLocName", it.QuyCachDGSanPhamLocName != null ? it.QuyCachDGSanPhamLocName : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamLoc", it.QuyCachDGSanPhamLoc != null ? it.QuyCachDGSanPhamLoc.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamThungCode", it.QuyCachDGSanPhamThungCode != null ? it.QuyCachDGSanPhamThungCode : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamThungName", it.QuyCachDGSanPhamThungName != null ? it.QuyCachDGSanPhamThungName : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamThung", it.QuyCachDGSanPhamThung != null ? it.QuyCachDGSanPhamThung.Replace(",", "") : "0"));


                    //cmd.Parameters.Add(new SqlParameter("KichThuocDaiCm", it.KichThuocDaiCm != null ? it.KichThuocDaiCm.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("KichThuocRongCm", it.KichThuocRongCm != null ? it.KichThuocRongCm.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("KichThuocCaoCm", it.KichThuocCaoCm != null ? it.KichThuocCaoCm.Replace(",", "") : "0"));


                    cmd.Parameters.Add(new SqlParameter("GiaMuaTruVat", Decimal.Parse(it.GiaMuaTruVat != null ? it.GiaMuaTruVat.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("LineDiscount", Decimal.Parse(it.LineDiscount != null ? it.LineDiscount.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("PTVAT", it.PTVAT != null ? it.PTVAT : "0"));
                    cmd.Parameters.Add(new SqlParameter("GiaMuaCongVAT", Decimal.Parse(it.GiaMuaCongVAT != null ? it.GiaMuaCongVAT.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("GiaBanNiemYet", Decimal.Parse(it.GiaBanNiemYet != null ? it.GiaBanNiemYet.Replace(",", "") : "0")));


                    cmd.Parameters.Add(new SqlParameter("LinkSanPham", it.LinkSanPham != null ? it.LinkSanPham : ""));
                    cmd.Parameters.Add(new SqlParameter("MoTaSanPham", it.MoTaSanPham != null ? it.MoTaSanPham : ""));
                    cmd.Parameters.Add(new SqlParameter("AnhSanPham", it.AnhSanPham != null ? it.AnhSanPham.TrimEnd(',') : ""));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", uid != null ? uid : ""));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_Info_Products_Vender_Add");
                    return false;
                }
            }
        }
        public async static Task<bool> SP_BBM_Info_Products_Vender_Save(ProductInfoNew it, string uid, string IDProducst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_Info_Products_Vender_Save", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("productId", it.ID != null ? it.ID : ""));
                    cmd.Parameters.Add(new SqlParameter("IDProducst", IDProducst != null ? IDProducst : ""));
                    cmd.Parameters.Add(new SqlParameter("VendorName", it.VendorName != null ? it.VendorName : ""));
                    cmd.Parameters.Add(new SqlParameter("VendorCode", it.VendorCode != null ? it.VendorCode : ""));
                    cmd.Parameters.Add(new SqlParameter("TenSanPham", it.TenSanPham != null ? it.TenSanPham : ""));
                    cmd.Parameters.Add(new SqlParameter("Barcode", it.Barcode != null ? it.Barcode : ""));

                    cmd.Parameters.Add(new SqlParameter("FunctionName", it.FunctionName != null ? it.FunctionName : ""));
                    cmd.Parameters.Add(new SqlParameter("FunctionCode", it.FunctionCode != null ? it.FunctionCode : ""));
                    cmd.Parameters.Add(new SqlParameter("DivisionName", it.DivisionName != null ? it.DivisionName : ""));
                    cmd.Parameters.Add(new SqlParameter("DivisionCode", it.DivisionCode != null ? it.DivisionCode : ""));
                    cmd.Parameters.Add(new SqlParameter("CategoryName", it.CategoryName != null ? it.CategoryName : ""));
                    cmd.Parameters.Add(new SqlParameter("CategoryCode", it.CategoryCode != null ? it.CategoryCode : ""));

                    cmd.Parameters.Add(new SqlParameter("GroupName", it.GroupName != null ? it.GroupName : ""));
                    cmd.Parameters.Add(new SqlParameter("GroupCode", it.GroupCode != null ? it.GroupCode : ""));
                    cmd.Parameters.Add(new SqlParameter("DivisionERPName", it.DivisionERPName != null ? it.DivisionERPName : ""));
                    cmd.Parameters.Add(new SqlParameter("DivisionERPCode", it.DivisionERPCode != null ? it.DivisionERPCode : ""));
                    cmd.Parameters.Add(new SqlParameter("CategoryERPName", it.CategoryERPName != null ? it.CategoryERPName : ""));
                    cmd.Parameters.Add(new SqlParameter("CategoryERPCode", it.CategoryERPCode != null ? it.CategoryERPCode : ""));
                    cmd.Parameters.Add(new SqlParameter("GroupERPCode", it.GroupERPCode != null ? it.GroupERPCode : ""));
                    cmd.Parameters.Add(new SqlParameter("GroupERPName", it.GroupERPName != null ? it.GroupERPName : ""));


                    cmd.Parameters.Add(new SqlParameter("HHKG", it.HHKG != null ? it.HHKG : ""));
                    cmd.Parameters.Add(new SqlParameter("MuaVuCode", it.MuaVuCode != null ? it.MuaVuCode : ""));
                    cmd.Parameters.Add(new SqlParameter("MuaVuName", it.MuaVuName != null ? it.MuaVuName : ""));
                    cmd.Parameters.Add(new SqlParameter("ThuongHieuCode", it.ThuongHieuCode != null ? it.ThuongHieuCode : ""));
                    cmd.Parameters.Add(new SqlParameter("ThuongHieuName", it.ThuongHieuName != null ? it.ThuongHieuName : ""));
                    cmd.Parameters.Add(new SqlParameter("NguonNhapCode", it.NguonNhapCode != null ? it.NguonNhapCode : ""));
                    cmd.Parameters.Add(new SqlParameter("NguonNhapName", it.NguonNhapName != null ? it.NguonNhapName : ""));
                    cmd.Parameters.Add(new SqlParameter("XuatXuCode", it.XuatXuCode != null ? it.XuatXuCode : ""));
                    cmd.Parameters.Add(new SqlParameter("XuatXuName", it.XuatXuName != null ? it.XuatXuName : ""));

                    cmd.Parameters.Add(new SqlParameter("DonViTinhCode", it.DonViTinhCode != null ? it.DonViTinhCode : "0"));
                    cmd.Parameters.Add(new SqlParameter("DonViTinhName", it.DonViTinhName != null ? it.DonViTinhName : "0"));


                    //cmd.Parameters.Add(new SqlParameter("TrongLuong", it.TrongLuong != null ? it.TrongLuong.Replace(",", "") : "0"));

                    //cmd.Parameters.Add(new SqlParameter("KichThuocDai", it.KichThuocDai != null ? it.KichThuocDai.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("KichThuocRong", it.KichThuocRong != null ? it.KichThuocRong.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("KichThuocCao", it.KichThuocCao != null ? it.KichThuocCao.Replace(",", "") : "0"));

                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamCode", it.QuyCachDGSanPhamCode != null ? it.QuyCachDGSanPhamCode : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamName", it.QuyCachDGSanPhamName != null ? it.QuyCachDGSanPhamName : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPham", it.QuyCachDGSanPham != null ? it.QuyCachDGSanPham.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamLocCode", it.QuyCachDGSanPhamLocCode != null ? it.QuyCachDGSanPhamLocCode : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamLocName", it.QuyCachDGSanPhamLocName != null ? it.QuyCachDGSanPhamLocName : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamLoc", it.QuyCachDGSanPhamLoc != null ? it.QuyCachDGSanPhamLoc.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamThungCode", it.QuyCachDGSanPhamThungCode != null ? it.QuyCachDGSanPhamThungCode : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamThungName", it.QuyCachDGSanPhamThungName != null ? it.QuyCachDGSanPhamThungName : "0"));
                    //cmd.Parameters.Add(new SqlParameter("QuyCachDGSanPhamThung", it.QuyCachDGSanPhamThung != null ? it.QuyCachDGSanPhamThung.Replace(",", "") : "0"));


                    //cmd.Parameters.Add(new SqlParameter("KichThuocDaiCm", it.KichThuocDaiCm != null ? it.KichThuocDaiCm.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("KichThuocRongCm", it.KichThuocRongCm != null ? it.KichThuocRongCm.Replace(",", "") : "0"));
                    //cmd.Parameters.Add(new SqlParameter("KichThuocCaoCm", it.KichThuocCaoCm != null ? it.KichThuocCaoCm.Replace(",", "") : "0"));


                    cmd.Parameters.Add(new SqlParameter("GiaMuaTruVat", Decimal.Parse(it.GiaMuaTruVat != null ? it.GiaMuaTruVat.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("LineDiscount", Decimal.Parse(it.LineDiscount != null ? it.LineDiscount.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("PTVAT", it.PTVAT != null ? it.PTVAT : "0"));
                    cmd.Parameters.Add(new SqlParameter("GiaMuaCongVAT", Decimal.Parse(it.GiaMuaCongVAT != null ? it.GiaMuaCongVAT.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("GiaBanNiemYet", Decimal.Parse(it.GiaBanNiemYet != null ? it.GiaBanNiemYet.Replace(",", "") : "0")));


                    cmd.Parameters.Add(new SqlParameter("LinkSanPham", it.LinkSanPham != null ? it.LinkSanPham : ""));
                    cmd.Parameters.Add(new SqlParameter("MoTaSanPham", it.MoTaSanPham != null ? it.MoTaSanPham : ""));
                    cmd.Parameters.Add(new SqlParameter("AnhSanPham", it.AnhSanPham != null ? it.AnhSanPham.TrimEnd(',') : ""));
                    cmd.Parameters.Add(new SqlParameter("ModifyBy", it.ModifyBy != null ? it.ModifyBy : ""));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_Info_Products_Vender_Save");
                    return false;
                }
            }
        }
        public async static Task<bool> SP_BBM_Info_Products_Vender_Save_ChinhSach_GiaoHang(ProductInfoNew it)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_Info_Products_Vender_Save_ChinhSach_GiaoHang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("productId", it.ID != null ? it.ID : ""));

                    cmd.Parameters.Add(new SqlParameter("GiaMuaTruVat", Decimal.Parse(it.GiaMuaTruVat != null ? it.GiaMuaTruVat.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("LineDiscount", Decimal.Parse(it.LineDiscount != null ? it.LineDiscount.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("PTVAT", it.PTVAT != null ? it.PTVAT : "0"));
                    cmd.Parameters.Add(new SqlParameter("GiaMuaCongVAT", Decimal.Parse(it.GiaMuaCongVAT != null ? it.GiaMuaCongVAT.Replace(",", "") : "0")));
                    //  cmd.Parameters.Add(new SqlParameter("GiaBanNiemYet", Decimal.Parse(it.GiaBanNiemYet != null ? it.GiaBanNiemYet.Replace(",", "") : "0")));

                    cmd.Parameters.Add(new SqlParameter("SLTonHienCo", Decimal.Parse(it.SLTonHienCo != null ? it.SLTonHienCo.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("KhoXuatHang", it.KhoXuatHang != null ? it.KhoXuatHang : ""));
                    cmd.Parameters.Add(new SqlParameter("ThoiGianGiaoHang", it.ThoiGianGiaoHang != null ? it.ThoiGianGiaoHang : ""));
                    cmd.Parameters.Add(new SqlParameter("SLToiThieu", Decimal.Parse(it.SLToiThieu != null ? it.SLToiThieu.Replace(",", "") : "0")));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_Info_Products_Vender_Save_ChinhSach_GiaoHang");
                    return false;
                }
            }
        }


        //
        public async static Task<bool> Delete_Size_color_Line(string NCC, string IDProducst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete_Size_color_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDProducst", IDProducst != null ? IDProducst : ""));
                    cmd.Parameters.Add(new SqlParameter("NCC", NCC != null ? NCC : ""));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_Size_color_Line");
                    return false;
                }
            }
        }
        public async static Task<bool> Delete_QuyCach_DongGoi_Line(string NCC, string IDProducst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete_QuyCach_DongGoi_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDProducst", IDProducst != null ? IDProducst : ""));
                    cmd.Parameters.Add(new SqlParameter("NCC", NCC != null ? NCC : ""));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_Size_color_Line");
                    return false;
                }
            }
        }
        public static bool Save_Size_color_Line(Product_Size info, string NCC, string IDProducst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_Size_color_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDProducst", IDProducst != null ? IDProducst : ""));
                    cmd.Parameters.Add(new SqlParameter("NCC", NCC != null ? NCC : ""));
                    cmd.Parameters.Add(new SqlParameter("Size", info.Size != null ? info.Size.Replace("undefined", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("SizeName", info.SizeName != null ? info.SizeName.Replace("undefined", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("Mau", info.Mau != null ? info.Mau.Replace("undefined", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("MauName", info.MauName != null ? info.MauName.Replace("undefined", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("Barcode", info.Barcode != null ? info.Barcode.Replace("undefined", "") : ""));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_Size_color_Line");
                    return false;
                }
            }
        }
        public async static Task<bool> Save_Size_color_Line_Edit(Product_Size info, string NCC, string IDProducst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_Size_color_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDProducst", IDProducst != null ? IDProducst : ""));
                    cmd.Parameters.Add(new SqlParameter("NCC", NCC != null ? NCC : ""));
                    cmd.Parameters.Add(new SqlParameter("Size", info.Size != null ? info.Size.Replace("undefined", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("SizeName", info.SizeName != null ? info.SizeName.Replace("undefined", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("Mau", info.Mau != null ? info.Mau.Replace("undefined", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("MauName", info.MauName != null ? info.MauName.Replace("undefined", "") : ""));
                    cmd.Parameters.Add(new SqlParameter("Barcode", info.Barcode != null ? info.Barcode.Replace("undefined", "") : ""));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_Size_color_Line");
                    return false;
                }
            }
        }

        public static List<ProductInfoERP> sp_BBS_get_Info_Products_Vender_API(string ID)
        {
            List<ProductInfoERP> it_r = new List<ProductInfoERP>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBS_get_Info_Products_Vender_API", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductInfoERP it = new ProductInfoERP
                        {
                            id = reader["id"].ToString(),
                            functionCode = reader["functionCode"].ToString(),
                            MaNCC = reader["MaNCC"].ToString(),
                            manufactureCode = reader["manufactureCode"].ToString(),
                            GenProPostingGroupCode = reader["GenProPostingGroupCode"].ToString(),
                            name = reader["name"].ToString(),
                            brand = reader["brand"].ToString(),
                            UoM = reader["UoM"].ToString(),
                            priceRetail = reader["priceRetail"].ToString(),
                            SeasonCode = reader["SeasonCode"].ToString(),
                            GiaBanNiemYet = reader["GiaBanNiemYet"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            groupCode = reader["groupCode"].ToString(),
                            categoryCode = reader["categoryCode"].ToString(),
                            divisionCode = reader["divisionCode"].ToString(),
                            New_Items_No_Series = reader["New_Items_No_Series"].ToString(),

                            BarcodeMaskHeard = reader["BarcodeMaskHeard"].ToString(),
                            barcodeHeard = reader["barcodeHeard"].ToString(),
                            barcode = reader["barcode"].ToString(),
                            Purchase_Price = reader["Purchase_Price"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBS_get_Info_Products_Vender_API");
                    return it_r;
                }
            }

        }
        public static bool SetStatus_Info_Products_Vender_ERP(string IDProducst, string Status, string uid, string JsonAPI)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SetStatus_Info_Products_Vender_ERP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDProducst", IDProducst));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("JsonAPI", JsonAPI));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SetStatus_Info_Products_Vender_ERP");
                    return false;
                }
            }
        }

        public static bool Delete_Info_Products_Vender(string IDProducst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete_Info_Products_Vender", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDProducst", IDProducst));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_Info_Products_Vender");
                    return false;
                }
            }
        }

        public static List<ProductInfoNew> Info_Products_Vender_Detail(string productId)
        {
            List<ProductInfoNew> it_r = new List<ProductInfoNew>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Info_Products_Vender_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("productId", productId));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductInfoNew it = new ProductInfoNew
                        {
                            ID = reader["ID"].ToString(),
                            IDProducst = reader["IDProducst"].ToString(),
                            VendorName = reader["VendorName"].ToString(),
                            VendorCode = reader["VendorCode"].ToString(),
                            TenSanPham = reader["TenSanPham"].ToString(),
                            Barcode = reader["Barcode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            DivisionCode = reader["DivisionCode"].ToString(),

                            CategoryName = reader["CategoryName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            DivisionERPName = reader["DivisionERPName"].ToString(),
                            DivisionERPCode = reader["DivisionERPCode"].ToString(),
                            CategoryERPName = reader["CategoryERPName"].ToString(),
                            CategoryERPCode = reader["CategoryERPCode"].ToString(),
                            GroupERPCode = reader["GroupERPCode"].ToString(),
                            GroupERPName = reader["GroupERPName"].ToString(),

                            HHKG = reader["HHKG"].ToString(),
                            MuaVuCode = reader["MuaVuCode"].ToString(),
                            MuaVuName = reader["MuaVuName"].ToString(),
                            ThuongHieuCode = reader["ThuongHieuCode"].ToString(),
                            ThuongHieuName = reader["ThuongHieuName"].ToString(),
                            NguonNhapCode = reader["NguonNhapCode"].ToString(),
                            NguonNhapName = reader["NguonNhapName"].ToString(),
                            XuatXuCode = reader["XuatXuCode"].ToString(),
                            XuatXuName = reader["XuatXuName"].ToString(),
                            DonViTinhCode = reader["DonViTinhCode"].ToString(),
                            DonViTinhName = reader["DonViTinhName"].ToString(),


                            TrongLuong = reader["TrongLuong"].ToString(),
                            KichThuocDai = reader["KichThuocDai"].ToString(),
                            KichThuocRong = reader["KichThuocRong"].ToString(),
                            KichThuocCao = reader["KichThuocCao"].ToString(),

                            QuyCachDGSanPhamCode = reader["QuyCachDGSanPhamCode"].ToString(),
                            QuyCachDGSanPhamName = reader["QuyCachDGSanPhamName"].ToString(),
                            QuyCachDGSanPham = reader["QuyCachDGSanPham"].ToString(),
                            QuyCachDGSanPhamLocCode = reader["QuyCachDGSanPhamLocCode"].ToString(),
                            QuyCachDGSanPhamLocName = reader["QuyCachDGSanPhamLocName"].ToString(),
                            QuyCachDGSanPhamLoc = reader["QuyCachDGSanPhamLoc"].ToString(),
                            QuyCachDGSanPhamThungCode = reader["QuyCachDGSanPhamThungCode"].ToString(),
                            QuyCachDGSanPhamThungName = reader["QuyCachDGSanPhamThungName"].ToString(),
                            QuyCachDGSanPhamThung = reader["QuyCachDGSanPhamThung"].ToString(),

                            KichThuocDaiCm = reader["KichThuocDaiCm"].ToString(),
                            KichThuocRongCm = reader["KichThuocRongCm"].ToString(),
                            KichThuocCaoCm = reader["KichThuocCaoCm"].ToString(),

                            GiaMuaTruVat = reader["GiaMuaTruVat"].ToString(),
                            LineDiscount = reader["LineDiscount"].ToString(),
                            PTVAT = reader["PTVAT"].ToString(),
                            GiaMuaCongVAT = reader["GiaMuaCongVAT"].ToString(),
                            GiaBanNiemYet = reader["GiaBanNiemYet"].ToString(),

                            LinkSanPham = reader["LinkSanPham"].ToString(),
                            MoTaSanPham = reader["MoTaSanPham"].ToString(),
                            AnhSanPham = reader["AnhSanPham"].ToString(),
                            Status = reader["Status"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Info_Products_Vender_Detail");
                    return it_r;
                }
            }

        }

        public static List<Product_Size> Info_Products_Color_Size_Detail(string productId)
        {
            List<Product_Size> it_r = new List<Product_Size>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Info_Products_Color_Size_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("productId", productId));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product_Size it = new Product_Size
                        {
                            Size = reader["Size"].ToString(),
                            SizeName = reader["SizeName"].ToString(),
                            Mau = reader["Mau"].ToString(),
                            MauName = reader["MauName"].ToString(),
                            Barcode = reader["Barcode"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Info_Products_Color_Size_Detail");
                    return it_r;
                }
            }

        }

        public static List<objCombox> sp_bbs_getlist_DOTUOI()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlist_DOTUOI_pro", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlist_DOTUOI_pro");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getlist_MAU()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlist_MAU_pro", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlist_MAU");
                    return it_r;
                }
            }
        }
        public static List<Get_Products_Vender_QuyCach> get_Products_QuyCach_DongGoi_Detail(string productId)
        {
            List<Get_Products_Vender_QuyCach> it_r = new List<Get_Products_Vender_QuyCach>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Info_Products_QuyCach_DongGoi_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("productId", productId));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Get_Products_Vender_QuyCach it = new Get_Products_Vender_QuyCach
                        {
                            productId = reader["productId"].ToString(),
                            VendorCode = reader["VendorCode"].ToString(),
                            DonViTinhCode = reader["DonViTinhCode"].ToString(),
                            DonViTinhName = reader["DonViTinhName"].ToString(),
                            SoLuong = Convert.ToDecimal(reader["SoLuong"].ToString()),
                            TrongLuong = Convert.ToDecimal(reader["TrongLuong"].ToString()),
                            KichThuocDai = Convert.ToDecimal(reader["KichThuocDai"].ToString()),
                            KichThuocRong = Convert.ToDecimal(reader["KichThuocRong"].ToString()),
                            KichThuocCao = Convert.ToDecimal(reader["KichThuocCao"].ToString()),
                            CreateBy = reader["CreateBy"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Info_Products_QuyCach_DongGoi_Detail");
                    return it_r;
                }
            }

        }


    }
}
