<%@ Page Title="งานบำรุงรักษา / รายงาน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMReport.aspx.cs" Inherits="ClaimProject.CM.CMReport" EnableEventValidation="false" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <script src="/crystalreportviewers13/js/crviewer/crv.js"></script>
    <script src="../Scripts/printThis.js"></script>

    <!-- CSS only -->
    <link href="../Content/form-design-new.css" rel="stylesheet" />
    <link href="../Content/CM.css" rel="stylesheet" />

    <!-- JS, Popper.js, and jQuery -->
    <script src="../Scripts/jquery-3.5.1.js"></script>
    <script src="../Scripts/umd/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <style>
        .modal-body {
            padding: 0.5rem;
        }
    </style>

    <div class="container-fluid" style="font-family: 'Prompt',sans-serif;">
        <div id="MainBody" runat="server" class="card" style="z-index: 0; font-size: 1rem;">
            <div class="card-header ">
                <div class="card-title">ค้นหา</div>
            </div>
            <div class="card-body table-responsive">
                <div runat="server">
                    <div class="row">
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <asp:Label ID="lbBudget" runat="server" Text="ปีงบประมาณ"></asp:Label>
                                <asp:DropDownList ID="ddlCMBudget" runat="server" CssClass="form-control  "></asp:DropDownList>
                            </div>
                        </div>
                        <div class=" col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <asp:Label ID="lbToll" runat="server" Text="ด่านฯ"></asp:Label>
                                <asp:DropDownList ID="txtCpointSearch" runat="server" CssClass="form-control "></asp:DropDownList>
                            </div>
                        </div>
                        <div class=" col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <asp:Label ID="lbAnnex" runat="server" Text="อาคาร"></asp:Label>
                                <asp:TextBox ID="txtPoint" runat="server" CssClass="form-control" placeholder="ใส่หมายเลข" ToolTip="ถ้าไม่มี ให้เว้นว่าง"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <asp:Label ID="lbChannel" runat="server" Text="หมายเลขช่องทาง"></asp:Label>
                                <asp:DropDownList ID="txtSearchChannel" runat="server" CssClass="form-control "></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <asp:Label ID="lbdevice" runat="server" Text="อุปกรณ์"></asp:Label>
                                <asp:DropDownList ID="txtDeviceDamage" runat="server" CssClass="combobox form-control custom-select "></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <asp:Label ID="lbStatus" runat="server" Text="สถานะ"></asp:Label>
                                <asp:DropDownList ID="txtCMStatus" runat="server" CssClass="form-control "></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <asp:Label ID="lblbRespons" runat="server" Text="ผู้รับผิดชอบ"></asp:Label>
                                <asp:DropDownList ID="ddlResponsible" runat="server" CssClass="form-control "></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="row">
                                <div class=" col-6 ">
                                    <div class="form-group bmd-form-group">
                                        <asp:Label ID="lbDayS" runat="server" Text="วันที่เริ่มต้น"></asp:Label>
                                        <asp:TextBox ID="txtDateStart" runat="server" CssClass="form-control datepicker "></asp:TextBox>
                                    </div>
                                </div>
                                <div class=" col-6">
                                    <div class="form-group bmd-form-group">
                                        <asp:Label ID="lbDayE" runat="server" Text="สิ้นสุด "></asp:Label>
                                        <asp:TextBox ID="txtDateEnd" runat="server" CssClass="form-control datepicker "></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-md-6 col-xl-2">
                            <div class="form-group bmd-form-group">
                                <div class="label-on-left">ช่วงเวลาทั้งหมด</div>
                                <label class="container">
                                    <input type="checkbox" id="CheckAllDay" name="CheckAllDay" runat="server" />
                                    <span class="checkmark"></span>
                                </label>
                            </div>
                        </div>
                        <div class=" col-md-2"></div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-12 col-md-6 col-xl-6 text-right">
                            <asp:LinkButton ID="btnSearchEdit1" runat="server" CssClass="btn btn-info fa col-sm-12 col-md-2" Font-Size="Larger" OnClick="btnSearchEdit_Click">&#xf002; ค้นหา</asp:LinkButton>
                        </div>
                        <div class="col-sm-12 col-md-6 col-xl-6 text-left">
                            <asp:LinkButton ID="btnReport" runat="server" CssClass="btn btn-success fa col-sm-12 col-md-2" Font-Size="Larger" OnCommand="btnReport_Command">&#xf15c; รายงาน</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="MainBody2" class="card" style="z-index: 0;">
            <div class="card-header ">
                <div class="card-title">รายการแจ้งซ่อมอุปกรณ์</div>
            </div>
            <div class="card-body table-responsive">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="GridView1" runat="server"
                        HeaderStyle-BackColor="White"
                        HeaderStyle-CssClass="align-content-center"
                        HeaderStyle-Font-Size="16px"
                        OnRowDataBound="GridView1_RowDataBound"
                        AlternatingRowStyle-CssClass="align-content-left"
                        AutoGenerateColumns="false"
                        PageSize="20"
                        GridLines="None"
                        Font-Size="14px"
                        HeaderStyle-Height="50px"
                        RowStyle-Height="50px"
                        CssClass="table table-hover table-condensed table-sm"
                        OnPageIndexChanging="GridView1_PageIndexChanging"
                        PagerSettings-Mode="NumericFirstLast"
                        PagerSettings-FirstPageText="หน้าแรก" PagerSettings-LastPageText="หน้าสุดท้าย"
                        AllowPaging="true">
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-CssClass="d-sm-none d-md-block" ItemStyle-CssClass="d-sm-none d-md-block">
                                <ItemTemplate>
                                    <asp:Label ID="lbClaimNumrow" Text='<%#  Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="lbCpoint" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name")+" "+DataBinder.Eval(Container, "DataItem.cm_point") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สถานที่" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="lbChannel" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อุปกรณ์" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" ControlStyle-Width="260px" HeaderStyle-Width="260px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>' OnCommand="lbDeviceName_Command"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อาการที่ชำรุด" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" ControlStyle-Width="260px" HeaderStyle-Width="260px">
                                <ItemTemplate>
                                    <asp:Label ID="lbProblem" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_problem") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่แจ้ง" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right">
                                <ItemTemplate>
                                    <asp:Label ID="lbSDate" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลา" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right">
                                <ItemTemplate>
                                    <asp:Label ID="lbSTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_stime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันแก้ไข" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="btnDateEditCM" runat="server" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลา" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="btnTimeEditCM" runat="server" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลาดำเนินการ" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right">
                                <ItemTemplate>
                                    <asp:Label ID="lbDay" runat="server" Font-Size="16px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right">
                                <ItemTemplate>
                                    <asp:Label ID="lbStatus" runat="server" Font-Size="16px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ผู้รับผิดชอบ" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right">
                                <ItemTemplate>
                                    <asp:Label ID="lbResponsible" runat="server" Font-Size="16px" Text='<%# new ClaimProject.Config.ClaimFunction().ShortText(DataBinder.Eval(Container, "DataItem.drive_group_agency").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager text-xl" ForeColor="#ef8a00" />
                    </asp:GridView>
                    <div class="row">
                        <asp:Label ID="lbCMNull" runat="server" CssClass="text-black-50 text-sm"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    <!------------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="ApprovCMModal" tabindex="-1" role="dialog" aria-labelledby="ApprovCMModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header" style="font-family: 'TH SarabunPSK'; font-size: 40px; font-weight: bold;">
                    <div class="modal-title">
                        <asp:Label ID="pkeq" runat="server" Visible="false" Font-Size="Smaller"></asp:Label>
                        <asp:Label ID="lbrefRecheck" Enabled="false" runat="server" Visible="false" />
                        ด่านฯ 
                                <asp:Label ID="lbCpointRecheck" Enabled="false" runat="server" />
                        <asp:Label ID="lbPointRecheck" Enabled="false" runat="server" />
                        [
                                <asp:Label ID="lbChannelRecheck" Enabled="false" runat="server" />
                        ]&nbsp อุปกรณ์ : [
                                    <asp:Label ID="lbdeviceRecheck" Enabled="false" runat="server" CssClass="font-weight-bold" />
                        ]
                    </div>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" style="font-size: 3rem;">&times;</span>
                    </button>
                </div>
                <div class="container" style="font-size: 32px; font-family: 'TH SarabunPSK'; font-weight: 200">
                    <div class="modal-body" style="line-height: inherit;">
                        <!--<div class="row">
                            <div class="col-xl-8">
                                <div class="form-group bmd-form-group" style="font-size: 38px;">
                                    <span class="label label-primary">อุปกรณ์ : </span>
                                    <asp:Label ID="lb" Enabled="false" runat="server" CssClass="font-weight-bold" />
                                </div>
                            </div>
                            <div class="col-xl-4">
                                <div class="form-group bmd-form-group">
                                    <asp:Label ID="lbStatusH" Enabled="false" runat="server" Visible="false">สถานะ : </asp:Label>
                                    <asp:Label ID="lbStatusRecheck" Enabled="false" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                        -->
                        <div class="row" style="height: 410px;">
                            <div class="card border-white col-sm-12 col-lg-5" style="font-size: 24px;">
                                <asp:Label ID="lbImageStart" runat="server" Text="ก่อนซ่อม" CssClass="text-center text-danger"></asp:Label>
                                <asp:Image ID="ImgEditEQ" runat="server" Height="340px" CssClass="rounded d-block" />
                            </div>
                            <div class="col-sm-12 col-lg-1"></div>
                            <div class="card border-white col-sm-12 col-lg-5" style="font-size: 24px;">
                                <asp:Label ID="lbImageEnd" runat="server" Text="หลังซ่อม" CssClass="text-center text-success"></asp:Label>
                                <asp:Image ID="ImgEditEQE" runat="server" Height="340px" CssClass="rounded d-block" />
                            </div>
                        </div>
                        <!------------------------------------------------------------------------------------------------------>
                        <div class="row">
                            <div class="col-xl-6 text-danger">
                                <div class="form-group bmd-form-group">
                                    <span class="label label-primary">อาการที่พบ : </span>
                                    <asp:Label ID="lbProblemRecheck" Enabled="false" runat="server" />
                                </div>
                            </div>
                            <div class="col-xl-6 ">
                                <div class="form-group bmd-form-group">
                                    <span class="label label-primary">วิธีการแก้ไข : </span>
                                    <asp:Label ID="lbMethodRecheck" Enabled="false" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-6">
                                <div class="form-group bmd-form-group">
                                    <span class="label label-primary">ผู้แจ้ง : </span>
                                    <asp:Label ID="lbUserRecheck" Enabled="false" runat="server" />
                                </div>
                            </div>
                            <div class="col-xl-6">
                                <div class="form-group bmd-form-group">
                                    <span class="label label-primary">ชื่ออุปกรณ์/อะไหล่ทดแทน : </span>
                                    <asp:Label ID="lbreplace" Enabled="false" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-6">

                            </div>
                            <div class="col-xl-6">
                                <div class="form-group bmd-form-group">
                                    <span class="label label-primary">หมายเลขอุปกรณ์เดิม : </span>
                                    <asp:Label ID="lbnoOriginal" Enabled="false" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-6">
                                
                            </div>
                            <div class="col-xl-6">
                                <div class="form-group bmd-form-group">
                                    <span class="label label-primary">หมายเลขอุปกรณ์ทดแทน : </span>
                                    <asp:Label ID="lbnorepalce" Enabled="false" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-6 ">
                                <div class="form-group bmd-form-group">
                                    <asp:Label ID="lbDates" Enabled="false" runat="server" Visible="false">วันที่แจ้ง : </asp:Label>
                                    <asp:Label ID="lbDatesRecheck" Enabled="false" runat="server" Visible="false" /><asp:Label ID="lbTimesRecheck" Enabled="false" runat="server" Visible="false" />
                                </div>
                            </div>
                            <!--<div class="col-xl-3">
                                <div class="form-group bmd-form-group">
                                    <span class="label label-primary">วันที่เข้า : </span>
                                    <asp:Label ID="lbDateERecheck" Enabled="false" runat="server" /><asp:Label ID="lbTimeERecheck" Enabled="false" runat="server" />
                                </div>
                            </div>-->
                            <div class="col-xl-6 ">
                                <div class="form-group bmd-form-group">
                                    <span class="label label-primary">วันเข้า-สิ้นสุด : </span>
                                    <asp:Label ID="lbDateEJRecheck" Enabled="false" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-6">
                                <!--<div class="form-group bmd-form-group">
                                    <span class="label label-primary">หมายเหตุ : </span>
                                    <asp:Label ID="lbNodeRecheck" Enabled="false" runat="server" />
                                </div>-->
                            </div>
                            <div class="col-xl-6">
                                <div class="form-group bmd-form-group">
                                    <span class="label label-primary">ผู้รับรอง : </span>
                                    <asp:Label ID="lbUserEJRecheck" Enabled="false" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
        <div class="modal-footer">
            <!--<span class="label label-primary">ใบ Service : </span>
                            <asp:Label ID="lbServiceForm" Enabled="false" runat="server" />-->
            <asp:Label ID="Imgfilename" runat="server" Visible="false"></asp:Label>
            <asp:LinkButton ID="ImgImageDocSer" runat="server" Text="ใบ Service" CssClass="col-1 btn btn-info" OnClick="ImgImageDocSer_Click" />
            <asp:LinkButton ID="btnReverb" runat="server" Text="Reverb" CssClass="col-1 btn btn-danger" OnCommand="btnReverb_Command" Visible="false" OnClientClick="return CompareConfirm('คุณต้องการย้อนกลับไปอนุมัติอีกครั้ง ใช่หรือไม่');" />
        </div>
        </div>
            </div>
        </div>
    </div>
    <!------------------------------------------------------------------------------------------------------------>

    <script src="/Scripts/jquery-migrate-3.0.0.min.js"></script>
    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script>
        $(function () {
            <% if (alert != "")
        { %>
            demo.showNotification('top', 'center', '<%=icon%>', '<%=alertType%>', '<%=alert%>');
            <% } %>
        });

        $('.datepicker').datepicker({
            format: 'dd/mm/yyyy',
            startDate: '-3d'
        });

        $(function () {
                <% if (EditModal != "")
        {%>
            $("#ApprovCMModal").modal('show');
                <%}
        else
        {%>
            $("#ApprovCMModal").modal('hide');
                <%}%>       
        });

        $("#ApprovCMModal").printThis({
            debug: false,
            importCSS: true,
            importStyle: true,
            printContainer: true,

            pageTitle: "My Modal",
            removeInline: false,
            printDelay: 333,
            header: null,
            formValues: true
        });

        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

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
</asp:Content>
