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
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html.simpleparser;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Drawing;

public partial class admin_students : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["Email"])))
        {
            Response.Redirect("admin_login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
        Labela.Text = "Hello" + " " + Session["FirstName"].ToString();


        if (!this.IsPostBack)
        {
            BindGrid();
            BindGrid4();
        }
      
    }
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select concat('Name: ',First_Name,'-',Last_Name,'-','Email: ',email) as name, PID from D_Parents";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "PID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Parent", "0"));
            con.Close();
        }
    }
    protected void BindGrid4()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select FClass, ClassID from D_Classes";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList4.DataSource = dt;
            DropDownList4.DataBind();
            DropDownList4.DataTextField = "FClass";
            DropDownList4.DataValueField = "ClassID";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, new ListItem("Select Class", "0"));
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
        SqlCommand cmdx = new SqlCommand();
        SqlDataAdapter sdax = new SqlDataAdapter();
        DataSet dsx = new DataSet();
        SqlConnection contx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);

        string ccc = ConfigurationManager.AppSettings["MaxStudents"];
        int all = int.Parse(ccc);
        contx.Open();
        SqlCommand comm = new SqlCommand("SELECT COUNT(SID) FROM D_Students", contx);
        Int32 count = Convert.ToInt32(comm.ExecuteScalar());
        if (count >= all)
        {
            MessageBox("You have reached the limit allowed on the platform, limit is " + all + "");
            return;
        }
        else
        {

        }
        contx.Close();

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
            MessageBox("Kindly enter Blood Group");
            TextBox7.BorderColor = Color.Red;
            return;
        }
        if (TextBox8.Text == "")
        {
            MessageBox("Kindly enter Date of Birth");
            TextBox8.BorderColor = Color.Red;
            return;
        }
        if (TextBox9.Text == "")
        {
            MessageBox("Kindly enter Email");
            TextBox8.BorderColor = Color.Red;
            return;
        }
        if (DropDownList1.SelectedItem.Text == "Select Parent")
        {
            MessageBox("Kindly select Parent");
            DropDownList1.BorderColor = Color.Red;
            return;
        }
        if (DropDownList4.SelectedItem.Text == "Select Class")
        {
            MessageBox("Kindly select Class");
            DropDownList4.BorderColor = Color.Red;
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
        if (TextBox10.Text == "")
        {
            MessageBox("Kindly enter Student Information");
            TextBox10.BorderColor = Color.Red;
            return;
        }
        if (TextBox11.Text == "")
        {
            MessageBox("Kindly enter Admission Fees");
            TextBox11.BorderColor = Color.Red;
            return;
        }
        string strt = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        SqlConnection con = new SqlConnection(strt);
        con.Open();
        string checkUser = "select Count(*) from D_Students where FirstName = '" + TextBox5.Text + "' and LastName='"+ TextBox6.Text + "'";
        SqlCommand command = new SqlCommand(checkUser, con);
        int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        if (temp >= 1)
        {
            MessageBox("Parent  with FirstName: " + TextBox5.Text + " and LastName: "+TextBox6.Text+"  Exists / is deactivated");
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

                string path = Server.MapPath("~/Students/");
                string extension = System.IO.Path.GetExtension(fuimage.PostedFile.FileName);
                string NewName = TextBox5.Text + "_" + DateTime.Now.ToString("ddMMyyHHmm");
                Label2.Text = NewName.ToString();
                Label3.Text = extension;
                fuimage.SaveAs(path + NewName + extension);

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Please Select your file";
                Label1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            int kk = int.Parse(Label12.Text);
            int jdf = kk + 1;

            int b = int.Parse(TextBox11.Text);


            //string insert = "Insert into D_Parents (Status,filetype,First_Name,Last_Name,Gender,Relationship,Religion,email,Phone,Alternate_Phone,Full_Address,Comments,Identity_Upload,Capture_Date,Capture_By,Password,FirstLogin) values ('A','" + Label3.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DropDownList2.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "','" + TextBox9.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + Label2.Text + "','" + DateTime.Now.AddHours(5).ToString("dd/MM/yyyy") + "','" + Session["StaffID"].ToString() + "','Parent123','0')";
            string insert = "Insert into D_Students (Section,Admission_ID,Parent_ID,FirstName,LastName,Gender,DOB,Roll_No,BG,Religion,Email,Class,Bio,Capture_Date,Capture_By,Photo,filetype,Balance,Password,RouteID,LoginC,Status) values ('" + Label13.Text+"','" + TextBox5.Text+"_"+DateTime.Now.ToString("ddMMyyHHmm")+"','"+DropDownList1.SelectedValue+"','"+TextBox5.Text+"','"+TextBox6.Text+"','"+DropDownList2.SelectedItem.Text+"','"+TextBox8.Text+"','"+jdf+"','"+TextBox7.Text+"','"+DropDownList3.SelectedItem.Text+"','"+TextBox9.Text+"','"+DropDownList4.SelectedValue+"','"+TextBox10.Text+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"','"+Session["StaffID"].ToString()+ "','" + Label2.Text + "','" + Label3.Text + "','"+b+"','Student123','','0','W')";
            insertRecord(insert);

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
                if(TextBox9.Text != "")
                {
                int joe = int.Parse(ServerPort);
                //string StaffMail = "Dear " + TextBox5.Text + "," + Environment.NewLine + "" + Environment.NewLine + " Welcome to the " + Institution + " School Management Platform" + Environment.NewLine + " We are so excited to have you onboard. Your Login Credentials are as below: " + Environment.NewLine + "" + Environment.NewLine + "WebPortal Address: " + URL + "" + Environment.NewLine + "Username: " + TextBox9.Text + " " + Environment.NewLine + " Password: Parent123" + Environment.NewLine + "" + Environment.NewLine + "On this platform you will be able to monitor the progress of your Child(ren),reach out to the school, get the latest information, make payments etc.  " + Environment.NewLine + "" + Environment.NewLine + " Welcome!!! ";
                //SendMail(TextBox9.Text, StaffMail, "Parent SignUp - Important Details", ServerName, SenderEmail, Institution, Mail_Password, joe);

                string AdminMail = "Dear Admin, " + Environment.NewLine + " Student Signup Alert ." + Environment.NewLine + "" + Environment.NewLine + " Name: " + TextBox5.Text + ", Email: " + TextBox9.Text + "";
                SendMail(AdminEmail, AdminMail, "Student Signup", ServerName, SenderEmail, Institution, Mail_Password, joe);

                string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Student Registration', '" + AdminMail + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                insertRecord(quee);
                }
            }
            



            MessageBox("Details Captured Successfully");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=Admin_students.aspx";
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

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
            if (DropDownList4.SelectedItem.Text == "Select Class")
            {

            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlConnection cont = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
                cont.Open();
                cmd.CommandText = "select count(*) as count from D_Students where Class='" + DropDownList4.SelectedValue + "'";
                cmd.Connection = cont;
                sda.SelectCommand = cmd;
                sda.Fill(ds, "D_Students");
                Label12.Text = ds.Tables[0].Rows[0]["count"].ToString();
                cont.Close();

                if (Label12.Text == "")
                {
                Label12.Text = "0";
                }
                //get the Section
                SqlCommand cmdo = new SqlCommand();
                SqlDataAdapter sdao = new SqlDataAdapter();
                DataSet dso = new DataSet();
                SqlConnection cono = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
                cono.Open();
                cmdo.CommandText = "select Section as sid from D_Classes where Classid = '" + DropDownList4.SelectedValue + "'";
                cmdo.Connection = cono;
                sdao.SelectCommand = cmdo;
                sdao.Fill(dso, "D_Classes");
                Label3.Text = dso.Tables[0].Rows[0]["sid"].ToString();
                cono.Close();

            }
        }
    
}