using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

public class IsChekIPV4
{
    public static IPAddress PublicIp { get; private set; }
    // ViewBag.ShowIP = IsChekIPV4.Get_IsChekIPV4_V2(); 

    #region V1
    public static string GetLocalIpAddresses_V00()
    {
        String direction = "";
        WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
        using (WebResponse response = request.GetResponse())
        using (StreamReader stream = new StreamReader(response.GetResponseStream()))
        {
            direction = stream.ReadToEnd();
        }
        int first = direction.IndexOf("Address: ") + 9;
        int last = direction.LastIndexOf("</body>");
        direction = direction.Substring(first, last - first);
        return direction;
    }
    public static string GetLocalIpAddresses_V0()
    {
        string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
        var externalIp = IPAddress.Parse(externalIpString);
        return externalIp.ToString();
    }
    public static string GetLocalIpAddresses_V1()
    {
        string externalIpString = new WebClient().DownloadString(" http://ipinfo.io/ip").Trim();
        var externalIp = IPAddress.Parse(externalIpString);
        return externalIp.ToString();
    }
    public static string GetLocalIpAddresses_V2()
    {
        string pubIp = new System.Net.WebClient().DownloadString("https://api.ipify.org");
        return pubIp.ToString();
    }
    public static string GetLocalIpAddresses_V3()
    {
        var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");
        request.UserAgent = "curl"; // this will tell the server to return the information as if the request was made by the linux "curl" command
        string publicIPAddress;
        request.Method = "GET";
        using (WebResponse response = request.GetResponse())
        {
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                publicIPAddress = reader.ReadToEnd();
            }
        }
        return publicIPAddress.Replace("\n", "");
    }
    public static string GetLocalIpAddresses_V4()
    {
        string externalip = new WebClient().DownloadString("https://ipv4.icanhazip.com/");
        return externalip.TrimEnd();
    }

    #endregion


    #region V2
    public static IPAddress Get_IsChekIPV4_V1()
    {
        List<string> services = new List<string>()
        {
            "https://ipv4.icanhazip.com",
            "https://api.ipify.org",
            "https://ipinfo.io/ip",
            "https://checkip.amazonaws.com",
            "https://wtfismyip.com/text",
            "http://icanhazip.com"
        };
        using (var webclient = new WebClient())
            foreach (var service in services)
            {
                try
                {
                    return IPAddress.Parse(webclient.DownloadString(service));
                }
                catch { }
            }
        return null;
    }

    public static string Get_IsChekIPV4_V2()
    {
        string result = string.Empty;
        try
        {
            using (var client = new WebClient())
            {
                client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                "(compatible; MSIE 6.0; Windows NT 5.1; " +
                ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                try
                {
                    byte[] arr = client.DownloadData("http://checkip.amazonaws.com/");

                    string response = System.Text.Encoding.UTF8.GetString(arr);

                    result = response.Trim();
                }
                catch (WebException)
                {
                }
            }
        }
        catch
        {
        }

        if (string.IsNullOrEmpty(result))
        {
            try
            {
                result = new WebClient().DownloadString("https://ipinfo.io/ip").Replace("\n", "");
            }
            catch
            {
            }
        }

        if (string.IsNullOrEmpty(result))
        {
            try
            {
                result = new WebClient().DownloadString("https://api.ipify.org").Replace("\n", "");
            }
            catch
            {
            }
        }

        if (string.IsNullOrEmpty(result))
        {
            try
            {
                result = new WebClient().DownloadString("https://icanhazip.com").Replace("\n", "");
            }
            catch
            {
            }
        }

        if (string.IsNullOrEmpty(result))
        {
            try
            {
                result = new WebClient().DownloadString("https://wtfismyip.com/text").Replace("\n", "");
            }
            catch
            {
            }
        }

        if (string.IsNullOrEmpty(result))
        {
            try
            {
                result = new WebClient().DownloadString("http://bot.whatismyipaddress.com/").Replace("\n", "");
            }
            catch
            {
            }
        }

        if (string.IsNullOrEmpty(result))
        {
            try
            {
                string url = "http://checkip.dyndns.org";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                string[] a = response.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                result = a3[0];
            }
            catch (Exception)
            {
            }
        }

        return result;
    }
    #endregion

}