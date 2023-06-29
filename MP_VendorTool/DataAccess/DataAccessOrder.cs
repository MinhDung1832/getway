using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Order;
using MP_VendorTool.Models.Order2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class DataAccessOrder2
{
    private static string strCon = ConfigurationManager.AppSettings.Get("strConn");

    public static async Task<int> XacNhanDonHang_Headerv2(XacNhanDonHang_Headerv2 it, string userid, string VendorCode)
    {
        DataSet ds = new DataSet();
        try
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Web_SUPPLIER_2023_xacnhan_giaohang", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000;
                cmd.Parameters.Add(new SqlParameter("userid", userid != null ? userid : ""));
                cmd.Parameters.Add(new SqlParameter("Vendor", VendorCode));
                cmd.Parameters.Add(new SqlParameter("prePO_ID", it.prePO_ID));
                cmd.Parameters.Add(new SqlParameter("NgayXN_GiaoHang", Convert.ToDateTime(it.NgayXN_GiaoHang)));
                Int32 rs = (Int32)await cmd.ExecuteScalarAsync();
                con.Close();
                return rs;
            }
        }
        catch (Exception ex)
        {
            LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Web_SUPPLIER_2023_xacnhan_giaohang");
            return -1;
        }
    }

    public static async Task<bool> Xacnhan_giaohang_detail_Linev2(XacNhanDonHang_Linev2 info, string userid, string VendorCode)
    {
        using (var con = new SqlConnection(strCon))
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("Web_SUPPLIER_2023_xacnhan_giaohang_detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("userid", userid != null ? userid : ""));
                cmd.Parameters.Add(new SqlParameter("Vendor", VendorCode));
                cmd.Parameters.Add(new SqlParameter("header_ID", info.header_ID));
                cmd.Parameters.Add(new SqlParameter("prePO_ID", info.prePO_ID));
                cmd.Parameters.Add(new SqlParameter("Quantity", info.Quantity));
                if (info.HanSD == null)
                {
                    cmd.Parameters.Add(new SqlParameter("HanSD", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("HanSD", info.HanSD));
                }
                if (info.NgaySanXuat == null)
                {
                    cmd.Parameters.Add(new SqlParameter("NgayXS", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("NgayXS", info.NgaySanXuat));
                }

                var reader = await cmd.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Web_SUPPLIER_2023_xacnhan_giaohang_detail");
                return false;
            }
        }
    }

    public static async Task<bool> updatelichgiaohang_ncc(updatelichgiaohang_ncc it, string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Web_SUPPLIER_2023_updatelichgiaohang_ncc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000;
                cmd.Parameters.Add(new SqlParameter("userid", userid != null ? userid : ""));
                cmd.Parameters.Add(new SqlParameter("ID", it.ID));
                cmd.Parameters.Add(new SqlParameter("isAccept", it.isAccept));
                cmd.Parameters.Add(new SqlParameter("lydo", it.lydo != null ? it.lydo : ""));
                cmd.Parameters.Add(new SqlParameter("sdt", it.sdt != null ? it.sdt : ""));
                cmd.Parameters.Add(new SqlParameter("DeXuatGioGiao", it.DeXuatGioGiao != null ? it.DeXuatGioGiao : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("DeXuatNgayGiao", it.DeXuatNgayGiao != null ? it.DeXuatNgayGiao : DBNull.Value));
                var reader = await cmd.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
        }
        catch (Exception ex)
        {
            LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Web_SUPPLIER_2023_updatelichgiaohang_ncc");
            return false;
        }
    }

    public static async Task<bool> updatexegiao_ncc(updatexegiao_ncc it, string userid, string vendor)
    {
        DataSet ds = new DataSet();
        try
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Web_SUPPLIER_2023_updatexegiao_ncc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000;
                cmd.Parameters.Add(new SqlParameter("userid", userid != null ? userid : ""));
                cmd.Parameters.Add(new SqlParameter("vendor", vendor));
                cmd.Parameters.Add(new SqlParameter("ID", it.ID));
                cmd.Parameters.Add(new SqlParameter("xe", it.xe != null ? it.xe : ""));
                cmd.Parameters.Add(new SqlParameter("taixe", it.taixe != null ? it.taixe : ""));
                cmd.Parameters.Add(new SqlParameter("sdt", it.sdt != null ? it.sdt : ""));
                cmd.Parameters.Add(new SqlParameter("DonViGiaoHang", it.DonViGiaoHang));
                cmd.Parameters.Add(new SqlParameter("CCCD", it.CCCD));
                var reader = await cmd.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
        }
        catch (Exception ex)
        {
            LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Web_SUPPLIER_2023_updatexegiao_ncc");
            return false;
        }
    }
}