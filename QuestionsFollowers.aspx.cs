using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class QuestionsFollowers : System.Web.UI.Page
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
             ((MasterPg) this.Master).title= "Question Followers";
            DatabaseHelper db = new DatabaseHelper();
            gvQuestionsFollowers.DataSource = db.ExecuteDataSet("list_QuestionsFollowers", CommandType.StoredProcedure);
            gvQuestionsFollowers.DataBind();

        }


    }

    protected void gvQuestionsLikes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@question_id", e.CommandArgument.ToString());

            gvFollowers.DataSource = db.ExecuteDataSet("select u.fullname [Name], Mobile, Email from QuestionsFollowers c inner join usermaster u on c.followed_by= u.userid where c.question_id=@question_id");
            gvFollowers.DataBind();
            foreach (GridViewRow gr in gvQuestionsFollowers.Rows)
            {
                gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

            }
            ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;
        }
    }


}