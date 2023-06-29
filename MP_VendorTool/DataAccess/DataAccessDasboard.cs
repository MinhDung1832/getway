using Lib.Utils.Package;
using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Dashboard;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class DataAccessDasboard
{

    private static string strCon = ConfigurationManager.AppSettings.Get("strConn");
    public static async Task<bool> ADD_SUPPLIER_Khaibao(SUPPLIER_FC_Khaibao_Add info, string userid, string vendor)
    {
        using (var con = new SqlConnection(strCon))
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SUPPLIER_2023_DF_Khaibao_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("userid", userid));
                cmd.Parameters.Add(new SqlParameter("vendor", vendor));
                cmd.Parameters.Add(new SqlParameter("item", info.item));
                cmd.Parameters.Add(new SqlParameter("Mien", info.Mien));
                cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                cmd.Parameters.Add(new SqlParameter("Tonhienco", info.Tonhienco));
                cmd.Parameters.Add(new SqlParameter("NgaySanXuat", Convert.ToDateTime(info.NgaySanXuat)));
                if (info.HanSuDung == null)
                {
                    cmd.Parameters.Add(new SqlParameter("HanSuDung", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("HanSuDung", info.HanSuDung));
                }
                cmd.Parameters.Add(new SqlParameter("KhoXuat", info.KhoXuat));
                cmd.Parameters.Add(new SqlParameter("NgayGiao", Convert.ToDateTime(info.NgayGiao)));
                cmd.Parameters.Add(new SqlParameter("GiaBan", Convert.ToDecimal(info.GiaBan)));
                var reader = await cmd.ExecuteNonQueryAsync();
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
    public static bool SUPPLIER_Khaibao_delete(string userid, int ID)
    {
        using (var con = new SqlConnection(strCon))
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SUPPLIER_2023_DF_Khaibao_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("userid", userid));
                cmd.Parameters.Add(new SqlParameter("vendor", userid));
                cmd.Parameters.Add(new SqlParameter("ID", ID));
                var reader = cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_SUPPLIER_2023_DF_Khaibao_delete");
                return false;
            }
        }
    }


    public static async Task<bool> ADD_SUPPLIER_Khaibao_KhuyenMai(SUPPLIER_FC_Khaibao_Add_KhuyenMai info, string userid, string vendor)
    {
        using (var con = new SqlConnection(strCon))
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SUPPLIER_2023_DF_Khaibao_KhuyenMai_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("userid", userid));
                cmd.Parameters.Add(new SqlParameter("vendor", vendor));
                cmd.Parameters.Add(new SqlParameter("item", info.item));
                cmd.Parameters.Add(new SqlParameter("Mien", info.Mien));
                cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                cmd.Parameters.Add(new SqlParameter("Contents", info.Contents));
                var reader = await cmd.ExecuteNonQueryAsync();
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

    public static bool sp_SUPPLIER_2023_DF_Khaibao_KhuyenMai_delete(string userid, int ID)
    {
        using (var con = new SqlConnection(strCon))
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SUPPLIER_2023_DF_Khaibao_KhuyenMai_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("userid", userid));
                cmd.Parameters.Add(new SqlParameter("vendor", userid));
                cmd.Parameters.Add(new SqlParameter("ID", ID));
                var reader = cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_SUPPLIER_2023_DF_Khaibao_KhuyenMai_delete");
                return false;
            }
        }
    }


}
