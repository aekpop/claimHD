<%@ Page Title="รายละเอียดการ PM" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PMDetailForm.aspx.cs" Inherits="ClaimProject.PM.PMDetailForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <asp:UpdatePanel runat="server">
                <ContentTemplate>
     <div class="row">
        <div class="col-md">
            <asp:Button ID="btnBack" CssClass="btn btn-dark" runat="server" Text="<< กลับ " OnClick="btnBack_Click" />
        </div>
    </div>

    <div class="tab-content">
        <div class="card shadow-lg" style="font-size: 19px; z-index: 0;" runat="server"  id="cardBody">

            <div class="card-body table-responsive">

                <div class="row">
                    <div class="col-md text-right">
                        <asp:label ID="lbstatNow" runat="server"  Font-Size="Large"  ></asp:label>
                    </div>
                </div>

                    <div class="row">
                        <div class="col-md-3">
                             <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">รายการ : </label>
                                <asp:Label ID="lbproject" runat="server" Text=""  Font-Size="Larger" Font-Bold="true"></asp:Label>
                              </div>
                        </div>
                        <div class="col-md-5">
                             <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ผู้รับผิดชอบ : </label>
                                <asp:Label ID="lbcompany" runat="server" Text=""  Font-Size="Larger" Font-Bold="true"></asp:Label>
                              </div>
                        </div>
                        <asp:Label ID="companyII" runat="server" Visible="false" ></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ด่านฯ : </label>
                                <asp:Label ID="lbDeCpoint" runat="server" Text=""  Font-Size="Larger" Font-Bold="true"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-5">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">หมายเลขอ้างอิง(กรุณาเขียนมุมขวาบนของใบเซอร์วิส) : </label>
                                <asp:Label ID="lbDeRef" runat="server" Text="10006"  BackColor="#ffffcc"  Font-Size="X-Large" Font-Bold="true"></asp:Label>
                            </div>
                        </div>
                        <asp:Label ID="LbcheckTimeStatPM" runat="server" Visible="false" Text=""  Enabled="false" ></asp:Label>
                        <asp:Label ID="lbcheckTimeEndPM" runat="server" Visible="true" Text=""  Enabled="false" ></asp:Label>
                        <asp:Label ID="lbTolldd" runat="server" Visible="false" Text=""   ></asp:Label>
                        <asp:Label ID="lbLocate" runat="server" Visible="false" Text=""   ></asp:Label>
                        <asp:Label ID="Lbpmref" runat="server" Visible="true" Text=""   ></asp:Label>
                        <asp:Label ID="chktxt1" runat="server" Visible="true" Text=""   ></asp:Label>
                    </div>

                </div>

            </div>

            <div class="card shadow-lg" style="font-size: 19px; z-index: 0;" runat="server" id="Div1">
            <div class="card-header card-header-warning">
                    <h3 class="card-title ">เจ้าหน้าที่ควบคุมระบบบันทึกข้อมูล</h3>
                    </div>
               
            <div class="card-body table-responsive">
                <div runat="server" id="divcom2" >
                    <div class="col-md">
                        <label class="bmd-label-floating">กรุณาเลือกบริเวณที่ต้องการบันทึกการ PM</label>
                    </div>
                    <div class="row" runat="server" >
                        <div class="col-md" >
                            <asp:RadioButton ID="rbtLane" runat="server" Text="บริเวณช่องทาง" AutoPostBack="true" GroupName="PMM" OnCheckedChanged="rbtLane_CheckedChanged" />
                            <asp:RadioButton ID="rbtBuilding" runat="server" text="บริเวณอาคารสำนักงาน" AutoPostBack="true" GroupName="PMM" OnCheckedChanged="rbtBuilding_CheckedChanged" />
                        </div>
                    </div>

                    <div class="row" id="divEN" runat="server" visible="false">
                        <div class="col-md" >
                            <asp:Button ID="btnEn1" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN01"  OnClick="btnEn1_Click"/>
                            <asp:Button ID="btnEn2" CssClass="btn btn-dark btn-sm" runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN02"  OnClick="btnEn2_Click"/>
                            <asp:Button ID="btnEn3" CssClass="btn btn-dark btn-sm" runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN03"  OnClick="btnEn3_Click"/>
                            <asp:Button ID="btnEn4" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN04" OnClick="btnEn4_Click"/>
                            <asp:Button ID="btnEn5" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN05" OnClick="btnEn5_Click"/>
                            <asp:Button ID="btnEn6" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN06" OnClick="btnEn6_Click"/>
                            <asp:Button ID="btnEn7" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN07" OnClick="btnEn7_Click"/>
                            <asp:Button ID="btnEn8" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN08" OnClick="btnEn8_Click"/>
                            <asp:Button ID="btnEn9" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN09" OnClick="btnEn9_Click"/>
                            <asp:Button ID="btnEn10" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN10" OnClick="btnEn10_Click"/>
                            <asp:Button ID="btnEn11" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN11" OnClick="btnEn11_Click"/>
                            <asp:Button ID="btnEn12" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN12" OnClick="btnEn12_Click"/>
                            <asp:Button ID="btnEn13" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN13" OnClick="btnEn13_Click"/>
                            <asp:Button ID="btnEn14" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN14" OnClick="btnEn14_Click"/>
                            <asp:Button ID="btnEn15" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN15" OnClick="btnEn15_Click"/>
                            <asp:Button ID="btnEn16" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN16" OnClick="btnEn16_Click"/>
                            <asp:Button ID="btnEn17" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN17" OnClick="btnEn17_Click"/>
                            <asp:Button ID="btnEn18" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN18" OnClick="btnEn18_Click"/>
                            <asp:Button ID="btnEn19" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN19" OnClick="btnEn19_Click"/>
                            <asp:Button ID="btnEn20" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EN20" OnClick="btnEn20_Click"/>
                            <asp:Label ID="LocateClick" runat="server" Text="" ForeColor="YellowGreen" Visible="true" ></asp:Label>
                            <asp:Label ID="lbchk9" runat="server" Text=""  Visible="true" ></asp:Label>
                        </div>
                    </div>
                    <div class="row" id="divEX" runat="server" visible="false">
                        <div class="col-md" >
                            <asp:Button ID="btnEx1" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX01"  OnClick="btnEx1_Click"/>
                            <asp:Button ID="btnEx2" CssClass="btn btn-dark btn-sm" runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX02"  OnClick="btnEx2_Click"/>
                            <asp:Button ID="btnEx3" CssClass="btn btn-dark btn-sm" runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX03"  OnClick="btnEx3_Click"/>
                            <asp:Button ID="btnEx4" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX04" OnClick="btnEx4_Click"/>
                            <asp:Button ID="btnEx5" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX05" OnClick="btnEx5_Click"/>
                            <asp:Button ID="btnEx6" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX06" OnClick="btnEx6_Click"/>
                            <asp:Button ID="btnEx7" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX07" OnClick="btnEx7_Click"/>
                            <asp:Button ID="btnEx8" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX08" OnClick="btnEx8_Click"/>
                            <asp:Button ID="btnEx9" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX09" OnClick="btnEx9_Click"/>
                            <asp:Button ID="btnEx10" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX10" OnClick="btnEx10_Click"/>
                            <asp:Button ID="btnEx11" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX11" OnClick="btnEx11_Click"/>
                            <asp:Button ID="btnEx12" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX12" OnClick="btnEx12_Click"/>
                            <asp:Button ID="btnEx13" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX13" OnClick="btnEx13_Click"/>
                            <asp:Button ID="btnEx14" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX14" OnClick="btnEx14_Click"/>
                            <asp:Button ID="btnEx15" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX15" OnClick="btnEx15_Click"/>
                            <asp:Button ID="btnEx16" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX16" OnClick="btnEx16_Click"/>
                            <asp:Button ID="btnEx17" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX17" OnClick="btnEx17_Click"/>
                            <asp:Button ID="btnEx18" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX18" OnClick="btnEx18_Click"/>
                            <asp:Button ID="btnEx19" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX19" OnClick="btnEx19_Click"/>
                            <asp:Button ID="btnEx20" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="46px" Height="30px" Font-Bold="true" Text="EX20" OnClick="btnEx20_Click"/>
                            
                        </div>
                    </div>
                    <div class="row" id="divBuilding1" runat="server" visible="false">
                        <div class="col-md" >
                            <asp:Button ID="btn41" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="60px" Height="30px" Font-Bold="true" Text="ห้องGen" OnClick="btn41_Click" />
                            <asp:Button ID="btn42" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="75px" Height="30px" Font-Bold="true" Text="ห้องเก็บของ" OnClick="btn42_Click" />
                            <asp:Button ID="btn44" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="71px" Height="30px" Font-Bold="true" Text="ห้องการเงิน" OnClick="btn44_Click" />
                            <asp:Button ID="btn45" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="65px" Height="30px" Font-Bold="true" Text="ห้องมั่นคง" OnClick="btn45_Click" />
                            <asp:Button ID="btn46" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="80px" Height="30px" Font-Bold="true" Text="ห้องล็อคเกอร์" OnClick="btn46_Click" />
                            <asp:Button ID="btn47" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="70px" Height="30px" Font-Bold="true" Text="ห้องอาหาร" OnClick="btn47_Click" />
                            <asp:Button ID="btn48" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="77px" Height="30px" Font-Bold="true" Text="ห้องServer" OnClick="btn48_Click" />
                            <asp:Button ID="btn49" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="68px" Height="30px" Font-Bold="true" Text="ห้องธุรการ" OnClick="btn49_Click" />
                            <asp:Button ID="btn50" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="75px" Height="30px" Font-Bold="true" Text="ห้องผู้จัดการ" OnClick="btn50_Click" />
                        </div>
                        
                    </div>
                    <div class="row" id="divBuilding2" runat ="server"  visible="false">
                        <div class="col-md">
                            
                            <asp:Button ID="btn51" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="73px" Height="30px" Font-Bold="true" Text="ห้องประชุม" OnClick="btn51_Click" />
                            <asp:Button ID="btn52" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="81px" Height="30px" Font-Bold="true" Text="ห้องแบตเตอรี่" OnClick="btn52_Click" />
                            <asp:Button ID="btn53" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="96px" Height="30px" Font-Bold="true" Text="ห้องควบคุมระบบ" OnClick="btn53_Click" />
                            <asp:Button ID="btn54" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="90px" Height="30px" Font-Bold="true" Text="ห้องควบคุมบัตร" OnClick="btn54_Click" />
                            <asp:Button ID="btn55" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="73px" Height="30px" Font-Bold="true" Text="ห้องพักผ่อน" OnClick="btn55_Click" />
                            <asp:Button ID="btn56" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="90px" Height="30px" Font-Bold="true" Text="ห้องระบบไฟฟ้า" OnClick="btn56_Click" />
                            <asp:Button ID="btn57" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="60px" Height="30px" Font-Bold="true" Text="ห้องTAG" OnClick="btn57_Click" />
                            <asp:Button ID="btn58" CssClass="btn btn-dark btn-sm " runat="server" Font-Size="Medium" Width="60px" Height="30px" Font-Bold="true" Text="ห้องUPS" OnClick="btn58_Click" />
                        </div>
                    </div>

               </div>
                <br />

<asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" BorderStyle="Solid" BorderColor="#ffcc99"  Height="800px" >
                <asp:GridView id="gridviewPM" runat="server"  
                    DataKeyNames="action_id"
                    AutoGenerateColumns="False"
                    OnRowDataBound="gridviewPM_RowDataBound" 
                    HeaderStyle-CssClass="text-center" RowStyle-CssClass="text-center" CellPadding="4" ForeColor="Black" GridLines="Both" BorderColor="White"
                >
                    <Columns>
                        <asp:TemplateField HeaderText="เลขครุภัณฑ์"   ControlStyle-Width="130px">
                            <ItemTemplate>
                                <asp:label ID="CodeEquipment" Font-Size="Smaller" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.equipment_no") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่ออุปกรณ์" ControlStyle-Width="200px">
                            <ItemTemplate>
                                <asp:label ID="EquipName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.equipment_nameth") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="บริเวณ" ControlStyle-Width="160px">
                            <ItemTemplate>
                                <asp:label ID="EquipPoint" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.comment") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ไม่ได้ PM" ControlStyle-Width="80px">
                            <ItemTemplate>
                                <asp:RadioButton id="rbtNoPM" runat="server" BorderColor="Green"   AutoPostBack="true" GroupName="OkOrBreak" OnCheckedChanged="rbtNoPM_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PM แล้วใช้งานปกติ" ControlStyle-Width="100px">
                            <ItemTemplate>
                                <asp:RadioButton id="rbtOK" runat="server" BorderColor="Green"   AutoPostBack="true" GroupName="OkOrBreak" OnCheckedChanged="rbtOK_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PM แล้วพบชำรุดเสียหาย" ControlStyle-Width="130px">
                            <ItemTemplate>
                                <asp:RadioButton id="rbtBreak" runat="server" BorderColor="Red"  AutoPostBack="true" GroupName="OkOrBreak" OnCheckedChanged="rbtBreak_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หมายเหตุ" ControlStyle-Width="150px">
                            <ItemTemplate>
                                <asp:TextBox ID="notepm" runat="server" text ='<%# DataBinder.Eval(Container, "DataItem.action_note") %>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ControlStyle-Width="10px">
                            <ItemTemplate>
                                <asp:label ID="EqipStat" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.action_stat") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ControlStyle-Width="50px">
                            <ItemTemplate>
                                <asp:label ID="EQid" runat="server"   Text='<%# DataBinder.Eval(Container, "DataItem.equipment_id") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle  BackColor="#005101" ForeColor="White" Font-Size="Large"></FooterStyle>
                        <HeaderStyle BackColor="#0a6901" Font-Underline="true" ForeColor="White" Font-Size="Large"/>
                        
                        <RowStyle BackColor="#ccffc9" ForeColor="#333333" Height="20px" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>

                 <asp:GridView id="gridviewpm2" runat="server"
                    DataKeyNames="equipment_id"   
                    AutoGenerateColumns="False"
                    HeaderStyle-Font-Bold="true"
                    OnRowDataBound="gridviewpm2_RowDataBound"
                    HeaderStyle-CssClass="text-center" RowStyle-CssClass="text-center" CellPadding="4" ForeColor="Black" GridLines="Both" BorderColor="White"
                >
                    <Columns>
                        <asp:TemplateField HeaderText="เลขครุภัณฑ์"  ControlStyle-Width="130px">
                            <ItemTemplate>
                                <asp:label ID="CodeEquipment2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.equipment_no") %>' ></asp:label>
                            </ItemTemplate>
                            <ControlStyle Width="130px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่ออุปกรณ์" ControlStyle-Width="200px" >
                            <ItemTemplate >
                                <asp:label ID="EquipName2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.equipment_nameth") %>' ></asp:label>
                            </ItemTemplate>
                            <ControlStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="บริเวณ"  ControlStyle-Width="160px">
                            <ItemTemplate>
                                <asp:label ID="EquipPoint2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.comment") %>' ></asp:label>
                            </ItemTemplate>
                            <ControlStyle Width="160px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ไม่ได้ PM" ControlStyle-Width="80px">
                            <ItemTemplate>
                                <asp:RadioButton id="rbtNoPM2" runat="server" BorderColor="Green" AutoPostBack="true" OnCheckedChanged="rbtNoPM2_CheckedChanged"   GroupName="OkOrBreak2" />
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PM แล้วใช้งานปกติ" ControlStyle-Width="100px">
                            <ItemTemplate>
                                <asp:RadioButton id="rbtOK2" runat="server" BorderColor="Green" AutoPostBack="true" OnCheckedChanged="rbtOK2_CheckedChanged"   GroupName="OkOrBreak2" />
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PM แล้วพบชำรุดเสียหาย" ControlStyle-Width="130px">
                            <ItemTemplate>
                                <asp:RadioButton id="rbtBreak2" runat="server" BorderColor="Red" AutoPostBack="true"  OnCheckedChanged="rbtBreak2_CheckedChanged" GroupName="OkOrBreak2" />
                            </ItemTemplate>
                            <ControlStyle Width="130px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หมายเหตุ" ControlStyle-Width="150px">
                            <ItemTemplate>
                                <asp:TextBox ID="notepm2" runat="server" text ='<%# DataBinder.Eval(Container, "DataItem.action_note") %>' ></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ControlStyle-Width="10px">
                            <ItemTemplate>
                                <asp:label ID="EqipStat2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.action_stat") %>' ></asp:label>
                            </ItemTemplate>
                            <ControlStyle Width="10px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ControlStyle-Width="50px">
                            <ItemTemplate>
                                <asp:label ID="EQid2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.equipment_id") %>' ></asp:label>
                            </ItemTemplate>
                            <ControlStyle Width="50px" />
                        </asp:TemplateField>

                    </Columns>
                    
                    <FooterStyle  BackColor="#005101" ForeColor="White" Font-Size="Large"></FooterStyle>
                        <HeaderStyle BackColor="#eb8802" Font-Underline="true" ForeColor="White" Font-Size="Large"/>
                        <RowStyle BackColor="#ffe8c9" ForeColor="#333333" Height="20px" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
    
  </asp:Panel>                  

                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="resultChecked" runat="server" Text="" ></asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md text-center" >
                        <asp:Button ID="btnSavelocate" runat="server" Text="บันทึก" Font-Size="Large" CssClass="btn btn-warning btn-sm text-center" OnClick="btnSavelocate_Click" />
                    </div>
                </div>


              <br />
                    
    


        </div>

    </div>

