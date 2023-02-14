<%@ Page Title="TECHNO/REPORT" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TechnoReport.aspx.cs" Inherits="ClaimProject.Techno.TechnoReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" style="font-family:'Prompt',sans-serif;">
        <div id="MainBody" class="card" style="z-index: 0; ">
            <div class="card-header ">
                <div class="card-title">รายงานอุบัติเหตุ</div>
            </div>
            <div class="card-body table-responsive">
                <div class="row">
                        <div class="col-md-6 col-xl-3" >
                            <div class="form-group bmd-form-group">
                                <div class="label-on-left">รายงาน</div>
                                    <asp:DropDownList ID="ddlselectReport" runat="server" CssClass="form-control" AutoPostBack="false" OnSelectedIndexChanged="ddlselectReport_SelectedIndexChanged" />
                            </div>
                       </div>
                    <div class="col-md-6 col-xl-3" >
                            <div class="form-group bmd-form-group">
                                <div class="label-on-left">เดือน</div>
                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control" />
                            </div>
                       </div>
                    <div class="col-md-6 col-xl-3" >
                            <div class="form-group bmd-form-group">
                                <div class="label-on-left">ปี พ.ศ.</div>
                                    <asp:DropDownList ID="ddlbudget" runat="server" CssClass="form-control" />
                            </div>
                       </div>
                </div>
                <br />
                <div class="row">
                    <div class="col text-center" style="font-size:smaller">
                        <asp:Button ID="btnResultReport" runat="server" CssClass="btn btn-success" OnCommand="btnResultReport_Command" Text="ตกลง"/>
                    </div>
                </div>                
            </div>
        </div>
    </div>
</asp:Content>
