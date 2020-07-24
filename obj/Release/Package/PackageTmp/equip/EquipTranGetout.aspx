<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipTranGetout.aspx.cs" Inherits="ClaimProject.equip.EquipTranGetout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <asp:Button runat="server" ID="btnMainGetout"  Font-Bold="true" BackColor="#005ebd" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="หน้าหลักรายการ"  OnClick="btnMainGetout_Click" CssClass="btn" />
    <div  class="card" style="font-size: 19px; z-index: 0;" runat="server">

        <h3 class="bg form-control"  style="font-size:30px;color:white;height:60px;background-color:#0242ab">&nbsp;&nbsp;รับโอนย้ายจากหน่วยงานภายนอก</h3>

        <div id="divtranSecond"  class="card-body table-responsive"  runat="server">
            <h3 class="card-title alert-warning" style="font-size:22px;background-color:#eeffd9;">ส่วนที่1 : ข้อมูลเบื้องต้น <asp:Label ID="refnoo" runat="server" Font-Size="Large" CssClass="text-right"></asp:Label></h3> 
            <div class="row" style="height:110px" >

                <div class="form-group bmd-form-group col-md-2" id="div1" runat="server"  style="padding:1px 1px 1px 15px;">
                       <label class="bmd-label-floating" style="font-size:20px;height:5px">จากหน่วยงาน</label>
                       <asp:DropDownList ID="ddlcompout" runat="server" Width="240px" AutoPostBack="true" OnSelectedIndexChanged="ddlcompout_SelectedIndexChanged"  CssClass="form-control"  ></asp:DropDownList>
                </div>
                <div class="form-group bmd-form-group col-md-2" id="div2" runat="server"  style="padding:1px 1px 1px 15px;">
                       <label class="bmd-label-floating" style="font-size:20px;height:5px">ผู้รับ</label>
                       <asp:DropDownList ID="ddlcompGet" runat="server" AutoPostBack="true"  CssClass="form-control"  ></asp:DropDownList>
                </div>
                <div class="form-group bmd-form-group col-md-2"  style="padding:1px 15px 1px 15px;" >
                     <label class="bmd-label-floating" style="font-size:large;height:10px">วันที่รับ</label>
                     <asp:TextBox runat="server" ID="txtDateGet"  CssClass="form-control datepicker" ></asp:TextBox>
               </div>
                
            </div>
            <div class="row" id="divbtnNext" runat="server"  >
                <div class="col-md text-left"   >
                    <asp:Button runat="server" ID="btnNext" CssClass="btn btn" Text="ต่อไป ->" Height="45px" ForeColor="White" BackColor="#0033cc" OnClick="btnNext_Click" />
               </div>
            </div>

        </div>
        <div id="div3"  class="card-body table-responsive" visible="false"  runat="server">
            <h3 class="card-title alert-warning" style="font-size:22px;background-color:#eeffd9;">ส่วนที่2 : รายการครุภัณฑ์</h3> 
            <div class="row " id="divnormal" runat="server"  style="padding:15px 1px 1px 15px;background-color:#d4efff;height:80px">
                <div class="col-md-2" style="padding:1px 5px 1px 8px;width:100px">
                    <asp:Label ID="lbEQtranAdd" runat="server" Text="เพิ่มรายการครุภัณฑ์" ForeColor="#001e80" Font-Bold="true"  ></asp:Label>
                </div>
                <div class="col-md-3" style="padding-left:5px;width:180px;enable-background:initial;">
                    <asp:DropDownList ID="txtEquipGet" runat="server" CssClass="combobox form-control custom-select" ></asp:DropDownList>
                </div>
                <div class="col-md-1" style="padding:1px 1px 1px 1px">
                   <asp:LinkButton ID="btnAddGet" runat="server" ToolTip="เพิ่มรายการ" Font-Size="XX-Large" ForeColor="#001e80" CssClass="fas text" OnCommand="btnAddGet_Command" OnClientClick="return UpdteConfirm('ยืนยันเลือกเลขครุภัณฑ์นี้ ใช่หรือไม่');">&#xf055;</asp:LinkButton>
                </div>
            </div>
            <asp:gridview ID="GridAddGet" runat="server" DataKeyNames="trans_act_id"
                    ShowFooter="true"  GridLines="Both" BorderColor="White"  Font-Size="20px" 
                    AutoGenerateColumns="false" OnRowDataBound="GridAddGet_RowDataBound" OnRowDeleting="GridAddGet_RowDeleting"> 
                    <AlternatingRowStyle BackColor="#edebec" />
                    <Columns>
                        <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-center" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขครุภัณฑ์" ItemStyle-Width="200px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="lbNoEq"   runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_no") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="รายการ" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:Label ID="lbListEq"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_nameth") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ยี่ห้อ" ItemStyle-Width="300px" ItemStyle-CssClass="text-center">
                            <ItemTemplate >
                                <asp:label ID="lbBrandEq"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.old_brand") %>' ></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField  ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="fa text-danger" ControlStyle-Font-Size="Small" />
                    </Columns>
                    <FooterStyle BackColor="#c8ffc4" Font-Bold="True" CssClass="text-center" ForeColor="#0a7802" />
                    <HeaderStyle BackColor="#c8ffc4" CssClass="text-center"   ForeColor="#0a7802" />
                    <RowStyle BackColor="#f3fff0"  />
                
                </asp:gridview>
        </div>
        <br />
            <div class="row">
                <div class="col-md text-center" >
                    <asp:Button ID="btnPlanSheet" runat="server" Visible="false" Text="บันทึกฉบับร่าง" Font-Size="Larger" OnClick="btnPlanSheet_Click" CssClass="btn btn-info"  />
                    <asp:Button ID="btnFinalSubmit" runat="server" Visible="false" Text="บันทึกและยืนยันรับเรียบร้อย" Font-Size="Larger" OnClick="btnFinalSubmit_Click" CssClass="btn btn-success" OnClientClick="return UpdteConfirm('ยืนยันบันทึก ใช่หรือไม่');" />
                    <asp:Button ID="btnDeleteALL" runat="server" Visible="false" Text="ลบรายการทิ้ง" Font-Size="Larger" OnClick="btnDeleteALL_Click" CssClass="btn btn-danger" OnClientClick="return UpdteConfirm('ยืนยันลบรายการทั้งหมด ใช่หรือไม่');" />
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
