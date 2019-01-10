using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class branchmaster : System.Web.UI.Page
{
    DatabaseHelper db = new DatabaseHelper();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        
        if (Request.Cookies["Theme"] != null)
            this.Theme = Request.Cookies["Theme"].Value;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMsg.Text = string.Empty;
        if (!IsPostBack)
        {
            FillGrid();
            FillTrashGrid(true, false);
        }
        lblErrorMsg.Text = "";
    }
    public void FillGrid()
    {



        db.AddParameter("@Mode", "Get");

        DataSet ds = db.ExecuteDataSet("Save_Edit_Delete_BranchMaster", CommandType.StoredProcedure);

        gvBranch.DataSource = ds;
        gvBranch.DataBind();

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        db.AddParameter("@branch_name", txtBranchName.Text);
        db.AddParameter("@address", txtAddress.Text);
        db.AddParameter("@contact_primary",txtContactPrimary.Text );
        db.AddParameter("@contact_secondary", txtContactSecondary.Text);
        db.AddParameter("@latitude", txtLatitude.Text);
        db.AddParameter("@longitude", txtLongitude.Text);
        db.AddParameter("@Mode", "Insert");
       
        db.ExecuteNonQuery("Save_Edit_Delete_BranchMaster", CommandType.StoredProcedure);
        txtAddress.Text = "";
        txtBranchName.Text = "";

        txtContactPrimary.Text = "";

        txtContactSecondary.Text = "";

        txtLatitude.Text = "";

        txtLongitude.Text = "";

        lblErrorMsg.Text = "Subject Saved Successfully.";
        //footer.Visible = true;
        FillGrid();

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtAddress.Text = "";
        txtBranchName.Text = "";

        txtContactPrimary.Text = "";

        txtContactSecondary.Text = "";

        txtLatitude.Text = "";

        txtLongitude.Text = "";


    }

    protected void gvBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBranch.PageIndex = e.NewPageIndex;
        gvBranch.DataBind();
        FillGrid();


    }

    protected void gvBranch_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridViewRow row = gvBranch.Rows[e.RowIndex];
        TextBox txtBranch = (TextBox)gvBranch.Rows[e.RowIndex].FindControl("txtBranch");
        TextBox txtBranchAddress = (TextBox)gvBranch.Rows[e.RowIndex].FindControl("txtBranchAddress");
        TextBox txtBranchContactPrimary = (TextBox)gvBranch.Rows[e.RowIndex].FindControl("txtBranchContactPrimary");
        TextBox txtBranchContactSecondary = (TextBox)gvBranch.Rows[e.RowIndex].FindControl("txtBranchContactSecondary");
        TextBox txtBranchLatitude = (TextBox)gvBranch.Rows[e.RowIndex].FindControl("txtBranchLatitude");
        TextBox txtBranchLongitude = (TextBox)gvBranch.Rows[e.RowIndex].FindControl("txtBranchLongitude");

        HiddenField hdnmID = (HiddenField)gvBranch.Rows[e.RowIndex].FindControl("hdnBranchid");
        db.AddParameter("@branch_name", txtBranch.Text);
        db.AddParameter("@branch_id", hdnmID.Value);
        db.AddParameter("@address", txtBranchAddress.Text);
        db.AddParameter("@contact_primary", txtBranchContactPrimary.Text);
        db.AddParameter("@contact_secondary", txtBranchContactSecondary.Text);
        db.AddParameter("@latitude", txtBranchLatitude.Text);
        db.AddParameter("@longitude", txtBranchLongitude.Text);
        db.AddParameter("@Mode", "Update");

        db.ExecuteNonQuery("Save_Edit_Delete_BranchMaster", CommandType.StoredProcedure);

        lblErrorMsg.Text = "Updated Successfully.";
        //displayError();
        gvBranch.EditIndex = -1;

        FillGrid();
        FillTrashGrid(true, false);


    }

    protected void gvBranch_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        gvBranch.EditIndex = -1;
        FillGrid();

    }

    protected void gvBranch_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hdnmID = (HiddenField)gvBranch.Rows[e.RowIndex].FindControl("hdnBranchid");

        db.AddParameter("@branch_id", hdnmID.Value);
        db.AddParameter("@Mode", "Delete");

        db.ExecuteNonQuery("Save_Edit_Delete_BranchMaster", CommandType.StoredProcedure);
        lblErrorMsg.Text = "Deleted Successfully.";
        //displayError();
        FillGrid();

    }

    protected void gvBranch_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvBranch.EditIndex = e.NewEditIndex;

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
            gvBranchTrash.DataSource = null;
            gvBranchTrash.DataBind();
        }
        else
        {
            lnkTrash.Text = "Close";
            lnkTrash.CssClass = "";
            dvMain.Visible = false;
            FillTrashGrid(false, true);
        }

    }
    private void FillTrashGrid(bool showCount, bool showGrid)
    {

        DatabaseHelper db = new DatabaseHelper();
        DataSet ds = db.ExecuteDataSet("select * from branchmaster where active=0");

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (showCount)
            {
                lnkTrash.Visible = true;
                lnkTrash.Text = " Trash (" + ds.Tables[0].Rows.Count + ")";
            }

        }
        else
        {
            lnkTrash.Visible = false;
            dvMain.Visible = true;
        }

        if (showGrid)
        {
            gvBranchTrash.DataSource = ds;
            gvBranchTrash.DataBind();
        }
    }



   protected void gvBranchTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@branch_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update branchmaster set active=1 where branch_id=@branch_id", CommandType.Text);


            FillGrid();
            FillTrashGrid(false, true);
        }
    }

 
}