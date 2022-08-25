﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Parent_MasterPage.master" AutoEventWireup="true" CodeFile="parents_Exams.aspx.cs" Inherits="Parents_Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <div class="section-body">
            <div class="container-fluid">
                <div class="d-flex justify-content-between align-items-center ">
                    <div class="header-action">
                        <h1 class="page-title">Hello <asp:Label ID="Label1" runat="server" Text="*"></asp:Label></h1>
                        <ol class="breadcrumb page-breadcrumb">
                            <li class="breadcrumb-item"><a href="#">PARENT</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Online Exams</li>
                        </ol>
                    </div>
                    <ul class="nav nav-tabs page-header-tab">
                        <li class="nav-item"><a class="nav-link active" id="Primary-tab" data-toggle="tab" href="#Primary">Entry Examinations</a></li>
<%--                        <li class="nav-item"><a class="nav-link" id="Social-tab" data-toggle="tab" href="#Social">Social</a></li>
                        <li class="nav-item"><a class="nav-link" id="Updates-tab" data-toggle="tab" href="#Updates">Updates</a></li>--%>
                        <li class="nav-item"><a href="#" class="btn btn-primary" title="">Other Examinations</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="section-body mt-4">
            <div class="container-fluid">
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade show active" id="Primary">
                        <asp:GridView ID="GridView1" runat="server" DataKeyNames="Examaccesscode" CssClass="table table-striped mb-0 " AllowPaging="true" EmptyDataText="No Pending Exams." AutoGenerateColumns="false">
                            <Columns>
                                  <asp:BoundField DataField="ExamDate" HeaderText="Exams Date"
            SortExpression="ExamDate" />
        <asp:BoundField DataField="Fclass" HeaderText="Prospective Class" SortExpression="Fclass" />
                                <asp:BoundField DataField="SID" HeaderText="StudentID - SID" SortExpression="SID" />
                                <asp:BoundField DataField="Examaccesscode" HeaderText="Examaccesscode" SortExpression="Examaccesscode" />
                                <asp:BoundField DataField="Name" HeaderText="Student's Name" SortExpression="Name" />
                                <asp:BoundField DataField="Information" HeaderText="Information" SortExpression="Information" />
         <asp:HyperLinkField HeaderText="Take Exams Now" DataNavigateUrlFields="Examaccesscode"  DataNavigateUrlFormatString="~/CBT_Login.aspx" DataTextField="Examaccesscode" DataTextFormatString= "<img src='ex.fw.png' alt='Take Exams Now'"/>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="tab-pane fade" id="Social">
                        <div class="card">
                            <div class="card-body text-center py-5">
                                <img src="../assets/images/no-email.svg" class="width360 mb-3">
                                <h4>Not Found</h4>
                                <span>Choose a different filter to view test results to you</span>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="Updates">
                        <div class="accordion" id="accordionExampleas">
                            <div class="card mb-1 inbox unread">
                                <div class="card-header" id="headingOneqq">
                                    <label class="custom-control custom-checkbox custom-control-inline mr-0">
                                        <input type="checkbox" class="custom-control-input" name="example-checkbox1" value="option1">
                                        <span class="custom-control-label">&nbsp;</span>
                                    </label>
                                    <a href="javascript:void(0);" class="mail-star xs-hide"><i class="fa fa-star-o"></i></a>
                                    <h5 class="mb-0">
                                        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOneqq" aria-expanded="true" aria-controls="collapseOneqq">Vincent Porter</button>
                                    </h5>
                                    <span class="text_ellipsis xs-hide">Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus</span>
                                    <div class="card-options">
                                        <a class="text-muted" href="javascript:void(0)"><i class="fa fa-reply"></i></a>
                                        <a class="text-muted" href="javascript:void(0)" class="xs-hide"><i class="fa fa-archive"></i></a>
                                        <a class="text-muted" href="javascript:void(0)" class="xs-hide"><i class="fa fa-clock-o"></i></a>
                                        <a class="text-muted" href="javascript:void(0)"><i class="fa fa-trash"></i></a>                                        
                                        <a class="text-muted" href="app-emailveiw.html"><i class="fa fa-eye"></i></a>
                                    </div>
                                </div>                            
                                <div id="collapseOneqq" class="collapse" aria-labelledby="headingOneqq" data-parent="#accordionExampleas">
                                    <div class="card-body detail">
                                        <div class="detail-header">
                                            <div class="media">
                                                <div class="float-left">
                                                    <div class="mr-3"><img src="../assets/images/xs/avatar1.jpg" alt=""></div>
                                                </div>
                                                <div class="media-body">
                                                    <p class="mb-0"><strong class="text-muted mr-1">From:</strong><a href="javascript:void(0);">info@gmail.com</a><span class="text-muted text-sm float-right">12:48, 23.06.2018</span></p>
                                                    <p class="mb-0"><strong class="text-muted mr-1">To:</strong>Me <small class="float-right"><i class="fe fe-paperclip mr-1"></i>(2 files, 89.2 KB)</small></p>                                        
                                                </div>
                                            </div>
                                        </div>
                                        <div class="mail-cnt">
                                            <p>Hello <strong>Marshall Nichols</strong>,</p><br>
                                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
                                            <ul>
                                                <li>standard dummy text ever since the 1500s, when an unknown printer</li>
                                                <li>Lorem Ipsum has been the industry's standard dummy</li>
                                            </ul>
                                            <p>printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrnturies, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
                                            <br>
                                            <div class="file_folder">
                                                <a href="javascript:void(0);">
                                                    <div class="icon">
                                                        <i class="fa fa-file-excel-o text-success"></i>
                                                    </div>
                                                    <div class="file-name">
                                                        <p class="mb-0 text-muted">Report2017.xls</p>
                                                        <small>Size: 68KB</small>
                                                    </div>
                                                </a>
                                                <a href="javascript:void(0);">
                                                    <div class="icon">
                                                        <i class="fa fa-file-word-o text-primary"></i>
                                                    </div>
                                                    <div class="file-name">
                                                        <p class="mb-0 text-muted">Report2017.doc</p>
                                                        <small>Size: 68KB</small>
                                                    </div>
                                                </a>
                                                <a href="javascript:void(0);">
                                                    <div class="icon">
                                                        <i class="fa fa-file-pdf-o text-danger"></i>
                                                    </div>
                                                    <div class="file-name">
                                                        <p class="mb-0 text-muted">Report2017.pdf</p>
                                                        <small>Size: 68KB</small>
                                                    </div>
                                                </a>
                                            </div>
            
                                            <p>Thank youm,<br><strong>Wendy Abbott</strong></p>
                                            <hr>
                                            <strong>Click here to</strong>
                                            <a href="app-compose.html">Reply</a> or
                                            <a href="app-compose.html">Forward</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card mb-1 inbox">
                                <div class="card-header" id="mailheading2qq">
                                    <label class="custom-control custom-checkbox custom-control-inline mr-0">
                                        <input type="checkbox" class="custom-control-input" name="example-checkbox1" value="option1">
                                        <span class="custom-control-label">&nbsp;</span>
                                    </label>
                                    <a href="javascript:void(0);" class="mail-star xs-hide"><i class="fa fa-star-o"></i></a>
                                    <h5 class="mb-0">
                                        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#maillist2qq" aria-expanded="true" aria-controls="maillist2qq">Merri Diamond</button>
                                    </h5>
                                    <span class="text_ellipsis xs-hide">There are many variations of passages of Lorem Ipsum available</span>
                                    <div class="card-options">
                                        <a class="text-muted" href="javascript:void(0)"><i class="fa fa-reply"></i></a>
                                        <a class="text-muted" href="javascript:void(0)" class="xs-hide"><i class="fa fa-archive"></i></a>
                                        <a class="text-muted" href="javascript:void(0)" class="xs-hide"><i class="fa fa-clock-o"></i></a>
                                        <a class="text-muted" href="javascript:void(0)"><i class="fa fa-trash"></i></a>                                        
                                        <a class="text-muted" href="app-emailveiw.html"><i class="fa fa-eye"></i></a>
                                    </div>
                                </div>                            
                                <div id="maillist2qq" class="collapse" aria-labelledby="mailheading2qq" data-parent="#accordionExampleas">
                                    <div class="card-body detail">
                                        <div class="detail-header">
                                            <div class="media">
                                                <div class="float-left">
                                                    <div class="mr-3"><img src="../assets/images/xs/avatar3.jpg" alt=""></div>
                                                </div>
                                                <div class="media-body">
                                                    <p class="mb-0"><strong class="text-muted mr-1">From:</strong><a href="javascript:void(0);">info@gmail.com</a><span class="text-muted text-sm float-right">12:48, 23.06.2018</span></p>
                                                    <p class="mb-0"><strong class="text-muted mr-1">To:</strong>Me <small class="float-right"><i class="fe fe-paperclip mr-1"></i>(2 files, 89.2 KB)</small></p>                                        
                                                </div>
                                            </div>
                                        </div>
                                        <div class="mail-cnt">
                                            <p>Hello <strong>Marshall Nichols</strong>,</p><br>
                                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>                                            
                                            <p>Thank youm,<br><strong>Wendy Abbott</strong></p>
                                            <hr>
                                            <strong>Click here to</strong>
                                            <a href="app-compose.html">Reply</a> or
                                            <a href="app-compose.html">Forward</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card mb-1 inbox">
                                <div class="card-header" id="mailheading3qq">
                                    <label class="custom-control custom-checkbox custom-control-inline mr-0">
                                        <input type="checkbox" class="custom-control-input" name="example-checkbox1" value="option1">
                                        <span class="custom-control-label">&nbsp;</span>
                                    </label>
                                    <a href="javascript:void(0);" class="mail-star xs-hide"><i class="fa fa-star-o"></i></a>
                                    <h5 class="mb-0">
                                        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#maillist3qq" aria-expanded="true" aria-controls="maillist3qq">John Rosenberg</button>
                                    </h5>
                                    <span class="text_ellipsis xs-hide">There are many variations of passages of Lorem Ipsum available</span>
                                    <div class="card-options">
                                        <a class="text-muted" href="javascript:void(0)"><i class="fa fa-reply"></i></a>
                                        <a class="text-muted" href="javascript:void(0)" class="xs-hide"><i class="fa fa-archive"></i></a>
                                        <a class="text-muted" href="javascript:void(0)" class="xs-hide"><i class="fa fa-clock-o"></i></a>
                                        <a class="text-muted" href="javascript:void(0)"><i class="fa fa-trash"></i></a>                                        
                                        <a class="text-muted" href="app-emailveiw.html"><i class="fa fa-eye"></i></a>
                                    </div>
                                </div>                            
                                <div id="maillist3qq" class="collapse" aria-labelledby="mailheading3qq" data-parent="#accordionExampleas">
                                    <div class="card-body detail">
                                        <div class="detail-header">
                                            <div class="media">
                                                <div class="float-left">
                                                    <div class="mr-3"><img src="../assets/images/xs/avatar5.jpg" alt=""></div>
                                                </div>
                                                <div class="media-body">
                                                    <p class="mb-0"><strong class="text-muted mr-1">From:</strong><a href="javascript:void(0);">info@gmail.com</a><span class="text-muted text-sm float-right">12:48, 23.06.2018</span></p>
                                                    <p class="mb-0"><strong class="text-muted mr-1">To:</strong>Me <small class="float-right"><i class="fe fe-paperclip mr-1"></i>(2 files, 89.2 KB)</small></p>                                        
                                                </div>
                                            </div>
                                        </div>
                                        <div class="mail-cnt">
                                            <p>Hello <strong>Marshall Nichols</strong>,</p><br>
                                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>                                            
                                            <p>Thank youm,<br><strong>Wendy Abbott</strong></p>
                                            <hr>
                                            <strong>Click here to</strong>
                                            <a href="app-compose.html">Reply</a> or
                                            <a href="app-compose.html">Forward</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card mb-1 inbox">
                                <div class="card-header" id="mailheading4qq">
                                    <label class="custom-control custom-checkbox custom-control-inline mr-0">
                                        <input type="checkbox" class="custom-control-input" name="example-checkbox1" value="option1">
                                        <span class="custom-control-label">&nbsp;</span>
                                    </label>
                                    <a href="javascript:void(0);" class="mail-star xs-hide"><i class="fa fa-star-o"></i></a>
                                    <h5 class="mb-0">
                                        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#maillist4qq" aria-expanded="true" aria-controls="maillist4qq">Vinnie Wagstaff</button>
                                    </h5>
                                    <span class="text_ellipsis xs-hide">There are many variations of passages of Lorem Ipsum available</span>
                                    <div class="card-options">
                                        <a class="text-muted" href="javascript:void(0)"><i class="fa fa-reply"></i></a>
                                        <a class="text-muted" href="javascript:void(0)" class="xs-hide"><i class="fa fa-archive"></i></a>
                                        <a class="text-muted" href="javascript:void(0)" class="xs-hide"><i class="fa fa-clock-o"></i></a>
                                        <a class="text-muted" href="javascript:void(0)"><i class="fa fa-trash"></i></a>                                        
                                        <a class="text-muted" href="app-emailveiw.html"><i class="fa fa-eye"></i></a>
                                    </div>
                                </div>                            
                                <div id="maillist4qq" class="collapse" aria-labelledby="mailheading4qq" data-parent="#accordionExampleas">
                                    <div class="card-body detail">
                                        <div class="detail-header">
                                            <div class="media">
                                                <div class="float-left">
                                                    <div class="mr-3"><img src="../assets/images/xs/avatar2.jpg" alt=""></div>
                                                </div>
                                                <div class="media-body">
                                                    <p class="mb-0"><strong class="text-muted mr-1">From:</strong><a href="javascript:void(0);">info@gmail.com</a><span class="text-muted text-sm float-right">12:48, 23.06.2018</span></p>
                                                    <p class="mb-0"><strong class="text-muted mr-1">To:</strong>Me <small class="float-right"><i class="fe fe-paperclip mr-1"></i>(2 files, 89.2 KB)</small></p>                                        
                                                </div>
                                            </div>
                                        </div>
                                        <div class="mail-cnt">
                                            <p>Hello <strong>Marshall Nichols</strong>,</p><br>
                                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>                                            
                                            <p>Thank youm,<br><strong>Wendy Abbott</strong></p>
                                            <hr>
                                            <strong>Click here to</strong>
                                            <a href="app-compose.html">Reply</a> or
                                            <a href="app-compose.html">Forward</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card mb-1 inbox">
                                <div class="card-header" id="mailheading5qq">
                                    <label class="custom-control custom-checkbox custom-control-inline mr-0">
                                        <input type="checkbox" class="custom-control-input" name="example-checkbox1" value="option1">
                                        <span class="custom-control-label">&nbsp;</span>
                                    </label>
                                    <a href="javascript:void(0);" class="mail-star xs-hide"><i class="fa fa-star-o"></i></a>
                                    <h5 class="mb-0">
                                        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#maillist5qq" aria-expanded="true" aria-controls="maillist5qq">Ruben Tillman</button>
                                    </h5>
                                    <span class="text_ellipsis xs-hide">There are many variations of passages of Lorem Ipsum available</span>
                                    <div class="card-options">
                                        <a class="text-muted" href="javascript:void(0)"><i class="fa fa-reply"></i></a>
                                        <a class="text-muted" href="javascript:void(0)" class="xs-hide"><i class="fa fa-archive"></i></a>
                                        <a class="text-muted" href="javascript:void(0)" class="xs-hide"><i class="fa fa-clock-o"></i></a>
                                        <a class="text-muted" href="javascript:void(0)"><i class="fa fa-trash"></i></a>                                        
                                        <a class="text-muted" href="app-emailveiw.html"><i class="fa fa-eye"></i></a>
                                    </div>
                                </div>                            
                                <div id="maillist5qq" class="collapse" aria-labelledby="mailheading5qq" data-parent="#accordionExampleas">
                                    <div class="card-body detail">
                                        <div class="detail-header">
                                            <div class="media">
                                                <div class="float-left">
                                                    <div class="mr-3"><img src="../assets/images/xs/avatar4.jpg" alt=""></div>
                                                </div>
                                                <div class="media-body">
                                                    <p class="mb-0"><strong class="text-muted mr-1">From:</strong><a href="javascript:void(0);">info@gmail.com</a><span class="text-muted text-sm float-right">12:48, 23.06.2018</span></p>
                                                    <p class="mb-0"><strong class="text-muted mr-1">To:</strong>Me <small class="float-right"><i class="fe fe-paperclip mr-1"></i>(2 files, 89.2 KB)</small></p>                                        
                                                </div>
                                            </div>
                                        </div>
                                        <div class="mail-cnt">
                                            <p>Hello <strong>Marshall Nichols</strong>,</p><br>
                                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>                                            
                                            <p>Thank youm,<br><strong>Wendy Abbott</strong></p>
                                            <hr>
                                            <strong>Click here to</strong>
                                            <a href="app-compose.html">Reply</a> or
                                            <a href="app-compose.html">Forward</a>
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

