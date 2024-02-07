<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PMAllReport.aspx.cs" Inherits="ClaimProject.PM.Report.PMReport" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/crystalreportviewers13/js/crviewer/crv.js"></script>
    <style>
        @font-face {
            font-family: 'THSarabun';
            src: url('/fonts/THSarabun.ttf') format('truetype');
        }

        @font-face {
            font-family: 'THSarabunIT๙';
            src: url('/fonts/THSarabunIT๙.ttf') format('truetype');
        }
    </style>
</head>
<body style="font-family: 'THSarabun,THSarabunIT๙'">
    <form id="form1" runat="server">
        
    </form>
</body>
</html>
