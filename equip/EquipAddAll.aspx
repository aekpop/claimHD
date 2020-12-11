<%@ Page Title="งานครุภัณฑ์ / เพิ่มครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipAddAll.aspx.cs" Inherits="ClaimProject.equip.EquipAddAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <div class="container-fluid">

    
    <!-- Menu Dropdown -->        
        <div class="btn-group">
              <button class="btn btn-info"><i class="fas fa-align-justify"></i></button>
              <button class="btn dropdown-toggle btn-info" data-toggle="dropdown">
                <span class="caret"></span>
              </button>
              <ul class="dropdown-menu">
                <li><a href="/equip/EquipDefault">หน้าหลัก</a></li>
                <li><a href="/equip/EquipAdd">ค้นหา</a></li>
                <li><a href="/equip/EquipTranList">ส่งครุภัณฑ์</a></li>
                <li><a href="/equip/EquipTranGetList">รับครุภัณฑ์</a></li>
                <li><asp:LinkButton id="divaddnew" runat="server" href="/equip/EquipAddAll" visible="true">เพิ่มครุภัณฑ์ใหม่</asp:LinkButton></li>
                <li><asp:LinkButton id="divcheckk" runat="server" href="/equip/EquipCheckList" visible="true">การโอนย้าย(ด่านฯ)</asp:LinkButton></li>
                <li><asp:LinkButton id="divcheckkk" runat="server" href="/equip/EquipHistory" visible="true">ประวัติโอนย้าย</asp:LinkButton></li>
              </ul>
        </div>
        <!-------------------------------- // ------------------------------------>
    <asp:Button runat="server" ID="btnCreatenew" OnClick="btnCreatenew_Click" CssClass="btn btn-danger" Text="เพิ่มครุภัณฑ์" />
    <div id="AddPM" runat="server" class="card" style="z-index: 0">

        <div class="card-header card-header-danger">
            <div class="card-title" ><asp:Label ID="hhh" runat="server" Text="รายการเพิ่มครุภัณฑ์" ForeColor="White" ></asp:Label></div>
        </div>
            <div class="card-body table-responsive table-sm">
                
                <div id="divsearch" runat="server" class="row" >
                    <div class="col-lg-3 col-md-5" >
                            <div class="form-group" >
                                <p class="lbdateAdd"  >วันที่เพิ่มครุภัณฑ์</p>
                                <asp:TextBox ID="txtDatestart" runat="server" ToolTip="ตัวอย่าง 01-12-2563" CssClass="form-control " onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                </div>
                     </div>
                    <div class="col-lg-3 col-md-5" >
                            <div class="form-group" >
                                <p class="lbCpoint" >ด่านฯ :</p>
                                <asp:DropDownList ID="ddlserchToll" runat="server"  CssClass="form-control" ></asp:DropDownList>
                                </div>
                     </div>
                    </div>
                <div class="row">
                     <div class="col-lg-3 col-md-2" >
                         <asp:Button ID="btnsearchAdd" runat="server" Text="ค้นหา" CssClass="btn btn-success" Font-Bold="true" OnClick="btnsearchAdd_Click" /> 
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
          <asp:Panel ID="Panel1" CssClass="col-md " runat="server" > 
              
            <asp:GridView ID="GridAddAll" runat="server"
            DataKeyNames="NewEQ_id" 
            OnRowDataBound="GridAddAll_RowDataBound"
            CssClass="table table-hover table-sm col-md "
            Font-Size="15px"
            HeaderStyle-Font-Size="18px"
            AutoGenerateColumns="False"
            HeaderStyle-CssClass="text-center" 
            CellPadding="4" 
            BorderColor="white" 
            ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="#ffffff" />
                <Columns>
                    
                    <asp:TemplateField HeaderText="ลำดับ" >
                                <ItemTemplate>
                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-center" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="ชื่อครุภัณฑ์" HeaderStyle-CssClass="text-left">
                        <ItemTemplate>
                            <asp:Label ID="lbThname" runat="server" CssClass="text-left" Text='<%# DataBinder.Eval(Container, "DataItem.AddNameth") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                                      
                    <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                        <ItemTemplate>
                            <asp:Label ID="lbtolladd"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="เลขที่สัญญา" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                        <ItemTemplate>
                            <asp:Label ID="lbAddConNum"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddConNum") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วันที่ตรวจรับ" >
                        <ItemTemplate>
                            <asp:Label ID="lbDateStart" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.AddDateGet") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="แก้ไข" >
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtneditAdd" runat="server" Text="แก้ไข"  CssClass="btn btn-sm btn-outline-warning" OnCommand="lbtneditAdd_Command"><i class="fas fa-edit"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle BackColor="#82e874" Font-Bold="True" ForeColor="White" />
                <HeaderStyle CssClass="text-center" BackColor="#ffffff"  ForeColor="000000" ></HeaderStyle>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="#2461BF" ForeColor="White" />
                <SelectedRowStyle BackColor="#a2fca5" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#baf7b2" />
                <SortedDescendingHeaderStyle BackColor="#5abe48"/>
        </asp:GridView>                  
   </asp:Panel>                   
            </div>
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

        function handleEnter (field, event) {
		    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 13) {
                
                return false;
            }
            else
            {
                return true;
            }
        }     

    </script>
</asp:Content>
