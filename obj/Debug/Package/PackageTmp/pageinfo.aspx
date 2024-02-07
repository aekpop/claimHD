<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pageinfo.aspx.cs" Inherits="ClaimProject.pageinfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <!-- Bootstrap core CSS -->
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link href="/Content/font-awesome.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="/Content/material-dashboard.css" rel="stylesheet" />
    <link href="/Content/form-design-new.css" rel="stylesheet" />
    <!--<link href="/Content/custom-signin.css" rel="stylesheet" /> -->
    <link href="Content/custom.css" rel="stylesheet" />

    <title>Toll Management System (TMS)</title>
    <style>
        .navbar-brand {
            font-size: 0.5rem;
        }
    </style>
</head>
<body class="d-flex flex-column">
    <div class="container-fluid">
        <nav class="navbar fixed-top navbar-light bg-light">
            <a class="navbar-brand" href="/Login">
                <img class="d-block w-25" src="/Content/Images/information/Banner.png" />
            </a>
            <div class="my-2 my-lg-0">
                <a class="navbar-brand" href="/Login">&nbsp เข้าสู่ระบบ</a>
            </div>
        </nav>
        <br />
        <br />
        <div class="justify-content-center">
            <div class="col-md-12">
                <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                    </ol>
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img src="/Content/Images/information/001_2000.jpg" class="d-block w-100" alt="กิจกรรม" />
                        </div>
                        <div class="carousel-item">
                            <img src="/Content/Images/information/002_2000.jpg" class="d-block w-100" alt="กิจกรรม" />
                        </div>
                        <div class="carousel-item">
                            <img src="/Content/Images/information/003_2000.jpg" class="d-block w-100" alt="กิจกรรม" />
                        </div>
                        <!--<div class="carousel-item">
                <img src="..." class="d-block w-100" alt="..."/>
            </div>-->
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap-material-design.min.js"></script>

</body>
</html>
