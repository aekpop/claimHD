<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClaimProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-2 text-right">
                    <asp:Label ID="Label1" runat="server" Text="ปีงบประมาณ : "></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="txtYear" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="txtYear_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>

            <br />
            <div class="row">
                <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="boxUserSystem">
                    <div class="card card-stats">
                        <div class="card-header card-header-danger card-header-icon">
                            <div class="card-icon">
                                <i class="fas fa-car-crash"></i>
                            </div>
                            <h4 class="card-category">แจ้งอุบัติเหตุ</h4>
                            <h4 class="card-title">
                                <asp:Label ID="lbAlert" runat="server" Text="Label"></asp:Label>
                            </h4>
                        </div>
                        <div class="card-footer">
                            <div class="stats">
                                <i class="fa fa-th-list"></i>&nbsp
                        <asp:LinkButton ID="btnDetailAlert" runat="server" OnClick="btnDetailAlert_Click">รายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div2">
                    <div class="card card-stats">
                        <div class="card-header card-header-secondary card-header-icon">
                            <div class="card-icon">
                                <i class="fas fa-file-export"></i>
                            </div>
                            <h4 class="card-category">ส่งเรื่องเข้ากองฯ</h4>
                            <h4 class="card-title">
                                <asp:Label ID="lbSend" runat="server" Text="Label"></asp:Label>
                            </h4>
                        </div>
                        <div class="card-footer">
                            <div class="stats">
                                <i class="fa fa-th-list"></i>&nbsp
                        <asp:LinkButton ID="btnSendto" runat="server" OnClick="btnSendto_Click">รายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div1">
                    <div class="card card-stats">
                        <div class="card-header card-header-warning card-header-icon">
                            <div class="card-icon">
                                <i class="fa fa-clipboard"></i>
                            </div>
                            <h4 class="card-category">ขอใบเสนอราคา</h4>
                            <h4 class="card-title">
                                <asp:Label ID="lbQuote" runat="server" Text="Label"></asp:Label>
                            </h4>
                        </div>
                        <div class="card-footer">
                            <div class="stats">
                                <i class="fa fa-th-list"></i>&nbsp
                        <asp:LinkButton ID="btnDetailQute" runat="server" OnClick="btnDetailQute_Click">รายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div4">
                    <div class="card card-stats">
                        <div class="card-header card-header-info card-header-icon">
                            <div class="card-icon">
                                <i class="fa fa-wrench"></i>
                            </div>
                            <h4 class="card-category">อยู่ระหว่างการซ่อม</h4>
                            <h4 class="card-title">
                                <asp:Label ID="lbRepair" runat="server" Text="Label"></asp:Label>
                            </h4>
                        </div>
                        <div class="card-footer">
                            <div class="stats">
                                <i class="fa fa-th-list"></i>&nbsp
                        <asp:LinkButton ID="btnWait" runat="server" OnClick="btnWait_Click">รายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div5">
                    <div class="card card-stats">
                        <div class="card-header card-header-success card-header-icon">
                            <div class="card-icon">
                                <i class="far fa-folder-open"></i>
                            </div>
                            <h4 class="card-category">ส่งงาน/เสร็จสิ้น</h4>
                            <h4 class="card-title">
                                <asp:Label ID="lbSuccess" runat="server" Text="Label"></asp:Label>
                            </h4>
                        </div>
                        <div class="card-footer">
                            <div class="stats">
                                <i class="fa fa-th-list"></i>&nbsp
                        <asp:LinkButton ID="btnSuccessJob" runat="server" OnClick="btnSuccessJob_Click">รายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div3">
                    <div class="card card-stats">
                        <div class="card-header card-header-primary card-header-icon">
                            <div class="card-icon">
                                <i class="fa fa-car"></i>
                            </div>
                            <h4 class="card-category">รายงานเพื่อทราบ</h4>
                            <h4 class="card-title">
                                <asp:Label ID="lbReport" runat="server" Text="Label"></asp:Label>
                            </h4>
                        </div>
                        <div class="card-footer">
                            <div class="stats">
                                <i class="fa fa-th-list"></i>&nbsp
                        <asp:LinkButton ID="btnReport" runat="server" OnClick="btnReport_Click">รายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

                <div class="col-lg-3 col-md-6 col-sm-6" runat="server" id="Div6">
                    <h3> ประกาศข่าวสารในกลุ่มไลน์</h3>

                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown-item">
                        <asp:ListItem Text="Toll:อุบัติเหตุ" Value="uQQdUNuFfBphgSugC3OUa1lSjmovi4XINOAe2VwIczo" ></asp:ListItem>
                        <asp:ListItem Text="Toll:CM_M9" Value="TcwUZJSfjZJf5KPOXd6HEoB6Bx4oXVB6zTAcRzLnf5F"></asp:ListItem>
                        <asp:ListItem Text="ทดสอบ" Value="g0Zinn2LGsXH7MqNl6LqRRAloneiupRMel3VaC3TVdJ"></asp:ListItem>
                    </asp:DropDownList><br />
                </div>
               
           
                        <div class="col-lg-3 col-md-6 col-sm-6">
                             <h3>ข้อความ</h3> 
                             <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" ></asp:TextBox>
                        </div>

                        <div class="col-lg-3 col-md-6 col-sm-6">
                            URL รูปภาพ
                            <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>
                        </div>
             <div class="col-lg-3 col-md-6 col-sm-6">
                    <asp:LinkButton ID="Button1" runat="server" Text="ส่ง" CssClass="btn btn-success" OnClientClick="return CompareConfirm('ยืนยันการส่งข้อมูล');" OnClick="Button1_Click" />
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
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
    </script>
</asp:Content>
