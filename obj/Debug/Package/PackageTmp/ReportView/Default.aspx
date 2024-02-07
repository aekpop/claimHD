<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClaimProject.ReportView.Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>


    <div class="card" style="z-index: 0">
        <div class="card-header ">
            <div class="card-title">แสดงข้อมูลอุบัติเหตุทางสถิติ</div>
        </div>

        <div class="card-body table-responsive">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div runat="server">
                        <div id="headdiv" runat="server">
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group bmd-form-group">
                                        <asp:RadioButton ID="rbtBudget" runat="server" Text="&nbspปีงบประมาณ" GroupName="G1" AutoPostBack="True" OnCheckedChanged="rbtBudget_CheckedChanged" />
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
                                        <asp:DropDownList ID="txtStation" runat="server" CssClass="form-control custom-select" AutoPostBack="true" OnSelectedIndexChanged="txtStation_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-2" id="divAnexx" runat="server" visible="false">
                                    <div class="form-group bmd-form-group">
                                        <asp:Label ID="Label1" runat="server" Text="เลขอาคาร" Font-Bold="true"></asp:Label>
                                        <asp:DropDownList ID="ddlAnexSta" runat="server" CssClass="form-control custom-select"></asp:DropDownList>
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
                        </div>

                        <div class="row">
                            <div class="col-md-1">

                                <asp:Button ID="btnResult" runat="server" Text="ตกลง" Visible="false" Width="100%" OnClick="btnResult_Click" CssClass="btn btn-success " />

                            </div>
                            <div class="col-md-1">

                                <asp:Button ID="btnNewSearch" runat="server" Text="ย้อนกลับ" Visible="false" Width="100%" OnClick="btnNewSearch_Click" class="btn btn-primary" />

                            </div>
                        </div>
                        <asp:Label ID="chkday" runat="server" Text=""></asp:Label>
                    </div>

                    <hr />
                    <div class="row">
                        <div class="col">
                            <h3>
                                <asp:Label ID="lbTable1" runat="server" Text="" Visible="false"></asp:Label>
                            </h3>
                            <asp:GridView
                                ID="GridViewAllbyBudget"
                                runat="server"
                                OnRowDataBound="GridViewAllbyBudget_RowDataBound"
                                OnRowCreated="GridViewAllbyBudget_RowCreated"
                                AutoGenerateColumns="False"
                                Visible="False" RowStyle-CssClass="text-center"
                                HeaderStyle-CssClass="text-center"
                                HeaderStyle-HorizontalAlign="Center"
                                FooterStyle-Font-Bold="true" BackColor="White"
                                BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" ShowFooter="true " Font-Size="Large">
                                <Columns>
                                    <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="15px">
                                        <ItemTemplate>
                                            <asp:Label ID="NumCpoint" runat="server" Text="" CssClass="text-center"> </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="cpoint" HeaderText="ด่านฯ" HeaderStyle-Width="200px" />
                                    <asp:BoundField DataField="Total" HeaderText="จำนวนอุบัติเหตุ" DataFormatString="{0}" HeaderStyle-Width="100px" />

                                </Columns>
                                <FooterStyle BackColor="#d65302" ForeColor="White"></FooterStyle>
                                <HeaderStyle BackColor="#d65302" ForeColor="White" />
                                <PagerStyle BackColor="#d65302" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#fff9d6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                            </asp:GridView>
                        </div>
                        <div class="col">
                            <h3>
                                <asp:Label ID="lbChart1" runat="server" Text="" Visible="false"></asp:Label>
                            </h3>
                            <asp:Chart ID="Chart1" runat="server" BackImageAlignment="Center">
                                <Series>
                                    <asp:Series Name="Series1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
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
                            <asp:GridView ID="DeviceGridview" runat="server" ShowFooter="True" Font-Size="Large" CssClass="table-sm"
                                HeaderStyle-HorizontalAlign="Center"
                                AutoGenerateColumns="False"
                                OnRowDataBound="DeviceGridview_RowDataBound"
                                FooterStyle-Font-Bold="true" BackColor="White"
                                BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                <Columns>
                                    <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:Label ID="NumDevice" runat="server" Text="" CssClass="text-center"> </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="devicename" HeaderText="รายชื่ออุปกรณ์" HeaderStyle-Width="400px" />
                                    <asp:BoundField DataField="amount" HeaderText="จำนวน" DataFormatString="{0}" HeaderStyle-Width="100px" />
                                </Columns>

                                <FooterStyle BackColor="#d65302" ForeColor="White" Font-Size="Medium"></FooterStyle>
                                <HeaderStyle BackColor="#d65302" ForeColor="White" Font-Size="Medium" />
                                <PagerStyle BackColor="#d65302" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#fff9d6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                            </asp:GridView>
                        </div>


                    </div>
                    <hr />
                    <h3>
                        <asp:Label ID="lbTable2" runat="server" Text="" Visible="false"></asp:Label></h3>
                    </div>

                    <asp:GridView
                        Style="table-layout: fixed;" Width="80%"
                        ID="GridViewthing"
                        runat="server" ShowFooter="True"
                        OnRowDataBound="GridViewthing_RowDataBound"
                        OnRowCreated="GridViewthing_RowCreated"
                        AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Center"
                        Visible="False" RowStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"
                        FooterStyle-Font-Bold="true" BackColor="White"
                        BorderColor="#ff9e9e" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Medium">

                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:Label ID="NumEn1" runat="server" Text="" CssClass="text-center" Font-Size="Larger"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="cpoint" HeaderText="ด่านฯ" HeaderStyle-Width="180px" />
                            <asp:BoundField DataField="EN01" HeaderText="EN01" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN02" HeaderText="EN02" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN03" HeaderText="EN03" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN04" HeaderText="EN04" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN05" HeaderText="EN05" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN06" HeaderText="EN06" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN07" HeaderText="EN07" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN08" HeaderText="EN08" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN09" HeaderText="EN09" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN10" HeaderText="EN10" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN11" HeaderText="EN11" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN12" HeaderText="EN12" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN13" HeaderText="EN13" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN14" HeaderText="EN14" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN15" HeaderText="EN15" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN16" HeaderText="EN16" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN17" HeaderText="EN17" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN18" HeaderText="EN18" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN19" HeaderText="EN19" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN20" HeaderText="EN20" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:TemplateField HeaderText="รวม" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <asp:Label ID="FinalEn1" runat="server" Text="" CssClass="text-center"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#8c0909" ForeColor="white" Font-Size="Large"></FooterStyle>
                        <HeaderStyle BackColor="#8c0909" ForeColor="white" Font-Size="Large" />
                        <PagerStyle BackColor="#f28a4b" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#ffeded" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#fff389" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#fffbdb" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                    <br />
                    <asp:GridView
                        Style="table-layout: fixed;" Width="80%"
                        ID="GridViewThingX"
                        runat="server" ShowFooter="True"
                        OnRowDataBound="GridViewThingX_RowDataBound"
                        OnRowCreated="GridViewThingX_RowCreated"
                        AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Center"
                        Visible="False" RowStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"
                        FooterStyle-Font-Bold="true" BackColor="White"
                        BorderColor="#95eda3" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Medium">
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:Label ID="NumThingX" runat="server" Text="" CssClass="text-center" Font-Size="Larger"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="cpoint" HeaderText="ด่านฯ" HeaderStyle-Width="180px" />
                            <asp:BoundField DataField="EX01" HeaderText="EX01" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX02" HeaderText="EX02" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX03" HeaderText="EX03" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX04" HeaderText="EX04" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX05" HeaderText="EX05" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX06" HeaderText="EX06" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX07" HeaderText="EX07" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX08" HeaderText="EX08" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX09" HeaderText="EX09" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX10" HeaderText="EX10" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX11" HeaderText="EX11" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX12" HeaderText="EX12" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX13" HeaderText="EX13" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX14" HeaderText="EX14" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX15" HeaderText="EX15" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX16" HeaderText="EX16" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX17" HeaderText="EX17" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX18" HeaderText="EX18" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX19" HeaderText="EX19" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX20" HeaderText="EX20" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:TemplateField HeaderText="รวม" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <asp:Label ID="FinalEx1" runat="server" Text="" CssClass="text-center"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <FooterStyle BackColor="#005101" ForeColor="White" Font-Size="Large"></FooterStyle>
                        <HeaderStyle BackColor="#005101" ForeColor="White" Font-Size="Large" />
                        <PagerStyle BackColor="#005101" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#e2ffe6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                    <br />
                    <asp:GridView
                        Style="table-layout: fixed;" Width="80%"
                        ID="GridViewEx"
                        runat="server" ShowFooter="True"
                        OnRowDataBound="GridViewEx_RowDataBound"
                        OnRowCreated="GridViewEx_RowCreated"
                        AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Center"
                        Visible="False" RowStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"
                        FooterStyle-Font-Bold="true" BackColor="White"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Medium">
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="35px">
                                <ItemTemplate>
                                    <asp:Label ID="NumEx" runat="server" Text="" CssClass="text-center"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="devicename" HeaderText="รายชื่ออุปกรณ์" HeaderStyle-Width="250px" />
                            <asp:BoundField DataField="EX01" HeaderText="EX01" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX02" HeaderText="EX02" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX03" HeaderText="EX03" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX04" HeaderText="EX04" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX05" HeaderText="EX05" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX06" HeaderText="EX06" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX07" HeaderText="EX07" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX08" HeaderText="EX08" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX09" HeaderText="EX09" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX10" HeaderText="EX10" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX11" HeaderText="EX11" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX12" HeaderText="EX12" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX13" HeaderText="EX13" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX14" HeaderText="EX14" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX15" HeaderText="EX15" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX16" HeaderText="EX16" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX17" HeaderText="EX17" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX18" HeaderText="EX18" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX19" HeaderText="EX19" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="EX20" HeaderText="EX20" DataFormatString="{0}" HeaderStyle-Width="35px" />
                            <asp:BoundField DataField="total" HeaderText="รวม" DataFormatString="{0}" HeaderStyle-Width="35px" />
                        </Columns>


                        <FooterStyle BackColor="#d65302" ForeColor="White" Font-Size="Large"></FooterStyle>
                        <HeaderStyle BackColor="#d65302" ForeColor="White" Font-Size="Large" />
                        <PagerStyle BackColor="#d65302" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#fff9d6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>

                    <br />
                    <asp:GridView
                        Style="table-layout: fixed;" Width="80%"
                        ID="GridViewEn2"
                        runat="server" ShowFooter="True"
                        OnRowDataBound="GridViewEn2_RowDataBound"
                        OnRowCreated="GridViewEn2_RowCreated"
                        AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Center"
                        Visible="False" RowStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"
                        FooterStyle-Font-Bold="true" BackColor="White"
                        BorderColor="#b8c6fc" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Medium">
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="41px">
                                <ItemTemplate>
                                    <asp:Label ID="NumEn2" runat="server" Text="" CssClass="text-center"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="devicename" HeaderText="รายชื่ออุปกรณ์" HeaderStyle-Width="320px" />
                            <asp:BoundField DataField="EN01" HeaderText="EN01" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN02" HeaderText="EN02" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN03" HeaderText="EN03" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN04" HeaderText="EN04" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN05" HeaderText="EN05" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN06" HeaderText="EN06" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN07" HeaderText="EN07" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN08" HeaderText="EN08" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN09" HeaderText="EN09" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN10" HeaderText="EN10" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN11" HeaderText="EN11" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN12" HeaderText="EN12" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN13" HeaderText="EN13" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN14" HeaderText="EN14" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN15" HeaderText="EN15" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN16" HeaderText="EN16" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN17" HeaderText="EN17" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN18" HeaderText="EN18" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN19" HeaderText="EN19" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EN20" HeaderText="EN20" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:TemplateField HeaderText="รวม" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <asp:Label ID="FinalEn2" runat="server" Text="" CssClass="text-center"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>


                        <FooterStyle BackColor="#001c82" ForeColor="White" Font-Size="Large"></FooterStyle>
                        <HeaderStyle BackColor="#001c82" ForeColor="White" Font-Size="Large" />
                        <PagerStyle BackColor="#001c82" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#dbe2fc" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                    <br />
                    <asp:GridView
                        Style="table-layout: fixed;" Width="80%"
                        ID="GridViewEx2"
                        runat="server" ShowFooter="True"
                        OnRowDataBound="GridViewEx2_RowDataBound"
                        OnRowCreated="GridViewEx2_RowCreated"
                        AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Center"
                        Visible="False" RowStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"
                        FooterStyle-Font-Bold="true" BackColor="White"
                        BorderColor="#a1eafc" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Medium">

                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="41px">
                                <ItemTemplate>
                                    <asp:Label ID="NumEx2" runat="server" Text="" CssClass="text-center"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="devicename" HeaderText="รายชื่ออุปกรณ์" HeaderStyle-Width="320px" />
                            <asp:BoundField DataField="EX01" HeaderText="EX01" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX02" HeaderText="EX02" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX03" HeaderText="EX03" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX04" HeaderText="EX04" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX05" HeaderText="EX05" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX06" HeaderText="EX06" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX07" HeaderText="EX07" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX08" HeaderText="EX08" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX09" HeaderText="EX09" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX10" HeaderText="EX10" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX11" HeaderText="EX11" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX12" HeaderText="EX12" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX13" HeaderText="EX13" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX14" HeaderText="EX14" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX15" HeaderText="EX15" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX16" HeaderText="EX16" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX17" HeaderText="EX17" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX18" HeaderText="EX18" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX19" HeaderText="EX19" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:BoundField DataField="EX20" HeaderText="EX20" DataFormatString="{0}" HeaderStyle-Width="40px" />
                            <asp:TemplateField HeaderText="รวม" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <asp:Label ID="FinalEx2" runat="server" Text="" CssClass="text-center"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <FooterStyle BackColor="#015b70" ForeColor="White" Font-Size="Large"></FooterStyle>
                        <HeaderStyle BackColor="#015b70" ForeColor="White" Font-Size="Large" />
                        <PagerStyle BackColor="#015b70" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#e0f9ff" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>


                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>






</asp:Content>
