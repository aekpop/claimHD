<%@ Page Title="งานครุภัณฑ์ / รายการครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipAdd.aspx.cs" Inherits="ClaimProject.equip.EquipAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }
        .alert {
            font-size:26px;
            font-family: 'Prompt';
        }
        
    </style>

    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <link href="../Content/form-design-new.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <div class="container-fluid" style="font-family:'Prompt',sans-serif; ">
        <!-- Menu Dropdown -->        
        <div class="btn-group" runat="server" visible="false">
              <button class="btn btn-info"><i class="fas fa-align-justify"></i></button>
              <button class="btn dropdown-toggle btn-info" data-toggle="dropdown">
                <span class="caret"></span>
              </button>
              <ul class="dropdown-menu">
                <li><a href="/equip/EquipDefault">หน้าหลัก</a></li>
                <li><a href="/equip/EquipAdd">ค้นหา</a></li>
                <li><a href="/equip/EquipTranList">ส่งครุภัณฑ์</a></li>
                <li><a href="/equip/EquipTranGetList">รับครุภัณฑ์</a></li>
                <li><asp:LinkButton id="divaddnew" runat="server" href="/equip/EquipAddAll" visible="true">เพิ่มครุภัณฑ์ใหม่</asp:LinkButton></li>
                <li><asp:LinkButton id="divcheckk" runat="server" href="/equip/EquipCheckList" visible="true">การโอนย้าย(ด่านฯ)</asp:LinkButton></li>
                <li><asp:LinkButton id="divcheckkk" runat="server" href="/equip/EquipHistory" visible="true">ประวัติโอนย้าย</asp:LinkButton></li>
              </ul>
        </div>
        <!------------------>
    <div id="AddPM" runat="server" class="card" style="z-index: 0; font-size:medium">

        <div class="card-header ">
            <div class="card-title " style="font-size:larger">ค้นหา</div>
        </div>        
            <div class="card-body table-responsive table-sm">
                
                <div id="divsearch" runat="server">
                    <div class="row text-right">
                            <div class="col-md-2 lg-2" >
                                <asp:Label ID="Label1" runat="server" Text="ชื่อครุภัณฑ์ :" Font-Bold="true" ></asp:Label>
                            </div>
                        <div class="col-md-2 lg-2">
                                <asp:TextBox ID="txtsearchth"  CssClass="form-control" runat="server" BorderStyle="NotSet" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                            </div>
                
                        <div class="col-md-1 lg-1" >
                                <asp:Label ID="Label2" runat="server" Text="เลขครุภัณฑ์ :"  Font-Bold="true" ></asp:Label>
                            </div>
                        <div class="col-md-3 lg-3">
                                <asp:TextBox ID="txtsearchNum"  CssClass="form-control" runat="server" BorderStyle="NotSet" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                               </div>

                        <div class="col-md-1 col-lg-1" >

                                <asp:Label ID="Label4" runat="server" Text="เลขทะเบียน :" Font-Bold="true" ></asp:Label>
                            </div>
                            <div class="col-md-3 lg-3">
                                <asp:TextBox ID="txtsearchSerial"  CssClass="form-control" runat="server" BorderStyle="NotSet"  onkeypress="return handleEnter(this, event)"></asp:TextBox>

                            </div>
                    </div>
                    <br />
                        <div class="row">
                                    <div class="col-md-2 col-lg-2 text-right" >

                                            <asp:Label ID="Label6" runat="server" Text="สถานะ :" Font-Bold="true" ></asp:Label>
                                        </div>
                                    <div class="col-md-2 lg-2">
                                            <asp:DropDownList ID="ddlsearchStat" runat="server"  CssClass="form-control" ></asp:DropDownList>
                               
                                 </div>
                                <div class="col-md-1 col-lg-1 text-right" >
                            
                                            <asp:Label ID="Label5" runat="server" Text="ด่านฯ :"  Font-Bold="true" ></asp:Label>
                                    </div>
                                    <div class="col-md-3 lg-3">
                                            <asp:DropDownList ID="ddlcpoint" runat="server"  OnSelectedIndexChanged="ddlcpoint_SelectedIndexChanged" AutoPostBack="true"  CssClass="form-control" ></asp:DropDownList>
                                
                                 </div>

                         
                                <div id="divAnex" runat="server" visible="false" class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-3 text-right">
                                            <asp:Label ID="Label3" runat="server" Text="อาคาร :"  Font-Bold="true" ></asp:Label>
                                    </div>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlserchToll" runat="server"  CssClass="form-control"  ></asp:DropDownList>
                                        </div>
                                    </div>
                               </div>
                         </div>
                     </div>
                   <br />
                        <div class="row">
                            <div class="col-md-6 text-right" >                               
                                   <asp:Button ID="searchEquip" runat="server" Text="&#xf002; ค้นหา" CssClass="fa btn btn-info btn-sm" Font-Bold="true" Font-Size="Large" OnClick="searchEquip_Click" />                                
                            </div>                                                   
                                <div id="divSagain" runat="server" visible="false" class="col-md-6">
                                         <asp:Label ID="chkS" runat="server" font-size="Small" ></asp:Label>
                                                 <asp:LinkButton ID="lbtnTollReport"  runat="server" Text="ออกรายงาน" Visible="false" ToolTip="พิมพ์" CssClass="btn btn-dark btn-sm" Font-Bold="true" Font-Size="Large"  OnCommand="lbtnTollReport_Command"></asp:LinkButton>
                                                        <asp:LinkButton ID="lbtnDepartReport" runat="server" Text="ออกรายงาน" Visible="false" ToolTip="พิมพ์" CssClass="btn btn-dark btn-sm"  Font-Bold="true" Font-Size="Large"  OnCommand="lbtnDepartReport_Command"></asp:LinkButton>
                                </div>
                         </div>
                   </div>
           </div>

        <div id="equip" runat="server" visible="false" class="card" >
        <div class="card-header ">
            <div class="card-title " style="font-size:larger">รายการครุภัณฑ์</div>
        </div>
        <div class="card-body" style="font-size:medium; font-family:'TH SarabunPSK'; ">
          <asp:Panel ID="Panel1" runat="server" > 
            <asp:GridView ID="GridEquipAdd" runat="server"
            DataKeyNames="equipment_id"
            OnRowDataBound="GridEquipAdd_RowDataBound"
            CssClass="table table-responsive-md table-hover table-condensed table-sm"
            HeaderStyle-Font-Size="28px"
            HeaderStyle-Height="50px"
            RowStyle-Height="50px"
            Font-Size="24px"
            AutoGenerateColumns="False" 
            OnPageIndexChanging="GridEquipAdd_PageIndexChanging" 
            PagerSettings-Mode="NumericFirstLast" 
            PageSize="100" 
            PagerSettings-FirstPageText="หน้าแรก"  PagerSettings-LastPageText="หน้าสุดท้าย"
            AllowPaging="true"
            HeaderStyle-CssClass="text-center" RowStyle-CssClass="text-center" CellPadding="4" BorderColor="White" ForeColor="#000000" GridLines="None">
                
                <Columns>
                    
                    <asp:TemplateField HeaderText="ลำดับ" >
                        <ItemTemplate >
                            <%# Container.DataItemIndex + 1+"." %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อครุภัณฑ์" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEquipthai" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.equipment_nameth") %>' OnCommand="btnEditEquip_Command" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="เลขครุภัณฑ์"  >
                        <ItemTemplate>
                            <asp:LinkButton ID="lbequipNo" runat="server"   Text='<%# DataBinder.Eval(Container, "DataItem.equipment_no") %>' OnCommand="btnEditEquip_Command" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="เลขทะเบียน" >
                        <ItemTemplate>
                            <asp:Label ID="lbequipSe" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.equipment_serial") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ยี่ห้อ" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbequipbrand"  runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.equipment_brand") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:Label ID="lbequipToll"  runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="สถานะ" >
                        <ItemTemplate>
                            <asp:Label ID="lbequipchk"  runat="server"   Text='<%# DataBinder.Eval(Container, "DataItem.status_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="สถานที่" >
                        <ItemTemplate>
                            <asp:Label ID="lbequipnote"  runat="server"   Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="จัดการข้อมูล" >
                        <ItemTemplate>
                            <asp:LinkButton ID="lbManage" runat="server" CssClass="badge bg-info text-white" Font-Size="24px"  OnCommand="btnEditEquip_Command"><i class="fas fa-bars fa-1x"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                </Columns>
                <FooterStyle BackColor="#82e874" Font-Bold="True" ForeColor="White" BorderColor="White"/>
                <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />            
        </asp:GridView>
              <div class="footer">
                  <div class="stats" style="padding-left:20px; color:grey; ">
                    <asp:Label ID="titlegrid" runat="server" Visible="false" ></asp:Label>               
                </div>
              </div>
   </asp:Panel>   
            </div>
        </div>
   <div class="modal fade" id="EquipModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" style="font-size: 15px;">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">ภาพครุภัณฑ์</h5>
                        
                </div>
                <div class="modal-body">
                    
                    <asp:Image ID="imagee" runat="server"  Width="70%" />
                    <asp:Label ID="lbIDEquipEdit" runat="server" Visible="true"></asp:Label>
                </div>
        </div>
    </div>
