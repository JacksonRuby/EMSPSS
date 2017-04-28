<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DisplayAllEmployees.aspx.cs" Inherits="EMS_PSS.DisplayAllEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Display Employees
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
        <form id="form1" runat="server">

        <asp:Table ID="ResultsTable" runat="server">
        </asp:Table>
            <asp:Button ID="btnPrev" runat="server" OnClick="btnPrev_Click" Text="&lt;&lt;" />
            <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="&gt;&gt;" />
        </form>
</asp:Content>
