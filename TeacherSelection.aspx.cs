using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class TeacherSelection : System.Web.UI.Page
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
            GetData();
            ((MasterPg)this.Master).title = "Teacher Selection";
        }


    }
    private void GetData()
    {
        DatabaseHelper db = new DatabaseHelper();
        gvTeacherSelection.DataSource = db.ExecuteDataSet("GetTeacherForSelection", CommandType.StoredProcedure);
        gvTeacherSelection.DataBind();
    }

    protected void gvTeacherSelection_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ACTIVATE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@userid", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update usermaster set active=1 where userid=@userid");

            db.AddParameter("@userid", e.CommandArgument.ToString());
            string email = Convert.ToString( db.ExecuteScalar("select email from usermaster where userid=@userid"));
            string mail_body = File.ReadAllText(HttpContext.Current.Server.MapPath("~/") + @"/templates/welcome_email.txt");
            
            Common.SendEmail("joysoncardoza50@gmail.com", "Welcome to Hence Proved", mail_body);
            GetData();
        }
    }

}