<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipCheck.aspx.cs" Inherits="ClaimProject.equip.EquipCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <asp:Button runat="server" ID="btnMainEQ"  Font-Bold="true" BackColor="#c44602" Height="45px" Width="160px" ForeColor="white" Font-Size="18px" Text="หน้าหลักครุภัณฑ์"  OnClick="btnMainEQ_Click" CssClass="btn" />
    <div  class="card" style="font-size: 19px; z-index: 0;" runat="server" >

        <h3 class="bg form-control"  style="font-size:30px;color:white;height:60px;background-color:darkcyan">&nbsp;&nbsp;ตรวจสอบโอนย้ายด่านฯ</h3>
        
        <div id="divtranFirst" class="card-body table-responsive" style="padding-top:1px" runat="server">
           <h3 class="card-title alert-warning" style="font-size:22px;">ส่วนที่1 : รายละเอียด   <asp:Label ID="refnoo" runat="server" Font-Size="Large" CssClass="text-right"></asp:Label><asp:Label ID="stathead" runat="server" CssClass="" Font-Size="Medium" ></asp:Label><asp:Label runat="server" Text=" )" CssClass="" Font-Size="Medium" ></asp:Label></h3>
            <div class="row" style="padding:1px 1px 1px 1px;height:80px"  >
                <div class="form-group bmd-form-group col-md-2" style="padding:1px 20px 1px 20px;">
                    <label class="bmd-label-floating" style="font-size:20px;height:5px">ประเภทการโอนย้าย</label>
                       <asp:DropDownList ID="ddlTypeEQQ" OnSelectedIndexChanged="ddlTypeEQQ_SelectedIndexChanged" AutoPostBack="true" runat="server" BackColor="#dbfff8" ForeColor="Black"  CssClass="form-control"  ></asp:DropDownList>
                </div>
                <div class="form-group bmd-form-group col-md-2" id="divfirst" runat="server"  style="padding:1px 1px 1px 15px;">
                       <label class="bmd-label-floating" style="font-size:20px;height:5px">ต้นทาง</label>
                       <asp:DropDownList ID="ddlStartEQ" runat="server" AutoPostBack="true"  CssClass="form-control"  ></asp:DropDownList>
                  </div>
                <div class="form-group bmd-form-group col-md-2" id="divEndToll" runat="server" style="padding:1px 1px 1px 15px;">
                       <label class="bmd-label-floating" style="font-size:20px;height:5px">ปลายทาง</label>
                       <asp:DropDownList ID="ddlTollEQ" runat="server"  CssClass="form-control"  ></asp:DropDownList>
                  </div>

                <div class="form-group bmd-form-group col-md-2"  style="padding:1px 15px 1px 15px;" >
                     <label class="bmd-label-floating" style="font-size:large;height:10px">วันที่โอนย้าย</label>
                     <asp:TextBox runat="server" ID="txtDateSend"  CssClass="form-control datepicker" ></asp:TextBox>
               </div>
            </div>
            <div class="row" style="padding:1px 1px 1px 1px;height:140px"  >
                
                <div  class="form-group bmd-form-group col-md-2" style="padding:1px 15px 1px 20px;">
                    <label class="bmd-label-floating" style="font-size:20px;height:5px">ระบุหมายเหตุ(ถ้ามี)</label>
                    <asp:TextBox ID="txtactnote" runat="server" TextMode="MultiLine" Enabled="false" CssClass="form-control" ></asp:TextBox>
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

            </div>

        <div id="divtranSecond"  class="card-body table-responsive"  runat="server">
            <h3 class="card-title alert-warning" style="font-size:22px;">ส่วนที่2 : รายการครุภัณฑ์</h3>


            <br />
            <div class="row" style="padding-left:15px;" >
                <asp:Label ID="lbshowamount" runat="server" ></asp:Label>
            </div>
                <asp:gridview ID="GridAddTran" runat="server" DataKeyNames="trans_act_id"
                    ShowFooter="true"  GridLines="Both" BorderColor="White"  Font-Size="20px" 
                    AutoGenerateColumns="false" OnRowDataBound="GridAddTran_RowDataBound" OnRowDeleting="GridAddTran_RowDeleting"> 
                    <AlternatingRowStyle BackColor="#edebec" />
                    <Columns>
                        <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-Width="20px" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-center" ></asp:Label>
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


            <br />
            
        </div>
        
    </div>
    
       
   
   




    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript"> 
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
