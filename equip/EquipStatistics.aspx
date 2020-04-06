<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipStatistics.aspx.cs" Inherits="ClaimProject.equip.EquipStatistics" %>
 <%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
        <asp:Button runat="server" ID="btnMainEQt"  Font-Bold="true" BackColor="#737272" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="หน้าหลักรายงาน"  OnClick="btnMainEQt_Click" CssClass="btn" />

    <div class="card" style="z-index: 0">
        <div class="card-header card-header-warning" style="height:60px;">
            <h3 class="card-title">ตารางรายงานแสดงข้อมูลทางสถิติ</h3>
        </div>

        <div class="card-body table-responsive table-sm">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div id="headdiv" runat="server" style="padding:1px 1px 1px 1px;" >
                        <div class="row" style="background-color:antiquewhite;height:40px">
                            <div class="col-md-2"  style="padding:13px 1px 1px 20px;width:60px;">
                                
                                   <asp:RadioButton ID="rbtBudgets" runat="server" Text="&nbspปีงบประมาณ" Checked="true" GroupName="G1" AutoPostBack="True" OnCheckedChanged="rbtBudgets_CheckedChanged" />
                                
                            </div>
                            <div class="col-md-2" style="padding:13px 1px 1px 10px;width:100px;">
                                    <asp:RadioButton ID="rbtDurations" runat="server" Text="&nbspตั้งแต่วันที่" GroupName="G1" AutoPostBack="True" OnCheckedChanged="rbtDurations_CheckedChanged" />
                                
                            </div>
                            
                        </div>
                        <div class="row" style="background-color:antiquewhite;height:50px">
                            <div class="col-md-1"   style="padding:24px 5px 1px 38px;">
                                
                                    <asp:DropDownList ID="txtBudgetYear" Width="120px" Height="38px" runat="server"  CssClass="form-control custom-select"></asp:DropDownList>
                                
                            </div>
                            <div class="col-md-3"   style="padding:1px 5px 1px 120px;">
                                <div class="form-group">
                                    <asp:TextBox ID="txtStartDate" runat="server" Width="120px" CssClass="form-control datepicker" />
                                </div>
                                    
                            </div>
                            <div class="col-md-1"   style="padding:30px 1px 1px 5px;">
                                <asp:Label runat="server" Text="ถึงวันที่" Font-Bold="true" ForeColor="#7d0000" Font-Size="20px" ></asp:Label>
                            </div>
                            
                            <div class="col-md-3"   style="padding:1px 5px 1px 5px;">
                                <div class="form-group">
                                    <asp:TextBox ID="txtEndDate" runat="server"  Width="120px" CssClass="form-control datepicker" />
                                </div>
                            </div>
                            </div>
                        <div class="row" style="background-color:antiquewhite;height:100px">
                            <div class="col-md-2" >
                                <div class="form-group" style="padding:1px 1px 1px 20px">
                                <asp:Label ID="Label1" runat="server" Text="ประเภทการโอนย้าย : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                                <asp:DropDownList ID="ddlstatType" runat="server"   CssClass="form-control" Width="160px" ></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" style="padding:1px 1px 1px 35px">
                                <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="ต้นทาง : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                                <asp:DropDownList ID="ddlStartTolls" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" style="padding:1px 1px 1px 35px">
                                <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="ปลายทาง : " Font-Size="Large" Font-Bold="true" ></asp:Label>
                                <asp:DropDownList ID="ddlEndTolls" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                                </div>
                            </div>


                        </div>


                        
                    </div>
           
                    <br />
                    <hr />
                    
    <div class="row">
                    <div class="col">
                        <h3>
                        <asp:Label ID="lbTable1" runat="server" Text="" Visible="false"></asp:Label>
                        </h3>
                        
                        </div>
                        <div class="col">
                                <h3>
                        <asp:Label ID="lbChart1" runat="server" Text="" Visible="false"></asp:Label>
                        </h3>
                            <asp:Chart ID="Chart1" runat="server"  BackImageAlignment="Center"  >
                               <Series>
                                   <asp:Series Name="Series1"  >
                                   </asp:Series>
                               </Series>
                               <ChartAreas>
                                   <asp:ChartArea Name="ChartArea1"  >
                                   </asp:ChartArea>
                               </ChartAreas>

                              </asp:Chart>
                              
                        </div>

    </div>
    <div class="row">
                    <div class="col">
                            <h3>
                            <asp:Label ID="devicelb" runat="server" Text="" Visible="false"></asp:Label>
                            </h3>
                            
                        </div>


      </div>
                    <hr />



                        <h3>
                            <asp:Label ID="lbTable2" runat="server" Text="" Visible="false"></asp:Label></h3>

                    </div>

                   
                    
                    
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>


    </div>


    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>

</asp:Content>
