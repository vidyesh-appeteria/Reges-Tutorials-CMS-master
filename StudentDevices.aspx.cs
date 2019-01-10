using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class StudentDevices : System.Web.UI.Page
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
             ((MasterPg) this.Master).title= "Student Devices";
            DatabaseHelper db = new DatabaseHelper();
            gvStudents.DataSource = db.ExecuteDataSet("device_info_count", CommandType.StoredProcedure);
            gvStudents.DataBind();

        }


    }

    protected void gvQuestionsLikes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@user_id", e.CommandArgument.ToString());

            gvStudentDevices.DataSource = db.ExecuteDataSet("select Model,Brand, Serial[Serial No], device_id[Device ID], convert(varchar(17),activated_on,113) [Activated On]  from device_info where user_id=@user_id order by 	activated_on desc");
            gvStudentDevices.DataBind();
            foreach (GridViewRow gr in gvStudents.Rows)
            {
                gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

            }
            ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;
        }
    }


}