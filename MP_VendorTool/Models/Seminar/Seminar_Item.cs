using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Seminar
{
    public class Seminar_Item
    {
        public string code { set; get; }
        public string NameCode { set; get; }
        public int id { set; get; }
        public string Name { set; get; }
        public string UoM { set; get; }
        public string packId { set; get; }
        public string namePack { set; get; }
        public string headerID { set; get; }
        public string qty { set; get; }
    }
}