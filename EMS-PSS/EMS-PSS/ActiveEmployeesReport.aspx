<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ActiveEmployeesReport.aspx.cs" Inherits="EMS_PSS.ActiveEmployeesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Active Employees Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div class="clear"></div>
        <div id="pageTitle" class="title">
            Active Employee Report
        </div>
        <div id="Reports" class="tables" runat="server"></div>
    </form>
</asp:Content>