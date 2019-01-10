using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TimeTable : System.Web.UI.Page
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
            Util.FillDropDownAll(ddlMedium, "select * from medium_master where active=1 order by medium", "medium", "medium_id", db);
            Util.FillDropDownAll(ddlBoard, "select * from board_master where active=1 order by board", "board", "board_id", db);
            Util.FillDropDown(ddlType, "select * from tt_type_master where active=1 order by tt_type", "tt_type", "tt_type_id", db);
            Util.FillDropDownAll(ddlStandard, "select * from standard_master where active=1 and board_id=" + ddlBoard.SelectedValue + " order by standard", "standard", "standard_id", db);
            getBatches();
            ((MasterPg)this.Master).title = "Time Table";
        }


    }

    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        Util.FillDropDownAll(ddlStandard, "select * from standard_master where active=1 and board_id=" + ddlBoard.SelectedValue + " order by standard", "standard", "standard_id", db);
        getBatches();
        ddlStandard.Focus();
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        db.AddParameter("@tt_id", hdnttId.Value);
        db.AddParameter("@tt_date", txtDate.Text);
        db.AddParameter("@tt_desc", txtDesc.Text);
        db.AddParameter("@tt_type_id", ddlType.SelectedValue);
        db.AddParameter("@batch_id", ddlBatch.SelectedValue);
        db.AddParameter("@standard_id", ddlStandard.SelectedValue);
        db.AddParameter("@board_id", ddlBoard.SelectedValue);
        db.AddParameter("@medium_id", ddlMedium.SelectedValue);
        db.AddParameter("@modified_by", Session["UserId"]);
        db.ExecuteNonQuery("save_time_table", CommandType.StoredProcedure);

        lblErrorMsg.Text = "Time Table Updated Successfully.";
        //footer.Visible = true;
        FillGrid();
        btnClear_Click(null, null);
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        hdnttId.Value = "0";
        txtDate.Text = string.Empty;
        txtDesc.Text = string.Empty;
        ddlType.SelectedIndex = -1;
        ddlBatch.SelectedIndex = -1;
        ddlStandard.SelectedIndex = -1;
        ddlBoard.SelectedIndex = -1;
        ddlMedium.SelectedIndex = -1;
    }


    public void FillGrid()
    {
        DataSet ds = db.ExecuteDataSet("get_time_table", CommandType.StoredProcedure);

        gvTimeTable.DataSource = ds;
        gvTimeTable.DataBind();

    }
    protected void gvTimeTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTimeTable.PageIndex = e.NewPageIndex;
        gvTimeTable.DataBind();
        FillGrid();
    }


    protected void gvTimeTable_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EDT")
        {
            db.AddParameter("@tt_id", e.CommandArgument.ToString());
            DataSet ds = db.ExecuteDataSet("select *,replace(convert(varchar, tt_date,106),' ','-')tt_date1 from time_table where tt_id=@tt_id");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdnttId.Value = e.CommandArgument.ToString();
                txtDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["tt_date1"]);
                txtDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["tt_desc"]);
                ddlType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["tt_type_id"]);
                ddlMedium.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["medium_id"]);
                ddlBoard.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["board_id"]);
                ddlBoard_SelectedIndexChanged(null, null);
                ddlStandard.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["standard_id"]);
                getBatches();
                ddlBatch.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["batch_id"]);
            }
        }
        else if (e.CommandName == "DEL")
        {
            db.AddParameter("@tt_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update time_table set active=0 where tt_id=@tt_id");

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
            gvTimeTableTrash.DataSource = null;
            gvTimeTableTrash.DataBind();
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
        DataSet ds = db.ExecuteDataSet("get_time_table", CommandType.StoredProcedure);

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
            gvTimeTableTrash.DataSource = ds;
            gvTimeTableTrash.DataBind();
        }
    }

    protected void gvTimeTableTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@tt_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update time_table set Active=1 where tt_id=@tt_id", CommandType.Text);


            FillGrid();
            FillTrashGrid(false, true);
        }


    }


    private void getBatches()
    {
        db.AddParameter("@standard_id", ddlStandard.SelectedValue);
        db.AddParameter("@board_id", ddlBoard.SelectedValue);
        db.AddParameter("@medium_id", ddlMedium.SelectedValue);
        Util.FillDropDownAll(ddlBatch, "select * from batch_master where active=1 and standard_id=@standard_id and board_id=@board_id and medium_id=@medium_id", "batch_name", "batch_id", db);
    }

    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        getBatches();
    }

    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        getBatches();
    }

}