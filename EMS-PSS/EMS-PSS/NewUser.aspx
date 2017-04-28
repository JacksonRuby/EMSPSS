<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="EMS_PSS.NewUser" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="header" class="title">
        Add New User
    </div>
    <div id="content" class="tables" runat="server"></div>
    <div class="clear"></div>
    <div id="FirstName" class="labels">
        First Name:
    </div>
    <div id="FirstNameEntry" class="textboxes">
        <asp:TextBox ID="txtFirstName" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="LastName" class="labels">
        Last Name:
    </div>
    <div id="LastNameEntry" class="textboxes">
        <asp:TextBox ID="txtLastName" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="username" class="labels">
        Username:
    </div>
    <div id="usernameEntry" class="textboxes">
        <asp:TextBox ID="txtUsername" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="password" class="labels">
        Password:
    </div>
    <div id="passwordEntry" class="textboxes">
        <asp:TextBox ID="txtPassword" runat="server" Width="90%" TextMode="Password"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="AdminToggle" class="textboxes">
        <asp:CheckBox ID="chkAdmin" runat="server" Text="Admin User" />
    </div>
    <div class="clear"></div>
    <div id="buttons" class="buttons">
        <asp:Button ID="btnSaveAddNew" runat="server" Height="26px" OnClick="btnSaveAddNew_Click" Text="Save" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </div>
    </form>
</asp:Content>