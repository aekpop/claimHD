<%@ Page Title="งานครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipDefault.aspx.cs" Inherits="ClaimProject.equip.EquipDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }
    </style>

    <!-- CSS only -->
    <link href="../Content/CM.css" rel="stylesheet" />

    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">
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
                <div class="alert alert-warning alert-dismissible fade show" id="alertWaitTrans" runat="server" >
                       <div class =" row">
                       <button type="button" class="close" data-dismiss="alert" aria-hidden="false">&times;</button>
                           <asp:LinkButton runat="server" ID="btnDetails" OnClick="lbtnReceiveDetail_Click">
                               <div class="col">
                                    <div class="row">
                                        ขณะนี้มีรายการรอรับครุภัณฑ์ &nbsp<asp:Label runat="server" ID="lbAmountWait" ></asp:Label>&nbsp รายการ
                                   </div>
                                 </div>
                               </asp:LinkButton>
                           </div>
                   </div>
                 <!-- ตารางสถานปัจจุบัน-->
               <div class="row">
                <div class="col-xl-4 col-md-6 mb-4">
                  <div class="card border-left-primary shadow h-70 py-2">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="font-family:'Prompt', sans-serif;">สถานะครุภัณฑ์
                                        
                          </div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                              <div class="col-auto">
                                  <i class="fas fa-chart-line fa-2x text-gray-300 text-info"></i>
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
                   <div class="col-xl-4 col-md-6 mb-4" id="tblToll" runat="server" >
                  <div class="card border-left-primary shadow h-70 py-2">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="font-family:'Prompt', sans-serif;">สถานะโอนย้าย       
                          </div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                              <div class="col-auto">
                                  <i class="fas fa-chart-line fa-2x text-gray-300 text-info"></i>
                              </div>
                           </div> 
                         <div class="row">
                             <div class="container mb-2">
                                        <div class="table-responsive-sm">
                                        <table class="table table-sm table-hover">                                          
                                            <tbody>
                                                <tr class="">
                                                    <th scope="row" class="text-center"></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">รับเข้า</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbStaRecieptToll" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="">
                                                    <th scope="row" class="text-center"></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ส่งคืนฝ่ายฯ</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbStaSentToll" runat="server" ></asp:Label> / <asp:Label ID="lbeqSentToll" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ส่งซ่อม</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbStaClaimToll" runat="server" ></asp:Label> / <asp:Label ID="lbeqClaimToll" runat="server" ></asp:Label>
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
                   
                <div class="col-xl-4 col-md-6 mb-4" id="tblClerical" runat="server">
                  <div class="card border-left-primary shadow h-40 py-2">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <div class="text-xs font-weight-bold text-danger text-uppercase mb-1" style="font-family:'Prompt', sans-serif;">สถานะโอนย้าย </div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800"></div>
                        </div>
                              <div class="col-auto">
                                  <i class="fas fa-chart-line fa-2x text-gray-300 text-danger"></i>
                              </div>
                         </div> 
                         <div class="row">
                             <div class="container mb-2">
                                        <div class="table-responsive-sm">
                                        <table class="table table-sm table-hover" >                                          
                                            <tbody>
                                                <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">รับเข้า</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbStaTransfer" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="">
                                                    <th scope="row" class="text-center" ></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">โอนย้าย(ส่งออก)</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbStatrans" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="">
                                                    <th scope="row" class="text-center"></th>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ส่งคืนกองฯ</td>
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
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">ยืม</td>
                                                    <td class="text-nowrap" style="font-size:15px; font-family:'Prompt', sans-serif;">
                                                        <asp:Label ID="lbStaRent" runat="server" ></asp:Label><asp:Label ID="Label4" runat="server" ></asp:Label>
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
                                <div class="card-category" style="font-size:32px;">แจ้งใหม่</div>
                                <div class="card-title">
                                
                                    <asp:Label ID="lbnew" runat="server"   Text=""></asp:Label>/
                                
                                    <asp:Label ID="lbnew1" runat="server"  Text=""></asp:Label>
                                </div>
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
                                <div class="card-category" style="font-size:32px;">รับใหม่</div>
                                <div class="card-title">
                                
                                    <asp:Label ID="lbreceive" runat="server"  ForeColor="Black" Text=""></asp:Label>
                                    /
                                    <asp:Label ID="lbreceive2" runat="server" ForeColor="Black" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnReceiveDetail" runat="server" OnClick="lbtnReceiveDetail_Click">รายละเอียด</asp:LinkButton>
                            
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div3" visible="true" >
                        <div class="card card-stats" >
                            <div class="card-header card-header-secondary card-header-icon" >
                                <div class="card-icon" >
                                    <i class="fa fa-wrench"></i>
                                </div>
                                <div class="card-category" style="font-size:32px;">ซ่อม</div>
                                <div class="card-title">
                                    <asp:Label ID="lbRepair" runat="server" ForeColor="Black" Text=""></asp:Label>
                                     / 
                                    <asp:Label ID="lbRepair2" runat="server" ForeColor="Black" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnRepairDetail" runat="server" OnClick="lbtnRepairDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                     <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="dvRent" visible="true">
                        <div class="card card-stats" >
                            <div class="card-header card-header-info card-header-icon" >
                                <div class="card-icon">
                                    <i class="fas fa-align-justify" ></i>
                                </div>
                                <div class="card-category" style="font-size:32px;">ยืม</div>
                                <div class="card-title">
                                    <asp:Label ID="lbrent" runat="server" ForeColor="Black" ></asp:Label>
                                     /
                                    <asp:Label ID="lbrentamount" runat="server" ForeColor="Black" ></asp:Label>
                                </div>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                                        <asp:LinkButton ID="btnRent" runat="server" OnClick="btnRent_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

             </div>
                <div class="row"> 
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div6" visible="false">
                        <div class="card card-stats" >
                            <div class="card-header card-header-success card-header-icon" >
                                <div class="card-icon ">
                                    <i class="fas fa-exchange-alt"></i>
                                </div>
                                <div class="card-category" style="font-size:32px;">โอนย้าย</div>
                                <div class="card-title">
                                
                                    <asp:Label ID="lbTran" runat="server"  ForeColor="Black" Text=""></asp:Label>
                                     /
                                    <asp:Label ID="lbTran2" runat="server" ForeColor="Black" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnTranDetail" runat="server" OnClick="lbtnTranDetail_Click">รายละเอียด</asp:LinkButton>
                            
                                </div>
                            </div>
                        </div>
                    </div>

                    

                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div5" visible="false">
                        <div class="card card-stats" >
                            <div class="card-header card-header-rose card-header-icon" >
                                <div class="card-icon">
                                    <i class="fas fa-people-carry" ></i>
                                </div>
                                <div class="card-category" style="font-size:32px;">ส่งคืน</div>
                                <div class="card-title">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" ></asp:Label>
                                    /
                                    <asp:Label ID="Label3" runat="server" ForeColor="Black" ></asp:Label>
                                </div>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtnCopyDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                
                
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div1" visible="false">
                        <div class="card card-stats" >
                            <div class="card-header card-header-warning card-header-icon" >
                                <div class="card-icon">
                                    <i class="fas fa-luggage-cart"></i>
                                </div>
                                <div class="card-category" style="font-size:32px;">ส่งคืนกองฯ</div>
                                <div class="card-title">
                                    <asp:Label ID="lbSendHead" runat="server" ForeColor="Black" Text=""></asp:Label>
                                     /
                                    <asp:Label ID="lbSendHead2" runat="server" ForeColor="Black" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnSendHeadDetail" runat="server" OnClick="lbtnSendHeadDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

          
              
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div4" visible="false">
                        <div class="card card-stats" >
                            <div class="card-header card-header-info card-header-icon" >
                                <div class="card-icon">
                                    <i class="fas fa-sync" ></i>
                                </div>
                                <div class="card-category" style="font-size:32px;">ทดแทน</div>
                                <div class="card-title">
                                    <asp:Label ID="lbCopy" runat="server" ForeColor="Black" ></asp:Label>
                                     /
                                    <asp:Label ID="lbCopy2" runat="server" ForeColor="Black" ></asp:Label>
                                </div>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnCopyDetail" runat="server" OnClick="lbtnCopyDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
 
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div2" visible="false">
                        <div class="card card-stats" >
                            <div class="card-header card-header-warning card-header-icon" >
                                <div class="card-icon" >
                                    <i class="fas fa-truck-loading"></i>
                                </div>
                                <div class="card-category" style="font-size:32px;">แทงจำหน่าย</div>
                                <div class="card-title">
                                    <asp:Label ID="lbSell" runat="server" ForeColor="Black" ></asp:Label>
                                     /
                                    <asp:Label ID="lbSell2" runat="server" ForeColor="Black" ></asp:Label>
                                </div>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="fa fa-th-list"></i>&nbsp
                            <asp:LinkButton ID="lbtnSellDetail" runat="server" OnClick="lbtnSellDetail_Click">รายละเอียด</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                
                    <div class="col-xl-3 col-md-6 col-sm-6" runat="server" id="div8" visible="false">
                        <div class="card card-stats" >
                            <div class="card-header card-header-dark card-header-icon" >
                                <div class="card-icon">
                                    <i class="fas fa-align-justify" ></i>
                                </div>
                                <div class="card-category" style="font-size:32px;">รายการส่งออกทั้งหมด</div>
                                <div class="card-title">
                                    <asp:Label ID="lbTotal" runat="server" ForeColor="Black" ></asp:Label>
                                     /
                                    <asp:Label ID="lbTotal2" runat="server" ForeColor="Black" ></asp:Label>
                                </div>
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
                </div>
                <div id="Expire" runat="server" visible="true" >
                    <div class="row">
                        <div class="col-lg-2 col-md-3 col-sm-3"></div>
                    <div class="col-lg-8 col-md-6 col-sm-6">
                        <div class="card card-stats">
                            <div class="card-header card-header-secondary card-header-icon">
                                <div class="card-icon">
                                <a class="card-link text-light" href="#"><i class='fa fa-user-secret'></i></a>
                            </div>
                                <h4 class="card-category">รายการครุภัณฑ์ที่ครบอายุการใช้งาน</h4>
                                <h4 class="card-title">ปีงบประมาณ</h4>
                            <asp:Label ID="lbBudget" runat="server" CssClass="text-danger" ></asp:Label>
                            <br />
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md">
                                    <asp:GridView ID="expiredGridview" runat="server"
                                    AutoGenerateColumns="false" 
                                    DataKeyNames="equipment_id"
                                    OnRowDataBound="expiredGridview_RowDataBound"
                                    CssClass="table table-hover table-responsive-md table-sm"
                                    HeaderStyle-Font-Size="18px"
                                        HeaderStyle-Height="40px"
                                        RowStyle-Height="30px"
                                    HeaderStyle-CssClass="text-center"
                                    Font-Size="15px"
                                    AllowSorting="true"
                                    >
                                    <Columns>
                                        <asp:TemplateField HeaderText="ลำดับ" ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-center" > </asp:Label>
                                                </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="รายการ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbEquipname" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAME") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbToll" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="อายุการใช้งาน" ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbexpired" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.age") %>' CssClass="text-center" > </asp:Label>
                                                </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                                <div class="col-md-1">
                                </div>
                            </div>
                        </div>
                    </div>
                </div> 
                <div class="col-lg-2 col-md-3 col-sm-3"></div>
                    </div>                   
                </div>
                
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

            function openModal() {
            $('#myModal').modal('show');
            }   
        </script>
     </div>
    
</asp:Content>
