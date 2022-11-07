<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClaimProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Claim.css" rel="stylesheet" />
    <style>
        .input-group-text {
            font-size: 1.5rem;
        }
        .btn {
            position: relative;
            padding: 0px 30px;
            margin: 0rem 0px;
            font-size: 1.25rem;
            font-weight: 400;
            line-height: 1.42857;
            text-decoration: none;
            text-transform: uppercase;
            letter-spacing: 0;
            cursor: pointer;
            background-color: transparent;
            border: 0;
            border-radius: 0.2rem;
            outline: 0;
            transition: box-shadow 0.2s cubic-bezier(0.4, 0, 1, 1), background-color 0.2s cubic-bezier(0.4, 0, 0.2, 1);
            will-change: box-shadow, transform;
        }
    </style>

    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">
        <asp:UpdatePanel runat="server">
        <ContentTemplate>          
            <div class="row">
                <div class="col-md-9">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text text-lg-center" id="basic-addon1">ปีงบประมาณ</span>
                            <asp:DropDownList ID="txtYear" runat="server" AutoPostBack="true" CssClass="input-group-text dropdown-toggle dropdown-toggle-split" OnSelectedIndexChanged="txtYear_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <asp:TextBox id="txtsearch" runat="server" CssClass="input-group-text form-control" placeholder="ค้นหา...เลขควบคุม" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-outline-warning input-group-text" Text="Search" OnCommand="btnSearch_Command"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xl-3 col-lg-6">
                    <div class="card l-bg-red">
                        <div class="card-statistic-3 p-4">
                            <div class="card-icon card-icon-large"><i class="fas fa-car-crash"></i></div>
                            <div class="mb-4">
                                <div class="card-category mb-0">แจ้งอุบัติเหตุ</div>
                            </div>
                            <div class="row align-items-center mb-2 d-flex">
                                <div class="col-8">
                                    <div class="card-title">
                                        <div class="d-flex align-items-center mb-0 ">
                                            <asp:Label ID="lbAlert" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <div class="stats">
                                <asp:LinkButton ID="btnDetailAlert" runat="server" CssClass="text-white-50" OnClick="btnDetailAlert_Click"> <i class="fa fa-th-list"></i>&nbspรายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-lg-6">
                    <div class="card l-bg-orange-dark">
                        <div class="card-statistic-3 p-4">
                            <div class="card-icon card-icon-large"><i class="fas fa-file-export"></i></div>
                            <div class="mb-4">
                                <div class="card-category mb-0">รายงานอุบัติเหตุ (ส่งกองฯ)</div>
                            </div>
                            <div class="row align-items-center mb-2 d-flex">
                                <div class="col-8">
                                    <div class="card-title">
                                        <div class="d-flex align-items-center mb-0 ">
                                            <asp:Label ID="lbSend" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <div class="stats">
                                <asp:LinkButton ID="btnSendto" runat="server" CssClass="text-white-50" OnClick="btnSendto_Click"> <i class="fa fa-th-list"></i>&nbspรายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-lg-6">
                    <div class="card l-bg-yellow-dark">
                        <div class="card-statistic-3 p-4">
                            <div class="card-icon card-icon-large"><i class="fas fa-clipboard"></i></div>
                            <div class="mb-4">
                                <div class="card-category mb-0">เสนอราคา</div>
                            </div>
                            <div class="row align-items-center mb-2 d-flex">
                                <div class="col-8">
                                    <div class="card-title">
                                        <div class="d-flex align-items-center mb-0 ">
                                            <asp:Label ID="lbQuote" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <div class="stats">
                                <asp:LinkButton ID="btnDetailQute" runat="server" CssClass="text-white-50" OnClick="btnDetailQute_Click"> <i class="fa fa-th-list"></i>&nbspรายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-lg-6">
                    <div class="card l-bg-dark">
                        <div class="card-statistic-3 p-4">
                            <div class="card-icon card-icon-large"><i class="fas fa-balance-scale""></i></div>
                            <div class="mb-4">
                                <div class="card-category mb-0">ประเมินราคา (ส่งนิติกร)</div>
                            </div>
                            <div class="row align-items-center mb-2 d-flex">
                                <div class="col-8">
                                     <div class="card-title">
                                        <div class="d-flex align-items-center mb-0 ">
                                             <asp:Label ID="lbRepair" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
                                        </div>
                                     </div>
                                </div>
                            </div>                           
                        </div>
                         <div class="card-footer">
                            <div class="stats">
                                    <asp:LinkButton ID="btnWait" runat="server" CssClass="text-white-50" OnClick="btnWait_Click"> <i class="fa fa-th-list"></i>&nbspรายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-lg-6">
                    <div class="card l-bg-green-dark">
                        <div class="card-statistic-3 p-4">
                            <div class="card-icon card-icon-large"><i class="fas fa-thumbs-up"></i></div>
                            <div class="mb-4">
                                <div class="card-category mb-0">ส่งงาน/เสร็จสิ้น</div>
                            </div>
                            <div class="row align-items-center mb-2 d-flex">
                                <div class="col-8">
                                     <div class="card-title">
                                        <div class="d-flex align-items-center mb-0 ">
                                            <asp:Label ID="lbSuccess" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
                                        </div>
                                     </div>
                                </div>
                            </div>                           
                        </div>
                         <div class="card-footer">
                            <div class="stats">
                                    <asp:LinkButton ID="btnSuccessJob" runat="server" CssClass="text-white-50" OnClick="btnSuccessJob_Click"> <i class="fa fa-th-list"></i>&nbspรายละเอียด</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-xl-3 col-lg-6">
                    <div class="card l-bg-blue-dark">
                        <div class="card-statistic-3 p-4">
                            <div class="card-icon card-icon-large"><i class="fas fa-car"></i></div>
                            <div class="mb-4">
                                <div class="card-category mb-0">รายงานเพื่อทราบ</div>
                            </div>
                            <div class="row align-items-center mb-2 d-flex">
                                <div class="col-8">
                                     <div class="card-title">
                                        <div class="d-flex align-items-center mb-0 ">
                                            <asp:Label ID="lbReport" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
                                        </div>
                                     </div>
                                </div>
                            </div>                           
                        </div>
                         <div class="card-footer">
                            <div class="stats">
                                    <asp:LinkButton ID="btnReport" runat="server" CssClass="text-white-50" OnClick="btnReport_Click"> <i class="fa fa-th-list"></i>&nbspรายละเอียด</asp:LinkButton>
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
    </div>
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
