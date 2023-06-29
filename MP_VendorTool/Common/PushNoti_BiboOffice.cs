using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MP_VendorTool.Models.Noti;
public class PusNoti
{
    

    public class ReturnTemplate_PushNoti
    {
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public string Content_Type { get; set; }// Html, url, uri
        public string Phone_MaNhanVien { get; set; }
    }
}
