<%@ Page Title="งานครุภัณฑ์ / รับครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipTranGetList.aspx.cs" Inherits="ClaimProject.equip.EquipTranGetList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <link href="../Content/form-design-new.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }
    </style>

    <div class="container-fluid"  style="font-family:'Prompt',sans-serif;">
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
       <!------------------>  
    
    
    <div id="AddPM" runat="server" class="card" style="z-index: 0; ">
        <div class="card-header card-header-success" >
            <div class="card-title" style="color:white;">รายการโอนย้ายครุภัณฑ์  (รับ)</div>
        </div>
            <div class="card-body table-responsive table-sm">

                <div class="row" id="divSendSearch" style="font-size:medium;" runat="server" >
                    <div class="row" >
                        <div class="col-md-6 col-xl-3"  >
                            <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="เลขอ้างอิง : "  ></asp:Label>
                                <asp:TextBox ID="txtRefTran" runat="server" CssClass="form-control col-auto" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                           </div>
                        </div>
                        <div class="col-md-6 col-xl-3" >
                            <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="ประเภทโอนย้าย : " ></asp:Label>
                            <asp:DropDownList ID="ddlsearchType" runat="server"  CssClass="form-control" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md-6 col-xl-3"  >
                            <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="ด่านต้นทาง : "  ></asp:Label>
                            <asp:DropDownList ID="ddlsearchEndToll" runat="server"  CssClass="form-control"  ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md-6 col-xl-3" >
                            <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="สถานะ : "  ></asp:Label>
                            <asp:DropDownList ID="ddlsearchStat" runat="server"  CssClass="form-control"  ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col text-center" >
                            <div class="form-group">
                            <asp:LinkButton ID="lbtnSearchSend" runat="server" ToolTip="กดค้นหา" Font-Size="XX-Large" CssClass="fa fa-search text-secondary" OnCommand="lbtnSearchSend_Command">&nbspค้นหา</asp:LinkButton>
                           </div>
                        </div>
                    </div>
                    
                </div>
                <hr />
                <div class="row" style="padding-left:20px;" >
                    <asp:Label ID="lbAmountgrid" runat="server" Font-Size="13px" ForeColor="#0022ff" ></asp:Label>
                </div>
                <asp:GridView ID="gridTranlist" runat="server" 
                    AutoGenerateColumns="false" 
                    DataKeyNames="trans_id" 
                    OnRowDataBound="gridTranlist_RowDataBound"
                    GridLines="None" 
                    CssClass="table table-hover table-condensed table-sm"
                    HeaderStyle-Font-Size="18px"
                    HeaderStyle-Height="75px"
                    Font-Size="15px"
                    AllowSorting="true"
                    RowStyle-Height="60px"
                    PageSize="30" >

                    
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
                        
                        

                        <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Font-Size ="Medium" >
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
</div>


    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript">
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
