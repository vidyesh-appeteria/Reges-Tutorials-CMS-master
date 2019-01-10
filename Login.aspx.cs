using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using DAL.SQLDataAccess;

public partial class Login : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //if (Session["Theme"] != null)
        //    this.Theme = Session["Theme"].ToString();
        if (Request.Cookies["Theme"] != null)
            this.Theme = Request.Cookies["Theme"].Value;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["Theme"] != null)
            //    ddlTheme.SelectedValue = Session["Theme"].ToString();
         
        }
    }
    


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();

        db.AddParameter("@Mobile", txtUserName.Text);
        db.AddParameter("@Password", txtPassword.Text);
        DataSet ds = db.ExecuteDataSet("User_Login", CommandType.StoredProcedure);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            if (Convert.ToInt32(dr["user_id"]) == -1)
            {
                lblError.Text = Convert.ToString(dr["error_message"]);
            }
            else if (Convert.ToString(dr["user_type"]) != "ADMIN")
            {
                lblError.Text = "Access Denied";
            }
            else
            {
                Session["UserId"] = Convert.ToInt32(dr["user_id"]);
                Session["Mobile"] = Convert.ToString(dr["Mobile"]);
                Session["UserName"] = Convert.ToString(dr["Full_Name"]);
                Response.Redirect("menu.aspx");
            }
            
        }
        else
        {
            lblError.Text = "Invalid Login Credentials";
        }
        
    }
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

}
