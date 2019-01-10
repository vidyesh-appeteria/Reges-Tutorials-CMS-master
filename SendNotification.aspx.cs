using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public partial class SendNotification : System.Web.UI.Page
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
            //FillGrid();
            
            ((MasterPg)this.Master).title = "Send Notification";
            Util.FillDropDownAll(ddlMedium, "select * from medium_master where active=1 order by medium", "medium", "medium_id", db);
            Util.FillDropDownAll(ddlBoard, "select * from board_master where active=1 order by board", "board", "board_id", db);            
            Util.FillDropDownAll(ddlStandard, "select * from standard_master where active=1 and board_id=" + ddlBoard.SelectedValue + " order by standard", "standard", "standard_id", db);

            FillGrid();
            //FillTrashGrid(true, false);
        }
        lblErrorMsg.Text = "";

    }


    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        Util.FillDropDownAll(ddlStandard, "select * from standard_master where active=1 and board_id=" + ddlBoard.SelectedValue + " order by standard", "standard", "standard_id", db);
        getBatches();
        ddlStandard.Focus();
    }


    private void getBatches()
    {
        db.AddParameter("@standard_id", ddlStandard.SelectedValue);
        db.AddParameter("@board_id", ddlBoard.SelectedValue);
        db.AddParameter("@medium_id", ddlMedium.SelectedValue);
        Util.FillDropDownAll(ddlBatch, "select * from batch_master where active=1 and standard_id=@standard_id and board_id=@board_id and medium_id=@medium_id", "batch_name", "batch_id", db);
    }




    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string fileName = "";

        if (imgImage.Visible)
        {
            //= "test.png";\
            fileName = imgImage.ImageUrl.Substring(imgImage.ImageUrl.LastIndexOf("/")+1);

        }
        else
        {
            fileName = fuImage.PostedFile.FileName;
        }
        
        if (txtDescription.Text.Trim() == string.Empty && fileName== string.Empty && txtLink.Text.Trim() == string.Empty)
        {
            lblErrorMsg.Text = "Enter Description/Link or select Image";
            return;
        }

        else if (txtLink.Text.Trim() != string.Empty && !txtLink.Text.StartsWith("http"))
        {
            lblErrorMsg.Text = "Enter proper Link";
            return;
        }

        if (fuImage.HasFile)
        {
            fileName = fuImage.PostedFile.FileName;
            string extesion = fileName.Substring(fileName.LastIndexOf("."));

            if (extesion != ".jpg" && extesion != ".png")
            {
                lblErrorMsg.Text = "Please select image of type .jpg, .png.";
                return;
            }
            string path = HttpContext.Current.Server.MapPath("~/") + @"/notification_images/" + fileName;
            fuImage.SaveAs(path);
        }

        db.AddParameter("@notification_id", hdnNotificationId.Value);
        db.AddParameter("@title", txtTittle.Text);
        db.AddParameter("@description", txtDescription.Text);
        db.AddParameter("@link", txtLink.Text);
        db.AddParameter("@file_name", fileName);
        db.AddParameter("@created_by", Session["UserId"]);
        db.AddParameter("@user_type", ddlUserType.SelectedValue);
        db.AddParameter("@board_id", ddlBoard.SelectedValue);
        db.AddParameter("@standard_id", ddlStandard.SelectedValue);
        db.AddParameter("@medium_id", ddlMedium.SelectedValue);
        db.AddParameter("@batch_id", ddlBatch.SelectedValue);
        int notificationId = Convert.ToInt16(db.ExecuteScalar("save_custom_notifications", CommandType.StoredProcedure));

        FCMPushNotification notify = new FCMPushNotification();
        
        db.AddParameter("@user_type", ddlUserType.SelectedValue);
        db.AddParameter("@board_id", ddlBoard.SelectedValue);
        db.AddParameter("@standard_id", ddlStandard.SelectedValue);
        db.AddParameter("@medium_id", ddlMedium.SelectedValue);
        db.AddParameter("@batch_id", ddlBatch.SelectedValue);
        DataSet ds = db.ExecuteDataSet("get_custom_notifications_users", CommandType.StoredProcedure);
        if (ds.Tables.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string deviceID = Convert.ToString(dr["device_token"]);
                if (txtDescription.Text.Trim() == string.Empty && fuImage.PostedFile.FileName == string.Empty && txtLink.Text.Trim() != string.Empty)
                    notify.SendNotification("Rege's Tutorials", txtTittle.Text, "", deviceID, notificationId, "", "com.appeteria.regestutorials.TARGET_CUSTOM", "link", 0);
                else
                    notify.SendNotification("Rege's Tutorials", txtTittle.Text, "", deviceID, notificationId, "", "com.appeteria.regestutorials.TARGET_CUSTOM", "custom", 0);
            }
        }
        FillGrid();
        btnClear_Click(null, null);

    }
 





    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtTittle.Text = "";
        txtDescription.Text = "";
        imgImage.Visible = false;
        txtLink.Text = "";
        fuImage.Attributes.Clear();
        //fuImage.PostedFile.c

    }


    public void FillGrid()
    {

        DataSet ds = db.ExecuteDataSet("select *  from custom_notifications  order by notification_date desc");

        gvNotifications.DataSource = ds;
        gvNotifications.DataBind();

    }




    public void displayError()
    {
        Page.Master.FindControl("footer").Visible = true;
        Label lt = Page.Master.FindControl("lblAlertError") as Label;
        lt.Text = Session["Message"].ToString();
        Session["Message"] = null;
    }


     

    protected void gvNotifications_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "RESEND")
        {

            //hdnNotificationId.Value = e.CommandArgument.ToString();
            db.AddParameter("@notification_id", e.CommandArgument.ToString());
            DataSet ds = db.ExecuteDataSet("select title,description,link,isnull(user_type,0)user_type,isnull(board_id,0) board_id,isnull(standard_id,0)standard_id, file_name  from custom_notifications where notification_id=@notification_id");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];

                txtTittle.Text = Convert.ToString(dr["title"]);
                txtDescription.Text = Convert.ToString(dr["description"]);
                ddlBoard.SelectedValue = Convert.ToString(dr["board_id"]);
                ddlBoard_SelectedIndexChanged(null, null);
                ddlStandard.SelectedValue = Convert.ToString(dr["standard_id"]);

                ddlUserType.SelectedValue = Convert.ToString(dr["user_type"]);
                txtLink.Text = Convert.ToString(dr["link"]);
                lnkImage.HRef = "/notification_images/"+ Convert.ToString(dr["file_name"]);
                imgImage.Visible = true;
                imgImage.ImageUrl = "/notification_images/" +  Convert.ToString(dr["file_name"]); 

            }
            

        }
       
    }

  

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        fuImage.Attributes.Clear();

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
/*



protected void gvCouponCode_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
    gvCouponCode.PageIndex = e.NewPageIndex;
    gvCouponCode.DataBind();
    FillGrid();
}


protected void gvCouponCode_RowEditing(object sender, GridViewEditEventArgs e)
{
    gvCouponCode.EditIndex = e.NewEditIndex;

    FillGrid();

}

protected void gvCouponCode_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
    TextBox txtcouponCodeName = (TextBox)gvCouponCode.Rows[e.RowIndex].FindControl("txtcouponCodeName");
    TextBox txtValidTillDate = (TextBox)gvCouponCode.Rows[e.RowIndex].FindControl("txtValidTillDate");
    TextBox txtcouponCodeTotalCount = (TextBox)gvCouponCode.Rows[e.RowIndex].FindControl("txtcouponCodeTotalCount");
    TextBox txtcouponCodeDiscount = (TextBox)gvCouponCode.Rows[e.RowIndex].FindControl("txtcouponCodeDiscount");
    DropDownList ddlCouponCodeDiscountType = (DropDownList)gvCouponCode.Rows[e.RowIndex].FindControl("ddlCouponCodeDiscountType");
    Label lblCouponCodeDiscountType = (Label)gvCouponCode.Rows[e.RowIndex].FindControl("lblCouponCodeDiscountType");

   // n ddlCouponCodeDiscountType.SelectedItem.Text = lblCouponCodeDiscountType.Text;

    HiddenField hdnmID = (HiddenField)gvCouponCode.Rows[e.RowIndex].FindControl("hdnCouponId");
    db.AddParameter("@coupon_code", txtcouponCodeName.Text);
    db.AddParameter("@Coupon_id", hdnmID.Value);
    db.AddParameter("@valid_till",Convert.ToDateTime(txtValidTillDate.Text));
    db.AddParameter("@coupon_count", txtcouponCodeTotalCount.Text);
    db.AddParameter("@discount", txtcouponCodeDiscount.Text);
    db.AddParameter("@Mode", "Update");
    db.AddParameter("@created_by", hdnUserid.Value);
    db.AddParameter("@discount_type", ddlCouponCodeDiscountType.SelectedValue);
    db.ExecuteNonQuery("Save_Edit_Delete_couponcode", CommandType.StoredProcedure); lblErrorMsg.Text = "Updated Successfully.";
    //displayError();
    gvCouponCode.EditIndex = -1;

    FillGrid();
    FillTrashGrid(true, false);

}

protected void gvCouponCode_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
{
    e.Cancel = true;
    gvCouponCode.EditIndex = -1;
    FillGrid();

}

protected void gvCouponCode_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
    HiddenField hdnmID = (HiddenField)gvCouponCode.Rows[e.RowIndex].FindControl("hdnCouponId");
    db.AddParameter("@Coupon_id", hdnmID.Value);
    db.AddParameter("@Mode", "Delete");
    db.AddParameter("@created_by", hdnUserid.Value);

    db.ExecuteNonQuery("Save_Edit_Delete_couponcode", CommandType.StoredProcedure);
    lblErrorMsg.Text = "Deleted Successfully.";
    //displayError();
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
        gvCouponCodeTrash.DataSource = null;
        gvCouponCodeTrash.DataBind();


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
    DataSet ds = db.ExecuteDataSet("select coupon_id, coupon_code, replace(convert(varchar(12),valid_till,106),' ','-')valid_till, coupon_count, discount from couponcode where active=0 order by coupon_id desc");

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
        gvCouponCodeTrash.DataSource = ds;
        gvCouponCodeTrash.DataBind();
    }
}

protected void gvCouponCodeTrash_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if (e.CommandName.ToString() == "RESTORE")
    {
        DatabaseHelper db = new DatabaseHelper();
        db.AddParameter("@chapter_id", e.CommandArgument.ToString());
        db.ExecuteNonQuery("update couponcode set Active=1 where Coupon_id=@Coupon_id", CommandType.Text);


        FillGrid();
        FillTrashGrid(false, true);
    }
}






}*/
