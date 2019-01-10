using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfessionMaster : System.Web.UI.Page
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
                ((MasterPg)this.Master).title = "Profession Master";
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
            db.AddParameter("@created_by", Session["UserId"]);

            DataSet ds = db.ExecuteDataSet("Save_Edit_Delete_ProfessionMaster", CommandType.StoredProcedure);

            gvProfession.DataSource = ds;
            gvProfession.DataBind();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvProfession_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvProfession.PageIndex = e.NewPageIndex;
            gvProfession.DataBind();
            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvProfession_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvProfession.EditIndex = e.NewEditIndex;
            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvProfession_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        gvProfession.EditIndex = -1;
        FillGrid();

    }

    protected void gvProfession_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            TextBox txtProfession = (TextBox)gvProfession.Rows[e.RowIndex].FindControl("txtProfession");
            HiddenField hdnmID = (HiddenField)gvProfession.Rows[e.RowIndex].FindControl("hdnProfessionId");
            if (txtProfession.Text == string.Empty)
            {
                lblErrorMsg.Text = "Please enter profession";
                return;
            }
            db.AddParameter("@profession", txtProfession.Text);
            db.AddParameter("@profession_id", hdnmID.Value);
            db.AddParameter("@Mode", "Update");
            db.AddParameter("@created_by", Session["UserId"]);

            db.ExecuteNonQuery("Save_Edit_Delete_ProfessionMaster", CommandType.StoredProcedure);
            lblErrorMsg.Text = "Updated Successfully.";
            //displayError();
            gvProfession.EditIndex = -1;

            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }
    }

    protected void gvProfession_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            TextBox txtSubject = (TextBox)gvProfession.Rows[e.RowIndex].FindControl("txtProfession");
            HiddenField hdnmID = (HiddenField)gvProfession.Rows[e.RowIndex].FindControl("hdnProfessionId");
            db.AddParameter("@profession_id", hdnmID.Value);
            db.AddParameter("@Mode", "Delete");
            db.AddParameter("@created_by", Session["UserId"]);

            db.ExecuteNonQuery("Save_Edit_Delete_ProfessionMaster", CommandType.StoredProcedure);
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
            if (txtProfession.Text == string.Empty)
            {
                lblErrorMsg.Text = "Please enter profession";
                return;
            }
            db.AddParameter("@profession", txtProfession.Text);
            db.AddParameter("@Mode", "Insert");
            db.AddParameter("@created_by", Session["UserId"]);

            db.ExecuteNonQuery("Save_Edit_Delete_ProfessionMaster", CommandType.StoredProcedure);
            txtProfession.Text = "";
            lblErrorMsg.Text = "Profession Saved Successfully.";
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
        txtProfession.Text = "";
    }

    protected void lnkTrash_Click(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();
        if (lnkTrash.Text == "Close")
        {
            dvMain.Visible = true;
            FillGrid();
            FillTrashGrid(true, false);
            gvProfessionTrash.DataSource = null;
            gvProfessionTrash.DataBind();


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
        DataSet ds = db.ExecuteDataSet("select * from ProfessionMaster where active=0 order by Profession");

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
            gvProfessionTrash.DataSource = ds;
            gvProfessionTrash.DataBind();
        }
    }

    protected void gvProfessionTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@profession_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update ProfessionMaster set Active=1 where profession_id=@profession_id", CommandType.Text);


            FillGrid();
            FillTrashGrid(false, true);
        }
    }
    
}