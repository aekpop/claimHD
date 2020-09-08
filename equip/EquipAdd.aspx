<%@ Page Title="รายการครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipAdd.aspx.cs" Inherits="ClaimProject.equip.EquipAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <!--<asp:Button runat="server" ID="btnBackHomeADDEQ" Text="กลับหน้าหลัก" OnClick="btnBackHomeADDEQ_Click" CssClass="btn btn-default " />-->
    <div id="AddPM" runat="server" class="card" style="z-index: 0">

        <div class="card-header card-header-warning">
            <h2 class="card-title">ค้นหา/แก้ไขรายการครุภัณฑ์</h2>
        </div>
        
            <div class="card-body table-responsive table-sm">
                
                <div id="divsearch" runat="server" class="row"  style="height:140px;padding:1px 1px 1px 1px;" >
                    <div class="col-md" style="padding:1px 2px 2px 20px">
                            <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="ชื่อครุภัณฑ์(ไทย):" Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:TextBox ID="txtsearchth"  CssClass="form-control" runat="server" BorderStyle="NotSet" Width="180px" ></asp:TextBox>
                           </div>
                        </div>
                
                    <div class="col-md" style="padding:1px 2px 2px 5px">
                            <div class="form-group" >
                            <asp:Label ID="Label2" runat="server" Text="เลขครุภัณฑ์:" Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:TextBox ID="txtsearchNum"  CssClass="form-control" runat="server" BorderStyle="NotSet" Width="160px" ></asp:TextBox>
                           </div>
                        </div>
                    <div class="col-md" style="padding:1px 2px 2px 5px">
                            <div class="form-group" >
                            <asp:Label ID="Label4" runat="server" Text="เลขทะเบียน(Serial):" Font-Size="Large" Font-Bold="true" ></asp:Label>
                            <asp:TextBox ID="txtsearchSerial"  CssClass="form-control" runat="server" BorderStyle="NotSet" Width="160px" ></asp:TextBox>
                           </div>
                        </div>
                    <div class="col-md" style="padding:1px 1px 1px 5px">
                            <div class="form-group" >
                                <asp:Label ID="Label6" runat="server" Text="สถานะ :" Font-Size="Large" Font-Bold="true" ></asp:Label>
                                <asp:DropDownList ID="ddlsearchStat" runat="server"  CssClass="form-control" Width="160px" ></asp:DropDownList>
                                </div>
                     </div>
                    <div class="col-md" style="padding:1px 1px 1px 1px">
                            <div class="form-group" >
                                <asp:Label ID="Label5" runat="server" Text="ด่านฯ :" Font-Size="Large" Font-Bold="true" ></asp:Label>
                                <asp:DropDownList ID="ddlcpoint" runat="server"  OnSelectedIndexChanged="ddlcpoint_SelectedIndexChanged" AutoPostBack="true"  CssClass="form-control" Width="150px" ></asp:DropDownList>
                                </div>
                     </div>

                     <div class="col-md" style="padding:1px 1px 1px 1px">
                            <div id="divAnex" runat="server" visible="false" class="form-group"  >
                                <asp:Label ID="Label3" runat="server" Text="อาคาร :" Font-Size="Large" Font-Bold="true" ></asp:Label>
                                <asp:DropDownList ID="ddlserchToll" runat="server"  CssClass="form-control" Width="150px" ></asp:DropDownList>
                                </div>
                     </div>
                     </div>
                   
                        <div class="row">
                            <div class="col-md-6 text-right" >                               
                                   <asp:Button ID="searchEquip" runat="server" Text="ค้นหา" CssClass="btn btn-warning btn-sm" Font-Bold="true" Font-Size="Large" OnClick="searchEquip_Click" />                                
                            </div>                                                   
                                <div id="divSagain" runat="server" visible="false" class="col-md-6">
                                         <asp:Label ID="chkS" runat="server" font-size="Small" ></asp:Label>
                                                 <asp:LinkButton ID="lbtnTollReport"  runat="server" Text="พิมพ์เอกสาร" Visible="false" ToolTip="พิมพ์" CssClass="btn btn-dark btn-sm" Font-Bold="true" Font-Size="Large"  OnCommand="lbtnTollReport_Command"></asp:LinkButton>
                                                        <asp:LinkButton ID="lbtnDepartReport" runat="server" Text="พิมพ์เอกสาร1" Visible="false" ToolTip="พิมพ์" CssClass="btn btn-dark btn-sm"  Font-Bold="true" Font-Size="Large"  OnCommand="lbtnDepartReport_Command"></asp:LinkButton>
                                </div>
                         </div>
                    
               
                <br />
                <div class="row" style="padding-left:20px">
                    <asp:Label ID="titlegrid" runat="server" text="" Visible="false" Font-Bold="true" Font-Size="Large" ></asp:Label>               
                        
                </div>
                <hr />

          <asp:Panel ID="Panel1" runat="server" > 
              
            <asp:GridView ID="GridEquipAdd" runat="server"
            DataKeyNames="equipment_id"
            OnRowDataBound="GridEquipAdd_RowDataBound"
            CssClass="table table-hover table-sm " 
            AutoGenerateColumns="False" 
                OnPageIndexChanging="GridEquipAdd_PageIndexChanging" 
                PagerSettings-Mode="NumericFirstLast"  PageSize="20" 
            PagerSettings-FirstPageText="หน้าแรก"  PagerSettings-LastPageText="หน้าสุดท้าย"
            AllowPaging="true" 
            HeaderStyle-CssClass="text-center" RowStyle-CssClass="text-center" CellPadding="4" BorderColor="white" ForeColor="#000000" GridLines="None">
                
                <Columns>
                    
                    <asp:TemplateField HeaderText="ลำดับ" ControlStyle-Width="10px" ControlStyle-Font-Size="12px">
                        <ItemTemplate >
                            <%# Container.DataItemIndex + 1+"." %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อครุภัณฑ์(ไทย)" >
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEquipthai" runat="server"  Font-Size="19px" ForeColor="Black" Text='<%# DataBinder.Eval(Container, "DataItem.equipment_nameth") %>' OnCommand="btnEditEquip_Command" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="เลขครุภัณฑ์" >
                        <ItemTemplate>
                            <asp:LinkButton ID="lbequipNo" runat="server" Font-Size="19px" ForeColor="Black" Text='<%# DataBinder.Eval(Container, "DataItem.equipment_no") %>' OnCommand="btnEditEquip_Command" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="เลขทะเบียน" >
                        <ItemTemplate>
                            <asp:Label ID="lbequipSe" runat="server" Font-Size="19px" Text='<%# DataBinder.Eval(Container, "DataItem.equipment_serial") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ยี่ห้อ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" >
                        <ItemTemplate>
                            <asp:Label ID="lbequipbrand"  runat="server" Font-Size="19px"  Text='<%# DataBinder.Eval(Container, "DataItem.equipment_brand") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="ด่านฯ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:Label ID="lbequipToll"  runat="server" Font-Size="19px" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.toll_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="สถานะ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ControlStyle-Width="70px">
                        <ItemTemplate>
                            <asp:Label ID="lbequipchk"  runat="server" Font-Size="19px"  Text='<%# DataBinder.Eval(Container, "DataItem.status_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="สถานที่" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:Label ID="lbequipnote"  runat="server" Font-Size="19px"  Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
                <FooterStyle BackColor="#82e874" Font-Bold="True" ForeColor="White" />
                <HeaderStyle CssClass="text-center" BackColor="#ffffff"  ForeColor="000000" ></HeaderStyle>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" BackColor="#2461BF" ForeColor="White" />
                
                <SelectedRowStyle BackColor="#a2fca5" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#baf7b2" />
                <SortedDescendingHeaderStyle BackColor="#5abe48"/>              
                <PagerStyle HorizontalAlign="Center" BackColor="White" ForeColor="#026b14"  />
        </asp:GridView>
                  
   </asp:Panel>   








            </div>
            
        </div>
   <div class="modal fade" id="EquipModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">ภาพครุภัณฑ์</h5>
                        
                </div>
                <div class="modal-body" style="font-size: medium;">
                    
                    <asp:Image ID="imagee" runat="server"  Width="70%" />
                    <asp:Label ID="lbIDEquipEdit" runat="server" Visible="true"></asp:Label>
                </div>
        </div>
    </div>
