<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeReports.aspx.cs" Inherits="EMS_PSS.EmployeeReports" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Employee Reports
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="pageTitle" class="title">
        Empoyee Reports
    </div>
    <div class="clear"></div>
    <div id="activeEmployee" class="reportLinks">
        <a href="ActiveEmployeesReport.aspx">Active Employee Report</a>
    </div>
    <div class="clear"></div>
    <div id="inactiveEmployee" class="reportLinks">
        <a href="InactiveEmployeeReport.aspx">Inactive Employee Report</a>
    </div>
    <div class="clear"></div>
    <div id="seniority" class="reportLinks">
        <a href="SeniorityReport.aspx">Seniority Report</a>
    </div>
    <div class="clear"></div>
    <div id="weeklyHours" class="reportLinks">
        <a href="WeeklyHoursReport.aspx">Weekly Hours Report</a>
    </div>
    <div class="clear"></div>
    <div id="payroll" class="reportLinks">
        <a href="PayrollReport.aspx">Payroll Report</a>
    </div>
        </form>
</asp:Content>