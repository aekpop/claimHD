<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipDefault.aspx.cs" Inherits="ClaimProject.equip.EquipDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button runat="server" ID="btnMainEQtt"  Font-Bold="true" BackColor="#737272" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="หน้าหลักครุภัณฑ์"  OnClick="btnMainEQtt_Click" CssClass="btn" />
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md" >
                    <div class="form-group" style="padding:1px 1px 1px 30px">
                        <asp:Label ID="Label1" runat="server" Text="ปีงบประมาณ : "></asp:Label>
                        <asp:DropDownList ID="txtBudgetYear" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="txtBudgetYear_SelectedIndexChanged">
                    </asp:DropDownList>
                    </div>
                    
                </div>
                
            </div>

            <br />
            <div class="row">
                <div class="col-lg col-md col-sm" style="padding:1px 1px 1px 10px;">
                    <div class="card card-stats" >
                        <div class="card-header card-header-success card-header-icon" >
                            <div class="card-icon " >
                                <i class="fas fa-luggage-cart" ></i>
                            </div>
                            <h4 class="card-category" style="color:#006600;">โอนย้าย</h4>
                            <h4 class="card-title">
                                
                                <asp:Label ID="lbTran" runat="server"  ForeColor="Black" Text=""></asp:Label>
                                <br />
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
                <div class="col-lg col-md col-sm" style="padding:1px 1px 1px 2px;">
                    <div class="card card-stats" >
                        <div class="card-header card-header-danger card-header-icon" >
                            <div class="card-icon">
                                <i class="fas fa-luggage-cart"></i>
                            </div>
                            <h4 class="card-category" style="color:#b00202;">ส่งคืนกองฯ</h4>
                            <h4 class="card-title">
                                <asp:Label ID="lbSendHead" runat="server" ForeColor="Black" Text=""></asp:Label>
                                <br />
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

                <div class="col-lg col-md col-sm" style="padding:1px 1px 1px 2px;" >
                    <div class="card card-stats" >
                        <div class="card-header card-header-warning card-header-icon" >
                            <div class="card-icon">
                                <i class="fas fa-truck-loading"></i>
                            </div>
                            <h4 class="card-category" style="color:#e6870b;">แทงจำหน่าย</h4>
                            <h4 class="card-title">
                                <asp:Label ID="lbSell" runat="server" ForeColor="Black" ></asp:Label>
                                <br />
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

                <div class="col-lg col-md col-sm" style="padding:1px 1px 1px 2px;" >
                    <div class="card card-stats" >
                        <div class="card-header card-header-secondary card-header-icon" >
                            <div class="card-icon">
                                <i class="fa fa-wrench"></i>
                            </div>
                            <h4 class="card-category" style="color:#8a8988;">ส่งซ่อม</h4>
                            <h4 class="card-title">
                                <asp:Label ID="lbRepair" runat="server" ForeColor="Black" Text=""></asp:Label>
                                <br /> 
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
                <div class="col-lg col-md col-sm" style="padding:1px 1px 1px 2px;" >
                    <div class="card card-stats" >
                        <div class="card-header card-header-info card-header-icon" >
                            <div class="card-icon">
                                <i class="far fa-copy"></i>
                            </div>
                            <h4 class="card-category" style="color:#05e0e8;">ทดแทน</h4>
                            <h4 class="card-title">
                                <asp:Label ID="lbCopy" runat="server" ForeColor="Black" ></asp:Label>
                                <br />
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
                </div>

            <div class="row" >

                <asp:Chart ID="Chart1" runat="server"  BackImageAlignment="Center"  >
                               <Series>
                                   <asp:Series Name="Series1"  >
                                   </asp:Series>
                                   <asp:Series Name="Series2"  >
                                   </asp:Series>
                               </Series>
                               <ChartAreas>
                                   <asp:ChartArea Name="ChartArea1"  >
                                   </asp:ChartArea>
                                   <asp:ChartArea Name="ChartArea2"  >
                                   </asp:ChartArea>
                               </ChartAreas>

                              </asp:Chart>

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
    </script>





</asp:Content>
