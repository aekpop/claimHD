﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMLine.aspx.cs" Inherits="ClaimProject.CM.CMLine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="card" style="z-index: 0">
            <div class="card-header card-header-warning">
            </div>
            <div class="card-body table-responsive table-sm" >
                <div class="row">
                    
                        <label class="bmd-label-floating">ด่านฯ : </label>
                        
                        <asp:DropDownList ID="ddlCMLine" runat="server" CssClass="form-control custom-select" OnSelectedIndexChanged="ddlCMLine_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                        
                        <asp:Label ID="lbBuild" runat="server" Visible="false" Text="อาคาร :" ></asp:Label> 
                        <asp:DropDownList ID="ddlAnnex" runat="server" Visible="false" CssClass="control-form" >
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                        </asp:DropDownList>
                    <label class="bmd-label-floating">ผลัด : </label>
                    <asp:DropDownList ID="ddlShift" runat="server" CssClass="control-form">
                            <asp:ListItem Value="0">ผลัดที่ 1 (22.00 - 06.00)</asp:ListItem>
                            <asp:ListItem Value="1">ผลัดที่ 2 (06.00 - 14.00)</asp:ListItem>
                            <asp:ListItem Value="2">ผลัดที่ 3 (14.00 - 22.00)</asp:ListItem>
                    </asp:DropDownList>

                        <asp:Button ID="btnrecm" runat="server" Text="แสดงรายงาน" OnClick="btnrecm_Click"  /> &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="กลับหน้าหลัก" OnClick="btnBack_Click"  />
                
                </div>
                                      
                    <div class="col-md" >
                        <asp:Button ID="printimg" runat="server" Text="photo" Visible="false" OnClick="printimg_Click"  />
                    </div>
                </div>
                <br />
                
                    <asp:Label ID="lbHeadToll" runat="server" Font-Bold="true" Font-Size="X-Large" Visible="false"></asp:Label>
                    &nbsp;<asp:Label ID="lbShift" runat="server" Font-Bold="true" Font-Size="X-Large" Visible="false" ></asp:Label>
                    &nbsp;<asp:Label ID="date" runat="server" Font-Bold="true" Font-Size="X-Large" Text="วันที่" Visible="false"></asp:Label>
                    &nbsp;<asp:Label ID="lbDateNow" runat="server" Font-Bold="true" Font-Size="X-Large" Visible="false"></asp:Label>
                
                    <asp:GridView ID="gridHeadToll" runat="server">

                    </asp:GridView>

                    <asp:GridView ID="gridCMLine" runat="server" 
                        AutoGenerateColumns="False" 
                        CssClass="col table table-striped table-hover"                         
                        HeaderStyle-BackColor="ActiveBorder" 
                        OnRowDataBound="gridCMLine_RowDataBound" 
                        Font-Size="13px"  CellPadding="4" 
                        ForeColor="#333333" GridLines="Both" 
                        BorderColor="Black" OnRowCreated="gridCMLine_RowCreated">
                        
                        <AlternatingRowStyle BackColor="White"  />                                             
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ" ControlStyle-Width="25px" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbnoo" runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่แจ้งซ่อม" ControlStyle-Width="70px" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbSDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_sdate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เวลาแจ้งซ่อม" ControlStyle-Width="70px" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbSTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_stime")+" น." %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ช่องทาง" ControlStyle-Width="100px" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbChannel"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.locate_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อุปกรณ์" ControlStyle-Width="400px" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.device_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อาการที่ชำรุด" ControlStyle-Width="300px" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbProblem" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cm_detail_problem") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สถานะ" ControlStyle-Width="100px" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbStt" runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1"  Font-Bold="True" ForeColor="White" Font-Size="Larger" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB"></RowStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </br>
                        <asp:HiddenField ID="hfImageData" runat="server" />
                        <asp:Button ID="btnExport" Text="Export to Image" runat="server" UseSubmitBehavior="false" OnClick="btnExport_Click" OnClientClick = "return ConvertToImage(this)"  />
            </div>
        </div>

     
    <script src="/Scripts/html2canvas.js"></script> 
    <script src="/Scripts/jquery-ui-1.11.4.custom.js"></script>
    <script src="/Scripts/jquery-1.12.4.min.js"></script>
    <script src="/Scripts/moment.min.js"></script>
    <script src="/Scripts/ClaimProjectScript.js"></script>
    <script type="text/javascript">
    function ConvertToImage(btnExport) {
        html2canvas($("[id*=gridCMLine]")[0]).then(function (canvas) {
            var base64 = canvas.toDataURL();
            $("[id*=hfImageData]").val(base64);
            __doPostBack(btnExport.name, "");
        });
        return false;
        }
                $("#btnExport").on('click', function() {             
                    var imgageData =  
                    getCanvas.toDataURL("image/png"); 
              
                // Now browser starts downloading  
                // it instead of just showing it 
                var newData = imgageData.replace( 
                /^data:image\/png/, "data:application/octet-stream"); 
                
                $("#btnExport").attr( 
                "download", "GeeksForGeeks.png").attr( 
                "href", newData); 
            }); 
</script>        
    </form>    
</body>    
</html>
