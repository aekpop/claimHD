<%@ Page Title="งานครุภัณฑ์ / ส่งครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipTranList.aspx.cs" Inherits="ClaimProject.EquipTranList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <link href="../Content/form-design-new.css" rel="stylesheet" />
    <script src="/Scripts/jquery-migrate-3.0.0.min.js"></script>
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }
    </style>

    <div class="container-fluid" style="font-family: 'Prompt',sans-serif;">
        <div id="GrpNewTrans" runat="server" class="row">
            <div class="col-6">
                <asp:Button runat="server" ID="btnNewTran" CssClass="btn btn-danger" OnClick="btnnewTranpage_Click" OnClientClick="return CheckIsRepeat();" Text="แจ้งใหม่" />
            </div>
            <div class="col-6 text-right">
                <a class="btn btn-outline-warning" data-toggle="collapse" href="#collapseSearch" role="button" aria-expanded="false" aria-controls="collapseSearch"><i class="fas fa-bars"></i></a>
            </div>
        </div>
        <div class="collapse show" id="collapseSearch">
            <div id="AddPM" runat="server" class="card" style="z-index: 0">
                <div class="card-header ">
                    <div class="card-title ">ค้นหา</div>
                </div>
                <div class="card-body table-responsive table-sm">
                    <div id="divSendSearch" runat="server" style="font-size: medium;">
                        <div class="row">
                            <div class="col-md-6 col-xl-3">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="เลขอ้างอิง : "></asp:Label>
                                    <asp:TextBox ID="txtRefTran" runat="server" CssClass="form-control col-auto" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 col-xl-3">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="ประเภทการโอนย้าย : "></asp:Label>
                                    <asp:DropDownList ID="ddlsearchType" runat="server" CssClass="form-control col-auto"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6 col-xl-3">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="ด่านปลายทาง : "></asp:Label>
                                    <asp:DropDownList ID="ddlsearchEndToll" runat="server" CssClass="form-control col-auto"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6 col-xl-3">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="สถานะ : "></asp:Label>
                                    <asp:DropDownList ID="ddlsearchStat" runat="server" CssClass="form-control col-auto"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <div class="form-group">
                                    <asp:LinkButton ID="lbtnSearchSend" runat="server" ToolTip="กดค้นหา" Font-Size="18px" CssClass="btn btn-success fa fa-search text-white" OnCommand="lbtnSearchSend_Command">&nbspค้นหา</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card">
            <div class="card-header ">
                <div class="card-title ">รายการส่งครุภัณฑ์</div>
            </div>
            <div class="card-body">
                <asp:GridView ID="gridTranlist" runat="server"
                    AutoGenerateColumns="false"
                    DataKeyNames="trans_id"
                    OnRowDataBound="gridTranlist_RowDataBound"
                    CssClass="table table-hover table-condensed table-sm"
                    HeaderStyle-Font-Size="18px"
                    HeaderStyle-Height="50px"
                    GridLines="None"
                    AllowSorting="true"
                    Font-Size="16px"
                    RowStyle-Height="40px"
                    OnPageIndexChanging="gridTranlist_PageIndexChanging"
                    PagerSettings-Mode="NumericFirstLast"
                    PageSize="25"
                    PagerSettings-FirstPageText="หน้าแรก"
                    PagerSettings-LastPageText="หน้าสุดท้าย"
                    AllowPaging="true">
                    <Columns>
                        <asp:TemplateField HeaderText="เลขอ้างอิง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                            <ItemTemplate>
                                <asp:Label ID="lbtransId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่หนังสือ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbSentDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.date_send") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ต้นทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbStarttrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_send") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ปลายทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbEndtrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_recieve") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ItemStyle-Font-Size="X-Large">
                            <ItemTemplate>
                                <asp:Label ID="lbstat" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.complete_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="จัดการข้อมูล" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtntrans" runat="server" ToolTip="คลิก!" Font-Size="X-Large" ForeColor="#0022ff" OnCommand="lbtntrans_Command"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="พิมพ์เอกสาร" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnprintTran" runat="server" Visible="false" CssClass="btn btn-sm btn-outline-warning" data-toggle="tooltip" data-placement="top" title="ออกรายงานเอกสาร" Font-Size="15px" OnCommand="lbtnprintTran_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                                <asp:LinkButton ID="printReport1" runat="server" CssClass="btn btn-sm btn-outline-info" Font-Size="15px" ToolTip="บันทึกข้อความ" Visible="false" OnCommand="printReport1_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#FFFFFF" Font-Bold="True" CssClass="text-center" ForeColor="#031f91" />
                    <HeaderStyle BackColor="#FFFFFF" CssClass="text-center" ForeColor="#031f91" />
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="white" ForeColor="#990000" />
                </asp:GridView>
            </div>
            <div class="row" style="padding-left: 20px;">
                <asp:Label ID="lbAmountgrid" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="#0022ff"></asp:Label>
            </div>
        </div>
    </div>
    <div class="modal fade " id="ReportModal" tabindex="-1" role="dialog" aria-labelledby="ReportModalLabel" aria-hidden="true">
        <div class="modal-dialog modal modal-dialog-centered " style="max-height: 85%; margin-top: 50px; margin-bottom: 50px; width: 500px" role="form">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="modal-title">#</div>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style="line-height: inherit;">
                    <div class="">กรอกรายละเอียด ใบส่งของ</div>
                    <div class="row" style="height: 90px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ชื่อผู้ส่ง :</label>
                                <asp:TextBox ID="txtSenderName" runat="server" Font-Size="Medium" CssClass="form-control time" onkeypress="return handleEnter(this, event)" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ตำแหน่งผู้ส่ง :</label>
                                <asp:TextBox ID="txtPosSender" runat="server" Font-Size="Medium" CssClass="form-control time" onkeypress="return handleEnter(this, event)" />
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="">กรอกรายละเอียด ใบปะหน้า</div>
                    <div class="row">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เลขที่หนังสือ :</label>
                                <asp:TextBox ID="txtNumto" runat="server" Font-Size="Medium" CssClass="form-control " onkeypress="return handleEnter(this, event)" />
                                <label class="bmd-label-floating">วันที่หนังสือ :</label>
                                <asp:TextBox ID="txtDate" runat="server" Font-Size="Medium" CssClass="form-control " onkeypress="return handleEnter(this, event)" ToolTip="รูปแบบตัวอย่าง : 01-05-2563" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="lbtnGoReport" runat="server" CssClass="btn btn-outline-success btn-sm" Font-Size="15px" ToolTip="ใบรับ-ส่ง" Visible="false" OnCommand="lbtnGoReport_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                    <asp:LinkButton ID="lbtnGoReportCopy" runat="server" CssClass="btn btn-outline-warning btn-sm" Font-Size="15px" ToolTip="ใบรับ-ส่ง สำเนา" Visible="false" OnCommand="lbtnGoReportCopy_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                    <asp:LinkButton ID="printReport1" runat="server" CssClass="btn btn-sm btn-outline-info" Font-Size="15px" ToolTip="บันทึกข้อความ" Visible="true" OnCommand="printReport1_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                    <asp:LinkButton ID="lbtnGoReportrd" runat="server" CssClass="btn btn-sm btn-outline-danger" Font-Size="15px" ToolTip="ใบรับส่ง RDLC" Visible="true" OnCommand="lbtnGoReportrd_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" style="font-size: medium">X</button>
                </div>
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
        $(function () {
            <% if (ReModal != "")
        {%>
            $("#ReportModal").modal('show');
            <%}
        else
        {%>
            $("#ReportModal").modal('hide');
            <%}%>
        });
        function UpdteConfirm(msg) {
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
        var submit = 0;

        function CheckIsRepeat() {
            if (++submit > 1) {
                alert('ระบบกำลังประมวลผล ... กรุณากด "ตกลง" เพื่อทำรายการต่อไป');
                return false;
            }
        }

        function handleEnter(field, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 13) {
                return false;
            }
            else {
                return true;
            }
        }

        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</asp:Content>
