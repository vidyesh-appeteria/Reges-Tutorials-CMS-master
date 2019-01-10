using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class TeacherAnswers : System.Web.UI.Page
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
            ((MasterPg) this.Master).title= "Answers by Teachers";
            DatabaseHelper db = new DatabaseHelper();
            gvTeacherAnswers.DataSource = db.ExecuteDataSet("list_AnswersByTeacher", CommandType.StoredProcedure);
            gvTeacherAnswers.DataBind();

        }


    }

    protected void gvTeacherAnswers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@userid", e.CommandArgument.ToString());
            gvAnswers.DataSource = db.ExecuteDataSet(" select q.question, a.answer from Answers a inner join Questions q on a.question_id=q.question_id where a.solved_by=@userid");
            gvAnswers.DataBind();
            foreach (GridViewRow gr in gvTeacherAnswers.Rows)
            {
                gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

            }
            ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;
        }
    }


 
}