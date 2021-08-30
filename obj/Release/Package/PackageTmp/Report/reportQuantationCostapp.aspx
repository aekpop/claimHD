<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportQuantationCostapp.aspx.cs" Inherits="ClaimProject.Report.reportQuantationCostapp" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
             <rsweb:ReportViewer ID="reportViewer1" runat="server" Height="700px" Width="100%">
                <LocalReport ReportPath="Report\reportCostAppraisal.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
