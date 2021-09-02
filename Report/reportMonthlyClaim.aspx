<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportMonthlyClaim.aspx.cs" Inherits="ClaimProject.Report.reportMonthlyClaim" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .col-10 {
            margin-right: 166px;
        }
    </style>
    
</head>
<body>

    
       
        <form id="form1" runat="server">
            <div class="col-10">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <rsweb:ReportViewer ID="reportViewer1" runat="server" Height="700px" Width="862px">
                    
                </rsweb:ReportViewer>
            </div>
        </form>
        
    
    
</body>
</html>
