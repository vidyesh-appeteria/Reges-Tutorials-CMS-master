using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for APICall
/// </summary>
public static class APICall
{
    //public static APICall()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public static string makeCall(string apiUrl, object input)
    {
        try
        {
        string inputJson = (new JavaScriptSerializer()).Serialize(input);
        WebClient client = new WebClient();
        client.Headers["Content-type"] = "application/json";
        client.Encoding = Encoding.UTF8;


        //string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("appeteria" + ":" + "appeteria@123"));
        //client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);

        string json = client.UploadString(apiUrl, inputJson);
            return json;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}