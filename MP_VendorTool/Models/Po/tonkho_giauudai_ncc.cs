using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Po
{
    public class tbl_tonkho_giauudai_ncc
    {
        public string MaNCC { get; set; }
        public string MaHang { get; set; }
        public decimal Giauudai { get; set; }
        public decimal SLtonkho { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public DateTime NgayHetHan { get; set; }
        public DateTime NgayCapnhat { get; set; }
        public string Nguoicapnhat { get; set; }
    }
}
