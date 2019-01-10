using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubscriptionPlans : System.Web.UI.Page
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
            ((MasterPg)this.Master).title = "Subscription Plans";
        }
        lblErrorMsg.Text = "";

    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        db.AddParameter("@plan_id", hdnPlanid.Value);
        db.AddParameter("@actual_amount", txtActualAmount.Text);
        db.AddParameter("@discount_amount", txtDiscountAmount.Text);
        db.AddParameter("@period", txtPeriod.Text);
        db.AddParameter("@plan_name", txtPlanName.Text);
        db.AddParameter("@Mode", "Insert");
        db.AddParameter("@created_by", Session["UserId"]);

        db.ExecuteNonQuery("Save_Edit_Delete_subscriptionplans", CommandType.StoredProcedure);
        txtActualAmount.Text = "";
        txtDiscountAmount.Text = "";
        txtPeriod.Text = "";
        txtPlanName.Text = "";
        lblErrorMsg.Text = "Plan Saved Successfully.";
        FillGrid();
    }



    public void FillGrid()
    {
        db.AddParameter("@Mode", "Get");
        db.AddParameter("@created_by", hdnPlanid.Value);

        DataSet ds = db.ExecuteDataSet("Save_Edit_Delete_subscriptionplans", CommandType.StoredProcedure);

        gvSubscripnPlans.DataSource = ds;
        gvSubscripnPlans.DataBind();

    }




    public void displayError()
    {
        Page.Master.FindControl("footer").Visible = true;
        Label lt = Page.Master.FindControl("lblAlertError") as Label;
        lt.Text = Session["Message"].ToString();
        Session["Message"] = null;
    }




    protected void gvSubscripnPlans_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSubscripnPlans.PageIndex = e.NewPageIndex;
        gvSubscripnPlans.DataBind();
        FillGrid();
    }


    protected void gvSubscripnPlans_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSubscripnPlans.EditIndex = e.NewEditIndex;
        FillGrid();

    }

    protected void gvSubscripnPlans_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtPlanName = (TextBox)gvSubscripnPlans.Rows[e.RowIndex].FindControl("txtPlanName");
        TextBox txtActualAmount = (TextBox)gvSubscripnPlans.Rows[e.RowIndex].FindControl("txtActualAmount");
        TextBox txtDiscountAmount = (TextBox)gvSubscripnPlans.Rows[e.RowIndex].FindControl("txtDiscountAmount");
        TextBox txtPeriod = (TextBox)gvSubscripnPlans.Rows[e.RowIndex].FindControl("txtPeriod");

        HiddenField hdnmID = (HiddenField)gvSubscripnPlans.Rows[e.RowIndex].FindControl("hdnPlanId");

        db.AddParameter("@plan_id", hdnmID.Value);
        db.AddParameter("@actual_amount", txtActualAmount.Text);
        db.AddParameter("@discount_amount", txtDiscountAmount.Text);
        db.AddParameter("@period", txtPeriod.Text);
        db.AddParameter("@plan_name", txtPlanName.Text);
        db.AddParameter("@Mode", "Update");
        db.AddParameter("@created_by", Session["UserId"]);


        db.ExecuteNonQuery("Save_Edit_Delete_subscriptionplans", CommandType.StoredProcedure); lblErrorMsg.Text = "Updated Successfully.";
        //displayError();
        gvSubscripnPlans.EditIndex = -1;

        FillGrid();

    }

    protected void gvSubscripnPlans_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        gvSubscripnPlans.EditIndex = -1;
        FillGrid();

    }

    protected void gvSubscripnPlans_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hdnmID = (HiddenField)gvSubscripnPlans.Rows[e.RowIndex].FindControl("hdnPlanId");
        db.AddParameter("@plan_id", hdnmID.Value);
        db.AddParameter("@Mode", "Delete");
        db.AddParameter("@created_by", Session["UserId"]);

        db.ExecuteNonQuery("Save_Edit_Delete_subscriptionplans", CommandType.StoredProcedure);
        lblErrorMsg.Text = "Deleted Successfully.";
        //displayError();
        FillGrid();
        FillTrashGrid(true, false);
    }


    protected void lnkTrash_Click(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();
        if (lnkTrash.Text == "Close")
        {
            dvMain.Visible = true;
            FillGrid();
            FillTrashGrid(true, false);
            gvSubscripnPlansTrash.DataSource = null;
            gvSubscripnPlansTrash.DataBind();


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
        DataSet ds = db.ExecuteDataSet("select * from subscriptionplans where active=0");

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
            gvSubscripnPlansTrash.DataSource = ds;
            gvSubscripnPlansTrash.DataBind();
        }
    }

    protected void gvSubscripnPlans_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvSubscripnPlansTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@plan_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update subscriptionplans set Active=1 where plan_id=@plan_id", CommandType.Text);


            FillGrid();
            FillTrashGrid(false, true);
        }
    }


}