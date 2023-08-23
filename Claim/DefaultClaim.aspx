<%@ Page Title="งานอุบัติเหตุ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultClaim.aspx.cs" Inherits="ClaimProject.Claim.DefaultClaim" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Claim.css" rel="stylesheet" />

    <div class="container-fluid" style="font-family: 'Prompt',sans-serif;">

        <div class="row" runat="server" visible="false">
            <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div5">
                <div class="card card-stats">
                    <div class="card-header card-header-danger card-header-icon">
                        <div class="card-icon">
                            <i class="fas fa-car-crash"></i>
                        </div>
                        <h4 class="card-category"></h4>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="boxUserSystem">
                <div class="card card-stats">
                    <div class="card-header card-header-danger card-header-icon">
                        <div class="card-icon">
                            <i class="fas fa-car-crash"></i>
                        </div>
                        <h4 class="card-category">
                            <a class="nav-link" href="/Claim/claimForm?add=true" style="font-family: 'Prompt',sans-serif;">แจ้งอุบัติเหตุ</a>
                        </h4>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div2">
                <div class="card card-stats">
                    <div class="card-header card-header-warning card-header-icon">
                        <div class="card-icon">
                            <i class="fas fa-stream"></i>
                        </div>
                        <h4 class="card-category">
                            <a class="nav-link" href="/Claim/claimForm" style="font-family: 'Prompt',sans-serif;">รายการแจ้ง</a>
                        </h4>
                    </div>
                </div>
            </div>

            <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div4">
                <div class="card card-stats">
                    <div class="card-header card-header-success card-header-icon">
                        <div class="card-icon">
                            <i class="fab fa-line"></i>
                        </div>
                        <h4 class="card-category">
                            <a class="nav-link" href="/Claim/claimLine" style="font-family: 'Prompt',sans-serif;">ส่ง Line</a>
                        </h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" runat="server" visible="false">
            <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div3">
                <div class="card card-stats">
                    <div class="card-header card-header-info card-header-icon">
                        <div class="card-icon">
                            <i class="fas fa-exclamation-triangle"></i>
                        </div>
                        <h4 class="card-category">
                            <a class="nav-link" href="/Claim/ClaimDevice" style="font-family: 'Prompt',sans-serif;">อุปกรณ์ค้างซ่อม</a>
                        </h4>
                    </div>
                </div>
            </div>

            <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div1">
                <div class="card card-stats">
                    <div class="card-header card-header-info card-header-icon">
                        <div class="card-icon">
                            <i class="fas fa-file-alt"></i>
                        </div>
                        <h4 class="card-category">
                            <a class="nav-link" href="/ReportView/" style="font-family: 'Prompt',sans-serif;">ข้อมูลทางสถิติ</a>
                        </h4>
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
                                    รหัสด่านฯ                              
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-home fa-2x text-gray-300 text-danger"></i>
                            </div>
                        </div>
                        <div class="col-auto">
                            <asp:Label ID="lbcpoint" runat="server" CssClass="text-gray" Font-Size="XX-Large" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-70 py-2">
                    <div class="card-body">
                        <asp:LinkButton ID="lbtnClaim" runat="server" OnCommand="lbtnClaim_Command">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                        เดือน 
                              <asp:Label ID="lbClaimNameMonthly" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-calendar fa-2x text-gray-300 text-warning"></i>
                                </div>
                            </div>
                        </asp:LinkButton>
                        <div class="col-auto">
                            <asp:Label ID="lbClaimStatMonthly" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-warning shadow h-70 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    ปีงบประมาณ 
                              <asp:Label ID="lbClaimNameBudget" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-bell fa-2x text-gray-300 text-success"></i>
                            </div>
                        </div>
                        <asp:Label ID="lbClaimStatBudget" runat="server" Font-Bold="true" CssClass="text-gray " Font-Size="XX-Large"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-warning shadow h-70 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1">ทั้งหมด</div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-history fa-2x text-gray-300 text-info"></i>
                            </div>
                        </div>
                        <div class="col-auto">
                            <asp:Label ID="lbClaimStatOverall" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xl-9 col-md-12 mb-4">
                <div class="card border-left-primary shadow py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="font-family: 'Prompt', sans-serif;">
                                     <asp:DropDownList ID="ddlstatus" runat="server" CssClass="dropdown " Visible="true"></asp:DropDownList>
                                </div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-chart-line fa-2x text-gray-300 text-info"></i>
                            </div>
                        </div>
                        <canvas id="myChart" style="width: 100%;"></canvas>
                    </div>
                </div>
            </div>
            
            <div class="col-xl-3 col-md-12 mb-4">
                <div class="card border-left-primary shadow py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="font-family: 'Prompt', sans-serif;">
                                    สถานะทั้งหมด                                    
                                </div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-table fa-2x text-gray-300 text-info"></i>
                            </div>
                        </div>
                        <div class="row">
                            <div class="container mb-2">
                                <div class="table-responsive-sm">
                                    <table class="table table-sm table-hover">
                                        <tbody>
                                            <tr class="">
                                                <th scope="row" class="text-center"></th>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">แจ้งอุบัติเหตุ</td>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">
                                                    <asp:Label ID="lbTotalSta1" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="">
                                                <th scope="row" class="text-center"></th>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">รายงานอุบัติเหตุ (ส่งกอง)</td>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">
                                                    <asp:Label ID="lbTotalSta2" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="">
                                                <th scope="row" class="text-center"></th>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">เสนอราคา</td>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">
                                                    <asp:Label ID="lbTotalSta3" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="">
                                                <th scope="row" class="text-center"></th>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">ประเมินราคา (ส่งนิติกร)</td>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">
                                                    <asp:Label ID="lbTotalSta4" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="">
                                                <th scope="row" class="text-center"></th>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">ส่งงาน/เสร็จสิ้น</td>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">
                                                    <asp:Label ID="lbTotalSta5" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="">
                                                <th scope="row" class="text-center"></th>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">รายงานเพื่อทราบ</td>
                                                <td class="text-nowrap" style="font-size: 15px; font-family: 'Prompt', sans-serif;">
                                                    <asp:Label ID="lbTotalSta6" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/Scripts/Chart.min.js"></script>
    <script type="text/javascript">  
        $(document).ready(function () {
            LoadChart();
        });

        function LoadChart() {
            var e = document.getElementById('<%= ddlstatus.ClientID %>');
            var getYear = e.options[e.selectedIndex].value;
            var labelS = "อุบัติเหตุรวม";
            var labelS1 = "อุบัติเหตุซ่อมแล้วเสร็จ";
            var cpoint = document.getElementById('<%= lbcpoint.ClientID %>').innerHTML;
            var jsonData = JSON.stringify({
                status: getYear, cp: cpoint
            });
                      
            $.ajax({
                type: "POST",
                url: "DefaultClaim.aspx/getLineChartData",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess_,
                error: OnErrorCall_
            });

            function OnSuccess_(reponse) {
                var aData = reponse.d;
                var aLabels = [];
                var aDatasets1 = [];
                var aDatasets2 = [];

                 aLabels = aData[0];
                aDatasets1 = aData[1];
                aDatasets2 = aData[2];

                console.log(aDatasets2);

                var data = {
                    labels:  aLabels ,
                    datasets: [{
                        label: labelS,
                        data: aDatasets1,
                        barPercentage: 0.9,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(255, 99, 132, 0.2)'
                           
                        ],
                        borderColor: [
                            'rgb(255, 99, 132)',
                            'rgb(255, 99, 132)',
                            'rgb(255, 99, 132)',
                            'rgb(255, 99, 132)',
                            'rgb(255, 99, 132)',
                            'rgb(255, 99, 132)',
                            'rgb(255, 99, 132)',
                            'rgb(255, 99, 132)'
                           
                        ],
                        borderWidth: 1
                    },
                        {
                        label: labelS1,
                        data: aDatasets2,
                        barPercentage: 0.9,
                        backgroundColor: [
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(75, 192, 192, 0.2)'

                        ],
                        borderColor: [
                            'rgb(75, 192, 192)',
                            'rgb(75, 192, 192)',
                            'rgb(75, 192, 192)',
                            'rgb(75, 192, 192)',
                            'rgb(75, 192, 192)',
                            'rgb(75, 192, 192)',
                            'rgb(75, 192, 192)',
                            'rgb(75, 192, 192)'

                        ],
                        borderWidth: 1
                    }
                    ]
                };

                var config = {
                    type: 'bar',
                    data: data,
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            }
                        }
                    }
                };

                var ctx = document.getElementById('myChart');
                var chart = new Chart(ctx, config);

                $("[id*=ddlstatus]").bind("change", function () {
                    
                });
            } 

            function OnErrorCall_(reponse) {
                alert("Woops something went wrong, pls try later !");
            }           
        }

    </script>
</asp:Content>
