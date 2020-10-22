<%@ Page Title="งานครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipCheckList.aspx.cs" Inherits="ClaimProject.equip.EquipCheckList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }
    </style>

    <div class="container-fluid" style="font-family:'Prompt',sans-serif">
    <asp:Button runat="server" ID="btnMainEQQ" Text="หน้าหลัก"  OnClick="btnMainEQQ_Click" CssClass="btn btn-default" />
    

    
    <div id="AddPM" runat="server" class="card" style="z-index: 0">

        <div class="card-header card-header-warning" >
            <div class="card-title" >ตรวจสอบการโอนย้าย ด่านฯ</div>
        </div>
            <div class="card-body table-responsive table-sm">
               
 
                    <div class="row" >
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="เลขอ้างอิง : "  ></asp:Label>
                                <asp:TextBox ID="txtRefTran" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                           </div>
                        </div>
                        <div class="col-md-6 col-xl-2">
                            <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="ประเภทโอนย้าย : " ></asp:Label>
                            <asp:DropDownList ID="ddlsearchType" runat="server"  CssClass="form-control" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="ด่านต้นทาง : "></asp:Label>
                            <asp:DropDownList ID="ddlsearchEndToll" runat="server" AutoPostBack="true"  CssClass="form-control" OnSelectedIndexChanged="ddlsearchEndToll_SelectedIndexChanged"></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md-6 col-xl-2" id="divannex" runat="server" visible="false"  >
                            <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="อาคาร" ></asp:Label>
                            <asp:DropDownList ID="ddlannex" runat="server"  CssClass="form-control" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md-6 col-xl-2">
                            <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="สถานะ : "></asp:Label>
                            <asp:DropDownList ID="ddlsearchStat" runat="server"  CssClass="form-control"></asp:DropDownList>
                           </div>
                        </div>
                    </div>

                        <div class="row">                       
                            <div class="col text-center">
                                <div class="form-group">
                                <asp:LinkButton ID="lbtnSearchSend" runat="server" ToolTip="กดค้นหา" Font-Size="XX-Large" CssClass="fa fa-search text-center text-secondary border-success" OnCommand="lbtnSearchSend_Command">&nbspค้นหา</asp:LinkButton>
                               </div>
                            </div>
                        </div>

                <div class="row" style="padding-left:20px;" >
                    <asp:Label ID="lbAmountgrid" runat="server" Font-Size="12px" Font-Bold="true" ForeColor="#0022ff" ></asp:Label>
                </div>
                <br />
                <asp:GridView ID="gridTranlist" runat="server" 
                    AutoGenerateColumns="false" 
                    DataKeyNames="trans_id" 
                    OnRowDataBound="gridTranlist_RowDataBound"
                    GridLines="None" 
                    BorderColor="#ababab"   
                    Font-Size="15px"
                    HeaderStyle-Font-Size="18px"
                    CssClass="table table-hover table-condensed table-sm"
                    >
                    
                    <Columns>
                        <asp:TemplateField HeaderText="ตรวจสอบ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="70px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtntrans" runat="server" ToolTip="คลิก!" Font-Size="Larger" ForeColor="#0022ff" CssClass="fas fa-eye" OnCommand="lbtntrans_Command"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbstat" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.complete_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หมายเลขอ้างอิง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbpktrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_id") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่ทำรายการ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbSentDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.date_send") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ประเภทรายการ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbtypetrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_stat_name") %>' ></asp:Label>
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
                        

                    </Columns>
                    <FooterStyle BackColor="#b8ecff" Font-Bold="True" CssClass="text-center" ForeColor="#031f91" />
                    <HeaderStyle BackColor="#fffd6b" CssClass="text-center"   ForeColor="Black" />
                    
                </asp:GridView>


            </div>

    </div>
        <!-- modal -->
        <div class="modal fade " id="UpdateEquipModal"   tabindex="-1" role="dialog" aria-labelledby="UpdateEquipModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered " style="width:100%" role="form">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">รายละเอียดการโอนย้าย 
                        <asp:Label ID="lbEQIDModal" runat="server" Text="" CssClass="text-dark"></asp:Label></h4>
                    <asp:Label ID="pkeq" runat="server" visible="false" Font-Size="Smaller" ></asp:Label>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style="line-height: inherit;">
                    
                    <div class="row" >
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <span class="label label-primary">ด่านต้นทาง</span>
                                <asp:Label ID="txtchkSend" Enabled="false"  runat="server" />
                            </div>
                            <div class="form-group bmd-form-group">
                                <span class="label label-primary">ด่านปลายทาง</span>
                                <asp:Label ID="txtchkRecieve" Enabled="false"  runat="server" />
                            </div>
                        </div>                        
                    </div>
                    <div class="row" >
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <span class="label label-primary">วันที่ส่ง</span>
                                <asp:Label ID="txtchkDatesend" Enabled="false"  runat="server" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <span class="label label-primary">ผู้ส่ง</span>
                                <asp:Label ID="txtchkUsersend" Enabled="false"  runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row" >
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <span class="label label-primary">วันที่รับ</span>
                                <asp:Label ID="txtchkDateRecieve" Enabled="false"  runat="server" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <span class="label label-primary">ผู้รับ</span>
                                <asp:Label ID="txtchkUserRecieve" Enabled="false"  runat="server" />
                            </div>
                        </div>
                    </div>

                    <div class="card-body table-responsive table-sm" >
                         <asp:Panel ID="Panel1" runat="server" >
                             <asp:GridView id="TranchkGridview" runat="server"
                                    CssClass="col table table-striped table-hover"
                                    HeaderStyle-CssClass="text-center" 
                                    HeaderStyle-BackColor="ActiveBorder"
                                    HeaderStyle-Font-Size="18px"
                                    RowStyle-CssClass="text-center"
                                    OnRowDataBound="TranchkGridview_RowDataBound" 
                                    Font-Size="15px" 
                                    CellPadding="4" 
                                    GridLines="None"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ลำดับ">
                                            <ItemTemplate>
                                                <asp:Label ID="lbClaimNumrow" Text='<%#  Container.DataItemIndex + 1 %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="รายการ" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbNameth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_nameth") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="หมายเลขครุภัณฑ์" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_no") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="หมายเลขเครื่อง" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbSerial" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_serial") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     </Columns>
                             </asp:GridView>
                         </asp:Panel>
                    </div>
                   
                    

                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" style="font-size: medium">Close</button>
                </div>
            </div>
        </div>
    </div>
    </div>
        </div>



    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript">
    $(function () {
            <% if (pkeq.Text != "")
        {%>
            $("#UpdateEquipModal").modal('show');
            <%}
        else
        {%>
            $("#UpdateEquipModal").modal('hide');
            <%}%>  
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
