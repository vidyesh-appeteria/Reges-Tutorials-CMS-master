using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPg : System.Web.UI.MasterPage
{

    public string title
    {
        get { return lblTitle.Text; }
        set { lblTitle.Text= value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
            Response.Redirect("Login.aspx");
      

    }

   
}
