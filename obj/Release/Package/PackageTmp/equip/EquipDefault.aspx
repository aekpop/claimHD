<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipDefault.aspx.cs" Inherits="ClaimProject.equip.EquipDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-2 text-right">
                    <asp:Label ID="Label1" runat="server" Text="ปีงบประมาณ : "></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="txtBudgetYear" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="txtBudgetYear_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>

            <br />
            <div class="row">
                <div class="col-lg col-md col-sm" style="padding:1px 1px 1px 10px;">
                    <div class="card card-stats" style="width:180px">
                        <div class="card-header card-header-success card-header-icon" >
                            <div class="card-icon " >
                                <i class="fas fa-luggage-cart" ></i>
                            </div>
                            <h6 class="card-category" style="font-size:20px">โอนย้าย</h6>
                            <h4 class="card-title">
                                <asp:Label ID="lbTran" runat="server" Text="Tran"></asp:Label>
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
                            <h6 class="card-category" style="font-size:20px">ส่งคืนกองฯ</h6>
                            <h4 class="card-title">
                                <asp:Label ID="lbSendHead" runat="server" Text="Head"></asp:Label>
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
                            <h6 class="card-category" style="font-size:20px">แทงจำหน่าย</h6>
                            <h4 class="card-title">
                                <asp:Label ID="lbSell" runat="server" Text="Sell"></asp:Label>
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
                            <a class="card-category" style="font-size:20px">ส่งซ่อม</a>
                            <h4 class="card-title">
                                <asp:Label ID="lbRepair" runat="server" Text="Repair"></asp:Label>
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
                            <a class="card-category" style="font-size:20px">ทดแทน</a>
                            <h4 class="card-title">
                                <asp:Label ID="lbCopy" runat="server" Text="Copy"></asp:Label>
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