</div>
</ContentTemplate>
</asp:UpdatePanel>
    <div class="card shadow-lg" style="font-size: 19px; z-index: 0;" runat="server" id="DivImg" visible="false">
<div class="card-body table-responsive">
    <asp:Label ID="lbHeadImg" runat="server" Text="แนบรูปภาพการปฏิบัติงาน" Font-Size="Larger" Font-Bold="true"  ForeColor="#800000"></asp:Label>
                    &nbsp&nbsp<asp:Label ID="Label2" runat="server"  ForeColor="#ff0000" Font-Size="Large" BackColor="#ffffcc"  Text="( 1.กดที่คำว่า 'เลือกภาพ' --> 2.เลือกภาพแล้วกดปุ่ม 'แนบ' )"></asp:Label><br />

                <div class="row">
                    <div class="col-md-3">
                        <div class="custom-file">
                            <label class="custom-file-label" for="customFile">เลือกภาพ</label>
                            <asp:FileUpload ID="ImgPM" runat="server" CssClass="custom-file-input" lang="en"  />
                        </div>
                    </div>
                    <div class="col-md-1">
                        <asp:LinkButton ID="btnAddImagePM" runat="server" Text="&#xf0c6; แนบ"  Font-Size="Small" CssClass="btn btn-success btn-sm fa"  OnClick="btnAddImagePM_Click" />
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-5">
                        <asp:GridView ID="PMImageGridView" runat="server"
                            DataKeyNames="MAimg_id"
                            GridLines="Both"
                            OnRowDataBound="PMImageGridView_RowDataBound"
                            OnRowDeleting="PMImageGridView_RowDeleting"
                            AutoGenerateColumns="False"
                            CssClass="table table-hover table-sm"
                             HeaderStyle-Font-Bold="true" RowStyle-CssClass="table-success" >
                            <Columns>
                                <asp:TemplateField HeaderText="รูปภาพประกอบ">
                                    <ItemTemplate>
                                        <asp:Image ID="ImgPM" runat="server" Width="200px"   />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Download">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDownload" runat="server" Font-Size="Small" CssClass="fa" OnCommand="lbtnDownload_Command">&#xf0ed; Download</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:CommandField ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Small"  />
                            </Columns>
                        </asp:GridView>


                        <asp:Label ID="lbAmountImg" runat="server" Text=""></asp:Label>
                        <br/>
                        <hr />

                        <asp:Label ID="checkimagevalues" runat="server" Text="" Visible="false" ></asp:Label>
                </div>
            </div>
            <br />
                <div class="row">
                    <div class="col-md text-center" >
                        <asp:Button ID="ComSubmit" Text="บันทึกการ PM" OnClick="ComSubmit_Click" OnClientClick="return ConfirmToAdd();" Font-Size="Larger"   runat="server" Font-Bold="true" CssClass="btn btn-success " Width="200px" Height="60px" />
                        <asp:Button ID="AdminCheck" Visible="false" OnClick="AdminCheck_Click" OnClientClick="return ConfirmToAddX();" Text="ตรวจสอบระบบถูกต้อง" Font-Size="Larger" runat="server" Font-Bold="true" CssClass="btn btn-primary " Width="200px" Height="60px" />
                        <asp:Button ID="AdComplete" Visible="false" OnClick="AdComplete_Click" OnClientClick="return ConfirmToAddํ();" Text="ใบเซอร์วิสถูกต้องกับระบบ" Font-Size="Larger" runat="server" Font-Bold="true" CssClass="btn btn-success" Width="200px" Height="60px" />
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
        <% } %>  });
    </script>
    <script type = "text/javascript">
    window.onload = function () {
        document.onkeydown = function (e) {
            return (e.which || e.keyCode) != 116;
        };
    }
    </script>
    <script>
        function ConfirmToAdd()
        {
            if (confirm('ยืนยันบันทึกการPMใช่หรือไม่ ?')) {
                return true;
            }
            else { return false; }
        }
    </script>
    <script>
        function ConfirmToAddX()
        {
            if (confirm('ยืนยันบันทึกการตรวจสอบใช่หรือไม่ ?')) {
                return true;
            }
            else { return false; }
        }
    </script>
    <script>
        function ConfirmToAddY()
        {
            if (confirm('ใบเซอร์วิสถูกต้องกับระบบใช่หรือไม่ ?')) {
                return true;
            }
            else { return false; }
        }
    </script>


</asp:Content>
