using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class Earning : System.Web.UI.Page
{
    DatabaseHelper db = new DatabaseHelper();
      protected void Page_PreInit(object sender, EventArgs e)
    {
        //if (Session["Theme"] != null)
        //    this.Theme = Session["Theme"].ToString();
        if (Request.Cookies["Theme"] != null)
            this.Theme = Request.Cookies["Theme"].Value;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillStatus();

            GetData();
               ((MasterPg) this.Master).title= "User Transactions";
        }
    }



    private void FillStatus()
    {
        DataSet ds = db.ExecuteDataSet("select distinct transaction_status from Usertransactions");
        ddlStatus.DataSource = ds;
        ddlStatus.DataValueField = "transaction_status";
        ddlStatus.DataTextField = "transaction_status";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, new ListItem("All", ""));

    }
    private void GetData()
    {
        DatabaseHelper db = new DatabaseHelper();
        db.AddParameter("@name", txtName.Text);
        db.AddParameter("@status", ddlStatus.SelectedValue);
        gvEarning.DataSource = db.ExecuteDataSet("getEarning", CommandType.StoredProcedure);
        gvEarning.DataBind();
        lblError.Text = gvEarning.Rows.Count + " records found";
    }





    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetData();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtName.Text = string.Empty;
        ddlStatus.SelectedIndex = 0;
        GetData();
    }

    protected void gvEarning_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[5].Text.Trim() == "Failed")
        {
            e.Row.Cells[5].BackColor = System.Drawing.Color.OrangeRed;
        }
        else if (e.Row.Cells[5].Text.Trim() == "InProgress")
        {
            e.Row.Cells[5].BackColor = System.Drawing.Color.Yellow;
        }
        else if (e.Row.Cells[5].Text.Trim() == "Complete")
        {
            e.Row.Cells[5].BackColor = System.Drawing.Color.LightGreen;
        }

    }
}
