using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net.Mail;
using System.Net;

public partial class forgotpass_admin : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    SqlCommand cmd1 = new SqlCommand();
    SqlConnection con1 = new SqlConnection();
    SqlDataAdapter sda1 = new SqlDataAdapter();
    DataSet ds1 = new DataSet();

    string sendmail = ConfigurationManager.AppSettings["SendEmail"];
    string SendSMS = ConfigurationManager.AppSettings["SendSMS"];
    string ServerName = ConfigurationManager.AppSettings["ServerName"];
    string SenderEmail = ConfigurationManager.AppSettings["SenderEmail"];
    string ServerPort = ConfigurationManager.AppSettings["ServerPort"];
    string Mail_Password = ConfigurationManager.AppSettings["Mail_Password"];
    string Institution = ConfigurationManager.AppSettings["Institution"];
    string URL = ConfigurationManager.AppSettings["URL"];
    string AdminEmail = ConfigurationManager.AppSettings["AdminEmail"];
    string SMSID = ConfigurationManager.AppSettings["SMSID"];
    string SMS_Email = ConfigurationManager.AppSettings["SMS_Email"];
    string SMS_Password = ConfigurationManager.AppSettings["SMS_Password"];
    string SMS_Sender = ConfigurationManager.AppSettings["SMS_Sender"];
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelza.Text = ConfigurationManager.AppSettings["Institution"];
        string joe = ConfigurationManager.AppSettings["InstitutionLogo"];
        Image1.ImageUrl = joe;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Label1.Visible = false;
            if (TextBox1.Text.Length < 2)
            {
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                Label1.Text = "Kindly provide Email Address";
            }

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select * from D_Staff where Email='" + TextBox1.Text + "' and Role='Administrator'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Staff");

            if (ds.Tables[0].Rows.Count > 0)
            {
                string staffID = ds.Tables[0].Rows[0]["StaffID"].ToString();
                string FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                String LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                String Email = ds.Tables[0].Rows[0]["Email"].ToString();
                Random rd = new Random();
                String EE = rd.Next(10000, 99999).ToString();
                string ps = FirstName +"_" + EE;

                //update password
                string uo = "Update D_Staff set Password='"+ps+"' where Email='"+TextBox1.Text+"'";
                insertRecord(uo);

                //send mail
                if (sendmail == "Yes")
                {

                    
                    int joe = int.Parse(ServerPort);
                    string StaffMail = ""+URL+""+Environment.NewLine+""+Environment.NewLine+"Your ID : " + staffID + "" + Environment.NewLine + "Dear " + FirstName + " "+LastName+"," + Environment.NewLine + "" + Environment.NewLine + "You have Successfully done Password reset on " + Institution + " App" + Environment.NewLine + " " + Environment.NewLine + " New Password is: " + ps + " "+Environment.NewLine+" "+Environment.NewLine+"With Love from the team at"+ ConfigurationManager.AppSettings["Institution"] + "";
                    SendMail(Email, StaffMail, "Password Reset Successful", ServerName, SenderEmail, Institution, Mail_Password, joe);
                }
                Label1.Visible = true;
                Label1.ForeColor = Color.Green;
                Label1.Text = "Password sent to your email address: " + Email + "";
           



            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                Label1.Text = "Email Provided is invalid!";
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "1;url=  forgotpass_admin.aspx";
                this.Page.Controls.Add(meta);
            }

            con.Close();
        }
        catch (Exception oa)
        {
            Label1.Visible = true;
            Label1.ForeColor = Color.DarkRed;
            Label1.Text = "Error is " + oa + "";
            return;
        }
    }
    string insertRecord(string query)
    {
        try
        {

            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand(query, myConnection);
            cmd.ExecuteNonQuery();
            myConnection.Close();
            return "1";
        }
        catch (Exception ex)
        {
            string success = "Possibe Network issue " + ex + "";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + success + "');", true);
            //MessageBox("at INSERT " + ex.Message);
            return "0" + ex.Message;
        }
    }
    public static void SendMail(string receiver, string body, string subject, string server, string Senderemail, string SenderID, string Mail_Password, int joe)
    {

        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("" + server + "");

        mail.From = new MailAddress("" + Senderemail + "", "" + SenderID + "");
        mail.To.Add(receiver);
        mail.Subject = subject;
        mail.Body = body;
        SmtpServer.EnableSsl = true;
        SmtpServer.Port = joe;
        SmtpServer.Credentials = new System.Net.NetworkCredential("" + Senderemail + "", "" + Mail_Password + "");
        SmtpServer.EnableSsl = false;
        NetworkCredential NetworkCred = new NetworkCredential("" + Senderemail + "", "" + Mail_Password + "");
        SmtpServer.Send(mail);


    }
}