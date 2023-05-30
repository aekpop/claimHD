<%@ Page Title="รายละเอียดอุบัติเหตุ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TechnoFormDetail.aspx.cs" Inherits="ClaimProject.Techno.TechnoFormDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- CSS only -->
    <link href="../Content/CM.css" rel="stylesheet" />

    <style>
        #ddlCom {
            display: none;
        }

        .btn:disabled {
            background-color: #c3c3c9;
        }

        .row {
            margin-top: 0.4rem;
        }
    </style>
    <!-- CSS Custom -->
    <link href="../Content/custom-control-file.css" rel="stylesheet" />

    <!-- content  -->
    <div class="card border-dark mb-3" style="font-size: 21px; font-family: 'TH SarabunPSK'">
        <div class="card-header">
            <h3 class="card-title">รายละเอียดอุบัติเหตุ</h3>
        </div>
        <div class="card-body table-responsive">
            <div class="row">
                <div class="col-md-2 text-right">สถานะ : </div>
                <div class="col-md">
                    <h3>
                        <asp:Label ID="lbTitleStatus" runat="server" Text="Label"></asp:Label></h3>
                </div>
                <div class="col-md-2 text-right">เลขควบคุม : </div>
                <div class="col-md">
                    <h3>
                        <asp:Label ID="lbRefnum" runat="server" Text="Label" CssClass="text-danger"></asp:Label></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">เรื่อง : </div>
                <div class="col-md">
                    <asp:Label ID="lbTitle" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">ด่านฯ : </div>
                <div class="col-md-2">
                    <asp:Label ID="lbCpoint" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-1 text-right">วันที่ : </div>
                <div class="col-md-3">
                    <asp:Label ID="lbDate" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lbAround" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">ได้รับแจ้งจาก : </div>
                <div class="col-md">
                    <asp:Label ID="lbAlert" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">เกิดอุบัติเหตุตู้ : </div>
                <div class="col-md">
                    <asp:Label ID="lbCb" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">รายละเอียด : </div>
                <div class="col-md">
                    <asp:Label ID="lbDetail" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2 text-right">คู่กรณี : </div>
                <div class="col-md-3">
                    <asp:Label ID="lbCar" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2 text-right">หมายเลขทะเบียน : </div>
                <div class="col-md">
                    <asp:Label ID="lbLP" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">ชื่อผู้ขับขี่ : </div>
                <div class="col-md-3">
                    <asp:Label ID="lbDriver" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2 text-right">หมายเลขบัตรประชาชน : </div>
                <div class="col-md">
                    <asp:Label ID="lbIDCard" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">ที่อยู่ : </div>
                <div class="col-md">
                    <asp:Label ID="lbAddress" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">เบอร์โทรศัพท์ : </div>
                <div class="col-md-3">
                    <asp:Label ID="lbTel" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2 text-right">ทำประกันไว้กับ : </div>
                <div class="col-md">
                    <asp:Label ID="lbInsure" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">หมายเลขเคลม : </div>
                <div class="col-md-3">
                    <asp:Label ID="lbClaimNum" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2 text-right">หมายเลขกรมธรรม์ : </div>
                <div class="col-md">
                    <asp:Label ID="lbPolicy" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">แจ้งความไว้ที่ : </div>
                <div class="col-md-3">
                    <asp:Label ID="lbInform" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-3 text-right">รายการอุปกรณ์ที่ได้รับความเสียหาย : </div>
                <div class="col-md">
                    <asp:Label ID="lbDevice" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-3 text-right">ผู้ควบคุม : </div>
                <div class="col-md">
                    <asp:Label ID="lbEmp" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 text-right">เจ้าหน้าที่คอม : </div>
                <div class="col-md">
                    <asp:Label ID="lbEmpCom" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div runat="server" id="Div2">
        <div class="card border-dark mb-3" style="font-size: 21px; font-family: 'TH SarabunPSK'">
            <div class="card-header">
                <div class="col-md">
                    <h3 class="card-title">ออกหนังสือส่งกองฯ</h3>
                </div>
            </div>
            <div class="card-body table-responsive">

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-3 text-right">เลขที่หนังสือ : </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtNoteNumTo" runat="server" CssClass="form-control " onkeypress="return handleEnter(this, event)"></asp:TextBox>
                            </div>
                            <div class="col-md-3 text-right">วันที่ : </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtDateNoteto" runat="server" AutoPostBack="true" CssClass="form-control datepicker" OnTextChanged="txtDateNoteto_TextChanged" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-md-3 text-right ">เรื่อง : </div>
                    <div class="col-md">
                        <asp:TextBox ID="txtNoteTitleTo" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 text-right">เรียน : </div>
                    <div class="col-md">
                        <asp:TextBox ID="txtNoteSendTo" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md">
                        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md text-center">
                        <asp:Button ID="btnSaveNoteTo" CssClass="btn btn-success btn-sm" Font-Size="20px" runat="server" Text="บันทึก" OnClick="btnSaveNoteTo_Click" OnClientClick="return CompareConfirm('ยืนยันบันทึก ใช่หรือไม่');" />
                        <asp:Button ID="btnNoteTo" CssClass="btn btn-info btn-sm" Font-Size="20px" runat="server" Text="พิมพ์ตัวจริง" OnClick="btnNoteTo_Click" />
                        <asp:Button ID="btnNoteToCpoy" CssClass="btn btn-default btn-sm" Font-Size="20px" runat="server" Text="พิมพ์สำเนา" OnClick="btnNoteToCpoy_Click" />
                    </div>

                </div>
                <hr />
                <div class="row">
                    <div class="col-md">
                        <h3>อัพโหลดใบปะหน้า (ที่เสนอเซ็นเรียบร้อยแล้ว)</h3>
                    </div>
                </div>
                <div class="row" runat="server" id="divFileUploalNote">
                    <div class="col-md-12 col-xl-6">
                        <div class="form-row formHead">
                            <div class="input-group mb-3">
                                <asp:FileUpload ID="FileUploalNote" runat="server" CssClass="form-control-file"></asp:FileUpload>
                                <div class="input-group-append">
                                    <asp:Button ID="btnUploadNote" runat="server" Text="Upload" CssClass="btn btn-outline-secondary" OnClick="btnUploadNote_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-5">
                        <asp:GridView ID="FileNoteGridView" runat="server"
                            DataKeyNames="claim_img_id"
                            GridLines="both"
                            BorderColor="White"
                            OnRowDataBound="FileNoteGridView_RowDataBound"
                            AutoGenerateColumns="False"
                            CssClass="table table-hover table-sm"
                            OnRowDeleting="FileNoteGridView_RowDeleting" HeaderStyle-Font-Bold="true" RowStyle-CssClass="table-success">
                            <Columns>
                                <asp:TemplateField HeaderText="ใบปะหน้า">
                                    <ItemTemplate>
                                        <asp:Image ID="ImgNote" runat="server" Width="200px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Download">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDownload" runat="server" Font-Size="Small" CssClass="fa" OnCommand="btnDownload_Command">&#xf0ed; Download</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" DeleteText="&#xf014; " ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Medium" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md text-center">
                <asp:Label ID="check49" runat="server" Visible="false" Text="Label"></asp:Label>

            </div>
        </div>

        <div runat="server" id="Div1">
            <div class="card border-dark mb-3" style="font-size: 21px; font-family: 'TH SarabunPSK'">
                <div class="card-header">
                    <div class="col-md-2">
                        <h3 class="card-title">รายการใบเสนอราคา</h3>
                    </div>
                </div>
                <div class="card-body table-responsive">
                    <div class="row">
                        <div class="col-md">
                            <asp:GridView ID="QuotaGridView" runat="server"
                                DataKeyNames="quotations_id"
                                GridLines="None"
                                OnRowDataBound="QuotaGridView_RowDataBound"
                                AutoGenerateColumns="False"
                                CssClass="table table-bordered table-sm"
                                HeaderStyle-Font-Bold="true"
                                HeaderStyle-HorizontalAlign="Center"
                                RowStyle-HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="ที่มา">
                                        <ItemTemplate>
                                            <asp:Label ID="lbRefer" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ชื่อบริษัท">
                                        <ItemTemplate>
                                            <asp:Label ID="lbCompany" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.company_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เลขที่หนังสือ">
                                        <ItemTemplate>
                                            <asp:Label ID="lbNote" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.quotations_note_number") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="วันที่ออกหนังสือ">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDateSend" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.quotations_date_send") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="พิมพ์หนังสือ">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnPrint" CssClass="text-info fa" runat="server" Font-Size="Larger" OnCommand="btnPrint_Command" ToolTip="ตัวจริง">&#xf02f;</asp:LinkButton>
                                            <asp:LinkButton ID="btnPrint2" CssClass="text-dark fa" runat="server" Font-Size="Larger" OnCommand="btnPrint2_Command" ToolTip="สำเนา">&#xf02f;</asp:LinkButton>
                                            <asp:LinkButton ID="btnQuatation" CssClass="text-danger fa" runat="server" Font-Size="Larger" OnCommand="btnQuatation_Command" ToolTip="ตารางราคากลาง">&#xf02f;</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ลงรับใบเสนอราคา" ControlStyle-CssClass="text-center text-warning fa">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" Font-Size="Larger" OnCommand="btnEdit_Command">&#xf044;</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ราคา">
                                        <ItemTemplate>
                                            <asp:Label ID="lbPrice" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.quotations_company_price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="วันที่ได้รับใบเสนอราคา">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDateRecive" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.quotations_date_recive") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เอกสารแนบ">
                                        <ItemTemplate>
                                            <asp:Image ID="DocClaim" runat="server" Width="100px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDocDownload" runat="server" Font-Size="Larger" CssClass="fa" OnCommand="btnDocDownload_Command">&#xf0ed;</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="col-12">
                    <div class="card-footer">
                        <asp:Button ID="BtnIncreate" runat="server" CssClass="btn btn-outline-info" OnClick="BtnIncreate_Click" Text="เพิ่ม" />
                    </div>
                </div>
            </div>

            <div id="estimate" runat="server">
                <div class="card border-dark mb-3" style="font-size: 21px; font-family: 'TH SarabunPSK'">
                    <div class="card-header">
                        <div class="col-md-2">
                            <h3 class="card-title">ประเมินราคา</h3>
                        </div>
                    </div>
                    <div class="card-body table-responsive">
                        <div class="row">
                            <div class="col-md-6">
                                <h3>ข้อมูลส่งประเมิน (นิติกร)</h3>
                            </div>
                            <div class="col-md-6">
                                <h3>แต่งตั้งคณะกรรมการประเมินค่าเสียหาย</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-2">
                                วันที่ส่ง : 
                        <asp:Label ID="lbestimatedays" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="col-2">
                                เลขที่ : 
                        <asp:Label ID="lbestimateNum" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="col-md-2">
                                <asp:LinkButton ID="lbtnEditEstimate" runat="server" CssClass="btn btn-outline-warning" OnCommand="lbtnEditEstimate_Command">แก้ไขข้อมูล</asp:LinkButton>
                            </div>

                            <div class="col-2">
                                วันที่ส่ง : 
                        <asp:Label ID="lbAppointDate" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="col-2">
                                เลขที่ : 
                        <asp:Label ID="lbAppointNum" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-2">
                                <asp:LinkButton ID="lbtnAddAppoint" runat="server" CssClass="btn btn-outline-warning" OnCommand="lbtnAddAppoint_Command">เพิ่ม / แก้ไข</asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:GridView ID="GridViewEstimate" runat="server"
                                    DataKeyNames="claim_img_id"
                                    GridLines="both"
                                    BorderColor="White"
                                    OnRowDataBound="GridViewEstimate_RowDataBound"
                                    AutoGenerateColumns="False"
                                    CssClass="table table-hover table-sm"
                                    OnRowDeleting="GridViewEstimate_RowDeleting" HeaderStyle-Font-Bold="true" RowStyle-CssClass="table-success">
                                    <Columns>
                                        <asp:TemplateField HeaderText="เอกสารประกอบ">
                                            <ItemTemplate>
                                                <asp:Image ID="ImgEstimate" runat="server" Width="200px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Download">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDownload" runat="server" Font-Size="Small" CssClass="fa" OnCommand="btnDownload_Command">&#xf0ed; Download</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" DeleteText="&#xf014; " ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Medium" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="col-md-6">
                                <asp:GridView ID="GridViewAppoint" runat="server"
                                    DataKeyNames="claim_img_id"
                                    GridLines="both"
                                    BorderColor="White"
                                    OnRowDataBound="GridViewAppoint_RowDataBound"
                                    AutoGenerateColumns="False"
                                    CssClass="table table-hover table-sm"
                                    OnRowDeleting="GridViewAppoint_RowDeleting" HeaderStyle-Font-Bold="true" RowStyle-CssClass="table-success">
                                    <Columns>
                                        <asp:TemplateField HeaderText="เอกสารประกอบ">
                                            <ItemTemplate>
                                                <asp:Image ID="ImgAppoint" runat="server" Width="200px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Download">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDownload" runat="server" Font-Size="Small" CssClass="fa" OnCommand="btnDownload_Command">&#xf0ed; Download</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" DeleteText="&#xf014; " ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Medium" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div runat="server" id="Div3">
        <div class="card border-dark mb-3" style="font-size: 21px; font-family: 'TH SarabunPSK'">
            <div class="card-header">
                <div class="col-md">
                    <h2 class="card-title">ส่งงาน/เสร็จสิ้น</h2>
                </div>
            </div>
            <div class="card-body table-responsive">
                <div class="row">
                    <div class="col-6">
                        <div class="row">
                            <div class="col-md">
                                <h3>ข้อมูลใบสั่งจ้าง</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right">
                                ชื่อบริษัท/อ้างอิงอื่นๆ : 
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lbCompanyOrder" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3 text-right">
                                วันที่สั่งจ้าง : 
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lbDateOrderStart" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right">
                                ราคาจ้าง : 
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lbPriceOrder" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3 text-right">
                                กำหนดแล้วเสร็จภายใน : 
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lbDateOrderEnd" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-3 text-right">
                                อัพโหลดใบสั่งจ้างใหม่
                            </div>
                            <div class="col-md-6">
                                <asp:FileUpload ID="FileEditEQ" runat="server" CssClass="custom-file" lang="en" />
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="lbtnchangeimg" runat="server" CssClass="btn btn-secondary" OnCommand="lbtnchangeimg_Command" Text="UPLOAD"></asp:LinkButton>
                            </div>
                        </div>
                        <br />
                        <div class="col">
                            <asp:GridView ID="gridquatation" runat="server" GridLines="Both"
                                DataKeyNames="quotations_id" AutoGenerateColumns="False"
                                CssClass="table table-hover table-sm"
                                HeaderStyle-Font-Bold="true"
                                BorderColor="White"
                                OnRowDataBound="gridquatation_RowDataBound" OnRowDeleting="gridquatation_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="ใบสั่งจ้าง">
                                        <ItemTemplate>
                                            <asp:Image ID="imgqua" runat="server" Width="200px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnload" runat="server" Font-Size="Larger" CssClass="fa" OnCommand="lbtnload_Command">&#xf0ed;</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Small" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="col-6">
                        <div runat="server" id="Div4">
                            <div class="row">
                                <div class="col-md">
                                    <h3>ข้อมูลใบส่งงาน</h3>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    วันที่ส่งงาน : 
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="lbDateSendOrder" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    ค่าปรับ : 
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="lbFineOrder" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    อัพโหลดใบส่งงานใหม่
                                </div>
                                <div class="col-md-6">
                                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="custom-file" lang="en" />
                                </div>
                                <div class="col-md-3">
                                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-secondary" OnCommand="lbtnchangefinalimg_Command" Text="UPLOAD"></asp:LinkButton>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md">
                                    <asp:Image ID="ImageOrderSend" runat="server" Width="300px" />
                                    <asp:LinkButton ID="btnDownloadOrderSend" Visible="false" CssClass="btn btn-outline-info btn-sm" Font-Size="15px" runat="server" OnClick="btnDownloadOrderSend_Click">ดาวน์โหลด</asp:LinkButton>
                                </div>
                            </div>
                            <div class="col">
                                <asp:GridView ID="gridFinal" runat="server" GridLines="Both"
                                    DataKeyNames="quotations_id" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-sm"
                                    HeaderStyle-Font-Bold="true"
                                    BorderColor="White"
                                    OnRowDataBound="gridFinal_RowDataBound" OnRowDeleting="gridFinal_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ใบส่งงาน">
                                            <ItemTemplate>
                                                <asp:Image ID="imgfinal" runat="server" Width="200px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Download">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnloadfinal" runat="server" Font-Size="Larger" CssClass="fa" OnCommand="lbtnloadfinal_Command">&#xf0ed;</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Small" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="card border-dark mb-3" style="font-family: 'TH SarabunPSK'; font-size: 16px;">
        <div class="card-header">
            <div class="col-md">
                <h3 class="card-title">อัพโหลดเอกสารอื่นๆ เพิ่มเติม</h3>
            </div>
        </div>
        <div class="card-body table-responsive">
            <div class="row" runat="server" id="divUploadetc">
                <div class="col-md-12 col-xl-6">
                    <div class="form-row formHead">
                        <div class="input-group mb-3">
                            <asp:FileUpload ID="FileUploadetc" runat="server" CssClass="form-control-file"></asp:FileUpload>
                            <div class="input-group-append">
                                <asp:Button ID="btnUploadetc" runat="server" Text="Upload" CssClass="btn btn-outline-secondary" OnClick="btnUploadetc_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-5">
                    <asp:GridView ID="GridViewEtc" runat="server"
                        DataKeyNames="claim_img_id"
                        GridLines="both"
                        BorderColor="White"
                        OnRowDataBound="GridViewEtc_RowDataBound"
                        AutoGenerateColumns="False"
                        CssClass="table table-hover table-sm"
                        OnRowDeleting="GridViewEtc_RowDeleting" HeaderStyle-Font-Bold="true" RowStyle-CssClass="table-success">
                        <Columns>
                            <asp:TemplateField HeaderText="เอกสารอื่นๆ">
                                <ItemTemplate>
                                    <asp:Image ID="ImgEtc" runat="server" Width="200px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDownload" runat="server" Font-Size="xx-large" CssClass="fa text-center" OnCommand="btnDownload_Command">&#xf0ed; Download</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" HeaderText="" DeleteText="&#xf014; " ControlStyle-CssClass="fa text-danger " ControlStyle-Font-Size="xx-large" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


    <div class="card border-dark mb-3" style="font-family: 'TH SarabunPSK'; font-size: 16px;">
        <div class="card-header">
            <div class="col-md">
                <h3 class="card-title">สถานะดำเนินการ</h3>
            </div>
        </div>
        <div class="card-body table-responsive">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row text-center">
                        <div class="col-md-2">
                            <asp:Button ID="btns0" runat="server" CssClass="btn btn-danger custom" OnClick="btns0_Click" Text="ลบข้อมูล" OnClientClick="return CompareConfirm('ยืนยัน คุณต้องการลบข้อมูล ใช่หรือไม่')" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btns1" runat="server" CssClass="btn btn-dark custom" Text="รายงานกองฯ" OnClick="btns2_Click" OnClientClick="return CompareConfirm('ยืนยันเปลี่ยนสถานะส่งเรื่องเข้ากองฯ ?');" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btns2" runat="server" CssClass="btn btn-warning custom" OnClick="btns1_Click" Text="ใบเสนอราคา" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btns3" runat="server" CssClass="btn btn-primary custom" Text="ส่งประเมินราคา" OnClick="btns3_Click" OnClientClick="return CompareConfirm('ยืนยัน ส่งประเมินราคา ?');" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn3_1" runat="server" CssClass="btn btn-info custom" Text="สั่งจ้าง" OnClick="btn3_1_Click" OnClientClick="return CompareConfirm('ยืนยัน สั่งจ้าง ?');" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btns4" runat="server" CssClass="btn btn-success custom" Text="ส่งงาน/เสร็จสิ้น" OnClick="btns4_Click" OnClientClick="return CompareConfirm('ยืนยันเปลี่ยนส่งงาน/เสร็จสิ้น ?');" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btns0" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <!-- End content  -->
    <!-- Start ขอใบเสนอราคา -->
    <div class="modal" id="QuotationsModel">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ใบเสนอราคา</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md">
                            <asp:DropDownList ID="ddlSelectQua" runat="server" name="form_select" onchange="showDiv('ddlCom', this)" class="btn btn-warning dropdown-toggle dropdown-toggle-split">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <asp:UpdatePanel runat="server" ID="SelectQua1">
                        <ContentTemplate>
                            <div id="ddlCom">
                                <div class="row">
                                    <div class="col-md-3 text-right">ชื่อบริษัท : </div>
                                    <div class="col-md">
                                        <asp:DropDownList ID="txtCompany" runat="server" CssClass="form-control custom-control col-md-6"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row" id="ddlDevi">
                                <div class="col-md-3 text-right">ชื่ออุปกรณ์ : </div>
                                <div class="col-md">
                                    <asp:DropDownList ID="ddlDevice" runat="server" CssClass="form-control custom-control col-md-6"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-3 text-right">เลขที่หนังสือ : </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtNoteNumber" runat="server" CssClass="form-control " onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                </div>

                                <div class="col-md-3 text-right">วันที่ : </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtDateQuotations" runat="server" CssClass="form-control datepicker " onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md text-center">
                                    <asp:Button ID="btnSaveQuotations" runat="server" CssClass="btn btn-success btn-sm text-lg-center" Text="ตกลง" Font-Size="Larger" OnClick="btnSaveQuotations_Click" />
                                </div>
                            </div>
                            </div>
                            <hr />
                            <asp:GridView ID="QuotationsGridView" runat="server"
                                DataKeyNames="quotations_id"
                                GridLines="None"
                                AutoGenerateColumns="False"
                                CssClass="table table-hover table-sm"
                                OnRowDataBound="QuotationsGridView_RowDataBound"
                                OnRowEditing="QuotationsGridView_RowEditing"
                                OnRowCancelingEdit="QuotationsGridView_RowCancelingEdit"
                                OnRowUpdating="QuotationsGridView_RowUpdating"
                                OnRowDeleting="QuotationsGridView_RowDeleting"
                                HeaderStyle-Font-Bold="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="ชื่อบริษัท/สัญญา" ControlStyle-Width="230px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbCompany" runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().ShortText(DataBinder.Eval(Container, "DataItem.company_name")+" / "+DataBinder.Eval(Container, "DataItem.device_ref_Project")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เลขที่หนังสือ">
                                        <ItemTemplate>
                                            <asp:Label ID="lbNote" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.quotations_note_number") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtENote" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.quotations_note_number") %>' CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ราคา">
                                        <ItemTemplate>
                                            <asp:Label ID="lbPriceQ" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.quotations_company_price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:CommandField ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="fa" ControlStyle-Font-Size="Small" />
                                   
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnSaveQuotations" />
                            <asp:PostBackTrigger ControlID="btns2" />
                            <asp:PostBackTrigger ControlID="btns3" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!-- End ขอใบเสนอราคา -->
    <!-- Start ลงรับใบเสนอราคา -->
    <div class="modal" id="ReciveQuotationsModel">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ลงรับใบเสนอราคา</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4 text-right">บริษัท : </div>
                        <div class="col-md">
                            <asp:Label ID="lbCompany" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4 text-right">วันที่รับใบเสนอราคา : </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDateRecive" runat="server" CssClass="form-control datepicker" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4 text-right">ราคาที่บริษัทเสนอ : </div>
                        <div class="col-md">
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4 text-right">แนบรูปภาพ : </div>
                        <div class="col-md">
                            <div class="custom-file">
                                <label class="custom-file-label" for="customFile">เลือกไฟล์</label>
                                <asp:FileUpload ID="fileDoc" runat="server" CssClass="custom-file-input" lang="en" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md text-center">
                            <asp:Button ID="btnSaveRecive" runat="server" Font-Size="20px" CssClass="btn btn-warning btn-sm" Text="ส่งเสนอราคา" OnClick="btnSaveRecive_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End ลงรับใบเสนอราคา -->
    <!-- Start New ส่งประเมินราคา นิติกร -->
    <div class="modal" id="estimateQuotationsModel">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ข้อมูลการส่งประเมิน(นิติกร)</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md">
                            <asp:DropDownList ID="ddlestimate" runat="server" name="form_select" onchange="showDiv('formestimate', this)" class="btn btn-warning dropdown-toggle dropdown-toggle-split">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-3 text-right">วันที่ส่ง : </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtestimateDay" runat="server" CssClass="datepicker form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">เลขที่ : </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtestimateNum" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                </div>
                            </div>
                            <div id="formestimate">
                                <div class="row">
                                    <div class="col-md-3 text-right">บันทึกข้อความ : </div>
                                    <div class="col-md-8">
                                        <div class="custom-file">
                                            <label class="custom-file-label" for="customFile">เลือกไฟล์</label>
                                            <asp:FileUpload ID="FileUploadstimate1" runat="server" CssClass="custom-file-input" lang="en" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">บก.06 : </div>
                                    <div class="col-md-8">
                                        <div class="custom-file">
                                            <label class="custom-file-label" for="customFile">เลือกไฟล์</label>
                                            <asp:FileUpload ID="FileUploadstimate2" runat="server" CssClass="custom-file-input" lang="en" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">ตารางราคา : </div>
                                    <div class="col-md-8">
                                        <div class="custom-file">
                                            <label class="custom-file-label" for="customFile">เลือกไฟล์</label>
                                            <asp:FileUpload ID="FileUploadstimate3" runat="server" CssClass="custom-file-input" lang="en" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-md text-center">
                            <asp:Button ID="btnEstimate" runat="server" Font-Size="16px" CssClass="btn btn-warning btn-sm" Text="ตกลง" OnClick="btnEstimate_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End New ส่งประเมินราคา นิติกร -->
    <!-- Start อยู่ระหว่างซ่อม -->
    <div class="modal" id="WaitQuotationsModel">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ข้อมูลใบสั่งจ้าง</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-3 text-right">บริษัท : </div>
                                <div class="col-md">
                                    <asp:DropDownList ID="txtCompanyOrder" AutoPostBack="true" runat="server" CssClass="form-control custom-control" OnSelectedIndexChanged="txtCompanyOrder_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-3 text-right">ราคาจ้าง : </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtPriceOrder" runat="server" CssClass="form-control text-center" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label3" runat="server" Text=" บาท"></asp:Label>
                                </div>
                            </div>
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-md-3 text-right">วันที่จ้าง : </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDateOrder" runat="server" CssClass="datepicker form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4 text-right">กำหนดส่งงานภายใน : </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtSendOrder" runat="server" CssClass="form-control" onkeypress="return isNumber(event)"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label1" runat="server" Text=" วัน"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 text-right">แนบรูปภาพ : </div>
                        <div class="col-md-5">
                            <div class="custom-file">
                                <label class="custom-file-label" for="customFile">เลือกไฟล์</label>
                                <asp:FileUpload ID="FileOrder" runat="server" CssClass="custom-file-input" lang="en" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md text-center">
                            <asp:Button ID="btnSaveOrder" runat="server" Font-Size="20px" CssClass="btn btn-warning btn-sm" Text="บันทึก" OnClick="btnSaveOrder_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End อยู่ระหว่างซ่อม -->
    <!-- Start ส่งงานเสร็จสิ้น -->
    <div class="modal" id="SuccessQuotationsModel">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ส่งงาน/เสร็จสิ้น</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-4 text-right">วันที่ส่งงาน : </div>
                                <div class="col-md-3">
                                    <!--<asp:TextBox ID="TextBox1" AutoPostBack="true" runat="server" CssClass="form-control datepicker" OnTextChanged="txtDateSendOrder_TextChanged"></asp:TextBox> -->
                                    <asp:TextBox ID="txtDateSendOrder" AutoPostBack="true" runat="server" CssClass="form-control datepicker" OnTextChanged="txtDateSendOrder_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" runat="server" id="DivFine">
                                <div class="col-md-4 text-right">ค่าปรับ : </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtFine" runat="server" CssClass="form-control" OnTextChanged="txtDateSendOrder_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="Label2" runat="server" Text=" บาท"></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-md-4 text-right">แนบรูปภาพ : </div>
                        <div class="col-md">
                            <div class="custom-file">
                                <label class="custom-file-label" for="customFile">เลือกไฟล์</label>
                                <asp:FileUpload ID="FileUploadSendDoc" runat="server" CssClass="custom-file-input" lang="en" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md text-center">
                            <asp:Button ID="btnSaveSendDoc" runat="server" Font-Size="20px" CssClass="btn btn-warning btn-sm" Text="เสร็จสิ้น" OnClick="btnSaveSendDoc_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End ส่งงานเสร็จสิ้น -->
    <!-- Start พิมพ์ตารางราคากลาง -->
    <div class="modal" id="tableQuotationsModel">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ตารางราคากลาง
                    </h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-3 text-right">ช่องทางที่ : </div>
                        <div class="col-md">
                            <asp:TextBox ID="txtProject" runat="server" CssClass="form-control col-md" ToolTip="EX01 (บางพลีมุ่งหน้าบางปะอิน) ด่านฯ ทับช้าง 1"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 text-right">ประธานกรรมการ : </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPerson1" runat="server" CssClass="form-control col-md"></asp:TextBox>
                        </div>
                        <div class="col-md-2 text-right">ตำแหน่ง : </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlPosition1" runat="server" CssClass="form-control col-md"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 text-right">กรรมการ : </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPerson2" runat="server" CssClass="form-control col-md"></asp:TextBox>
                        </div>
                        <div class="col-md-2 text-right">ตำแหน่ง : </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlPosition2" runat="server" CssClass="form-control col-md"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 text-right">กรรมการและเลขานุการ : </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPerson3" runat="server" CssClass="form-control col-md"></asp:TextBox>
                        </div>
                        <div class="col-md-2 text-right">ตำแหน่ง : </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlPosition3" runat="server" CssClass="form-control col-md"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md text-center">
                            <asp:Button ID="btnTblQuan" runat="server" CssClass="btn btn-warning btn-md" Text="ตารางราคากลาง" OnCommand="btnTblQuan_Command" />
                        </div>
                        <div class="col-md text-center">
                            <asp:Button ID="btnShowCost" runat="server" CssClass="btn btn-info btn-md" Text="ตารางแสดงวงเงิน" OnCommand="btnShowCost_Command" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End พิมพ์ตารางราคากลาง -->
    <!-- appoint -->
    <div class="modal" id="appointsModel">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">แต่งตั้งคณะกรรมการประเมินค่าเสียหาย</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-3 text-right">วันที่ : </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtappointdate" runat="server" CssClass="datepicker form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3 text-right">เลขที่ : </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtappointNum" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3 text-right">บันทึก : </div>
                        <div class="col-md-8">
                            <div class="custom-file">
                                <div class="custom-file">
                                    <label class="custom-file-label" for="customFile">เลือกไฟล์</label>
                                    <asp:FileUpload ID="FileUploadappoint" runat="server" CssClass="custom-file-input" lang="en" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md text-center">
                            <asp:Button ID="btnappoint" runat="server" Font-Size="16px" CssClass="btn btn-warning btn-sm" Text="บันทึก" OnClick="btnappoint_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" id="alertModel">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12 text-danger text-xl-center">
                            <i class="fa fa-times fa-10x" aria-hidden="true" style="font-size: xx-large;"></i>
                        </div>
                    </div>
                    <br />
                    <div class="col-12 text-danger">
                        ตรวจสอบบันทึกการประเมินราคา / คำสั่งแต่งตั้งคณะกรรมการอีกครั้ง                       
                    </div>
                </div>
            </div>
        </div>
    </div>

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

        function showDiv(divId, element) {
            {
                document.getElementById(divId).style.display = element.value == 1 ? 'block' : 'none';
            }
        }

        $(".custom-file-input").on("change", function () {
            var fileName = $(this).val().split("\\").pop();
            $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        });

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }       

    </script>
</asp:Content>
