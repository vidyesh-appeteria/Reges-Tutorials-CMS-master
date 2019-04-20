using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class Users : System.Web.UI.Page
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
            ((MasterPg)this.Master).title = "List of Users";
            FillGrid();
            FillTrashGrid(true, false);
            FillStandard();
        }
        lblError.Text = "";


    }
    private void FillStandard()
    {
        try
        {
            DatabaseHelper db = new DatabaseHelper();
            DataSet ds = db.ExecuteDataSet("get_serachStd", CommandType.StoredProcedure);
            if (ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlSearchStandard.Items.Add(new ListItem("All", "0"));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlSearchStandard.Items.Add(new ListItem(dr["standard"].ToString(), dr["standard_id"].ToString()));
                }
            }
        }
        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }
    }
    private void FillGrid()
    {
        DatabaseHelper db = new DatabaseHelper();
        db.AddParameter("@user_type", ddlUserType.SelectedValue);
        db.AddParameter("@full_name", txtName.Text);
        db.AddParameter("@standard_id", ddlSearchStandard.SelectedValue);
        db.AddParameter("@active", 1);
        gvUsers.DataSource = db.ExecuteDataSet("getUsers", CommandType.StoredProcedure);
        gvUsers.DataBind();

        lblError.Text = gvUsers.Rows.Count.ToString();
        lblError.Text += ddlUserType.SelectedIndex == 0 ? " User" : " " + ddlUserType.SelectedItem.Text;
        lblError.Text += gvUsers.Rows.Count > 1 ? "s" : "";
    }

    private void FillTrashGrid(bool showCount, bool showGrid)
    {

        DatabaseHelper db = new DatabaseHelper();
        db.AddParameter("@user_type", ddlUserType.SelectedValue);
        db.AddParameter("@full_name", txtName.Text);
        db.AddParameter("@active", 0);
        DataSet ds = db.ExecuteDataSet("getUsers", CommandType.StoredProcedure);

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (showCount)
            {
                lnkTrash.Visible = true;
                lnkTrash.Text = " Trash (" + ds.Tables[0].Rows.Count + ")";
                pnlTrash.Visible = false;
            }

        }
        else
        {
            lnkTrash.Visible = false;
            dvMain.Visible = true;
            pnlTrash.Visible = false;
        }

        if (showGrid)
        {
            gvUsersTrash.DataSource = ds;
            gvUsersTrash.DataBind();
            pnlTrash.Visible = true;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGrid();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtName.Text = string.Empty;
        ddlUserType.SelectedIndex = 0;
        ddlSearchStandard.SelectedIndex = 0;
        FillGrid();
    }

    protected void lnkTrash_Click(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();
        if (lnkTrash.Text == "Close")
        {
            dvMain.Visible = true;
            FillGrid();
            FillTrashGrid(true, false);
            gvUsersTrash.DataSource = null;
            gvUsersTrash.DataBind();


        }
        else
        {
            lnkTrash.Text = "Close";
            lnkTrash.CssClass = "";
            dvMain.Visible = false;
            FillTrashGrid(false, true);
        }
    }

    protected void gvUsersTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {

            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@user_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update user_master set Active=1 where user_id=@user_id", CommandType.Text);

            FillGrid();
            FillTrashGrid(false, true);


        }
    }

    protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "EDT")
        {
            Response.Redirect("UserMaster.aspx?uid=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName.ToString() == "DEL")
        {

            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@user_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update user_master set Active=0 where user_id=@user_id", CommandType.Text);

            FillGrid();
            FillTrashGrid(true, false);


        }
    }
}