<%@ Page Language="C#" AutoEventWireup="true" CodeFile="parents_students_pay.aspx.cs" Inherits="parents_students_pay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- place below the html form -->
<script>
  function payWithPaystack(){
    var handler = PaystackPop.setup({
        //key: 'pk_live_4bdfcfaa70630ec7f6c999b1a0a08ea4f1433ce3',
         key: '<%=Label9.Text %>',
      email: '<%=Label1.Text %>',
      amount: '<%=Label2.Text %>',
      ref: ''+Math.floor((Math.random() * 1000000000) + 1), // generates a pseudo-unique reference. Please replace with a reference you generated. Or remove the line entirely so our API will generate one for you
      metadata: {
         custom_fields: [
            {
                display_name: "Mobile Number",
                variable_name: "mobile_number",
                value: "+2348012345678"
            }
         ]
      },
      callback: function(response){
          //alert('success. transaction ref is ' + response.reference);
           document.getElementById("<%=Button1.ClientID %>").click();
      },
      onClose: function(){
          alert('window closed');
      }
    });
    handler.openIframe();
  }
</script>
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
            background-color: #FFFFFF;
        }
        .auto-style2 {
            width: 335px;
            height: 53px;
        }
        .auto-style3 {
            font-size: xx-large;
        }
        .auto-style4 {
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label14" runat="server" Text="'*" Visible="false"></asp:Label>
             <asp:Label ID="Label15" runat="server" Text="'*" Visible="false"></asp:Label>
            <asp:Label ID="Label9" runat="server" Text="'*" Visible="false"></asp:Label>
            <asp:Label ID="Label7" runat="server" Text="'*" Visible="false"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="'*" Visible="false"></asp:Label>
             <asp:Label ID="Label2" runat="server" Text="'*" Visible="false"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="'*" Visible="false"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="'*" Visible="false"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="false"></asp:Label>
            <br />
            <asp:Image ID="Image2" runat="server" Height="126px" ImageUrl="~/schoollogo.png" Width="284px" />
            <br />
            <asp:Label ID="Label8" runat="server" Text="*" Visible="false"></asp:Label>
            <br />
            <strong>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">&lt;&lt; Leave Payment Page</asp:LinkButton>
            <br />
            <br />
            <span class="auto-style3">Invoice:
            </span>
            <asp:Label ID="Label10" runat="server" Text="*" CssClass="auto-style3"></asp:Label>
            <span class="auto-style3">&nbsp;<br />
            Student ID:
            <asp:Label ID="Label11" runat="server" Text="*" CssClass="auto-style3"></asp:Label>
            &nbsp;</span></strong><br />
            <strong><span class="auto-style3">Amount To Pay:
            </span>
            <asp:Label ID="Label6" runat="server" Text="*" CssClass="auto-style3"></asp:Label>
            <span class="auto-style3">&nbsp;Naira</span></strong><br />
            <br />
            <br />
            <script src="https://js.paystack.co/v1/inline.js"></script>
  <button type="button" onclick="payWithPaystack()" class="auto-style2" style="border-color:chocolate"> Pay Now </button> 
            <br />
            <br />
            <strong>
            <span class="auto-style4">Purpose:
            <span class="auto-style3">
            <asp:Label ID="Label13" runat="server" Text="*" CssClass="auto-style4"></asp:Label>
            &nbsp;<br />
            </span>Note: </span>
            <span class="auto-style3">
            <asp:Label ID="Label12" runat="server" Text="*" CssClass="auto-style4"></asp:Label>
            &nbsp;<br />
            </span>
            </strong>
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" ImageUrl="~/secured-by-paystack.png" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" BorderStyle="None" CssClass="auto-style1" OnClick="Button1_Click" Text="Button" />
        </div>
    </form>
</body>
</html>
