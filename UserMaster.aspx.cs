using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserMaster : System.Web.UI.Page
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
            Util.FillDropDown(ddlMedium, "select * from medium_master where active=1 order by medium", "medium", "medium_id", db);
            Util.FillDropDown(ddlBoard, "select * from board_master where active=1 order by board", "board", "board_id", db);
            Util.FillDropDown(ddlInstitute, "select * from Institute_master where active=1 order by Institute_name", "Institute_name", "Institute_id", db);
            ((MasterPg)this.Master).title = "User Master";


            if (Request.QueryString["uid"] != null)
            {
                hdnUserId.Value = Convert.ToString(Request.QueryString["uid"]);
                db.AddParameter("@user_id", hdnUserId.Value);
                DataSet ds = db.ExecuteDataSet("select * from user_master where user_id=@user_id");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    rblUserType.SelectedValue= Convert.ToString(dr["user_type"]);
                    txtFullName.Text = Convert.ToString(dr["Full_Name"]);
                    txtMobile.Text = Convert.ToString(dr["Mobile"]);
                    rblGender.SelectedValue= Convert.ToString(dr["gender"]);
                    txtEmail.Text = Convert.ToString(dr["email"]);
                    txtLocality.Text = Convert.ToString(dr["locality"]);
                    ddlMedium.SelectedValue = Convert.ToString(dr["medium_id"]) ;
                    ddlInstitute.SelectedValue = Convert.ToString(dr["institute_id"]);
                    ddlBoard.SelectedValue = Convert.ToString(dr["board_id"]);
                    ddlBoard_SelectedIndexChanged(null, null);
                    ddlStandard.SelectedValue = Convert.ToString(dr["standard_id"]);

                    if (Convert.ToString(dr["photo_name"]) == "")
                    {
                        lnkRemovePhoto.Visible = ivPhoto.Visible = false;
                    }
                    else
                    {
                        lnkRemovePhoto.Visible = ivPhoto.Visible = true;
                        ivPhoto.ImageUrl = "user_photos" + "/" + Convert.ToString(dr["photo_name"]);

                    }
                    getBatches();
                    ddlBatch.SelectedValue = Convert.ToString(dr["batch_id"]);

                    if (rblUserType.SelectedValue == "ADMIN")
                    {
                        tblParentView.Visible = tblStudentView.Visible = false;
                    }
                    else if (rblUserType.SelectedValue == "PARENT")
                    {
                        tblParentView.Visible = true;
                        tblStudentView.Visible = false;
                        tblChilds.Visible = true;
                        getChilds();
                    }
                    else if (rblUserType.SelectedValue == "STUDENT")
                    {
                        tblParentView.Visible = tblStudentView.Visible = true;
                    }
                }
            }
        }


    }

    private void getChilds()
    {
        Util.FillDropDown(ddlChild, "select * from user_master where active=1 and user_type='STUDENT' order by full_name", "full_name", "user_id", db);
        getChildList();
    }

    protected void rblUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblUserType.SelectedValue == "ADMIN")
        {
            tblParentView.Visible = tblStudentView.Visible = false;
            tblChilds.Visible = false;
        }
        else if (rblUserType.SelectedValue == "PARENT")
        {
            tblParentView.Visible = true;
            tblStudentView.Visible = false;
            tblChilds.Visible = true;
        }
        else if (rblUserType.SelectedValue == "STUDENT")
        {
            tblParentView.Visible = tblStudentView.Visible = true;
            tblChilds.Visible = false;
        }
    }
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        Util.FillDropDown(ddlStandard, "select * from standard_master where active=1 and board_id=" + ddlBoard.SelectedValue + " order by standard", "standard", "standard_id", db);
        ddlStandard.Focus();
        getBatches();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string file_name=string.Empty, extension = string.Empty ;
        if (fuPhoto.HasFile)
        {
            file_name = fuPhoto.FileName;
            extension = file_name.Substring(file_name.LastIndexOf("."));

            if (extension.ToLower().Equals(".png") || extension.ToLower().Equals(".jpg"))
            {
                file_name = DateTime.Now.ToString().Replace(":", "").Replace("-", "").Replace(" ", "");
                file_name = file_name + "_" + fuPhoto.FileName;
                fuPhoto.SaveAs(Server.MapPath("user_photos") + "/" +file_name);
            }
            else
            {
                lblErrorMsg.Text = "Please select .Png or .Jpg file only";
                return;
            }
        }
        string pwd = string.Empty;
        if (hdnUserId.Value == "0")
        {
            string allowedChars = "";
            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }
            pwd = passwordString;
        }

        db.AddParameter("@user_id", hdnUserId.Value);
        db.AddParameter("@full_name", txtFullName.Text);
        db.AddParameter("@mobile", txtMobile.Text);
        db.AddParameter("@email", txtEmail.Text);
        db.AddParameter("@password", pwd);
        db.AddParameter("@gender", rblGender.SelectedValue);
        db.AddParameter("@locality", txtLocality.Text);
        db.AddParameter("@future_self", "");
        db.AddParameter("@user_type", rblUserType.SelectedValue);
        db.AddParameter("@photo_name", file_name);
        db.AddParameter("@firebase_id", "");
        db.AddParameter("@device_token", "");
        db.AddParameter("@default_password", 1);
        db.AddParameter("@institute_id", ddlInstitute.SelectedValue);
        db.AddParameter("@standard_id", ddlStandard.SelectedValue);
        db.AddParameter("@board_id", ddlBoard.SelectedValue);
        db.AddParameter("@batch_id", ddlBatch.SelectedValue);
        db.AddParameter("@medium_id", ddlMedium.SelectedValue);
        db.AddParameter("@modified_by", Session["UserId"]);

        int user_id = Convert.ToInt16(db.ExecuteScalar("save_user_master", CommandType.StoredProcedure));
        hdnUserId.Value = user_id.ToString();

        if (file_name != string.Empty)
        {
            System.IO.File.Move(Server.MapPath("user_photos") + "/" + file_name, Server.MapPath("user_photos") + "/" + user_id + extension);
            db.AddParameter("@user_id", user_id);
            db.AddParameter("@photo_name", user_id + extension);
            db.ExecuteNonQuery("update user_master set photo_name=@photo_name where user_id=@user_id");
        }
        if (user_id == -1)
            lblErrorMsg.Text = "User already exists.";
        else if (hdnUserId.Value == "0")
        {
            lblErrorMsg.Text = "User Created Successfully.";

            string msg = System.IO.File.ReadAllText(Server.MapPath("templates/welcome_email.txt"));
            msg = msg.Replace("###mobile###", txtMobile.Text);
            msg = msg.Replace("###password###", pwd);
            Common.SendEmail(txtEmail.Text, "Welecome to Rege's Tutorials", msg);

            if (rblUserType.SelectedValue == "PARENT")
            {
                btnSubmit.Visible = false;
                btnClear.Visible = false;
                tblChilds.Visible = true;
                getChilds();
            }
            else
                Response.Redirect("Users.aspx");
        }
        else
            lblErrorMsg.Text = "User Data Saved Successfully.";
        //footer.Visible = true;
        //FillGrid();
    }
    
    protected void btnClear_Click(object sender, EventArgs e)
    {
        hdnUserId.Value = "0";
        rblUserType.SelectedIndex = -1;
        txtFullName.Text = string.Empty;
        txtMobile.Text = string.Empty;
        rblGender.SelectedIndex = -1;
        txtEmail.Text = string.Empty;
        txtLocality.Text = string.Empty;
        ddlMedium.SelectedIndex = -1;
        ddlStandard.SelectedIndex = -1;
        ddlBoard.SelectedIndex = -1;
        ddlInstitute.SelectedIndex = -1;
        tblParentView.Visible = tblStudentView.Visible = true;
        tblChilds.Visible = false;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        db.AddParameter("@parent_id", hdnUserId.Value);
        db.AddParameter("@child_id", ddlChild.SelectedValue);
        int user_id = Convert.ToInt16(db.ExecuteScalar("save_parent_childs", CommandType.StoredProcedure));

        if (user_id == -1)
            lblErrorMsg.Text = "User already exists.";
        else
        {
            getChildList();
            ddlChild.SelectedIndex = -1;
        }
    }

    private void getChildList()
    {
        db.AddParameter("@parent_id", hdnUserId.Value);
        gvChildren.DataSource = db.ExecuteDataSet("get_parent_childs", CommandType.StoredProcedure);
        gvChildren.DataBind();
    }

    protected void gvChildren_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "DEL")
        {

            db.AddParameter("@parent_id", hdnUserId.Value);
            db.AddParameter("@child_id", e.CommandArgument.ToString());
            db.ExecuteNonQuery("remove_parent_childs", CommandType.StoredProcedure);
            getChildList();
        }
    }

    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        getBatches();
    }

    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        getBatches();
    }


    private void getBatches()
    {
        db.AddParameter("@standard_id", ddlStandard.SelectedValue);
        db.AddParameter("@board_id", ddlBoard.SelectedValue);
        db.AddParameter("@medium_id", ddlMedium.SelectedValue);
        Util.FillDropDown(ddlBatch, "select * from batch_master where active=1 and standard_id=@standard_id and board_id=@board_id and medium_id=@medium_id", "batch_name", "batch_id", db);
    }


    protected void lnkRemovePhoto_Click(object sender, EventArgs e)
    {
        db.AddParameter("@user_id", hdnUserId.Value);
        string file_name = Convert.ToString(db.ExecuteScalar("select photo_name from user_master where user_id=@user_id"));

        System.IO.File.Delete(Server.MapPath("user_photos") + "/" + file_name);

        db.AddParameter("@user_id", hdnUserId.Value);
        db.ExecuteNonQuery("update user_master set photo_name='' where user_id=@user_id");
        lnkRemovePhoto.Visible = ivPhoto.Visible = false;
    }
}