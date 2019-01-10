using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class Feedbacks : System.Web.UI.Page
{
      protected void Page_PreInit(object sender, EventArgs e)
    {
     
        if (Request.Cookies["Theme"] != null)
            this.Theme = Request.Cookies["Theme"].Value;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DatabaseHelper db = new DatabaseHelper();
gvFeedbacks.DataSource = db.ExecuteDataSet("select convert(varchar(17), feedback_on, 113)[Feedback Date],Feedback, FullName [Feedback By], Mobile,ChildNumber [Child's Number], 	user_type[User Type] from UserFeedback f inner join usermaster u on f.feedback_by=u.userid order by feedback_on desc");
            gvFeedbacks.DataBind();
             ((MasterPg) this.Master).title= "User Feedback";

        }


    }
}