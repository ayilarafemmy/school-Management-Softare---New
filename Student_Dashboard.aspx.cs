using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class Admin_Dashboard : System.Web.UI.Page
{
 

    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    SqlCommand cmd1 = new SqlCommand();
    SqlConnection con1 = new SqlConnection();
    SqlDataAdapter sda1 = new SqlDataAdapter();
    DataSet ds1 = new DataSet();

    SqlCommand cmd2 = new SqlCommand();
    SqlConnection con2 = new SqlConnection();
    SqlDataAdapter sda2 = new SqlDataAdapter();
    DataSet ds2 = new DataSet();

    SqlCommand cmd3 = new SqlCommand();
    SqlConnection con3 = new SqlConnection();
    SqlDataAdapter sda3 = new SqlDataAdapter();
    DataSet ds3 = new DataSet();

    SqlCommand cmd4 = new SqlCommand();
    SqlConnection con4 = new SqlConnection();
    SqlDataAdapter sda4 = new SqlDataAdapter();
    DataSet ds4 = new DataSet();

    SqlCommand cmd5 = new SqlCommand();
    SqlConnection con5 = new SqlConnection();
    SqlDataAdapter sda5 = new SqlDataAdapter();
    DataSet ds5 = new DataSet();

    SqlCommand cmd6 = new SqlCommand();
    SqlConnection con6 = new SqlConnection();
    SqlDataAdapter sda6 = new SqlDataAdapter();
    DataSet ds6 = new DataSet();

    SqlCommand cmd7 = new SqlCommand();
    SqlConnection con7 = new SqlConnection();
    SqlDataAdapter sda7 = new SqlDataAdapter();
    DataSet ds7 = new DataSet();

    SqlCommand cmd8 = new SqlCommand();
    SqlConnection con8 = new SqlConnection();
    SqlDataAdapter sda8 = new SqlDataAdapter();
    DataSet ds8 = new DataSet();

    SqlCommand cmd8a = new SqlCommand();
    SqlConnection con8a = new SqlConnection();
    SqlDataAdapter sda8a = new SqlDataAdapter();
    DataSet ds8a = new DataSet();

    SqlCommand cmd8b = new SqlCommand();
    SqlConnection con8b = new SqlConnection();
    SqlDataAdapter sda8b = new SqlDataAdapter();
    DataSet ds8b = new DataSet();

    SqlCommand cmd8c = new SqlCommand();
    SqlConnection con8c = new SqlConnection();
    SqlDataAdapter sda8c = new SqlDataAdapter();
    DataSet ds8c = new DataSet();


    SqlCommand cmd8d = new SqlCommand();
    SqlConnection con8d = new SqlConnection();
    SqlDataAdapter sda8d = new SqlDataAdapter();
    DataSet ds8d = new DataSet();

    SqlCommand cmd8e = new SqlCommand();
    SqlConnection con8e = new SqlConnection();
    SqlDataAdapter sda8e = new SqlDataAdapter();
    DataSet ds8e = new DataSet();

    SqlCommand cmd9 = new SqlCommand();
    SqlConnection con9 = new SqlConnection();
    SqlDataAdapter sda9 = new SqlDataAdapter();
    DataSet ds9 = new DataSet();

    SqlCommand cmd10 = new SqlCommand();
    SqlConnection con10 = new SqlConnection();
    SqlDataAdapter sda10 = new SqlDataAdapter();
    DataSet ds10 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
   

        if (string.IsNullOrEmpty(Convert.ToString(Session["SID"])))
        {
            Response.Redirect("student_login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
  
            Label12.Text = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();
       
        try { 
        Label10.Text = ConfigurationManager.AppSettings["Institution"];
            Image1.ImageUrl = ConfigurationManager.AppSettings["InstitutionLogo"];
        string qq = "select SID,FirstName,LastName,Gender,DOB,Roll_No,BG,Religion from  D_Students where SID='" + Session["SID"].ToString() + "'";
        ListViewBind(qq);
        string qqa = "Select Notice from D_Notices where Status='A'";
         GridViewBind(qqa);
            string qqb = "select Top 5 Notice,Enteredby as SentBy, EntryDate as SendDate from D_Notices where Recipients ='All' and Status='A' order by NID desc";
            GridViewBind3(qqb);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        con.Open();
        cmd3.CommandText = "SELECT sum(CAST(amount AS INT)) as newam FROM D_Account";
        cmd3.Connection = con;
        sda3.SelectCommand = cmd3;
        sda3.Fill(ds3, "D_Account");
            Decimal kk =Decimal.Parse( ds3.Tables[0].Rows[0]["newam"].ToString());
            var separator = new System.Globalization.NumberFormatInfo()
            {
                NumberDecimalDigits = 0,
                NumberGroupSeparator = ","
            };
              cmd7.CommandText = "SELECT sum(CAST(amount AS INT)) as i0 FROM D_Account where destination != 'Expenses' and EntryDate  like '%/" + DateTime.Now.ToString("MM/yyyy") + "'";
            cmd7.Connection = con;
            sda7.SelectCommand = cmd7;
            sda7.Fill(ds7, "D_Account");
           string k1 = ds7.Tables[0].Rows[0]["i0"].ToString();
           
            cmd6.CommandText = "SELECT sum(CAST(amount AS INT)) as ii FROM D_Account where destination = 'Expenses' and EntryDate  like '%/" + DateTime.Now.ToString("MM/yyyy") + "'";
            cmd6.Connection = con;
            sda6.SelectCommand = cmd6;
            sda6.Fill(ds6, "D_Account");
            string ee = ds6.Tables[0].Rows[0]["ii"].ToString();
            if (ee.ToString() != "")
            {
                Decimal eea = Decimal.Parse(ee);
            }
            else
            {
          
            }
            //cmd.CommandText = "select count(SID) as sid from D_students";
            //cmd.Connection = con;
            //sda.SelectCommand = cmd;
            //sda.Fill(ds, "D_students");
            //Label5.Text = ds.Tables[0].Rows[0]["sid"].ToString();
            //cmd2.CommandText = "select count(PID) as SN from D_Parents";
            //cmd2.Connection = con;
            //sda2.SelectCommand = cmd2;
            //sda2.Fill(ds2, "D_Parents");
            //Label6.Text = ds2.Tables[0].Rows[0]["SN"].ToString();
            //Label15.Text = ds2.Tables[0].Rows[0]["SN"].ToString();
            //cmd1.CommandText = "select count(StaffID) as StaffID from D_Staff";
            //cmd1.Connection = con;
            //sda1.SelectCommand = cmd1;
            //sda1.Fill(ds1, "D_Staff");
            //Label7.Text = ds1.Tables[0].Rows[0]["StaffID"].ToString();
            //Label14.Text = ds1.Tables[0].Rows[0]["StaffID"].ToString();

            cmd4.CommandText = "select CONCAT(Year,'-',Period) as Term from D_Session where Status='Open'";
            cmd4.Connection = con;
            sda4.SelectCommand = cmd4;
            sda4.Fill(ds4, "D_Session");
            Label8.Text = ds4.Tables[0].Rows[0]["Term"].ToString();
            cmd5.CommandText = "select count(StaffID) as StaffIDx from D_Staff where SecondaryRole='Teacher'";
            //cmd5.Connection = con;
            //sda5.SelectCommand = cmd5;
            //sda5.Fill(ds5, "D_Staff");
            //Label9.Text = ds5.Tables[0].Rows[0]["StaffIDx"].ToString();
            

            cmd8a.CommandText = "select concat(Photo,filetype) as profile,FirstName as Name,Concat(FirstName,' ',LastName) as FullName,Gender as SecondaryRole from D_Students where SID='" + Session["SID"].ToString() + "'";
            cmd8a.Connection = con;
            sda8a.SelectCommand = cmd8a;
            sda8a.Fill(ds8a, "D_Students");
            string jj = ds8a.Tables[0].Rows[0]["profile"].ToString();
            Label11.Text = ds8a.Tables[0].Rows[0]["Name"].ToString();          
            Image2.ImageUrl = "~/Students/" + jj+"";

            cmd8b.CommandText = "select Balance as bal from D_Students where SID='"+Session["SID"].ToString()+"'";
            cmd8b.Connection = con;
            sda8b.SelectCommand = cmd8b;
            sda8b.Fill(ds8b, "D_Students");
            Label16.Text = ds8b.Tables[0].Rows[0]["bal"].ToString();

            cmd8c.CommandText = "select concat(a.FirstName,' ',a.LastName) as Teacher from D_Staff a,D_Classes b,D_Students c where a.StaffID = b.Teacher and c.Class = b.ClassID and c.SID='"+Session["SID"].ToString()+"'";
            cmd8c.Connection = con;
            sda8c.SelectCommand = cmd8c;
            sda8c.Fill(ds8c, "D_Staff");
            Label17.Text = ds8c.Tables[0].Rows[0]["Teacher"].ToString();
            cmd8d.CommandText = "select a.FClass as Class from D_Classes a,D_Students b where a.ClassID = b.Class and b.SID='"+Session["SID"].ToString()+"'";
            cmd8d.Connection = con;
            sda8d.SelectCommand = cmd8d;
            sda8d.Fill(ds8d, "D_Classes");
            Label18.Text = ds8d.Tables[0].Rows[0]["Class"].ToString();
            cmd8e.CommandText = "select a.Route as Route from D_Routes a,D_Students b where a.RoutesID = b.RouteID and b.SID = '"+Session["SID"].ToString()+"'";
            cmd8e.Connection = con;
            sda8e.SelectCommand = cmd8e;
            sda8e.Fill(ds8e, "D_Students");
            Label19.Text = ds8e.Tables[0].Rows[0]["Route"].ToString();


            con.Close();
        }
        catch (Exception u)
        {

        }

        if (!this.IsPostBack)
        {
           // Bindchart();
            string jjjj = "select b.Day, a.Subject,b.Period,concat(c.FirstName,' ',c.LastName) as Teacher  from D_Subjects a, D_Period b,D_Staff c,D_Students d, D_Classes e where a.SubjectID = b.Subject and c.StaffID = b.Teacher and e.ClassID = B.ClassID and d.Class = B.ClassID and d.SID = '"+Session["SID"].ToString()+"'";
            GridViewBind2(jjjj);

            //name,gender,fclass,photo
            //string constr = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(constr))
            //{
            //    using (SqlDataAdapter sda = new SqlDataAdapter("select SID as ID, Concat(FirstName,' ',LastName) as Name, Concat(Photo,filetype) from d_students", conn))
            //    {
            //        DataTable dt = new DataTable();
            //        sda.Fill(dt);
            //        gvImages.DataSource = dt;
            //        gvImages.DataBind();
            //    }
            //}
        }

    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);


        // SqlConnection con = new SqlConnection(connstring);

        SqlCommand myQuery = con.CreateCommand();
        myQuery.CommandText = @"select Event,EventDate from D_Events;";
        SqlDataReader myReader;
        con.Open();
        myReader = myQuery.ExecuteReader();
        DataTable dataTable = new DataTable();
        dataTable.Load(myReader);
        foreach (DataRow row in dataTable.Rows)
        {
            if (Convert.ToDateTime(e.Day.Date) == Convert.ToDateTime(row["EventDate"]))
            {
                e.Cell.Controls.Add(new Label { Text = "<br/>" });
                e.Cell.Controls.Add(new Label { Text = row["Event"].ToString() });
            }
        }
        con.Close();
    }
    protected void ListViewBind(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DetailsView1.DataSource = dr;
                DetailsView1.DataBind();
                con.Close();
            }
        }
        catch (Exception kk)
        {
            string success = "Possibe Network issue " + kk + "";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + success + "');", true);
            return;
        }
    }
    protected void GridViewBind(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                con.Close();
            }
        }
        catch (Exception kk)
        {
            string success = "Possibe Network issue " + kk + "";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + success + "');", true);
            return;
        }
    }
    protected void GridViewBind2(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView2.DataSource = dr;
                GridView2.DataBind();
                con.Close();
            }
        }
        catch (Exception kk)
        {
            string success = "Possibe Network issue " + kk + "";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + success + "');", true);
            return;
        }
    }
    protected void GridViewBind3(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView3.DataSource = dr;
                GridView3.DataBind();
                con.Close();
            }
        }
        catch (Exception kk)
        {
            string success = "Possibe Network issue " + kk + "";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + success + "');", true);
            return;
        }
    }

    private void Bindchart()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        con.Open();
        string query = "select Date,count(Status) as status from D_Attendance where status='Present' group by Date";//not recommended this i have written just for example,write stored procedure for security    
        SqlCommand com = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable ChartData = ds.Tables[0];
        //storing total rows count to loop on each Record    
        string[] XPointMember = new string[ChartData.Rows.Count];
        int[] YPointMember = new int[ChartData.Rows.Count];
        for (int count = 0; count < ChartData.Rows.Count; count++)
        {
            //storing Values for X axis    
            XPointMember[count] = ChartData.Rows[count]["Date"].ToString();
            //storing values for Y Axis    
            YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Status"]);
        }
        //binding chart control    
        Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);
        //Setting width of line    
        Chart1.Series[0].BorderWidth = 1;
        //setting Chart type     
        Chart1.Series[0].ChartType = SeriesChartType.Line;

        Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        Chart1.Series[0].ChartType = SeriesChartType.Bar;
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
        Chart1.ChartAreas[0].AxisX.Title = "Dates";
        Chart1.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.DarkBlue;
        Chart1.ChartAreas[0].AxisY.Title = "Number of Students Present";
        Chart1.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.DarkBlue;
        Chart1.ChartAreas[0].AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
        Chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;
        con.Close();
    }
    
}