using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MP_VendorTool.Models.ERP_API;
using MP_VendorTool.Models.Promotion;

namespace MP_VendorTool.DataAccess
{
    public class ERP_API_Promorion_DataAccess
    {
        #region API
        private static string APIDomain = ConfigurationManager.AppSettings.Get("APIDomain");
        //API ChangeStatus CTKM
        public async static Task<API_return> API_ChangeStatusCTKM(Models.ERP_API.Promotion.objChangeStatus it)
        {
            LogBuild.CreateLogger(JsonConvert.SerializeObject(it.No), "API_ChangeStatusCTKM");
            API_return rt = new API_return();
            try
            {
                if (it.No.Length > 0 && it.Type.Length > 0)
                {
                    var client = new HttpClient();
                    string url = "";
                    switch (it.Type)
                    {
                        case "Discount Offers":
                            url = APIDomain + "/api/ChangeStatusDiscountOffer";
                            break;
                        case "Mix&Match":
                            url = APIDomain + "/api/ChangeStatusMixMatch";
                            break;
                        case "Mix&match":
                            url = APIDomain + "/api/ChangeStatusMixMatch";
                            break;
                        case "Total Discount Offer":
                            url = APIDomain + "/api/ChangeStatusTotalDiscountOffer";
                            break;
                    }

                    string strParam = JsonConvert.SerializeObject(it);
                    var content = new StringContent(strParam, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string res = await response.Content.ReadAsStringAsync();
                    if ((int)response.StatusCode == 200)
                    {
                        rt.codeReturn = true;
                        rt.orderNo = JsonConvert.SerializeObject(res);
                    }
                    else
                    {
                        rt.codeReturn = false;
                        rt.orderNo = JObject.Parse(res)["Message"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                rt.codeReturn = false;
                rt.orderNo = JsonConvert.SerializeObject(ex);
            }
            LogBuild.CreateLogger(JsonConvert.SerializeObject(rt), "API_ChangeStatusCTKM");
            return rt;
        }

        //API MixMatch
        public async static Task<API_return> API_createMixMatch(Models.ERP_API.Promotion.MixMatch it)
        {
            LogBuild.CreateLogger(JsonConvert.SerializeObject(it), "API_createMixMatch");
            API_return rt = new API_return();
            try
            {
                var result = new API_return();
                if (it.MixMatchLineGroup.Count > 0)
                {
                    foreach (var box in it.MixMatchLineGroup)
                    {
                        result = await API_createMixMatchLineGroup(box);
                    }
                }
                if (result.codeReturn)
                {
                    var client = new HttpClient();
                    string url = APIDomain + "/api/PostMixMatch";
                    string strParam = JsonConvert.SerializeObject(it);
                    var content = new StringContent(strParam, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string res = await response.Content.ReadAsStringAsync();

                    if ((int)response.StatusCode == 200)
                    {
                        rt.codeReturn = true;
                        rt.orderNo = JsonConvert.SerializeObject(res);
                    }
                    else
                    {
                        rt.codeReturn = false;
                        rt.orderNo = JObject.Parse(res)["Message"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                rt.codeReturn = false;
                rt.orderNo = JsonConvert.SerializeObject(ex);
            }
            LogBuild.CreateLogger(JsonConvert.SerializeObject(rt), "API_createMixMatch");
            return rt;
        }
        public async static Task<API_return> API_createMixMatchLineGroup(Models.ERP_API.Promotion.MixMatchLineGroup it)
        {
            LogBuild.CreateLogger(JsonConvert.SerializeObject(it), "API_createMixMatchLineGroup");
            API_return rt = new API_return();
            try
            {
                var client = new HttpClient();
                string url = APIDomain + "/api/PostMixMatchLineGroup";
                string strParam = JsonConvert.SerializeObject(it);

                var content = new StringContent(strParam, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                string res = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {
                    rt.codeReturn = true;
                    rt.orderNo = JsonConvert.SerializeObject(res);
                }
                else
                {
                    rt.codeReturn = false;
                    rt.orderNo = JObject.Parse(res)["Message"].ToString();
                }
            }
            catch (Exception ex)
            {
                rt.codeReturn = false;
                rt.orderNo = JsonConvert.SerializeObject(ex);
            }
            LogBuild.CreateLogger(JsonConvert.SerializeObject(rt), "API_createMixMatchLineGroup");
            return rt;
        }
        //End API MixMatch
        public async static Task<API_return> API_GetCusPriceGroup()
        {
            API_return rt = new API_return();
            try
            {
                var client = new HttpClient();
                string url = APIDomain + "/api/GetCusPriceGroup";
                HttpResponseMessage response = client.GetAsync(url).Result;
                string res = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {
                    rt.codeReturn = true;
                    rt.Items = JsonConvert.SerializeObject(res);
                }
                else
                {
                    rt.codeReturn = false;
                    rt.orderNo = JObject.Parse(res)["Message"].ToString();
                }
            }
            catch (Exception ex)
            {
                rt.codeReturn = false;
                rt.orderNo = JsonConvert.SerializeObject(ex);
            }
            LogBuild.CreateLogger(JsonConvert.SerializeObject(rt), "API_GetCusPriceGroup");
            return rt;
        }
        public async static Task<API_return> API_createDiscountOffer(Models.ERP_API.Promotion.DiscountOffer it)
        {
            LogBuild.CreateLogger(JsonConvert.SerializeObject(it), "API_createDiscountOffer");
            API_return rt = new API_return();

            try
            {
                var client = new HttpClient();
                string url = APIDomain + "/api/PostDiscountOffer";
                string strParam = JsonConvert.SerializeObject(it);

                var content = new StringContent(strParam, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                string res = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {
                    rt.codeReturn = true;
                    rt.orderNo = JsonConvert.SerializeObject(res);
                }
                else
                {
                    rt.codeReturn = false;
                    rt.orderNo = JObject.Parse(res)["Message"].ToString();
                }
            }
            catch (Exception ex)
            {
                rt.codeReturn = false;
                rt.orderNo = JsonConvert.SerializeObject(ex);
            }
            LogBuild.CreateLogger(JsonConvert.SerializeObject(rt), "API_createDiscountOffer");
            return rt;
        }
        public async static Task<API_return> API_GenerateCodeKM(string typeCTKM)
        {
            API_return rt = new API_return();
            try
            {
                var client = new HttpClient();
                string url = "";
                switch (typeCTKM)
                {
                    case "Discount Offers":
                        url = APIDomain + "/api/GenerateCodePostDiscountOffer";
                        break;
                    case "Mix&Match":
                        url = APIDomain + "/api/GenerateCodeMixMatch";
                        break;

                    case "Total Discount Offer":
                        url = APIDomain + "/api/GenerateCodeTotalDiscountOffer";
                        break;
                }
                string strParam = "";
                var content = new StringContent(strParam, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.GetAsync(url).Result;
                string res = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {
                    rt.codeReturn = true;
                    rt.No = JsonConvert.SerializeObject(res);
                }
                else
                {
                    rt.codeReturn = false;
                    rt.No = JObject.Parse(res)["Message"].ToString();
                }
            }
            catch (Exception ex)
            {
                rt.codeReturn = false;
                rt.No = JsonConvert.SerializeObject(ex);
            }
            LogBuild.CreateLogger(JsonConvert.SerializeObject(rt), "API_GenerateCodeDiscountOffer");
            return rt;
        }

        public async static Task<API_return> API_createTotalDiscountOffer(Models.ERP_API.Promotion.TotalDiscountOffer it)
        {
            LogBuild.CreateLogger(JsonConvert.SerializeObject(it), "API_createTotalDiscountOffer");
            API_return rt = new API_return();
            try
            {
                var client = new HttpClient();
                string url = APIDomain + "/api/TotalDiscountOffer";
                string strParam = JsonConvert.SerializeObject(it);
                var content = new StringContent(strParam, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                string res = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {
                    rt.codeReturn = true;
                    rt.orderNo = JsonConvert.SerializeObject(res);
                }
                else
                {
                    rt.codeReturn = false;
                    rt.orderNo = JObject.Parse(res)["Message"].ToString();
                }
            }
            catch (Exception ex)
            {
                rt.codeReturn = false;
                rt.orderNo = JsonConvert.SerializeObject(ex);
            }
            LogBuild.CreateLogger(JsonConvert.SerializeObject(rt), "API_createTotalDiscountOffer");
            return rt;
        }

        public async static Task<API_return> API_CreateValidationPeriod(Models.ERP_API.Promotion.ValidationPeriod it)
        {
            LogBuild.CreateLogger(JsonConvert.SerializeObject(it), "API_CreateValidationPeriod");
            API_return rt = new API_return();
            try
            {
                var client = new HttpClient();
                string url = APIDomain + "/api/PostValidationPeriod";
                string strParam = JsonConvert.SerializeObject(it);

                var content = new StringContent(strParam, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                string res = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {
                    rt.codeReturn = true;
                    rt.ValidationPeriodID = JsonConvert.SerializeObject(res);
                }
                else
                {
                    rt.codeReturn = false;
                    rt.ValidationPeriodID = JObject.Parse(res)["Message"].ToString();
                }
            }
            catch (Exception ex)
            {
                rt.codeReturn = false;
                rt.ValidationPeriodID = JsonConvert.SerializeObject(ex);
            }
            LogBuild.CreateLogger(JsonConvert.SerializeObject(rt), "API_createDiscountOffer");
            return rt;
        }
        #endregion
    }
}