<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WeeklyHoursReport.aspx.cs" Inherits="EMS_PSS.WeeklyHoursReport" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Weekly Hours Report
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="pageTitle" class="title">
        Weekly Hours Report
    </div>
    <asp:PlaceHolder ID="weeklyHoursPlaceHolder" runat="server"></asp:PlaceHolder>
        </form>
</asp:Content>