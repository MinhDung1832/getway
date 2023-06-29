//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.Common;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Mail;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Web;
//using System.Globalization;
//using System.Reflection;
//using MP_VendorTool.Models.Order;
//using MP_VendorTool.DataAccess;
//using System.Text;
//using Lib.Utils.Package;

//public class BaseConnectionSql
//{
//    public static TValue Execute_Get_V1<TValue>(string strCon, string Stored, params object[] parameterValues)
//    {
//        var con = new SqlConnection(ConfigurationManager.AppSettings.Get(strCon));
//        var kq = new List<TValue>();
//        StringBuilder str = new StringBuilder();
//        try
//        {
//            try
//            {
//                using (con)
//                {
//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(Stored, con);
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    //Parameters

//                    if ((parameterValues != null) && (parameterValues.Length > 0))
//                    {
//                        var commandParameters = SqlHelperParameterCache.GetSpParameterSet(ConfigurationManager.AppSettings.Get(strCon), Stored);

//                        //Số lượng tham số không khớp với số lượng Giá trị tham số
//                        if (commandParameters.Length != parameterValues.Length)
//                        {
//                            throw new ArgumentException("Số lượng tham số không khớp với số lượng Giá trị tham số.");
//                        }
//                        // Lặp lại thông qua SqlParameters, gán các giá trị từ vị trí tương ứng trong
//                        for (int i = 0, j = commandParameters.Length; i < j; i++)
//                        {
//                            // Nếu giá trị mảng hiện tại xuất phát từ IDbDataParameter, thì hãy gán thuộc tính Giá trị của nó
//                            if (parameterValues[i] is IDbDataParameter value)
//                            {
//                                var paramInstance = value;
//                                var p = new SqlParameter
//                                {
//                                    ParameterName = commandParameters[i].ToString(),
//                                    Value = paramInstance.Value ?? DBNull.Value
//                                };
//                                cmd.Parameters.Add(p);
//                                str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + paramInstance.Value ?? DBNull.Value + "));");

//                            }
//                            else if (parameterValues[i] == null)
//                            {
//                                var p = new SqlParameter
//                                {
//                                    ParameterName = commandParameters[i].ToString(),
//                                    Value = DBNull.Value
//                                };
//                                cmd.Parameters.Add(p);
//                                str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + DBNull.Value + "));");
//                            }
//                            else
//                            {
//                                var p = new SqlParameter
//                                {
//                                    ParameterName = commandParameters[i].ToString(),
//                                    Value = parameterValues[i]
//                                };
//                                cmd.Parameters.Add(p);
//                                str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + parameterValues[i] + "));");
//                            }
//                        }
//                    }
//                    //while
//                    var reader = cmd.ExecuteReader();
//                    if (!reader.HasRows)
//                    {
//                        con.Close();
//                        return default(TValue);
//                        // Không có dữ liệu trả về.
//                    }
//                    else
//                    {
//                        try
//                        {
//                            while (reader.Read())
//                            {
//                                Type type = typeof(TValue);
//                                TValue obj = (TValue)Activator.CreateInstance(type);
//                                PropertyInfo[] properties = type.GetProperties();
//                                foreach (PropertyInfo property in properties)
//                                {
//                                    try
//                                    {
//                                        var value = reader[property.Name];
//                                        if (value != null)
//                                            property.SetValue(obj, Convert.ChangeType(value.ToString(), property.PropertyType));
//                                    }
//                                    catch (Exception ex1)
//                                    {
//                                        // throw ex1;
//                                    }
//                                }
//                                kq.Add(obj);
//                            }
//                        }
//                        catch (Exception ex1)
//                        {
//                            // throw ex1;
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            con.Close();
//            return kq.First();
//        }
//        catch (Exception ex)
//        {
//            if (con.State == ConnectionState.Open)
//            {
//                con.Close();
//            }
//            LogBuild.CreateLogger(str.ToString(), Stored + "_Param");
//            LogBuild.CreateLogger("Error: " + ex.ToString(), Stored);
//            return kq.First();
//        }
//    }
//    public static DataTable ExecuteDataTable<Tkey>(string strCon, string Stored, Tkey item)
//    {
//        DataSet ds = new DataSet();
//        StringBuilder str = new StringBuilder();
//        try
//        {
//            var strCons = ConfigurationManager.AppSettings.Get(strCon);
//            using (var con = new SqlConnection(strCons))
//            {
//                con.Open();
//                SqlCommand cmd = new SqlCommand(Stored, con);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.CommandTimeout = 30000;
//                PropertyInfo[] props = typeof(Tkey).GetProperties();
//                object value1;
//                foreach (PropertyInfo prop in props)
//                {
//                    value1 = prop.GetValue(item, null);
//                    if (value1 != null)
//                    {
//                        var p = new System.Data.SqlClient.SqlParameter
//                        {
//                            ParameterName = prop.Name,
//                            Value = value1
//                        };
//                        if (prop.PropertyType == typeof(DateTime) && (DateTime)value1 == DateTime.MinValue)
//                        {
//                            //ignore
//                        }
//                        else
//                        {
//                            cmd.Parameters.Add(p);
//                            str.Append("cmd.Parameters.Add(new SqlParameter(" + prop.Name + ", " + value1 + "));");
//                        }
//                    }
//                }

