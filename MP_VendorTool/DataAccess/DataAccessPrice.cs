using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using ProductAllTool.Models.DeXuatGiaBan;
using MP_VendorTool.Models.Order;
using MP_VendorTool.DataAccess;

namespace ProductAllTool.DataAccess
{
    public class DataAccessPrice
    {
        private static string APIDomain = ConfigurationManager.AppSettings.Get("APIDomain");
        private static string strConn = ConfigurationManager.AppSettings.Get("strConnTrading");
        private static string strCon_SPACEMAN = ConfigurationManager.AppSettings.Get("strConn");

        public static objCombox SalesPrice_ThayDoiGiaAll(string MaHang)
        {
            objCombox itr = new objCombox();
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SalesPrice_DeXuatGiaBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Name = reader["Price"].ToString(),
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SalesPrice_ThayDoiGiaAll");
                    return itr;
                }
            }
        }

        public static objCombox GiaMua_DeXuatGiaBan(string MaHang, string Vendor)
        {
            objCombox itr = new objCombox();
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GiaMua_DeXuatGiaBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("Vendor", Vendor));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Code"].ToString(),
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GiaMua_DeXuatGiaBan");
                    return itr;
                }
            }
        }
        public static objCombox PTGPFunction_DeXuatGiaBan(string MaHang)
        {
            objCombox itr = new objCombox();
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("PTGPFunction_DeXuatGiaBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PTGPFunction_DeXuatGiaBan");
                    return itr;
                }
            }
        }

        public static List<objCombox> SP_DeXuqatGiaBan_Pro_ITEM_Vendor(string VendorCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_DeXuqatGiaBan_Pro_ITEM_Vendor", con);

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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_DeXuqatGiaBan_Pro_ITEM_Vendor");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_TRADTERM_GET_BARCODE(string ItemNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_DeXuatGiaBan_GET_BARCODE", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_TRADTERM_GET_BARCODE");
                    return it_r;
                }
            }
        }
        public static bool SP_SAVE_DeXuatGiaBan(Obj_DeXuatGiaBan info, string CreateBy)
        {
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_SAVE_DeXuatGiaBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaNCC", info.MaNCC));
                    cmd.Parameters.Add(new SqlParameter("TenNCC", info.TenNCC));
                    cmd.Parameters.Add(new SqlParameter("MaHang", info.MaHang));
                    cmd.Parameters.Add(new SqlParameter("TenHang", info.TenHang));
                    cmd.Parameters.Add(new SqlParameter("Barcode", info.Barcode != null ? info.Barcode : ""));
                    cmd.Parameters.Add(new SqlParameter("Link", info.Link != null ? info.Link : ""));
                    if (info.GiaBanCu != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaBanCu", Decimal.Parse(info.GiaBanCu != "" ? info.GiaBanCu.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaBanCu", "0"));
                    }
                    if (info.GiaMoi != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMoi", Decimal.Parse(info.GiaMoi != "" ? info.GiaMoi.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMoi", "0"));
                    }
                    if (info.GiaMua != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMua", Decimal.Parse(info.GiaMua != "" ? info.GiaMua.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMua", "0"));
                    }

                    cmd.Parameters.Add(new SqlParameter("GpCu", info.GpCu != null ? info.GpCu : "0"));
                    cmd.Parameters.Add(new SqlParameter("GpMoi", info.GpMoi != null ? info.GpMoi : "0"));
                    cmd.Parameters.Add(new SqlParameter("GpFunction", info.GpFunction != null ? info.GpFunction : "0"));

                    if (String.IsNullOrWhiteSpace(info.NgayThongBaoChinhThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DateTime.Parse(info.NgayThongBaoChinhThuc)));
                    }
                    if (String.IsNullOrWhiteSpace(info.NgayHieuLuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", DateTime.Parse(info.NgayHieuLuc)));
                    }
                    if (String.IsNullOrWhiteSpace(info.NgayKetThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DateTime.Parse(info.NgayKetThuc)));
                    }
                    cmd.Parameters.Add(new SqlParameter("Status", info.Status));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_SAVE_OfferPrice");
                    return false;
                }
            }
        }

        public static DataTable Get_List_DeXuatGiaBan(string NhaCC, string MaHang, string Status, string VendorNo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon_SPACEMAN))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Get_List_DeXuatGiaBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("NhaCC", NhaCC));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_List_OfferPrice");
                return ds.Tables[0];
            }
        }

        public static bool Delete_DeXuatGiaBan(string ID)
        {
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Delete_DeXuatGiaBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_DeXuatGiaBan");
                    return false;
                }
            }
        }
        public static bool Update_Status_DeXuatGiaBan(string ID, string HanhDong)
        {
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_DeXuatGiaBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_DeXuatGiaBan");
                    return false;
                }
            }
        }

        public static bool Update_Status_DeXuatGiaBan_Duyet_ERP(string ID, string uid)
        {
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_DeXuatGiaBan_Duyet_ERP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_DeXuatGiaBan_Duyet_ERP");
                    return false;
                }
            }
        }

        public static Obj_DeXuatGiaBan Listget_DeXuatGiaBan_PopUp_BIBO(string ID)
        {
            Obj_DeXuatGiaBan itr = new Obj_DeXuatGiaBan();
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Listget_DeXuatGiaBan_PopUp_BIBO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Obj_DeXuatGiaBan it = new Obj_DeXuatGiaBan
                        {
                            ID = reader["ID"].ToString(),
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            Barcode = reader["Barcode"].ToString(),
                            Link = reader["Link"].ToString(),
                            GiaBanCu = reader["GiaBanCu"].ToString(),
                            GiaMoi = reader["GiaMoi"].ToString(),
                            GiaMua = reader["GiaMua"].ToString(),
                            GpCu = reader["GpCu"].ToString(),
                            GpMoi = reader["GpMoi"].ToString(),
                            GpFunction = reader["GpFunction"].ToString(),

                            FMGpCu = reader["FMGpCu"].ToString(),
                            FMGpMoi = reader["FMGpMoi"].ToString(),
                            FMGpFunction = reader["FMGpFunction"].ToString(),


                            NgayThongBaoChinhThuc = reader["NgayThongBaoChinhThuc"].ToString(),
                            NgayHieuLuc = reader["NgayHieuLuc"].ToString(),
                            NgayKetThuc = reader["NgayKetThuc"].ToString(),
                            GhiChu = reader["GhiChu"].ToString(),
                            Status = reader["Status"].ToString(),
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_DeXuatGiaBan_PopUp_BIBO");
                    return itr;
                }
            }
        }
        public static bool SP_Update_DeXuatGiaBan(Obj_DeXuatGiaBan info)
        {
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Update_DeXuatGiaBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("Link", info.Link != null ? info.Link : ""));
                    if (info.GiaBanCu != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaBanCu", Decimal.Parse(info.GiaBanCu != "" ? info.GiaBanCu.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaBanCu", "0"));
                    }
                    if (info.GiaMoi != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMoi", Decimal.Parse(info.GiaMoi != "" ? info.GiaMoi.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMoi", "0"));
                    }
                    if (info.GiaMua != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMua", Decimal.Parse(info.GiaMua != "" ? info.GiaMua.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMua", "0"));
                    }

                    cmd.Parameters.Add(new SqlParameter("GpCu", info.GpCu != null ? info.GpCu : "0"));
                    cmd.Parameters.Add(new SqlParameter("GpMoi", info.GpMoi != null ? info.GpMoi : "0"));
                    cmd.Parameters.Add(new SqlParameter("GpFunction", info.GpFunction != null ? info.GpFunction : "0"));

                    if (String.IsNullOrWhiteSpace(info.NgayThongBaoChinhThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DateTime.Parse(info.NgayThongBaoChinhThuc)));
                    }
                    if (String.IsNullOrWhiteSpace(info.NgayHieuLuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", DateTime.Parse(info.NgayHieuLuc)));
                    }
                    if (String.IsNullOrWhiteSpace(info.NgayKetThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DateTime.Parse(info.NgayKetThuc)));
                    }
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Update_DeXuatGiaBan");
                    return false;
                }
            }
        }
        public static bool SP_Update_DeXuatGiaBan_ERP(Obj_DeXuatGiaBan info, string NgayBatDau, string uid)
        {
            using (var con = new SqlConnection(strCon_SPACEMAN))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_DeXuatGiaBan_Duyet_ERP2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("Link", info.Link != null ? info.Link : ""));
                    if (info.GiaBanCu != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaBanCu", Decimal.Parse(info.GiaBanCu != "" ? info.GiaBanCu.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaBanCu", "0"));
                    }
                    if (info.GiaMoi != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMoi", Decimal.Parse(info.GiaMoi != "" ? info.GiaMoi.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMoi", "0"));
                    }
                    if (info.GiaMua != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMua", Decimal.Parse(info.GiaMua != "" ? info.GiaMua.Replace(",", "") : "0")));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("GiaMua", "0"));
                    }

                    cmd.Parameters.Add(new SqlParameter("GpCu", info.GpCu != null ? info.GpCu : "0"));
                    cmd.Parameters.Add(new SqlParameter("GpMoi", info.GpMoi != null ? info.GpMoi : "0"));
                    cmd.Parameters.Add(new SqlParameter("GpFunction", info.GpFunction != null ? info.GpFunction : "0"));

                    if (String.IsNullOrWhiteSpace(info.NgayThongBaoChinhThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayThongBaoChinhThuc", DateTime.Parse(info.NgayThongBaoChinhThuc)));
                    }
                    if (String.IsNullOrWhiteSpace(NgayBatDau))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", DateTime.Parse(NgayBatDau)));
                    }
                    if (String.IsNullOrWhiteSpace(info.NgayKetThuc))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThuc", DateTime.Parse(info.NgayKetThuc)));
                    }
                    cmd.Parameters.Add(new SqlParameter("uid", uid != null ? uid : ""));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Update_DeXuatGiaBan");
                    return false;
                }
            }
        }

    }
}