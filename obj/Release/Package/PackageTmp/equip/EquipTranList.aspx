﻿<%@ Page Title="งานครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipTranList.aspx.cs" Inherits="ClaimProject.EquipTranList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <div class="container-fluid">
    
    <asp:Button runat="server" ID="btnMainEQ" Text="หน้าหลัก"  OnClick="btnMainEQ_Click" CssClass="btn btn-default" />
    <asp:Button runat="server" ID="btnnewTranpage" Text="แจ้งใหม่"  OnClick="btnnewTranpage_Click" CssClass="btn btn-danger" OnClientClick="return CheckIsRepeat();"/>
    <div id="AddPM" runat="server" class="card" style="z-index: 0">

        <div class="card-header bg-success " >
            <h3 class="card-title " style="color:white;">รายการโอนย้ายครุภัณฑ์ (ส่งออก)</h3>
        </div>
            <div class="card-body table-responsive table-sm">

                <div class="row" style="font-size:medium;" id="divSendSearch"  runat="server"  >
                    <div class="row" >
                        <div class="col-md-3"  >
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" Text="เลขอ้างอิง : "  ></asp:Label>
                                <asp:TextBox ID="txtRefTran" runat="server" CssClass="form-control col-auto"  ></asp:TextBox>
                           </div>
                        </div>
                        <div class="col-md-3" >
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="ประเภทการโอนย้าย : "  ></asp:Label>
                                <asp:DropDownList ID="ddlsearchType" runat="server"  CssClass="form-control col-auto" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="ด่านปลายทาง : " ></asp:Label>
                                <asp:DropDownList ID="ddlsearchEndToll" runat="server"  CssClass="form-control col-auto"  ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md-2" >
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="สถานะ : "  ></asp:Label>
                                <asp:DropDownList ID="ddlsearchStat" runat="server"  CssClass="form-control col-auto"  ></asp:DropDownList>
                           </div>
                        </div>
                        <div class="col-md-1" >
                            <div class="form-group">
                                <asp:LinkButton ID="lbtnSearchSend" runat="server" ToolTip="กดค้นหา" Font-Size="XX-Large" CssClass="fa fa-search bottom" OnCommand="lbtnSearchSend_Command"></asp:LinkButton>
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
                    CssClass="table table-hover table-condensed table-sm"
                    HeaderStyle-Font-Size="18px"
                    GridLines="None" 
                    AllowSorting="true"                   
                    Font-Size="16px" 
                    OnPageIndexChanging="gridTranlist_PageIndexChanging" 
                    PagerSettings-Mode="NumericFirstLast"  
                    PageSize="100" 
            PagerSettings-FirstPageText="หน้าแรก"  PagerSettings-LastPageText="หน้าสุดท้าย" AllowPaging="true" >
                    
                    <Columns>
                        
                        <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-center" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขอ้างอิง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbpktrans" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.trans_id") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่เริ่มดำเนินการ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
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
                        <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:Label ID="lbstat" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.complete_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ดู/แก้ไข" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtntrans" runat="server" ToolTip="คลิก!" Font-Size="Larger" ForeColor="#0022ff" OnCommand="lbtntrans_Command"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="พิมพ์เอกสาร" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnprintTran" runat="server" Visible="false" CssClass="btn btn-sm btn-outline-warning" ToolTip="ใบรับ-ส่ง" Font-Size="15px" OnCommand="lbtnprintTran_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                                <asp:LinkButton ID="printReport1" runat="server" CssClass="btn btn-sm btn-outline-info" Font-Size="15px" ToolTip="บันทึกข้อความ" visible="false" OnCommand="printReport1_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#FFFFFF" Font-Bold="True" CssClass="text-center" ForeColor="#031f91" />
                    <HeaderStyle BackColor="#FFFFFF" CssClass="text-center"   ForeColor="#031f91" />
                    
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="white" ForeColor="#990000" />
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
                alert('ห้ามกดดับเบิ้ลคลิก ... กรุณากด ตกลง เพื่อทำรายการต่อไป');
                return false;
            }
        }
        
    </script>
</asp:Content>
