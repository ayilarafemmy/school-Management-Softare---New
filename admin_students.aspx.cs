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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["Email"])))
        {
            Response.Redirect("admin_login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
        Labela.Text = "Hello" + " " + Session["FirstName"].ToString();


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
            using (SqlCommand cmd = new SqlCommand("select a.SID,concat(a.FirstName,' ',a.LastName) as Name,CONCAT('~/Students/',a.Photo,a.filetype) as Photo,b.Fclass as Class,a.Gender,a.Balance,a.Status from D_Students a, D_Classes b where a.Class = b.ClassID"))
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
    private void BindGridMethod(string query)
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
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
    private void ExportGridToPDF(string Name)
    {
        this.BindGrid();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;"+Name+".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter s_w = new StringWriter();
        HtmlTextWriter h_w = new HtmlTextWriter(s_w);
        GridView1.AllowPaging = false;
        GridView1.DataBind();
        GridView1.RenderControl(h_w);
        GridView1.HeaderRow.Style.Add("width", "15%");
        GridView1.HeaderRow.Style.Add("font-size", "10px");
        GridView1.Style.Add("text-decoration", "none");
        GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        GridView1.Style.Add("font-size", "8px");
        StringReader sr = new StringReader(s_w.ToString());
        Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
{
    GridViewRow row = GridView1.Rows[e.RowIndex];
    int SID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
    string Status = (row.Cells[6].Controls[0] as TextBox).Text;
        string constr = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand("UPDATE D_Students SET Status = @Status WHERE SID = @SID"))
        {
            cmd.Parameters.AddWithValue("@SID", SID);
            cmd.Parameters.AddWithValue("@Status", Status);
           cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    GridView1.EditIndex = -1;
    this.BindGrid();
}
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int SID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        string constr = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM D_Students WHERE SID = @SID"))
            {
                cmd.Parameters.AddWithValue("@SID", SID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        this.BindGrid();
    }
    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        {
            (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        }
    }


    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        //string nn = "Parents_" + DateTime.Now.ToString("ddMMyyhhmm");
        //ExportGridToPDF(nn);
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {

                //Hide the Column containing CheckBox
                GridView1.Columns[0].Visible = false;

                GridView1.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Students_"+DateTime.Now.ToString("ddMMyy_hhmm")+".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
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
        string q = "select a.SID,concat(a.FirstName,' ',a.LastName) as Name,b.Fclass as Class,a.Gender,a.Balance,a.Status from D_Students a, D_Classes b where a.Class = b.ClassID";
        string n = "Students_" + DateTime.Now.ToString("ddMMyyhhmm");
        export(q, n);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(TextBox4.Text =="" && TextBox3.Text =="" && TextBox2.Text == "" && TextBox1.Text == "")
        {
            MessageBox("Put in atleast one search criteria");
            return;
        }
        //search and populate
        string jj = "select a.SID,concat(a.FirstName,' ',a.LastName) as Name,CONCAT('~/Students/',a.Photo,a.filetype) as Photo,b.Fclass as Class,a.Gender,a.Balance,a.Status from D_Students a, D_Classes b where a.Class = b.ClassID and a.SID='" + TextBox1.Text+ "' OR a.FirstName like '%"+ TextBox2.Text+ "%' OR a.LastName like '%" + TextBox2.Text + "%' OR b.Fclass like '%"+TextBox3.Text+"%' OR a.Gender='"+TextBox4.Text+"'";
        BindGridMethod(jj);
        if(GridView1.Rows.Count < 1)
        {
            MessageBox("Record Not found");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=  admin_students.aspx";
            this.Page.Controls.Add(meta);
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
        if (TextBox8.Text == "")
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
        if (temp >= 1)
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

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Please Select your file";
                Label1.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (TextBox9.Text == "")
            {
                MessageBox("Email Address is very compulsory");
                return;
            }



            string insert = "Insert into D_Parents (filetype,First_Name,Last_Name,Gender,Relationship,Religion,email,Phone,Alternate_Phone,Full_Address,Comments,Identity_Upload,Capture_Date,Capture_By,Password,FirstLogin) values ('" + Label3.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DropDownList2.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "','" + TextBox9.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + Label2.Text + "','" + DateTime.Now.AddHours(5).ToString("dd/MM/yyyy") + "','" + Session["StaffID"].ToString() + "','Parent123','0')";
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
                int joe = int.Parse(ServerPort);
                string StaffMail = "Dear " + TextBox5.Text + "," + Environment.NewLine + "" + Environment.NewLine + " Welcome to the " + Institution + " School Management Platform" + Environment.NewLine + " We are so excited to have you onboard. Your Login Credentials are as below: " + Environment.NewLine + "" + Environment.NewLine + "WebPortal Address: " + URL + "" + Environment.NewLine + "Username: Email: " + TextBox9.Text + " " + Environment.NewLine + " Password: Parent123" + Environment.NewLine + "" + Environment.NewLine + "On this platform you will be able to monitor the progress of your Child(ren),reach out to the school, get the latest information, make payments etc.  " + Environment.NewLine + "" + Environment.NewLine + " Welcome!!! ";
                SendMail(TextBox9.Text, StaffMail, "Parent SignUp - Important Details", ServerName, SenderEmail, Institution, Mail_Password, joe);

                string AdminMail = "Dear Admin, " + Environment.NewLine + " Parent Signup Alert ." + Environment.NewLine + "" + Environment.NewLine + " Name: " + TextBox5.Text + ", Email: " + TextBox9.Text + " and Phone:" + TextBox7.Text + "";
                SendMail(AdminEmail, AdminMail, "Parent Signup", ServerName, SenderEmail, Institution, Mail_Password, joe);

                string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Parent Registration', '" + StaffMail + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                insertRecord(quee);

            }
            if (SendSMS == "Yes")
            {
                var message = "Hi " + TextBox5.Text + "," + Environment.NewLine + " Welcome to the " + Institution + " Portal" + Environment.NewLine + " Your Login details: " + Environment.NewLine + "URL: " + URL + "" + Environment.NewLine + "Username: Email: " + TextBox9.Text + " " + Environment.NewLine + " Password: Parent123" + Environment.NewLine + "" + Environment.NewLine + "Please check email for details ";

                string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + SMS_Email + "&subacct=" + SMSID + "&subacctpwd=" + SMS_Password + "&message=" + message + "&sender=" + SMS_Sender + "&sendto=" + TextBox7.Text + "&msgtype=0";
                System.Net.WebClient c = new System.Net.WebClient();
                var response = c.DownloadString(apicommand);


                string SMSMMM = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('SMS Message', '" + message + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                insertRecord(SMSMMM);
            }



            MessageBox("Details Captured Successfully");
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