<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipLoanList.aspx.cs" Inherits="ClaimProject.equip.EquipLoanList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <asp:Button runat="server" ID="btnMainEQ"  Font-Bold="true" BackColor="#c44602" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="หน้าหลักครุภัณฑ์"  OnClick="btnMainEQ_Click" CssClass="btn" />
    <asp:Button runat="server" ID="btnnewTranpage" Font-Bold="true" BackColor="#990303" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="ยืม"  OnClick="btnLoan_Click" CssClass="btn" />
    <div id="AddPM" runat="server" class="card" style="z-index: 0">
        <div class="card-header "  style="background-color:#26115c;height:60px">
            <h3 class="card-title" style="color:white;height:35px;font-size:30px">รายการยืมครุภัณฑ์</h3>

            <div class="card-body table-responsive table-sm">

                <div class="row" id="divSendSearch"  runat="server" style="background-color:#cdfae4;height:120px;padding:1px 1px 1px 1px;" >
                    <div class="row" >
                        <div class="col-md" style="padding:1px 1px 1px 50px" >
                            <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="เลขอ้างอิง : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                                <asp:TextBox ID="txtRefTran" runat="server" CssClass="form-control" Width="120px" ></asp:TextBox>
                           </div>
                        </div>
                        <div class="col-md" style="padding:1px 1px 1px 5px" >
                            <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="ประเภทการโอนย้าย : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                           <asp:DropDownList ID="ddlsearchType" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md" style="padding:1px 1px 1px 5px" >
                            <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="ด่านปลายทาง : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:DropDownList ID="ddlsearchEndToll" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md" style="padding:1px 1px 1px 5px">
                            <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="สถานะ : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:DropDownList ID="ddlsearchStat" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md" style="padding:30px 1px 1px 15px">
                            <div class="form-group">
                            <asp:LinkButton ID="lbtnSearchSend" runat="server" ToolTip="กดค้นหา" Font-Size="XX-Large" CssClass="fa fa-search" OnCommand="lbtnSearchSend_Command"></asp:LinkButton>
                           </div>
                        </div>
                    </div>

                </div>
                <div class="row" style="padding-left:20px;" >
                    <asp:Label ID="lbAmountgrid" runat="server" Font-Size="19px" Font-Bold="true" ForeColor="#0022ff" ></asp:Label>
                </div>
                <asp:GridView ID="gridTranlist" runat="server" 
                    AutoGenerateColumns="false" 
                    DataKeyNames="trans_id" 
                    OnRowDataBound="gridTranlist_RowDataBound"
                    GridLines="Both" BorderColor="White"  Font-Size="20px" 
                    OnPageIndexChanging="gridTranlist_PageIndexChanging" PagerSettings-Mode="NumericFirstLast"  PageSize="20" 
            PagerSettings-FirstPageText="หน้าแรก"  PagerSettings-LastPageText="หน้าสุดท้าย"
            AllowPaging="true" 
                    ><AlternatingRowStyle BackColor="#f0fbff" />
                    <Columns>
                        <asp:TemplateField HeaderText="คลิก" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="35px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtntrans" runat="server" ToolTip="คลิก!" Font-Size="Larger" ForeColor="#0022ff" OnCommand="lbtntrans_Command"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="พิมพ์" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="35px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnprintTran" runat="server" Visible="false" CssClass="fa fa-print" ToolTip="คลิก!" Font-Size="Larger" ForeColor="#cc0000" OnCommand="lbtnprintTran_Command"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="70px">
                            <ItemTemplate>
                                <asp:Label ID="lbstat" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.complete_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขอ้างอิง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Label ID="lbpktrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_id") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่เริ่มดำเนินการ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="120px">
                            <ItemTemplate>
                                <asp:Label ID="lbSentDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.date_send") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ประเภทรายการ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="180px">
                            <ItemTemplate>
                                <asp:Label ID="lbtypetrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_stat_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ต้นทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lbStarttrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ปลายทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lbEndtrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_recieve") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ผู้แจ้ง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="140px">
                            <ItemTemplate>
                                <asp:Label ID="lbsenderr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name_send") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หมายเหตุ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="140px">
                            <ItemTemplate>
                                <asp:Label ID="lbnoteGetlist" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_note") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#b8ecff" Font-Bold="True" CssClass="text-center" ForeColor="#031f91" />
                    <HeaderStyle BackColor="#b8ecff" CssClass="text-center"   ForeColor="#031f91" />
                    <RowStyle BackColor="#def4fc"  />
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="white" ForeColor="#990000" />
                </asp:GridView>


            </div>
        </div>
    </div>
    
</asp:Content>
