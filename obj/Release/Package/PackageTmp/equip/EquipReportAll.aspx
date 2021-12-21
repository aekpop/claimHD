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
        .table > tbody > tr > th,
        .table > tbody > tr > td  {
            padding: 5px 50px 5px 5px;
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
    <div class="container" style="font-family:'Prompt',sans-serif">
        <div class="card">
            <div class="card-header">
                <div class="card-title">รายงานรับครุภัณฑ์</div>
            </div>

            <div class="card-body" style="padding:10px;">
                <asp:GridView ID="gridReport" runat="server"
                    AutoGenerateColumns="false"
                    OnRowDataBound="gridReport_RowDataBound"
                    CssClass="table table-hover table-bordered table-sm"
                    HeaderStyle-Font-Size="18px"
                    HeaderStyle-Height="50px"
                    GridLines="None" 
                    AllowSorting="true"                   
                    Font-Size="16px"
                    RowStyle-Height="50px"
                    
                >
                    <Columns>                        
                        <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-left" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                            <ItemTemplate>
                                <asp:Label ID="lbpktrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="จำนวน (รายการ)" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                            <ItemTemplate>
                                <asp:Label ID="lbAmount" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ครั้ง") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                    </Columns>
                </asp:GridView>
                </div>
                <div class="row" style="padding-left:20px;" >
                    <asp:Label ID="lbAmountgrid" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="#0022ff" ></asp:Label>
                
            </div>
        </div>
        <div class="card">
            <div class="card-header">
                <div class="card-title">รายงานส่งครุภัณฑ์</div>
            </div>

            <div class="card-body" style="padding:10px;">
                <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="false"
                    OnRowDataBound="GridView1_RowDataBound"
                    CssClass="table table-hover table-bordered table-sm"
                    HeaderStyle-Font-Size="18px"
                    HeaderStyle-Height="50px"
                    GridLines="None" 
                    AllowSorting="true"                   
                    Font-Size="16px"
                    RowStyle-Height="50px"
                    
                >
                    <Columns>                        
                        <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-left" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                            <ItemTemplate>
                                <asp:Label ID="lbpktrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="จำนวน (รายการ)" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                            <ItemTemplate>
                                <asp:Label ID="lbAmount" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ครั้ง") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                </div>
                <div class="row" style="padding-left:20px;" >
                    <asp:Label ID="Label1" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="#0022ff" ></asp:Label>
                
            </div>
        </div>
    </div>
</asp:Content>
