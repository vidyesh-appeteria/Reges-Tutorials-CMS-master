using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class Questions : System.Web.UI.Page
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
            getData();
        }
    }

    private void getData()
    {
        ((MasterPg)this.Master).title = "All Questions";
        DatabaseHelper db = new DatabaseHelper();
        gvQuestions.DataSource = db.ExecuteDataSet("list_Questions", CommandType.StoredProcedure);
        gvQuestions.DataBind();
      
    }
    protected void gvQuestionsLikes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();
        if (e.CommandName == "VIEW")
        {
          
            db.AddParameter("@question_id", e.CommandArgument.ToString());
gvAnswers.DataSource = db.ExecuteDataSet("select  c.answer_id, c.answer, u.fullname , Mobile, Email  from Answers c inner join usermaster u on c.solved_by= u.userid where c.active=1 and c.question_id=@question_id");
            gvAnswers.DataBind();
            foreach (GridViewRow gr in gvQuestions.Rows)
            {
                gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

            }
            ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;
        }
        if (e.CommandName == "DEL")
        {
            db.AddParameter("@question_id", e.CommandArgument.ToString());
            db.ExecuteScalar("update questions set active=0 where question_id=@question_id");
            getData();
          
        }
        }



    protected void gvAnswers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //DatabaseHelper db = new DatabaseHelper();
        //if (e.CommandName == "DEL")
        //{
        //    db.AddParameter("@answer_id", e.CommandArgument.ToString());
        //    db.ExecuteScalar("update answers set active=0 where answer_id=@answer_id");
        //    getData();
        //    gvAnswers.DataSource = null;
        //    gvAnswers.DataBind();
        //}
    }
}