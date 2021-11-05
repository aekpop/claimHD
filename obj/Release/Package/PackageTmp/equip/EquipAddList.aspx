<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipAddList.aspx.cs" Inherits="ClaimProject.equip.EquipAddList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
     <style type ="text/css">
                            .ui-datepicker {
                                font-size: 16pt
                            } 
     </style>
    <script src="/Scripts/bootbox.js"></script>
    <div class="container-fluid">     
    <div  class="card" style="font-size: 19px; z-index: 0;" runat="server" >
        <div class="card-header card-header-rose" style="height:60px" >
            <h3 class="card-title" style="font-style:initial;font-size:24px;">เพิ่มครุภัณฑ์ <asp:Label ID="statsave" runat="server" ForeColor="Black"  CssClass="badge badge" Font-Size="Medium" ></asp:Label></h3>
        </div>
        <div class="card-body table-responsive" runat="server" id="divAdd" >
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                <div class="row" >
                        <div class="col-md-3" style="padding:1px 5px 1px 10px">
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating">ชื่อครุภัณฑ์(ไทย)</p>
                                <asp:TextBox ID="txtAddTH" runat="server" text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล" Font-Size="Medium" CssClass="form-control" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                        <div class="col-md-3" style="padding:1px 5px 1px 5px">
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating" >ชื่อครุภัณฑ์(อังกฤษ)</p>
                                <asp:TextBox ID="txtAddENG" runat="server" Text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล"  Font-Size="Medium" CssClass="form-control" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                        <div class="col-md-3" style="padding:1px 5px 1px 5px">
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating" >ยี่ห้อ</p>
                                <asp:TextBox ID="txtAddBrand" runat="server" Text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล"  Font-Size="Medium" CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                        <div class="col-md-3" style="padding:1px 5px 1px 5px">
                            <div class="form-group bmd-form-group">
                                <p class="bmd-label-floating" >รุ่น</p>
                                <asp:TextBox ID="txtAddSeries" runat="server" Text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล"  Font-Size="Medium" CssClass="form-control" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>                        
                    </div>                    
                    <div class="row" >
                        <div class="col-md-3" style="padding:1px 10px 1px 5px">
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating" >เลขสัญญา</p>
                                <asp:TextBox ID="txtAddContractNum" runat="server" ToolTip="ใส่ - กรณีไม่มีข้อมูล" Text="-" Font-Size="Medium" CssClass="form-control" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                        <div class="col-md-3" style="padding:1px 5px 1px 10px">
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating" >ด่านฯ</p>
                                <asp:DropDownList ID="ddlAddCpoint" runat="server" Font-Size="Large" CssClass="form-control " />
                            </div>
                        </div>
                       
                       <div class="col-md-3" style="padding:1px 5px 1px 5px" >
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating" >วันที่รับ</p>
                                <asp:TextBox ID="txtAddDateGet" runat="server" Font-Size="Large" CssClass="form-control datepicker" onkeypress="return handleEnter(this, event)"/>                             
                            </div>
                        </div>

                        <div class="col-md-3" style="padding:1px 2px 2px 2px" >
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating" >ราคา</p>
                                <asp:TextBox ID="txtAddPrize" runat="server" Text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล" Font-Size="Medium" CssClass="form-control" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                        </div>
                    <div class="row">
                        <div class="col-md-3" style="padding:1px 2px 2px 2px" >
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating" >หน่วย</p>
                                <asp:TextBox ID="txtAddUnit" runat="server" Text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล" Font-Size="Medium" CssClass="form-control" onkeypress="return handleEnter(this, event)"/>
                            </div>
                        </div>
                        <div class="col-md-3" style="padding:1px 5px 1px 5px">
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating" >บริษัทที่รับผิดชอบ</p>
                                <asp:DropDownList ID="ddlAddCompany" runat="server" Font-Size="Medium" CssClass="form-control " />
                            </div>
                        </div>
                        <div class="col-md-3" style="padding:1px 2px 2px 2px">
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating" >สถานะอุปกรณ์</p>
                                <asp:DropDownList ID="ddlAddStat" runat="server"  CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-3" style="padding:1px 2px 2px 2px">
                            <div class="form-group bmd-form-group" >
                                <p class="bmd-label-floating" >อายุการใช้งาน</p>
                                <asp:TextBox ID="txtexpired" runat="server"  CssClass="form-control" text="8"/>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <br />
            <asp:Label ID="checkRowNum" runat="server" Visible="false"></asp:Label>
       <div class="container">
                <asp:gridview ID="Gridview1" runat="server" CssClass="col-md text-center"
                    ShowFooter="true"  GridLines="Both" BorderColor="White"  Font-Size="16px" 
                    HeaderStyle-Font-Size="24px"
                    AutoGenerateColumns="false" 
                    OnRowDataBound="Gridview1_RowDataBound"
                    > 
                    <AlternatingRowStyle BackColor="#edebec" />
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="ลำดับ" ItemStyle-Width="30px" HeaderStyle-CssClass="text-center"  ItemStyle-CssClass="text-center" />
                        <asp:TemplateField HeaderText="เลขครุภัณฑ์"  ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:TextBox ID="TextBox1"  runat="server" CssClass="form-control text-center" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="เลขทะเบียน" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:TextBox ID="TextBox2"  runat="server" ToolTip="ใส่ - กรณีไม่มีข้อมูล" CssClass="form-control text-center" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                            </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="สถานที่" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAddLocatedd" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                                <div class="col-3">
                                    <asp:Button ID="btnNewrow" runat="server" Font-Size="Medium" Font-Bold="true"  ForeColor="White" CssClass="btn btn-success " Text="เพิ่มแถว" OnClick="btnNewrow_Click" />
                                </div>  
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  ItemStyle-Width="45px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:LinkButton ID="lbtnDeleteRow" runat="server" Font-Size="Medium" CssClass="fas fa-trash-alt" ForeColor="#cc0000" OnClick="lbtnDeleteRow_Click" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#ffd9d9" Font-Bold="True" CssClass="text-center" ForeColor="#780202" />
                    <HeaderStyle BackColor="#ffd9d9" CssClass="text-center"   ForeColor="#780202" />
                    <RowStyle BackColor="#ffedf5"  />
                </asp:gridview>
           
            <br />
            <div class="row">
                <div class="col-md  text-center">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" Font-Bold="true" runat="server" OnClick="btnSubmit_Click" Text="บันทึก" OnClientClick="return UpdteConfirm('ยืนยันเพิ่มรายการ ใช่หรือไม่');" />               
                </div>
            </div>
            <hr />
            <div class="row" style="padding-left:20px;" >
                <div class="text-center" >
                    <asp:Label ID="resulttt" runat="server" Font-Bold="true" Font-Size="12px"></asp:Label>
                </div>
            </div>
            <asp:gridview ID="gridadded" runat="server" DataKeyNames="newlist_id"
                    ShowFooter="true"  GridLines="None" BorderColor="White"  Font-Size="16px" 
                    HeaderStyle-Font-Size="24px" PageSize="100" 
                    CssClass="table table-hover table-condensed table-sm"
                    HeaderStyle-CssClass="text-center"
                    AutoGenerateColumns="false" OnRowDataBound="gridadded_RowDataBound" OnRowDeleting="gridadded_RowDeleting"> 
                    <AlternatingRowStyle BackColor="#ffffff" />
                    <Columns>
                        <asp:TemplateField HeaderText="ลำดับ"  ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1+"." %>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขครุภัณฑ์"  ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="lbEQnumber"   runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.list_number") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="เลขทะเบียน"  ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="lbEQSerial"   runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.list_serial") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ชื่อครุภัณฑ์"  ItemStyle-CssClass="text-center" Visible="false">
                            <ItemTemplate >
                                <asp:Label ID="lbEQthname"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.list_thname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ยี่ห้อ"  ItemStyle-CssClass="text-center" Visible="false">
                            <ItemTemplate >
                                <asp:label ID="lbEQBrand"  runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().ShortTextCom(DataBinder.Eval(Container, "DataItem.list_brand").ToString()) %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="รุ่น/ซีรีย์"  ItemStyle-CssClass="text-center" Visible="false">
                            <ItemTemplate >
                                <asp:label ID="lbEQSeries"  runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().ShortTextCom(DataBinder.Eval(Container, "DataItem.list_series").ToString()) %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="สถานที่"  ItemStyle-CssClass="text-center" Visible ="true">
                            <ItemTemplate >
                                <asp:label ID="lbLocate"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่บันทึกระบบ"  ItemStyle-CssClass="text-center" Visible="true">
                            <ItemTemplate >
                                <asp:label ID="lbdatesys"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Date_added") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เวลา"  ItemStyle-CssClass="text-center" Visible ="true">
                            <ItemTemplate >
                                <asp:label ID="lbtimesys"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Time_added") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="จัดการข้อมูล"  ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Button id="delete" runat="server" CommandName="Delete" Text="ลบ" CssClass="btn btn-danger" OnClientClick="return UpdteConfirm('ยืนยัน ลบรายการครุภัณฑ์ทั้งหมด ใช่หรือไม่');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <FooterStyle BackColor="#ffffff" Font-Bold="True" CssClass="text-center" ForeColor="#ffffff" />
                    <HeaderStyle BackColor="#ab0c56" ForeColor="#ffd9d9"/>
                    <RowStyle BackColor="#ffffff"  />               
                </asp:gridview>
                    </ContentTemplate>
            </asp:UpdatePanel>
    </div>
        <div class="row">
                <div class="col-md text-center">
                    <asp:Button ID="deleteAll" runat="server" Visible="false" CssClass="btn btn-danger" Font-Bold="true" OnClick="deleteAll_Click" Text="ลบทั้งหมด" OnClientClick="return UpdteConfirm('ยืนยัน ลบรายการครุภัณฑ์ทั้งหมด ใช่หรือไม่');"/>
                </div>            
            </div>
        <div class="row" >
            <div class="col-md-4">
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnAgain" runat="server" CssClass="btn btn-warning" Visible="false" Text="เพิ่มรายการครุภัณฑ์อื่น" OnClick="btnAgain_Click"/>
            </div>
        </div>
        <br />
        <asp:Label runat="server" ID="lbAlert" ></asp:Label>
        </div>
</div>
</div>
    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script type="text/javascript">
        $(function () {
        <% if (alerts != "")
        { %>
            demo.showNotification('top', 'center', '<%=icons%>', '<%=alertTypes%>', '<%=alerts%>');
        <% } %>
            $('#txtAddDateGet').datepicker($.datepicker.regional["th"]);
            if ($('#txtAddDateGet').val() == "") {
                $('#txtAddDateGet').datepicker("setDate", new Date());
            }

            $('#txtAddDateGet').attr('maxlength', '10');
            $('#txtAddDateGet').css('font-size', '8');
            
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
        function clsAlphaNoOnly (e) {  // Accept only alpha numerics, no special characters 
            var regex = new RegExp("^[a-zA-Z0-9 ]+$");
            var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (regex.test(str)) {
                return true;
            }

            e.preventDefault();
            return false;
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
