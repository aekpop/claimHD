<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportView.aspx.cs" Inherits="ClaimProject.Report.reportView" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/crystalreportviewers13/js/crviewer/crv.js"></script>
</head>
<body style="height: 862px">
    <form id="iframe" runat="server" >
        <asp:Panel id="dvReport" runat="server" >
            <CR:CrystalReportViewer ID="resultReportLeave" runat="server" 
                EnableParameterPrompt="False" 
                ToolPanelView="None" GroupTreeStyle-ShowLines="False" HasCrystalLogo="False" HasToggleGroupTreeButton="False" PrintMode="Pdf" AutoDataBind="true" EnableDatabaseLogonPrompt="False" />
        </asp:Panel>

    <script type="text/javascript">
        function Print() {
            var dvReport = document.getElementById("");
            var frame1 = dvReport.getElementsByTagName("iframe")[0];
            if (navigator.appName.indexOf("Internet Explorer") != -1 || navigator.appVersion.indexOf("Trident") != -1) {
                frame1.name = frame1.id;
                window.frames[frame1.id].focus();
                window.frames[frame1.id].print();
            }
            else {
                var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
                frameDoc.print();
            }
        }
    </script>                                        
    </form>
    </body>
</html>
