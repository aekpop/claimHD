<%@ Page Title="รายการ CM" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMDetailForm.aspx.cs" Inherits="ClaimProject.CM.CMDetailForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <div class="container-fluid">
   
        <div class="card" style="z-index: 0; font-size:medium; ">
            <div class="card-header card-header-warning">
                <h3 class="card-title">แจ้งซ่อมอุปกรณ์</h3>
            </div>
            <div class="card-body table-responsive table-sm">
                <asp:HiddenField ID="txtRef" runat="server" />
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">ด่านฯ :</p>
                            <asp:DropDownList ID="txtCpoint" runat="server" CssClass="form-control custom-select"></asp:DropDownList>
                        </div>
                    </div>
                   <div class="col-md-2">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating ">อาคารย่อย :</p>
                                <asp:TextBox ID="txtPoint" runat="server" CssClass="form-control" placeholder="อาคารย่อย" MaxLength="1"/>
                            </div>
                    </div>
                
                    <div class="col-md-2">
                        <div class="form-group bmd-form-group ">
                            <p class="bmd-label-floating ">วันที่ :</p>
                            <asp:TextBox ID="txtSDate" runat="server" CssClass="form-control datepicker" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group bmd-form-group ">
                            <p class="bmd-label-floating ">เวลา :</p>
                            <asp:TextBox ID="txtSTime" runat="server" CssClass="form-control time" />
                        </div>
                    </div>
                                    
                    <div class="col-md-3">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating ">ช่องทาง</p>
                            <asp:DropDownList ID="ddlChanel" Width="90px" runat="server" CssClass="form-control" ></asp:DropDownList>
                        </div>
                    </div>    
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">อุปกรณ์</p>
                            <asp:DropDownList ID="txtDeviceAdd" runat="server" CssClass="combobox form-control custom-select" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">ปัญหา/อาการ</p>
                            <asp:TextBox ID="txtProblem" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">หมายเหตุ</p>
                            <asp:TextBox ID="txtNote" runat="server" CssClass="form-control" />
                        </div>
                    </div>  
                    
                    <!-- แนบรูป -->
                    <div class="col-md-3">
                       <div class="form-group bmd-form-group">
                           <p class="bmd-label-floating">แนบรูปภาพ</p>
                           <div class="col" runat="server" id="diveditpic">
                                <asp:FileUpload ID="fileImg" runat="server" CssClass="custom-file" lang="en" />
                            </div>
                         <div class="col-md-3">
                                 <asp:Label ID="pkeq" runat="server" visible="true" Font-Size="Smaller" ></asp:Label>
                          </div>
                        </div>
                     </div>

                <div class="row">
                    <div class="col-md text-center">
                        <asp:LinkButton ID="btnSaveCM" runat="server" Font-Size="20px" CssClass="btn btn-success btn-sm" OnClientClick="return CompareConfirm('ยืนยัน แจ้งซ่อมอุปกรณ์ ใช่หรือไม่');" OnClick="btnSaveCM_Click">แจ้งซ่อม</asp:LinkButton>
                        <asp:LinkButton ID="btnEditCM" runat="server" Font-Size="20px" CssClass="btn btn-warning btn-sm" OnClientClick="return CompareConfirm('ยืนยัน แก้ไขแจ้งซ่อมอุปกรณ์ ใช่หรือไม่');" OnClick="btnEditCM_Click">แก้ไข</asp:LinkButton>
                        <asp:LinkButton ID="btnCancelCM" runat="server" Font-Size="20px" CssClass="btn btn-dark btn-sm" OnClick="btnCancelCM_Click">ยกเลิก</asp:LinkButton>
                        <asp:LinkButton ID="btnDeleteCM" runat="server" Font-Size="20px" CssClass="btn btn-danger btn-sm" OnClientClick="return CompareConfirm('ยืนยัน ลบข้อมูลการแจ้งซ่อมอุปกรณ์ ใช่หรือไม่');" OnClick="btnDeleteCM_Click">ลบ</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <br />
    </div>

    <div id="DivCMGridView" runat="server" class="col-12">
        <div class="card" style="z-index: 0" >
            <div class="card-header card-header-warning">
                <h3 class="card-title">รายการแจ้งซ่อมอุปกรณ์ (รอการแก้ไข)</h3>
            </div>
            <div class="card-body table-responsive table-sm">
                <!--<div class="row">
                    <div class="col-md" >
                        <label ID="lbTollz" class="bmd-label-floating">ด่านฯ : </label>
                        <asp:DropDownList ID="txtCpointSearch" runat="server" CssClass="form-control custom-select" ></asp:DropDownList>
                    </div>
                    <div class="col-md">
                        <label ID="lbBudgetz" class="bmd-label-floating">ปีงบประมาณ : </label>
                        <asp:DropDownList ID="ddlBudgetcc" runat="server" CssClass="form-control custom-select" ></asp:DropDownList>
                    </div>
                    <div class="col-md">
                        <br />
                        <asp:Button ID="btnSearchAddd" runat="server" Text="ค้นหา" Visible="false" CssClass="btn btn-success" OnClick="btnSearchAddd_Click"/>
                    </div>

                    <div class="col-md" >
                        <br />
                        <asp:Button ID="btnToReport" runat="server" Text="ไปยังหน้ารายงาน" Visible="false" CssClass="btn btn-warning" OnClick="btnToReport_Click"/>
                    </div>
                </div>-->
                <br />
                <asp:Panel ID="Panel1" runat="server" >
                    <asp:GridView ID="CMGridView" runat="server"
                        AutoGenerateColumns="False" CssClass="col table table-striped table-hover "
                        HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="ActiveBorder"
                        HeaderStyle-Font-Size="18px"
                        RowStyle-CssClass="text-center"
                        OnRowDataBound="CMGridView_RowDataBound" Font-Size="15px" CellPadding="4" ForeColor="#000033" GridLines="None" PageSize="1">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ" >
                                <ItemTemplate>
                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-center" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="ด่านฯ" >
                                <ItemTemplate>
                                    <asp:Label ID="lbCpoint" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name")+" "+DataBinder.Eval(Container, "DataItem.cm_point") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ช่องทาง" >
                                <ItemTemplate>
                                    <asp:Label ID="lbChannel" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อุปกรณ์" >
                                <ItemTemplate>
                                    <asp:Label ID="lbDeviceName" runat="server"  Text='<%# new ClaimProject.Config.ClaimFunction().ShortText(DataBinder.Eval(Container, "DataItem.device_name").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อาการที่ชำรุด" >
                                <ItemTemplate>
                                    <asp:Label ID="lbProblem" runat="server" CssClass="l" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_problem") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่แจ้งซ่อม" >
                                <ItemTemplate>
                                    <asp:Label ID="lbSDate" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลาแจ้งซ่อม" >
                                <ItemTemplate>
                                    <asp:Label ID="lbSTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_stime")+" น." %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ผู้แจ้ง" ControlStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbcmUser" runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().ShortText(DataBinder.Eval(Container, "DataItem.name").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="แก้ไข" ControlStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditCM" runat="server" CssClass="fas text-warning" OnCommand="btnEdit_Command">&#xf303;</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="White" CssClass="text-left" Font-Bold="True" ForeColor="#000033"  />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" CssClass="text-left" />
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
        
    </script>
</asp:Content>
