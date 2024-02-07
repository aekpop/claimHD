<%@ Page Title="งานบำรุงรักษา" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultCM.aspx.cs" Inherits="ClaimProject.CM.DefaultCM" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Claim.css" rel="stylesheet" />
    <style>
        .table > thead > tr > th,
        .table > tbody > tr > th,
        .table > tfoot > tr > th,
        .table > thead > tr > td,
        .table > tbody > tr > td,
        .table > tfoot > tr > td {
            padding: 0.25rem 0.25rem;
        }

        .card {
            font-size: 1rem;
        }
    </style>
    <div class="container-fluid" style="font-family: 'Prompt',sans-serif;">
        <div class="row">
            <div class="col-xl-3 col-lg-6 col-md-12 col-sm-12" runat="server" id="Div6">
                <div class="card card-stats">
                    <div class="card-header card-header-danger card-header-icon">
                        <div class="card-icon">
                            <i class="fas fa-eye"></i>
                        </div>
                        <h4 class="card-category">
                            <asp:Label ID="lbSurveyNoti" runat="server"></asp:Label>
                            <a class="nav-link" href="/CM/CMSurveyForm" style="font-family: 'Prompt',sans-serif;">ตรวจสอบ</a>
                        </h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-70 py-2">
                    <div class="card-body">
                        <asp:LinkButton ID="lbtnMa" runat="server" OnCommand="lbtnMa_Command">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-danger text-uppercase mb-1">
                                        <asp:Label ID="lbMAtoll" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-clock fa-2x text-gray-300 text-danger"></i>
                                </div>
                            </div>
                            <div class="col-auto">
                                <asp:Label ID="lbAmoMAtoll" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                            </div>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-70 py-2">
                    <div class="card-body">
                        <asp:LinkButton ID="lbtnAir" runat="server" OnCommand="lbtnAir_Command">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                        <asp:Label ID="lbAir" runat="server" Font-Bold="true" CssClass="text-warning"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-clock fa-2x text-gray-300 text-warning"></i>
                                </div>
                            </div>
                            <div class="col-auto">
                                <asp:Label ID="lbAmoMAair" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                            </div>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-70 py-2">
                    <div class="card-body">
                        <asp:LinkButton ID="lbtnAsset" runat="server" OnCommand="lbtnAsset_Command">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                        <asp:Label ID="lbAsset" runat="server" Font-Bold="true" CssClass="text-success"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-clock fa-2x text-gray-300 text-success"></i>
                                </div>
                            </div>
                            <div class="col-auto">
                                <asp:Label ID="lbAmoMAasset" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                            </div>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-70 py-2">
                    <div class="card-body">
                        <asp:LinkButton ID="lbtnHq" runat="server" OnCommand="lbtnHq_Command">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                        <asp:Label ID="lbHq" runat="server" Font-Bold="true" CssClass="text-info">ค้</asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-clock fa-2x text-gray-300 text-info"></i>
                                </div>
                            </div>
                            <div class="col-auto">
                                <asp:Label ID="lbAmoMAhq" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                            </div>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!-- Content Row -->
        <div class="row">
            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-70 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-danger text-uppercase mb-1">
                                    <asp:Label ID="lbdateShow" runat="server" Font-Bold="true" CssClass="text-danger"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-solid fa-calendar-day fa-2x text-gray-300 text-danger"></i>
                            </div>
                        </div>
                        <div class="col-auto">
                            <asp:Label ID="lbCMStatDay" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                        </div>
                        <div class="text-xs font-weight-bold text-danger text-uppercase mb-1 text-right">ซ่อมแล้ว / แก้ไขเบื้องต้น</div>
                        <div class="col-xl text-right">
                            <asp:Label ID="lbFixBack" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="Large"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-80 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                    <!-- เดือน-->
                                    <span class="sr-only">Toggle Dropdown</span>
                                    <asp:DropDownList ID="ddlCMNameMonthly" runat="server" AutoPostBack="true" CssClass="border-white text-warning dropdown-toggle dropdown-toggle-split"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-calendar text-warning fa-2x text-gray-300"></i>
                            </div>
                        </div>
                        <div class="col-auto">
                            <asp:Label ID="lbCMStatMonthly" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                        </div>
                        <div class="text-xs font-weight-bold text-warning text-uppercase mb-1 text-right">ซ่อมแล้ว / แก้ไขเบื้องต้น</div>
                        <div class="col-xl text-right">
                            <asp:Label ID="lbFixbackMonth" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="Large"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-warning shadow h-80 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    ปีงบประมาณ 
                              <asp:Label ID="lbCMNameBudget" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-solid fa-hand-holding-usd fa-2x text-gray-300 text-success"></i>
                            </div>
                        </div>
                        <div class="col-auto">
                            <asp:Label ID="lbCMStatBudget" runat="server" Font-Bold="true" CssClass="text-gray " Font-Size="XX-Large"></asp:Label>
                        </div>
                        <div class="text-xs font-weight-bold text-success text-uppercase mb-1 text-right">ซ่อมแล้ว / แก้ไขเบื้องต้น</div>
                        <div class="col-xl text-right">
                            <asp:Label ID="lbFixbackyear" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="Large"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-warning shadow h-80 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                    <div class="font-weight-bold">ทั้งหมด</div>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-solid fa-globe fa-2x text-gray-300 text-info"></i>
                            </div>
                        </div>
                        <div class="col-auto">
                            <asp:Label ID="lbCMStatOverall" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                        </div>
                        <div class="col-auto">
                            <asp:Label ID="Label1" runat="server" Font-Bold="true" CssClass="text-gray " Font-Size="XX-Large"></asp:Label>
                        </div>
                        <div class="text-xs font-weight-bold text-info text-uppercase mb-1 text-right">ซ่อมแล้ว / แก้ไขเบื้องต้น</div>
                        <div class="col-xl text-right">
                            <asp:Label ID="lbFixbackOverall" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="Large"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div>
                <div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xl-4 col-md">
                <div class="card border-left-warning shadow h-80 py-2">
                    <div class="card-header" style="font-size: large">แจ้งซ่อมมากที่สุด 5 อันดับแรก</div>
                    <div class="card-body">
                        <div class="card-body table-responsive table-sm">
                            <asp:Panel ID="Panel1" runat="server">
                                <asp:GridView ID="lsTodayGridview" runat="server"
                                    CssClass="col table table-striped table-hover"
                                    HeaderStyle-BackColor="White"
                                    HeaderStyle-Font-Size="14px"
                                    OnRowDataBound="lsTodayGridview_RowDataBound"
                                    Font-Size="12px"
                                    CellPadding="4"
                                    GridLines="None"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="รายการ">
                                            <ItemTemplate>
                                                <asp:Label ID="lbDevice" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ครั้ง">
                                            <ItemTemplate>
                                                <asp:Label ID="lbAmount" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-4 col-md">
                <div class="card border-left-warning shadow h-80 py-2">
                    <div class="card-header" style="font-size: large">
                        แจ้งซ่อมมากที่สุด 5 อันดับแรก ประจำเดือน
                          <asp:Label ID="lbTop5CMMonthly" runat="server"></asp:Label>
                    </div>
                    <div class="card-body">
                        <div class="card-body table-responsive table-sm">
                            <asp:Panel ID="Panel2" runat="server">
                                <asp:GridView ID="GridViewNoService" runat="server"
                                    CssClass="col table table-striped table-hover"
                                    HeaderStyle-BackColor="White"
                                    HeaderStyle-Font-Size="14px"
                                    OnRowDataBound="GridViewNoService_RowDataBound"
                                    Font-Size="12px"
                                    CellPadding="4"
                                    GridLines="None"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="รายการ">
                                            <ItemTemplate>
                                                <asp:Label ID="lbMonthDevice" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ครั้ง">
                                            <ItemTemplate>
                                                <asp:Label ID="lbMonthAmount" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-4 col-md">
                <div class="card border-left-warning shadow h-80 py-2">
                    <div class="card-header" style="font-size: large">ค้างซ่อมล่าช้า 5 อันดับแรก</div>
                    <div class="card-body">
                        <div class="card-body table-responsive table-sm">
                            <asp:Panel ID="Panel3" runat="server">
                                <asp:GridView ID="GridViewNoFix" runat="server"
                                    CssClass="col table table-striped table-hover"
                                    HeaderStyle-BackColor="White"
                                    HeaderStyle-Font-Size="14px"
                                    OnRowDataBound="GridViewNoFix_RowDataBound"
                                    Font-Size="12px"
                                    CellPadding="4"
                                    GridLines="None"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="รายการ">
                                            <ItemTemplate>
                                                <asp:Label ID="lbnofixDevice" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="วันที่">
                                            <ItemTemplate>
                                                <asp:Label ID="lbDaynoFix" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_sdate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/Scripts/bootstrap.bundle.js"></script>
    <script src="/Scripts/jquery-migrate-3.0.0.min.js"></script>
    <script type="text/javascript">
        function refresh() {
            window.location.reload(true);
        }
        setTimeout(refresh, 300000);

        history.pushState(null, null, window.location.href);
        history.back();
        window.onpopstate = () => history.forward();
    </script>
</asp:Content>
