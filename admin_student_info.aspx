<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_student_info.aspx.cs" Inherits="admin_students" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="section-body">
            <div class="container-fluid">
                <div class="d-flex justify-content-between align-items-center ">
                    <div class="header-action">
                       <h1 class="page-title">  
                            <asp:Label ID="Labela" runat="server" Text="*"></asp:Label> </h1>
                        <ol class="breadcrumb page-breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Admin</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Students Management</li>
                        </ol>
                    </div>
                    <ul class="nav nav-tabs page-header-tab">
                        <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#Student-add">Add Student</a></li>
                        <li class="nav-item"><a href="admin_students.aspx">All Students</a></li>
                        
                    </ul>
                </div>
            </div>
        </div>
        <div class="section-body mt-4">
            <div class="container-fluid">
                <div class="tab-content">
                   <div class="tab-pane active" id="Student-all">
                        <div class="row clearfix">
                            <div class="col-lg-8 col-md-12 col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h3 class="card-title">Basic Information</h3>
                                        <div class="card-options ">
                                            <a href="#" class="card-options-collapse" data-toggle="card-collapse"><i class="fe fe-chevron-up"></i></a>
                                            <a href="#" class="card-options-remove" data-toggle="card-remove"><i class="fe fe-x"></i></a>
                                        </div>
                                    </div>
                                    <form class="card-body">
                                        <asp:Label ID="Label1" runat="server" Text="*" Visible="false"></asp:Label><asp:Label ID="Label2" runat="server" Text="*" Visible="false"></asp:Label><asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">First Name <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="TextBox5" runat="server" placeholder="Enter First name" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Last Name <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="TextBox6" runat="server" placeholder="Enter Last name" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Roll No <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="TextBox7" runat="server" placeholder="Enter Roll Number" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Blood Group <span class="text-danger"></span></label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="TextBox8" runat="server" placeholder="Enter Blood Group" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Email <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                               <asp:TextBox ID="TextBox9" runat="server" placeholder="Enter Email" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Parent <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Class <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="DropDownList6" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                         <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Route <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Gender <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                                    <asp:ListItem>Select Gender</asp:ListItem>
                                       <asp:ListItem>Male</asp:ListItem>
                                       <asp:ListItem>Female</asp:ListItem>
                                       <asp:ListItem>Others</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                         <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Religion <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                                                    <asp:ListItem>Select Religion</asp:ListItem>
                                       <asp:ListItem>Christianity</asp:ListItem>
                                       <asp:ListItem>Islam</asp:ListItem>
                                       <asp:ListItem>Hindu</asp:ListItem>
                                         <asp:ListItem>Others</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Status <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="A">Active</asp:ListItem>
                                        <asp:ListItem Value="D">De-Activated</asp:ListItem>
                                         <asp:ListItem Value="W">Awaiting Approval</asp:ListItem>
                                          <asp:ListItem Value="G">Graduated</asp:ListItem>
                                            <asp:ListItem Value="E">Exited</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Bio <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                 <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Balance <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                 <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Date of Birth <span class="text-danger">*</span></label>
                                            <div class="col-md-9">
                                                 <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                           <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showpreview(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview').css('visibility', 'visible');
                    $('#imgpreview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }

        }

    </script> 
                                        <div class="form-group row">
                                            <label class="col-md-3 col-form-label">Profile Picture</label>
                                            <div class="col-md-9">
        <asp:FileUpload ID="fuimage" runat="server" onchange="showpreview(this);" />
                                                <small id="fileHelp" class="form-text text-muted">Kindly ensure that a Jpeg or PNG image or passport photograph is selected.</small>
                                            </div>
                                              
                                        </div>
                                    </form>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-12 col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h3 class="card-title">Preview Picture</h3>
                                        <div class="card-options ">
                                            <a href="#" class="card-options-collapse" data-toggle="card-collapse"><i class="fe fe-chevron-up"></i></a>
                                            <a href="#" class="card-options-remove" data-toggle="card-remove"><i class="fe fe-x"></i></a>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <div class="row clearfix">
                                            <div class="col-sm-12">
                                                <div class="form-group">
                                                    <img id="imgpreview" height="200" width="250" src="" style="border-width: 0px; visibility: hidden;" />
                                                    <asp:Image ID="Image1" runat="server" Height="200" Width="200" />
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <asp:Button ID="Button2" runat="server" Text="Update Student Information"  CssClass="btn btn-primary" OnClick="Button2_Click"/>
                                                <asp:Button ID="Button3" runat="server" Text="Reset"  CssClass="btn btn-outline-secondary"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