</div> 
    


    <div class="modal fade " id="UpdateEquipModal"   tabindex="-1" role="dialog" aria-labelledby="UpdateEquipModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered " style="width:100%" role="form">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ครุภัณฑ์ : 
                        <asp:Label ID="lbEQIDModal" runat="server" Text="" CssClass="text-dark"></asp:Label></h4>
                    <asp:Label ID="pkeq" runat="server" visible="false" Font-Size="Smaller" ></asp:Label>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style="line-height: inherit;">
                    <div class="row" style="height: 140px">
                        <div class="col-md-3">
                            <asp:Image ID="ImgEditEQ" runat="server" Width="100%"  />
                        </div>
                        <div class="col-md-2" runat="server" id="diveditpic">
                            <label class="bmd-label-floating"></label>
                            <asp:FileUpload ID="FileEditEQ" runat="server" CssClass="custom-file" Font-Size="Medium" lang="en" />
                        </div>
                    </div>
                    <div class="row" >
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ชื่อครุภัณฑ์(ไทย)</label>
                                <asp:TextBox ID="txtEditTH" Enabled="false"  runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ชื่อครุภัณฑ์(อังกฤษ)</label>
                                <asp:TextBox ID="txtEditEng" Enabled="false" runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เลขครุภัณฑ์</label>
                                <asp:TextBox ID="txtEditNo" Enabled="false" runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เลขทะเบียน</label>
                                <asp:TextBox ID="txtEditNoform" Enabled="false" runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                    </div>

                    <div class="row" style="height: 110px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ยี่ห้อ</label>
                                <asp:TextBox ID="txtEditBrand" Enabled="false" runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">รุ่น</label>
                                <asp:TextBox ID="txtEditSeries" Enabled="false" TextMode="MultiLine" runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ราคา</label>
                                <asp:TextBox ID="txtEditPrice" Enabled="false" runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">หน่วยนับ</label>
                                <asp:TextBox ID="txtEditcUnit" Enabled="false" runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                    </div>

                    <div class="row" style="height: 90px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">วันที่รับ</label>
                                <asp:TextBox ID="txtEditDate" Enabled="false" runat="server" Font-Size="21px" CssClass="form-control datepicker" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">เลขสัญญา</label>
                                <asp:TextBox ID="txtEditContract" Enabled="false" runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">สถานะ</label>
                                <asp:DropDownList ID="ddlEditStat"  runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ด่านฯ</label>
                                <asp:DropDownList ID="ddlEditCpoint"  runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                        
                    </div>

                    <div class="row" style="height: 90px">
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">สถานที่ตั้ง</label>
                                <asp:DropDownList ID="ddlEditLocate" runat="server" Font-Size="21px" CssClass="form-control timeline" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">บริษัทที่รับผิดชอบ</label>
                                <asp:DropDownList ID="ddlEditCompany" Enabled="false" runat="server" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">ผู้รับผิดชอบหรือผู้ใช้งาน</label>
                                <asp:TextBox ID="txtEditPerson" runat="server" Font-Size="21px"  CssClass="form-control time" />
                            </div>
                        </div>
                        

                    </div>
                    <div class="row" style="height: 120px">
                        <div class="col-md-12">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating">หมายเหตุ</label>
                                <asp:TextBox ID="txtEditNote"  runat="server" TextMode="MultiLine" Font-Size="21px" CssClass="form-control time" />
                            </div>
                        </div>

                    </div>


                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="btnUpdateEQ" runat="server" CssClass="btn btn-success btn-sm" Font-Size="Medium" OnCommand="btnUpdateEQ_Command" OnClientClick="return UpdteConfirm('ยืนยันแก้ไขข้อมูล ใช่หรือไม่');">ยืนยันแก้ไข</asp:LinkButton>
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
        
    </script>




</asp:Content>
