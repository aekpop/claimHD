<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipAddList.aspx.cs" Inherits="ClaimProject.equip.EquipAddList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <asp:Button runat="server" ID="btnBackHome" Text="กลับหน้าหลัก" OnClick="btnBackHome_Click" CssClass="btn btn-default " />
    <div  class="card" style="font-size: 19px; z-index: 0;" runat="server" >

        <div class="card-header card-header-rose" style="height:60px" >
            <h3 class="card-title" style="font-style:initial;font-size:24px;">เพิ่มรายการครุภัณฑ์ <asp:Label ID="statsave" runat="server" ForeColor="Black"  CssClass="badge badge" Font-Size="Medium" ></asp:Label></h3>
            
        </div>
        <div class="card-body table-responsive" runat="server" id="divAdd" >
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                <div class="row" style="height: 110px;padding:1px 1px 1px 1px; " >
                        <div class="col-md-3" style="padding:1px 5px 1px 10px">
                            <div class="form-group bmd-form-group" >
                                <label class="bmd-label-floating" style="font-size:large;height:5px">ชื่อครุภัณฑ์(ไทย)</label>
                                <asp:TextBox ID="txtAddTH" runat="server" text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล" Font-Size="Medium" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-3" style="padding:1px 5px 1px 5px">
                            <div class="form-group bmd-form-group" >
                                <label class="bmd-label-floating" style="font-size:large;height:5px">ชื่อครุภัณฑ์(อังกฤษ)</label>
                                <asp:TextBox ID="txtAddENG" runat="server" Text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล"  Font-Size="Medium" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-2" style="padding:1px 5px 1px 5px">
                            <div class="form-group bmd-form-group" >
                                <label class="bmd-label-floating" style="font-size:large;height:5px">ยี่ห้อ</label>
                                <asp:TextBox ID="txtAddBrand" runat="server" Text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล"  Font-Size="Medium" CssClass="form-control time" />
                            </div>
                        </div>
                        <div class="col-md-2" style="padding:1px 5px 1px 5px">
                            <div class="form-group bmd-form-group">
                                <label class="bmd-label-floating" style="font-size:large;height:5px">รุ่น</label>
                                <asp:TextBox ID="txtAddSeries" runat="server" Text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล"  Font-Size="Medium" CssClass="form-control" />
                            </div>
                        </div>
                        
                        <div class="col-md-2" style="padding:1px 10px 1px 5px">
                            <div class="form-group bmd-form-group" >
                                <label class="bmd-label-floating" style="font-size:large;height:5px">เลขสัญญา</label>
                                <asp:TextBox ID="txtAddContractNum" runat="server" ToolTip="ใส่ - กรณีไม่มีข้อมูล" Text="-" Font-Size="Medium" CssClass="form-control" />
                            </div>
                        </div>
                         
                    </div>
                    
                    <div class="row" style="height: 140px;">
                        <div class="col-md-2" style="padding:1px 5px 1px 10px">
                            <div class="form-group bmd-form-group" >
                                <label class="bmd-label-floating" style="font-size:large;height:5px">ด่านฯ</label>
                                <asp:DropDownList ID="ddlAddCpoint" runat="server" Font-Size="Large" CssClass="form-control " />
                            </div>
                        </div>
                        <style type ="text/css">
                            .ui-datepicker {
                                font-size: 11pt
                            } 
                        </style>
                       <div class="col-md-2" style="padding:1px 5px 1px 5px" >
                            <div class="form-group bmd-form-group" >
                                <label class="bmd-label-floating" style="font-size:large;height:5px">วันที่รับ</label>
                                <asp:TextBox ID="txtAddDateGet" runat="server" Font-Size="Large" CssClass="form-control datepicker" />                             
                            </div>
                        </div>

                        <div class="col-md-2" style="padding:1px 2px 2px 2px" >
                            <div class="form-group bmd-form-group" >
                                <label class="bmd-label-floating" style="font-size:large;height:5px">ราคา</label>
                                <asp:TextBox ID="txtAddPrize" runat="server" Text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล" Font-Size="Medium" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-1" style="padding:1px 2px 2px 2px" >
                            <div class="form-group bmd-form-group" >
                                <label class="bmd-label-floating" style="font-size:large;height:5px">หน่วย</label>
                                <asp:TextBox ID="txtAddUnit" runat="server" Text="-" ToolTip="ใส่ - กรณีไม่มีข้อมูล" Font-Size="Medium" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-3" style="padding:1px 5px 1px 5px">
                            <div class="form-group bmd-form-group" >
                                <label class="bmd-label-floating" style="font-size:large;height:5px">บริษัทที่รับผิดชอบ</label>
                                <asp:DropDownList ID="ddlAddCompany" runat="server" Font-Size="Medium" CssClass="form-control " />
                            </div>
                        </div>
                        <div class="col-md-2" style="padding:1px 2px 2px 2px">
                            <div class="form-group bmd-form-group" >
                                <label class="bmd-label-floating" style="font-size:large;height:5px">สถานะอุปกรณ์</label>
                                <asp:DropDownList ID="ddlAddStat" runat="server" Font-Size="Large" CssClass="form-control" />
                            </div>
                        </div>

                    </div>
            <asp:Label ID="checkRowNum" runat="server" Visible="false"></asp:Label>
       
                <asp:gridview ID="Gridview1" runat="server" CssClass="col-md text-center"
                    ShowFooter="true"  GridLines="Both" BorderColor="White"  Font-Size="20px" 
                    AutoGenerateColumns="false" > 
                    <AlternatingRowStyle BackColor="#edebec" />
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="ลำดับ" ItemStyle-Width="100px" HeaderStyle-CssClass="text-center"  ItemStyle-CssClass="text-center" />
                        <asp:TemplateField HeaderText="เลขครุภัณฑ์" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:TextBox ID="TextBox1"   runat="server" CssClass="form-control text-center"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="เลขทะเบียน" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:TextBox ID="TextBox2"  runat="server" ToolTip="ใส่ - กรณีไม่มีข้อมูล" CssClass="form-control text-center"></asp:TextBox>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                             <asp:Button ID="btnNewrow" runat="server" Font-Size="Large" Font-Bold="true"   BackColor="#035405" ForeColor="White" CssClass="btn btn-sm " Text="(+) เพิ่มแถว" OnClick="btnNewrow_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  ItemStyle-Width="45px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:LinkButton ID="lbtnDeleteRow" runat="server" Font-Size="Small" CssClass="fas fa-trash-alt" ForeColor="#cc0000" OnClick="lbtnDeleteRow_Click" >ลบ</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#ffd9d9" Font-Bold="True" Height="40px" CssClass="text-center" ForeColor="#780202" />
                    <HeaderStyle BackColor="#ffd9d9" CssClass="text-center"   ForeColor="#780202" />
                    <RowStyle BackColor="#ffedf5"  />
                </asp:gridview>
            <br />
            <div class="row">
                <div class="col-md  text-center">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-rose" Font-Bold="true" runat="server" OnClick="btnSubmit_Click" Text="บันทึกรายการทั้งหมด" OnClientClick="return UpdteConfirm('ยืนยันเพิ่มรายการ ใช่หรือไม่');" />
                
                </div>
                    
            </div>
          

            <hr />
            <div class="row" style="padding-left:30px;" >
                <div class="text-center" >
                    <asp:Label ID="resulttt" runat="server" Font-Bold="true" ></asp:Label>
                </div>
            </div>
            <asp:gridview ID="gridadded" runat="server" DataKeyNames="newlist_id"
                    ShowFooter="true"  GridLines="Both" BorderColor="White"  Font-Size="20px" 
                    AutoGenerateColumns="false" OnRowDataBound="gridadded_RowDataBound" OnRowDeleting="gridadded_RowDeleting"> 
                    <AlternatingRowStyle BackColor="#e3e3e3" />
                    <Columns>
                        <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1+"." %>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขครุภัณฑ์" ItemStyle-Width="180px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="lbEQnumber"   runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.list_number") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="เลขทะเบียน" ItemStyle-Width="180px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="lbEQSerial"   runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.list_serial") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ชื่อครุภัณฑ์" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="lbEQthname"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.list_thname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ยี่ห้อ" ItemStyle-Width="180px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="lbEQBrand"  runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().ShortTextCom(DataBinder.Eval(Container, "DataItem.list_brand").ToString()) %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="รุ่น/ซีรีย์" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="lbEQSeries"  runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().ShortTextCom(DataBinder.Eval(Container, "DataItem.list_series").ToString()) %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่บันทึกระบบ" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="lbdatesys"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Date_added") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เวลาที่บันทึกระบบ" ItemStyle-Width="200px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="lbtimesys"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Time_added") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField  ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Small" />
                    </Columns>
                    <FooterStyle BackColor="#ffffff" Font-Bold="True" CssClass="text-center" ForeColor="#ffffff" />
                    <HeaderStyle BackColor="#ab0c56" CssClass="text-center"   ForeColor="#ffffff" />
                    <RowStyle BackColor="#fff0fa"  />
                
                </asp:gridview>



                    </ContentTemplate>
            </asp:UpdatePanel>


    </div>
        <div class="row">
                <div class="col-md text-center">
                    <asp:Button ID="deleteAll" runat="server" Visible="false" CssClass="btn btn-danger" Font-Bold="true" OnClick="deleteAll_Click" Text="ลบรายการที่เพิ่มไปแล้วทั้งหมด" />
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
    </script>

</asp:Content>
