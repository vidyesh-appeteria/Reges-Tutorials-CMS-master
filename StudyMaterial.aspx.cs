using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudyMaterial : System.Web.UI.Page
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
           // Util.FillDropDown(ddlType, "select * from tt_type_master where active=1 order by tt_type", "tt_type", "tt_type_id", db);
            Util.FillDropDownAll(ddlStandard, "select * from standard_master where active=1 and board_id=" + ddlBoard.SelectedValue + " order by standard", "standard", "standard_id", db);
            getBatches();
            ((MasterPg)this.Master).title = "Study Material";
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
        string file_name = string.Empty;
        if (fuDesc.HasFile)
        {
            file_name = DateTime.Now.ToString().Replace(":", "").Replace("-", "").Replace(" ", "");
            fuDesc.SaveAs(Server.MapPath("study_material") + "/" + file_name +"_"+ fuDesc.FileName);
        }
        db.AddParameter("@study_material_id", hdnStudyMaterialId.Value);
        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@description", ddlType.SelectedValue=="doc"? file_name+ "_" + fuDesc.FileName: txtDesc.Text);
        db.AddParameter("@material_type", ddlType.SelectedValue);
        db.AddParameter("@batch_id", ddlBatch.SelectedValue);
        db.AddParameter("@standard_id", ddlStandard.SelectedValue);
        db.AddParameter("@board_id", ddlBoard.SelectedValue);
        db.AddParameter("@medium_id", ddlMedium.SelectedValue);
        db.AddParameter("@modified_by", Session["UserId"]);
        db.ExecuteNonQuery("save_study_material", CommandType.StoredProcedure);

        lblErrorMsg.Text = "Time Table Updated Successfully.";
        //footer.Visible = true;
        FillGrid();
        btnClear_Click(null, null);
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        hdnStudyMaterialId.Value = "0";
        txtTitle.Text = string.Empty;
        txtDesc.Text = string.Empty;
        ddlType.SelectedIndex = -1;
        ddlBatch.SelectedIndex = -1;
        ddlStandard.SelectedIndex = -1;
        ddlBoard.SelectedIndex = -1;
        ddlMedium.SelectedIndex = -1;
    }


    public void FillGrid()
    {
        DataSet ds = db.ExecuteDataSet("get_study_material", CommandType.StoredProcedure);

        gvStudyMaterial.DataSource = ds;
        gvStudyMaterial.DataBind();

    }
    protected void gvStudyMaterial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudyMaterial.PageIndex = e.NewPageIndex;
        gvStudyMaterial.DataBind();
        FillGrid();
    }


    protected void gvStudyMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EDT")
        {
            db.AddParameter("@study_material_id", e.CommandArgument.ToString());
            DataSet ds = db.ExecuteDataSet("select * from study_material where study_material_id=@study_material_id");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdnStudyMaterialId.Value = e.CommandArgument.ToString();
                txtTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["title"]);
                txtDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["description"]);
                ddlType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["material_type"]);
                ddlType_SelectedIndexChanged(null, null);
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
            db.AddParameter("@study_material_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update study_material set active=0 where study_material_id=@study_material_id");

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
            gvStudyMaterialTrash.DataSource = null;
            gvStudyMaterialTrash.DataBind();
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
        DataSet ds = db.ExecuteDataSet("get_study_material", CommandType.StoredProcedure);

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
            gvStudyMaterialTrash.DataSource = ds;
            gvStudyMaterialTrash.DataBind();
        }
    }

    protected void gvStudyMaterialTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@study_material_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update study_material set Active=1 where study_material_id=@study_material_id", CommandType.Text);


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


    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedValue == "doc")
        {
            fuDesc.Visible = true;
            txtDesc.Visible = false;
            rfvDesc.Enabled = false;
            lblDesc.Text = "Upload Document";
        }
        else
        {
            fuDesc.Visible = false;
            txtDesc.Visible = true;
            rfvDesc.Enabled = true;
            lblDesc.Text = "Enter Link";
        }
    }
}