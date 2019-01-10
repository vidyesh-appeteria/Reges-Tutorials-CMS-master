using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SQLDataAccess;
using System.Web.UI.DataVisualization.Charting;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.Cookies["Theme"] != null)
            this.Theme = Request.Cookies["Theme"].Value;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        DatabaseHelper db = new DatabaseHelper();

        if (!IsPostBack)
        {
            //db.AddParameter("@type", "User");
            //DataSet ds = db.ExecuteDataSet("dashboard", CommandType.StoredProcedure);
            //chUsers.DataSource = ds;
            //chUsers.DataBind();
            //setChart(chUsers, ds,"Recent 10 days");

            //db.AddParameter("@type", "Teacher");
            //ds = db.ExecuteDataSet("dashboard", CommandType.StoredProcedure);
            //chTeachers.DataSource = ds;
            //chTeachers.DataBind();
            //setChart(chTeachers, ds,"Top 10");


            //db.AddParameter("@type", "Earning");
            //ds = db.ExecuteDataSet("dashboard", CommandType.StoredProcedure);
            //chEarning.DataSource = ds;
            //chEarning.DataBind();
            //setChart(chEarning, ds, "Recent 10 days");


            //db.AddParameter("@type", "ActiveTeacher");
            //ds = db.ExecuteDataSet("dashboard", CommandType.StoredProcedure);
            //chActiveTeachers.DataSource = ds;
            //chActiveTeachers.DataBind();
            //setChart(chActiveTeachers, ds, "Top 10");

            //db.AddParameter("@type", "ActiveStudent");
            //ds = db.ExecuteDataSet("dashboard", CommandType.StoredProcedure);
            //chActiveStudents.DataSource = ds;
            //chActiveStudents.DataBind();
            //setChart(chActiveStudents, ds, "Top 10");

            //db.AddParameter("@type", "TeacherEarning");
            //ds = db.ExecuteDataSet("dashboard", CommandType.StoredProcedure);
            //chTeacherEarning.DataSource = ds;
            //chTeacherEarning.DataBind();
            //setChart(chTeacherEarning, ds, "Top 10");
        }

    }

    private void setChart(Chart chart, DataSet ds, string title)
    {
        if (ds.Tables.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            //string[] y = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            chart.Series[0].Points.DataBindXY(x, y);
            //  chUsers.Series[0].ChartType = SeriesChartType.StackedColumn;
            //setReportType();
            chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            chart.Legends[0].Enabled = true;
          
            chart.Titles[0].Text = title;
            chart.Titles[0].ShadowColor = System.Drawing.Color.White;

            //if (ddlChartType.SelectedValue == "STROKE")
            //    chUsers.Series[0].LegendText = ddlChartType.SelectedItem.Text + " Count";
            //else
            //    chUsers.Series[0].LegendText = ddlChartType.SelectedItem.Text + " Minutes";

            //if (chUsers.Titles.Count > 0)
            //    chUsers.Titles.RemoveAt(0);
            //chUsers.Titles.Add("Weekly Report");

            //if (chUsers.Series.Count > 0)
            //    chUsers.Series.RemoveAt(0);
            //chUsers.Series.Insert(0, new Series(ddlChartType.SelectedItem.Text + " Count"));

            chart.Series[0].IsValueShownAsLabel = true;
        }
    }





    protected void chUsers_Click(object sender, ImageMapEventArgs e)
    {
        Response.Redirect("Users.aspx");

    }

    protected void chTeachers_Click(object sender, ImageMapEventArgs e)
    {
        Response.Redirect("TeacherFollowers.aspx");

    }

    protected void chEarning_Click(object sender, ImageMapEventArgs e)
    {
        Response.Redirect("Earning.aspx");

    }

    protected void chActiveTeachers_Click(object sender, ImageMapEventArgs e)
    {
        Response.Redirect("TeacherAnswers.aspx");
    }

    protected void Chart1_Click(object sender, ImageMapEventArgs e)
    {

    }

    protected void chActiveStudents_Click(object sender, ImageMapEventArgs e)
    {
        Response.Redirect("QuestionsAsked.aspx");
    }

    protected void chTeacherEarning_Click(object sender, ImageMapEventArgs e)
    {
        Response.Redirect("TeacherEarning.aspx");
    }
}