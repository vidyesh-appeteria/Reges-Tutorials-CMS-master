using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChapterMaster : System.Web.UI.Page
{
    DatabaseHelper db = new DatabaseHelper();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.Cookies["Theme"] != null)
            this.Theme = Request.Cookies["Theme"].Value;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        lblErrorMsg.Text = "";
        if (!IsPostBack)
        {
            FillSubject();
            FillStandard();
            FillGrid();
            FillTrashGrid(true, false);
            ((MasterPg)this.Master).title = "Chapter Master";

        }
        lblErrorMsg.Text = "";

    }

    public void FillSubject()
    {
        DataSet ds = db.ExecuteDataSet("select subject_id 'key',subject_name as value from subjectMaster where active=1", CommandType.Text);
        ddlSubject.DataSource = ds;
        ddlSubject.DataValueField = "key";
        ddlSubject.DataTextField = "value";
        ddlSubject.DataBind();
        ddlSubject.Items.Insert(0, new ListItem("Seelct", "0"));

        ddlSubjectSearch.DataSource = ds;
        ddlSubjectSearch.DataValueField = "key";
        ddlSubjectSearch.DataTextField = "value";
        ddlSubjectSearch.DataBind();
        ddlSubjectSearch.Items.Insert(0, new ListItem("All Subjects", "0"));

    }


    public void FillStandard()
    {
        DataSet ds = db.ExecuteDataSet("select s.standard_id 'key',s.Standard + ' [' + b.board +']' as value from StandardMaster s inner join  boardmaster b on s.board_id=b.board_id where s.active=1", CommandType.Text);
        ddlStandard.DataSource = ds;
        ddlStandard.DataValueField = "key";
        ddlStandard.DataTextField = "value";
        ddlStandard.DataBind();
        ddlStandard.Items.Insert(0,new ListItem("Select","0"));


        ddlStandardSearch.DataSource = ds;
        ddlStandardSearch.DataValueField = "key";
        ddlStandardSearch.DataTextField = "value";
        ddlStandardSearch.DataBind();
        ddlStandardSearch.Items.Insert(0,new ListItem("All Standards","0"));

    }

    //public void FillDropdown(DropDownList ddl, string query, string default_Text)
    //{
    //    DataSet ds = db.ExecuteDataSet(query, CommandType.Text);
    //    ddl.DataSource = ds;
    //    ddl.DataValueField = "key";
    //    ddl.DataTextField = "value";
    //    ddl.DataBind();
    //    ddl.Items.Insert(0, default_Text);

    //}

    public void FillGrid()
    {
        try
        {
            db.AddParameter("@chapter_name", txtChapterSearch.Text);
            db.AddParameter("@subject_id", ddlSubjectSearch.SelectedValue);
            db.AddParameter("@standard_id", ddlStandardSearch.SelectedValue);
            DataSet ds = db.ExecuteDataSet("list_chaptermaster",CommandType.StoredProcedure);
            gvChapter.DataSource = ds;
            gvChapter.DataBind();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }


    protected void gvChapter_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        gvChapter.EditIndex = -1;
        FillGrid();

    }

    protected void gvChapter_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtChapter = (TextBox)gvChapter.Rows[e.RowIndex].FindControl("txtChapter");
            DropDownList ddlSubjectName = (DropDownList)gvChapter.Rows[e.RowIndex].FindControl("ddlSubjectName");
            DropDownList ddlStandardName = (DropDownList)gvChapter.Rows[e.RowIndex].FindControl("ddlStandardName");

            HiddenField hdnmID = (HiddenField)gvChapter.Rows[e.RowIndex].FindControl("hdnStandardId");
            db.AddParameter("@chapter_id", hdnmID.Value);

            db.AddParameter("@chapter_name", txtChapter.Text);
            db.AddParameter("@subject_id", ddlSubjectName.SelectedValue);
            db.AddParameter("@standard_id", ddlStandardName.SelectedValue);

            db.AddParameter("@created_by", hdnUserid.Value);

            db.AddParameter("@Mode", "Update");


            db.ExecuteNonQuery("Save_Edit_Delete_ChapterMaster", CommandType.StoredProcedure);
            lblErrorMsg.Text = "Updated Successfully.";
            //displayError();
            gvChapter.EditIndex = -1;

            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }
    }

    protected void gvChapter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvChapter.PageIndex = e.NewPageIndex;
            gvChapter.DataBind();
            FillGrid();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }


    protected void gvChapter_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {


            gvChapter.EditIndex = e.NewEditIndex;

            FillGrid();

        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }

    protected void gvChapter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                //   hdnSavedmemberID.Value = hdnSavedmemberID.Value + "";
                DataRowView drv = e.Row.DataItem as DataRowView;
                DropDownList ddlSubjectName = (DropDownList)e.Row.FindControl("ddlSubjectName");
                DataSet ds = db.ExecuteDataSet("select subject_id 'key',subject_name as value from SubjectMaster where active=1", CommandType.Text);
                ddlSubjectName.DataSource = ds;
                ddlSubjectName.DataValueField = "key";
                ddlSubjectName.DataTextField = "value";
                ddlSubjectName.DataBind();
                ddlSubjectName.Items.Insert(0, "Select");
                HiddenField hdnSubjectdid = (HiddenField)e.Row.FindControl("hdnSubjectid");
                ddlSubjectName.SelectedValue = hdnSubjectdid.Value;

                DropDownList ddlStandardName = (DropDownList)e.Row.FindControl("ddlStandardName");
                ds = db.ExecuteDataSet("select s.standard_id 'key',s.Standard + ' [' + b.board +']' as value from StandardMaster s inner join  boardmaster b on s.board_id=b.board_id where s.active=1", CommandType.Text);
                ddlStandardName.DataSource = ds;
                ddlStandardName.DataValueField = "key";
                ddlStandardName.DataTextField = "value";
                ddlStandardName.DataBind();
                ddlStandardName.Items.Insert(0, "Select");

                HiddenField hdnmStandardID = (HiddenField)e.Row.FindControl("hdnStandardid");
                ddlStandardName.SelectedValue = hdnmStandardID.Value;

            }
        }
    }

    protected void gvChapter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            HiddenField hdnmID = (HiddenField)gvChapter.Rows[e.RowIndex].FindControl("hdnChapterId");
            db.AddParameter("@chapter_id", hdnmID.Value);
            db.AddParameter("@Mode", "Delete");
            db.AddParameter("@created_by", hdnUserid.Value);

            db.ExecuteNonQuery("Save_Edit_Delete_ChapterMaster", CommandType.StoredProcedure);
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
            db.AddParameter("@chapter_name", txtChapterName.Text);
            db.AddParameter("@subject_id", ddlSubject.SelectedValue);
            db.AddParameter("@standard_id", ddlStandard.SelectedValue);
            db.AddParameter("@created_by", hdnUserid.Value);
            db.AddParameter("@Mode", "Insert");

            db.ExecuteNonQuery("Save_Edit_Delete_ChapterMaster", CommandType.StoredProcedure);
            txtChapterName.Text = "";
            ddlSubject.SelectedIndex = 0;
            ddlSubject.Items.Insert(0, "Select");
            ddlStandard.SelectedIndex = 0;
            ddlStandard.Items.Insert(0, "Select");

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
        txtChapterName.Text = "";
        ddlSubject.SelectedIndex = -1;
        ddlStandard.SelectedIndex = -1;

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGrid();

    }

    protected void btnClearSearch_Click(object sender, EventArgs e)
    {
        txtChapterSearch.Text = "";
        ddlSubjectSearch.SelectedIndex = -1;
        ddlStandardSearch.SelectedIndex = -1;
        FillGrid();
    }

    protected void lnkTrash_Click(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();
        if (lnkTrash.Text == "Close")
        {
            dvMain.Visible = true;
            FillGrid();
            FillTrashGrid(true, false);
            gvChapterTrash.DataSource = null;
            gvChapterTrash.DataBind();


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
        //db.AddParameter("@chapter_name", "");
        //db.AddParameter("@subject_id", "0");
        //db.AddParameter("@standard_id", "0");
        db.AddParameter("@active", "0");
        DataSet ds = db.ExecuteDataSet("list_chaptermaster", CommandType.StoredProcedure);

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
            gvChapterTrash.DataSource = ds;
            gvChapterTrash.DataBind();
        }
    }

    protected void gvChapterTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESTORE")
        {
            DatabaseHelper db = new DatabaseHelper();
            db.AddParameter("@chapter_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("update chaptermaster set Active=1 where chapter_id=@chapter_id", CommandType.Text);


            FillGrid();
            FillTrashGrid(false, true);
        }
    }
}