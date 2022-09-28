﻿<%@ Page Title="งานบำรุงรักษา / แจ้งซ่อม" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMDetailForm.aspx.cs" Inherits="ClaimProject.CM.CMDetailForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <script src="/crystalreportviewers13/js/crviewer/crv.js"></script>
    <script src="../Scripts/printThis.js"></script>
    <!-- CSS only -->
    <link href="/Content/form-design-new.css" rel="stylesheet" />
    <link href="../Content/CM.css" rel="stylesheet" />
    <!-- JS, Popper.js, and jQuery -->
    <script src="../Scripts/jquery-3.5.1.js"></script>
    <script src="../Scripts/umd/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <div class="container-fluid" style="font-family: 'Prompt',sans-serif;">
        <!-- Menu Dropdown -->
        <!-------------------------------- // ------------------------------------>
        <div class="card" style="z-index: 0; font-size: 1rem;">
            <div class="card-header">
                <div class="card-title text-black-50">แจ้งซ่อมอุปกรณ์</div>
            </div>
            <div class="card-body table-responsive">
                <asp:HiddenField ID="txtRef" runat="server" />
                <div class="row">
                    <div class="col-md-6 col-xl-3">
                        <div class="form-group bmd-form-group">
                            <asp:Label runat="server" Text="ด่านฯ"></asp:Label>
                            <!--<p class="bmd-label-floating">ด่านฯ :</p>-->
                            <asp:DropDownList ID="txtCpoint" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6 col-xl-3">
                        <div class="form-group bmd-form-group">
                            <asp:Label runat="server">อาคารย่อย</asp:Label>
                            <asp:TextBox ID="txtPoint" runat="server" CssClass="form-control" MaxLength="1" Enabled="false" ToolTip="กรณีไม่มีอาคารย่อย ให้เว้นว่าง" onkeypress="return handleEnter(this, event)" />
                        </div>
                    </div>
                    <div class="col-md-6 col-xl-3">
                        <div class="form-group bmd-form-group">
                            <asp:Label runat="server">หมายเลขช่องทาง</asp:Label>
                            <asp:DropDownList ID="ddlChanel" runat="server" CssClass="form-control dropdown"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6 col-xl-3">
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group bmd-form-group">
                                    <asp:Label runat="server">วันที่</asp:Label>
                                    <asp:TextBox ID="txtSDate" runat="server" CssClass="form-control datepicker" onkeypress="return handleEnter(this, event)" />
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-group bmd-form-group">
                                    <asp:Label runat="server">เวลา</asp:Label>
                                    <asp:TextBox ID="txtSTime" runat="server" MaxLength="5" type="time" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-xl-3">
                        <div class="form-group bmd-form-group">
                            <asp:Label runat="server">อุปกรณ์</asp:Label>
                            <asp:DropDownList ID="txtDeviceAdd" runat="server" CssClass="combobox form-control custom-select" onkeypress="return handleEnter(this, event)" />
                        </div>
                    </div>
                    <div class="col-md-6 col-xl-3">
                        <div class="form-group bmd-form-group">
                            <asp:Label runat="server">อาการที่พบ</asp:Label>
                            <asp:TextBox ID="txtProblem" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)" />
                        </div>
                    </div>
                    <!-- แนบรูป -->
                    <div class="col-md-12 col-xl-6">
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group bmd-form-group">
                                    <asp:Label runat="server">แนบรูปภาพ</asp:Label>
                                    <div class="col" runat="server" id="diveditpic">
                                        <asp:FileUpload ID="fileImg" runat="server" CssClass="custom-file" lang="en" onchange="validateSize(this)" />
                                    </div>
                                    <div class="col-md-1">
                                        <asp:Label ID="pkeq" runat="server" Visible="true" Font-Size="Smaller"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-group bmd-form-group">
                                    <asp:Label runat="server">Preview</asp:Label>
                                    <asp:Image ID="lbNameFileImg" runat="server" CssClass="img-thumbnail" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br>
                <div class="row">
                    <div class="col-md text-center">
                        <asp:LinkButton ID="btnSaveCM" runat="server" Visible="true" CssClass="btn btn-success btn-sm" OnClientClick="return CompareConfirm('ยืนยัน แจ้งซ่อมอุปกรณ์ ใช่หรือไม่');" OnClick="btnSaveCM_Click">
                             ตกลง</asp:LinkButton>
                        <asp:LinkButton ID="btnEditCM" runat="server" CssClass="btn btn-warning btn-sm" OnClientClick="return CompareConfirm('ยืนยัน แก้ไขแจ้งซ่อมอุปกรณ์ ใช่หรือไม่');" OnClick="btnEditCM_Click">แก้ไข</asp:LinkButton>
                        <asp:LinkButton ID="btnCancelCM" runat="server" CssClass="btn btn-dark btn-sm" OnClick="btnCancelCM_Click">ยกเลิก</asp:LinkButton>
                        <asp:LinkButton ID="btnDeleteCM" runat="server" CssClass="btn btn-danger btn-sm" OnClientClick="return CompareConfirm('ยืนยัน ลบข้อมูลการแจ้งซ่อมอุปกรณ์ ใช่หรือไม่');" OnClick="btnDeleteCM_Click">ลบ</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div id="DivCMGridView" runat="server">
            <div class="card" style="z-index: 0; font-size: 1rem;">                
                <div class="card-header">
                    <div class="card-title">ค้นหา</div>
                        <div class="input-group mb-3">
                            <asp:DropDownList ID="txtCpointSearch" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:TextBox ID="txtCmpoint" runat="server" CssClass="form-control" placehodler="อาคารย่อย"></asp:TextBox>
                            <div class="input-group-append">
                                <asp:Button ID="btnSearchAddd" runat="server" Visible="true" CssClass="btn btn-outline-secondary" OnClick="btnSearchAddd_Click" Text="ค้นหา"></asp:Button>
                            </div>
                        </div>                 
                    <br />
                    <div class="card-title">รายการแจ้งซ่อมอุปกรณ์</div>
                </div>
                <div class="card-body table-responsive table-sm">                    
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:GridView ID="CMGridView" runat="server"
                            AutoGenerateColumns="False"
                            CssClass="table table-striped table-hover"
                            HeaderStyle-BackColor="#4a9cc0"
                            HeaderStyle-ForeColor="#FFFFFF"
                            HeaderStyle-Font-Size="18px"
                            OnRowDataBound="CMGridView_RowDataBound"
                            Font-Size="15px"
                            CellPadding="4"
                            ForeColor="#333333"
                            GridLines="None"
                            OnPageIndexChanging="CMGridView_PageIndexChanging"
                            PagerSettings-Mode="NumericFirstLast"
                            AllowPaging="true"
                            PageSize="30">
                            <Columns>
                                <asp:TemplateField HeaderText="ด่านฯ" ItemStyle-CssClass="col-2">
                                    <ItemTemplate>
                                        <asp:Label ID="lbCpoint" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name")+" "+DataBinder.Eval(Container, "DataItem.cm_point") +" ["+DataBinder.Eval(Container, "DataItem.locate_name")+"]" %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="วันที่" ItemStyle-CssClass="col-1">
                                    <ItemTemplate>
                                        <asp:Label ID="lbSDate" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="อุปกรณ์" ItemStyle-CssClass="col-3">
                                    <ItemTemplate>
                                        <asp:Label ID="lbDeviceName" runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().ShortText(DataBinder.Eval(Container, "DataItem.device_name").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="อาการชำรุด" ItemStyle-CssClass="col-3">
                                    <ItemTemplate>
                                        <asp:Label ID="lbProblem" runat="server" Text='<%#new ClaimProject.Config.ClaimFunction().ShortText( DataBinder.Eval(Container, "DataItem.cm_detail_problem").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                       
                                <asp:TemplateField HeaderText="ผู้แจ้ง" ItemStyle-CssClass="col-2">
                                    <ItemTemplate>
                                        <asp:Label ID="lbcmUser" runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().ShortText(DataBinder.Eval(Container, "DataItem.name").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="จัดการข้อมูล" ItemStyle-CssClass="col-1">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditCM" runat="server" CssClass="badge bg-warning text-white" Font-Size="16px" ToolTip="แก้ไขรายละเอียดการแจ้งซ่อม" OnCommand="btnEdit_Command" OnClientClick="return CompareConfirm('แก้ไขรายการ ใช่หรือไม่')"><i class="fas fa-edit fa-2x"></i>&nbsp Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle Font-Bold="True"/>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <!--model confirm-->
        <div class="modal fade" id="EditModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:Label ID="pkedit" runat="server" Visible="true" Font-Size="Smaller"></asp:Label>
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="H3"></h4>
                    </div>
                    <asp:UpdatePanel ID="upDel" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                คุณต้องการแก้ไขรายการนี้ใช่ หรือ ไม่
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                <asp:Button ID="btnEditCMM" runat="server" CssClass="btn btn-success" Text="Confirm" OnCommand="btnEditCMM_Command" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <script src="/Scripts/jquery-migrate-3.0.0.min.js"></script>
    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript"> 
        function ClickAdd() {
            $("#addCMModal").modal('show');
            return false;
        }

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

        function unhide() {
            document.getElementById("Loading").removeAttribute("hidden");
        }

        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {
                alert('ระบบกำลังประมวลผล ... กรุณากด "ตกลง" เพื่อทำรายการต่อไป');
                return false;
            }
        }

        function ComfirmEdit() {
            $('#EditModal').modal(); // initialized with defaults
            return false;
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

        $(function () {
         <% if (alerts != "")
        { %>
            demo.showNotification('top', 'center', '<%=icons%>', '<%=alertTypes%>', '<%=alerts%>');
        <% } %>
        });

        function validateSize(FileUpload) {
            const fileSize = FileUpload.files[0].size / 1024 / 1024; // in MiB
            if (fileSize > 2) {
                alert('ขนาดไฟล์เกิน 4 MB');
                $(FileUpload).val(''); //for clearing with Jquery
            } else {
                // Proceed further
            }
        }

        function chkNum(ele) {
            var num = parseFloat(ele.value);
            ele.value = num.toFixed(2);
        }
    </script>
</asp:Content>
