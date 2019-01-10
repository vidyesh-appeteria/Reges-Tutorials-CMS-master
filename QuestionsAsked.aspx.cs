using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class QuestionsAsked : System.Web.UI.Page
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
            ((MasterPg)this.Master).title = "Quetions Asked by Users";
            DatabaseHelper db = new DatabaseHelper();
gvQuestionsAsked.DataSource = db.ExecuteDataSet("list_QuestionsAsked", CommandType.StoredProcedure);
            gvQuestionsAsked.DataBind();

        }


    }
   
    protected void gvQuestionsAsked_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@user_id", e.CommandArgument.ToString());
            gvQuestions.DataSource = db.ExecuteDataSet("select Question,tags, convert(varchar(17), raised_on, 113)[Raised On] from Questions where raised_by=@user_id order by raised_on desc");
            gvQuestions.DataBind();
            foreach (GridViewRow gr in gvQuestionsAsked.Rows)
            {
                gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

            }
          ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;
        }
    }
}