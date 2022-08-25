<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en" dir="ltr">
<head runat="server">
   <meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<meta http-equiv="X-UA-Compatible" content="ie=edge">

<link rel="icon" href="favicon.ico" type="image/x-icon"/>

<title>:: School Master :: DataPlus</title>

<!-- Bootstrap Core and vandor -->
<link rel="stylesheet" href="../assets/plugins/bootstrap/css/bootstrap.min.css" />

<!-- Core css -->
<link rel="stylesheet" href="../assets/css/style.min.css"/>
</head>
<body style="background-image: url('a.jpg');">
    <form id="form1" runat="server">
        <div>
            <div class="auth option2">
    <div class="auth_left">
        <div class="card">
            <div class="card-body">
                <div class="text-center">
                <asp:Image ID="Image1" runat="server" />
                    <div class="card-title mt-3">
                    <asp:Label ID="Labelza" runat="server" Text="*"></asp:Label></div>
                           <h5>Admin Login</h5>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Placeholder="Email Address" TextMode="Email"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="form-label"><a href="forgotpass_admin.aspx" class="float-right small">I forgot password</a></label>
                   <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Placeholder="Password" TextMode="Password"></asp:TextBox>
                        
                </div>
                <div class="text-center">
                        <asp:Button ID="Button1" runat="server" Text="Sign in" CssClass="btn btn-primary btn-block" OnClick="Button1_Click" />
                        <asp:Label ID="Label1" runat="server" Text="*" Visible="false"></asp:Label>
                </div>
            </div>
        </div>        
    </div>
</div>

<!-- Start Main project js, jQuery, Bootstrap -->
<script src="../assets/bundles/lib.vendor.bundle.js"></script>

<!-- Start project main js  and page js -->
<script src="../assets/js/core.js"></script>
        </div>
    </form>
</body>
</html>
