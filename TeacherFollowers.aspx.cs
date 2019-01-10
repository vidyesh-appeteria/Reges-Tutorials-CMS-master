using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class TeacherFollowers : System.Web.UI.Page
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
            ((MasterPg)this.Master).title = "Teacher Followers";
            DatabaseHelper db = new DatabaseHelper();
gvTeacherFollowers.DataSource = db.ExecuteDataSet("select u.userid, u.fullname [Name], u.Mobile, u.Email, count(*) Followers from TeacherFollowers f inner join usermaster u on u.userid=f.user_id group by u.fullname, u.mobile, u.userid, u.email order by Followers desc");
            gvTeacherFollowers.DataBind();

        }


    }

    protected void gvTeacherFollowers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@userid", e.CommandArgument.ToString());

            gvFollowers.DataSource = db.ExecuteDataSet("select u.fullname [name], Mobile, Email from TeacherFollowers c inner join usermaster u on c.followed_by= u.userid where c.user_id=@userid");
            gvFollowers.DataBind();
            foreach (GridViewRow gr in gvTeacherFollowers.Rows)
            {
                gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

            }
            ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;
        }
    }
}