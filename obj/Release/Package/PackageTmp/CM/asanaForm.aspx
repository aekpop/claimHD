<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="asanaForm.aspx.cs" Inherits="ClaimProject.CM.asanaForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="asana-embed-container"><link rel="stylesheet" href="https://form.asana.com/static/asana-form-embed-style.css"/>
            <iframe class="asana-embed-iframe" src="https://form.asana.com/?k=fP3DY7epBdAnAPGk52Q0Uw&d=1203613610868930&embed=true"></iframe>
            <style>
        .asana-embed-iframe {
            width:auto;
            height: 850px;
        }
    </style>
            <div class="asana-embed-footer">
                <a rel="nofollow noopener" target="_blank" class="asana-embed-footer-link" href="https://asana.com/?utm_source=embedded_form">
                    <span class="asana-embed-footer-text">Form powered by</span>
                    <div class="asana-embed-footer-logo" role="img" aria-label="Logo of Asana">
                    </div>
                </a>
            </div>
        </div>
    </div>    
</asp:Content>
