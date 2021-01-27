<%@ Page Title="งานอุบัติเหตุ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClaimDevice.aspx.cs" Inherits="ClaimProject.Claim.ClaimDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div Id="lbSearch" class="card" style="z-index: 0; font-size: medium">
        <div class="card-header card-header-warning">
            <h3 class="card-title">รายการอุปกรณ์ค้างซ่อม</h3>
        </div>
        <div class="card-body table-responsive table-sm">
            <div class="row">
                <div class="col-md-2 text-right">
                    <asp:Label ID="Label6" runat="server" Text="ด่านฯ : "></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="txtSearchCpoint" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-2 text-right">
                    <asp:Label ID="Label1" runat="server" Text="อาคารย่อย :"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtPoint" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 text-right">
                    <asp:Label ID="lbChannel" runat="server" Text="ตู้ :"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="txtSearchChannel" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
           </div>
            <br />
            <div class="row">
                <div class="col-md-2 text-right">
                    <asp:Label ID="Label5" runat="server" Text="สถานะ : "></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="txtSearchStatus" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <!--<div class="col-md-1">
                    <asp:CheckBox ID="CheckDeviceNotDamaged" runat="server" />
                    <label-->
            
                <div class="col-md-2 text-right">
                    <asp:Label ID="lbDeviceDamage" runat="server" Text="อุปกรณ์ :"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="txtDeviceDamage" runat="server" CssClass="combobox form-control custom-select"></asp:DropDownList>
                </div>
                
                </div>
            <br />
            <div class="row">
                
                 <div class =" col-md-2 text-right">
                    <asp:Label Id ="lbCheckAllDay" runat="server" Text="ช่วงเวลา : เลือกทั้งหมด" ></asp:Label> 
                </div>
                <div class =" col-md-2 text-left">
                    <asp:CheckBox ID ="CheckAllDay" runat="server" AutoPostBack="True" CssClass="text-xl-center" OnCheckedChanged="CheckAllDay_CheckedChanged"/>
                    </div>

                <div class="col-md-2 text-right">
                    <asp:Label ID="lbDateStart" runat="server" Text="ตั้งแต่วันที่ : "></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtDateStart" runat="server" CssClass="form-control datepicker"></asp:TextBox>
                </div>
                <div class="col-md-2 text-right">
                    <asp:Label ID="lbDateEnd" runat="server" Text="ถึงวันที่ : "></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtDateEnd" runat="server" CssClass="form-control datepicker"></asp:TextBox>
                </div>
                
            </div>
           <hr />
            <div class="row">              
                <div class="col-md-6 text-right">
                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-default fa" Font-Size="Medium" OnClick="btnSearch_Click">&#xf002; ค้นหา</asp:LinkButton>
                </div>

                <div class="col-md-6 text-left">
                    <asp:LinkButton ID="btnExport" runat="server" CssClass="btn btn-dark fa" Font-Size="Medium" OnClick="btnExport_Click">&#xf1c3; Export To Excel</asp:LinkButton>
                </div>
            </div>
            <asp:Label ID="lbClaimNull" runat="server" Text="" CssClass="text-success"></asp:Label>
        </div>
        
   </div>
    <div id="Div1" runat="server" >
        <!--<div class="card" style="z-index: 0"> -->           
            <!--<div class="card-body table-responsive table-sm">-->

                <asp:GridView ID="ClaimGridView" runat="server"
                    AutoGenerateColumns="False" 
                    CssClass="table table-hover table-sm"
                    HeaderStyle-CssClass="text-left" 
                    HeaderStyle-BackColor="ActiveBorder"
                    HeaderStyle-Font-Size="17px"
                    HeaderStyle-Height="50px"
                    RowStyle-Height="50px"
                    RowStyle-CssClass="text-left" 
                    GridLines="None"                    
                    OnRowDataBound="ClaimGridView_RowDataBound" 
                    Font-Size="14px">
                    <Columns>
                        <asp:TemplateField HeaderText="ลำดับ">
                            <ItemTemplate>
                                <asp:Label ID="lbClaimNumrow" Text='<%#  Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="เลขที่(ฝ่ายฯ)">
                            <ItemTemplate>
                                <asp:Label ID="lbTechnoNumdoc" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.techno_doc_num")+" /"+DataBinder.Eval(Container, "DataItem.techno_doc_date") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ด่านฯ">
                            <ItemTemplate>
                                <asp:Label ID="lbClaimCpoint" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name")+" "+DataBinder.Eval(Container, "DataItem.claim_point") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ช่องทาง">
                            <ItemTemplate>
                                <asp:Label ID="lbClaimChannel" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.claim_detail_cb_claim") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="อุปกรณ์"  ControlStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lbClaimDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="อาการที่ชำรุด"  ControlStyle-Width="250px">
                            <ItemTemplate>
                                <asp:Label ID="lbClaimProblem" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_damaged") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่">
                            <ItemTemplate>
                                <asp:Label ID="lbClaimSDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.claim_start_date")+" "+DataBinder.Eval(Container, "DataItem.claim_detail_time")+" น." %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เวลา">
                            <ItemTemplate>
                                <asp:Label ID="lbClaimSTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.claim_detail_time")+" น." %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="นับเวลา">
                        <ItemTemplate>
                            <asp:Label ID="lbDay" runat="server"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="สถานะ">
                            <ItemTemplate>
                                <asp:Label ID="lbClaimStatus" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.status_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>                    
                </asp:GridView>
            </div>
        <!--</div>-->
   <!-- </div> -->
    <script>
            function btnSearch_Click() {
                var x = document.getElementById("lbSearch");
                if (x.style.display === "none") {
                    x.style.display = "block";
                } else {
                    x.style.display = "none";
                }
            }
</script>
</asp:Content>
