<%@ Page Title="งานครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipTranGetList.aspx.cs" Inherits="ClaimProject.equip.EquipTranGetList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <asp:Button runat="server" ID="btnMainEQ"  Font-Bold="true" Text="หน้าหลัก"  OnClick="btnMainEQ_Click" CssClass="btn btn-default" />
    <div id="AddPM" runat="server" class="card" style="z-index: 0">

        <div class="card-header "  style="background-color:#559101;height:60px">
            <h3 class="card-title" style="color:white;height:35px;font-size:30px">รายการโอนย้ายครุภัณฑ์  (รับมา)</h3>
        </div>
            <div class="card-body table-responsive table-sm">

                <div class="row" id="divSendSearch"  runat="server" >
                    <div class="row" >
                        <div class="col-md"  >
                            <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="เลขอ้างอิง : "  ></asp:Label>
                                <asp:TextBox ID="txtRefTran" runat="server" CssClass="form-control" Width="120px" ></asp:TextBox>
                           </div>
                        </div>
                        <div class="col-md" >
                            <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="ประเภทโอนย้าย : " ></asp:Label>
                            <asp:DropDownList ID="ddlsearchType" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md"  >
                            <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="ด่านต้นทาง : "  ></asp:Label>
                            <asp:DropDownList ID="ddlsearchEndToll" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md" >
                            <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="สถานะ : "  ></asp:Label>
                            <asp:DropDownList ID="ddlsearchStat" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md" >
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
                    GridLines="None" 
                    CssClass="table table-hover table-condensed table-sm"
                    Font-Size="19px"
                    AllowSorting="true"
                    PageSize="100" >

                    
                    <Columns>
                        
                        <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-center" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ประเภทรายการ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbtypetrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_stat_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขอ้างอิง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbpktrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_id") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่ดำเนินการ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbSentDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.date_send") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ต้นทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbStarttrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ปลายทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbEndtrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_recieve") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ผู้แจ้ง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbsenderr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name_send") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ผู้ตรวจรับ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbreciever" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name_recieve") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        

                        <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width ="45px" ControlStyle-Font-Size ="Medium" >
                            <ItemTemplate>
                                <asp:Label ID="lbstat" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.complete_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ดู/แก้ไข" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtntrans" runat="server" ToolTip="คลิก!" Font-Size="Larger" OnCommand="lbtntrans_Command" BackColor="#ffffff"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#ffffff" Font-Bold="True" CssClass="text-center" ForeColor="#031f91" />
                    <HeaderStyle BackColor="#ffffff" CssClass="text-center"   ForeColor="#031f91" />
                    
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="white" ForeColor="#990000" />
                </asp:GridView>


            </div>

    </div>



    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
</asp:Content>
