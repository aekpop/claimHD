<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipHistory.aspx.cs" Inherits="ClaimProject.equip.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div id="eqHistory" runat="server" class="card" style="z-index: 0; font-size:medium">
             <div class="card-header card-header-warning">
                 <h2 class="card-title">ประวัติการโอนย้ายของครุภัณฑ์</h2>
                 <div class="card-body table-responsive table-sm">
                     <div id="divsearch" runat="server" class="row"  >
                        <div class="col-md-2 col-lg-2" >
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="เลขครุภัณฑ์ :" Font-Bold="true" ></asp:Label>
                                    <asp:TextBox ID="txtsearchNum"  CssClass="form-control" runat="server" ></asp:TextBox>
                               </div>
                         </div>
                                <div class="col-md-2 col-lg-2" >
                                        <div class="form-group" >
                                            <asp:Label ID="Label4" runat="server" Text="เลขทะเบียน(Serial):" Font-Bold="true" ></asp:Label>
                                            <asp:TextBox ID="txtsearchSerial"  CssClass="form-control" runat="server" BorderStyle="NotSet"  ></asp:TextBox>
                                        </div>
                                </div>
                            <div class="col-md-6 text-right" >                               
                                   <asp:Button ID="searchEquip" runat="server" Text="ค้นหา" CssClass="btn btn-warning btn-sm" Font-Bold="true" Font-Size="Large" OnClick="searchEquip_Click" />                                
                            </div>  
                    </div>
                     <div class="card-body" style="font-size:medium; ">

          <asp:Panel ID="Panel1" runat="server" > 
              
            <asp:GridView ID="HistoryEqGridview" runat="server"
            DataKeyNames="equipment_id"
            OnRowDataBound="HistoryEqGridview_RowDataBound"
            CssClass="table table-hover table-sm "
            HeaderStyle-Font-Size="18px"
            Font-Size="15px"
            AutoGenerateColumns="False" 
            AllowPaging="true" 
            HeaderStyle-CssClass="text-center" RowStyle-CssClass="text-center" CellPadding="4" GridLines="None">
                
                <Columns>
                    
                    <asp:TemplateField HeaderText="ลำดับ" >
                        <ItemTemplate >
                            <%# Container.DataItemIndex + 1+"." %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อครุภัณฑ์(ไทย)" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEquipthai" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.equipment_nameth") %>' OnCommand="btnEditEquip_Command" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="เลขครุภัณฑ์" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbequipNo" runat="server"   Text='<%# DataBinder.Eval(Container, "DataItem.equipment_no") %>' OnCommand="btnEditEquip_Command" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="เลขทะเบียน" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                        <ItemTemplate>
                            <asp:Label ID="lbequipSe" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.equipment_serial") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ยี่ห้อ" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                        <ItemTemplate>
                            <asp:Label ID="lbequipbrand"  runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.equipment_brand") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:Label ID="lbequipToll"  runat="server"  Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                        <ItemTemplate>
                            <asp:Label ID="lbequipchk"  runat="server"   Text='<%# DataBinder.Eval(Container, "DataItem.status_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="สถานที่" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                        <ItemTemplate>
                            <asp:Label ID="lbequipnote"  runat="server"   Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ประวัติโอนย้าย" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbequipHistory"  runat="server" OnCommand="lbequipHistory_Command">*-*</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
                <FooterStyle BackColor="#82e874" Font-Bold="True" ForeColor="White" />
                <HeaderStyle CssClass="text-center" BackColor="#ffffff"  ForeColor="000000" ></HeaderStyle>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="#2461BF" ForeColor="White" />
                <SelectedRowStyle BackColor="#a2fca5" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#baf7b2" />
                <SortedDescendingHeaderStyle BackColor="#5abe48"/>              
                <PagerStyle HorizontalAlign="Center" BackColor="White" ForeColor="#026b14"  />
        </asp:GridView>                  
   </asp:Panel>   
            </div>
                 </div>
             </div>
        </div>
    </div>
</asp:Content>