//                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
//                {
//                    sda.Fill(ds);
//                }
//                con.Close();
//                return ds.Tables[0];
//            }
//        }
//        catch (Exception ex)
//        {
//            LogBuild.CreateLogger(str.ToString(), Stored + "_Param");
//            LogBuild.CreateLogger("Error: " + ex.ToString(), Stored);
//            return ds.Tables[0];
//        }
//    }
//    public static List<T> Bind_List_Reader<T>(SqlCommand command) where T : class
//    {
//        List<T> list = new List<T>();
//        var reader = command.ExecuteReader();
//        try
//        {
//            while (reader.Read())
//            {
//                Type type = typeof(T);
//                T obj = (T)Activator.CreateInstance(type);
//                PropertyInfo[] properties = type.GetProperties();

//                foreach (PropertyInfo property in properties)
//                {
//                    try
//                    {
//                        var value = reader[property.Name];
//                        if (value != null)
//                            property.SetValue(obj, Convert.ChangeType(value.ToString(), property.PropertyType));
//                    }
//                    catch { }
//                }
//                list.Add(obj);
//            }
//        }
//        catch (Exception exception)
//        {
//            throw exception;
//        }
//        finally
//        {
//            command.Connection.Close();
//        }
//        return list;
//    }
//    public static List<TValue> ExecuteList<Tkey, TValue>(string strCon, string Stored, Tkey item)
//    {
//        var con = new SqlConnection(ConfigurationManager.AppSettings.Get(strCon));
//        var kq = new List<TValue>();
//        StringBuilder str = new StringBuilder();
//        try
//        {
//            try
//            {
//                using (con)
//                {
//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(Stored, con);
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    //Parameters

//                    PropertyInfo[] props = typeof(Tkey).GetProperties();
//                    object value1;
//                    foreach (PropertyInfo prop in props)
//                    {
//                        value1 = prop.GetValue(item, null);
//                        if (value1 != null)
//                        {
//                            var p = new System.Data.SqlClient.SqlParameter
//                            {
//                                ParameterName = prop.Name,
//                                Value = value1
//                            };
//                            if (prop.PropertyType == typeof(DateTime) && (DateTime)value1 == DateTime.MinValue)
//                            {
//                                //ignore
//                            }
//                            else
//                            {
//                                cmd.Parameters.Add(p);
//                                str.Append("cmd.Parameters.Add(new SqlParameter(" + prop.Name + ", " + value1 + "));");
//                            }
//                        }
//                    }

//                    //while
//                    var reader = cmd.ExecuteReader();
//                    try
//                    {
//                        while (reader.Read())
//                        {
//                            Type type = typeof(TValue);
//                            TValue obj = (TValue)Activator.CreateInstance(type);
//                            PropertyInfo[] properties = type.GetProperties();

