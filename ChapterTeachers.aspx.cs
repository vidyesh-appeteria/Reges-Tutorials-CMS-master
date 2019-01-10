using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class ChapterTeachers : System.Web.UI.Page
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
             ((MasterPg) this.Master).title= "Teachers for Chapters";
            DatabaseHelper db = new DatabaseHelper();
gvChapterTeachers.DataSource = db.ExecuteDataSet("list_ChapterTeacher",CommandType.StoredProcedure);
            gvChapterTeachers.DataBind();

        }


    }
    
    protected void gvChapterTeachers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@chapter_id", e.CommandArgument.ToString());

            gvTeachers.DataSource = db.ExecuteDataSet("select u.fullname [name], Mobile, Email from ChapterTeacher c inner join usermaster u on c.user_id= u.userid where c.chapter_id=@chapter_id");
            gvTeachers.DataBind();
            foreach (GridViewRow gr in gvChapterTeachers.Rows)
            {
                gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

            }
            ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;
        }
    }
}