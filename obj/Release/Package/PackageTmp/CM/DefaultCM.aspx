<%@ Page Title="Maintenance Service Agreement (MA)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultCM.aspx.cs" Inherits="ClaimProject.CM.DefaultCM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container-fluid"> 
        <!--<h3 class="bg-success "  style="font-size:30px;color:white;height:50px">&nbsp;&nbsp;Corrective Maintenance : CM</h3>-->

    <div class="row">
        <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="boxUserSystem">
            <div class="card card-stats">
                <div class="card-header card-header-danger card-header-icon">
                    
                    <div class="card-icon">
                        <i class="fas fa-wrench"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/CM/CMDetailForm">แจ้งซ่อม</a>
                    </h4>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div4">
            <div class="card card-stats">
                <div class="card-header card-header-warning card-header-icon">
                    <div class="card-icon">
                        <i class="fas fa-tools"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/CM/CMEditForm">การแก้ไข</a>
                    </h4>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div1">
            <div class="card card-stats">
                <div class="card-header card-header-success card-header-icon">
                    <div class="card-icon">
                        <i class="fab fa-line"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/CM/CMLine">ส่ง Line</a>
                    </h4>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="height:100px">
        <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div6">
            <div class="card card-stats">
                <div class="card-header card-header-danger card-header-icon">
                    <div class="card-icon">
                        <i class="fas fa-eye"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/CM/CMSurveyForm">ตรวจสอบ</a>
                    </h4>
                </div>
            </div>
        </div>
        
        <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div7">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="fas fa-file-alt"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/CM/CMReport">สรุปรายการ</a>
                    </h4>
                </div>
            </div>
        </div>

    </div>

    <br />

    <!-- content PM -->
    <!--<div runat="server" id="divpm" >
        <h3 class="bg-primary " style="font-size:30px;color:white;height:50px">&nbsp;&nbsp;</h3>
    </div>
     
    

    <div class="row" runat="server" id="divpm2">
        <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div2">
            <div class="card card-stats">
                <div class="card-header card-header-warning card-header-icon">
                    <div class="card-icon">
                        <i class="fas fa-magic"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/PM/PMMainForm">เพิ่มรายการ PM</a>
                    </h4>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div5">
            <div class="card card-stats">
                <div class="card-header card-header-success card-header-icon">
                    <div class="card-icon">
                        <i class="fas fa-cogs"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/PM/PMListForm">บริษัทเข้า PM</a>
                    </h4>
                </div>
            </div>
        </div>
    
        <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div3">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="fas fa-file-alt"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/PM/AdminPMReport">รายงานการ PM</a>
                    </h4>
                </div>
            </div>
        </div>
    </div>
    -->
               <!-- Content Row -->
              <div class="row">

                <!-- Earnings (Monthly) Card Example -->
                  <div class="col-xl-3 col-md-6 mb-4">
                  <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <div class="text-xs font-weight-bold text-success text-uppercase mb-1">วันนี้</div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                              <div class="col-auto">
                                  <i class="fas fa-clock fa-2x text-gray-300"></i>
                              </div>
                           </div> 
                         <div class="col-auto">
                              <asp:Label ID="lbCMStatDay" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                          </div>
                        </div>
                      </div>
                    </div>

                <div class="col-xl-3 col-md-6 mb-4">
                  <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <div class="text-xs font-weight-bold text-danger text-uppercase mb-1">เดือน
                              <asp:Label ID="lbCMNameMonthly" runat="server" ></asp:Label>
                               
                          </div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                              <div class="col-auto">
                                  <i class="fas fa-calendar fa-2x text-gray-300"></i>
                              </div>
                           </div> 
                         <div class="col-auto">
                              <asp:Label ID="lbCMStatMonthly" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
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
                              <asp:Label ID="lbCMNameBudget" runat="server" ></asp:Label>
                          </div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                        <div class="col-auto">
                          <i class="fas fa-bell fa-2x text-gray-300">
                          
                          </i>
                        </div>
                      </div>
                         <asp:Label ID="lbCMStatBudget" runat="server" Font-Bold="true" CssClass="text-gray " Font-Size="XX-Large"></asp:Label>
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
                              <asp:Label ID="lbCMStatOverall" runat="server" Font-Bold="true" CssClass="text-gray" Font-Size="XX-Large"></asp:Label>
                          </div>
                    </div>
                  </div>
                </div>
            </div>
       <div class="row">
           <div class="col-xl-6 col-md">
                  <div class="card border-left-warning shadow h-100 py-2">
                      <div class="card-header" style="font-size:small" >รายการอุปกรณ์แจ้งซ่อมมากที่สุด 5 อันดับแรก ประจำด่านฯ</div>
                      <div class="card-body">
                          <div class="card-body table-responsive table-sm" >
                         <asp:Panel ID="Panel1" runat="server" >
                             <asp:GridView id="lsTodayGridview" runat="server"
                                    CssClass="col table table-striped table-hover"
                                     
                                    HeaderStyle-BackColor="ActiveBorder"
                                    HeaderStyle-Font-Size="18px"
                                    
                                    OnRowDataBound="lsTodayGridview_RowDataBound" 
                                    Font-Size="15px" 
                                    CellPadding="4" 
                                    GridLines="None"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="รายการ" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbDevice" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="จำนวน" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbAmount" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num") %>' ></asp:Label>
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

</asp:Content>
