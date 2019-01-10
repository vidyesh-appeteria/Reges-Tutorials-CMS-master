using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TTTypeMaster : System.Web.UI.Page
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
            ((MasterPg)this.Master).title = "Time Table Types"; 
        }


    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        db.AddParameter("@tt_type_id", hdnTTTypeId.Value);
        db.AddParameter("@tt_type", txtType.Text);
        db.AddParameter("@tt_type_color", ddlColor.SelectedValue);
        db.AddParameter("@modified_by", Session["UserId"]);
        db.ExecuteNonQuery("Save_tt_type_master", CommandType.StoredProcedure);

        lblErrorMsg.Text = "Type Saved Successfully.";
        //footer.Visible = true;
        FillGrid();
        btnClear_Click(null, null);
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        hdnTTTypeId.Value = "0";
        txtType.Text = string.Empty;
        ddlColor.SelectedIndex = -1;
        pnnlColor.BackColor = Color.White;
        
    }


    public void FillGrid()
    {
        DataSet ds = db.ExecuteDataSet("get_tt_type_master", CommandType.StoredProcedure);

        gvTypes.DataSource = ds;
        gvTypes.DataBind();

    }
    protected void gvTypes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTypes.PageIndex = e.NewPageIndex;
        gvTypes.DataBind();
        FillGrid();
    }


    protected void gvTypes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EDT")
        {
            db.AddParameter("@tt_type_id", e.CommandArgument.ToString());
            DataSet ds = db.ExecuteDataSet("select * from tt_type_master where tt_type_id=@tt_type_id");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdnTTTypeId.Value = e.CommandArgument.ToString();
                txtType.Text = Convert.ToString(ds.Tables[0].Rows[0]["tt_type"]);
                ddlColor.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["tt_type_color"]);
                
            FillGrid();
            }
        }
        else if (e.CommandName == "DEL")
        {
            db.AddParameter("@tt_type_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update tt_type_master set active=0 where tt_type_id=@tt_type_id");

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
            gvTypesTrash.DataSource = null;
            gvTypesTrash.DataBind();
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
        DataSet ds = db.ExecuteDataSet("get_tt_type_master", CommandType.StoredProcedure);

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
            gvTypesTrash.DataSource = ds;
            gvTypesTrash.DataBind();
        }
    }

    protected void gvTypesTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@tt_type_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update tt_type_master set Active=1 where tt_type_id=@tt_type_id", CommandType.Text);

            FillGrid();
            FillTrashGrid(false, true);
        }
    }

    protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlColor.SelectedValue == "0")
            pnnlColor.BackColor = Color.White;
        else
            pnnlColor.BackColor = Color.FromName(ddlColor.SelectedValue);
        ddlColor.Focus();
    }
}