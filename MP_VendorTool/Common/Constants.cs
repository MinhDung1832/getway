using MP_VendorTool.Models.Account;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MP_VendorTool.Common
{

    public class SystemFunctions
    {
        private static string uploadurl = ConfigurationManager.AppSettings.Get("Media_Url");
        private static string uploadFileurl = ConfigurationManager.AppSettings.Get("Mediafile_Url");
        private static string uploadkey = ConfigurationManager.AppSettings.Get("Media_Key");
        public static void SaveSession(string controller, string action)
        {
            HttpContext.Current.Session["prev_action"] = action;
            HttpContext.Current.Session["prev_control"] = controller;
        }

        public static async Task<string> UploadIMGDirect_Multiple(string folder, HttpPostedFileBase files)
        {
            var client = new HttpClient();
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
                form.Add(DictionaryItems, "model");
                var stream = files.InputStream;
                HttpContent content = new StringContent("");
                content = new StreamContent(stream);
                form.Add(content, "myFiles", files.FileName);
                form.Add(new StringContent(folder), "dir");
                client.DefaultRequestHeaders.Add("Authorization", uploadkey);
                HttpResponseMessage response = await client.PostAsync(uploadurl, form);
                string res = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    Root result = JsonConvert.DeserializeObject<Root>(res);
                    return result.files[0].url;
                }
                else
                {
                    return "Ảnh sai định dạng hoặc quá lớn.";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static async Task<string> UploadIMG(string folder, string files)
        {
            var client = new HttpClient();
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
                form.Add(DictionaryItems, "model");
                var stream = new FileStream(files, FileMode.Open);
                HttpContent content = new StringContent("");
                content = new StreamContent(stream);
                form.Add(content, "myFiles", files);
                form.Add(new StringContent(folder), "dir");
                client.DefaultRequestHeaders.Add("Authorization", uploadkey);
                HttpResponseMessage response = await client.PostAsync(uploadurl, form);
                string res = await response.Content.ReadAsStringAsync();


                if ((int)response.StatusCode == 200)
                {
                    Root result = JsonConvert.DeserializeObject<Root>(res);
                    return result.files[0].url;
                }
                else
                {
                    return "Ảnh sai định dạng hoặc quá lớn.";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static async Task<string> UploadIMGDirect(string folder, HttpPostedFile files)
        {
            var client = new HttpClient();
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
                form.Add(DictionaryItems, "model");
                var stream = files.InputStream;
                HttpContent content = new StringContent("");
                content = new StreamContent(stream);
                form.Add(content, "myFiles", files.FileName);
                form.Add(new StringContent(folder), "dir");
                client.DefaultRequestHeaders.Add("Authorization", uploadkey);
                HttpResponseMessage response = await client.PostAsync(uploadurl, form);
                string res = await response.Content.ReadAsStringAsync();


                if ((int)response.StatusCode == 200)
                {
                    Root result = JsonConvert.DeserializeObject<Root>(res);
                    return result.files[0].url;
                }
                else
                {
                    return "Ảnh sai định dạng hoặc quá lớn.";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static async Task<string> Upload_File_Direct(string folder, HttpPostedFile files)
        {
            var client = new HttpClient();
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
                form.Add(DictionaryItems, "model");
                var stream = files.InputStream;
                HttpContent content = new StringContent("");
                content = new StreamContent(stream);
                form.Add(content, "myFiles", files.FileName);
                form.Add(new StringContent(folder), "dir");
                client.DefaultRequestHeaders.Add("Authorization", uploadkey);
                HttpResponseMessage response = await client.PostAsync(uploadFileurl, form);
                string res = await response.Content.ReadAsStringAsync();


                if ((int)response.StatusCode == 200)
                {
                    Root result = JsonConvert.DeserializeObject<Root>(res);
                    return result.files[0].url;
                }
                else
                {
                    return "Ảnh sai định dạng hoặc quá lớn.";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public class File
        {
            public string mimetype { get; set; }
            public string url { get; set; }
            public long timestamp { get; set; }
        }

        public class Root
        {
            public int error { get; set; }
            public string message { get; set; }
            public List<File> files { get; set; }
        }
    }
    public class Constants
    {
        public static bool checkpermission(string controller, string action)
        {
            List<permissioninfo> ls = (List<permissioninfo>)HttpContext.Current.Session["permission"];
            if (ls.Where(x => x.controller == controller && x.action == action).Count() > 0)
                return true;
            else return false;
        }

        #region URLs PARTIAL VIEWs
        public const string Partial_Order_Index = "~/Views/Order/Partial/__Index.cshtml";
        public const string Partial_Order_Detail = "~/Views/Order/Partial/__Detail.cshtml";
        public const string Partial_TradingTerm_Index = "~/Views/TradingTermVendor/Partial/__Index.cshtml";
        public const string Partial_TradingTerm_Duyet_TRADING_TERM = "~/Views/TradingTermVendor/Partial/__DuyetTradingTerm.cshtml";

        #endregion URLs PARTIAL VIEWs

        #region [Date Formats]

        public const string SQLDateFormat = "yyyy-MM-dd";
        public const string SiteDateFormat = "dd/MM/yyyy";
        public const string SiteDateTimeFormat = "dd/MM/yyyy HH:mm:ss";
        public const string TimestampFormat = "yyyyMMddHHmmssfff";
        public static readonly string[] NullDate = { "01/01/0001", "01/01/1753", "31/12/9998", "31/12/9999" };

        #endregion
        public static string Split_Images(string Images)
        {
            string bReturn = "";
            if (Images != null && Images != "" && Images.ToString().Length > 5)
            {
                string[] strArray = Images.ToString().Split(new char[] { ',' });
                bReturn = strArray[0].ToString();
                //for (int i = 0; i < strArray.Length; i++)
                //{
                //    bReturn +=strArray[i].ToString();
                //}
            }
            return bReturn;
        }
        public static string Substring(string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }

    }
}
