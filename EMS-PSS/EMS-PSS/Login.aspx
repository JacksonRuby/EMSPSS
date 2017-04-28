<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMS_PSS.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="title" class="title">
        <strong>Welcome to the EMS-PSS sytem.</strong><br />
    </div>
    <div id="login" class="login">
        &nbsp;<asp:Login ID="Login" align="center" runat="server" OnAuthenticate="Login_Authenticate" Style="text-align: center" DisplayRememberMe="False">
        </asp:Login>
    </div>
        </form>
</asp:Content>