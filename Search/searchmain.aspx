<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="searchmain.aspx.cs" Inherits="ClaimProject.Search.searchmain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <div id="AddPM" runat="server" class="card" style="z-index: 0">

        <div class="card-header card-header-warning">
            <h3 class="card-title">ค้นหา/แก้ไขรายการครุภัณฑ์</h3>
        </div>
            <div class="card-body table-responsive table-sm">
                <div id="divSearchplate" runat="server" class="row"  style="background-color:peachpuff;height:130px;padding:1px 1px 1px 1px;" >
                    <div class="col-md" style="padding:1px 2px 2px 20px">
                            <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="เลขทะเบียนรถ :" Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:TextBox ID="txtSplate"  CssClass="form-control" runat="server" BorderStyle="NotSet" Width="180px" ></asp:TextBox>
                           </div>
                        </div>
                
                    <div class="col-md" style="padding:1px 2px 2px 5px">
                            <div class="form-group" >
                            <asp:Label ID="Label2" runat="server" Text="ยี่ห้อ :" Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:TextBox ID="txtSBrand"  CssClass="form-control" runat="server" BorderStyle="NotSet" Width="160px" ></asp:TextBox>
                           </div>
                        </div>
                    <div class="col-md" style="padding:1px 2px 2px 5px">
                            <div class="form-group" >
                            <asp:Label ID="Label3" runat="server" Text="รุ่น :" Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:TextBox ID="txtSSeries"  CssClass="form-control" runat="server" BorderStyle="NotSet" Width="160px" ></asp:TextBox>
                           </div>
                        </div>
                   
                     <div class="col-md" style="padding:50px 1px 1px 5px">
                         <asp:Button ID="btnsPlate" runat="server" Text="ค้นหา" CssClass="btn btn-warning btn-sm" Font-Bold="true" Font-Size="Large" OnClick="btnsPlate_Click" /> 
                     </div>
                    </div>
                <div id="divSagain" runat="server" visible="false">
                    <asp:Button ID="btnSplateagain" runat="server" Text="ค้นหาใหม่"  CssClass="btn btn-dark btn-sm" Font-Bold="true" Font-Size="Large" OnClick="btnSplateagain_Click" />
                    <asp:Label ID="chkS" runat="server" ></asp:Label>
                </div>



                <asp:Label ID="titlegridd" runat="server" text="" Visible="false" Font-Bold="true" Font-Size="Large" ></asp:Label>
          <asp:Panel ID="Panel1" runat="server" ScrollBars="Both"  BorderStyle="Solid" BorderColor="#ffcc99"  Height="800px" > 
              
            <asp:GridView ID="gridsearchcar" runat="server"
            DataKeyNames="plate_id"
            OnRowDataBound="gridsearchcar_RowDataBound"
            CssClass="table table-hover table-sm " 
            AutoGenerateColumns="False"
            HeaderStyle-CssClass="text-center" RowStyle-CssClass="text-center" CellPadding="4" BorderColor="white" ForeColor="#333333" GridLines="Both">
                <AlternatingRowStyle BackColor="#f3ffe0" />
                <Columns>
                    
                    <asp:TemplateField HeaderText="ลำดับ" ControlStyle-Width="30px">
                        <ItemTemplate>
                            <asp:Label ID="lbnumcar" runat="server" Font-Size="16px" CssClass="text-center"  ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ประเภทรถ" ControlStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lbtypecar" runat="server" Font-Size="16px" Text='<%# DataBinder.Eval(Container, "DataItem.cartype_id") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ยี่ห้อ" ControlStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lbbrand" runat="server" Font-Size="16px" Text='<%# DataBinder.Eval(Container, "DataItem.brand") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="รุ่น" ControlStyle-Width="100px" >
                        <ItemTemplate>
                            <asp:Label ID="lbseries" runat="server" Font-Size="16px" Text='<%# DataBinder.Eval(Container, "DataItem.series") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ทะเบียน" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="80px">
                        <ItemTemplate>
                            <asp:Label ID="lblicence"  runat="server" Font-Size="16px"  Text='<%# DataBinder.Eval(Container, "DataItem.license_no") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="จังหวัด" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="160px">
                        <ItemTemplate>
                            <asp:Label ID="lbprovince"  runat="server" Font-Size="16px" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.province") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ด่านฯ ขาเข้า" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label ID="lbcpointEN"  runat="server" Font-Size="16px" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_EN") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="ช่องทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="60px">
                        <ItemTemplate>
                            <asp:Label ID="lbEN"  runat="server" Font-Size="16px"  Text='<%# DataBinder.Eval(Container, "DataItem.lane_EN") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="วันที่เข้า" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lbDateEN"  runat="server" Font-Size="16px" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.date_EN") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="เวลาเข้า" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="80px">
                        <ItemTemplate>
                            <asp:Label ID="lbTimeEN"  runat="server" Font-Size="16px" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.time_EN") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="ด่านฯ ขาออก" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label ID="lbcpointEX"  runat="server" Font-Size="16px" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_EX") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="ช่องทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="60px">
                        <ItemTemplate>
                            <asp:Label ID="lbEX"  runat="server" Font-Size="16px" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.lane_EX") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="วันที่ออก" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lbDateEX"  runat="server" Font-Size="16px" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.date_EX") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="เวลาออก" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="80px">
                        <ItemTemplate>
                            <asp:Label ID="lbTimeEX"  runat="server" Font-Size="16px" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.time_EX") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="เลขบัตร Transit Card" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lbTransit"  runat="server" Font-Size="16px" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.transit_no") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 

                </Columns>
                <FooterStyle BackColor="#82e874" Font-Bold="True" ForeColor="White" />
                <HeaderStyle CssClass="text-center" BackColor="#25660d"  ForeColor="White" ></HeaderStyle>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="#2461BF" ForeColor="White" />
                <RowStyle CssClass="text-center" BackColor="#deffad"></RowStyle>
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
</asp:Content>
