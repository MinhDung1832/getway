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
using MP_VendorTool.Models.PushSale;
using MP_VendorTool.Models.OfferPrice;

namespace MP_VendorTool.DataAccess
{
    public class DataAccessDemand02
    {
        private static string strConn = ConfigurationManager.AppSettings.Get("strConn");
        //private static string strConn101 = ConfigurationManager.AppSettings.Get("strConn101");
        private static string strConnSpac = ConfigurationManager.AppSettings.Get("strConnSpac");

        public static DataTable bbs_getlist_dubaonhaphang(string userid, string Mancc)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("bbs_getlist_dubaonhaphang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("Mancc", Mancc));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "bbs_getlist_dubaonhaphang");
                return ds.Tables[0];
            }
        }

        public static bool bbs_create_purchaseprice_ncc(string userid, string Mancc, string Mahang, string Tenhang, decimal Price, decimal VAT, decimal PriceVAT, decimal SLton, string DateSP)
        {
            using (var con = new SqlConnection(strConn))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("bbs_create_purchaseprice_ncc", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("Mancc", Mancc));
                    cmd.Parameters.Add(new SqlParameter("Mahang", Mahang));
                    cmd.Parameters.Add(new SqlParameter("Tenhang", Tenhang));
                    cmd.Parameters.Add(new SqlParameter("Price", Price));
                    cmd.Parameters.Add(new SqlParameter("VAT", VAT));
                    cmd.Parameters.Add(new SqlParameter("PriceVAT", PriceVAT));
                    cmd.Parameters.Add(new SqlParameter("SLton", SLton));
                    cmd.Parameters.Add(new SqlParameter("DateSP", DateSP));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "bbs_create_purchaseprice_ncc");
                    return false;
                }
            }
        }


    }
}