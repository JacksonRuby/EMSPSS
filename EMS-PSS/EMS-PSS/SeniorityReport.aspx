<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SeniorityReport.aspx.cs" Inherits="EMS_PSS.SeniorityReport" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Seniority Report
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="pageTitle" class="title">
        Seniority Report
    </div>
    <div id="Reports" class="tables" runat="server"></div>
        </form>
</asp:Content>