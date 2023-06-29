using MP_VendorTool.DataAccess;
using MP_VendorTool.Models.Account;
using MP_VendorTool.Models.Vendor;
using Newtonsoft.Json;
using Lib.Utils.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Text;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;

namespace MP_VendorTool.Controllers
{
    public class AccountController : MyController
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdsfghjklqwertyuiopzxcvbnm0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        static string hash { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";

        public ActionResult Login()
        {
            // Code Gen mật khẩu danh sách toàn bộ NCC
            // trong bảng db cần thêm 2 trường nữa. PasND , passwordND
            //var bn = DataAccess.DataAccess.List_TaiKhoan();
            //if (bn != null)
            //{
            //    foreach (var item in bn)
            //    {
            //        string hash = RandomString(10);
            //        DataAccess.DataAccess.List_TaiKhoanUpdate(item.Name, hash, DataAccess.DataAccess.MD5Hash(hash));
            //    }
            //}

            // ViewBag.ShowIP = IsChekIPV4.Get_IsChekIPV4_V2();

            //  var cc = DataAccess.DataAccess.MD5Hash("live8888");

            Session["err"] = "";
            if (Session["all_us_role"] != null)
            {
                //return RedirectToAction("Index", "Vendor");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ForgotPassword()
        {
            Session["errp"] = null;
            return View();
        }
        public ActionResult Logout()
        {
            Session.Contents.RemoveAll();

            return RedirectToAction("Login");
        }
        public ActionResult ChangePassword(string token = "")
        {
            Session["errc"] = null;
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    if (token.Length > 0)
                    {
                        ViewBag.old = "token:" + token;
                    }
                    else
                    {
                        ViewBag.old = "";
                    }
                    return View();
                }
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AccountController_ChangePassword");
                return RedirectToAction("Logout");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection ip_form)
        {
            string uid = ip_form["uid"].ToUpper();
            string pwd = ip_form["pwd"];
            string IsChekIPV4 = ip_form["IsChekIPV4"];

            Session["TypePhongBan"] = "";
            //string pwdmd5 = DataAccess.DataAccess.MD5Hash(pwd);
            //string pwdAES = AES.Encrypt(pwd);
            // Thủ tục tạo user cho nhà cung từ ERp về . Mạnh: --> sp_BBM_MP_VendorTool_AutoSync_VendorTool_User ,--> và Auto_Create_UserName_Pass_PhongBanNCC

            // Note 
            // Gen_TaiKhoan_Vender_PhongBan_MaSoThue
            //Auto_Create_UserName_Pass_PhongBanNCC_DuyetDangKyHoptac
            //sp_BBM_MP_VendorTool_AutoSync_VendorTool_User_DuyetDangKyHoptac
            //Auto_Create_UserName_Pass_PhongBanNCC


            var bn = new user_Item();
            if (uid.Length > 0 && uid.ToUpper().Substring(0, 1) == "B") //Login thành viên
            {
                var uid3 = uid.ToUpper().Substring(0, 1);
                bn = DataAccess.DataAccess.BBM_MP_TradingTern_Login_User(0, 0, new Models.Account.user_Item { userName = uid, password = AES.Encrypt(pwd) });
                if (bn.userName != null)
                {
                    Session["Admin"] = uid;
                    Session["uid"] = uid;
                    Session["uname"] = bn.userName;
                    Session["VendorName"] = "";
                    Session["TypePhongBan"] = "NV";

                    var us_role = DataAccess.DataAccess.sp_BBM_MP_VendorTool_UserRole_get(uid.Split('-')[0]);
                    if (us_role.Count > 0)
                    {
                        Session["all_us_role"] = us_role;
                        Session["uname"] = bn.userName;
                        RoleItem us_role2 = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");
                        Session["us_role"] = us_role2;
                        Session["roleCode"] = us_role2.roleCode;
                    }

                    List<permissioninfo> per = DataAccess.DataAccess.sp_getWay_getPermissionbyUser(uid);
                    Session["permission"] = per;
                    if (Session["prev_action"] != null && Session["prev_control"] != null)
                    {
                        try
                        {
                            return RedirectToAction(Session["prev_action"].ToString(), Session["prev_control"].ToString());
                        }
                        catch (Exception ex)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    @Session["err"] = "Sai tài khoản hoặc Sai mật khẩu";
                    return View();
                }
            }
            else //Login Nhà cung cấp theo phòng ban 
            {
                //Thủ tục tạo mã phòng ban NCC --> sp_VENDOR_Create_UserName_pass_Ncc
                //uid = uid.ToUpper().Substring(0, 1);
                //if (uid.ToLower() + "@123456" == pwd.ToLower())
                //{
                //    bn = DataAccess.DataAccess.BBM_MP_VendorTool_User_get(0, 0, new Models.Account.user_Item { userName = uid, password = pwd });// Mã NCC + @123456
                //}
                // kiểm tra login nếu là Phòng ban của nhà cung

                var PBan = DataAccess.DataAccess.BBM_MP_VendorTool_Department_User_get(uid, DataAccess.DataAccess.MD5Hash(pwd));
                if (PBan.userName != null)
                {
                    #region Tạm thời rào lại , khi nào cần lại mở ra.
                    //var isChekIPV4 = IsChekIPV4;// IsChekIPV4.Get_IsChekIPV4_V2();
                    //bool ChekIPV4 = false;
                    //string ThongBao = "Địa chỉ IP chưa được đăng ký với Bibo Mart. Vui lòng liên hệ với Admin để được hỗ trợ.";
                    //var IsChek = DataAccess.DataAccess.BBM_MP_VendorTool_Department_IsCheck_IPV4(uid);
                    //if (IsChek.Count > 0)
                    //{
                    //    ThongBao = "Địa chỉ IP đăng nhập không khớp với thông tin đã đăng ký. Vui lòng liên hệ với Admin để được hỗ trợ.";
                    //    // ThongBao = "IP của bạn không đúng với bản khai , và đây là (" + IsChek[0].DiaChiIP + ") cũ.<br /> IP hiện tại trên máy của bạn là :"+ isChekIPV4 + " <br /> Vui lòng kiểm tra lại";
                    //    foreach (var item in IsChek)
                    //    {
                    //        if (item.DiaChiIPV4 == isChekIPV4)
                    //        {
                    //            ChekIPV4 = true;
                    //            break;
                    //        }
                    //    }
                    //}
                    //if (ChekIPV4 == false)
                    //{
                    //    @Session["err"] = ThongBao;
                    //    return View();
                    //}
                    #endregion

                    List<permissioninfo> per = DataAccess.DataAccess.sp_getWay_getPermissionby_PhongBan(uid);
                    Session["permission"] = per;

                    // uid = uid.ToUpper().Substring(0, 5);
                    if (PBan.userName != null)
                    {
                        Session["TypePhongBan"] = "PB";

                        // Session["URole"] = PBan.URole;
                        Session["Admin"] = uid;

                        Session["uid"] = PBan.userName;
                        Session["uname"] = PBan.userName;
                        Session["uids"] = uid.Split('-')[0];

                        //get Role

                        var us_role = DataAccess.DataAccess.sp_BBM_MP_VendorTool_UserRole_get(PBan.userName);
                        if (us_role.Count > 0)
                        {
                            Session["all_us_role"] = us_role;
                            RoleItem us_role2 = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");
                            Session["us_role"] = us_role2;
                            Session["roleCode"] = us_role2.roleCode;
                        }

                        var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_VendorCode(PBan.userName);
                        if (list_vendor.Count > 0)
                        {
                            Session["VendorName"] = list_vendor[0].Name;
                            Session["VendorCode"] = list_vendor[0].Code;
                        }
                        else
                        {
                            Session["uid"] = PBan.userName;
                            Session["uname"] = PBan.userName;
                            Session["VendorName"] = PBan.userName;
                            Session["VendorCode"] = PBan.userName;
                        }

                        // Tạm thời bỏ trạng thái trong db đi để lấy dc mã registrationTax,VendorContact_ID
                        //  var vd_contact = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_get(Request.Cookies["culture"].Value, 2, "", uid.Split('-')[0]);
                        //var vd_contact = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_get_login(Request.Cookies["culture"].Value, PBan.userName);
                        //if (vd_contact.Count > 0)
                        //{
                        //    Session["Vendor_con"] = vd_contact[0];
                        //    Session["registrationTax"] = vd_contact[0].registrationTax;
                        //    Session["on_VendorContact_ID"] = vd_contact[0].id;
                        //    Session["BBM_Code"] = "";
                        //}
                        //else
                        //{
                        //    Session["Vendor_con"] = null;
                        //    Session["registrationTax"] = "";
                        //    Session["on_VendorContact_ID"] = "";
                        //    Session["BBM_Code"] = uid.Split('-')[0];
                        //}
                        if (Session["prev_action"] != null && Session["prev_control"] != null)
                        {
                            try
                            {
                                return RedirectToAction(Session["prev_action"].ToString(), Session["prev_control"].ToString());
                            }
                            catch (Exception ex)
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        @Session["err"] = "Sai tài khoản hoặc Sai mật khẩu";
                        return View();
                    }

                }
                else // Tài khoản nhà cung
                {
                    bn = DataAccess.DataAccess.BBM_MP_VendorTool_User_get(0, 0, new Models.Account.user_Item { userName = uid, password = DataAccess.DataAccess.MD5Hash(pwd) });
                    if (bn.userName != null)
                    {
                        Session["TypePhongBan"] = "NCC";

                        //Session["URole"] = "|1|2|3|4|";
                        Session["Admin"] = uid;

                        Session["uid"] = uid;
                        Session["uname"] = bn.userName;
                        Session["uids"] = uid.Split('-')[0];

                        //get Role

                        List<permissioninfo> per = DataAccess.DataAccess.sp_getWay_getPermissionby_NCC();
                        Session["permission"] = per;

                        var us_role = DataAccess.DataAccess.sp_BBM_MP_VendorTool_UserRole_get(uid.Split('-')[0]);
                        if (us_role.Count > 0)
                        {
                            Session["all_us_role"] = us_role;
                            RoleItem us_role2 = ((List<RoleItem>)Session["all_us_role"]).FirstOrDefault(s => s.controlCode == "C001");
                            Session["us_role"] = us_role2;
                            Session["roleCode"] = us_role2.roleCode;
                        }

                        var list_vendor = DataAccess.DataAccess.SP_TRADTERM_GET_Vendor_VendorCode(uid.Split('-')[0]);
                        if (list_vendor.Count > 0)
                        {
                            Session["VendorName"] = list_vendor[0].Name;
                            Session["VendorCode"] = list_vendor[0].Code;
                        }
                        else
                        {
                            Session["uid"] = uid;
                            Session["uname"] = bn.userName;
                            Session["VendorName"] = bn.userName;
                            Session["VendorCode"] = bn.userName;
                        }

                        // Tạm thời bỏ trạng thái trong db đi để lấy dc mã registrationTax,VendorContact_ID
                        //get vendor contact
                        //  var vd_contact = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_get(Request.Cookies["culture"].Value, 2, "", uid.Split('-')[0]);
                        //var vd_contact = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorContact_get_login(Request.Cookies["culture"].Value, uid.Split('-')[0]);
                        //if (vd_contact.Count > 0)
                        //{
                        //    Session["Vendor_con"] = vd_contact[0];
                        //    Session["registrationTax"] = vd_contact[0].registrationTax;
                        //    Session["on_VendorContact_ID"] = vd_contact[0].id;
                        //    Session["BBM_Code"] = "";
                        //}
                        //else
                        //{
                        //    Session["Vendor_con"] = null;
                        //    Session["registrationTax"] = "";
                        //    Session["on_VendorContact_ID"] = "";
                        //    Session["BBM_Code"] = uid.Split('-')[0];
                        //}

                        try
                        {
                            if (us_role[0].roleCode == "RA")
                            {
                                return RedirectToAction("UpdateLst", "Product");
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        if (Session["prev_action"] != null && Session["prev_control"] != null)
                        {
                            try
                            {
                                return RedirectToAction(Session["prev_action"].ToString(), Session["prev_control"].ToString());
                            }
                            catch (Exception ex)
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        @Session["err"] = "Sai tài khoản hoặc Sai mật khẩu";
                        return View();
                    }
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(FormCollection ip_form)
        {
            try
            {
                string uid = ip_form["uid"].ToUpper();
                // string email = ip_form["email"];
                //checck info

                var bn = DataAccess.DataAccess.sp_BBM_MP_VendorTool_VendorEmail_get(uid);
                if (bn.Count > 0)
                {
                    if ((bn[0].Name).Trim() != "")
                    {
                        if (bn[0].Code.ToString().Trim() == "1")// --> = 1 là Type NCC
                        {
                            #region Type=1 NCC 
                            var newpass = DataAccess.DataAccess.genPassword(12);
                            var upPass = DataAccess.DataAccess.BBM_MP_VendorTool_Change_pass(new user_Item { userName = uid, password = DataAccess.DataAccess.MD5Hash(newpass) });
                            if (upPass.userName == null)
                            {
                                @Session["errp"] = "Tài khoản không tồn tại";
                                return View();
                            }
                            else
                            {
                                #region SendEmail
                                string chuoi = "";
                                chuoi += "<p><b>Chào bạn!</b></p>";
                                chuoi += "<p>Thông tin tài khoản và mật khẩu mới của bạn là:</p>";
                                chuoi += "<p><b>Tài khoản đăng nhập: </b>" + uid + "</p>";
                                //chuoi += "<p><b>Email: </b>" + bn[0].Name + "</p>";
                                chuoi += "<p><b>Mật khẩu: </b>" + newpass + " </p>";
                                chuoi += "<p>Mời bạn đăng nhập vào link sau để bắt đầu sử dụng hệ thống của chúng tôi: https://gateway.bibomart.net </p>";
                                chuoi += "<br />";
                                // EmailSend_Send("Thông tin Reset Password trên Gateway Bibomart ", chuoi, bn[0].Name);
                                MailUtilities.SendMail(bn[0].Name, "Thông tin Reset Password trên Gateway Bibo Mart", chuoi);
                                #endregion

                                try
                                {
                                    DataAccess.DataAccess.Log_ResetPass_Vendor_add(uid, bn[0].Name, newpass, chuoi, "LayLaiMatKhau");
                                }
                                catch (Exception)
                                { }

                                @Session["errp"] = "Mật khẩu của bạn đã được thay đổi. Vui lòng check email <i style=\"color:#ffe425;\">(" + bn[0].Name + ")</i>";
                                return View();
                            }

                            #endregion
                        }
                        else
                        {
                            #region Type=2 Phòng ban NCC 
                            var newpass = DataAccess.DataAccess.genPassword(12);
                            var upPass = DataAccess.DataAccess.BBM_MP_VendorTool_Change_pass_PhongBan(new user_Item { userName = uid, password = DataAccess.DataAccess.MD5Hash(newpass) });
                            if (upPass.userName == null)
                            {
                                @Session["errp"] = "Tài khoản không tồn tại";
                                return View();
                            }
                            else
                            {
                                #region SendEmail
                                string chuoi = "";
                                chuoi += "<p><b>Chào bạn!</b></p>";
                                chuoi += "<p>Thông tin tài khoản và mật khẩu mới của bạn là:</p>";
                                chuoi += "<p><b>Tài khoản đăng nhập: </b>" + uid + "</p>";
                                chuoi += "<p><b>Mật khẩu: </b>" + newpass + " </p>";
                                chuoi += "<p>Mời bạn đăng nhập vào link sau để bắt đầu sử dụng hệ thống của chúng tôi: https://gateway.bibomart.net </p>";
                                chuoi += "<br />";
                                // EmailSend_Send("Thông tin Reset Password trên Gateway Bibomart ", chuoi, bn[0].Name);
                                MailUtilities.SendMail(bn[0].Name, "Thông tin Reset Password trên Gateway Bibo Mart", chuoi);
                                #endregion

                                try
                                {
                                    DataAccess.DataAccess.Log_ResetPass_Vendor_add(uid, bn[0].Name, newpass, chuoi, "LayLaiMatKhau_PB");
                                }
                                catch (Exception)
                                { }

                                @Session["errp"] = "Mật khẩu của bạn đã được thay đổi. Vui lòng check email <i style=\"color:#ffe425;\">(" + bn[0].Name + ")</i>";
                                return View();
                            }

                            #endregion
                        }
                    }
                    else
                    {
                        @Session["errp"] = "Không tìm thấy email. Vui lòng kiểm tra lại!";
                        return View();
                    }
                }
                else
                {
                    @Session["errp"] = "Không tìm thấy email. Vui lòng kiểm tra lại!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AccountController_ForgotPassword");
                @Session["errp"] = "Tài khoản không tồn tại hoặc email chưa đúng định dạng!.";
                return View();
            }

        }

        #region Mail
        public class return_Item
        {
            public string code_number { set; get; }
            public bool code_status { set; get; }
            public string content { set; get; }
        }
        public static return_Item EmailSend_Send(string str_title, string str_content, string mailTo)
        {
            return_Item rt = new return_Item();
            String FROM = ConfigurationManager.AppSettings.Get("SG_FROM");
            String FROMNAME = ConfigurationManager.AppSettings.Get("SG_FROMNAME");
            String SG_TokenKey = ConfigurationManager.AppSettings.Get("SG_TokenKey");

            String HOST = "smtp.sendgrid.net";
            int PORT = 587;
            // The subject line of the email
            String SUBJECT = str_title;

            // The body of the email
            String BODY = str_content;

            // Create and build a new MailMessage object
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            // message.To.Add(new MailAddress(mailTo));
            foreach (var address in mailTo.Trim().Split(';'))
            {
                message.Bcc.Add(new MailAddress(address.Trim(), ""));
            }
            message.Subject = SUBJECT;
            message.Body = BODY;
            // Comment or delete the next line if you are not using a configuration set
            //message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                // Pass SMTP credentials
                client.Credentials = new NetworkCredential("apikey", SG_TokenKey);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.
                try
                {
                    client.Send(message);
                    LogBuild.CreateLogger(mailTo + "Mail done", "_sendmail");
                    rt.code_status = true;
                    rt.content = "";
                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(ex.ToString(), "_sendmail");
                    rt.code_status = false;
                    rt.content = JsonConvert.SerializeObject(ex);
                }
                return rt;
            }
        }
        #endregion

        public static bool RegularExpressionsPassword(string pass)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(pass, @"^(?=(.*[a-z]){1,})(?=(.*[A-Z]){0,})(?=(.*[0-9]){1,})(?=(.*[!@#$%^&*()\-__+.]){0,}).{8,}$");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(FormCollection ip_form)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    string old = ip_form["old"];
                    string newpa = ip_form["newpa"];
                    string re_newpa = ip_form["re_newpa"];

                    //check NewsPass

                    if (old == "" || newpa == "" || re_newpa == "")
                    {
                        @Session["errc"] = "Vui lòng điền đầy đủ thông tin trên from";
                        return View();
                        // return RedirectToAction("ChangePassword", new { token = old.Replace("token:", "") });
                    }

                    if (newpa != re_newpa)
                    {
                        @Session["errc"] = "Mật khẩu mới không trùng nhau!";
                        return View();
                        // return RedirectToAction("ChangePassword", new { token = old.Replace("token:", "") });
                    }

                    if (newpa.Length <= 8)
                    {
                        @Session["errc"] = "Mật khẩu bao gồm 8 ký tự!";
                        return View();
                        // return RedirectToAction("ChangePassword", new { token = old.Replace("token:", "") });
                    }
                    else if (!RegularExpressionsPassword(newpa.Trim()) == true)
                    {
                        @Session["errc"] = "Mật khẩu phải gồm có ký tự từ a đến z và các số từ 0 đến 9";
                    }

                    if (Session["TypePhongBan"].ToString() == "NCC")
                    {
                        #region Đổi mật khẩu NCC
                        old = DataAccess.DataAccess.MD5Hash(old);
                        var Us_exist = DataAccess.DataAccess.BBM_MP_VendorTool_User_get(0, 0, new user_Item { userName = Session["uid"].ToString(), password = old, token = old });
                        if (Us_exist.userName == null)
                        {
                            @Session["errc"] = "Mật khẩu cũ không đúng!";
                            return View();
                        }

                        var passEn = DataAccess.DataAccess.MD5Hash(newpa);
                        var upPass = DataAccess.DataAccess.BBM_MP_VendorTool_User_get(1, 0, new user_Item { userName = Us_exist.userName, password = passEn, token = DataAccess.DataAccess.Encryption(newpa) });
                        try
                        {
                            string chuoi = "";
                            chuoi += "<p>Pass Old:" + ip_form["old"] + "</p>";
                            chuoi += "<p>Pass New:" + newpa + "</p>";
                            DataAccess.DataAccess.Log_ResetPass_Vendor_add(Session["uid"].ToString(), "Old:" + ip_form["old"] + "", newpa, chuoi, "DoiMatKhau");
                        }
                        catch (Exception)
                        { }
                        
                        if (upPass.userName == null)
                        {
                            @Session["errc"] = "Mật khẩu hoặc tên đăng nhập không đúng!";
                            return View();
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        #endregion
                    }
                    else
                    {
                        #region Đổi mật khẩu NCC Theo Phòng Ban
                        var Us_exist = DataAccess.DataAccess.BBM_MP_VendorTool_Department_User_get(Session["Admin"].ToString(), DataAccess.DataAccess.MD5Hash(old));
                        if (Us_exist.userName == null)
                        {
                            @Session["errc"] = "Mật khẩu cũ không đúng!";
                            return View();
                        }

                        var passEn = DataAccess.DataAccess.MD5Hash(newpa);
                        var upPass = DataAccess.DataAccess.BBM_MP_VendorTool_Change_pass_PhongBan(new user_Item { userName = Session["Admin"].ToString(), password = DataAccess.DataAccess.MD5Hash(newpa) });
                        try
                        {
                            string chuoi = "";
                            chuoi += "<p>Pass Old:" + ip_form["old"] + "</p>";
                            chuoi += "<p>Pass New:" + newpa + "</p>";
                            DataAccess.DataAccess.Log_ResetPass_Vendor_add(Session["Admin"].ToString(), "Old:" + ip_form["old"] + "", newpa, chuoi, "DoiMatKhau_PB");
                        }
                        catch (Exception)
                        { }

                        if (upPass.userName == null)
                        {
                            @Session["errc"] = "Mật khẩu hoặc tên đăng nhập không đúng!";
                            return View();
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        #endregion
                    }
                }
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AccountController_ChangePassword");
                @Session["errc"] = "Mật khẩu hoặc tên đăng nhập không đúng!";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInfoUser(FormCollection ip_form)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    string Type = ip_form["Type"];
                    string newpa = ip_form["password"];
                    string re_newpa = ip_form["passwordNew"];

                    ViewBag.Type = Type;
                    ViewBag.password = newpa;
                    ViewBag.passwordNew = re_newpa;

                    if (string.IsNullOrEmpty(Type) || string.IsNullOrEmpty(newpa) || string.IsNullOrEmpty(re_newpa))
                    {
                        @Session["errif"] = "Vui lòng điền đầy đủ thông tin trên from";
                        return View();
                    }

                    if (newpa != re_newpa)
                    {
                        @Session["errif"] = "Mật khẩu mới không trùng nhau!";
                        return View();
                    }
                    if (newpa.Length <= 8)
                    {
                        @Session["errif"] = "Mật khẩu bao gồm 8 ký tự!";
                        return View();
                    }
                    else if (!RegularExpressionsPassword(newpa.Trim()) == true)
                    {
                        @Session["errif"] = "Mật khẩu phải gồm có ký tự từ a đến z và các số từ 0 đến 9";
                        return View();
                    }
                    var passEn = DataAccess.DataAccess.MD5Hash(newpa);
                    var Us_exist = DataAccess.DataAccess.Vender_User_Department_get(Session["uid"].ToString(), Type, passEn, newpa);
                    if (Us_exist.userName != null)
                    {
                        // @Session["errif"] = "Tài khoản này đã tồn tại. vui lòng kiểm tra lại!";
                        @Session["errif"] = "Đã cập nhật mật khẩu mới theo phòng ban.";
                        return View();
                    }

                    // SUBSTRING(BBM_Code,5, 10) AS BBM_Codesa,BBM_Code

                    var upPass = DataAccess.DataAccess.Create_Vender_User_Department(Session["uid"].ToString(), passEn, newpa, Type);

                    @Session["errif"] = "Thêm mới thành công.";
                    ViewBag.Type = "";
                    ViewBag.password = "";
                    ViewBag.passwordNew = "";
                    return View();

                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                @Session["errif"] = "Mật khẩu hoặc tên đăng nhập không đúng!";
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult SetCssMenu()
        {
            if (Session["SetCssMenu"] != null && Session["SetCssMenu"].ToString().Length > 0)
            {
                Session["SetCssMenu"] = Session["SetCssMenu"].ToString().Contains("sidebar-mini") ? "fixed-navbar has-animation MenuTo" : "fixed-navbar has-animation sidebar-mini MenuCon";
            }
            else
            {
                Session["SetCssMenu"] = "fixed-navbar has-animation MenuTo";
            }
            return Json(new { code = 0 });
        }

    }
}