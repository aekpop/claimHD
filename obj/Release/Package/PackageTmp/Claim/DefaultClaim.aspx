<%@ Page Title="งานอุบัติเหตุ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultClaim.aspx.cs" Inherits="ClaimProject.Claim.DefaultClaim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
  
        <div class="row">
            <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="boxUserSystem">
                <div class="card card-stats">
                    <div class="card-header card-header-danger card-header-icon">
                        <div class="card-icon">
                            <i class="fas fa-car-crash"></i>
                        </div>
                        <h4 class="card-category">
                            <a class="nav-link" href="/Claim/claimForm?add=true">แจ้งอุบัติเหตุ</a>
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
                            <a class="nav-link" href="/Claim/claimForm">รายการแจ้ง</a>
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
                            <a class="nav-link" href="/Claim/claimLine">ส่ง Line</a>
                        </h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div3">
                <div class="card card-stats">
                    <div class="card-header card-header-info card-header-icon">
                        <div class="card-icon">
                            <i class="fas fa-exclamation-triangle"></i>
                        </div>
                        <h4 class="card-category">
                            <a class="nav-link" href="/Claim/ClaimDevice">อุปกรณ์ค้างซ่อม</a>
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
                            <a class="nav-link" href="/ReportView/">ข้อมูลทางสถิติ</a>
                        </h4>
                    </div>
                </div>
            </div>       
        </div>

        <!-- Content Row -->
              <div class="row">

                <!-- Earnings (Monthly) Card Example -->
                <div class="col-xl-3 col-md-6 mb-4">
                  <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <div class="text-xs font-weight-bold text-danger text-uppercase mb-1">เดือน 
                              <asp:Label ID="lbClaimNameMonthly" runat="server" ></asp:Label>
                               
                          </div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                              <div class="col-auto">
                                  <i class="fas fa-calendar fa-2x text-gray-300"></i>
                              </div>
                           </div> 
                         <div class="col-auto">
                              <asp:Label ID="lbClaimStatMonthly" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                          </div>
                        </div>
                      </div>
                    </div>
              
            

                <div class="col-xl-3 col-md-6 mb-4">
                  <div class="card border-left-warning shadow h-100 py-2">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <div class="text-xs font-weight-bold text-secondary text-uppercase mb-1">ปีงบประมาณ 
                              <asp:Label ID="lbClaimNameBudget" runat="server" ></asp:Label>
                          </div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                        <div class="col-auto">
                          <i class="fas fa-bell fa-2x text-gray-300">
                          
                          </i>
                        </div>
                      </div>
                         <asp:Label ID="lbClaimStatBudget" runat="server" Font-Bold="true" CssClass="text-gray " Font-Size="XX-Large"></asp:Label>
                    </div>
                  </div>
                </div>
              
                  <div class="col-xl-3 col-md-6 mb-4">
                  <div class="card border-left-warning shadow h-100 py-2">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <div class="text-xs font-weight-bold text-info text-uppercase mb-1">ทั้งหมด</div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                        <div class="col-auto">
                          <i class="fas fa-history fa-2x text-gray-300"></i>
                        </div>
                      </div>
                        <div class="col-auto">
                              <asp:Label ID="lbClaimStatOverall" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                          </div>
                    </div>
                  </div>
                </div>
            </div>
        </div>
</asp:Content>
