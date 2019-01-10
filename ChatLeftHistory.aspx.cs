using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class ChatLeftHistory : System.Web.UI.Page
{
     protected void Page_PreInit(object sender, EventArgs e)
    {
     
        if (Request.Cookies["Theme"] != null)
            this.Theme = Request.Cookies["Theme"].Value;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             ((MasterPg) this.Master).title= "Chat Left History";
            DatabaseHelper db = new DatabaseHelper();
            gvChatLeftHistory.DataSource = db.ExecuteDataSet("select substring(convert(varchar, start_time, 106), 4, 8)[Month], count(queue_id)[Count] from chat_history where reason = 'Queue Left' group by substring(convert(varchar, start_time, 106), 4, 8)");
            gvChatLeftHistory.DataBind();

        }


    }

    protected void gvQuestionsLikes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@month", e.CommandArgument.ToString());

            gvChatLeftList.DataSource = db.ExecuteDataSet("get_chat_leave_history",CommandType.StoredProcedure);
            gvChatLeftList.DataBind();
            foreach (GridViewRow gr in gvChatLeftHistory.Rows)
            {
                gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

            }
            ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;
        }
    }


}