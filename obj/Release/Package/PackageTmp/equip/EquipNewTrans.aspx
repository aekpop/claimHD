<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="EquipNewTrans.aspx.cs" Inherits="ClaimProject.equip.EquipNewTrans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <asp:Button runat="server" ID="btnMainEQ"  Font-Bold="true" BackColor="#c44602" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="หน้าหลักครุภัณฑ์"  OnClick="btnMainEQ_Click" CssClass="btn" />
    <asp:Button runat="server" ID="btnMainTranSend" Visible="false" Font-Bold="true" BackColor="#02acbd" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="หน้ารายการ(ส่ง)ครุภัณฑ์"  OnClick="btnMainTranSend_Click" CssClass="btn" />
    <asp:Button runat="server" ID="btnMainTranGet" Visible="false" Font-Bold="true" BackColor="#02acbd" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="หน้ารายการ(รับ)ครุภัณฑ์"  OnClick="btnMainTranGet_Click" CssClass="btn" />
    <div  class="card" style="font-size: 19px; z-index: 0;" runat="server" >

        <h3 class="bg form-control"  style="font-size:30px;color:white;height:60px;background-color:darkcyan">&nbsp;&nbsp;โอนย้ายครุภัณฑ์</h3>
        
        <div id="divtranFirst" class="card-body table-responsive" style="padding-top:1px" runat="server">
           <h3 class="card-title alert-warning" style="font-size:22px;">ส่วนที่1 : รายละเอียด   <asp:Label ID="refnoo" runat="server" Font-Size="Large" CssClass="text-right"></asp:Label><asp:Label ID="stathead" runat="server" CssClass="" Font-Size="Medium" ></asp:Label>)</h3>
            <div class="row" id="divhitback" runat="server" visible="false" style="padding:1px 1px 1px 20px;height:60px"  >
                <asp:TextBox ID="NoteHitback" BackColor="#ffffcc" BorderColor="#e1e1e1" runat="server" Width="800px"  ForeColor="Red" Font-Bold="true" Font-Size="Large"  TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="row" style="padding:1px 1px 1px 1px;height:80px"  >
                <div class="form-group bmd-form-group col-md-2" style="padding:1px 20px 1px 20px;">
                    <label class="bmd-label-floating" style="font-size:20px;height:5px">ประเภทการโอนย้าย</label>
                       <asp:DropDownList ID="ddlTypeEQQ" OnSelectedIndexChanged="ddlTypeEQQ_SelectedIndexChanged" AutoPostBack="true" runat="server" BackColor="#dbfff8" ForeColor="Black"  CssClass="form-control"  ></asp:DropDownList>
                </div>
                <div class="form-group bmd-form-group col-md-2" id="divfirst" runat="server"  style="padding:1px 1px 1px 15px;">
                       <label class="bmd-label-floating" style="font-size:20px;height:5px">ต้นทาง</label>
                       <asp:DropDownList ID="ddlStartEQ" runat="server"  CssClass="form-control"  ></asp:DropDownList>
                  </div>
                <div class="form-group bmd-form-group col-md-2" id="divsecond" runat="server" visible="false" style="padding:1px 1px 1px 15px;">
                       <label class="bmd-label-floating" style="font-size:20px;height:5px">ต้นทาง</label>
                       <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="form-control"  ></asp:DropDownList>
                  </div>
                <div class="form-group bmd-form-group col-md-2" id="divEndToll" runat="server" visible="false" style="padding:1px 1px 1px 15px;">
                       <label class="bmd-label-floating" style="font-size:20px;height:5px">ปลายทาง</label>
                       <asp:DropDownList ID="ddlTollEQ" runat="server"  CssClass="form-control"  ></asp:DropDownList>
                  </div>
                <div class="form-group bmd-form-group col-md-3" id="divcompany" runat="server" visible="false" style="padding:1px 1px 1px 15px;">
                       <label class="bmd-label-floating" style="font-size:20px;height:5px">ส่งซ่อม</label>
                       <asp:DropDownList ID="ddlcompany" runat="server"  CssClass="form-control"  ></asp:DropDownList>
                  </div>
                <div class="form-group bmd-form-group col-md-2"  style="padding:1px 15px 1px 15px;" >
                     <label class="bmd-label-floating" style="font-size:large;height:10px">วันที่โอนย้าย</label>
                     <asp:TextBox runat="server" ID="txtDateSend"  CssClass="form-control datepicker" ></asp:TextBox>
               </div>
            </div>
            <div class="row" style="padding:1px 1px 1px 1px;height:140px"  >
                
                <div  class="form-group bmd-form-group col-md-2" style="padding:1px 15px 1px 20px;">
                    <label class="bmd-label-floating" style="font-size:20px;height:5px">ระบุหมายเหตุ(ถ้ามี)</label>
                    <asp:TextBox ID="txtactnote" runat="server" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="form-group bmd-form-group col-md-2" style="padding:1px 1px 1px 15px;" >
                    <label class="bmd-label-floating" style="font-size:large;height:10px">ชื่อผู้โอนย้าย</label>
                    <asp:TextBox ID="txtSender" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class ="form-group bmd-form-group col-md-4" style="padding:1px 50px 1px 15px;width:300px" >
                    <label class="bmd-label-floating" style="font-size:large;height:10px">ตำแหน่งผู้โอนย้าย</label>
                    <asp:DropDownList ID="ddlPosition" runat="server"  CssClass="form-control"></asp:DropDownList>
                </div>

            </div>
            <div id="divSubmitFirst" runat="server" class="row">
                <div class="col-md text-center" >
                    <asp:Button ID="btnFistSubmit" runat="server" Text="ต่อไป" Visible="true" Font-Size="Larger" OnClick="btnFistSubmit_Click" CssClass="btn btn-success" />
                </div>
            </div>

            </div>

        <div id="divtranSecond" visible="false" class="card-body table-responsive"  runat="server">
            <h3 class="card-title alert-warning" style="font-size:22px;">ส่วนที่2 : รายการครุภัณฑ์</h3>

            <div class="row" id="divnewserial" runat="server" visible="false" style="padding:1px 1px 20px 1px;height:115px"  >
                <div class="form-group bmd-form-group col-md-3"  style="padding:1px 20px 1px 20px;">
                    <label class="bmd-label-floating"  style="font-size:20px;height:2px">ใส่เลขทะเบียนใหม่(Serial Number)</label>
                      <asp:TextBox ID="txtNewSerial" runat="server"  BackColor="#ffffcc" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="form-group bmd-form-group col-md-2" id="diviconchk" runat="server" style="padding-top:30px;">
                    <asp:LinkButton ID="chknewSEE" runat="server" ToolTip="เพิ่มรายการ" Font-Size="XX-Large" CssClass="fa fa-search" OnCommand="chknewSEE_Command"></asp:LinkButton>
                </div>
                <div class="form-group bmd-form-group col-md-3" id="diviconchkAgain" runat="server" visible="false" style="padding-top:26px;">
                    <asp:Button ID="chkSEAgain" runat="server" Width="120px" Text="<<-แก้ไขเลข" BackColor="#006666" CssClass="btn form-control" OnClick="chkSEAgain_Click" />
                </div>

            </div>

            <div class="row " id="divnormal" runat="server"  style="padding:15px 1px 1px 15px;background-color:lightcyan;height:80px">
                <div class="col-md-2" style="padding:1px 5px 1px 8px;width:100px">
                    <asp:Label ID="lbEQtranAdd" runat="server" Text="เพิ่มรายการครุภัณฑ์ ->" ForeColor="#990000" Font-Bold="true"  ></asp:Label>
                </div>
                <div class="col-md-3" style="padding-left:5px;width:180px;enable-background:initial;">
                    <asp:DropDownList ID="txtEquipTrans" runat="server" CssClass="combobox form-control custom-select" ></asp:DropDownList>
                </div>
                <div class="col-md-1" style="padding:1px 1px 1px 1px">
                   <asp:LinkButton ID="btnAddEQTran" runat="server" ToolTip="เพิ่มรายการ" Font-Size="XX-Large" CssClass="fas text-success" OnCommand="btnAddEQTran_Command" OnClientClick="return UpdteConfirm('ยืนยันเลือกเลขครุภัณฑ์นี้ ใช่หรือไม่');">&#xf055;</asp:LinkButton>
                </div>
            </div>
            <div class="row " id="divreplace" runat="server" visible="false" style="padding:14px 1px 1px 15px;background-color:lemonchiffon;height:80px">
                <div class="col-md-2" style="padding:1px 5px 1px 8px;width:100px">
                    <asp:Label ID="Label1" runat="server" Text="เลือกครุภัณฑ์ที่ทดแทน ->" ForeColor="#990000" Font-Bold="true"  ></asp:Label>
                </div>
                <div class="col-md-3" style="padding-left:5px;width:180px;enable-background:initial;">
                    <asp:DropDownList ID="ddlreplace" runat="server" CssClass="combobox form-control custom-select" ></asp:DropDownList>
                </div>
                <div class="col-md-1" style="padding:1px 1px 1px 1px">
                   <asp:LinkButton ID="lbtnreplace" runat="server" ToolTip="เพิ่มรายการ" Font-Size="XX-Large" CssClass="fas text-warning" OnCommand="lbtnreplace_Command" OnClientClick="return UpdteConfirm('ยืนยันเลือกเลขครุภัณฑ์นี้ ใช่หรือไม่');">&#xf055;</asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row" style="padding-left:15px;" >
                <asp:Label ID="lbshowamount" runat="server"  ></asp:Label>
            </div>
                <asp:gridview ID="GridAddTran" runat="server" DataKeyNames="trans_act_id"
                    ShowFooter="true"  GridLines="Both" BorderColor="White"  Font-Size="20px" 
                    AutoGenerateColumns="false" OnRowDataBound="GridAddTran_RowDataBound" OnRowDeleting="GridAddTran_RowDeleting"> 
                    <AlternatingRowStyle BackColor="#edebec" />
                    <Columns>
                        <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-center" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขครุภัณฑ์" ItemStyle-Width="200px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="TextBox1"   runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_no") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="รายการ" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="TextBox2"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_nameth") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ยี่ห้อ" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="TextBox3"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_brand") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField  ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Small" />
                    </Columns>
                    <FooterStyle BackColor="#c8ffc4" Font-Bold="True" CssClass="text-center" ForeColor="#0a7802" />
                    <HeaderStyle BackColor="#c8ffc4" CssClass="text-center"   ForeColor="#0a7802" />
                    <RowStyle BackColor="#f3fff0"  />
                
                </asp:gridview>


            <asp:gridview ID="gridreplace" runat="server" DataKeyNames="trans_act_id"
                    ShowFooter="true"  GridLines="Both" BorderColor="White"  Font-Size="20px" 
                    AutoGenerateColumns="false" OnRowDataBound="gridreplace_RowDataBound" OnRowDeleting="gridreplace_RowDeleting"> 
                    <AlternatingRowStyle BackColor="#edebec" />
                    <Columns>

                        <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbnumreplace" runat="server" Text="" CssClass="text-center" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขครุภัณฑ์" ItemStyle-Width="200px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="txteqno"   runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_no") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="รายการ" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="txteqlist"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_nameth") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ยี่ห้อ" ItemStyle-Width="200px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="txteqbrand"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_brand") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขทะเบียนเดิม" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="txtoldserial"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_serial") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขทะเบียนใหม่" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="txtnewserialz"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.new_serial") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Small" />
                    </Columns>
                    <FooterStyle BackColor="#e8ba23" Font-Bold="True" CssClass="text-center" ForeColor="white" />
                    <HeaderStyle BackColor="#e8ba23" CssClass="text-center"   ForeColor="#000000" />
                    <RowStyle BackColor="#fff0c2"  />
                
                </asp:gridview>
  <asp:UpdatePanel runat="server">
                <ContentTemplate>
            <asp:gridview ID="GridRepair" runat="server" DataKeyNames="trans_act_id"
                    ShowFooter="true"  GridLines="Both" BorderColor="White"  Font-Size="20px" 
                    AutoGenerateColumns="false" OnRowDataBound="GridRepair_RowDataBound"
                    HeaderStyle-CssClass="text-center" RowStyle-CssClass="text-center" 

                    > 
                    <AlternatingRowStyle BackColor="#d5c7ff" />
                    <Columns>

                        <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbnumrepair" runat="server" Text="" CssClass="text-center" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขครุภัณฑ์" ItemStyle-Width="200px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="txteqno"   runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_no") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="รายการ" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="txteqlist"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_nameth") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ยี่ห้อ" ItemStyle-Width="200px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="txteqbrand"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_brand") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขทะเบียนเดิม" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="txtoldserial"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_serial") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขทะเบียนใหม่" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="txtnewserialz"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.new_serial") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        
                        <asp:TemplateField HeaderText="รอซ่อม" ControlStyle-Width="80px">
                            <ItemTemplate>
                                <asp:RadioButton id="rdtWait" runat="server" BorderColor="#d1d1d1" AutoPostBack="true" OnCheckedChanged="rdtWait_CheckedChanged"   GroupName="OkOrBreak2" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbtotalWait" runat="server" ></asp:Label>
                            </FooterTemplate>
                            <ControlStyle Width="100px" />
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ซ่อมไม่ได้" ControlStyle-Width="80px">
                            <ItemTemplate>
                                <asp:RadioButton id="rdtNoRepair" runat="server" BorderColor="#ffe3e3" AutoPostBack="true" OnCheckedChanged="rdtNoRepair_CheckedChanged"   GroupName="OkOrBreak2" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbtotalNo" runat="server" ></asp:Label>
                            </FooterTemplate>
                            <ControlStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ซ่อมเรียบร้อย" ControlStyle-Width="80px">
                            <ItemTemplate>
                                <asp:RadioButton id="rdtRepaired" runat="server" BorderColor="#e3ffe3" AutoPostBack="true" OnCheckedChanged="rdtRepaired_CheckedChanged"   GroupName="OkOrBreak2" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbtotalRepaired" runat="server" ></asp:Label>
                            </FooterTemplate>
                            <ControlStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ControlStyle-Width="10px">
                            <ItemTemplate>
                                <asp:label ID="RepairStat" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.repair_action") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ControlStyle-Width="50px">
                            <ItemTemplate>
                                <asp:label ID="ActID" runat="server"   Text='<%# DataBinder.Eval(Container, "DataItem.trans_act_id") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ControlStyle-Width="50px">
                            <ItemTemplate>
                                <asp:label ID="EQIDf" runat="server"   Text='<%# DataBinder.Eval(Container, "DataItem.trans_equip_id") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#3d2063" Font-Bold="True" CssClass="text-center" Height="25px" ForeColor="white" />
                    <HeaderStyle BackColor="#3d2063" CssClass="text-center"   ForeColor="white" />
                    <RowStyle BackColor="#e8e0ff"  />
                
                </asp:gridview>
