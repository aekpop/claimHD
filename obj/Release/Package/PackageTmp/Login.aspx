﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClaimProject.Login" %>

<!DOCTYPE html>

<html lang="th">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=tis-620" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <!--<a href="Login.aspx" style="color:#ffffff">Login.aspx</a> -->
    <link rel="icon" href="favicon.ico">

    <title>ระบบจัดการบริหารงานจัดเก็บ Toll Management System (TMS)</title>

    <!-- Bootstrap core CSS -->
    <link href="/Content/bootstrap.css" rel="stylesheet">
    <link href="/Content/font-awesome.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="/Content/signin.css" rel="stylesheet">
    <link href="/Content/material-dashboard.css" rel="stylesheet" />
    <link href="/Content/form-design-new.css" rel="stylesheet" />
    <link href="/Content/custom-signin.css" rel="stylesheet" />
</head>

<body class="text-center">

    <div class="container text-center">
        <div class="card form-signin">
            <div class="card-header card-header-warning card-header-icon" style="color: black;">
                <div class="card-icon">
                    <img class="mb-4" src="/Content/Images/j4.png" alt="" width="130" height="130">
                </div>
                <p class="card-category">
                    <h3>Toll Management System (TMS)</h3>
                </p>
                <h1 class="h3 mb-3 font-weight-normal">ระบบจัดการบริหารงานจัดเก็บ</h1>
            </div>
            <div class="card-body table-responsive">

                <form class="formLogin" runat="server">
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="msgBox" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text fa fa-user-circle-o" style="font-size: x-large; width: 50px;"></span>
                                </div>
                                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control " placeholder="Username" MaxLength="20"></asp:TextBox>
                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text fa fa-unlock-alt" style="font-size: x-large; width: 50px;"></span>
                                </div>
                                <asp:TextBox TextMode="Password" ID="txtPass" runat="server" CssClass="form-control" placeholder="Password" MaxLength="20"></asp:TextBox><br />
                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text fa fa-road" style="font-size: x-large; width: 50px;"></span>
                                </div>
                                <asp:DropDownList ID="txtCpoint" runat="server" CssClass="form-control" Visible="false" Enabled="false"></asp:DropDownList>
                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend" >
                                    <span class="input-group-text fa fa-building" style="font-size: x-large; width: 50px;" ></span>
                                </div>
                                <asp:DropDownList ID="txtPoint" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                            <asp:Button ID="btnSubmit" runat="server" Text="Login" CssClass="btn btn-warning col-6" OnClick="btnSubmit_Click1" />
                            <br />
                            <asp:LinkButton ID="linkDownload" runat="server" OnClick="linkDownload_Click">Download Google Chrome</asp:LinkButton>
                        </div>
                    </div>
                </form>
            </div>
            <div class="card-footer">
                <div class="stats">
                    <p style="font-size: 18px; text-align: center;">&copy; <%=DateTime.Now.Year%> - ฝ่ายจัดเก็บเงินค่าธรรมเนียม กองทางหลวงพิเศษระหว่างเมือง กรมทางหลวง </p>
                </div>
            </div>
        </div>
        <div class="modal fade " id="modalselectAnnex" tabindex="-1" role="dialog" aria-labelledby="modalselectAnnex" aria-hidden="true">
            <div class="modal-dialog modal-lg modal-dialog-centered " style="width: 480px" role="form">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title"></h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body" style="line-height: inherit;">
                        สวัสดี 
                       <asp:Label ID="lbname" runat="server" CssClass="text-success" ></asp:Label>
                        เลือก Annex ที่ปฎิบัติงาน
                    </div>
                    <div class="modal-footer">
                        
                    </div>
                </div>
            </div>
        </div>      
    </div>

    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap-material-design.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript">
       $(function () {
            <% if (annexGet != "")
        {%>
           $("#modalselectAnnex").modal('show');
           annexGet = "";
            <%}
        else
        {%>
            $("#modalselectAnnex").modal('hide');
            <%}%>
        });
    </script>
    
</body>
</html>
