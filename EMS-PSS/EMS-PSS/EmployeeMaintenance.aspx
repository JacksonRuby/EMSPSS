<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeMaintenance.aspx.cs" Inherits="EMS_PSS.EmployeeMaintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Employee Maintenance
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="pageTitle" class="title">
        Employee Maintenance
    </div>
    <div class="clear"></div>
    <div id="Search" class="reportLinks">
        <a href="EmployeeSearch.aspx">Search</a>
    </div>
    <div class="clear"></div>
    <div id="Add" class="reportLinks">
        <a href="AddEmployee.aspx">Add Employee</a>
    </div>
    <div class="clear"></div>
        <div id="View" class="reportLinks">
        <a href="DisplayAllEmployees.aspx">Display All Employees</a>
    </div>
    <div class="clear"></div>
        </form>
</asp:Content>
