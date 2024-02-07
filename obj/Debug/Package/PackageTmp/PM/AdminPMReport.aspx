<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPMReport.aspx.cs" Inherits="ClaimProject.PM.AdminPMReport" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <script src="/crystalreportviewers13/js/crviewer/crv.js"></script>

    <div class="card" style="z-index: 0">
        <div class="card-header card-header-primary">
            <h3 class="card-title">รายงานการบำรุงรักษาอุปกรณ์ PM </h3>
        </div>

        <hr />
        <div class="card-body table-responsive">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div runat="server">

                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <asp:RadioButton ID="rbtBudget" runat="server" Text="&nbspปีงบประมาณ" GroupName="G1" AutoPostBack="True" OnCheckedChanged="rbtBudget_CheckedChanged" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <asp:RadioButton ID="rbtMonth" runat="server" Text="&nbspเดือน" GroupName="G1" AutoPostBack="True" OnCheckedChanged="rbtMonth_CheckedChanged" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <asp:RadioButton ID="rbtDuration" runat="server" Text="&nbspช่วงวันที่" GroupName="G1" AutoPostBack="True" OnCheckedChanged="rbtDuration_CheckedChanged" />
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <asp:Label ID="lbPoint" runat="server" Text="ด่านฯ " Font-Bold="true"></asp:Label>
                                    <asp:DropDownList ID="txtStation" runat="server" CssClass="form-control custom-select"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <asp:Label ID="lbBudget" runat="server" Text="ปีงบประมาณ " Font-Bold="true" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="txtBudgetYear" runat="server" Visible="false" CssClass="form-control custom-select"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <asp:Label ID="Label1" runat="server" Text="ปีพ.ศ." Font-Bold="true" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddlThaiYear" runat="server" Visible="false" CssClass="form-control custom-select"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <asp:Label ID="Label2" runat="server" Text="เดือน" Font-Bold="true" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddlMonth" runat="server" Visible="false" CssClass="form-control custom-select">
                                        <asp:ListItem Text="มกราคม" Value="1" ></asp:ListItem><asp:ListItem Text="กุมภาพันธ์" Value="2" ></asp:ListItem>
                                        <asp:ListItem Text="มีนาคม" Value="3" ></asp:ListItem><asp:ListItem Text="เมษายน" Value="4" ></asp:ListItem>
                                        <asp:ListItem Text="พฤษภาคม" Value="5" ></asp:ListItem><asp:ListItem Text="มิถุนายน" Value="6" ></asp:ListItem>
                                        <asp:ListItem Text="กรกฎาคม" Value="7" ></asp:ListItem><asp:ListItem Text="สิงหาคม" Value="8" ></asp:ListItem>
                                        <asp:ListItem Text="กันยายน" Value="9" ></asp:ListItem><asp:ListItem Text="ตุลาคม" Value="10" ></asp:ListItem>
                                        <asp:ListItem Text="พฤศจิกายน" Value="11" ></asp:ListItem><asp:ListItem Text="ธันวาคม" Value="12" ></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <asp:Label ID="lbStartDate" runat="server" Text="ตั้งแต่วันที่ " Font-Bold="true" Visible="false"></asp:Label>
                                    <asp:TextBox ID="txtStartDate" runat="server" Visible="false" CssClass="form-control datepicker" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <asp:Label ID="lbEndDate" runat="server" Text="ถึงวันที่ " Font-Bold="true" Visible="false"></asp:Label>
                                    <asp:TextBox ID="txtEndDate" runat="server" Visible="false" CssClass="form-control datepicker" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <label class="bmd-label-floating"></label>
                                    <asp:Button ID="btnResult" runat="server" Text="แสดงผลลัพธ์" Visible="false" Width="80%" OnClick="btnResult_Click" class="btn btn-danger" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                    <asp:Button ID="btnCoverReport" runat="server" Text="บันทึกใบปะหน้า" Visible="false" Width="80%" CssClass="btn btn-outline-success" OnClick="btnCoverReport_Click" />
                            </div>
                        </div>
                    </div>
                    <br />

                    <h3>
                        <asp:Label ID="lbTable1" runat="server" Text="" Visible="false"></asp:Label>
                    </h3>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lbTableAll" Text="" ></asp:Label>
                        </div>
                    </div>
                    <asp:Label ID="checksomthing" runat="server" Text="" Visible="true"></asp:Label>
                   
                    
                        <asp:Label ID="lbPMNull" runat="server" Text="" Font-Bold="true" ForeColor="#990000"></asp:Label>
                         
                    &nbsp&nbsp<asp:LinkButton ID="ltnAllPM" runat="server" Visible="false" CssClass="btn btn-sm btn-outline-danger" Font-Size="10px" ToolTip="บันทึกPDF"  OnCommand="ltnAllPM_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                        <br />
                        <asp:GridView ID="GridView1" 
                         Visible="false"   HeaderStyle-BackColor="#990000" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="align-content-center"
                         RowStyle-BackColor="#ffe6e6" AlternatingRowStyle-BackColor="#fff0f0" AlternatingRowStyle-ForeColor="#000"
                         OnRowDataBound="GridView1_RowDataBound" AlternatingRowStyle-CssClass="align-content-center"
                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="ลำดับ" ControlStyle-Width="25px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbnum" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="วันที่เข้าPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblActDate" Text='<%# (DataBinder.Eval(Container, "DataItem.pm_act_sdate")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เวลาเริ่มPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbActTime" Text='<%# DataBinder.Eval(Container, "DataItem.pm_act_stime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เวลาสิ้นสุดPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbActETime" Text='<%# DataBinder.Eval(Container, "DataItem.pm_act_etime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ด่านฯ" ControlStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbcpoint" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name").ToString()+" "+DataBinder.Eval(Container, "DataItem.pm_detail_annex").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รายละเอียดการ PM" ControlStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbPMdetail" Text='<%# DataBinder.Eval(Container, "DataItem.pm_detail_note") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="บริษัท" ControlStyle-Width="250px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbCompany" Text='<%# DataBinder.Eval(Container, "DataItem.pm_corporate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ระยะเวลา PM" ControlStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbDuration" Text='<%# DataBinder.Eval(Container, "DataItem.pm_duration_time") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service No." ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbService" Text='<%# DataBinder.Eval(Container, "DataItem.pm_ref_no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ผู้บันทึก" ControlStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbAdmin" Text='<%# DataBinder.Eval(Container, "DataItem.pm_admin_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                </asp:GridView>
                        <br />

            <div id="supdiv" runat="server">
                    
                            <asp:Label ID="lbnum2" runat="server" Text="" ForeColor="#006600" Font-Bold="true" ></asp:Label>
                            
                     &nbsp&nbsp<asp:LinkButton ID="ltnNum2" runat="server" Visible="false" CssClass="btn btn-sm btn-outline-success" ToolTip="บันทึกPDF" Font-Size="10px"  OnCommand="ltnNum2_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                        <br />
                        <asp:GridView ID="GridView2" 
                         Visible="false"   HeaderStyle-BackColor="#006600" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="align-content-center"
                         RowStyle-BackColor="#b3ffb3" AlternatingRowStyle-BackColor="#e6ffe6" AlternatingRowStyle-ForeColor="#000"
                         OnRowDataBound="GridView2_RowDataBound" AlternatingRowStyle-CssClass="align-content-center"
                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridView2_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="ลำดับ" ControlStyle-Width="25px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbnum2" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="วันที่เข้าPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblActDate2" Text='<%# (DataBinder.Eval(Container, "DataItem.pm_act_sdate")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เวลาเริ่มPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbActTime2" Text='<%# DataBinder.Eval(Container, "DataItem.pm_act_stime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เวลาสิ้นสุดPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbActETime2" Text='<%# DataBinder.Eval(Container, "DataItem.pm_act_etime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ด่านฯ" ControlStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbcpoint2" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name").ToString()+" "+DataBinder.Eval(Container, "DataItem.pm_detail_annex").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="บริษัท" ControlStyle-Width="250px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbCompany2" Text='<%# DataBinder.Eval(Container, "DataItem.pm_corporate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ระยะเวลา PM" ControlStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbDuration2" Text='<%# DataBinder.Eval(Container, "DataItem.pm_duration_time") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service No." ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbService2" Text='<%# DataBinder.Eval(Container, "DataItem.pm_ref_no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ผู้บันทึก" ControlStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbAdmin2" Text='<%# DataBinder.Eval(Container, "DataItem.pm_admin_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                </asp:GridView>

                    <br />
                    
                            <asp:Label ID="lbnum3" runat="server" Text="" Font-Bold="true"  ForeColor="#0033cc"></asp:Label>
                            
                     &nbsp&nbsp<asp:LinkButton ID="ltnNum3" runat="server" Visible="false" CssClass="btn btn-sm btn-outline-info" ToolTip="บันทึกPDF" Font-Size="10px"  OnCommand="ltnNum3_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                        <br />
                        <asp:GridView ID="GridView3" 
                         Visible="false"   HeaderStyle-BackColor="#0033cc" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="align-content-center"
                         RowStyle-BackColor="#ccd9ff" AlternatingRowStyle-BackColor="#e6ecff" AlternatingRowStyle-ForeColor="#000"
                         OnRowDataBound="GridView3_RowDataBound" AlternatingRowStyle-CssClass="align-content-center"
                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridView3_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="ลำดับ" ControlStyle-Width="25px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbnum3" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="วันที่เข้าPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblActDate3" Text='<%# (DataBinder.Eval(Container, "DataItem.pm_act_sdate")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เวลาเริ่มPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbActTime3" Text='<%# DataBinder.Eval(Container, "DataItem.pm_act_stime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เวลาสิ้นสุดPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbActETime3" Text='<%# DataBinder.Eval(Container, "DataItem.pm_act_etime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ด่านฯ" ControlStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbcpoint3" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name").ToString()+" "+DataBinder.Eval(Container, "DataItem.pm_detail_annex").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รายละเอียดการ PM" ControlStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbPMdetail3" Text='<%# DataBinder.Eval(Container, "DataItem.pm_detail_note") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="บริษัท" ControlStyle-Width="250px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbCompany3" Text='<%# DataBinder.Eval(Container, "DataItem.pm_corporate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ระยะเวลา PM" ControlStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbDuration3" Text='<%# DataBinder.Eval(Container, "DataItem.pm_duration_time") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service No." ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbService3" Text='<%# DataBinder.Eval(Container, "DataItem.pm_ref_no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ผู้บันทึก" ControlStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbAdmin3" Text='<%# DataBinder.Eval(Container, "DataItem.pm_admin_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                </asp:GridView>

                        <br />
                    
                            <asp:Label ID="lbnum4" runat="server" Text="" Font-Bold="true"  ForeColor="#373737"></asp:Label>
                           
                      &nbsp&nbsp<asp:LinkButton ID="ltnNum4" runat="server" Visible="false" CssClass="btn btn-sm btn-outline-dark" ToolTip="บันทึกPDF" Font-Size="10px"  OnCommand="ltnNum4_Command"><i class="fa">&#xf02f;</i></asp:LinkButton>
                        <br />
                        <asp:GridView ID="GridView4" 
                         Visible="false"   HeaderStyle-BackColor="#373737" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="align-content-center"
                         RowStyle-BackColor="#d3d3d3" AlternatingRowStyle-BackColor="#efefef" AlternatingRowStyle-ForeColor="#000"
                         OnRowDataBound="GridView4_RowDataBound" AlternatingRowStyle-CssClass="align-content-center"
                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridView4_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="ลำดับ" ControlStyle-Width="25px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbnum4" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="วันที่เข้าPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblActDate4" Text='<%# (DataBinder.Eval(Container, "DataItem.pm_act_sdate")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เวลาเริ่มPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbActTime4" Text='<%# DataBinder.Eval(Container, "DataItem.pm_act_stime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เวลาสิ้นสุดPM" ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbActETime4" Text='<%# DataBinder.Eval(Container, "DataItem.pm_act_etime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ด่านฯ" ControlStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbcpoint4" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name").ToString()+" "+DataBinder.Eval(Container, "DataItem.pm_detail_annex").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รายละเอียดการ PM" ControlStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbPMdetail4" Text='<%# DataBinder.Eval(Container, "DataItem.pm_detail_note") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="บริษัท" ControlStyle-Width="250px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbCompany4" Text='<%# DataBinder.Eval(Container, "DataItem.pm_corporate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ระยะเวลา PM" ControlStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbDuration4" Text='<%# DataBinder.Eval(Container, "DataItem.pm_duration_time") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service No." ControlStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbService4" Text='<%# DataBinder.Eval(Container, "DataItem.pm_ref_no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ผู้บันทึก" ControlStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbAdmin4" Text='<%# DataBinder.Eval(Container, "DataItem.pm_admin_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                </asp:GridView>
                </div>

                        <h3><asp:Label ID="lbTable2" runat="server" Text="" Visible="false"></asp:Label></h3>

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>


    </div>

    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
</asp:Content>
