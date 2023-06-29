using MP_VendorTool.Models.Order;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using MP_VendorTool.Common;
using System.Web;
using System.Threading.Tasks;
using MP_VendorTool.Models.ChiDinhHotdeal;
using MP_VendorTool.Models.OfferPrice;
using MP_VendorTool.Models.Report;

namespace MP_VendorTool.DataAccess
{
    public class DataAccessChiDinhHotdeal
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConnSpac = ConfigurationManager.AppSettings.Get("strConnSpac");
        public static DataTable SP_CTKM_ChiDinhHotdeal_HHOA_KGUI(string vendorNo, string MaHang, string Barcode)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnSpac))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CTKM_ChiDinhHotdeal_HHOA_KGUI", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_CTKM_ChiDinhHotdeal_HHOA_KGUI");
                return ds.Tables[0];
            }
        }
        public static DataTable ChiDinhHotdealApr(string vendorNo, string MaHang, string TrangThai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnSpac))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ChiDinhHotdeal_Apr_HHOA_KGUI", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("vendorNo", vendorNo));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ChiDinhHotdeal_Apr_HHOA_KGUI");
                return ds.Tables[0];
            }
        }
        public static List<objCombox> SP_ChiDinhHotdeal_Vender(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Chidinhhotdeal_Vender", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ChiDinhHotdeal_Vender");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_ChiDinhHotdeal_Vender_BARCODE(string ItemNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ChiDinhHotdeal_Vender_BARCODE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("itemNo", ItemNo));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Value"].ToString(),
                            Name = reader["Text"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ChiDinhHotdeal_Vender_BARCODE");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_ChiDinhHotdeal_Vender_ITEM_Vendor(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ChiDinhHotdeal_Vender_ITEM_Vendor", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorCode", VendorCode));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["MaHang"].ToString(),
                            Name = reader["TenHang"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_ChiDinhHotdeal_Vender_ITEM_Vendor");
                    return it_r;
                }
            }
        }
        public async static Task<bool>  Add_ChiDinhHotdeal_Vender_Item(string userid, ChiDinhHotdeal_Vender_Item po)
        {
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Add_ChiDinhHotdeal_Vender_Item", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", po.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", po.TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaHang", po.MaHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("TenHang", po.TenHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("Images", po.Images.Trim()));
                    cmd.Parameters.Add(new SqlParameter("Price", po.Price.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("HHOA_KGUI", po.HHOA_KGUI.Trim()));

                    cmd.Parameters.Add(new SqlParameter("GiaKM", po.GiaKM.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("PTGiamGia", po.PTGiamGia.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("NgayBatDau", po.NgayBatDau.Trim()));
                    cmd.Parameters.Add(new SqlParameter("NgayKetThuc", po.NgayKetThuc.Trim()));
                    cmd.Parameters.Add(new SqlParameter("SLApDung", po.SLApDung.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", userid));

                    var reader = await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Add_ChiDinhHotdeal_Vender_Item");
                    return false;
                }
            }
        }
        public static bool Update_ChiDinhHotdeal_Vender_Item(string userid, ChiDinhHotdeal_Vender_Item po)
        {
            using (var con = new SqlConnection(strConnSpac))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_ChiDinhHotdeal_Vender_Item", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    
                    cmd.Parameters.Add(new SqlParameter("ID", po.ID.Trim()));
                    cmd.Parameters.Add(new SqlParameter("MaHang", po.MaHang.Trim()));
                    cmd.Parameters.Add(new SqlParameter("GiaKM", po.GiaKM.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("PTGiamGia", po.PTGiamGia.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("NgayBatDau", po.NgayBatDau.Trim()));
                    cmd.Parameters.Add(new SqlParameter("NgayKetThuc", po.NgayKetThuc.Trim()));
                    cmd.Parameters.Add(new SqlParameter("SLApDung", po.SLApDung.Trim().Replace(",", "")));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", userid));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_ChiDinhHotdeal_Vender_Item");
                    return false;
                }
            }
        }
    }
}