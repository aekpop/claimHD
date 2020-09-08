<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipAddAll.aspx.cs" Inherits="ClaimProject.equip.EquipAddAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <asp:Button runat="server" ID="btnBackHomeADDEQ" Text="กลับหน้าหลัก" OnClick="btnBackHomeADDEQ_Click" CssClass="btn btn-default " />
    <asp:Button runat="server" ID="btnCreatenew" Text="สร้างรายการเพิ่มใหม่!!" BackColor="#db005b" ForeColor="White" OnClick="btnCreatenew_Click" CssClass="btn btn-default " />
    <div id="AddPM" runat="server" class="card" style="z-index: 0">

        <div class="card-header " style="background-color:#960238;">
            <h3 class="card-title" ><asp:Label ID="hhh" runat="server" Text="รายการเพิ่มครุภัณฑ์ใหม่" ForeColor="White" ></asp:Label></h3>
        </div>
            <div class="card-body table-responsive table-sm">
                
                <div id="divsearch" runat="server" class="row"  style="background-color:#fcd7e4;height:130px;padding:1px 1px 1px 1px;" >
                    <div class="col-md-2" style="padding:1px 1px 1px 30px;">
                            <div class="form-group" >
                                <asp:Label ID="Label1" runat="server" Text="วันที่เริ่มดำเนินการ" Font-Size="Large" Font-Bold="true" ></asp:Label>
                                <asp:TextBox ID="txtDatestart" runat="server" Width="160px" ToolTip="ตัวอย่าง 01-12-2563" CssClass="form-control " ></asp:TextBox>
                                </div>
                     </div>
                    <div class="col-md-2" style="padding:1px 1px 1px 20px">
                            <div class="form-group" >
                                <asp:Label ID="Label3" runat="server" Text="ด่านฯ :" Font-Size="Large" Font-Bold="true" ></asp:Label>
                                <asp:DropDownList ID="ddlserchToll" runat="server"  CssClass="form-control" Width="150px" ></asp:DropDownList>
                                </div>
                     </div>
                     <div class="col-md" style="padding:50px 1px 1px 1px">
                         <asp:Button ID="btnsearchAdd" runat="server" Text="ค้นหา" CssClass="btn btn-sm" ForeColor="White" BackColor="#960238" Font-Bold="true" Font-Size="Large" OnClick="btnsearchAdd_Click" /> 
                     </div>
                    </div>
                <div id="divSagain" runat="server" visible="false">
                    <asp:Button ID="btnSagain" runat="server" Text="ค้นหาใหม่"  CssClass="btn btn-dark btn-sm" Font-Bold="true" Font-Size="Large" OnClick="btnSagain_Click" />
                    <asp:Label ID="chkS" runat="server" ></asp:Label>
                </div>
                <br />
                <div class="row" style="padding-left:20px">
                    <asp:Label ID="titlegrid" runat="server" text="" Visible="false" Font-Bold="true" Font-Size="Large" ></asp:Label>
                </div>
                <div class="row" style="padding-left:35px;" >
                    <asp:Label ID="lbamountEQ" runat="server" ></asp:Label>
                </div>
          <asp:Panel ID="Panel1" CssClass="col-md text-center" runat="server" > 
              
            <asp:GridView ID="GridAddAll" runat="server"
            DataKeyNames="NewEQ_id" 
            OnRowDataBound="GridAddAll_RowDataBound"
            CssClass="table table-hover table-sm col-md text-center" 
            AutoGenerateColumns="False"
            HeaderStyle-CssClass="text-center" RowStyle-CssClass="text-center" CellPadding="4" BorderColor="white" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="#ffffff" />
                <Columns>
                    
                    <asp:TemplateField HeaderText="วันที่รับ" >
                        <ItemTemplate>
                            <asp:Label ID="lbDateStart" runat="server" Font-Size="16px" Text='<%# DataBinder.Eval(Container, "DataItem.AddDateGet") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อครุภัณฑ์(ไทย)" >
                        <ItemTemplate>
                            <asp:Label ID="lbThname" runat="server" Font-Size="16px" Text='<%# DataBinder.Eval(Container, "DataItem.AddNameth") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ยี่ห้อ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                        <ItemTemplate>
                            <asp:Label ID="lbBrandAdd"  runat="server" Font-Size="16px" Text='<%# DataBinder.Eval(Container, "DataItem.AddBrand") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รุ่น" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                        <ItemTemplate>
                            <asp:Label ID="lbseriesAdd"  runat="server" Font-Size="16px" Text='<%# DataBinder.Eval(Container, "DataItem.AddSeries") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                        <ItemTemplate>
                            <asp:Label ID="lbtolladd"  runat="server" Font-Size="16px" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="แก้ไข" >
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtneditAdd" runat="server" Text="แก้ไข" Font-Size="16px" CssClass="fas text-warning" OnCommand="lbtneditAdd_Command">&#xf044;</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle BackColor="#82e874" Font-Bold="True" ForeColor="White" />
                <HeaderStyle CssClass="text-center" BackColor="#ffffff"  ForeColor="000000" ></HeaderStyle>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="#2461BF" ForeColor="White" />
                <RowStyle CssClass="text-center" BackColor="#ffffff"></RowStyle>
                <SelectedRowStyle BackColor="#a2fca5" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#baf7b2" />
                <SortedDescendingHeaderStyle BackColor="#5abe48"/>

        </asp:GridView>
                  
   </asp:Panel>   

                
            </div>






    </div>
    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript"> 
        $(function () {
        <% if (alerts != "")
        { %>
            demo.showNotification('top', 'center', '<%=icons%>', '<%=alertTypes%>', '<%=alerts%>');
        <% } %>
        });
    </script>
</asp:Content>
