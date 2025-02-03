<%@ Page Title="งานครุภัณฑ์ / เพิ่มครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EquipAddAll.aspx.cs" Inherits="ClaimProject.equip.EquipAddAll" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
        <script src="/Scripts/bootbox.js"></script>
        <script src="/Scripts/HRSProjectScript.js"></script>

        <asp:Button runat="server" ID="btnCreatenew" OnClick="btnCreatenew_Click" CssClass="btn btn-info"
            Text="เพิ่มครุภัณฑ์" />
        <div id="AddPM" runat="server" class="card" style="z-index: 0">
            <div class="card-header ">
                <div class="card-title">
                    <asp:Label ID="hhh" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="card-body">
                <div id="divsearch" runat="server" class="row">
                    <div class="col-md-3 ">
                        <asp:TextBox ID="txtDatestart" runat="server" visible="false" ToolTip="ตัวอย่าง 01-12-2563"
                            CssClass="form-control " onkeypress="return handleEnter(this, event)"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <asp:DropDownList ID="ddlserchToll" runat="server" CssClass="col-2 dropdown dropdown-item">
                        </asp:DropDownList>
                        <asp:Button ID="btnsearchAdd" runat="server" Text="ค้นหา" CssClass="btn btn-outline-secondary"
                            OnClick="btnsearchAdd_Click" />
                    </div>
                </div>
                <div id="divSagain" runat="server" visible="false">
                    <asp:Button ID="btnSagain" runat="server" Text="ค้นหาใหม่" CssClass="btn btn-dark btn-sm"
                        Font-Bold="true" Font-Size="Large" OnClick="btnSagain_Click" />
                    <asp:Label ID="chkS" runat="server"></asp:Label>
                </div>
                <br />
                <div class="row" style="padding-left: 20px">
                    <asp:Label ID="titlegrid" runat="server" Text="" Visible="false" Font-Bold="true" Font-Size="Large">
                    </asp:Label>
                </div>
                <div class="row" style="padding-left: 35px;">
                    <asp:Label ID="lbamountEQ" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="card">
            <div class="card-header ">
                <div class="card-title">
                    <h5>รายการครุภัณฑ์นำเข้าระบบ</h5>
                </div>
            </div>
            <div class="card-body ">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="GridAddAll" runat="server" DataKeyNames="NewEQ_id"
                        OnRowDataBound="GridAddAll_RowDataBound" OnPageIndexChanging="GridAddAll_PageIndexChanging"
                        CssClass="table table-striped table-bordered dt-responsive nowrap" Font-Size="15px"
                        HeaderStyle-Font-Size="15px" AutoGenerateColumns="False" PagerSettings-Mode="NumericFirstLast"
                        PageSize="50" PagerSettings-FirstPageText="หน้าแรก" PagerSettings-LastPageText="หน้าสุดท้าย"
                        AllowPaging="true" CellPadding="4" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1+"." %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่นำเข้า">
                                <ItemTemplate>
                                    <asp:Label ID="lbNewEQ_Date" runat="server"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.NewEQ_Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อครุภัณฑ์" HeaderStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="lbThname" runat="server" CssClass="text-left"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.AddNameth") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-center"
                                ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbtolladd" runat="server"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เลขที่สัญญา" HeaderStyle-CssClass="text-center"
                                ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbAddConNum" runat="server"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.AddConNum") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="แก้ไข" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtneditAdd" runat="server" CssClass="btn btn-outline-warning"
                                        OnCommand="lbtneditAdd_Command">
                                        <i class="fas fa-edit fa-1x"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>

        <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
        <script src="/Scripts/moment.min.js"></script>
        <script src="/Scripts/ClaimProjectScript.js"></script>
        <script type="text/javascript">
            $(function () {
        <% if (alerts != "") { %>
                    demo.showNotification('top', 'center', '<%=icons%>', '<%=alertTypes%>', '<%=alerts%>');
        <% } %>
        });

            function handleEnter(field, event) {
                var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
                if (keyCode == 13) {
                    return false;
                }
                else {
                    return true;
                }
            }
        </script>
    </asp:Content>