using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            getData();
             ((MasterPg) this.Master).title= "Teacher Earning";
        }


    }
    private void getData()
    {
        DatabaseHelper db = new DatabaseHelper();
        gvTeacherEarning.DataSource = db.ExecuteDataSet("list_TeacherEarning", CommandType.StoredProcedure);
        gvTeacherEarning.DataBind();
    }
    protected void gvTeacherEarning_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        foreach (GridViewRow gr in gvTeacherEarning.Rows)
        {
            gr.BackColor = System.Drawing.Color.FromName("#E5E3F1");

        }
        DatabaseHelper db = new DatabaseHelper();

        if (e.CommandName == "VIEW")
        {

            ((GridViewRow)((LinkButton)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;

            db.AddParameter("@user_id", e.CommandArgument.ToString());
            gvRatings.DataSource = db.ExecuteDataSet("list_TeacherRating", CommandType.StoredProcedure);
            gvRatings.DataBind();
            gvPaymetns.Visible = false;
            gvRatings.Visible = true;
        }
        if (e.CommandName == "PAYMENT")
        {

            ((GridViewRow)((LinkButton)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;

            db.AddParameter("@user_id", e.CommandArgument.ToString());
            gvPaymetns.DataSource = db.ExecuteDataSet("select  convert(varchar(17), payment_date, 113) [Payment Date],payment_amount [Payment Amount] from TeacherPayments where user_id = @user_id");
            gvPaymetns.DataBind();
            gvPaymetns.Visible = true;
            gvRatings.Visible = false;
        }
        if (e.CommandName == "PAID")
        {
            ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).BackColor = System.Drawing.Color.Teal;

            db.AddParameter("@user_id", e.CommandArgument.ToString());
            db.ExecuteScalar("makepayment", CommandType.StoredProcedure);
            getData();
        }
    }


}