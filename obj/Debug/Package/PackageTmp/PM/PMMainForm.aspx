<%@ Page Title="เพิ่มรายการ PM" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PMMainForm.aspx.cs" Inherits="ClaimProject.PM.PMMainForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>


    <div class="row">
        <div class="col-md">
            <asp:Button ID="btnGotoPMList" CssClass="btn btn-info" runat="server" Text="หน้ารายการ PM " OnClick="btnGotoPMList_Click" />
        </div>
        <div class="col-md">
            <asp:Label ID="chhh" runat="server" Text=""  />
        </div>
    </div>


    <div id="AddPM" runat="server" class="card" style="z-index: 0">
        <div class="card-header card-header-warning">
            <h3 class="card-title">1. เพิ่มรายการ PM ใหม่ </h3>
        </div>
        <div class="card-body table-responsive table-sm">

            <div class="row" >
                <div class="col-md-2">
                    <div id="DivToll" runat="server"  class="form-group bmd-form-group">
                        <label class="bmd-label-floating">ด่านฯ</label>
                        <asp:DropDownList ID="txtPMCpoint" runat="server" CssClass="form-control custom-select"></asp:DropDownList>
                    </div>
                </div>

                <asp:Label ID="chkall" runat="server" Text="" ></asp:Label>
            </div> 
            <div class="row" >
                <div class="col-md-2">
                    <div class="form-group bmd-form-group">
                      <label class="bmd-label-floating">โครงการ</label> 
                        <asp:DropDownList ID="DDLProject" runat="server" AutoPostBack="true" CssClass="form-control custom-select" OnSelectedIndexChanged="DDLProject_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
                <div id="divCompany" runat="server" visible="false" class="row">
                    <div  class="col-md-2">
                        <div class="form-group bmd-form-group">
                            <label class="bmd-label-floating">ชื่อบริษัท</label>
                            <asp:DropDownList ID="ddlCoporate" runat="server" Width="250px" CssClass="form-control custom-select"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            <br />
               <div class="row">
                   <div id="divBtnAdd" runat="server" visible="false" class="col-md-2">
                         <asp:Button ID="btnAddPM" runat="server" Text="เพิ่ม" CssClass="btn btn-warning" 
                             OnClientClick="return ConfirmToAdd();"  OnClick="btnAddPM_Click" />
                    </div>
                </div>
           
        </div>
</div>

    <div id="PMListDiv" runat="server" class="card" style="z-index: 0">
        <div class="card-header card-header-success">
            <h3 class="card-title">2. รายการ PM ที่เพิ่ม</h3> 
          <!--  <asp:Label runat="server" Text="รายการ PM" Font-Bold="true" Font-Size="Larger" ForeColor="#003300" ></asp:Label> -->
        </div>
        <div class="card-body table-responsive table-sm">

        <asp:GridView ID="PMListEdit" runat="server"
            DataKeyNames="pm_ref_no"
            OnRowDataBound="PMListEdit_RowDataBound"
            CssClass="table table-hover table-sm"
            AutoGenerateColumns="False"
            HeaderStyle-CssClass="text-center" RowStyle-CssClass="text-center" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="อัพเดทข้อมูล" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbtnUpdate"  CssClass="fas text-warning" OnCommand="lbtnUpdate_Command" >&#xf35d;</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ด่านฯ" >
                        <ItemTemplate>
                            <asp:Label ID="lbToll" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="รายการ" >
                        <ItemTemplate>
                            <asp:Label ID="lbList" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.project_name") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="บริษัท" >
                        <ItemTemplate>
                            <asp:Label ID="lbCompany" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.company_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ผู้แจ้ง" >
                        <ItemTemplate>
                            <asp:Label ID="lbWhoCreate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:Label ID="lbPMStat"  runat="server" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.pm_status_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>    

                </Columns>
                <FooterStyle BackColor="#82e874" Font-Bold="True" ForeColor="White" />
                <HeaderStyle CssClass="text-center" BackColor="#3d9c30" Font-Bold="True" ForeColor="White" ></HeaderStyle>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="#2461BF" ForeColor="White" />
                <RowStyle CssClass="text-center" BackColor="#e3fce4"></RowStyle>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#baf7b2" />
                <SortedDescendingHeaderStyle BackColor="#5abe48"/>

        </asp:GridView>
            
        <asp:Label ID="lbAmount" runat="server" Text=""></asp:Label>
            </div>
    </div>

    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type = "text/javascript">
    window.onload = function () {
        document.onkeydown = function (e) {
            return (e.which || e.keyCode) != 116;
        };
    }
    </script>
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
    <script>
        function ConfirmToAdd()
        {
            if (confirm('ยืนยันที่จะเพิ่มรายการPMใช่หรือไม่ ?')) {
                return true;
            }
            else { return false; }
        }
    </script>





</asp:Content>
