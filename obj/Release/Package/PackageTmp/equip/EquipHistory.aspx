<%@ Page Title="งานครุภัณฑ์ / ประวัติครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipHistory.aspx.cs" Inherits="ClaimProject.equip.EquipHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }
    </style>
    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">
        <!-- Menu Dropdown -->        
        <div class="btn-group">
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
        <!-------------------------------- // ------------------------------------>
        <div id="MainBody" class="card" style="z-index: 0; ">
            <div class="card-header card-header-info">
                <div class="card-title">
                    <i class="fas fa-history"></i>&nbsp ประวัติการโอนย้ายของครุภัณฑ์</div>
            </div>
            <div class="card-body table-responsive">
                <div id="Search" class="row">
                    <div class="form-group bmd-form-group col-xl-3 col-md-6">
                        <span class = "label label-primary">หมายเลขครุภัณฑ์ : </span>
                        <asp:TextBox id="txtSearchEq" runat="server" CssClass="form-control" aria-describedby="SearchEqHelp" placeholder="กรอกตัวเลขอย่างน้อย 1 ตัวอักษร" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                       
                    </div> 
                </div>            
                <div class="col-xl-6 text-left">
                        <asp:Button ID="btnSearchEq" runat="server" CssClass="btn btn-info is" OnClick="btnSearchEq_Click" Text="ค้นหา"></asp:Button>
                </div>
            </div>
        </div>
        <div class="row" style="padding-left:20px; font-size:small">
                    <asp:Label ID="titlegrid" runat="server" text="" Visible="false"  ></asp:Label>                   
                </div>
        <br />
        <asp:Panel ID="Panel" runat="server" >
            <asp:GridView ID="GridViewSearchEq" runat="server"
                OnRowDataBound="GridViewSearchEq_RowDataBound"
                AutoGenerateColumns="false"
                GridLines="None"
                CssClass="table table-hover table-condensed table-sm">
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <asp:Label ID="lbClaimNumrow" Text='<%#  Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="หมายเลขอ้างอิง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbRef" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.transfer_id") %>'  />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="หมายเลขครุภัณฑ์" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbEquip" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.equipment_no") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ด่านฯต้นทาง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbCpointS" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ด่านฯปลายทาง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbCpointE" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="วันที่ส่ง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbDate" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ผู้ส่ง" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbUserS" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.name_send") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="สถานะโอนย้าย" HeaderStyle-CssClass="text-left" ItemStyle-CssClass="text-left" >
                                <ItemTemplate>
                                            <asp:Label ID="lbStatus" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>

    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript">

    /***********************************************
    * Disable "Enter" key in Form script- By Nurul Fadilah(nurul@REMOVETHISvolmedia.com)
    * This notice must stay intact for use
    * Visit http://www.dynamicdrive.com/ for full source code
    ***********************************************/
                
    function handleEnter (field, event) {
		    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
		    if (keyCode == 13) {
			    var i;
			    for (i = 0; i < field.form.elements.length; i++)
				    if (field == field.form.elements[i])
					    break;
			    i = (i + 1) % field.form.elements.length;
			    field.form.elements[i].focus();
			    return false;
		    } 
		    else
		    return true;
	    }      

    </script>


</asp:Content>
