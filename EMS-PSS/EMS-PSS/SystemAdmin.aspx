<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SystemAdmin.aspx.cs" Inherits="EMS_PSS.SystemAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="header" class="title">
        System Administration Page
    </div>
    <div class="clear"></div>
    <div id="AddUser" class="reportLinks">
        <a href="NewUser.aspx">Add New User</a>
    </div>
    <div class="clear"></div>
    <div id="AddCompany" class="reportLinks">
        <a href="NewCompany.aspx">Add New Company</a>
    </div>
    <div class="clear"></div>
    <div id="ViewLogs" class="reportLinks">
        <a href="ViewLogs.aspx">View Logs</a>
    </div>
    <div class="clear"></div>
        </form>
</asp:Content>