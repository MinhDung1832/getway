using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Account
{
    public class user_Item
    {
        public string userName { set; get; }
        public string password { set; get; }
        public string token { set; get; }
    }
    public class user_Role
    {
        public string userName { set; get; }
        public string password { set; get; }
        public string URole { set; get; }
    }
    public class IsCheck_IPV4
    {
        public string UserName { set; get; }
        public string DiaChiIPV4 { set; get; }
        public string DiaChiIP { set; get; }
    }
    public class Company
    {
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }
        public string Address { set; get; }
        public string Masothue { set; get; }
        public string Dienthoai { set; get; }
        public string NguoiLienHe { set; get; }
        public string Email { set; get; }
        public string website { set; get; }
    }

    public class permissioninfo
    {
        public string fcode { set; get; }
        public string fname { set; get; }
        public string paname { set; get; }
        public string parentcode { set; get; }
        public string action { set; get; }
        public string controller { set; get; }
        public string icon { set; get; }
    }

}