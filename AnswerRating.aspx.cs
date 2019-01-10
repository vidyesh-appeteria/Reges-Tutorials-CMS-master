using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class AnswerRating : System.Web.UI.Page
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
             ((MasterPg) this.Master).title= "Highly Rated Answers";
            DatabaseHelper db = new DatabaseHelper();
gvAnswerRating.DataSource = db.ExecuteDataSet("list_AnswerRating", CommandType.StoredProcedure);
            gvAnswerRating.DataBind();

        }


    }
    
    protected void gvQuestionsLikes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@answer_id", e.CommandArgument.ToString());

            gvRatedBy.DataSource = db.ExecuteDataSet("select u.fullname [name], Mobile, Email,c.rating from AnswerRating c inner join usermaster u on c.rated_by= u.userid where c.answer_id=@answer_id and c.active=1");
            gvRatedBy.DataBind();
            foreach (GridViewRow gr in gvAnswerRating.Rows)
            {
                gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

            }
            ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;
        }
    }

    
}