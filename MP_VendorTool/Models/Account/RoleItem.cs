using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Account
{
    public class RoleItem
    {
        public string BBM_Code { set; get; }
        public string roleCode { set; get; }
        public string controlCode { set; get; }
        public string create_act { set; get; }
        public string view_act { set; get; }
        public string edit_act { set; get; }
        public string accept_act { set; get; }

    }
}