//                            foreach (PropertyInfo property in properties)
//                            {
//                                try
//                                {
//                                    var value = reader[property.Name];
//                                    if (value != null)
//                                        property.SetValue(obj, Convert.ChangeType(value.ToString(), property.PropertyType));
//                                }
//                                catch { }
//                            }
//                            kq.Add(obj);
//                        }
//                    }
//                    catch { }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            con.Close();
//            return kq;
//        }
//        catch (Exception ex)
//        {
//            if (con.State == ConnectionState.Open)
//            {
//                con.Close();
//            }
//            LogBuild.CreateLogger(str.ToString(), Stored + "_Param");
//            LogBuild.CreateLogger("Error: " + ex.ToString(), Stored);
//            return kq;
//        }
//    }
//    public static bool Execute_Update_Insert<TValue>(string strCon, string Stored, TValue item)
//    {
//        StringBuilder str = new StringBuilder();
//        var con = new SqlConnection(ConfigurationManager.AppSettings.Get(strCon));
//        var kq = new List<TValue>();
//        try
//        {
//            using (con)
//            {
//                con.Open();
//                SqlCommand cmd = new SqlCommand(Stored, con);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.CommandTimeout = 30000;
//                PropertyInfo[] props = typeof(TValue).GetProperties();
//                object value1;
//                foreach (PropertyInfo prop in props)
//                {
//                    value1 = prop.GetValue(item, null);
//                    if (value1 != null)
//                    {
//                        var p = new System.Data.SqlClient.SqlParameter
//                        {
//                            ParameterName = prop.Name,
//                            Value = value1
//                        };
//                        if (prop.PropertyType == typeof(DateTime) && (DateTime)value1 == DateTime.MinValue)
//                        {
//                            //ignore
//                        }
//                        else
//                        {
//                            cmd.Parameters.Add(p);
//                            str.Append("cmd.Parameters.Add(new SqlParameter(" + prop.Name + ", " + value1 + "));");
//                        }
//                    }
//                }
//                var reader = cmd.ExecuteNonQuery();
//                con.Close();
//                return true;
//            }
//        }
//        catch (Exception ex)
//        {
//            con.Close();
//            LogBuild.CreateLogger(str.ToString(), Stored + "_Param");
//            LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), Stored);
//            return false;
//        }
//    }
//    public static List<TValue> ExecuteList_V1<TValue>(string strCon, string Stored, params object[] parameterValues)
//    {
//        var con = new SqlConnection(ConfigurationManager.AppSettings.Get(strCon));
//        var kq = new List<TValue>();
//        StringBuilder str = new StringBuilder();
//        try
//        {
//            try
//            {
//                using (con)
//                {
//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(Stored, con);
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    //Parameters

//                    if ((parameterValues != null) && (parameterValues.Length > 0))
//                    {
//                        var commandParameters = SqlHelperParameterCache.GetSpParameterSet(ConfigurationManager.AppSettings.Get(strCon), Stored);

//                        //Số lượng tham số không khớp với số lượng Giá trị tham số
//                        if (commandParameters.Length != parameterValues.Length)
//                        {
//                            throw new ArgumentException("Số lượng tham số không khớp với số lượng Giá trị tham số.");
//                        }
//                        // Lặp lại thông qua SqlParameters, gán các giá trị từ vị trí tương ứng trong
//                        for (int i = 0, j = commandParameters.Length; i < j; i++)
//                        {
//                            // Nếu giá trị mảng hiện tại xuất phát từ IDbDataParameter, thì hãy gán thuộc tính Giá trị của nó
//                            if (parameterValues[i] is IDbDataParameter value)
//                            {
//                                var paramInstance = value;
//                                var p = new SqlParameter
//                                {
//                                    ParameterName = commandParameters[i].ToString(),
//                                    Value = paramInstance.Value ?? DBNull.Value
//                                };
//                                cmd.Parameters.Add(p);
//                                str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + paramInstance.Value ?? DBNull.Value + "));");

//                            }
//                            else if (parameterValues[i] == null)
//                            {
//                                var p = new SqlParameter
//                                {
//                                    ParameterName = commandParameters[i].ToString(),
//                                    Value = DBNull.Value
//                                };
//                                cmd.Parameters.Add(p);
//                                str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + DBNull.Value + "));");
//                            }
//                            else
//                            {
//                                var p = new SqlParameter
//                                {
//                                    ParameterName = commandParameters[i].ToString(),
//                                    Value = parameterValues[i]
//                                };
//                                cmd.Parameters.Add(p);
//                                str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + parameterValues[i] + "));");
//                            }
//                        }
//                    }
//                    //while
//                    var reader = cmd.ExecuteReader();
//                    try
//                    {
//                        while (reader.Read())
//                        {
//                            Type type = typeof(TValue);
//                            TValue obj = (TValue)Activator.CreateInstance(type);
//                            PropertyInfo[] properties = type.GetProperties();

//                            foreach (PropertyInfo property in properties)
//                            {
//                                try
//                                {
//                                    var value = reader[property.Name];
//                                    if (value != null)
//                                        property.SetValue(obj, Convert.ChangeType(value.ToString(), property.PropertyType));
//                                }
//                                catch { }
//                            }
//                            kq.Add(obj);
//                        }
//                    }
//                    catch (Exception ex1)
//                    {
//                        throw ex1;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            con.Close();
//            return kq;
//        }
//        catch (Exception ex)
//        {
//            if (con.State == ConnectionState.Open)
//            {
//                con.Close();
//            }
//            LogBuild.CreateLogger(str.ToString(), Stored + "_Param");
//            LogBuild.CreateLogger("Error: " + ex.ToString(), Stored);
//            return kq;
//        }
//    }
//    public static bool Execute_Update_Insert_V1(string strCon, string Stored, params object[] parameterValues)
//    {
//        StringBuilder str = new StringBuilder();
//        var con = new SqlConnection(ConfigurationManager.AppSettings.Get(strCon));

