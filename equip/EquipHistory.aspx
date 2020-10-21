<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipHistory.aspx.cs" Inherits="ClaimProject.equip.EquipHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }
    </style>
    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">
        <asp:Button runat="server" ID="btnMainEQQ" Text="หน้าหลัก"  OnClick="btnMainEQQ_Click" CssClass="btn btn-default" />
        <div id="MainBody" class="card" style="z-index: 0; ">
            <div class="card-header card-header-info">
                <div class="card-title">
                    <i class="fas fa-history"></i>&nbsp ประวัติการโอนย้ายของครุภัณฑ์</div>
            </div>
            <div class="card-body table-responsive">
                <div id="Search" class="row">
                    <div class="form-group bmd-form-group col-xl-3 col-md-6">
                        <span class = "label label-primary">หมายเลขครุภัณฑ์ : </span>
                        <asp:TextBox id="txtSearchEq" runat="server" CssClass="form-control" aria-describedby="SearchEqHelp" placeholder="หมายเลขครุภัณฑ์"></asp:TextBox>
                        <small id="SearchEqHelp" class="form-text text-muted">กรอกตัวเลขอย่างน้อย 1 ตัวอักษร</small>
                    </div> 
                </div>            
                <div class="col-xl-6 text-left">
                        <asp:Button ID="btnSearchEq" runat="server" CssClass="btn btn-info is" OnClick="btnSearchEq_Click" Text="ค้นหา"></asp:Button>
                </div>
            </div>
        </div>

        <asp:Panel ID="Panel" runat="server" >
            <asp:GridView ID="GridViewSearchEq" runat="server"
                OnRowDataBound="GridViewSearchEq_RowDataBound"
                AutoGenerateColumns="false"
                GridLines="None"
                CssClass="table table-hover table-condensed table-sm">
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <asp:Label ID="lbClaimNumrow" Text='<%#  Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="หมายเลขอ้างอิง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbRef" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.transfer_id") %>'  />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="หมายเลขครุภัณฑ์" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbEquip" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.equipment_no") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ด่านฯต้นทาง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbCpointS" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ด่านฯปลายทาง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbCpointE" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="วันที่ส่ง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbDate" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ผู้ส่ง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbUserS" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.name_send") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
