using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class Attendance : System.Web.UI.Page
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
             ((MasterPg) this.Master).title= "Attendance";
            DatabaseHelper db = new DatabaseHelper();
            Util.FillDropDown(ddlBatch, "exec get_batches_for_ddl", "batch_name", "batch_id", db);

        }


    }

    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        getAttendance();

    }

    private void getAttendance()
    {
        DatabaseHelper db = new DatabaseHelper();
        db.AddParameter("@absent_date", txtDate.Text);
        db.AddParameter("@batch_id", ddlBatch.SelectedValue);
        gvAttendance.DataSource = db.ExecuteDataSet("get_attendance", CommandType.StoredProcedure);
        gvAttendance.DataBind();
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        getAttendance();
    }

    protected void gvAttendance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ABSENT")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@absent_date", txtDate.Text);
            db.AddParameter("@user_id", e.CommandArgument.ToString());
            db.AddParameter("@remarks", "");
            db.AddParameter("@modified_by", Session["UserId"]);
            db.ExecuteScalar("mark_attendance", CommandType.StoredProcedure);
            getAttendance();
        }
        else if (e.CommandName == "PRESENT")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@absent_date", txtDate.Text);
            db.AddParameter("@user_id", e.CommandArgument.ToString());
            db.ExecuteScalar("unmark_attendance", CommandType.StoredProcedure);
            getAttendance();
        }
    }
}