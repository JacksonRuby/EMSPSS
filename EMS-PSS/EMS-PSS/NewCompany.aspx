<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewCompany.aspx.cs" Inherits="EMS_PSS.NewCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    New Company
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="header" class="title">
        Add New Company
    </div>
    <div id="content" class="tables" runat="server"></div>
    <div class="clear"></div>
    <div id="Company" class="labels">
        Company Name:
    </div>
    <div id="CompanyEntry" class="textboxes">
        <asp:TextBox ID="txtCompany" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="buttons" class="buttons">
        <asp:Button ID="btnSaveAddNew" runat="server" Height="26px" OnClick="btnSaveAddNew_Click" Text="Save" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </div>
    </form>
</asp:Content>
