<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InactiveEmployeeReport.aspx.cs" Inherits="EMS_PSS.InactiveEmployeeReport" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Inactive Employee Report
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div class="clear"></div>
        <div id="pageTitle" class="title">
            Inactive Employee Report
        </div>
        <div id="Reports" class="tables" runat="server"></div>
    </form>
</asp:Content>