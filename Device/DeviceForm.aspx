﻿<%@ Page Title="รายการอุปกรณ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DeviceForm.aspx.cs" Inherits="ClaimProject.Device.DeviceForm" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">เพิ่มอุปกรณ์</h3>
            </div>
            <div class="card-body">
                <div class="form-row">
                    <div class="col-md-4">
                        ชื่ออุปกรณ์ :
                        <asp:TextBox ID="txtDeviceName" runat="server" CssClass="form-control"
                            onkeypress="return handleEnter(this, event)"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        กลุ่ม :
                        <asp:DropDownList ID="txtGroup" runat="server" CssClass="form-control dropdown-item ">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        เวลาเข้าซ่อม :
                        <asp:TextBox ID="txtSchedule" runat="server" CssClass="form-control"
                            onkeypress="return handleEnter(this, event)"></asp:TextBox>
                    </div>
                     <div class="col-md-3">
                        <asp:Button ID="Button1" runat="server" Text="&#xf067; เพิ่ม" Font-Size="Medium"
                            CssClass="btn btn-success btn-sm align-items-end fa" OnClick="btnDeviceAdd_Click"
                            OnClientClick="return CompareConfirm('ยืนยันเพิ่มอุปกรณ์ ใช่หรือไม่');" />
                    </div>
                </div>                
            </div>
        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="form-row">
                    <h3 class="card-title">ค้นหา</h3>
                    <div class="col-md-3">
                        
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"
                            onkeypress="return handleEnter(this, event)"></asp:TextBox>
                        </div>
                         <div class="col-md-3">
                            <asp:Button ID="btnSearch" runat="server" Font-Size="Medium" Text="&#xf002; ค้นหา"
                            CssClass="btn btn-info btn-sm align-items-end fa" OnClick="btnSearch_Click" />
                    </div>
                </div>
               
                <div class="form-row">
                    <div class="card">
                        <div class="card-header ">
                            <h3 class="card-title">รายการอุปกรณ์</h3>
                        </div>
                        <div class="card-body table-responsive">
                            <asp:GridView ID="DeviceGridView" runat="server" DataKeyNames="device_id" GridLines="None"
                                OnRowDataBound="DeviceGridView_RowDataBound" AutoGenerateColumns="False"
                                CssClass="table table-hover table-sm" OnRowEditing="DeviceGridView_RowEditing"
                                OnRowCancelingEdit="DeviceGridView_RowCancelingEdit"
                                OnRowUpdating="DeviceGridView_RowUpdating" OnRowDeleting="DeviceGridView_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="ชื่ออุปกรณ์">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDevice" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEDevice" size="20" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>'
                                                CssClass="form-control" onkeypress="return handleEnter(this, event)">
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ชื่อย่อ">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDeviceSub" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.device_initials") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEDeviceSub" size="20" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.device_initials") %>'
                                                CssClass="form-control" onkeypress="return handleEnter(this, event)">
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="กลุ่ม">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDeviceGroup" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.drive_group_name") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="txtEDeviceGroup" runat="server"
                                                CssClass="form-control"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เวลาเข้าซ่อม">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDeviceSchedule" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.device_schedule_hour") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEDeviceSchedule" size="3" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.device_schedule_hour") %>'
                                                CssClass="form-control" onkeypress="return handleEnter(this, event)">
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="สัญญา/โครงการอ้างอิง">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDeviceref" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.device_ref_Project") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDeviceref" runat="server" CssClass="form-control"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.device_ref_Project") %>'>
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ราคาอ้างอิง">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDevicePrice" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.device_ref_Price") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDevicePrice" runat="server" CssClass="form-control"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.device_ref_Price") %>'>
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" CancelText="ยกเลิก"
                                        EditText="&#xf040; แก้ไข" UpdateText="ตกลง" HeaderText="ปรับปรุง"
                                        ControlStyle-Font-Size="Small"
                                        ControlStyle-CssClass="btn btn-outline-warning btn-sm fa" />
                                    <asp:CommandField ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014; ลบ"
                                        ControlStyle-CssClass="btn btn-outline-danger btn-sm fa"
                                        ControlStyle-Font-Size="Small" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="card-footer">
                            <div class="stats">
                                <asp:Label ID="lbDeviceNull" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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

            function handleEnter(field, event) {
                var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
                if (keyCode == 13) {

                    return false;
                }
                else {
                    return true;
                }
            }
        </script>
    </asp:Content>