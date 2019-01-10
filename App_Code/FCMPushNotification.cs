using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using DAL.SQLDataAccess;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;


/// <summary>
/// Summary description for FCMPushNotification
/// </summary>
public class FCMPushNotification
{
    public FCMPushNotification()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Successful
    {
        get;
        set;
    }

    public string Response
    {
        get;
        set;
    }
    public Exception Error
    {
        get;
        set;
    }
    public void RemoveNotification(string user_id, int id, string type, int action_user_id)
    {
        DatabaseHelper db = new DatabaseHelper();
        //db.AddParameter("@device_token", _device_id);
        //string user_id = Convert.ToString(db.ExecuteScalar("select userid from usermaster where device_token=@device_token"));

        db.AddParameter("@institute_id", 1);
        db.AddParameter("@notification_type", type);
        db.AddParameter("@user_id", user_id);
        db.AddParameter("@reference_id", id);
        db.AddParameter("@action_user_id", action_user_id);
        db.ExecuteNonQuery("remove_notification", System.Data.CommandType.StoredProcedure);

    }
    public FCMPushNotification SendNotification(string _title, string _message, string _topic, string _device_id, int id, string question, string target, string type, int action_user_id)
    {
        FCMPushNotification result = new FCMPushNotification();
        try
        {
          
                DatabaseHelper db = new DatabaseHelper();
                db.AddParameter("@device_token", _device_id);
                string user_id = Convert.ToString(db.ExecuteScalar("select userid from usermaster where device_token=@device_token"));

                db.AddParameter("@institute_id", 1);
                db.AddParameter("@notification", _message);
                db.AddParameter("@notification_type", type);
                db.AddParameter("@user_id", user_id);
                db.AddParameter("@reference_id", id);
                db.AddParameter("@action_user_id", action_user_id);
                db.ExecuteNonQuery("save_notification", System.Data.CommandType.StoredProcedure);
           

            result.Successful = true;
            result.Error = null;
            // var value = message;
            var requestUri = "https://fcm.googleapis.com/fcm/send";

            WebRequest webRequest = WebRequest.Create(requestUri);
            webRequest.Method = "POST";

            webRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAA_HaR5nk:APA91bHV7qGoDCX66QB5zvy6Ry93LFnAhXIIax1LVdpMRhITO5u6oKUWycpPnM8BddFbGjKhKWuDtQKYPb-ya88bg7TP3iIRpbEg8i6OjssODy5TmDDWCv_LlZzJW6bpA6WapuVQ7GTv"));
            webRequest.Headers.Add(string.Format("Sender: id={0}", "1084321031801"));
            webRequest.ContentType = "application/json";

            if (_message.Contains("https://firebasestorage"))
            {
                if (_message.Contains(".jpg"))
                    _message = "New Image";
                else if (_message.Contains(".mp4"))
                    _message = "New Video";
            }

            var data = new
            {
                to = _device_id, // Uncoment this if you want to test for single device
                                 //to = "/topics/" + _topic, // this is for topic 
                notification = new
                {
                    title = _title,
                    body = _message,
                    click_action = target,
                    sound = "default",
                    icon = "myicon"

                },
                data = new
                {
                    id = id,
                    question = question,
                    type = type
                }
            };
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(data);

            Byte[] byteArray = Encoding.UTF8.GetBytes(json);

            webRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = webRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);

                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = webResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            result.Response = sResponseFromServer;

                            //{ "multicast_id":8963785532865370122,"success":0,"failure":1,"canonical_ids":0,"results":[{"error":"InvalidRegistration"}]}
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            result.Successful = false;
            result.Response = null;
            result.Error = ex;
        }
        return result;
    }
    public FCMPushNotification SendNotificationToTopic(string _title, string _message, string _topic, int id, string question, string target, string type)
    {
        FCMPushNotification result = new FCMPushNotification();
        try
        {
            result.Successful = true;
            result.Error = null;
            // var value = message;
            var requestUri = "https://fcm.googleapis.com/fcm/send";

            WebRequest webRequest = WebRequest.Create(requestUri);
            webRequest.Method = "POST";

            webRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAA_HaR5nk:APA91bHV7qGoDCX66QB5zvy6Ry93LFnAhXIIax1LVdpMRhITO5u6oKUWycpPnM8BddFbGjKhKWuDtQKYPb-ya88bg7TP3iIRpbEg8i6OjssODy5TmDDWCv_LlZzJW6bpA6WapuVQ7GTv"));
            webRequest.Headers.Add(string.Format("Sender: id={0}", "1084321031801"));
            webRequest.ContentType = "application/json";


            var data = new
            {
                //to = _device_id, // Uncoment this if you want to test for single device
                to = "/topics/" + _topic, // this is for topic 
                notification = new
                {
                    title = _title,
                    body = _message,
                    click_action = target,
                    sound = "default",
                    icon = "myicon"

                },
                data = new
                {
                    id = id,
                    question = question,
                    type = type
                }
            };
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(data);

            Byte[] byteArray = Encoding.UTF8.GetBytes(json);

            webRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = webRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);

                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = webResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            result.Response = sResponseFromServer;

                            //{ "multicast_id":8963785532865370122,"success":0,"failure":1,"canonical_ids":0,"results":[{"error":"InvalidRegistration"}]}
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            result.Successful = false;
            result.Response = null;
            result.Error = ex;
        }
        return result;
    }
}
