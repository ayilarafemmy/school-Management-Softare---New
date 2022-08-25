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

public partial class admin_students : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["Email"])))
        {
            Response.Redirect("admin_login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
        Labela.Text = "Hello" + " " + Session["FirstName"].ToString();


        if (!this.IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select * from D_Parents where PID=" + Request.QueryString["PID"].ToString() + "";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Parents");
            TextBox5.Text = ds.Tables[0].Rows[0]["First_Name"].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0]["Last_Name"].ToString();
            Label7.Text = TextBox5.Text + " " + TextBox6.Text;
            DropDownList2.SelectedItem.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["Relationship"].ToString();
            TextBox9.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            TextBox10.Text = ds.Tables[0].Rows[0]["Full_Address"].ToString();
            TextBox11.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
            DropDownList3.SelectedItem.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
            DropDownList3.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            TextBox8.Text = ds.Tables[0].Rows[0]["Alternate_Phone"].ToString();
            string ue = ds.Tables[0].Rows[0]["Identity_Upload"].ToString();
            string end = ds.Tables[0].Rows[0]["filetype"].ToString();
            Image1.ImageUrl = "~/Parents/" + ue + "" + end + "";
            con.Close();

        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void export(string query, string filename)
    {
        string constr = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);

                        //Build the CSV file data as a Comma separated string.
                        string csv = string.Empty;

                        foreach (DataColumn column in dt.Columns)
                        {
                            //Add the Header row for CSV file.
                            csv += column.ColumnName + ',';
                        }

                        //Add new line.
                        csv += "\r\n";

                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (DataColumn column in dt.Columns)
                            {
                                //Add the Data rows.
                                csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                            }

                            //Add new line.
                            csv += "\r\n";
                        }

                        //Download the CSV file.
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".csv");
                        Response.Charset = "";
                        Response.ContentType = "application/text";
                        Response.Output.Write(csv);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string q = "select PID,concat(First_Name,' ',Last_Name) as Name,Email,Phone,Status from D_Parents";
        string n = "Parents_" + DateTime.Now.ToString("ddMMyyhhmm");
        export(q, n);
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox5.Text == "")
        {
            MessageBox("Kindly enter Parent First Name");
            TextBox5.BorderColor = Color.Red;
            return;
        }
        if (TextBox6.Text == "")
        {
            MessageBox("Kindly enter Parent Last Name");
            TextBox6.BorderColor = Color.Red;
            return;
        }
        if (TextBox7.Text == "")
        {
            MessageBox("Kindly enter Phone No");
            TextBox7.BorderColor = Color.Red;
            return;
        }
        if (TextBox9.Text == "")
        {
            MessageBox("Kindly enter Email");
            TextBox8.BorderColor = Color.Red;
            return;
        }
        if (DropDownList1.SelectedItem.Text == "Select Relationship")
        {
            MessageBox("Kindly select Relationship");
            DropDownList1.BorderColor = Color.Red;
            return;
        }

        if (DropDownList2.SelectedItem.Text == "Select Gender")
        {
            MessageBox("Kindly Select Gender");
            DropDownList2.BorderColor = Color.Red;
            return;
        }
        if (DropDownList3.SelectedItem.Text == "Select Religion")
        {
            MessageBox("Kindly Select Religion");
            DropDownList3.BorderColor = Color.Red;
            return;
        }

        string strt = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        SqlConnection con = new SqlConnection(strt);
        con.Open();
        string checkUser = "select Count(*) from D_Parents where email = '" + TextBox9.Text + "'";
        SqlCommand command = new SqlCommand(checkUser, con);
        int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        if (temp > 1)
        {
            MessageBox("Parent  with Email" + TextBox9.Text + " Exists / is deactivated");
            return;
        }
        else
        {


            //validation ends
            //check file(passport)
            if (fuimage.HasFile)
            {
                string FileExtention = System.IO.Path.GetExtension(fuimage.FileName);

                if (FileExtention == ".jpg" || FileExtention == ".png" || FileExtention == ".jpeg" || FileExtention == ".JPG")
                {

                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Only PNG & JPG Files are allowed";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string path = Server.MapPath("~/Parents/");
                string extension = System.IO.Path.GetExtension(fuimage.PostedFile.FileName);
                string NewName = TextBox5.Text + "_" + DateTime.Now.ToString("ddMMyyHHmm");
                Label2.Text = NewName.ToString();
                Label3.Text = extension;
                fuimage.SaveAs(path + NewName + extension);

                string jjc = " Update D_Parents Set Status='"+DropDownList4.SelectedValue+ "', filetype='"+ Label3.Text + "',First_Name='" + TextBox5.Text + "',Last_Name='" + TextBox6.Text + "',Gender='" + DropDownList2.SelectedItem.Text + "',Relationship='" + DropDownList1.SelectedItem.Text + "',Religion='" + DropDownList3.SelectedItem.Text + "', email='" + TextBox9.Text + "', Phone='" + TextBox7.Text + "', Alternate_Phone='" + TextBox8.Text + "',Full_Address='" + TextBox10.Text + "', Comments='" + TextBox11.Text + "', Identity_Upload='" + Label2.Text + "' where PID='"+ Request.QueryString["PID"].ToString() + "'";
                insertRecord(jjc);

            }
            else
            {
                string jjc = " Update D_Parents Set Status='" + DropDownList4.SelectedValue + "',First_Name='" + TextBox5.Text + "',Last_Name='" + TextBox6.Text + "',Gender='" + DropDownList2.SelectedItem.Text + "',Relationship='" + DropDownList1.SelectedItem.Text + "',Religion='" + DropDownList3.SelectedItem.Text + "', email='" + TextBox9.Text + "', Phone='" + TextBox7.Text + "', Alternate_Phone='" + TextBox8.Text + "',Full_Address='" + TextBox10.Text + "', Comments='" + TextBox11.Text + "' where PID='" + Request.QueryString["PID"].ToString() + "'";
                insertRecord(jjc);
            }




            //string insert = "Insert into D_Parents 
            //insertRecord(insert);

            //pick messaging parameters from webconfig
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
            if (sendmail == "Yes")
            {
                int joe = int.Parse(ServerPort);
                string StaffMail = "Dear " + TextBox5.Text + "," + Environment.NewLine + "" + Environment.NewLine + " Welcome to the " + Institution + " School Management Platform" + Environment.NewLine + " We are so excited to have you onboard. Your Login Credentials are as below: " + Environment.NewLine + "" + Environment.NewLine + "WebPortal Address: " + URL + "" + Environment.NewLine + "Username: Email: " + TextBox9.Text + " " + Environment.NewLine + " Password: Parent123" + Environment.NewLine + "" + Environment.NewLine + "On this platform you will be able to monitor the progress of your Child(ren),reach out to the school, get the latest information, make payments etc.  " + Environment.NewLine + "" + Environment.NewLine + " Welcome!!! ";
                

                string AdminMail = "Dear Admin, " + Environment.NewLine + " Parent Details Update ." + Environment.NewLine + "" + Environment.NewLine + " Name: " + TextBox5.Text + ", Email: " + TextBox9.Text + " and Phone:" + TextBox7.Text + "";
                SendMail(AdminEmail, AdminMail, "Parent Details Update", ServerName, SenderEmail, Institution, Mail_Password, joe);

                string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Parent Details Update', '" + StaffMail + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                insertRecord(quee);

            }

            MessageBox("Update Captured Successfully");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "1;url=Admin_Parents.aspx";
            this.Page.Controls.Add(meta);
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