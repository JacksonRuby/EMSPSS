<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EMS_PSS.index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    The Main Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div class="genericText">
            <p>
                This web application is meant to keep track of many different employees.  It can be used to add new, view old, adjust timesheets, and do many different things
                that involve employees.  If you an administrative user, you can view reports and can add new users as well.
            </p>
        </div>
    </form>
</asp:Content>