<%@ Page Title="รายการ PM" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PMListForm.aspx.cs" Inherits="ClaimProject.PM.PMListForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />

    <div class="row">
        <div class="col-md">
             <asp:Button ID="btnNewPM" CssClass="btn btn-danger" runat="server" Font-Bold="true" Font-Size="Large" Visible="false" Text=" แจ้งการPMใหม่ " OnClick="btnNewPM_Click" />
        </div>
    </div>


    <div class="card" style="z-index: 0">
        <div class="card-header card-header-warning">
            <h3 class="card-title">รายการบำรุงรักษาอุปกรณ์</h3>
        </div>
        <div class="card-body table-responsive table-sm">
          <div id="SearchArea" runat="server" >
            <div class="row">
                <div class="col-md-2 text-right">
                    <asp:Label ID="lbPMCpoint" runat="server" Text="ด่านฯ : "></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="PMSearchCpoint" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 text-right">
                    <asp:Label ID="lbList" runat="server" Text="รายการ : "></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="PMSearchProj" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 text-right">
                    <asp:Label ID="lbRef" runat="server" Text="เลขที่อ้างอิง(Ref.No.) : "></asp:Label>
                </div>
                <div class="col-md-1">
                    <asp:TextBox ID="PMSearchRef" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                
            </div>
            <br />
            <div class="row">
                <div class="col-md-2 text-right">
                    <asp:Label ID="lbCpoint" runat="server" Text="สถานะ : "></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="PMSearchStat" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 text-right">
                    <asp:Label ID="lbBudgetY" runat="server" Text="ปีงบประมาณ : "></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="PMSearchBudget" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
            <br />
            <div class="row">

                <div class="col-md-2"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnSearch" runat="server" Text="ค้นหา"  CssClass="btn btn-success btn-sm" Font-Bold="true" Font-Size="Large"  OnClick="btnSearch_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnNewSearch" runat="server" Text="ค้นหาใหม่"  CssClass="btn btn-primary btn-sm" Font-Bold="true" Font-Size="Large" Visible="false"  OnClick="btnNewSearch_Click" />
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="checktoday" runat="server" visible="false" Text="" ></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="checkresult" runat="server" Visible="false" Text="" ></asp:TextBox>
                </div>

            </div>
                
            <hr />

  <!---------------------------------------------------------------------------------------------------------->
            
            <div class="row">
                <div class="col-md">
                    <asp:Label ID="lbSearchResult" runat="server" Text="" Font-Bold="true" Font-Size="Large" ></asp:Label>
                </div>
            </div>

            <asp:GridView ID="PMListGridview" runat="server"
                DataKeyNames="pm_ref_no"
                OnRowDataBound="PMListGridview_RowDataBound"
                
                AutoGenerateColumns="false"
                CssClass="table table-light"
                AllowSorting="true"
                AllowPaging="true"
                PageSize="50"
                 
                OnPageIndexChanging="PMListGridview_PageIndexChanging"
                PagerSettings-Mode="NumericFirstLast"
               HeaderStyle-CssClass="text-center" RowStyle-CssClass="text-center" CellPadding="4" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>

                    <asp:TemplateField HeaderText="ด่านฯ" ControlStyle-width="100px">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnCpoint" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name").ToString() %>' CssClass="links-horizontal" OnCommand="lbtnPMRef_Command"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="เลขที่อ้างอิง" ControlStyle-width="80px">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnRefNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.pm_ref_no").ToString() %>' CssClass="links-horizontal" OnCommand="lbtnPMRef_Command"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ชื่อบริษัท" ControlStyle-Width="250px">
                        <ItemTemplate>
                             <asp:Linkbutton ID="lbPMCorporate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.company_name") %>' OnCommand="lbtnPMRef_Command" CssClass="links-horizontal"></asp:Linkbutton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="รายการ PM" ControlStyle-width="200px">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnPMList" runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().ShortText(DataBinder.Eval(Container, "DataItem.project_name").ToString()) %>' OnCommand="lbtnPMRef_Command" CssClass="links-horizontal"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="วันที่เข้า PM" ControlStyle-width="150px">
                        <ItemTemplate>
                             <asp:Label ID="lbPMACTSDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.pm_act_sdate") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="สถานะ"  ControlStyle-width="140px">
                        <ItemTemplate>
                             <asp:Label ID="lbPMStat" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.pm_status_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ผู้แจ้งPM" ControlStyle-Width="150px">
                        <ItemTemplate>
                            <asp:Label ID="lbPMWhoAdd" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                   
                </Columns>

                <FooterStyle BackColor="#F9B357" Font-Bold="True" ForeColor="White" />

                <HeaderStyle CssClass="text-center" BackColor="#eb7610" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="#FF8C00" ForeColor="White" />

                <RowStyle CssClass="text-center" BackColor="#ffeed6"></RowStyle>
                <SelectedRowStyle BackColor="#F3E5D4" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />  

           </asp:GridView>
            <asp:Label ID="lbPMNull" runat="server" Text=""></asp:Label>


        </div>
    </div>



    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
   






</asp:Content>

