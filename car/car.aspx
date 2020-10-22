<%@ Page title="ยี่ห้อรถ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="car.aspx.cs" Inherits="ClaimProject.car.car" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-row">
        <div class="col-md-3">
            ยี่ห้อ : 
            <asp:TextBox ID="txtCarName" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
        </div>    
    </div>
    <div class="form-row">
        <div class="col-md-3">
            <asp:Button ID="btnCarAdd" runat="server" Text="&#xf067; เพิ่ม" Font-Size="Medium" CssClass="btn btn-success btn-sm align-items-end fa" OnClick="btnCarAdd_Click" OnClientClick="return CompareConfirm('ยืนยันเพิ่มอุปกรณ์ ใช่หรือไม่');" />
        </div>
    </div>
    <hr />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row">
                <div class="col-md-3">
                    ค้นหา 
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <br />
                    <asp:Button ID="btnSearch" runat="server" Text="&#xf002; ค้นหา" Font-Size="Medium" CssClass="btn btn-dark btn-sm align-items-end fa" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="form-row">
                <div class="card">
                    <div class="card-header card-header-warning">
                        <h3 class="card-title">ยี่ห้อ</h3>
                    </div>
                    <div class="card-body table-responsive">
                        <asp:GridView ID="CarGridView" runat="server"
                            DataKeyNames="brandcar_id"
                            GridLines="None"
                            OnRowDataBound="CarGridView_RowDataBound"
                            AutoGenerateColumns="False"
                            CssClass="table table-hover table-sm"
                            OnRowEditing="CarGridView_RowEditing"
                            OnRowCancelingEdit="CarGridView_RowCancelingEdit"
                            OnRowUpdating="CarGridView_RowUpdating"
                            OnRowDeleting="CarGridView_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="ชื่อยี่ห้อ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbCar" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.brandcar_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtECar" size="20" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.brandcar_name") %>' CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                                
                                <asp:CommandField ShowEditButton="True" CancelText="ยกเลิก" EditText="&#xf040; แก้ไข" UpdateText="แก้ไข" HeaderText="ปรับปรุง" ControlStyle-Font-Size="Small" ControlStyle-CssClass="btn btn-outline-warning btn-sm fa" />
                                <asp:CommandField ShowDeleteButton="True" HeaderText="ลบ" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="btn btn-outline-danger btn-sm fa" ControlStyle-Font-Size="Small" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="card-footer">
                        <div class="stats">
                            <asp:Label ID="lbCarNull" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                </div>
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