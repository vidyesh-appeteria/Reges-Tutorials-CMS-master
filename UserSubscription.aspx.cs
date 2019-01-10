using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class UserSubscription : System.Web.UI.Page
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
        }


    }
    private void GetData()
    {
        DatabaseHelper db = new DatabaseHelper();
        db.AddParameter("@mobile", txtMobile.Text);
        db.AddParameter("@fullname", txtName.Text);
        gvUsers.DataSource = db.ExecuteDataSet("getUserSubscriptions", CommandType.StoredProcedure);
        gvUsers.DataBind();
        ((MasterPg)this.Master).title = "User Subscriptions";
        lblError.Text = gvUsers.Rows.Count.ToString() + " Student";        
        lblError.Text += gvUsers.Rows.Count > 1 ? "s" : "";

        foreach (GridViewRow gr in gvUsers.Rows)
        {

            gr.BackColor = System.Drawing.Color.White;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetData();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtName.Text = string.Empty;
        txtMobile.Text = string.Empty;
        GetData();
    }

    protected void btnRenew_Click(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();
        
        db.AddParameter("@user_id", hdnUserID.Value);
        db.AddParameter("@days", txtDays.Text);
        db.ExecuteNonQuery("Update_User_subscription", CommandType.StoredProcedure);
        GetData();
        clear();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
    }

    private void clear()
    {
        hdnUserID.Value = "0";
        txtDays.Text = string.Empty;
        pnlRenew.Visible = false;
        foreach (GridViewRow gr in gvUsers.Rows)
        {

            gr.BackColor = System.Drawing.Color.White;
        }
    }
    protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        hdnUserID.Value = e.CommandArgument.ToString();
        GridViewRow selectedRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
        int RowIndexx = Convert.ToInt32(selectedRow.RowIndex);

        gvUsers.Rows[RowIndexx].BackColor = System.Drawing.Color.Yellow;

        pnlRenew.Visible = true;
        
    }

   
}