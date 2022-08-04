<%@ Page Title="Setting/Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="settingPage.aspx.cs" Inherits="ClaimProject.settingPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!-- CSS only -->
    <link href="/Content/form-design-new.css" rel="stylesheet" />
    <link href="../Content/CM.css" rel="stylesheet" />

    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">

    <div class="card">
        <div class="card-header card-header-warning">
            <div class="card-title">เมนู</div>
        </div>
        <div class="card-body table-responsive">
            <div class="row text-center">
                <div class="col-md-2">
                    <a class="nav-link" href="/User/Add/userForm">
                        <i class="fa fa-address-book-o" style="font-size: 22px;"></i>
                        <div class="text-black-50 ">เพิ่มผู้ใช้งาน</div>
                    </a>
                </div>
                <div class="col-md-2">
                    <a class="nav-link" href="/Device/DeviceForm">
                        <i class="fa fa-cubes" style="font-size: 22px;"></i>
                        <div class="text-black-50 ">รายการอุปกรณ์</div>
                    </a>
                </div>
                <div class="col-md-2">
                    <a class="nav-link" href="/Device/DeviceDiff">
                        <i class="fa fa-cubes" style="font-size: 22px;"></i>
                        <div class="text-black-50 ">รายการอุปกรณ์ยกเว้น</div>
                    </a>
                </div>
                <div class="col-md-2">
                    <a class="nav-link" href="/Device/GroupDeviceForm">
                        <i class="fa fa-gears" style="font-size: 22px;"></i>
                        <div class="text-black-50 ">กลุ่มอุปกรณ์</div>
                    </a>
                </div>
                <div class="col-md-2">
                    <a class="nav-link" href="/Company/CompanyForm">
                        <i class="fa fa-handshake-o" style="font-size: 22px;"></i>
                        <div class="text-black-50 ">รายการบริษัท</div>
                    </a>
                </div>
                <div class="col-md-2">
                    <a class="nav-link" href="/car/car">
                        <i class="fa fa-car" style="font-size: 22px;"></i>
                        <div class="text-black-50 ">ยี่ห้อรถ</div>
                    </a>
                </div>
            </div>
        </div>
    </div>
        </div>
</asp:Content>
