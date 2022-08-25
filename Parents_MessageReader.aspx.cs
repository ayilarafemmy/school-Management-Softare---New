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
    string strConnString = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
    string str;
    SqlCommand com;
    SqlCommand comt;

    SqlCommand cmd = new SqlCommand();
    SqlConnection conx = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(Convert.ToString(Session["PID"])))
        {
            Response.Redirect("parent_login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        Label1.Text = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();

        string exx = Request.QueryString["RelationshipID"];
        if (exx == "")
        {
            Response.Redirect("Parents_Message.aspx");
        }
        if (!this.IsPostBack)
        {
            this.BindGrid();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select concat(b.FirstName, ' ',b.LastName) as Name,SchoolR from D_Message_New a, D_Staff b where a.RelationshipID='" + Request.QueryString["RelationshipID"].ToString() + "' and a.SchoolR = b.StaffID";
            // cmd.CommandText = "select * from D_Examschedule where Examaccesscode='" + exx + "' and Status='Ready'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Message_New");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Label2.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                Label12.Text = ds.Tables[0].Rows[0]["SchoolR"].ToString();
            }
            con.Close();
        }

    }
    protected void Timer1_Tick(object sender, EventArgs e)


    {


        this.BindGrid();


    }
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("select distinct RelationshipID,MID,EndUser,SchoolR,Nature,Message,Status,EntryDate,EntryTime,MessageType,Sender from D_Message_New where EndUser='" + Session["PID"].ToString() + "' and RelationshipID in (select RelationshipID from D_Message_New where RelationshipID='" + Request.QueryString["RelationshipID"].ToString()+ "') order by MID desc"))
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
    void MessageBox(string x)
    {
        // Label1.Text = x;
        try
        {
            string message = x;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload=function(){");

            sb.Append("alert('");

            sb.Append(message);

            sb.Append("')};");

            sb.Append("</script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());


        }
        catch (Exception ex)
        {

        }
    }
    protected void Send_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text =="")
        {
            MessageBox("Kindly Enter the message to be sent");
            return;
        }
        //select  from 
        string jjjsss = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();
        string jjnd = "insert into D_Message_New (EndUser,SchoolR,Nature,Message,Status,EntryDate,EntryTime,MessageType,Sender,RelationshipID) values ('"+Session["PID"].ToString()+"','"+Label12.Text+"','One-Way','"+TextBox1.Text+"','A','"+DateTime.Now.ToString("dd/MM/yyyy")+"','"+DateTime.Now.ToString("hh:mm tt")+"','I','"+ jjjsss + "','"+ Request.QueryString["RelationshipID"] + "')";
        insertRecord(jjnd);
        MessageBox("Sent Successfully");
        TextBox1.Text = "";
    }
    string insertRecord(string query)
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        myConnection.Open();
        try
        {
            SqlCommand cmd = new SqlCommand(query, myConnection);
            cmd.ExecuteNonQuery();
            myConnection.Close();
            return "1";
        }
        catch (Exception ex)
        {
            //MessageBox("at INSERT " + ex.Message);
            return "0" + ex.Message;
        }
    }
}