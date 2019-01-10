using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class standardMaster : System.Web.UI.Page
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
                FillBoard();
                FillGrid();
                FillTrashGrid(true, false);
                ((MasterPg)this.Master).title = "Standard Master";
            }
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

            DataSet ds = db.ExecuteDataSet("Save_Edit_Delete_standardMaster", CommandType.StoredProcedure);

            gvStandard.DataSource = ds;
            gvStandard.DataBind();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }
    public void FillBoard()
    {
        DataSet ds = db.ExecuteDataSet("select board_id 'key',Board as value from board_Master where active=1", CommandType.Text);
        ddlBoardName.DataSource = ds;
        ddlBoardName.DataValueField = "key";
        ddlBoardName.DataTextField = "value";
        ddlBoardName.DataBind();
        ddlBoardName.Items.Insert(0, "Select");

    }
    protected void gvStandard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvStandard.PageIndex = e.NewPageIndex;
            gvStandard.DataBind();
            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvStandard_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            HiddenField hdnmID = (HiddenField)gvStandard.Rows[e.RowIndex].FindControl("hdnStandardId");
            db.AddParameter("@standard_id", hdnmID.Value);
            db.AddParameter("@Mode", "Delete");
            db.AddParameter("@createdby", hdnUserid.Value);

            db.ExecuteNonQuery("Save_Edit_Delete_standardMaster", CommandType.StoredProcedure);
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

    protected void gvStandard_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtStandard = (TextBox)gvStandard.Rows[e.RowIndex].FindControl("txtStandard");
            DropDownList ddlBoard = (DropDownList)gvStandard.Rows[e.RowIndex].FindControl("ddlBoard");
            HiddenField hdnmID = (HiddenField)gvStandard.Rows[e.RowIndex].FindControl("hdnStandardId");

            db.AddParameter("@standard", txtStandard.Text);
            db.AddParameter("@standard_id", hdnmID.Value);
            db.AddParameter("@board_id", ddlBoard.SelectedValue);
            db.AddParameter("@Mode", "Update");
            db.AddParameter("@createdby", hdnUserid.Value);

            db.ExecuteNonQuery("Save_Edit_Delete_standardMaster", CommandType.StoredProcedure);
            lblErrorMsg.Text = "Updated Successfully.";
            //displayError();
            gvStandard.EditIndex = -1;

            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvStandard_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        gvStandard.EditIndex = -1;
        FillGrid();

    }

    protected void gvStandard_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {


            gvStandard.EditIndex = e.NewEditIndex;
            //   HiddenField hdnmBoardID = (HiddenField)gvStandard.Rows[e.NewEditIndex].FindControl("hdnboardid");
            //DropDownList ddlBoard = (DropDownList)gvStandard.Rows[e.NewEditIndex].FindControl("ddlBoard");

            //DataSet ds = db.ExecuteDataSet("select board_id 'key',Board as value from boardMaster where active=1", CommandType.Text);
            //ddlBoard.DataSource = ds;
            //ddlBoard.DataValueField = "key";
            //ddlBoard.DataTextField = "value";
            //ddlBoard.DataBind();
            //ddlBoard.Items.Insert(0, "Select");
            // ddlBoard.SelectedValue = hdnmBoardID.Value;

            FillGrid();

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
            db.AddParameter("@standard", txtStandardName.Text);
            db.AddParameter("@board_id", ddlBoardName.SelectedValue);

            db.AddParameter("@Mode", "Insert");
            db.AddParameter("@createdby", hdnUserid.Value);

            db.ExecuteNonQuery("Save_Edit_Delete_standardMaster", CommandType.StoredProcedure);
            txtStandardName.Text = "";
            ddlBoardName.SelectedIndex = 0;
            ddlBoardName.Items.Insert(0, "Select");

            lblErrorMsg.Text = "Subject Saved Successfully.";
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
        txtStandardName.Text = "";
        ddlBoardName.SelectedIndex = 0;

    }

    protected void gvStandard_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                //   hdnSavedmemberID.Value = hdnSavedmemberID.Value + "";
                DataRowView drv = e.Row.DataItem as DataRowView;
                DropDownList ddlBoard = (DropDownList)e.Row.FindControl("ddlBoard");
                DataSet ds = db.ExecuteDataSet("select board_id 'key',Board as value from board_Master where active=1", CommandType.Text);
                ddlBoard.DataSource = ds;
                ddlBoard.DataValueField = "key";
                ddlBoard.DataTextField = "value";
                ddlBoard.DataBind();
                ddlBoard.Items.Insert(0, "Select");

                HiddenField hdnmBoardID = (HiddenField)e.Row.FindControl("hdnboardid");
                ddlBoard.SelectedValue = hdnmBoardID.Value;


            }
        }
    }

    private void FillTrashGrid(bool showCount, bool showGrid)
    {

        DatabaseHelper db = new DatabaseHelper();
        DataSet ds = db.ExecuteDataSet("select standard_id,standard,board,s.board_id from standard_Master s inner join Board_Master b on s.board_id=b.board_id where s.active=0 order by standard");

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
        pnlTrash.Visible = false;
        if (showGrid)
        {
            gvStandardTrash.DataSource = ds;
            gvStandardTrash.DataBind();
            pnlTrash.Visible = gvStandardTrash.Rows.Count > 0;
        }
    }
    protected void lnkTrash_Click(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();
        if (lnkTrash.Text == "Close")
        {
            dvMain.Visible = true;
            FillGrid();
            FillTrashGrid(true, false);
            gvStandardTrash.DataSource = null;
            gvStandardTrash.DataBind();
        }
        else
        {
            lnkTrash.Text = "Close";
            lnkTrash.CssClass = "";
            dvMain.Visible = false;
            FillTrashGrid(false, true);
        }
    }


    protected void gvStandardTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@standard_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update standard_master set Active=1 where standard_id=@standard_id", CommandType.Text);
            FillGrid();
            FillTrashGrid(false, true);
        }
    }
}