using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class parents_events : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["PID"])))
        {
            Response.Redirect("parent_login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        Label1.Text = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();

    }
}