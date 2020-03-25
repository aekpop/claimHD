<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipTranList.aspx.cs" Inherits="ClaimProject.EquipTranList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <asp:Button runat="server" ID="btnMainEQ"  Font-Bold="true" BackColor="#c44602" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="หน้าหลักครุภัณฑ์"  OnClick="btnMainEQ_Click" CssClass="btn" />
    <asp:Button runat="server" ID="btnnewTranpage" Font-Bold="true" BackColor="#02acbd" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="แจ้งรายการใหม่ คลิก!"  OnClick="btnnewTranpage_Click" CssClass="btn" />
    <div id="AddPM" runat="server" class="card" style="z-index: 0">

        <div class="card-header "  style="background-color:#01914b;height:60px">
            <h3 class="card-title" style="color:white;height:35px;font-size:30px">รายการโอนย้ายครุภัณฑ์ (ส่งออก)</h3>
        </div>
            <div class="card-body table-responsive table-sm">

                <div class="row" id="divSendSearch"  runat="server" style="background-color:#cdfae4;height:120px;padding:1px 1px 1px 1px;" >
                    <div class="row" >
                        <div class="col-md" style="padding:1px 1px 1px 50px" >
                            <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="เลขอ้างอิง : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                                <asp:TextBox ID="txtRefTran" runat="server" CssClass="form-control" Width="120px" ></asp:TextBox>
                           </div>
                        </div>
                        <div class="col-md" style="padding:1px 1px 1px 5px" >
                            <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="ประเภทการโอนย้าย : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:DropDownList ID="ddlsearchType" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md" style="padding:1px 1px 1px 5px" >
                            <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="ด่านปลายทาง : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:DropDownList ID="ddlsearchEndToll" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md" style="padding:1px 1px 1px 5px">
                            <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="สถานะ : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:DropDownList ID="ddlsearchStat" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md" style="padding:30px 1px 1px 15px">
                            <div class="form-group">
                            <asp:LinkButton ID="lbtnSearchSend" runat="server" ToolTip="กดค้นหา" Font-Size="XX-Large" CssClass="fa fa-search" OnCommand="lbtnSearchSend_Command"></asp:LinkButton>
                           </div>
                        </div>
                    </div>

                </div>
                <div class="row" style="padding-left:20px;" >
                    <asp:Label ID="lbAmountgrid" runat="server" Font-Size="19px" Font-Bold="true" ForeColor="#0022ff" ></asp:Label>
                </div>
                <asp:GridView ID="gridTranlist" runat="server" 
                    AutoGenerateColumns="false" 
                    DataKeyNames="trans_id" 
                    OnRowDataBound="gridTranlist_RowDataBound"
                    GridLines="Both" BorderColor="White"  Font-Size="20px" 
                    ><AlternatingRowStyle BackColor="#f0fbff" />
                    <Columns>
                        <asp:TemplateField HeaderText="คลิก" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="35px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtntrans" runat="server" ToolTip="คลิก!" Font-Size="Larger" ForeColor="#0022ff" OnCommand="lbtntrans_Command"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="พิมพ์" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="35px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnprintTran" runat="server" Visible="false" CssClass="fa fa-print" ToolTip="คลิก!" Font-Size="Larger" ForeColor="#cc0000" OnCommand="lbtnprintTran_Command"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="70px">
                            <ItemTemplate>
                                <asp:Label ID="lbstat" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.complete_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขอ้างอิง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Label ID="lbpktrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_id") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่เริ่มดำเนินการ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="120px">
                            <ItemTemplate>
                                <asp:Label ID="lbSentDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.date_send") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ประเภทรายการ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="180px">
                            <ItemTemplate>
                                <asp:Label ID="lbtypetrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_stat_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ต้นทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lbStarttrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ปลายทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lbEndtrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.toll_recieve") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ผู้แจ้ง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="140px">
                            <ItemTemplate>
                                <asp:Label ID="lbsenderr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name_send") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หมายเหตุ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  ControlStyle-Width="140px">
                            <ItemTemplate>
                                <asp:Label ID="lbnoteGetlist" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_note") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#b8ecff" Font-Bold="True" CssClass="text-center" ForeColor="#031f91" />
                    <HeaderStyle BackColor="#b8ecff" CssClass="text-center"   ForeColor="#031f91" />
                    <RowStyle BackColor="#def4fc"  />
                </asp:GridView>


            </div>

    </div>
    <div class="modal fade " id="ReportModal"   tabindex="-1" role="dialog" aria-labelledby="ReportModalLabel" aria-hidden="true">
        <div class="modal-dialog modal modal-dialog-centered " style=" max-height:85%;  margin-top: 50px; margin-bottom:50px;width:500px" role="form">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">กรุณากรอกข้อมูล</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style="line-height: inherit;">

                    <div class="row" style="height: 90px">
                        
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ชื่อผู้ส่ง :</label>
                                <asp:TextBox ID="txtSenderName"  runat="server" Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ตำแหน่งผู้ส่ง :</label>
                                <asp:TextBox ID="txtPosSender"  runat="server" Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="lbtnGoReport" runat="server" CssClass="btn btn-success btn-sm" Font-Size="Medium" OnCommand="lbtnGoReport_Command" >แสดงรายงาน</asp:LinkButton>
                    <asp:LinkButton ID="lbtnGoReportCopy" runat="server" CssClass="btn btn-warning btn-sm" Font-Size="Medium" OnCommand="lbtnGoReportCopy_Command" >แสดงรายงาน(สำเนา)</asp:LinkButton>
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

    </script>
</asp:Content>
