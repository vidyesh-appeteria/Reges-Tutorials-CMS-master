using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InstituteMaster : System.Web.UI.Page
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
            ((MasterPg)this.Master).title = "Institute Master";
        }


    }
 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        db.AddParameter("@institute_id", hdnInstituteId.Value);
        db.AddParameter("@institute_name", txtInstituteName.Text);
        db.AddParameter("@locality", txtLocality.Text);
        db.AddParameter("@institute_type", rblInstituteType.SelectedValue);
        db.AddParameter("@modified_by", Session["UserId"]);

        db.ExecuteNonQuery("save_institute_master", CommandType.StoredProcedure);

        lblErrorMsg.Text = "Institute Saved Successfully.";
        //footer.Visible = true;
        FillGrid();
        btnClear_Click(null, null);
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        hdnInstituteId.Value = "0";
        txtInstituteName.Text = string.Empty;
        txtLocality.Text = string.Empty;
        rblInstituteType.SelectedIndex = -1;        
    }


    public void FillGrid()
    {
        DataSet ds = db.ExecuteDataSet("get_institute_master", CommandType.StoredProcedure);

        gvInstitutes.DataSource = ds;
        gvInstitutes.DataBind();

    }
    protected void gvInstitutes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInstitutes.PageIndex = e.NewPageIndex;
        gvInstitutes.DataBind();
        FillGrid();
    }


    protected void gvInstitutes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EDT")
        {
            db.AddParameter("@institute_id", e.CommandArgument.ToString());
            DataSet ds = db.ExecuteDataSet("select * from institute_master where institute_id=@institute_id");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdnInstituteId.Value = e.CommandArgument.ToString();
                txtInstituteName.Text = Convert.ToString(ds.Tables[0].Rows[0]["institute_name"]);
                txtLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["locality"]);
                rblInstituteType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["institute_type"]);                
            }
        }
        else if (e.CommandName == "DEL")
        {
            db.AddParameter("@institute_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update institute_master set active=0 where institute_id=@institute_id");

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
            gvInstitutesTrash.DataSource = null;
            gvInstitutesTrash.DataBind();
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
        DataSet ds = db.ExecuteDataSet("get_institute_master", CommandType.StoredProcedure);

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
            gvInstitutesTrash.DataSource = ds;
            gvInstitutesTrash.DataBind();
        }
    }

    protected void gvInstitutesTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@institute_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update institute_master set Active=1 where institute_id=@institute_id", CommandType.Text);


            FillGrid();
            FillTrashGrid(false, true);
        }


    }

  

    
 
}