using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.ERP_API;
using MP_VendorTool.Models.Noti;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

public class BaseApiClient
{
    private static string BaseAddress = ConfigurationManager.AppSettings.Get("BaseAddress");
    private static string TokenAPI = ConfigurationManager.AppSettings.Get("TokenAPI");
    public async static Task<API_returnAPI> PostAsync_API_Noti<TSearch>(string BaseAddress, string TokenAPI, string Url, TSearch it)
    {
        API_returnAPI rt = new API_returnAPI();
        var client = new HttpClient();
        string strParam = "";
        try
        {
            BaseAddress = ConfigurationManager.AppSettings.Get(BaseAddress);
            string url = BaseAddress + Url;
            if (!String.IsNullOrEmpty(TokenAPI))
            {
                string key = TokenAPI;
                client.DefaultRequestHeaders.Add("Authorization", key);
            }
            client.BaseAddress = new Uri(url);

            strParam = JsonConvert.SerializeObject(it);
            var content = new StringContent(strParam, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(Url, content);

            string res = await response.Content.ReadAsStringAsync();
            if ((int)response.StatusCode == 200)
            {
                rt.StatusCode = true;
                LogBuild.CreateLogger(strParam + response.Content, Url);
                rt.Items = res;
            }
            else
            {
                rt.StatusCode = false;
                rt.Items = "";
            }
        }
        catch (Exception e)
        {
            LogBuild.CreateLogger(strParam + e.Message, "Url");
        }
        return rt;
    }
    public async static Task<API_returnAPI_Call<TKey>> CallAsync_API<TKey>(string Url)
    {
        API_returnAPI_Call<TKey> rt = new API_returnAPI_Call<TKey>();
        try
        {
            var client = new HttpClient();
            string key = TokenAPI;
            string url = BaseAddress + Url;
            client.DefaultRequestHeaders.Add("Authorization", key);

            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            string res = await response.Content.ReadAsStringAsync();
            if ((int)response.StatusCode == 200)
            {
                rt.StatusCode = true;
                //rt.Items = res;
                var obj = JsonConvert.DeserializeObject<List<TKey>>(JObject.Parse(res)["Item"].ToString());
                rt.Items = obj;
            }
            else
            {
                rt.StatusCode = false;
                rt.Items = null;
            }
        }
        catch (Exception ex)
        {
            rt.StatusCode = false;
            rt.Items = null;
        }
        return rt;
    }
    public async static Task<API_returnAPI> GetAsync_API(string Url)
    {
        API_returnAPI rt = new API_returnAPI();
        try
        {
            var client = new HttpClient();
            string key = TokenAPI;
            string url = BaseAddress + Url;
            client.DefaultRequestHeaders.Add("Authorization", key);

            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            string res = await response.Content.ReadAsStringAsync();
            if ((int)response.StatusCode == 200)
            {
                rt.StatusCode = true;
                rt.Items = JObject.Parse(res)["Item"].ToString();
            }
            else
            {
                rt.StatusCode = false;
                rt.Items = JObject.Parse(res)["Message"].ToString();
            }
        }
        catch (Exception ex)
        {
            rt.StatusCode = false;
            rt.Items = JsonConvert.SerializeObject(ex);
        }
        return rt;
    }
    public async static Task<API_returnAPI_Call<TKey>> PostAsync_Param_API<TKey, TSearch>(string Url, TSearch it)
    {
        API_returnAPI_Call<TKey> rt = new API_returnAPI_Call<TKey>();
        var client = new HttpClient();
        string strParam = "";
        try
        {
            string key = TokenAPI;
            string urls = BaseAddress;
            client.DefaultRequestHeaders.Add("Authorization", key);

            client.BaseAddress = new Uri(urls);
            strParam = JsonConvert.SerializeObject(it);
            var content = new StringContent(strParam, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(Url, content);

            string res = await response.Content.ReadAsStringAsync();
            if ((int)response.StatusCode == 200)
            {
                rt.StatusCode = true;
                var obj = JsonConvert.DeserializeObject<List<TKey>>(JObject.Parse(res)["Item"].ToString());
                rt.Items = obj;
                LogBuild.CreateLogger(strParam + response.Content, Url);
            }
            else
            {
                rt.StatusCode = false;
                rt.Items = null;
            }
        }
        catch (Exception e)
        {
            LogBuild.CreateLogger(strParam + e.Message, "Url");
        }
        return rt;
    }// Search obj
    public async static Task<API_returnAPI> PostAsync_API<TSearch>(string Url, TSearch it)
    {
        API_returnAPI rt = new API_returnAPI();
        var client = new HttpClient();
        string strParam = "";
        try
        {
            string key = TokenAPI;
            string urls = BaseAddress;
            client.DefaultRequestHeaders.Add("Authorization", key);

            client.BaseAddress = new Uri(urls);
            strParam = JsonConvert.SerializeObject(it);
            var content = new StringContent(strParam, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(Url, content);

            string res = await response.Content.ReadAsStringAsync();
            if ((int)response.StatusCode == 200)
            {
                rt.StatusCode = true;
                LogBuild.CreateLogger(strParam + response.Content, Url);
            }
            else
            {
                rt.StatusCode = false;
                rt.Items = JObject.Parse(res)["Message"].ToString();
            }
        }
        catch (Exception e)
        {
            LogBuild.CreateLogger(strParam + e.Message, "Url");
        }
        return rt;
    }
    public async static Task<API_returnAPI> DeleteAsync_API(string Url)
    {
        API_returnAPI rt = new API_returnAPI();
        try
        {
            var client = new HttpClient();
            string key = TokenAPI;
            string url = BaseAddress + Url;
            client.DefaultRequestHeaders.Add("Authorization", key);

            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.DeleteAsync("");
            string res = await response.Content.ReadAsStringAsync();
            if ((int)response.StatusCode == 200)
            {
                rt.StatusCode = true;
            }
            else
            {
                rt.StatusCode = false;
            }
        }
        catch (Exception ex)
        {
            rt.StatusCode = false;
        }
        return rt;
    }
}
