<%@ Page Title="รายงาน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipReportAll.aspx.cs" Inherits="ClaimProject.equip.EquipReportAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }
    </style>

    <div class="container-fluid" style="font-family:'Prompt',sans-serif">
        <div id="Report" runat="server" class="card" style="z-index: 0">
            <div class="card-header card-header-info" >
                <div class="card-title" >รายงาน</div>
                    <div class="card-body table-responsive table-sm">
                        <div class="row" > 
                            <div class="col-md-6 col-xl-3">
                                <div class="form-group">
                                <asp:Label ID="lbreportGroup" runat="server" Text="ประเภทของรายงาน : " ></asp:Label>
                                <asp:DropDownList ID="ddlreportType" runat="server"  CssClass="form-control" ></asp:DropDownList>
                               </div>
                            </div>
                            <div class="col-md-6 col-xl-3">
                                <div class="form-group">
                                <asp:Label ID="lbreportToll" runat="server" Text="ด่านฯ : " ></asp:Label>
                                <asp:DropDownList ID="ddlreportToll" runat="server"  CssClass="form-control" ></asp:DropDownList>
                               </div>
                            </div>
                            <div class="col-md-6 col-xl-3">
                                <div class="form-group">
                                <asp:Label ID="lbreportBudget" runat="server" Text="ปีงบประมาณ : " ></asp:Label>
                                <asp:DropDownList ID="ddlreportBudget" runat="server"  CssClass="form-control" ></asp:DropDownList>
                               </div>
                            </div>
                            <div class="col-md-6 col-xl-3">
                                <div class="form-group">
                                <asp:Label ID="lbreportMonth" runat="server" Text="เดือน : " ></asp:Label>
                                <asp:DropDownList ID="ddlreportMonth" runat="server"  CssClass="form-control" ></asp:DropDownList>
                               </div>
                            </div>
                            <div class="col-12 row">                       
                            <div class="col-md-12 col-xl-12 text-center">
                                <div class="form-group">
                                <asp:LinkButton ID="lbtnreportQ" runat="server" ToolTip="กดค้นหา" Font-Size="XX-Large" CssClass="fa fa-search text-center text-secondary border-success" OnCommand="lbtnreportQ_Command">&nbspค้นหา</asp:LinkButton>
                               </div>
                            </div>
                        </div>
                       </div>
                   </div>
            </div>
        </div>
    </div>
</asp:Content>
