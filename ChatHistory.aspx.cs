using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class ChatHistory : System.Web.UI.Page
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
             ((MasterPg) this.Master).title= "Chats";
            DatabaseHelper db = new DatabaseHelper();
            gvChatHistory.DataSource = db.ExecuteDataSet("get_chat_history_all", CommandType.StoredProcedure);
            gvChatHistory.DataBind();

        }


    }

    protected void gvQuestionsLikes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@queueid", e.CommandArgument.ToString());

            gvChatMessages.DataSource = db.ExecuteDataSet("get_chats_cms", CommandType.StoredProcedure);
            gvChatMessages.DataBind();
            foreach (GridViewRow gr in gvChatHistory.Rows)
            {
                gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

            }
            ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;
        }
    }


}