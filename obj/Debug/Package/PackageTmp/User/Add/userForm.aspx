﻿<%@ Page Title="ข้อมูลผู้ใช้" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userForm.aspx.cs" Inherits="ClaimProject.User.Add.userForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/HRSProjectScript.js"></script>

    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">

    <div class="card">
            <div class="card-header card-header-warning">
                <div class="card-title">เพิ่มผู้ใช้งาน</div>
            </div>
            <div class="card-body ">
                <div class="form-row">
        <div class="col-md-3">
            Username 
            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
        </div>
        <div class="col-md-3">
            Password 
            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" onkeypress="return handleEnter(this, event)"></asp:TextBox>
        </div>
        <div class="col-md-3">
            Confirm Password 
            <asp:TextBox ID="txtCPass" runat="server" CssClass="form-control" TextMode="Password" onkeypress="return handleEnter(this, event)"></asp:TextBox>
        </div>

    </div>
    <br />
    <div class="row">
        
        <div class="col-md-3">
            ชื่อ-สกุล
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
        </div>
        <div class="col-md-3">
            สิทธ์การใช้งาน
            <asp:DropDownList ID="txtLevel" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-md-3">
            ด่านฯ
            <asp:DropDownList ID="ddlCpoint" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
            </div>
                <br />
        <div class="row">
                 <div class="col text-center">
                <asp:Button ID="btnUserAdd" runat="server" Text="&#xf067; เพิ่ม" Font-Size="Medium" CssClass="btn btn-success btn-sm align-items-end fa" OnClick="btnUserAdd_Click" OnClientClick="return CompareConfirm('ยืนยันเพิ่มผู้ใช้งาน ใช่หรือไม่');"/>
            </div>
        </div>
            </div>
    </div>
    
    <hr />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row">
                <div class="card">
                    <div class="card-header card-header-warning">
                        <div class="card-title">รายการผู้ใช้งาน</div>
                    </div>
                    <div class="card-body table-responsive">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1" runat="server" visible="true">
                               <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-white " OnClick="btnSearch_Click"></asp:LinkButton>
                            </div>
                        </div>
                        <br />
                        <asp:GridView ID="UserGridView" runat="server"
                            DataKeyNames="id"
                            GridLines="None"
                            OnRowDataBound="UserGridView_RowDataBound"
                            AutoGenerateColumns="False"
                            CssClass="table table-hover table-sm"
                            OnRowEditing="UserGridView_RowEditing"
                            OnRowCancelingEdit="UserGridView_RowCancelingEdit"
                            OnRowUpdating="UserGridView_RowUpdating"
                            OnRowDeleting="UserGridView_RowDeleting"
                            AllowSorting="true"
                            AllowPaging="true"
                            PageSize="50"
                            OnPageIndexChanging="UserGridView_PageIndexChanging"
                            PagerSettings-Mode="NumericFirstLast" HeaderStyle-Font-Bold="true" HeaderStyle-Height="70">
                            <Columns>
                                <asp:TemplateField HeaderText="Username" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbUser" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.username") %>'></asp:Label>
                                    </ItemTemplate>
                                    
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEUser" size="20" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.username") %>' CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Password" >
                                <ItemTemplate>
                                        <asp:Label ID="lbPass" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.password") %>'></asp:Label>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อ-สกุล">
                                    <ItemTemplate>
                                        <asp:Label ID="lbName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEName" size="20" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name") %>' CssClass="form-control" onkeypress="return handleEnter(this, event)"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="สิทธ์การใช้งาน" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbPrivilege" runat="server" Text='<%# new ClaimProject.Config.ClaimFunction().GetLevel(int.Parse(DataBinder.Eval(Container, "DataItem.level").ToString())) %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="txtEPrivilege" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ด่านฯ" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbCpoint" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cpoint_name").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlCpoint" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:CommandField ShowEditButton="True" CancelText="ยกเลิก" EditText="&#xf040; แก้ไข" UpdateText="ตกลง" ControlStyle-Font-Size="Small" ControlStyle-CssClass="btn btn-outline-warning btn-sm fa" />
                                <asp:CommandField ShowDeleteButton="True" DeleteText="&#xf014; ลบ" ControlStyle-CssClass="btn btn-outline-danger btn-sm fa " ControlStyle-Font-Size="Small" />
                            </Columns>
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        </asp:GridView>
                    </div>
                    <div class="card-footer">
                        <div class="stats">
                            <asp:Label ID="lbUserNull" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
       </div>
       
        </ContentTemplate>
    </asp:UpdatePanel>
        </div>
    <script type="text/javascript">
        

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


        function controlEnter(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;  
            if (keyCode == 13)
            {   
               // __doPostBack(obj, '');
               document.getElementById(obj).click();
                   return false;      
             }      
             else  {
                   return true; 
            } 
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


    </script>
</asp:Content>