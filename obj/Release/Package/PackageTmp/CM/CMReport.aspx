<%@ Page Title="รายงานการซ่อมอุปกรณ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMReport.aspx.cs" Inherits="ClaimProject.CM.CMReport" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <script src="/crystalreportviewers13/js/crviewer/crv.js"></script>


    <div class="card" style="z-index: 0">
        <div class="card-header card-header-primary">
            <h3 class="card-title">รายงานการซ่อมอุปกรณ์ CM </h3>
        </div>

        <hr />
        <div class="card-body table-responsive">                  
                    <div runat="server">

                        <div class="row">
                                                       
                                <div class="col-md-3">
                                    <label class="bmd-label-floating">ปีงบประมาณ : </label>
                                    <asp:DropDownList ID="ddlCMBudget" runat="server"  CssClass="form-control custom-select col-md-4" ></asp:DropDownList>
                                </div>
                            <div class="col-md-3">
                                <!--<div class="form-group bmd-form-group">-->
                                    <label class="bmd-label-floating">ด่านฯ : </label>
                                    <asp:DropDownList ID="txtCpointSearch" runat="server" CssClass="form-control custom-select col-md-4"></asp:DropDownList>
                                </div>

                            <div class="col-md-3">
                                    <label class="bmd-label-floating">สถานะ : </label>
                                    <asp:DropDownList ID="txtCMStatus" runat="server"  CssClass="form-control custom-select col-md-5" ></asp:DropDownList>
                                </div>
                            
                        <div class="col-md-3">
                            <asp:Button ID="btnSearchEdit" runat="server" Text="ค้นหา" CssClass="btn btn-success" OnClick="btnSearchEdit_Click"/>
                        </div>
                        </div>

                    </div>    
                    </div>
                    <br />
                   <asp:Panel ID="Panel1" runat="server" >
                        <asp:GridView ID="GridView1"   
                            HeaderStyle-BackColor="#ffffff" 
                            HeaderStyle-CssClass="align-content-center"
                            RowStyle-BackColor="#ffffff" 
                            AlternatingRowStyle-BackColor="#ffffff" 
                            AlternatingRowStyle-ForeColor="#000"
                            OnRowDataBound="GridView1_RowDataBound" 
                            AlternatingRowStyle-CssClass="align-content-center" 
                            runat="server" 
                            AutoGenerateColumns="false" 
                            AllowPaging="true"
                            PageSize="100"
                            GridLines="None"
                            CssClass="table table-hover table-condensed table-sm"
                            OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                
                                <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                                <ItemTemplate>
                                    <asp:Label ID="lbCpoint" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name")+" "+DataBinder.Eval(Container, "DataItem.cm_point") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ช่องทาง" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                                <ItemTemplate>
                                    <asp:Label ID="lbChannel" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_channel") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อุปกรณ์" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                                <ItemTemplate>
                                    <asp:Label ID="lbDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อาการที่ชำรุด" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbProblem" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_problem") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่แจ้งซ่อม" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbSDate" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลาแจ้งซ่อม" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbSTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_stime")+" น." %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่แก้ไข" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="btnDateEditCM" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลาที่แก้ไข" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="btnTimeEditCM" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbStatus" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                               
                            </Columns>
                </asp:GridView>
                       </asp:Panel>
                </div>                     
                    </div>

        </div>


    </div>

    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>



</asp:Content>
