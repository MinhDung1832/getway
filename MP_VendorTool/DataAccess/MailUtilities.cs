using System;
using System.Text;
using System.Net;
using System.Web;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Net.Mail;
using System.IO;

public class MailUtilities
{
    public static void SendMail(string to, string title, string body)
    {
        String sendername = ConfigurationManager.AppSettings.Get("Fromname");
        String email = ConfigurationManager.AppSettings.Get("Email");
        String password = ConfigurationManager.AppSettings.Get("Password");
        int port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Port"));
        String host = ConfigurationManager.AppSettings.Get("Host");

        MailMessage message = new MailMessage();
        MailAddress address = new MailAddress(email, sendername);
        message.From = address;
        MailAddress item = new MailAddress(to);
        message.To.Add(item);
        message.Subject = title;
        message.Body = body;
        message.Priority = MailPriority.Normal;
        message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient();
        NetworkCredential credential = new NetworkCredential();
        credential.UserName = email;
        credential.Password = password;
        client.Credentials = credential;
        client.EnableSsl = true;
        client.Host = host;
        client.Port = port;
        client.Send(message);

    }
}