</ContentTemplate>
</asp:UpdatePanel>

            <div class="row" style="padding-left:15px;padding-top:5px;" >
                <asp:Label ID="txtstatcount" runat="server"  ></asp:Label>
                <asp:Label ID="lbchkWait" runat="server" Visible="false" ></asp:Label>
                <asp:Label ID="lbchkTotal" runat="server" Visible="false" ></asp:Label>
            </div>



            <br />
            <div class="row">
                <div class="col-md text-center" >
                    <asp:Button ID="btnPlanSheet" runat="server" Visible="false" Text="บันทึกฉบับร่าง" Font-Size="Larger" OnClick="btnPlanSheet_Click" CssClass="btn btn-info"  />
                    <asp:Button ID="btnSendRepair" runat="server" Visible="false" Text="บันทึกและส่งซ่อม" Font-Size="Larger" OnClick="btnSendRepair_Click" CssClass="btn" BackColor="#50009f" OnClientClick="return UpdteConfirm('ยืนยันแจ้งส่งซ่อม ใช่หรือไม่');" />
                    <asp:Button ID="btnSecondSubmit" runat="server" Visible="false" Text="บันทึกและส่งข้อมูลไปยังปลายทาง" Font-Size="Larger" OnClick="btnSecondSubmit_Click" CssClass="btn btn-success" OnClientClick="return UpdteConfirm('ยืนยันบันทึกและส่งข้อมูลไปปลายทาง ใช่หรือไม่');" />
                    <asp:Button ID="btnEdit" runat="server" Visible="false" Text="ดึงเรื่องกลับแก้ไข" Font-Size="Larger" OnClick="btnEdit_Click" CssClass="btn btn-warning" />
                    <asp:Button ID="btnGet" runat="server" Visible="false" Text="ยืนยันรับเรียบร้อย" Font-Size="Larger" OnClick="btnGet_Click" CssClass="btn btn-success"  />
                    <asp:Button ID="btnRepaired" runat="server" Visible="false" Text="บันทึก/อัพเดทรายการส่งซ่อม" Font-Size="Larger" OnClick="btnRepaired_Click" CssClass="btn btn-success"  />
                    <asp:Button ID="btnBackto" runat ="server" Visible="false" Text="ตีกลับต้นทาง" Font-Size="Larger" OnClick="btnBackto_Click" CssClass="btn btn-danger" />
                    <asp:LinkButton ID="lbtnDelete" runat="server" Visible="false"  CssClass="btn btn-danger " Font-Size="Larger" OnCommand="lbtnDelete_Command" OnClientClick="return UpdteConfirm('ยืนยันลบรายการทั้งหมด ใช่หรือไม่');">ลบ</asp:LinkButton>                
                </div>
            </div>
        </div>
        
    </div>
     <div class="modal fade " id="ReplaceModal"   tabindex="-1" role="dialog" aria-labelledby="ReplaceModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered " style="width:600px"  role="form">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"> เลขครุภัณฑ์ที่ถูกทดแทน : 
                        <asp:Label ID="lbreplaceeqide" runat="server" Text="" ForeColor="#ffffcc" CssClass="text-dark"></asp:Label></h4>
                    <asp:Label ID="pkreplace" runat="server" ForeColor="#ffffe1" Font-Size="Smaller" ></asp:Label>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style="line-height: inherit;">
                    
                    <div class="row" style="height: 90px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ชื่อครุภัณฑ์(ไทย)</label>
                                <asp:TextBox ID="txtreThai" Enabled="false" runat="server" Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ชื่อครุภัณฑ์(อังกฤษ)</label>
                                <asp:TextBox ID="txtreEng" Enabled="false" runat="server" Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                    </div>

                    <div class="row" style="height: 90px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ยี่ห้อ(เก่า)</label>
                                <asp:TextBox ID="txtrebrand"  runat="server" Enabled="false"  Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ยี่ห้อ(ใหม่)</label>
                                <asp:TextBox ID="txtNewbrandRe"  runat="server" BackColor="#ffffd7"  Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                   </div>     
                    <div class="row" style="height: 90px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">รุ่น(เก่า)</label>
                                <asp:TextBox ID="txtreSeries"  runat="server" Enabled="false" Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                        
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">รุ่น(ใหม่)</label>
                                <asp:TextBox ID="txtNewSeriesRe"  runat="server" BackColor="#ffffd7" Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                        
                    </div>

                    <div class="row" style="height: 90px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">สถานที่(เก่า)</label>
                                <asp:TextBox ID="ddlReEoldLocate"  runat="server" Enabled="false" Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">สถานที่(ใหม่)</label>
                                <asp:DropDownList ID="ddlNewLocated" runat="server" BackColor="#ffffd7" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="height: 90px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เลขทะเบียนเก่า</label>
                                <asp:TextBox ID="txtReoldSerial"  runat="server" Enabled="false" Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เลขทะเบียนใหม่</label>
                                <asp:TextBox ID="txtRenewSerial"  runat="server" Enabled="false" BackColor="#ffffd7" Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">หมายเหตุ</label>
                                <asp:TextBox ID="txtReNote"  runat="server" BackColor="#ffffd7"  Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="lbtnSubreplace" runat="server" CssClass="btn btn-success btn-sm" Font-Size="Medium" OnCommand="lbtnSubreplace_Command" OnClientClick="return UpdteConfirm('ยืนยันบันทึก ใช่หรือไม่');">ยืนยันบันทึก</asp:LinkButton>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" style="font-size: medium">ยกเลิก</button>
                </div>
            </div>
        </div>
    </div>
       
    <div class="modal fade " id="modalConfirmGet"   tabindex="-1" role="dialog" aria-labelledby="modalConfirmGet" aria-hidden="true">
        <div class="modal-dialog modal-sm modal-dialog-centered " style="width:1000px" role="form">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"> กรุณาเลือกตำแหน่งของท่านเพื่อยืนยัน</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style="line-height: inherit;">
                    
                    <div class="row" style="height: 90px">
                        <div class="col-md text-center">
                            <asp:DropDownList ID="ddlposGet" runat="server" ></asp:DropDownList>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="lbtnGet" runat="server" CssClass="btn btn-success btn-sm" Font-Size="Medium" OnCommand="lbtnGet_Command" OnClientClick="return UpdteConfirm('ยืนยันบันทึก ใช่หรือไม่');">ยืนยันบันทึก</asp:LinkButton>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" style="font-size: medium">ยกเลิก</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade " id="modalHitBack"   tabindex="-1" role="dialog" aria-labelledby="modalHitBack" aria-hidden="true">
        <div class="modal-dialog modal-sm modal-dialog-centered "  style="width:600px" role="form">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"> กรุณาใส่หมายเหตุการตีกลับต้นทาง</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style="line-height: inherit;">
                    
                    <div class="row" style="height: 120px">
                        <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เหตุผลการตีกลับเอกสาร</label>
                                <asp:TextBox ID="txtEditNote"  runat="server" Font-Size="Medium" TextMode="MultiLine" CssClass="form-control time" />
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="lbtnBack" runat="server" CssClass="btn btn-success btn-sm" Font-Size="Medium" OnCommand="lbtnBack_Command" OnClientClick="return UpdteConfirm('ยืนยันตีกลับเอกสาร ใช่หรือไม่');">ยืนยันตีกลับ</asp:LinkButton>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" style="font-size: medium">ยกเลิก</button>
                </div>
            </div>
        </div>
    </div>




    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript"> 
        $(function () {
        <% if (alerts != "")
        { %>
            demo.showNotification('top', 'center', '<%=icons%>', '<%=alertTypes%>', '<%=alerts%>');
        <% } %>
        });
        $(function () {
            <% if (replaceids != "")
        {%>
            $("#ReplaceModal").modal('show');
            <%}
        else
        {%>
            $("#ReplaceModal").modal('hide');
            <%}%>
            
        });
        $(function () {
            <% if (confirmGet != "")
        {%>
            $("#modalConfirmGet").modal('show');
            <%}
        else
        {%>
            $("#modalConfirmGet").modal('hide');
            <%}%>
            
        });
        $(function () {
            <% if (HitBack != "")
        {%>
            $("#modalHitBack").modal('show');
            <%}
        else
        {%>
            $("#modalHitBack").modal('hide');
            <%}%>
            
        });
        function UpdteConfirm(msg) {
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
