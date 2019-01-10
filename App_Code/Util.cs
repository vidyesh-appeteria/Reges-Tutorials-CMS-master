using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Drawing;
using System.Xml;

using System.Web;
//using Telerik.Web.UI;
using System.ComponentModel;
using System.Collections.Generic;
using System.Dynamic;
using System.Collections.Specialized;
using DAL.SQLDataAccess;

public class Util
{
    DatabaseHelper db = new DatabaseHelper();


    public Util()
    {

    }
   public static void FillDropDown(DropDownList cbo, string ssql, string DataTextField, string DataValueField, DatabaseHelper db)
    {
        DataSet ds = db.ExecuteDataSet(ssql,CommandType.Text);
        cbo.DataTextField = DataTextField;
        cbo.DataValueField = DataValueField;
        cbo.DataSource = ds;
        cbo.DataBind();
        cbo.Items.Insert(0, "Select----->");
        cbo.Items[0].Value = "0";
        //reader.Close();
    }

    public static void FillDropDownAll(DropDownList cbo, string ssql, string DataTextField, string DataValueField, DatabaseHelper db)
    {
        DataSet ds = db.ExecuteDataSet(ssql, CommandType.Text);
        cbo.DataTextField = DataTextField;
        cbo.DataValueField = DataValueField;
        cbo.DataSource = ds;
        cbo.DataBind();
        cbo.Items.Insert(0, "All");
        cbo.Items[0].Value = "0";
        //reader.Close();
    }

    public static void FillDropDownByDefault(DropDownList cbo, string ssql, string DataTextField, string DataValueField, DatabaseHelper db)
    {
            DataSet ds = db.ExecuteDataSet(ssql,CommandType.Text);
    cbo.DataTextField = DataTextField;
        cbo.DataValueField = DataValueField;
        cbo.DataSource = ds;
        cbo.DataBind();
//reader.Close();
    }
    public static string sendSMS(string msg, string number)
    {
        String message = HttpUtility.UrlEncode(msg);
        using (var wb = new WebClient())
        {
            byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "<replace KEY>"},
                {"numbers" , "91" + "9920393933" },//number},
                { "message" , msg},
                {"sender" , "SENDER"}
                });
            string result = System.Text.Encoding.UTF8.GetString(response);
            return result;
        }
    }
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
        MailObj.To.Add(new MailAddress("appeteria@gmail.com"));// toemail));
        MailObj.Bcc.Add(new MailAddress("appeteria@gmail.com"));
        MailObj.Bcc.Add(new MailAddress("prasad.appeteria@gmail.com"));
        MailObj.From = new MailAddress(fromemail);
        MailObj.IsBodyHtml = true;
        MailObj.Priority = MailPriority.Normal;
        MailObj.Subject = subject;
        MailObj.Body = message ;
        SmtpClient smtpcli = new SmtpClient(smtpserver, port);
        // smtpcli.EnableSsl = true;
        smtpcli.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpcli.UseDefaultCredentials = false;
        smtpcli.Credentials = new NetworkCredential(fromemail, password);
        smtpcli.Send(MailObj);
    }

    public static void HandleError(string msg, Label lblError, bool unexpected)
    {
        if(unexpected)
        lblError.Text = "Something went wrong : " + msg;
        else
            lblError.Text = msg;
    }

    public static bool CheckImage(string url)
    {
        HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse httpRes = null;
        try
        {
            httpRes = (HttpWebResponse)httpReq.GetResponse(); // Error 404 right here,
            if (httpRes.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
        }
        catch (WebException wec)
        {
            return false;
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            // Close the response.
            if(httpRes!=null)
            httpRes.Close();
        }
        return true;
    }

}