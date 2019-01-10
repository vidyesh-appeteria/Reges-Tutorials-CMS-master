using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
public partial class Contacted : System.Web.UI.Page
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
              ((MasterPg) this.Master).title= "User Contacted";
            DatabaseHelper db = new DatabaseHelper();
gvContacted.DataSource = db.ExecuteDataSet("select convert(varchar(17), contact_on, 113)[Contacted Date],Contact_mode [Contact Mode], branch_name [Branch Name] , FullName [Contacted By], Mobile, ChildNumber[Child's Number], 	user_type[User Type]from contact c inner join usermaster u on c.contact_by = u.userid inner join branchmaster b on c.branch_id=b.branch_id order by contact_on desc");
            gvContacted.DataBind();

        }


    }
}