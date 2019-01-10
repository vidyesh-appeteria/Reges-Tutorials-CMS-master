using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    public static void SendEmail(string toemail, string subject, string message)
    {
        string fromemail = System.Configuration.ConfigurationManager.AppSettings["fromemail"].ToString();
        //"marathi.lekhmala.app@gmail.com";
        string password = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
        //"@ppeteria369";
        string smtpserver = System.Configuration.ConfigurationManager.AppSettings["smtpserver"].ToString();
        //"smtp.gmail.com";
        int port = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["port"]);
        //587;

        MailMessage MailObj = new MailMessage();
        MailObj.To.Add("appeteria@gmail.com");// toemail);
        MailObj.Bcc.Add("appeteria@gmail.com");
        MailObj.From = new MailAddress(fromemail, fromemail);
        MailObj.IsBodyHtml = true;
        MailObj.Priority = MailPriority.Normal;
        MailObj.Subject = subject;
        MailObj.Body = "<html><body>" + message + "</body></html>";
        SmtpClient smtpcli = new SmtpClient(smtpserver, port);
        // smtpcli.EnableSsl = true;
        smtpcli.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpcli.UseDefaultCredentials = false;
        smtpcli.Credentials = new NetworkCredential(fromemail, password);
        smtpcli.Send(MailObj);
    }
}