//        try
//        {
//            using (con)
//            {
//                con.Open();
//                SqlCommand cmd = new SqlCommand(Stored, con);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.CommandTimeout = 30000;

//                if ((parameterValues != null) && (parameterValues.Length > 0))
//                {
//                    var commandParameters = SqlHelperParameterCache.GetSpParameterSet(ConfigurationManager.AppSettings.Get(strCon), Stored);

//                    //Số lượng tham số không khớp với số lượng Giá trị tham số
//                    if (commandParameters.Length != parameterValues.Length)
//                    {
//                        throw new ArgumentException("Số lượng tham số không khớp với số lượng Giá trị tham số.");
//                    }
//                    // Lặp lại thông qua SqlParameters, gán các giá trị từ vị trí tương ứng trong
//                    for (int i = 0, j = commandParameters.Length; i < j; i++)
//                    {
//                        // Nếu giá trị mảng hiện tại xuất phát từ IDbDataParameter, thì hãy gán thuộc tính Giá trị của nó
//                        if (parameterValues[i] is IDbDataParameter value)
//                        {
//                            var paramInstance = value;
//                            var p = new SqlParameter
//                            {
//                                ParameterName = commandParameters[i].ToString(),
//                                Value = paramInstance.Value ?? DBNull.Value
//                            };
//                            cmd.Parameters.Add(p);
//                            str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + paramInstance.Value ?? DBNull.Value + "));");

//                        }
//                        else if (parameterValues[i] == null)
//                        {
//                            var p = new SqlParameter
//                            {
//                                ParameterName = commandParameters[i].ToString(),
//                                Value = DBNull.Value
//                            };
//                            cmd.Parameters.Add(p);
//                            str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + DBNull.Value + "));");
//                        }
//                        else
//                        {
//                            var p = new SqlParameter
//                            {
//                                ParameterName = commandParameters[i].ToString(),
//                                Value = parameterValues[i]
//                            };
//                            cmd.Parameters.Add(p);
//                            str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + parameterValues[i] + "));");
//                        }
//                    }
//                }

//                var reader = cmd.ExecuteNonQuery();
//                con.Close();
//                return true;
//            }
//        }
//        catch (Exception ex)
//        {
//            con.Close();
//            LogBuild.CreateLogger(str.ToString(), Stored + "_Param");
//            LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), Stored);
//            return false;
//        }
//    }
//    public static DataTable ExecuteDataTable_V1(string strCon, string Stored, params object[] parameterValues)
//    {
//        DataSet ds = new DataSet();
//        StringBuilder str = new StringBuilder();
//        try
//        {
//            var strCons = ConfigurationManager.AppSettings.Get(strCon);
//            using (var con = new SqlConnection(strCons))
//            {
//                con.Open();
//                SqlCommand cmd = new SqlCommand(Stored, con);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.CommandTimeout = 30000;

//                if ((parameterValues != null) && (parameterValues.Length > 0))
//                {
//                    var commandParameters = SqlHelperParameterCache.GetSpParameterSet(ConfigurationManager.AppSettings.Get(strCon), Stored);

//                    //Số lượng tham số không khớp với số lượng Giá trị tham số
//                    if (commandParameters.Length != parameterValues.Length)
//                    {
//                        throw new ArgumentException("Số lượng tham số không khớp với số lượng Giá trị tham số.");
//                    }
//                    // Lặp lại thông qua SqlParameters, gán các giá trị từ vị trí tương ứng trong
//                    for (int i = 0, j = commandParameters.Length; i < j; i++)
//                    {
//                        // Nếu giá trị mảng hiện tại xuất phát từ IDbDataParameter, thì hãy gán thuộc tính Giá trị của nó
//                        if (parameterValues[i] is IDbDataParameter value)
//                        {
//                            var paramInstance = value;
//                            var p = new SqlParameter
//                            {
//                                ParameterName = commandParameters[i].ToString(),
//                                Value = paramInstance.Value ?? DBNull.Value
//                            };
//                            cmd.Parameters.Add(p);
//                            str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + paramInstance.Value ?? DBNull.Value + "));");

