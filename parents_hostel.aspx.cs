using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Drawing;

public partial class Parents_Message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(Convert.ToString(Session["PID"])))
        {
            Response.Redirect("parent_login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        Label1.Text = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();


        if (!this.IsPostBack)
        {
            this.BindGrid();
        }

    }
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("select b.ExamDate, a.Fclass,b.SID,b.Examaccesscode,concat(c.FirstName,' ',c.LastName) as Name,'You will need SID and examaccesscode to write exams, also note the exam date, exam must be taken that date' as Information from D_Classes a,D_Examschedule b,D_Students c where a.ClassID = b.ExamClass and c.SID = b.SID and b.ExamStatus='P' and c.Status='WE' and Parent_ID='99999999999999999999999999999'"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
}