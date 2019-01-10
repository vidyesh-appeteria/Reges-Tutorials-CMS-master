using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;

public partial class appupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataSet ds;
            try
            {
                ds = db.ExecuteDataSet("select * from app_update_details");
                if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    txtAppVersion.Text = Convert.ToString(dr["app_version"]);
                    chkForceUpdate.Checked = Convert.ToBoolean(dr["force_update"]);
                    txtWhatsNew.Text = Convert.ToString(dr["whats_new"]);

                }

            }
            catch (Exception ex)
            {


                lblErrorMsg.Text = ex.Message.ToString();
            }
            

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();
        try
        {
            db.AddParameter("@app_version", txtAppVersion.Text);
            db.AddParameter("@force_update", chkForceUpdate.Checked ? 1 : 0);
            db.AddParameter("@whats_new", txtWhatsNew.Text);
            db.ExecuteNonQuery("save_app_update_details", CommandType.StoredProcedure);
            lblErrorMsg.Text = "Information updated successfully";
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }

    }
}