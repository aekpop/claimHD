<%@ Page Title="งานบำรุงรักษา / การแก้ไข" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMEditForm.aspx.cs" Inherits="ClaimProject.CM.CMEditForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- CSS only -->
    <link href="../Content/form-design-new.css" rel="stylesheet" />
    <link href="../Content/CM.css" rel="stylesheet" />
    <style>
        .custom-file {
            border: 0.1rem solid #808080;
            margin-bottom: 0;
        }

        .custom-file {
            height: calc(1.5em + 0.45rem + 2px);
        }
    </style>

    <!-- JS -->

    <div class="container-fluid" style="font-family: 'Prompt',sans-serif;">
        <!-- Menu Dropdown -->
        <div class="btn-group" runat="server" visible="false">
            <button class="btn btn-info"><i class="fas fa-align-justify"></i></button>
            <button class="btn dropdown-toggle btn-info" data-toggle="dropdown">
                <span class="caret"></span>
            </button>
            <ul class="dropdown-menu">
                <li><a href="/CM/DefaultCM">หน้าหลัก</a></li>
                <li><a href="/CM/CMDetailForm">แจ้งซ่อม</a></li>
                <li><a href="/CM/CMEditForm">การแก้ไข</a></li>
                <li><a href="/CM/CMLine">ส่งไลน์</a></li>
                <li><a href="/CM/CMReport">สรุปรายการ</a></li>
            </ul>
        </div>
        <!-------------------------------- // ------------------------------------>
        <div id="DivCMGridView" runat="server">
            <div class="card" style="z-index: 0">
                <div class="card-header ">
                    <div class="card-title">ค้นหา</div>
                </div>
                <div class="card-body table-responsive table-md">

                    <!--<div class="col-md">
                        <label class="bmd-label-floating">ปีงบประมาณ : </label>
                        <asp:DropDownList ID="ddlCMBudget" runat="server"  CssClass="form-control custom-select" ></asp:DropDownList>
                    </div>-->
                    <div class="input-group mb-3">
                        <asp:DropDownList ID="txtCpointSearch" runat="server" CssClass="form-control custom-select "></asp:DropDownList>
                        <asp:TextBox ID="txtAnnex" runat="server" CssClass="form-control " Enabled="false" placeholder="อาคาร" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                        <asp:DropDownList ID="ddlChanel" runat="server" CssClass="form-control custom-select " placeholder="ช่องทาง"></asp:DropDownList>
                        <div class="input-group-append">
                            <asp:LinkButton ID="btnSearchEdit" runat="server" CssClass="btn btn-outline-secondary " OnClick="btnSearchEdit_Click"><i class="fas fa-search"></i>&nbsp</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header">
                    <div class="card-title">
                        รายการแจ้งซ่อมอุปกรณ์                       
                    </div>
                    <div class="card-body">
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="CMGridView" runat="server"
                                AutoGenerateColumns="False" CssClass="table table-striped table-hover"
                                HeaderStyle-BackColor="#4a9cc0"
                                HeaderStyle-Font-Size="18px"
                                HeaderStyle-ForeColor="#FFFFFF"
                                OnRowDataBound="CMGridView_RowDataBound"
                                Font-Size="15px"
                                CellPadding="4"
                                ForeColor="#333333"
                                GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="ด่านฯ" ItemStyle-CssClass="col-2">
                                        <ItemTemplate>
                                            <asp:Label ID="lbCpoint" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name")+" "+DataBinder.Eval(Container, "DataItem.cm_point") +" [" +DataBinder.Eval(Container, "DataItem.locate_name") +"]" %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="วันที่-เวลา" ItemStyle-CssClass="col-1">
                                        <ItemTemplate>
                                            <asp:Label ID="lbSDate" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="อุปกรณ์" ItemStyle-CssClass="col-3">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="อาการที่พบ" ItemStyle-CssClass="col-3">
                                        <ItemTemplate>
                                            <asp:Label ID="lbProblem" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_problem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ผู้แจ้ง" ItemStyle-CssClass="col-2">
                                        <ItemTemplate>
                                            <asp:Label ID="lbUser" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="จัดการข้อมูล" ItemStyle-CssClass="col-1 text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnStatusUpdate" runat="server" OnCommand="btnStatusUpdate_Command" CssClass="badge bg-info text-white" Font-Size="16px" ToolTip="อัพเดตสถานะการซ่อม"><i class="fas fa-wrench fa-2x"></i>&nbsp Repair</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle Font-Bold="True"></HeaderStyle>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="UpdateStatusModal" tabindex="-1" role="dialog" aria-labelledby="UpdateStatusModalLabel" aria-hidden="true" style="font-family: 'Prompt',sans-serif;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="modal-title">
                        กรอกรายละเอียดการแก้ไข
                        <asp:Label ID="Label1" runat="server" Text="Label1" CssClass="text-dark"></asp:Label>
                    </div>
                    <asp:Label ID="lbcmid" runat="server" Visible="false"></asp:Label>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style="line-height: inherit;">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="card border-info ">
                                <asp:Image ID="ImgCM" runat="server" Width="100%" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">วันที่ : </label>
                                <asp:Label ID="lbsDate" runat="server" Text="Label" CssClass="text-dark"></asp:Label>
                                <label class="bmd-label-floating">เวลา : </label>
                                <asp:Label ID="lbsTime" runat="server" Text="Label" CssClass="text-dark"></asp:Label>
                            </div>
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ด่านฯ : </label>
                                <asp:Label ID="Label5" runat="server" Text="Label" CssClass="text-dark"></asp:Label>
                                <label class="bmd-label-floating">ช่องทาง : </label>
                                <asp:Label ID="Label2" runat="server" Text="Label" CssClass="text-dark"></asp:Label>
                            </div>
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">อุปกรณ์ : </label>
                                <asp:Label ID="Label3" runat="server" CssClass="text-dark"></asp:Label>
                            </div>
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">อาการที่พบ : </label>
                                <asp:Label ID="Label4" runat="server" CssClass="text-dark"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-xl-3">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">วันที่เข้าซ่อม</label>
                                <asp:TextBox ID="txtEDate" runat="server" CssClass="form-control datepicker" />
                            </div>
                        </div>
                        <div class="col-xl-3">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เวลาเข้าซ่อม</label>
                                <asp:TextBox ID="txtETime" runat="server" type="time" CssClass="form-control" MaxLength="5" />
                            </div>
                        </div>

                        <div class="col-xl-3">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">วันที่ซ่อมเสร็จ</label>
                                <asp:TextBox ID="txtEJDate" runat="server" CssClass="form-control datepicker" />
                            </div>
                        </div>
                        <div class="col-xl-3">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เวลาซ่อมเสร็จ</label>
                                <asp:TextBox ID="txtEJTime" runat="server" type="time" CssClass="form-control" MaxLength="5" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">วิธีแก้ไข</label>
                                <asp:TextBox ID="txtMethod" runat="server" CssClass="form-control " />
                            </div>
                        </div>

                        <div class="col-lg">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">หมายเหตุ</label>
                                <asp:TextBox ID="txtNote" runat="server" CssClass="form-control " />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <label class="container" style="font-size: 1rem;">
                                    เปลี่ยนอุปกรณ์/อะไหล่ (ระบุหมายเลขอุปกรณ์)
                                  <input type="checkbox" id="Chkreplace" name="ckeRepalce" runat="server" />
                                    <span class="checkmark"></span>
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-12 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ชื่ออุปกรณ์/อะไหล่ทดแทน (ถ้ามี)</label>
                                <asp:TextBox ID="txtreplaceName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <label class="container" style="font-size: 1rem;">
                                    ไม่มีใบService (แก้ไขเบื้องต้น หายเอง หรือซ่อมโดยซ่อมบำรุง)
                                  <input type="checkbox" id="ckeNoservice" name="ckeNoservice" runat="server" />
                                    <span class="checkmark"></span>
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-12 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">หมายเลขอุปกรณ์ทดแทน (ถ้ามี) </label>
                                <asp:TextBox ID="txtreplaceNo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-6 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <label class="text-black-50">แนบภาพแก้ไข </label>
                                <asp:FileUpload ID="fileImg" runat="server" CssClass="custom-file" lang="en" onchange="validateSize(this)" />
                            </div>
                        </div>
                        <div class="col-lg-6 col-xl-6">
                            <div id="imgService" runat="server">

                                <div class="form-group bmd-form-group">
                                    <label class="text-black-50">ใบService </label>
                                    <asp:FileUpload ID="fileDocService" runat="server" CssClass="custom-file" lang="en" onchange="validateSize(this)" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row col-xl-12 text-black-50">
                        <label style="font-size: 0.5rem;">รองรับรูปภาพนามสกุล .jpg, .JPEG และ.PNG เท่านั้น </label>
                        <label style="font-size: 0.5rem;">ภาพแก้ไขและใบservice ขนาดไฟล์รูปภาพไม่เกิน 2MB</label>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton ID="btnUpdateCM" runat="server" CssClass="btn btn-success btn-sm" Font-Size="Medium" OnCommand="btnUpdateCM_Command" OnClientClick="return CompareConfirm('ยืนยันบันทึกข้อมูล ใช่หรือไม่');">บันทึก</asp:LinkButton>
                        <asp:LinkButton ID="btnDeleteCM" runat="server" CssClass="btn btn-danger btn-sm" Font-Size="Medium" OnCommand="btnDeleteCM_Command" OnClientClick="return CompareConfirm('ยืนยันลบข้อมูล ใช่หรือไม่');">ลบ</asp:LinkButton>
                        <button type="button" class="btn btn-default btn-sm" data-dismiss="modal" style="font-size: medium">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/Scripts/jquery-migrate-3.0.0.min.js"></script>
    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript">
        <%if (cm_id != "")
        {%>
        $('#UpdateStatusModal').modal("show");
        <%}
        else
        {%>
        $('#UpdateStatusModal').modal("hide");
        <%}%>
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

        function checkText() {
            var str1 = "1";
            var str2 = "2";

            if (str1 === str2) {
                // your logic here
                return false;
            } else {
                // your logic here
                if ($('<%=txtMethod.ClientID%>').val === "") {
                    alert("กรุณาใส่วิธีแก้ไข");
                    return false;
                } else {
                    return true;
                }
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

        function validateSize(FileUpload) {
            const fileSize = FileUpload.files[0].size / 1024 / 1024; // in MiB
            if (fileSize > 2) {
                alert('ขนาดไฟล์เกิน 2 MB');
                $(FileUpload).val(''); //for clearing with Jquery
            } else {
                return true;
            }
        }

        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

        history.pushState(null, null, window.location.href);
        history.back();
        window.onpopstate = () => history.forward();

        $('#txtETime').datetimepicker({
            format: 'HH.mm'
        });

        function disableF5(e) { if ((e.which || e.keyCode) == 116) e.preventDefault(); };
        $(document).on("keydown", disableF5);

    </script>
</asp:Content>
