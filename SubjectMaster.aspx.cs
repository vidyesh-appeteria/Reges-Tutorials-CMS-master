using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubjectMaster : System.Web.UI.Page
{
    DatabaseHelper db = new DatabaseHelper();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.Cookies["Theme"] != null)
            this.Theme = Request.Cookies["Theme"].Value;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillGrid();
            FillTrashGrid(true, false);
            ((MasterPg) this.Master).title= "Subject Master";
        }
        lblMsg.Text = "";

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        db.AddParameter("@SubjectName", txtSubjectName.Text);
        db.AddParameter("@Mode", "Insert");
        db.AddParameter("@created_by",hdnUserid.Value);

        db.ExecuteNonQuery("Save_Edit_Delete_SubjectMaster", CommandType.StoredProcedure);
        txtSubjectName.Text = "";
       lblMsg.Text = "Subject Saved Successfully.";
        //footer.Visible = true;
        FillGrid();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtSubjectName.Text = string.Empty;

    }
  
    //protected void gvSubject_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        int Sid = Convert.ToInt32(e.CommandArgument.ToString());

    //        if (e.CommandName == "EDIT")
    //        {
                
    //            db.AddParameter("@SubjectName", Sid);
    //            db.AddParameter("@SubjectId", Sid);
    //            db.AddParameter("@Mode", "Update");
    //            db.AddParameter("@created_by", hdnUserid.Value);

    //            db.ExecuteNonQuery("Save_Edit_Delete_SubjectMaster", CommandType.StoredProcedure);
    //        }

    //        if (e.CommandName == "DELETE")
    //        {
    //            db.AddParameter("@SubjectId", Sid);
    //            db.AddParameter("@Mode", "Delete");
    //            db.AddParameter("@created_by", hdnUserid.Value);

    //            db.ExecuteNonQuery("Save_Edit_Delete_SubjectMaster", CommandType.StoredProcedure);
    //        }



    //        FillGrid();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblErrorMsg.Text = ex.Message.ToString();
    //    }

    //}

    protected void gvSubject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSubject.PageIndex = e.NewPageIndex;
        gvSubject.DataBind();
        FillGrid();
    }

    protected void gvSubject_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    public void FillGrid()
    {
        db.AddParameter("@Mode", "Get");
        db.AddParameter("@created_by", hdnUserid.Value);

        DataSet ds = db.ExecuteDataSet("Save_Edit_Delete_SubjectMaster", CommandType.StoredProcedure);

        gvSubject.DataSource = ds;
        gvSubject.DataBind();

    }

    protected void gvSubject_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSubject.EditIndex = e.NewEditIndex;

        FillGrid();
    }

    protected void gvSubject_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        gvSubject.EditIndex = -1;
            FillGrid();
        

    }

    protected void gvSubject_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridViewRow row = gvSubject.Rows[e.RowIndex];
        TextBox txtSubject = (TextBox)gvSubject.Rows[e.RowIndex].FindControl("txtSubject");
        HiddenField hdnmID = (HiddenField)gvSubject.Rows[e.RowIndex].FindControl("hdnsubject_id");
        db.AddParameter("@SubjectName", txtSubject.Text);
        db.AddParameter("@SubjectId", hdnmID.Value);
        db.AddParameter("@Mode", "Update");
        db.AddParameter("@created_by", hdnUserid.Value);

        db.ExecuteNonQuery("Save_Edit_Delete_SubjectMaster", CommandType.StoredProcedure);
        lblMsg.Text = "Updated Successfully.";
        //displayError();
        gvSubject.EditIndex = -1;

        FillGrid();
       


    }

    protected void gvSubject_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TextBox txtSubject = (TextBox)gvSubject.Rows[e.RowIndex].FindControl("txtSubject");
        HiddenField hdnmID = (HiddenField)gvSubject.Rows[e.RowIndex].FindControl("hdnsubject_id");
        db.AddParameter("@SubjectId", hdnmID.Value);
        db.AddParameter("@Mode", "Delete");
        db.AddParameter("@created_by", hdnUserid.Value);

        db.ExecuteNonQuery("Save_Edit_Delete_SubjectMaster", CommandType.StoredProcedure);
        lblMsg.Text = "Deleted Successfully.";
        //displayError();
        FillGrid();


    }

    public void displayError()
    {
        Page.Master.FindControl("footer").Visible = true;
        Label lt = Page.Master.FindControl("lblAlertError") as Label;
        lt.Text = Session["Message"].ToString();
        Session["Message"] = null;
    }


    private void FillTrashGrid(bool showCount, bool showGrid)
    {

        DatabaseHelper db = new DatabaseHelper();
        DataSet ds = db.ExecuteDataSet("select * from SubjectMaster where Active=0 order by Subject_Name", CommandType.Text);

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
            gvSubjectTrash.DataSource = ds;
            gvSubjectTrash.DataBind();
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
            gvSubjectTrash.DataSource = null;
            gvSubjectTrash.DataBind();


        }
        else
        {
            lnkTrash.Text = "Close";
            lnkTrash.CssClass = "";
            dvMain.Visible = false;
            FillTrashGrid(false, true);
        }

    }

    protected void gvSubjectTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {

            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@Subject_Id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update SubjectMaster set Active=1 where Subject_Id=@Subject_Id", CommandType.Text);

            FillGrid();
            FillTrashGrid(false, true);


        }
    }
}