</div> 
    


    <div class="modal fade " id="UpdateEquipModal"   tabindex="-1" role="dialog" aria-labelledby="UpdateEquipModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl modal-dialog-scrollable " style="width:100%" role="form">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="modal-title">
                        <asp:Label ID="lbEQIDModal" runat="server" Font-Size="Medium" CssClass="text-dark"></asp:Label></div>
                    <asp:Label ID="pkeq" runat="server" visible="false" Font-Size="Smaller" ></asp:Label>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style="line-height: inherit;">
                    <div class="row" >
                        <div class="col-md-3">
                            <div class="form-group bmd-form-group">
                                <div class="card border-info ">
                                    <asp:Image ID="ImgEditEQ" runat="server" Width="100%"  />
                                
                        
                                <div runat="server" id="diveditpic">
                                    <label class="bmd-label-floating"></label>
                                    <asp:FileUpload ID="FileEditEQ" runat="server" CssClass="custom-file " Font-Size="12px" lang="en" />
                                </div>
                                    </div>
                            </div>
                        </div>
                        
                        <div class="col-md-4">
                            <div class="form-group bmd-form-group">
                                    <p class="bmd-label-floating">ชื่อครุภัณฑ์</p>
                                    <asp:TextBox ID="txtEditTH" Enabled="false"  runat="server"  CssClass="form-control time" />
                                 <br />
                                    <p class="bmd-label-floating">เลขครุภัณฑ์</p>
                                    <asp:TextBox ID="txtEditNo" Enabled="false" runat="server"  CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                                 <br />
                                    <p class="bmd-label-floating">เลขทะเบียน</p>
                                    <asp:TextBox ID="txtEditNoform" Enabled="false" runat="server"  CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                                </div>
                            </div>
                                <div class="col-md-4">
                                    <div class="form-group bmd-form-group">
                                        <p class="bmd-label-floating">ชื่อครุภัณฑ์อังกฤษ(ถ้ามี)</p>
                                        <asp:TextBox ID="txtEditEng" Enabled="false" runat="server" CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                                         <br />
                                        <p class="bmd-label-floating">ยี่ห้อ</p>
                                        <asp:TextBox ID="txtEditBrand" Enabled="false" runat="server"  CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                                         <br />
                                        <p class="bmd-label-floating">รุ่น</p>
                                        <asp:TextBox ID="txtEditSeries" Enabled="false" TextMode="MultiLine" runat="server"  CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                                    </div>
                                </div>    
                      </div>
                  
                     
                    <div class="row" >                                                
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ราคา</p>
                                <asp:TextBox ID="txtEditPrice" Enabled="false" runat="server"  CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">หน่วยนับ</p>
                                <asp:TextBox ID="txtEditcUnit" Enabled="false" runat="server"  CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">วันที่รับ</p>
                                <asp:TextBox ID="txtEditDate" Enabled="false" runat="server"  CssClass="form-control datepicker" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">เลขสัญญา</p>
                                <asp:TextBox ID="txtEditContract" Enabled="false" runat="server"  CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                    </div>

                    <div class="row" >
                        
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">สถานะ</p>
                                <asp:DropDownList ID="ddlEditStat"  runat="server"  CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ด่านฯ</p>
                                <asp:DropDownList ID="ddlEditCpoint"  runat="server"  CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">สถานที่ตั้ง</p>
                                <asp:DropDownList ID="ddlEditLocate" runat="server"  CssClass="form-control timeline" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">บริษัทที่รับผิดชอบ</p>
                                <asp:DropDownList ID="ddlEditCompany" Enabled="false" runat="server"  CssClass="form-control time" />
                            </div>
                        </div>
                    </div>

                    <div class="row" >              
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">อายุการใช้งาน</p>
                                <asp:TextBox ID="txtlifetime" runat="server" Enabled="false" CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>

                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">ผู้รับผิดชอบหรือผู้ใช้งาน</p>
                                <asp:TextBox ID="txtEditPerson" runat="server"   CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                                            
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating">หมายเหตุ</p>
                                <asp:TextBox ID="txtEditNote"  runat="server" TextMode="MultiLine"  CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                    </div>


                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="btnchkHistory" runat="server" CssClass="btn btn-warning btn-sm" Font-Size="Medium" OnCommand="btnchkHistory_Command">ประวัติ</asp:LinkButton>
                    <asp:LinkButton ID="btnUpdateEQ" runat="server" CssClass="btn btn-success btn-sm" Font-Size="Medium" OnCommand="btnUpdateEQ_Command" OnClientClick="return UpdteConfirm('ยืนยันแก้ไขข้อมูล ใช่หรือไม่');">ยืนยัน</asp:LinkButton>
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" style="font-size: medium">Close</button>
                </div>
            </div>
        </div>
    </div>

    
    



    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript"> 
        $(function () {
        <% if (alert != "")
        { %>
            demo.showNotification('top', 'center', '<%=icon%>', '<%=alertType%>', '<%=alert%>');
        <% } %>
        });

        $(function () {
            <% if (EditModal != "")
        {%>
            $("#UpdateEquipModal").modal('show');
            <%}
        else
        {%>
            $("#UpdateEquipModal").modal('hide');
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

        function handleEnter (field, event) {
		    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 13) {
                
                return false;
            }
            else
            {
                return true;
            }
	    }     
        
    </script>
</asp:Content>
