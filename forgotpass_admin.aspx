<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgotpass_admin.aspx.cs" Inherits="forgotpass_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en" dir="ltr">
<head runat="server">
 <meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<meta http-equiv="X-UA-Compatible" content="ie=edge">

<link rel="icon" href="favicon.ico" type="image/x-icon"/>

<title>:: School Master :: Admin Forgot Password</title>

<!-- Bootstrap Core and vandor -->
<link rel="stylesheet" href="../assets/plugins/bootstrap/css/bootstrap.min.css" />

<!-- Core css -->
<link rel="stylesheet" href="../assets/css/style.min.css"/>
<link rel="stylesheet" href="assets/css/default.css" />
</head>
<body class="font-muli theme-cyan gradient">
    <form id="form1" runat="server">
        <div>
            <div class="auth option2">
    <div class="auth_left">
        <div class="card">
            <div class="card-body">
                <div class="text-center">
                     <asp:Image ID="Image1" runat="server" />
                    <div class="card-title mt-3">
                    <asp:Label ID="Labelza" runat="server" Text="*"></asp:Label>
                </div>
                <p class="text-muted">Forgot password <br />Enter your email address and your password will be reset and emailed to you.</p>
                <div class="form-group">
                    <label class="form-label" for="exampleInputEmail1">Email address</label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Placeholder="Registered Email" aria-describedby="emailHelp"></asp:TextBox>
                </div>
                <div class="text-center">
                            <asp:Button ID="Button1" runat="server" Text="Send Me New Password" CssClass="btn btn-primary btn-block" OnClick="Button1_Click" />
                    <div class="text-muted mt-4">Forget it, <a href="Admin_Login.aspx">Send me Back</a> to the Sign in screen.</div>

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
