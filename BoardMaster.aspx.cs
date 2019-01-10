using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BoardMaster : System.Web.UI.Page
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
                ((MasterPg)this.Master).title = "Board Master";
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

            DataSet ds = db.ExecuteDataSet("Save_Edit_Delete_BoardMaster", CommandType.StoredProcedure);

            gvBoard.DataSource = ds;
            gvBoard.DataBind();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvBoard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvBoard.PageIndex = e.NewPageIndex;
            gvBoard.DataBind();
            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvBoard_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {


            gvBoard.EditIndex = e.NewEditIndex;

            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvBoard_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        gvBoard.EditIndex = -1;
        FillGrid();

    }

    protected void gvBoard_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
           
            TextBox txtBoard = (TextBox)gvBoard.Rows[e.RowIndex].FindControl("txtBoard");
            HiddenField hdnmID = (HiddenField)gvBoard.Rows[e.RowIndex].FindControl("hdnBoardId");
            if (txtBoard.Text == string.Empty)
            {
                lblErrorMsg.Text = "Please enter name of the board";
                return;
            }
            db.AddParameter("@board", txtBoard.Text);
            db.AddParameter("@board_id", hdnmID.Value);
            db.AddParameter("@Mode", "Update");
            db.AddParameter("@createdby", hdnUserid.Value);

            db.ExecuteNonQuery("Save_Edit_Delete_BoardMaster", CommandType.StoredProcedure);
            lblErrorMsg.Text = "Updated Successfully.";
            //displayError();
            gvBoard.EditIndex = -1;

            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }
    }

    protected void gvBoard_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            TextBox txtSubject = (TextBox)gvBoard.Rows[e.RowIndex].FindControl("txtBoard");
            HiddenField hdnmID = (HiddenField)gvBoard.Rows[e.RowIndex].FindControl("hdnBoardId");
            db.AddParameter("@board_id", hdnmID.Value);
            db.AddParameter("@Mode", "Delete");
            db.AddParameter("@createdby", hdnUserid.Value);

            db.ExecuteNonQuery("Save_Edit_Delete_BoardMaster", CommandType.StoredProcedure);
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
            if (txtBoardName.Text == string.Empty)
            {
                lblErrorMsg.Text = "Please enter name of the board";
                return;
            }
            db.AddParameter("@board", txtBoardName.Text);
            db.AddParameter("@Mode", "Insert");
            db.AddParameter("@createdby", hdnUserid.Value);

            db.ExecuteNonQuery("Save_Edit_Delete_BoardMaster", CommandType.StoredProcedure);
            txtBoardName.Text = "";
            lblErrorMsg.Text = "Board Saved Successfully.";
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
        txtBoardName.Text = "";
    }

    protected void lnkTrash_Click(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();
        if (lnkTrash.Text == "Close")
        {
            dvMain.Visible = true;
            FillGrid();
            FillTrashGrid(true, false);
            gvBoardTrash.DataSource = null;
            gvBoardTrash.DataBind();


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
        DataSet ds = db.ExecuteDataSet("select * from board_master where active=0 order by board");

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
            gvBoardTrash.DataSource = ds;
            gvBoardTrash.DataBind();
            pnlTrash.Visible = gvBoardTrash.Rows.Count > 0;
        }
    }

    protected void gvBoardTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@board_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update board_master set Active=1 where board_id=@board_id", CommandType.Text);


            FillGrid();
            FillTrashGrid(false, true);
        }
    }
}