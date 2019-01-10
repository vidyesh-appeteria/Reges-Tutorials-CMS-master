using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MediumMaster : System.Web.UI.Page
{
    DatabaseHelper db = new DatabaseHelper();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.Cookies["Theme"] != null)
            this.Theme = Request.Cookies["Theme"].Value;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblErrorMsg.Text = string.Empty;
            if (!IsPostBack)
            {
                FillGrid();
                FillTrashGrid(true, false);
                ((MasterPg)this.Master).title = "Medium Master";
            }
            lblErrorMsg.Text = "";
            lblErrorMsg.Text = "";
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }
    public void FillGrid()
    {
        try
        {
            db.AddParameter("@Mode", "Get");
            db.AddParameter("@createdby", hdnUserid.Value);

            DataSet ds = db.ExecuteDataSet("Save_Edit_Delete_MediumMaster", CommandType.StoredProcedure);

            gvMedium.DataSource = ds;
            gvMedium.DataBind();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvMedium_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvMedium.PageIndex = e.NewPageIndex;
            gvMedium.DataBind();
            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvMedium_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {


            gvMedium.EditIndex = e.NewEditIndex;

            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvMedium_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        gvMedium.EditIndex = -1;
        FillGrid();

    }

    protected void gvMedium_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
           
            TextBox txtMedium = (TextBox)gvMedium.Rows[e.RowIndex].FindControl("txtMedium");
            HiddenField hdnmID = (HiddenField)gvMedium.Rows[e.RowIndex].FindControl("hdnMediumId");
            if (txtMedium.Text == string.Empty)
            {
                lblErrorMsg.Text = "Please enter name of the Medium";
                return;
            }
            db.AddParameter("@medium", txtMedium.Text);
            db.AddParameter("@Medium_id", hdnmID.Value);
            db.AddParameter("@Mode", "Update");
            db.AddParameter("@createdby", hdnUserid.Value);

            db.ExecuteNonQuery("Save_Edit_Delete_MediumMaster", CommandType.StoredProcedure);
            lblErrorMsg.Text = "Updated Successfully.";
            //displayError();
            gvMedium.EditIndex = -1;

            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }
    }

    protected void gvMedium_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            TextBox txtSubject = (TextBox)gvMedium.Rows[e.RowIndex].FindControl("txtMedium");
            HiddenField hdnmID = (HiddenField)gvMedium.Rows[e.RowIndex].FindControl("hdnMediumId");
            db.AddParameter("@Medium_id", hdnmID.Value);
            db.AddParameter("@Mode", "Delete");
            db.AddParameter("@createdby", hdnUserid.Value);

            db.ExecuteNonQuery("Save_Edit_Delete_MediumMaster", CommandType.StoredProcedure);
            lblErrorMsg.Text = "Deleted Successfully.";
            //displayError();
            FillGrid();
            FillTrashGrid(true, false);
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtMedium.Text == string.Empty)
            {
                lblErrorMsg.Text = "Please enter name of the Medium";
                return;
            }
            db.AddParameter("@Medium", txtMedium.Text);
            db.AddParameter("@Mode", "Insert");
            db.AddParameter("@createdby", hdnUserid.Value);

            db.ExecuteNonQuery("Save_Edit_Delete_MediumMaster", CommandType.StoredProcedure);
            txtMedium.Text = "";
            lblErrorMsg.Text = "Meduim Saved Successfully.";
            //footer.Visible = true;
            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtMedium.Text = "";
    }

    protected void lnkTrash_Click(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();
        if (lnkTrash.Text == "Close")
        {
            dvMain.Visible = true;
            FillGrid();
            FillTrashGrid(true, false);
            gvMediumTrash.DataSource = null;
            gvMediumTrash.DataBind();


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
        DataSet ds = db.ExecuteDataSet("select * from Medium_master where active=0 order by Medium");

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
        pnlMediumTrash.Visible = false;
        if (showGrid)
        {
            gvMediumTrash.DataSource = ds;
            gvMediumTrash.DataBind();
            pnlMediumTrash.Visible = gvMediumTrash.Rows.Count > 0;
        }
    }

    protected void gvMediumTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@Medium_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update Medium_master set Active=1 where Medium_id=@Medium_id", CommandType.Text);


            FillGrid();
            FillTrashGrid(false, true);
        }
    }
}