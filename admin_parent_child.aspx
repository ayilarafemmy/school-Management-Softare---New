<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_parent_child.aspx.cs" Inherits="admin_students" EnableEventValidation="false" %>

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
                            <li class="breadcrumb-item active" aria-current="page">Parents</li>
                        </ol>
                    </div>
                    <ul class="nav nav-tabs page-header-tab">
                        <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#Student-add">Kids Information - Children</a></li>
<%--                          <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#Student-child">Children</a></li>--%>
                        <li class="nav-item"><a href="admin_parents.aspx">All Parents</a></li>
                        
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
                                        <h3 class="card-title">Children Information - <asp:Label ID="Label7" runat="server" Text="*"></asp:Label></h3> 
                                        <div class="card-options ">
                                            <a href="#" class="card-options-collapse" data-toggle="card-collapse"><i class="fe fe-chevron-up"></i></a>
                                            <a href="#" class="card-options-remove" data-toggle="card-remove"><i class="fe fe-x"></i></a>
                                        </div>
                                    </div>
                                    <form class="card-body">
                                        <asp:Label ID="Label1" runat="server" Text="*" Visible="false"></asp:Label><asp:Label ID="Label2" runat="server" Text="*" Visible="false"></asp:Label><asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                                        <div class="form-group row">
                                             <asp:GridView ID="GridView1" runat="server" DataKeyNames="SID" EmptyDataText="No records has been added." AutoGenerateColumns="false" CssClass="table table-striped mb-0 " AllowPaging="true"
     PageSize="15" >
   <Columns>
                                                        <asp:BoundField DataField="SID" HeaderText="StudentID" SortExpression="SID" />
                                                        <asp:ImageField DataImageUrlField="Photo" HeaderText="Image" ItemStyle-Width="50px" ItemStyle-Height="50px"></asp:ImageField>  
                                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        <asp:BoundField DataField="Class" HeaderText="Class"
            SortExpression="Class" />
        <asp:BoundField DataField="Gender" HeaderText="Gender"
            SortExpression="Gender" />
        <asp:BoundField DataField="Status" HeaderText="Status"
            SortExpression="Status" />
       <asp:BoundField DataField="Balance" HeaderText="Balance(NGN)"
            SortExpression="Balance" />
          </Columns>
</asp:GridView>
                                        </div>
                                  
                                    </form>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-12 col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h3 class="card-title">Parent's Picture</h3>
                                      
                                    </div>
                                    <div class="card">
                                        <asp:Image ID="Image1" runat="server" Height="200" Width="200" />
                                        <div class="row clearfix">
                                            
                                                    
                                              
                                            </div>
                                            <div class="col-sm-12">
                                                <%--<asp:Button ID="Button2" runat="server" Text="Update Parent Information"  CssClass="btn btn-primary" OnClick="Button2_Click"/>
                                                <asp:Button ID="Button3" runat="server" Text="Reset"  CssClass="btn btn-outline-secondary"/>--%>
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

