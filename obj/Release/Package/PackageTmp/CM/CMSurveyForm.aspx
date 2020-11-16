<%@ Page Title="Maintenance Service Agreement (MA)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMSurveyForm.aspx.cs" Inherits="ClaimProject.CM.CMSurveyForm" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <!-- Menu Dropdown -->        
        <div class="btn-group">
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
        

    <div id="DivCMGridView" runat="server" class="col-12">
        <div class="card" style="z-index: 0">
            <div class="card-header card-header-warning">
                <h3 class="card-title">รายการแก้ไขอุปกรณ์</h3>
            </div>
            <div class="card-body table-responsive table-sm" >
                <asp:Panel ID="Panel1" runat="server" >
                    <asp:GridView ID="CMGridView" runat="server"
                        AutoGenerateColumns="False" 
                        CssClass="col table table-striped table-hover"
                        HeaderStyle-CssClass="text-center" 
                        HeaderStyle-BackColor="ActiveBorder"
                        HeaderStyle-Font-Size="18px"
                        OnRowDataBound="CMGridView_RowDataBound" 
                        Font-Size="15px" 
                        CellPadding="4" 
                        ForeColor="#333333"
                        Font-Names="thsaraban"
                        GridLines="None">

                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Ref." >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbref" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_id") %>' OnCommand="lbref_Command"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ด่านฯ" >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbCpoint" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name")+" "+DataBinder.Eval(Container, "DataItem.cm_point") %>' runat="server" OnCommand="lbref_Command" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ช่องทาง" >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbChannel" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>' OnCommand="lbref_Command"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อุปกรณ์" >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>' OnCommand="lbref_Command"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อาการที่ชำรุด" >
                                <ItemTemplate>
                                    <asp:Label ID="lbProblem" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_problem") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="วันที่แก้ไข" >
                                <ItemTemplate>
                                    <asp:Label ID="btnDateEditCM" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลาที่แก้ไข" >
                                <ItemTemplate>
                                    <asp:Label ID="btnTimeEditCM" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="วิธีแก้ไข" >
                                <ItemTemplate>
                                    <asp:Label ID="lbMethod" runat="server" Width="200px" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_method") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="อนุมัติ" >
                                <ItemTemplate>
                                    <div class="row" >
                                        <asp:LinkButton ID="btnStatusUpdate" runat="server" OnCommand="btnStatusUpdate_Command" OnClientClick="return CompareConfirm('ยืนยันข้อมูลถูกต้อง ใช่หรือไม่');" CssClass="btn btn-outline-success"><i class="fas fa-check"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnCancel" runat="server" OnCommand="btnCancel_Command" OnClientClick="return CompareConfirm('ยืนยันไม่อนุมัติ ใช่หรือไม่');" CssClass="btn btn-outline-danger"><i class="fas fa-times"></i></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="text-left" Font-Bold="True"></HeaderStyle>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle CssClass="text-left" BackColor="#ffffff"></RowStyle>
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

    <!------------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="ApprovCMModal" tabindex="-1" role="dialog" aria-labelledby="ApprovCMModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">ตรวจสอบรายละเอียดการแจ้งซ่อมอุปกรณ์ CM</h5>
                        <asp:Label ID="pkeq" runat="server" visible="false" Font-Size="Smaller" ></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                </div>
                            <div class="container">                              
                                <div class="modal-body " style="line-height: inherit;">
                                    <div class="row" style="height: 380px">
                                        <div class="card border-white col-sm-4">
                                            <asp:Label ID="lbImageStart" runat="server" Text="ภาพก่อนซ่อม"></asp:Label>
                                            <asp:Image ID="ImgEditEQ" runat="server" Height="340px" CssClass="img-thumbnail"/>
                                        </div>
                        
                                        <div class="card border-white col-sm-4">
                                            <asp:Label ID="lbImageEnd" runat="server" Text="ภาพหลังซ่อม"></asp:Label>
                                            <asp:Image ID="ImgEditEQE" runat="server" Height="340px" CssClass="img-thumbnail" />
                                        </div>

                                        <div class="card border-white col-sm-4">
                                            <asp:Label ID="lbImageDocSer" runat="server" Text="ภาพใบ Service"></asp:Label>
                                            <asp:Image ID="ImgImageDocSer" runat="server" Height="340px" CssClass="img-thumbnail" />
                                        </div>
                                    </div>                                 
                    <hr />
                    <!-------------------------------------------------------------->
                    
                            <div class="row" >
                                <div class="col-xl">
                                    <div class="form-group bmd-form-group">       
                                        <span class = "label label-primary">Ref. </span>
                                        <asp:Label ID="lbrefRecheck" Enabled="false"  runat="server"   />
                                    </div>
                                </div>
                                <div class="col-xl">
                                    <div class="form-group bmd-form-group">
                                        <span class = "label label-primary">ด่านฯ : </span>
                                        <asp:Label ID="lbCpointRecheck" Enabled="false" runat="server"   />
                                    </div>
                                </div>
                                <div class="col-xl">
                                    <div class="form-group bmd-form-group">
                                        <span class = "label label-primary">อาคารย่อย : </span>
                                        <asp:Label ID="lbPointRecheck" Enabled="false" runat="server"   />
                                    </div>
                                </div>
                                <div class="col-xl">
                                    <div class="form-group bmd-form-group">
                                        <span class = "label label-primary">ตู้ : </span>
                                        <asp:Label ID="lbChannelRecheck" Enabled="false" runat="server"   />
                                    </div>
                                </div>
                            </div>

                            <div class="row" >
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">       
                                            <span class = "label label-primary">อุปกรณ์ : </span>
                                            <asp:Label ID="lbdeviceRecheck" Enabled="false"  runat="server"   />
                                        </div>
                                    </div>
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">อาการเสีย : </span>
                                            <asp:Label ID="lbProblemRecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                </div>

                            <div class="row" >
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">วิธีแก้ไข : </span>
                                            <asp:Label ID="lbMethodRecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">หมายเหตุ : </span>
                                            <asp:Label ID="lbNodeRecheck" Enabled="false" runat="server"  />
                                        </div>
                                    </div>
                                </div>

                                <div class="row" >
                                    <div class="col-lg">
                                        <div class="form-group bmd-form-group">       
                                            <span class = "label label-primary">วันที่แจ้ง : </span>
                                            <asp:Label ID="lbDatesRecheck" Enabled="false"  runat="server"   />
                                        </div>
                                    </div>
                                    <div class="col-lg">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">เวลา : </span>
                                            <asp:Label ID="lbTimesRecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                    <div class="col-lg">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">วันที่เข้า :</span>
                                            <asp:Label ID="lbDateERecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                    <div class="col-lg">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">เวลา :</span>
                                            <asp:Label ID="lbTimeERecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                </div>

                                <div class="row" >
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">วันที่แก้ไขเสร็จ : </span>
                                            <asp:Label ID="lbDateEJRecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">เวลาแก้ไขเสร็จ : </span>
                                            <asp:Label ID="lbTimeEJRecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-xl">
                                            <div class="form-group bmd-form-group">       
                                                <span class = "label label-primary">ผู้แจ้งซ่อม : </span>
                                                <asp:Label ID="lbUserRecheck" Enabled="false"  runat="server"   />
                                            </div>
                                        </div>
                                        <div class="col-xl">
                                            <div class="form-group bmd-form-group">       
                                                <span class = "label label-primary">ผู้รับรองงานซ่อม : </span>
                                                <asp:Label ID="lbUserEJRecheck" Enabled="false"  runat="server"   />
                                            </div>
                                        </div>       
                                    </div>

                                    <div class="row " >
                                        <asp:LinkButton ID="lbtnStatusUpdateModal" runat="server" OnCommand="lbtnStatusUpdateModal_Command" OnClientClick="return CompareConfirm('ยืนยันข้อมูลถูกต้อง ใช่หรือไม่');" CssClass="fas text-success m-3" ToolTip="ยินยัน">&#xf058; อนุมัติ</asp:LinkButton>
                                        <asp:LinkButton ID="btnCancel" runat="server" OnCommand="btnCancelModal_Command" OnClientClick="return CompareConfirm('ยืนยันไม่อนุมัติ ใช่หรือไม่');" CssClass="fas text-danger m-3" ToolTip="ปฏิเสธ">&#xf057; ไม่อนุมัติ</asp:LinkButton>
                                    </div>

                    </div>
                </div>
            </div>
        </div>
    </div> 
    <!------------------------------------------------------------------------------------------------------------>
    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript"> 

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
