using DAL.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConfigMaster : System.Web.UI.Page
{
    DatabaseHelper db = new DatabaseHelper();
    protected void Page_PreInit(object sender, EventArgs e)
    {

        if (Request.Cookies["Theme"] != null)
            this.Theme = Request.Cookies["Theme"].Value;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    ((MasterPg)this.Master).title = "Configuration";

        //    if (Request.Cookies["Theme"] != null)
        //        ddlTheme.SelectedValue = Request.Cookies["Theme"].Value;

        //    DataSet ds = db.ExecuteDataSet("select * from configurationmaster", CommandType.Text);
        //    txtChatDuration.Text = ds.Tables[0].Rows[0]["ChatDuration"].ToString();
        //    txtmaxchatduration.Text = ds.Tables[0].Rows[0]["maxchatduration"].ToString();

        //    txtRatePerStar.Text = ds.Tables[0].Rows[0]["RatePerStar"].ToString();

        //    txttimerduration.Text = ds.Tables[0].Rows[0]["timerduration"].ToString();
        //    txtmaxchatwithteacher.Text = ds.Tables[0].Rows[0]["maxchatwithteacher"].ToString();
        //    txtFreeTrailDays.Text = ds.Tables[0].Rows[0]["freetraildays"].ToString();

        //    txtMinPaymentAmt.Text = ds.Tables[0].Rows[0]["MinAmountForPayment"].ToString();
        //    txtRatePerStarForWall.Text = ds.Tables[0].Rows[0]["RatePerStarForWall"].ToString();
        //}
        lblErrorMsg.Text = "";


    }

    protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["Theme"] = ddlTheme.SelectedValue;


        HttpCookie Cookie = new HttpCookie("Theme");
        Cookie.Value = ddlTheme.SelectedValue;
        Cookie.Expires = DateTime.MaxValue; // never expire
        HttpContext.Current.Response.Cookies.Add(Cookie);
        Response.Redirect("Configmaster.aspx");
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {



            db.AddParameter("@ChatDuration", txtChatDuration.Text);
            db.AddParameter("@RatePerStar", txtRatePerStar.Text);
            db.AddParameter("@maxchatduration", txtmaxchatduration.Text);
            db.AddParameter("@timerduration", txttimerduration.Text);
            db.AddParameter("@maxchatwithteacher", txtmaxchatwithteacher.Text);
            db.AddParameter("@freetraildays", txtFreeTrailDays.Text);
            db.AddParameter("@Mode", "Update");
            db.AddParameter("@MinAmountForPayment", txtMinPaymentAmt.Text);
            db.AddParameter("@RatePerStarForWall", txtRatePerStarForWall.Text);

            db.ExecuteNonQuery("Save_Edit_Delete_configurationmaster", CommandType.StoredProcedure);

            lblErrorMsg.Text = "Configuration Saved Successfully.";

        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }


    }


}