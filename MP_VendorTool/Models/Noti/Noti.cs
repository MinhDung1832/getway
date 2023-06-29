using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Noti
{
    public class Param
    {
        public string MaNhanVien { get; set; }
        public List<Value> value { get; set; }
    }

    public class topic
    {
        public string Value { get; set; }
    }

    public class AddNotionPush
    {
        public int channel { get; set; }
        public string content { get; set; }
        public string content_type { get; set; }
        public string cover { get; set; }
        public string description { get; set; }
        public string receiver_type { get; set; }
        public int status { get; set; }
        public string title { get; set; }
        public List<topic> topics { get; set; }
        public List<Param> Params { get; set; }
        public string published { get; set; }
    }

    public class Value
    {
        public string ParamKey { get; set; }
        public string ParamValue { get; set; }
    }

    // Save
    public class obj_Noti_Firebase_FCM
    {
        public int channel { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string contens { get; set; }
        public string content_type { get; set; }
        public string Images { get; set; }
        public string Published { get; set; }
        public string receiver_type { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string TimeNoti { get; set; }
        public string DateNoti { get; set; }
        public string Paraminput { get; set; }
        
    }

    public class Obj_Noti_Firebase_FCM_Topics
    {
        public string Value { get; set; }
    }

    public class Obj_Noti_Firebase_FCM_Params_To
    {
        public int Parent_ID { get; set; }
        public string receiver_type { get; set; }
        public string Phone { get; set; }
    }

    public class Obj_Noti_Firebase_FCM_Params
    {
        public int Parent_ID { get; set; }
        public int Parent_ID_To { get; set; }
        public string ParamKey { get; set; }
        public string ParamValue { get; set; }
    }

    public class Obj_Noti_Messenger
    {
        public int IDPush { get; set; }
        public string VendorNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Contens { get; set; }
        public string Published { get; set; }
        public string Images { get; set; }
        public string content_type { get; set; }
        public string Status { get; set; }
        public string StatusSend { get; set; }
        public string CreateBy { get; set; }
        public string JsonAPI { get; set; }
        public string Paraminput { get; set; }
        public string ParamSend { get; set; }
    }
    public class Obj_vendor
    {
        public string ID { set; get; }
        public string type { set; get; }
    }
    public class Root_Noti
    {
        public int status { get; set; }
        public string message { get; set; }
        public int idHeader { get; set; }
        public string iD_Noti { get; set; }
        public bool statusSend { get; set; }
        public string item { get; set; }
    }


}