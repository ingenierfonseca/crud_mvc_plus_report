<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdapterReportPage.aspx.cs" Inherits="crud_mvc_plus_report.SRSS.AdapterReportPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="appReportViewer" runat="server" ZoomMode="PageWidth" Width="700"
            BackColor="White" BorderColor="White" AsyncRendering="false" ShowExportControls="true">

        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
