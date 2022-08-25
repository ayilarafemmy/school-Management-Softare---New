using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class CBT_result : System.Web.UI.Page
{
    string str;
    SqlCommand com;
    SqlCommand comt;

    SqlCommand cmd = new SqlCommand();
    SqlConnection conx = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string exx = Request.QueryString["Examaccesscode"];
        if (exx == "")
        {
            Response.Redirect("Parent_Login.aspx");
        }
        else
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select a.Examaccesscode,a.SID,b.ExamType,c.Fclass,d.FullName,a.ExamStatus,d.Score,d.TimeCompleted,a.ExamDate from D_Examschedule a, D_Examtype b, D_Classes c, D_ExamsDone d where a.ExamType = b.ETID  and c.ClassID = a.ExamClass and a.Examaccesscode = d.Examaccesscode and a.Examaccesscode='"+ exx + "'";
            //cmd.CommandText = "select * from OgunTCBT where TCBTCode='" + exx + "' and Status='Closed' and Score is not Null";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Examschedule");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Panel1.Visible = true;
                Label1.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                Label2.Text = ds.Tables[0].Rows[0]["Examaccesscode"].ToString();
                Label3.Text = ds.Tables[0].Rows[0]["SID"].ToString();
                Label4.Text = ds.Tables[0].Rows[0]["ExamStatus"].ToString();
                Label5.Text = ds.Tables[0].Rows[0]["ExamDate"].ToString();
                Label6.Text = ds.Tables[0].Rows[0]["Score"].ToString();
                Label7.Text = ds.Tables[0].Rows[0]["ExamStatus"].ToString();
                if (Label4.Text == "Passed")
                {
                    Label4.Text = "CONGRATULATIONS!!!";
                    Label4.ForeColor = System.Drawing.Color.Green;
                    Label6.ForeColor = System.Drawing.Color.Green;
                    Label7.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    Label4.Text = "NOT SUCCESSFUL THIS TIME";
                    Label4.ForeColor = System.Drawing.Color.Red;
                    Label6.ForeColor = System.Drawing.Color.Red;
                    Label7.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {

                Response.Redirect("Parent_Login.aspx");
            }
            con.Close();
        }
    }

}