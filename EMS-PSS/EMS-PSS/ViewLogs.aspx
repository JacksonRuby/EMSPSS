<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewLogs.aspx.cs" Inherits="EMS_PSS.ViewLogs" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="header" class="title">
        Log Viewer
    </div>
    <div class="clear"></div>
    <div id="auditTableDiv" class="">
        <asp:PlaceHolder ID="auditTable" runat="server"></asp:PlaceHolder>
    </div>
    <div class="clear"></div>
    <div id="nextPage" class="nextPage"><a href="ViewLogs.aspx">Next ></a></div>
        </form>
</asp:Content>