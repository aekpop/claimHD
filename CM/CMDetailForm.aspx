<%@ Page Title="Maintenance Service Agreement (MA)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMDetailForm.aspx.cs" Inherits="ClaimProject.CM.CMDetailForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @font-face {
            font-family: 'Prompt';
            src: url('/fonts/Prompt-Light.ttf') format('truetype');
        }            
        
    </style>

    <link href="/Content/jquery-ui-1.11.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>
    <script src="/crystalreportviewers13/js/crviewer/crv.js"></script>
    <script src="../Scripts/printThis.js"></script>
    <!-- CSS only -->
    
    <!-- JS, Popper.js, and jQuery -->    
    <script src="../Scripts/jquery-3.5.1.js"></script>
    <script src="../Scripts/umd/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
   

    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">
       <!-- Menu Dropdown -->        
        <div class="btn-group" runat="server" visible="false">
              <button class="btn btn-info"><i class="fas fa-align-justify"></i></button>
              <button class="btn dropdown-toggle btn-info" data-toggle="dropdown">
                <span class="caret"></span>
              </button>
              <ul class="dropdown-menu">
                <li><a href="/CM/DefaultCM">หน้าหลัก</a></li>
                <li><a href="/CM/CMDetailForm">แจ้งซ่อม</a></li>
                <li><a href="/CM/CMEditForm">การแก้ไข</a></li>
                <li><a href="/CM/CMLine">ส่งไลน์</a></li>
                <li><a href="/CM/CMReport">สรุปรายการ</a></li>                
              </ul>
        </div>
        <!-------------------------------- // ------------------------------------> 
        

        <div class="card" style="z-index: 0; ">
            <div class="card-header card-header-warning">
                <div class="card-title">แจ้งซ่อมอุปกรณ์</div>
            </div>
            <div class="card-body table-responsive table-sm">
                <asp:HiddenField ID="txtRef" runat="server" />
                <div class="row">
                    <div class="col-md-3 col-xl-2">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">ด่านฯ :</p>
                            <asp:DropDownList ID="txtCpoint" runat="server" CssClass="form-control custom-select" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>
                   <div class="col-md-2">
                            <div class="form-group bmd-form-group">
                                <p Class="bmd-label-floating ">อาคารย่อย :</p>
                                <asp:TextBox ID="txtPoint" runat="server" CssClass="form-control"  MaxLength="1" Enabled="false" ToolTip="กรณีไม่มีอาคารย่อย ให้เว้นว่าง" onkeypress="return handleEnter(this, event)"/>
                            </div>
                    </div>
                
                    <div class="col-md-2">
                        <div class="form-group bmd-form-group ">
                            <p class="bmd-label-floating ">วันที่ :</p>
                            <asp:TextBox ID="txtSDate" runat="server" CssClass="form-control datepicker" onkeypress="return handleEnter(this, event)"/>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group bmd-form-group ">
                            <p class="bmd-label-floating ">เวลา :</p>
                            <asp:TextBox ID="txtSTime" runat="server" CssClass="form-control time" onkeypress="return handleEnter(this, event)"/>
                        </div>
                    </div>
                                    
                    <div class="col-md-2">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating ">ช่องทาง</p>
                            <asp:DropDownList ID="ddlChanel" runat="server" CssClass="form-control " ></asp:DropDownList>
                        </div>
                    </div>    
                </div>
                <div class="row">
                    <div class="col-md-6 col-xl-4">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">อุปกรณ์</p>
                            <asp:DropDownList ID="txtDeviceAdd" runat="server" CssClass="combobox form-control custom-select" onkeypress="return handleEnter(this, event)" />
                            
                        </div>
                    </div>
                    <div class="col-md-6 col-xl-4">
                        <div class="form-group bmd-form-group">
                            <p class="bmd-label-floating">ปัญหา/อาการ</p>
                            <asp:TextBox ID="txtProblem" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)" />
                            
                        </div>
                    </div>
                                         
                    <!-- แนบรูป -->                                      
                    <div class="col-md-4">
                       <div class="form-group bmd-form-group">
                           <p class="bmd-label-floating">แนบรูปภาพ</p>
                           <div class="col" runat="server" id="diveditpic">
                                <asp:FileUpload ID="fileImg" runat="server" CssClass="custom-file" lang="en" />
                               <asp:Label ID="lbNameFileImg" runat="server" CssClass="text text-dark" />
                            </div>
                         <div class="col-md-1">
                                 <asp:Label ID="pkeq" runat="server" visible="true" Font-Size="Smaller" ></asp:Label>
                          </div>
                        </div>
                     </div>
                </div>
                <hr />

                <div class="row">
                    <div class="col-md text-center">
                        <asp:LinkButton ID="btnSaveCM" runat="server" Visible="true" Font-Size="20px" CssClass="btn btn-success btn-sm" OnClientClick="return CompareConfirm('ยืนยัน แจ้งซ่อมอุปกรณ์ ใช่หรือไม่');" OnClick="btnSaveCM_Click" >
                             แจ้งซ่อม</asp:LinkButton>
                        <div id="Loading" class="d-flex justify-content-center" runat="server" visible="false">
                              <div class="spinner-border" role="status">
                                <span class="sr-only">Loading...</span>
                              </div>
                            </div>
                        <asp:LinkButton ID="btnEditCM" runat="server" Font-Size="20px" CssClass="btn btn-warning btn-sm" OnClientClick="return CompareConfirm('ยืนยัน แก้ไขแจ้งซ่อมอุปกรณ์ ใช่หรือไม่');" OnClick="btnEditCM_Click">แก้ไข</asp:LinkButton>
                        <asp:LinkButton ID="btnCancelCM" runat="server" Font-Size="20px" CssClass="btn btn-dark btn-sm" OnClick="btnCancelCM_Click">ยกเลิก</asp:LinkButton>
                        <asp:LinkButton ID="btnDeleteCM" runat="server" Font-Size="20px" CssClass="btn btn-danger btn-sm" OnClientClick="return CompareConfirm('ยืนยัน ลบข้อมูลการแจ้งซ่อมอุปกรณ์ ใช่หรือไม่');" OnClick="btnDeleteCM_Click">ลบ</asp:LinkButton>
                    </div>
                </div>
            </div>       
        <br />
    </div>

    <div id="DivCMGridView" runat="server" >
        <div class="card" style="z-index: 0" >
            <div class="card-header card-header-warning">
                <div class="card-title">รายการแจ้งซ่อมอุปกรณ์</div>
            </div>
            <div class="card-body table-responsive table-sm">
                <!--<div class="row">
                    <div class="col-md" >
                        <label ID="lbTollz" class="bmd-label-floating">ด่านฯ : </label>
                        <asp:DropDownList ID="txtCpointSearch" runat="server" CssClass="form-control custom-select" ></asp:DropDownList>
                    </div>
                    <div class="col-md">
                        <label ID="lbBudgetz" class="bmd-label-floating">ปีงบประมาณ : </label>
                        <asp:DropDownList ID="ddlBudgetcc" runat="server" CssClass="form-control custom-select" ></asp:DropDownList>
                    </div>
                    <div class="col-md">
                        <br />
                        <asp:Button ID="btnSearchAddd" runat="server" Text="ค้นหา" Visible="false" CssClass="btn btn-success" OnClick="btnSearchAddd_Click"/>
                    </div>

                    <div class="col-md" >
                        <br />
                        <asp:Button ID="btnToReport" runat="server" Text="ไปยังหน้ารายงาน" Visible="false" CssClass="btn btn-warning" OnClick="btnToReport_Click"/>
                    </div>
                </div>-->
                <br />
                <asp:Panel ID="Panel1" runat="server" >
                    <asp:GridView ID="CMGridView" runat="server"
                        AutoGenerateColumns="False" CssClass="col table table-striped table-hover "
                        HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="ActiveBorder"
                        HeaderStyle-Font-Size="18px"
                        RowStyle-CssClass="text-center"
                        OnRowDataBound="CMGridView_RowDataBound" Font-Size="15px" CellPadding="4" ForeColor="#000033" GridLines="None" PageSize="20">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ" >
                                <ItemTemplate>
                                    <asp:Label ID="lbRowNum" runat="server" Text="" CssClass="text-center" > </asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="ด่านฯ" >
                                <ItemTemplate>
                                    <asp:Label ID="lbCpoint" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name")+" "+DataBinder.Eval(Container, "DataItem.cm_point") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ช่องทาง" >
                                <ItemTemplate>
                                    <asp:Label ID="lbChannel" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อุปกรณ์" ItemStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:Label ID="lbDeviceName" runat="server"  Text='<%# new ClaimProject.Config.ClaimFunction().ShortText(DataBinder.Eval(Container, "DataItem.device_name").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อาการชำรุด" ItemStyle-Width="250px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbProblem" runat="server"  Text='<%#new ClaimProject.Config.ClaimFunction().ShortText( DataBinder.Eval(Container, "DataItem.cm_detail_problem").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันแจ้งซ่อม" >
                                <ItemTemplate>
                                    <asp:Label ID="lbSDate" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลาแจ้งซ่อม" >
                                <ItemTemplate>
                                    <asp:Label ID="lbSTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_stime")+" น." %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ผู้แจ้ง" ControlStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbcmUser" runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().ShortText(DataBinder.Eval(Container, "DataItem.name").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditCM" runat="server"  CssClass="btn btn-sm btn-outline-warning"  Font-Size="15px" ToolTip="แก้ไขรายละเอียดการแจ้งซ่อม" OnCommand="btnEdit_Command" OnClientClick="return CompareConfirm('ยืนยัน แก้ไขรายการใช่หรือไม่')"><i class="fas fa-edit"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="White" CssClass="text-left" Font-Bold="True" ForeColor="#000033"  />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" CssClass="text-left" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
    </div>
        <!--model confirm-->
            <div class="modal fade" id="EditModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Label ID="pkedit" runat="server" visible="true" Font-Size="Smaller" ></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="H3"></h4>
                        </div>
                        <asp:UpdatePanel ID="upDel" runat="server">

                    <ContentTemplate>
                        <div class="modal-body">
                            คุณต้องการแก้ไขรายการนี้ใช่ หรือ ไม่
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                            <asp:Button ID="btnEditCMM" runat="server"  CssClass="btn btn-success" Text="Confirm" OnCommand="btnEditCMM_Command"/>
                        </div>
                        </ContentTemplate>
                </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    <script src="/Scripts/jquery-migrate-3.0.0.min.js"></script>
    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript"> 
        function ClickAdd() {
            $("#addCMModal").modal('show');
            return false;
        }

        function CompareConfirm(msg) {
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

        function unhide(){
	        document.getElementById("Loading").removeAttribute("hidden");
        }

        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {
                alert('ระบบกำลังประมวลผล ... กรุณากด "ตกลง" เพื่อทำรายการต่อไป');
                return false;
            }
        }

        function ComfirmEdit() 
            {
              $('#EditModal').modal(); // initialized with defaults
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

         $(document).ready(function(){
          $('[data-toggle="tooltip"]').tooltip();   
        });

        $(function () {
         <% if (alerts != "")
        { %>
            demo.showNotification('top', 'center', '<%=icons%>', '<%=alertTypes%>', '<%=alerts%>');
        <% } %>
        });


    </script>
</asp:Content>
