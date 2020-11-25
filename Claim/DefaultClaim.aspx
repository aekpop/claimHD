<%@ Page Title="งานอุบัติเหตุ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultClaim.aspx.cs" Inherits="ClaimProject.Claim.DefaultClaim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }
    </style>

    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">
        <div class="row" runat="server" visible="false">
            <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="boxUserSystem">
                <div class="card card-stats">
                    <div class="card-header card-header-danger card-header-icon">
                        <div class="card-icon">
                            <i class="fas fa-car-crash"></i>
                        </div>
                        <h4 class="card-category">
                            <a class="nav-link" href="/Claim/claimForm?add=true" style="font-family:'Prompt',sans-serif;">แจ้งอุบัติเหตุ</a>
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
                            <a class="nav-link" href="/Claim/claimForm" style="font-family:'Prompt',sans-serif;">รายการแจ้ง</a>
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
                            <a class="nav-link" href="/Claim/claimLine" style="font-family:'Prompt',sans-serif;">ส่ง Line</a>
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
                            <a class="nav-link" href="/Claim/ClaimDevice" style="font-family:'Prompt',sans-serif;">อุปกรณ์ค้างซ่อม</a>
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
                            <a class="nav-link" href="/ReportView/" style="font-family:'Prompt',sans-serif;">ข้อมูลทางสถิติ</a>
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
                          <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">เดือน 
                              <asp:Label ID="lbClaimNameMonthly" runat="server" ></asp:Label>
                          </div>
                        </div>
                              <div class="col-auto">
                                  <i class="fas fa-calendar fa-2x text-gray-300 text-warning"></i>
                              </div>
                           </div> 
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
                          <div class="text-xs font-weight-bold text-success text-uppercase mb-1">ปีงบประมาณ 
                              <asp:Label ID="lbClaimNameBudget" runat="server" ></asp:Label>
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
            <!--</div>

         <div class="row">-->

                
        </div>
        <div class="row">
            <div class="col-xl-6 col-md-6 mb-4">
                  <div class="card border-left-warning shadow h-70 py-2">
                      <div class="card-body">
                        <div class="row no-gutters align-items-center">
                          <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1">กราฟ</div>
                            </div>
                                <div class="col-auto">
                                    <i class="fas fa-chart-bar fa-2x text-gray-300 text-success"></i>
                                </div>
                          </div>
                          <div class="col-auto">
                              <div id="chart" style="width: 600px; height: 250px;"></div>
                          </div>
                        </div>
                      </div>
                </div>

            <div class="col-xl-3 col-md-6 mb-4">
                  <div class="card border-left-primary shadow h-70 py-2">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <div class="text-xs font-weight-bold text-danger text-uppercase mb-1" style="font-family:'Prompt', sans-serif;">สถานะปัจจุบัน
                                        
                          </div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                              <div class="col-auto">
                                  <i class="fas fa-chart-line fa-2x text-gray-300 text-danger"></i>
                              </div>
                           </div> 
                         <div class="row">
                             <div class="container mb-2" style="height:250px">
                                        <div class="table-responsive-sm" >
                                        <table class="table table-sm table-hover" >                                          
                                            <tbody>
                                                <tr class="">
                                                    <th scope="row" class="text-center"></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">แจ้งอุบัติเหตุ</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbTotalSta1" runat="server" ></asp:Label>
                                                    </td>
                                                    </tr>
                                                 <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ส่งเรื่องเข้ากองฯ</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbTotalSta2" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ขอใบเสนอราคา</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbTotalSta3" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">อยู่ระหว่างการซ่อม</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbTotalSta4" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ส่งงาน/เสร็จสิ้น</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbTotalSta5" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">รายงานเพื่อทราบ</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbTotalSta6" runat="server" ></asp:Label>
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
    
</asp:Content>
