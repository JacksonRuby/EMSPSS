<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeSearch.aspx.cs" Inherits="EMS_PSS.EmployeeSearch" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Search
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="searchBox" class="textbox">
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" Width="92%"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
        <br />
        <asp:Table ID="ResultsTable" runat="server">
        </asp:Table>
    </div>
    </form>
</asp:Content>