//                        }
//                        else if (parameterValues[i] == null)
//                        {
//                            var p = new SqlParameter
//                            {
//                                ParameterName = commandParameters[i].ToString(),
//                                Value = DBNull.Value
//                            };
//                            cmd.Parameters.Add(p);
//                            str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + DBNull.Value + "));");
//                        }
//                        else
//                        {
//                            var p = new SqlParameter
//                            {
//                                ParameterName = commandParameters[i].ToString(),
//                                Value = parameterValues[i]
//                            };
//                            cmd.Parameters.Add(p);
//                            str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + parameterValues[i] + "));");
//                        }
//                    }
//                }

//                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
//                {
//                    sda.Fill(ds);
//                }
//                con.Close();
//                return ds.Tables[0];
//            }
//        }
//        catch (Exception ex)
//        {
//            LogBuild.CreateLogger(str.ToString(), Stored + "_Param");
//            LogBuild.CreateLogger("Error: " + ex.ToString(), Stored);
//            return ds.Tables[0];
//        }
//    }
//    public static List<TValue> ExecuteList_V2<TValue>(string strCon, string Stored, params object[] parameterValues) where TValue : new()
//    {
//        var con = new SqlConnection(ConfigurationManager.AppSettings.Get(strCon));
//        var kq = new List<TValue>();
//        StringBuilder str = new StringBuilder();
//        try
//        {
//            try
//            {
//                using (con)
//                {
//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(Stored, con);
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    //Parameters

//                    if (parameterValues == null || parameterValues.Length == 0)
//                    {
//                        throw new ArgumentException("Không có giá trị tham số nào, không cần xử lý gì.");
//                    }

//                    var commandParameters = SqlHelperParameterCache.GetSpParameterSet(ConfigurationManager.AppSettings.Get(strCon), Stored);

//                    // Thiếu thông tin về các tham số, ném ra một ArgumentException.
//                    if (commandParameters.Length != parameterValues.Length)
//                    {
//                        throw new ArgumentException("Số lượng tham số không khớp với số lượng Giá trị tham số.");
//                    }

//                    // Lặp lại thông qua SqlParameters, gán các giá trị từ vị trí tương ứng trong
//                    for (int i = 0, j = commandParameters.Length; i < j; i++)
//                    {
//                        var currentValue = parameterValues[i]; // Giá trị hiện tại của tham số.

//                        if (currentValue is IDbDataParameter dbParam) // Kiểm tra tham số có phải là IDbDataParameter.
//                        {
//                            var sqlParam = new SqlParameter
//                            {
//                                ParameterName = commandParameters[i].ToString(),
//                                Value = dbParam.Value ?? DBNull.Value
//                            };
//                            cmd.Parameters.Add(sqlParam);
//                            str.Append($"cmd.Parameters.Add(new SqlParameter({commandParameters[i]}, {dbParam.Value ?? DBNull.Value}));");
//                        }
//                        else // Tham số không phải là IDbDataParameter, xử lý bình thường.
//                        {
//                            var sqlParam = new SqlParameter
//                            {
//                                ParameterName = commandParameters[i].ToString(),
//                                Value = currentValue ?? DBNull.Value
//                            };
//                            cmd.Parameters.Add(sqlParam);
//                            str.Append($"cmd.Parameters.Add(new SqlParameter({commandParameters[i]}, {currentValue ?? DBNull.Value}));");
//                        }
//                    }

//                    //while
//                    using (var reader = cmd.ExecuteReader())
//                    {
//                        var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
//                        while (reader.Read())
//                        {
//                            var obj = new TValue();
//                            foreach (var column in columns)
//                            {
//                                var property = typeof(TValue).GetProperty(column);
//                                if (property == null || reader[column] is DBNull) continue;
//                                property.SetValue(obj, Convert.ChangeType(reader[column], property.PropertyType));
//                            }
//                            kq.Add(obj);
//                        }
//                        return kq;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            con.Close();
//            return kq;
//        }
//        catch (Exception ex)
//        {
//            if (con.State == ConnectionState.Open)
//            {
//                con.Close();
//            }
//            LogBuild.CreateLogger(str.ToString(), Stored + "_Param");
//            LogBuild.CreateLogger("Error: " + ex.ToString(), Stored);
//            return kq;
//        }
//    }


//    //Helper
//    public static List<T> ExecuteList_Helper<T>(string strCon, string Stored, params object[] parameterValues) where T : new()
//    {
//        var dt = SqlHelper.ExecuteTable(ConfigurationManager.AppSettings.Get(strCon), Stored, parameterValues);
//        return dt.HasRow() ? dt.ToList<T>() : new List<T>();
//    }
//    public static DataTable ExecuteTable_Helper(string strCon, string Stored, params object[] parameterValues)
//    {
//        var ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings.Get(strCon), Stored, parameterValues);
//        return ds.HasItem() ? ds.Tables[0] : new DataTable();
//    }





//}
