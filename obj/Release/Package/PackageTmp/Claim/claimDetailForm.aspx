<%@ Page Title="งานอุบัติเหตุ/แจ้งอุบัติเหตุ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="claimDetailForm.aspx.cs" Inherits="ClaimProject.Claim.claimDetailForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <style>
        .card {
            
        }
            .card .card-body {
                background-color: #ffffff;
            }

        .btn, .btn.btn-default {
            top: 0px;
            left: 0px;
        }

        .btn {
            margin: 0 0 0 0;
            line-height: 1;
            font-size: 2rem;
        }
            .btn.btn-outline-secondary {
                color: #567492;
                border-color: #bfcad5;
            }

        .form-control-file, .form-control-range {
            border: 1px solid;
            border-color: #bfcad5;
            width: 90%;
        }

        button, input, optgroup, select, textarea {
            font-size: 1.6rem;
        }

        .form-control {
            font-size:1.3rem;
        }

    </style>
    <div class="tab-content">
        <div class="card" style="font-size: 26px; z-index: 0; font-family: 'TH SarabunPSK';">
            <div class="card-body table-responsive">
                <div runat="server" id="divCom">
                    <div class="card-title text-gray-800">
                        รายละเอียดการเกิดอุบัติเหตุ (เจ้าหน้าที่คอม)
                        <asp:Label ID="statheader" runat="server"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="font-weight-normal">ด่านฯ </p>
                                <asp:DropDownList ID="txtCpoint" runat="server" CssClass="form-control custom-select"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">อาคารย่อย </p>
                                <asp:TextBox ID="txtPoint" runat="server" CssClass="form-control" MaxLength="1" placeholder="Annex เช่น 1 หรือ 2 หรือเว้นว่าง" />
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">เลขที่บันทึก</p>
                                <asp:TextBox ID="txtCpointNote" runat="server" CssClass="form-control" placeholder="เช่น 1234" />
                                <span id="numNote-error">ไม่ถูกต้อง</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ลงวันที่</p>
                                <asp:TextBox ID="txtCpointDate" runat="server" CssClass="form-control datepicker" />
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">เรียน </p>
                                <asp:TextBox ID="txtNoteTo" runat="server" CssClass="form-control" Text="ผจด. ผ่าน รอง ผจด."></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ชื่อเรื่อง </p>
                                <asp:TextBox ID="txtEquipment" runat="server" CssClass="form-control" placeholder="รายงานอุบัติเหตุรถเฉี่ยวชนอุปกรณ์ (....ชื่ออุปกรณ์) ช่องทาง ...... ด่านฯ...."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <hr />
                    <div class="row">
                        <div class="col-md-3 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">วันที่เกิดเหตุ</p>
                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control datepicker" />
                            </div>
                        </div>
                        <div class="col-md-3 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">เวลา</p>
                                <asp:TextBox ID="txtTime" runat="server" CssClass="form-control" MaxLength="5" ToolTip="เวลา เช่น 10.30 ไม่ต้องใส่ น." />
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ผลัด </p>
                                <asp:DropDownList ID="txtAround" runat="server" CssClass="form-control custom-select"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ได้รับแจ้งจาก</p>
                                <asp:TextBox ID="txtNameAleat" runat="server" CssClass="form-control" placeholder="ชื่อผู้แจ้งเหตุ"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ตำแหน่ง </p>
                                <asp:DropDownList ID="txtPosAleat" runat="server" CssClass="form-control custom-select"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ประจำตู้ / บริเวณ</p>
                                <asp:DropDownList ID="txtCB" runat="server" CssClass="combobox form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">แจ้งว่าเกิดอุบัติเหตุ...</p>
                                <asp:TextBox ID="txtDetail" runat="server" CssClass="form-control col-xl-auto"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">บริเวณที่เกิดอุบัติเหตุ</p>
                                <asp:DropDownList ID="txtCBClaim" runat="server" CssClass="combobox form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ทิศทาง</p>
                                <asp:TextBox ID="txtDirection" runat="server" CssClass="form-control" placeholder="ขาเข้าระบบ หรือ ขาออกระบบ"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <hr />
                    <div class="card-title text-black-50">รายละเอียดรถยนต์ของคู่กรณี (เจ้าหน้าที่คอม) </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ประเภทรถ</p>
                                <asp:DropDownList ID="txtTypeCar" runat="server" CssClass="combobox form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ยี่ห้อ</p>
                                <asp:DropDownList ID="txtBrandCar" runat="server" CssClass="combobox form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">สีรถ</p>
                                <asp:TextBox ID="txtColorCar" runat="server" placeholder="เช่น แดง" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">เลขทะเบียน</p>
                                <asp:TextBox ID="txtLicensePlate" runat="server" MaxLength="50" placeholder="กรณีไม่มี ไม่ต้องระบุ" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">จังหวัด</p>
                                <asp:TextBox ID="txtProvince" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">เลขทะเบียนส่วงพ่วง(ถ้ามี)</p>
                                <asp:TextBox ID="txtLp2" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">จังหวัดส่วนพ่วง(ถ้ามี)</p>
                                <asp:TextBox ID="txtProvince22" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">เลขทะเบียนอังกฤษ(ถ้ามี)</p>
                                <asp:TextBox ID="txtLiEng" runat="server" MaxLength="50" ToolTip="ไม่มีไม่ต้องใส่" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">จังหวัดอังกฤษ(ถ้ามี)</p>
                                <asp:TextBox ID="txtProEng" runat="server" MaxLength="50" ToolTip="ไม่มีไม่ต้องใส่" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">วิ่งมาจาก</p>
                                <asp:TextBox ID="txtComeFrom" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">มุ่งหน้า</p>
                                <asp:TextBox ID="txtDirectionIn" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ชื่อผู้ขับขี่</p>
                                <asp:TextBox ID="txtNameDrive" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">บัตรประจำตัวประชาชน</p>
                                <asp:TextBox ID="txtIdcard" runat="server" CssClass="form-control" MaxLength="13" ToolTip="ไม่มีขีด เช่น 1234567890123"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-3">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">เบอร์โทรศัพท์</p>
                                <asp:TextBox ID="txtTelDrive" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ที่อยู่</p>
                                <asp:TextBox ID="txtAddressDriver" runat="server" MaxLength="255" CssClass="form-control col-xl-auto" TextMode="MultiLine" Rows="4"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2" style="padding: 80px 1px 1px 10px" id="divcar2" runat="server" visible="true">
                            <asp:Button ID="btnCar2" Height="40px" runat="server" Text="คู่กรณีคันที่2" Font-Size="18px" Font-Bold="true" ForeColor="#790000" CssClass="btn " OnClick="btnCar2_Click" BackColor="#fcde92" />
                        </div>
                        <div class="col-md-2" style="padding: 80px 10px 1px 5px" id="divcar3" runat="server" visible="false">
                            <asp:Button ID="btnCar3" Height="40px" runat="server" Text="คู่กรณีคันที่3" Font-Size="18px" Font-Bold="true" CssClass="btn" ForeColor="#790000" OnClick="btnCar3_Click" BackColor="#fcde92" />
                        </div>
                    </div>
                    <hr />
                </div>
                <div id="divSup" runat="server">
                    <div class="card-title text-black-50">รายละเอียดอุบัติเหตุ (รองผู้จัดการด่านฯ)</div>
                    <div class="row ">
                        <div class="col-xl-3">
                            <label>
                                <asp:RadioButton ID="RadioButton1" GroupName="Check1" runat="server" onclick="Radio_Click()" Text="รถมีประกัน" />

                            </label>
                        </div>
                        <div class="col-xl-3">
                            <label>
                                <asp:RadioButton ID="RadioButton2" GroupName="Check1" runat="server" onclick="Radio_Click()" Text="รถไม่มีประกัน" />

                            </label>
                        </div>
                        <div class="col-xl-3">
                            <label>
                                <asp:RadioButton ID="RadioButton3" GroupName="Check1" runat="server" onclick="Radio_Click()" Text="รถฝ่าด่านฯ" />
                            </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">บริษัทประกันภัย</p>
                                <asp:TextBox ID="txtInsurer" runat="server" ToolTip="กรณีรถไม่ทำประกันไว้ ให้ระบุว่า ไม่มีประกัน " CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">สถานีตำรวจที่แจ้งความ</p>
                                <asp:TextBox ID="txtInform" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">หมายเลขกรมธรรม์</p>
                                <asp:TextBox ID="txtPolicyholders" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-xl-6">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">หมายเลขเคลม</p>
                                <asp:TextBox ID="txtClemence" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="card-title text-black-50">พนักงานที่ปฏิบัติงาน</div>
                <div class="row">
                    <div class="col-md-6 col-xl-6">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">รองผู้จัดการด่านฯ ประจำผลัด</p>
                            <asp:TextBox ID="txtSup" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 col-xl-6">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">ตำแหน่ง </p>
                            <asp:DropDownList ID="txtPosSup" runat="server" CssClass="form-control custom-select"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-xl-6">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">พนักงานควบคุมระบบที่ปฏิบัติหน้าที่</p>
                            <asp:TextBox ID="txtComName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 col-xl-6">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">ตำแหน่ง </p>
                            <asp:DropDownList ID="txtPosCom" runat="server" CssClass="form-control custom-select"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12 text-left">
                        <div class="form-group bmd-form-group">
                            <asp:LinkButton ID="btnAddCom" runat="server" Text="&#xf234; เพิ่ม พ.ควบคุมระบบ " CssClass="btn btn-success btn-sm fa" OnClick="btnAddCom_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>
                <br />
                <div style="font-size: larger" class="row">
                    <div class="col-md-6">
                        <asp:GridView ID="ComGridView" runat="server"
                            DataKeyNames="com_working_id"
                            GridLines="None"
                            OnRowDataBound="ComGridView_RowDataBound"
                            AutoGenerateColumns="False"
                            CssClass="table table-hover table-sm"
                            OnRowDeleting="ComGridView_RowDeleting" HeaderStyle-Font-Bold="true" RowStyle-CssClass="table-success">
                            <Columns>
                                <asp:TemplateField HeaderText="ชื่อ-สกุล">
                                    <ItemTemplate>
                                        <asp:Label ID="lbUser" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.com_working_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ตำแหน่ง">
                                    <ItemTemplate>
                                        <asp:Label ID="lbUser" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.com_working_pos") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014;" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Medium" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="LabelCom" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <hr />
                <div class="card-title text-black-50">รายการอุปกรณ์ที่ได้รับความเสียหาย</div>
                <div class="row">
                    <div class="col-md-6 col-xl-6">
                        <asp:RadioButton ID="rbtNormal" runat="server" AutoPostBack="true" GroupName="NormalOrKnow" OnCheckedChanged="rbtNormal_CheckedChanged" />
                        <label>แจ้งอุบัติเหตุ (อุปกรณ์ได้รับความเสียหาย)</label>
                    </div>
                    <div class="col-md-6 col-xl-6">
                        <asp:RadioButton ID="rbtForKnow" runat="server" AutoPostBack="true" GroupName="NormalOrKnow" OnCheckedChanged="rbtForKnow_CheckedChanged" />
                        <label>แจ้งเพื่อทราบ (อุปกรณ์ไม่ได้รับความเสียหาย)</label>
                    </div>
                    <asp:Label ID="chkClaimm" runat="server" Visible="false"></asp:Label>
                </div>
                <div class="row" id="DivNoDamage" runat="server" visible="false">
                    <div class="col-md-2">
                        <asp:CheckBox ID="CheckDeviceNotDamaged" runat="server" AutoPostBack="true" OnCheckedChanged="CheckDeviceNotDamaged_CheckedChanged" />
                        <label>อุปกรณ์ไม่ได้รับความเสียหาย</label>
                    </div>
                </div>
                <div id="DivDamaged" visible="false" runat="server">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">อุปกรณ์ที่ได้รับความเสียหาย</label>
                                <asp:DropDownList ID="txtDevice" runat="server" CssClass="combobox form-control custom-select"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form">
                                <br />
                                <label class="bmd-label-floating">ความเสียหาย</label>
                                <asp:TextBox ID="txtDeviceBroken" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group bmd-form-group">
                                <asp:LinkButton ID="btnAddDeviceBroken" runat="server" Text="&#xf067; เพิ่มอุปกรณ์" CssClass="btn btn-success btn-sm fa" OnClick="btnAddDeviceBroken_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            <br />
            <div class="row">
                <div class="col-md-6">
                    <asp:GridView ID="DeviceGridView" runat="server"
                        DataKeyNames="device_damaged_id"
                        GridLines="None"
                        OnRowDataBound="DeviceGridView_RowDataBound"
                        AutoGenerateColumns="False"
                        CssClass="table table-hover table-sm"
                        OnRowDeleting="DeviceGridView_RowDeleting" HeaderStyle-Font-Bold="true" RowStyle-CssClass="table-danger">
                        <Columns>
                            <asp:TemplateField HeaderText="ชื่ออุปกรณ์ที่ได้รับความเสียหาย">
                                <ItemTemplate>
                                    <asp:Label ID="lbUser" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ความเสียหาย">
                                <ItemTemplate>
                                    <asp:Label ID="lbUser" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_damaged") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014;" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Medium" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lbClaimDetailNull" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <hr />
            <div class="row card-title text-black-50">
                <div class="col-md-3">
                    <div>รูปภาพประกอบ</div>
                </div>
            </div>
            <h5 class="text-danger">เช่น รูปภาพความเสียหาย รูปภาพรถคู่กรณี</h5>
            <div class="col-md-12 col-xl-6">
                <div class="form-row formHead">
                    <div class="input-group mb-3">
                        <asp:FileUpload ID="fileImg" runat="server" CssClass="form-control-file"></asp:FileUpload>
                        <div class="input-group-append">
                            <asp:Button ID="btnAddImg" runat="server" Text="Upload" CssClass="btn btn-outline-secondary" OnClick="btnAddImg_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:GridView ID="FileGridView" runat="server"
                        DataKeyNames="claim_img_id"
                        GridLines="None"
                        OnRowDataBound="FileGridView_RowDataBound"
                        AutoGenerateColumns="False"
                        CssClass="table table-hover table-sm"
                        OnRowDeleting="FileGridView_RowDeleting" HeaderStyle-Font-Bold="true" RowStyle-CssClass="table-light">
                        <Columns>
                            <asp:TemplateField HeaderText="รูปภาพประกอบ">
                                <ItemTemplate>
                                    <asp:Image ID="ImgClaim" runat="server" Width="300px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDownload" runat="server" Font-Size="Small" CssClass="fa" OnCommand="btnDownload_Command">&#xf0ed; Download</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Small" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="LabelImg" runat="server" Text="Label"></asp:Label>
                    <!--<asp:LinkButton ID="btnReportImg" runat="server" Text="&#xf02f; พิมพ์รูปภาพประกอบ" Font-Size="Large" CssClass="btn btn-dark fa btn-sm" OnClick="btnReportImg_Click" />-->
                </div>
            </div>
            <hr />
            <div class="row card-title text-black-50">
                <div class="col-md-5">
                    <h3>รูปภาพเอกสารประกอบ</h3>
                </div>
            </div>
            <h5 class="text-danger">เช่น สำเนาบัตรประจำตัวประชาชน สำเนาใบขับขี่ สำเนาใบยอมรับความผิด เอกสารที่เกี่ยวข้องอื่นๆ</h5>
            <div class="col-md-12 col-xl-6">
                <div class="form-row formHead">
                    <div class="input-group mb-3">
                        <asp:FileUpload ID="FileUploadDoc" runat="server" CssClass="form-control-file"></asp:FileUpload>
                        <div class="input-group-append">
                            <asp:Button ID="btnUploadDoc" runat="server" Text="Upload" CssClass="btn btn-outline-secondary" OnClick="btnUploadDoc_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:GridView ID="UploadDocGridView" runat="server"
                        DataKeyNames="claim_img_id"
                        GridLines="None"
                        OnRowDataBound="UploadDocGridView_RowDataBound"
                        AutoGenerateColumns="False"
                        CssClass="table table-hover table-sm"
                        OnRowDeleting="UploadDocGridView_RowDeleting" HeaderStyle-Font-Bold="true" RowStyle-CssClass="table-light">
                        <Columns>
                            <asp:TemplateField HeaderText="รูปภาพประกอบ">
                                <ItemTemplate>
                                    <asp:Image ID="DocClaim" runat="server" Width="300px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDocDownload" runat="server" Font-Size="Small" CssClass="fa" OnCommand="btnDownload_Command">&#xf0ed; Download</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014;" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Medium" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="LabelDoc" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div class="card-footer">
            <div class="stats">
            </div>
        </div>
        <div class="row">
            <div class="col-md text-center">
                <asp:LinkButton ID="btnSaveReport" runat="server" Text="&#xf0c7; บันทึก" Font-Size="Large" CssClass="btn btn-info fa btn-sm" OnClick="btnSaveReport_Click"></asp:LinkButton>
                <asp:LinkButton ID="btnDelete" runat="server" Text="&#xf014; ลบข้อมูล" Font-Size="Large" CssClass="btn btn-danger fa btn-sm" OnClick="btnDelete_Click" OnClientClick="return CompareConfirm('ยืนยัน คุณต้องการลบข้อมูล ใช่หรือไม่')" />
                <asp:LinkButton ID="btnTechno" runat="server" Text="รายงานกองฯ" Font-Size="Large" CssClass="btn btn-dark fa btn-sm" OnClick="btnTechno_Click" />
                <br />
                &nbsp;
            </div>
        </div>
    </div>
    </div>
    <div class="modal fade " id="AddSecondModal" tabindex="-1" role="dialog" aria-labelledby="AddSecondModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered " style="max-height: 85%; margin-top: 50px; margin-bottom: 50px;" role="form">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="modal-title">
                        ข้อมูลคุ่กรณี คันที่  
                        <asp:Label runat="server" ID="lbmodaltitle" CssClass="text-center"></asp:Label>
                    </div>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style="line-height: inherit;">
                    <div class="row" style="height: 110px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ประเภทรถ</label>
                                <asp:DropDownList ID="ddlSecTypecar" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ยี่ห้อ</label>
                                <asp:DropDownList ID="ddlbrandcar2" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">สีรถ</label>
                                <asp:TextBox ID="txtColorcar2" runat="server" Font-Size="Large" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เลขทะเบียน</label>
                                <asp:TextBox ID="txtnocar2" runat="server" Font-Size="Large" CssClass="form-control time" />
                            </div>
                        </div>
                    </div>
                    <div class="row" style="height: 90px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">จังหวัด</label>
                                <asp:TextBox ID="txtprovince2" runat="server" Font-Size="Large" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เลขทะเบียนส่วนพ่วง</label>
                                <asp:TextBox ID="txtnocombind" runat="server" Font-Size="Large" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">จังหวัดส่วนพ่วง</label>
                                <asp:TextBox ID="txtprovince2222" runat="server" Font-Size="Large" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เลขทะเบียนอังกฤษ(ถ้ามี)</label>
                                <asp:TextBox ID="txtEngNo2" runat="server" Font-Size="Large" CssClass="form-control time" />
                            </div>
                        </div>
                    </div>
                    <div class="row" style="height: 90px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">จังหวัดอังกฤษ(ถ้ามี)</label>
                                <asp:TextBox ID="txtEngProvince2" runat="server" Font-Size="Large" CssClass="form-control " />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ขับขี่โดย</label>
                                <asp:TextBox ID="txtDriver2" runat="server" Font-Size="Large" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เลขบัตรประชาชน(ใส่แต่เลข)</label>
                                <asp:TextBox ID="txtIDcar2" runat="server" Font-Size="Large" TextMode="Number" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เบอร์โทร</label>
                                <asp:TextBox ID="txtTelcar2" runat="server" Font-Size="Large" CssClass="form-control time" />
                            </div>
                        </div>
                    </div>
                    <div class="row" style="height: 90px">
                        <div class="col-md-5">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ที่อยู่</label>
                                <asp:TextBox ID="txtAddress2" runat="server" TextMode="MultiLine" Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="lbtnDeletecar2" runat="server" CssClass="btn btn-danger btn-sm far-fa-save" Font-Size="Large" OnCommand="lbtnDeletecar2_Command" OnClientClick="return CompareConfirm('ยืนยันลบข้อมูล ใช่หรือไม่');">ลบข้อมูล</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEditcar2" runat="server" Visible="false" CssClass="btn btn-warning btn-sm far-fa-save" Font-Size="Large" OnCommand="lbtnEditcar2_Command" OnClientClick="return CompareConfirm('ยืนยันแก้ไขข้อมูล ใช่หรือไม่');">บันทึก</asp:LinkButton>
                    <asp:LinkButton ID="lbtnsubmitcar2" runat="server" CssClass="btn btn-success btn-sm far-fa-save" Font-Size="Large" OnCommand="lbtnsubmitcar2_Command" OnClientClick="return CompareConfirm('ยืนยันบันทึกข้อมูล ใช่หรือไม่');">บันทึก</asp:LinkButton>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" style="font-size: medium">Close</button>
                </div>
            </div>
        </div>
    </div>
    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript">   
        $(function () {
            //datepicker
        <% if (alert != "")
        { %>
            demo.showNotification('top', 'center', '<%=icon%>','<%=alertType%>', '<%=alert%>');
        <% } %>


            $(".datepicker").datepicker($.datepicker.regional["th"]);
            if ($(".datepicker").val() == "") {
                $(".datepicker").datepicker("setDate", new Date());
            }

            $(".datepicker").attr('maxlength', '10');
        });

    </script>

    <script type="text/javascript">
        $(function () {
                //
                <%
        if (Session["View"].Equals(true))
        {
                %>
            $('.tab-content input').attr('disabled', 'true');
            $('.tab-content select').attr('disabled', 'true');
            $('.tab-content textarea').attr('disabled', 'true');
            $('.tab-content a').removeAttr('href');
            $('.tab-content a').removeAttr('onclick');
            $('.tab-content a').attr('disabled', 'true');
            $('.tab-content a').hide();
            //$('.combobox').attr('disabled', 'true');
            $('.tab-content input[type=submit]').hide();
            $('.formHead').hide();
                <%
        }
            %>
        });
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
    </script>
    <script type="text/javascript"> 

        $(function () {
            <% if (Car2 != "")
        {%>
            $("#AddSecondModal").modal('show');
            <%}
        else
        {%>
            $("#AddSecondModal").modal('hide');
            <%}%>

        });

        function Radio_Click() {
            var radio1 = document.getElementById("<%=RadioButton1.ClientID %>");
            var textBox = document.getElementById("<%=txtInsurer.ClientID %>");
            if (!radio1.checked) {
                textBox.value = '';
                textBox.disabled = true;
            } else {
                textBox.disabled = false;
                textBox.focus();
            }
        }
    </script>
</asp:Content>
