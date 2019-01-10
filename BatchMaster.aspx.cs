using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BatchMaster : System.Web.UI.Page
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
            Util.FillDropDown(ddlMedium, "select * from medium_master where active=1 order by medium", "medium", "medium_id", db);
            Util.FillDropDown(ddlBoard, "select * from board_master where active=1 order by board", "board", "board_id", db);
            //Util.FillDropDown(ddlMedium, "select * from medium_master where active=1 order by medium", "medium", "medium_id", db);
            ((MasterPg)this.Master).title = "Batch Master";
        }


    }

    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        Util.FillDropDown(ddlStandard, "select * from standard_master where active=1 and board_id=" + ddlBoard.SelectedValue + " order by standard", "standard", "standard_id", db);
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        db.AddParameter("@batch_id", hdnBatchId.Value);
        db.AddParameter("@batch_name", txtBatchName.Text);
        db.AddParameter("@standard_id", ddlStandard.SelectedValue);
        db.AddParameter("@board_id", ddlBoard.SelectedValue);
        db.AddParameter("@medium_id", ddlMedium.SelectedValue);
        db.AddParameter("@modified_by", Session["UserId"]);

        db.ExecuteNonQuery("save_batch_master", CommandType.StoredProcedure);

        lblErrorMsg.Text = "Batch Saved Successfully.";
        //footer.Visible = true;
        FillGrid();
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        hdnBatchId.Value = "0";
        txtBatchName.Text = string.Empty;
        ddlMedium.SelectedIndex = -1;
        ddlStandard.SelectedIndex = -1;
        ddlBoard.SelectedIndex = -1;
    }


    public void FillGrid()
    {
        DataSet ds = db.ExecuteDataSet("get_batch_master", CommandType.StoredProcedure);

        gvBatch.DataSource = ds;
        gvBatch.DataBind();

    }
    protected void gvBatch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBatch.PageIndex = e.NewPageIndex;
        gvBatch.DataBind();
        FillGrid();
    }


    protected void gvBatch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EDT")
        {
            db.AddParameter("@batch_id", e.CommandArgument.ToString());
            DataSet ds = db.ExecuteDataSet("select * from batch_master where batch_id=@batch_id");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdnBatchId.Value = e.CommandArgument.ToString();
                txtBatchName.Text = Convert.ToString(ds.Tables[0].Rows[0]["batch_name"]);
                ddlMedium.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["medium_id"]);
                ddlBoard.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["board_id"]);
                ddlBoard_SelectedIndexChanged(null, null);
                ddlStandard.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["standard_id"]);
            }
        }
        else if (e.CommandName == "DEL")
        {
            db.AddParameter("@batch_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update batch_master set active=0 where batch_id=@batch_id");

            FillGrid();
            FillTrashGrid(true, false);
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
            gvBatchTrash.DataSource = null;
            gvBatchTrash.DataBind();
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
        db.AddParameter("@active", 0);
        DataSet ds = db.ExecuteDataSet("get_batch_master", CommandType.StoredProcedure);

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
            gvBatchTrash.DataSource = ds;
            gvBatchTrash.DataBind();
        }
    }

    protected void gvBatchTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@batch_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update batch_master set Active=1 where batch_id=@batch_id", CommandType.Text);


            FillGrid();
            FillTrashGrid(false, true);
        }


    }
}