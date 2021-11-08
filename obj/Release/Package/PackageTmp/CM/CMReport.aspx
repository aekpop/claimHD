<%@ Page Title="งานบำรุงรักษา / รายงาน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMReport.aspx.cs" Inherits="ClaimProject.CM.CMReport" EnableEventValidation="false" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>
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


    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">
     <!-- Menu Dropdown -->        
        
        <!-------------------------------- // ------------------------------------> 
    <div id="MainBody" class="card" style="z-index: 0; ">
        <div class="card-header ">
            <div class="card-title">รายงานสรุปแจ้งซ่อมอุปกรณ์</div>
        </div>       
        <div class="card-body table-responsive"> 
                    <div runat="server">                        
                        <div class="row">                                       
                                        <div class="col-md-4 ">
                                            <div class="form-group bmd-form-group">
                                            <asp:Label ID="lbBudget" runat="server" Text="ปีงบฯ : "></asp:Label>
                                            <asp:DropDownList ID="ddlCMBudget" runat="server" CssClass="form-control  "></asp:DropDownList>
                                                </div>
                                        </div>
                                        <div class=" col-md-4 ">
                                         <div class="form-group bmd-form-group">
                                            <asp:Label ID="lbToll" runat="server" Text="ด่านฯ : "></asp:Label>                                            
                                            <asp:DropDownList ID="txtCpointSearch" runat="server" CssClass="form-control "></asp:DropDownList>
                                             </div>
                                        </div>
                                        <div class=" col-md-4 ">
                                             <div class="form-group bmd-form-group">
                                            <asp:Label ID="lbAnnex" runat="server" Text="อาคาร"></asp:Label>                                       
                                            <asp:TextBox ID="txtPoint" runat="server" CssClass="form-control" placeholder="ใส่หมายเลข" ToolTip="ถ้าไม่มี ให้เว้นว่าง"></asp:TextBox>
                                                 </div>
                                        </div>
                            </div>
                        <div class="row">
                                        <div class="col-md-4">
                                             <div class="form-group bmd-form-group">
                                                        <asp:Label ID="lbChannel" runat="server" text="  ตู้ :" ></asp:Label>
                                                        <asp:DropDownList ID="txtSearchChannel" runat="server" CssClass="form-control "></asp:DropDownList>
                                                    </div>
                                            </div>
                                        <div class="col-md-4 ">
                                             <div class="form-group bmd-form-group">
                                            <asp:Label ID="lbdevice" runat="server" Text="อุปกรณ์ : "></asp:Label>                                            
                                            <asp:DropDownList ID="txtDeviceDamage" runat="server" CssClass="combobox form-control custom-select "></asp:DropDownList>
                                                 </div>
                                        </div>
                                         <div class=" col-md-4 ">
                                             <div class="form-group bmd-form-group">
                                            <asp:Label ID="lbStatus" runat="server" Text="สถานะ : "></asp:Label>
                                            <asp:DropDownList ID="txtCMStatus" runat="server"  CssClass="form-control " ></asp:DropDownList>
                                                 </div>
                                        </div>                                        
                        </div>                        
                        <div class="row">
                                        

                                      <div class=" col-md-2 ">
                                             <div class="form-group bmd-form-group">
                                            <asp:Label ID="lbDayS" runat="server" Text="วันที่แจ้งซ่อม      ตั้งแต่ "></asp:Label>
                                            <asp:TextBox ID="txtDateStart" runat="server" CssClass="form-control datepicker "></asp:TextBox>
                                        </div>
                                            </div>
                                        <div class=" col-md-2">
                                              <div class="form-group bmd-form-group">
                                            <asp:Label ID="lbDayE" runat="server" Text="ถึงวันที่ "></asp:Label>
                                            <asp:TextBox ID="txtDateEnd" runat="server" CssClass="form-control datepicker "></asp:TextBox>
                                                  </div>
                                        </div>
                                        <div class ="col-md-2">
                                                          <div class="form-group bmd-form-group">
                                                             <div class="label-on-left" >เลือกทั้งหมด</div>
                                                                <label class="container">
                                                                        <input type="checkbox"  id="CheckAllDay" name="CheckAllDay" runat="server" />
                                                                      <span class="checkmark"></span>                                                                                                
                                                                </label>                              
                                                          </div>
                                                    </div>
                                        <div class=" col-md-2"></div>
                                        <div class=" col-md-4 ">
                                             <div class="form-group bmd-form-group">
                                            <asp:Label ID="lblbRespons" runat="server" Text="ผู้รับผิดชอบ : "></asp:Label>
                                            <asp:DropDownList ID="ddlResponsible" runat="server"  CssClass="form-control " ></asp:DropDownList>
                                                 </div>
                                        </div>           
                                  </div>
                                                                     
                                         
                        <br />
                                        <div class="row">  
                                            <div class="col-xl-6 text-right">
                                                      <asp:LinkButton ID="btnSearchEdit1" runat="server" CssClass="btn btn-info fa" Font-Size="Larger" OnClick="btnSearchEdit_Click">&#xf002; ค้นหา</asp:LinkButton>
                                                </div>
                                            <!--<div class="col-xl-4 text-left">
                                                    <asp:LinkButton ID="btnExport" runat="server" Visible="false" CssClass="btn btn-dark fa" Font-Size="Larger" ToolTip="Export To Excel" OnClick="btnExport_Click">&#xf1c3; ออกรายงาน</asp:LinkButton>
                                                </div>
                                            -->
                                            <div class="col-xl-6 text-left">
                                                <asp:LinkButton ID="btnReport" runat="server" CssClass="btn btn-success fa" Font-Size="Larger" OnCommand="btnReport_Command">&#xf15c; ออกรายงาน</asp:LinkButton>
                                            </div>
                                        </div>
                        </div>
                </div> 
           </div>
        <asp:Label ID="lbCMNull" runat="server" Text=""></asp:Label>

        <asp:Panel ID="Panel1" runat="server" >
                       <asp:GridView ID="GridView1" runat="server"
                           HeaderStyle-BackColor="#ffffff"
                           HeaderStyle-CssClass="align-content-center"
                           HeaderStyle-Font-Size="18px"
                           OnRowDataBound="GridView1_RowDataBound"
                           AlternatingRowStyle-CssClass="align-content-left"
                           AutoGenerateColumns="false"
                           PageSize="20"
                           GridLines="None"
                           Font-Size="15px"
                           HeaderStyle-Height="50px"
                           RowStyle-Height="50px"
                           CssClass="table table-hover table-condensed table-sm"
                           OnPageIndexChanging="GridView1_PageIndexChanging"
                           PagerSettings-Mode="NumericFirstLast"
                           PagerSettings-FirstPageText="หน้าแรก"  PagerSettings-LastPageText="หน้าสุดท้าย"
                           AllowPaging="true"
                           >                      
                            <Columns>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <asp:Label ID="lbClaimNumrow" Text='<%#  Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbCpoint" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name")+" "+DataBinder.Eval(Container, "DataItem.cm_point") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ช่องทาง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbChannel" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อุปกรณ์" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" ControlStyle-Width="230px" HeaderStyle-Width="230px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>' OnCommand="lbDeviceName_Command"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อาการที่ชำรุด" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" ControlStyle-Width="230px" HeaderStyle-Width="230px">
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
                            <asp:TemplateField HeaderText="เวลาดำเนินการ" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right" >
                                <ItemTemplate>
                                    <asp:Label ID="lbDay" runat="server"></asp:Label>
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
                           <PagerStyle HorizontalAlign="Center" CssClass="GridPager"  ForeColor="#ef8a00" />
                </asp:GridView>
            </asp:Panel> 

            </div>
          <!------------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="ApprovCMModal" tabindex="-1" role="dialog" aria-labelledby="ApprovCMModalLabel" aria-hidden="true" >
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="modal-title">รายละเอียดการแจ้งซ่อมอุปกรณ์ #</div>
                        <asp:Label ID="pkeq" runat="server" visible="false" Font-Size="Smaller" ></asp:Label>
                            <asp:Label ID="lbrefRecheck" Enabled="false"  runat="server"   />
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                </div>
                            <div class="container" style="font-size:medium; ">                              
                                <div class="modal-body" style="line-height: inherit;">
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
                    <!------------------------------------------------------------------------------------------------------>
                    
                            <div class="row" >
                                <div class="col-xl">
                                    <div class="form-group bmd-form-group">       
                                        <span class = "label label-primary">สถานะ : </span>
                                           <asp:Label ID="lbStatusRecheck" Enabled="false" runat="server"></asp:Label>
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
                                            <asp:Label ID="lbNodeRecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                </div>

                                
                                    
                                        <div class="row" >
                                            <div class="col-xl">
                                                <div class="form-group bmd-form-group">       
                                                    <asp:Label ID="lbDates" Enabled="false" runat="server" Visible="false">วันที่แจ้ง : </asp:Label>
                                                    <asp:Label ID="lbDatesRecheck" Enabled="false" runat="server" Visible="false" />
                                                </div>
                                            </div>
                                            <div class="col-xl">
                                                <div class="form-group bmd-form-group">
                                                    <asp:Label ID="lbTimes" Enabled="false" runat="server" Visible="false">เวลา : </asp:Label>
                                                    <asp:Label ID="lbTimesRecheck" Enabled="false" runat="server" Visible="false" />
                                                </div>
                                            </div>
                                        </div>
                                  
                                
                                <div class="row" >
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">วันที่เข้าแก้ไข :</span>
                                            <asp:Label ID="lbDateERecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                    <div class="col-xl">
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
                                            <span class = "label label-primary">เวลา : </span>
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
                                </div>
                                <div class="modal-footer">
                                    <div class="row">                                      
                                        <div class="col-2">
                                            
                                            <asp:LinkButton Id="btnReverb" runat="server" Text="Reverb" CssClass="btn btn-danger" OnCommand="btnReverb_Command" Visible="false" OnClientClick="return CompareConfirm('คุณต้องการย้อนกลับไปอนุมัติอีกครั้ง ใช่หรือไม่');" />
                                        </div>                                                                            
                                    </div>
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

            $(document).ready(function(){
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
