<%@ Page Title="งานครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipDefault.aspx.cs" Inherits="ClaimProject.equip.EquipDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }
    </style>
    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">
   
        <asp:Button runat="server" ID="btnMainEQtt" Text="หน้าหลัก"  OnClick="btnMainEQtt_Click" CssClass="btn btn-default" />
        <br />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <!--<div class="row" style="height:100px">
                    <div class="col-md " >
                        <div class="form-group" style="padding:1px 1px 1px 30px">
                            <asp:Label ID="Label1" runat="server" Text="ปีงบประมาณ :"></asp:Label>
                            <asp:DropDownList ID="txtBudgetYear" runat="server" BorderStyle="NotSet" Width="120px" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="txtBudgetYear_SelectedIndexChanged">
                        </asp:DropDownList>
                        </div>
                    
                    </div>
                
                </div>-->
                 <!-- ตารางสถานปัจจุบัน-->
               <div class="row">
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
                             <div class="container mb-2">
                                        <div class="table-responsive-sm">
                                        <table class="table table-sm table-hover">                                          
                                            <tbody>
                                                <tr class="">
                                                    <th scope="row" class="text-center"></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ครุภัณฑ์รวม</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbEqTotal" runat="server" ></asp:Label>
                                                    </td>
                                                    </tr>
                                                 <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ครุภัณฑ์สภาพดี</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbEqNorm" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ครุภัณฑ์ชำรุด</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbEqBork" runat="server" ></asp:Label>
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
                   <div class="col-xl-3 col-md-6 mb-4">
                  <div class="card border-left-primary shadow h-70 py-2">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <div class="text-xs font-weight-bold text-danger text-uppercase mb-1" style="font-family:'Prompt', sans-serif;">โอนย้าย      
                          </div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                              <div class="col-auto">
                                  <i class="fas fa-chart-line fa-2x text-gray-300 text-danger"></i>
                              </div>
                           </div> 
                         <div class="row">
                             <div class="container mb-2">
                                        <div class="table-responsive-sm">
                                        <table class="table table-sm table-hover">                                          
                                            <tbody>
                                                <tr class="">
                                                    <th scope="row" class="text-center"></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ส่งคืน</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbStaSent" runat="server" ></asp:Label>
                                                    </td>
                                                    </tr>
                                                 <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ส่งซ่อม</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbStaClaim" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">โอนย้าย</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbStaTransfer" runat="server" ></asp:Label>
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
              
                <div class="row">
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="Div7">
                        <div class="card card-stats" >
                            <div class="card-header card-header-danger card-header-icon" >
                                <div class="card-icon ">
                                    <i class="fas fa-plus"></i>
                                </div>
                                <h4 class="card-category" style="font-size:32px;">แจ้งใหม่</h4>
                                <h4 class="card-title">
                                
                                    <asp:Label ID="lbnew" runat="server"   Text=""></asp:Label>/
                                
                                    <asp:Label ID="lbnew1" runat="server"  Text=""></asp:Label>
                                </h4>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnNewTranDetail" runat="server" OnClick="lbtnNewTranDetail_Click">รายละเอียด</asp:LinkButton>
                            
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="receive">
                        <div class="card card-stats" >
                            <div class="card-header card-header-warning card-header-icon" >
                                <div class="card-icon ">
                                    <i class="fas fa-receipt"></i>
                                </div>
                                <h4 class="card-category" style="font-size:32px;">รับใหม่</h4>
                                <h4 class="card-title">
                                
                                    <asp:Label ID="lbreceive" runat="server"  ForeColor="Black" Text=""></asp:Label>
                                    /
                                    <asp:Label ID="lbreceive2" runat="server" ForeColor="Black" Text=""></asp:Label>
                                </h4>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnReceiveDetail" runat="server" OnClick="lbtnReceiveDetail_Click">รายละเอียด</asp:LinkButton>
                            
                                </div>
                            </div>
                        </div>
                    </div>
             </div>
                <div class="row"> 
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div6">
                        <div class="card card-stats" >
                            <div class="card-header card-header-success card-header-icon" >
                                <div class="card-icon ">
                                    <i class="fas fa-exchange-alt"></i>
                                </div>
                                <h4 class="card-category" style="font-size:32px;">โอนย้าย</h4>
                                <h4 class="card-title">
                                
                                    <asp:Label ID="lbTran" runat="server"  ForeColor="Black" Text=""></asp:Label>
                                     /
                                    <asp:Label ID="lbTran2" runat="server" ForeColor="Black" Text=""></asp:Label>
                                </h4>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnTranDetail" runat="server" OnClick="lbtnTranDetail_Click">รายละเอียด</asp:LinkButton>
                            
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div3" >
                        <div class="card card-stats" >
                            <div class="card-header card-header-secondary card-header-icon" >
                                <div class="card-icon" >
                                    <i class="fa fa-wrench"></i>
                                </div>
                                <h5 class="card-category" style="font-size:32px;">ส่งซ่อม</h5>
                                <h4 class="card-title">
                                    <asp:Label ID="lbRepair" runat="server" ForeColor="Black" Text=""></asp:Label>
                                     / 
                                    <asp:Label ID="lbRepair2" runat="server" ForeColor="Black" Text=""></asp:Label>
                                </h4>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnRepairDetail" runat="server" OnClick="lbtnRepairDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div5" >
                        <div class="card card-stats" >
                            <div class="card-header card-header-rose card-header-icon" >
                                <div class="card-icon">
                                    <i class="fas fa-people-carry" ></i>
                                </div>
                                <h5 class="card-category" style="font-size:32px;">ส่งคืน</h5>
                                <h4 class="card-title">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" ></asp:Label>
                                    /
                                    <asp:Label ID="Label3" runat="server" ForeColor="Black" ></asp:Label>
                                </h4>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtnCopyDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                
                
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div1">
                        <div class="card card-stats" >
                            <div class="card-header card-header-warning card-header-icon" >
                                <div class="card-icon">
                                    <i class="fas fa-luggage-cart"></i>
                                </div>
                                <h5 class="card-category" style="font-size:32px;">ส่งคืนกองฯ</h5>
                                <h4 class="card-title">
                                    <asp:Label ID="lbSendHead" runat="server" ForeColor="Black" Text=""></asp:Label>
                                     /
                                    <asp:Label ID="lbSendHead2" runat="server" ForeColor="Black" Text=""></asp:Label>
                                </h4>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnSendHeadDetail" runat="server" OnClick="lbtnSendHeadDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

          
              
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div4" >
                        <div class="card card-stats" >
                            <div class="card-header card-header-info card-header-icon" >
                                <div class="card-icon">
                                    <i class="fas fa-sync" ></i>
                                </div>
                                <h5 class="card-category" style="font-size:32px;">ทดแทน</h5>
                                <h4 class="card-title">
                                    <asp:Label ID="lbCopy" runat="server" ForeColor="Black" ></asp:Label>
                                     /
                                    <asp:Label ID="lbCopy2" runat="server" ForeColor="Black" ></asp:Label>
                                </h4>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnCopyDetail" runat="server" OnClick="lbtnCopyDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
 
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div2" >
                        <div class="card card-stats" >
                            <div class="card-header card-header-warning card-header-icon" >
                                <div class="card-icon" >
                                    <i class="fas fa-truck-loading"></i>
                                </div>
                                <h5 class="card-category" style="font-size:32px;">แทงจำหน่าย</h5>
                                <h4 class="card-title">
                                    <asp:Label ID="lbSell" runat="server" ForeColor="Black" ></asp:Label>
                                     /
                                    <asp:Label ID="lbSell2" runat="server" ForeColor="Black" ></asp:Label>
                                </h4>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnSellDetail" runat="server" OnClick="lbtnSellDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div8" >
                        <div class="card card-stats" >
                            <div class="card-header card-header-dark card-header-icon" >
                                <div class="card-icon">
                                    <i class="fas fa-align-justify" ></i>
                                </div>
                                <h5 class="card-category" style="font-size:32px;">รายการส่งออกทั้งหมด</h5>
                                <h4 class="card-title">
                                    <asp:Label ID="lbTotal" runat="server" ForeColor="Black" ></asp:Label>
                                     /
                                    <asp:Label ID="lbTotal2" runat="server" ForeColor="Black" ></asp:Label>
                                </h4>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lbtnTotalDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
               
               <!-- <div class="row" >
                    <asp:Chart ID="Chart1" runat="server"  BackImageAlignment="Center" Width="1000" Height="400"  >
                                   <Series>
                                       <asp:Series Name="Series1" BorderWidth="2" >
                                       </asp:Series>
                                       <asp:Series Name="Series2" BorderWidth="2" >
                                       </asp:Series>
                                       <asp:Series Name="Series3" BorderWidth="2" >
                                       </asp:Series>
                                       <asp:Series Name="Series4" BorderWidth="2" >
                                       </asp:Series>
                                       <asp:Series Name="Series5" BorderWidth="2" >
                                       </asp:Series>
                                       <asp:Series Name="Series6" BorderWidth="2" >
                                       </asp:Series>
                                   </Series>
                                   <ChartAreas>
                                       <asp:ChartArea Name="ChartArea1"  >
                                       </asp:ChartArea>
                                   </ChartAreas>
                                  </asp:Chart>
                </div>
                -->           
            </ContentTemplate>
        </asp:UpdatePanel>
        <script type="text/javascript">
            function CompareConfirm(msg) {
                var str1 = "1";
                var str2 = "2";

                if (str1 === str2) {
                    // your logic here
                    return false;
                } else {
                    // your logic here
                    return confirm(msg);
                }
            }
        </script>




     </div>
</asp:Content>
