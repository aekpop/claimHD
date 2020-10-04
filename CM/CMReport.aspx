<%@ Page Title="รายงานการซ่อมอุปกรณ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMReport.aspx.cs" Inherits="ClaimProject.CM.CMReport" EnableEventValidation="false" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <script src="/crystalreportviewers13/js/crviewer/crv.js"></script>

    <!-- CSS only -->
    <!--<link rel="stylesheet" href="/Content/bootstrap.min.css">-->
    
    <!-- JS, Popper.js, and jQuery -->    
    <script src="../Scripts/jquery-3.5.1.js"></script>
    <script src="../Scripts/umd/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>


    <!--<div class="container-fluid" >-->
    
    <div class="card" style="z-index: 0; font-size:medium; ">
        <div class="card-header card-header-primary">
            <h3 class="card-title">รายงานการซ่อมอุปกรณ์ CM </h3>
        </div>       
        <div class="card-body table-responsive"> 
                    <div runat="server">                        
                        <div class="row">                                       
                                        <div class="col-md-1 text-right">
                                            <asp:Label ID="lbBudget" runat="server" Text="ปีงบประมาณ : "></asp:Label>
                                        </div>
                                        <div class=" col-md-2">
                                            <asp:DropDownList ID="ddlCMBudget" runat="server" CssClass="form-control custom-select "></asp:DropDownList>
                                        </div>
                                        <div class=" col-md-1 text-right">
                                        <!--<div class="form-group bmd-form-group">-->
                                            <asp:Label ID="lbToll" runat="server" Text="ด่านฯ : "></asp:Label>
                                            </div>
                                        <div class=" col-md-2">
                                            <asp:DropDownList ID="txtCpointSearch" runat="server" CssClass="form-control custom-select "></asp:DropDownList>
                                        </div>
                                        <div class=" col-md-1 text-right">
                                            <asp:Label ID="lbAnnex" runat="server" Text="อาคารย่อย : "></asp:Label>
                                        </div>
                                        <div class=" col-md-1 ">
                                            <asp:TextBox ID="txtPoint" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1 text-right">
                                            <asp:Label ID="lbdevice" runat="server" Text="อุปกรณ์ : "></asp:Label>
                                            </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="txtDeviceDamage" runat="server" CssClass="combobox form-control custom-select "></asp:DropDownList>
                                        </div>
                                        
                                        
                        </div>
                        <br />
                        <div class="row">
                                        <div class="col-md-1 text-right">
                                            <asp:Label ID="lbChannel" runat="server" text="ตู้ :" ></asp:Label>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:DropDownList ID="txtSearchChannel" runat="server" CssClass="form-control "></asp:DropDownList>
                                        </div>
                                        <div class =" col-md-1 text-right">
                                            <asp:CheckBox ID ="CheckAllDay" runat="server" AutoPostBack="True" OnCheckedChanged="CheckAllDay_CheckedChanged"/>
                                            <asp:Label Id ="lbCheckAllDay" runat="server" Text="AllDay" ></asp:Label> 
                                        </div>
                                        <div class=" col-md-1 text-right">
                                            <asp:Label ID="lbDayS" runat="server" Text="ตั้งแต่วันที่ : "></asp:Label>
                                            </div>
                                        <div class=" col-md-2">
                                            <asp:TextBox ID="txtDateStart" runat="server" CssClass="form-control datepicker "></asp:TextBox>
                                        </div>
                                        <div class=" col-md-1 text-right">
                                            <asp:Label ID="lbDayE" runat="server" Text="ถึงวันที่ : "></asp:Label>
                                        </div>
                                        <div class=" col-md-2">
                                            <asp:TextBox ID="txtDateEnd" runat="server" CssClass="form-control datepicker "></asp:TextBox>
                                        </div>                            
                                        <div class=" col-md-1 text-right">
                                            <asp:Label ID="lbStatus" runat="server" Text="สถานะ : "></asp:Label>
                                            </div>
                                        <div class=" col-md-2">
                                            <asp:DropDownList ID="txtCMStatus" runat="server"  CssClass="form-control custom-select " ></asp:DropDownList>
                                        </div>
                                        
                        </div>                  
                        <br />
                                        <div class="row">  
                                            <div class="col-xl-6 text-right">
                                                      <asp:LinkButton ID="btnSearchEdit1" runat="server" CssClass="btn btn-info fa" Font-Size="Medium" OnClick="btnSearchEdit_Click">&#xf002; ค้นหา</asp:LinkButton>
                                                </div>
                                            <div class="col-xl-6 text-left">
                                                    <asp:LinkButton ID="btnExport" runat="server" CssClass="btn btn-dark fa" Font-Size="Medium" OnClick="btnExport_Click">&#xf1c3; Export To Excel</asp:LinkButton>
                                                </div>
                                        </div>
                        </div>
                </div> 
           </div>
   
                   <asp:Label ID="lbCMNull" runat="server" Text=""></asp:Label>
                   <hr />
                                        

                   <asp:Panel ID="Panel1" runat="server" >
                        <asp:GridView ID="GridView1" runat="server"    
                            HeaderStyle-BackColor="#ffffff" 
                            HeaderStyle-CssClass="align-content-center"
                            HeaderStyle-Font-Size="18px"   
                            OnRowDataBound="GridView1_RowDataBound" 
                            AlternatingRowStyle-CssClass="align-content-left" 
                            AutoGenerateColumns="false" 
                            AllowPaging="false"
                            PageSize="20"
                            GridLines="None"
                            Font-Size="15px"
                            CssClass="table table-hover table-condensed table-sm"     
                            >                      
                            <Columns>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <asp:Label ID="lbClaimNumrow" Text='<%#  Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbCpoint" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name")+" "+DataBinder.Eval(Container, "DataItem.cm_point") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ช่องทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                                <ItemTemplate>
                                            <asp:Label ID="lbChannel" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อุปกรณ์" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>' OnCommand="lbDeviceName_Command"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อาการที่ชำรุด" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                   <asp:Label ID="lbProblem" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_problem") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่แจ้งซ่อม" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="lbSDate" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลาแจ้งซ่อม" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="lbSTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_stime")+" น." %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่แก้ไข" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="btnDateEditCM" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลาที่แก้ไข" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="btnTimeEditCM" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="นับเวลา" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="lbDay" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                                <ItemTemplate>
                                    <asp:Label ID="lbStatus" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                                    
                            </Columns>

                </asp:GridView>         
            </asp:Panel>
          <!------------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="ApprovCMModal" tabindex="-1" role="dialog" aria-labelledby="ApprovCMModalLabel" aria-hidden="true" ">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">ตรวจสอบรายละเอียดการแจ้งซ่อมอุปกรณ์ CM</h5>
                        <asp:Label ID="pkeq" runat="server" visible="false" Font-Size="Smaller" ></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                </div>
                            <div class="container" style="font-size:medium; ">                              
                                <div class="modal-body" style="line-height: inherit;">
                                    <div class="row" style="height: 380px">
                                        <div class="col-xl">
                                            <asp:Label ID="lbImageStart" runat="server" Text="ภาพก่อนซ่อม"></asp:Label>
                                            <asp:Image ID="ImgEditEQ" runat="server" Height="360px" CssClass="img-thumbnail"/>
                                        </div>
                        
                                        <div class="col-xl">
                                            <asp:Label ID="lbImageEnd" runat="server" Text="ภาพหลังซ่อม"></asp:Label>
                                            <asp:Image ID="ImgEditEQE" runat="server" Height="360px" CssClass="img-thumbnail" />
                                        </div>
                                    </div>                                 
                    <hr />
                    <!------------------------------------------------------------------------------------------------------>
                    
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
                                            <asp:Label ID="lbNodeRecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                </div>

                                <div class="row" >
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">       
                                            <span class = "label label-primary">วันที่แจ้ง : </span>
                                            <asp:Label ID="lbDatesRecheck" Enabled="false"  runat="server"   />
                                        </div>
                                    </div>
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">เวลาแจ้ง : </span>
                                            <asp:Label ID="lbTimesRecheck" Enabled="false" runat="server"  />
                                        </div>
                                    </div>
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">วันที่แก้ไข : </span>
                                            <asp:Label ID="lbDateERecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">
                                            <span class = "label label-primary">เวลาแก้ไข : </span>
                                            <asp:Label ID="lbTimeERecheck" Enabled="false" runat="server"   />
                                        </div>
                                    </div>
                                </div>

                                <div class="row" >
                                    <div class="col-xl">
                                        <div class="form-group bmd-form-group">       
                                            <span class = "label label-primary">ผู้แจ้งซ่อม : </span>
                                            <asp:Label ID="lbUserRecheck" Enabled="false"  runat="server"   />
                                        </div>
                                    </div>                                                                      
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
    <script>
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
    </script>
</asp:Content>
