<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeDetail.aspx.cs" Inherits="EMS_PSS.EmployeeDetail" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Employee Detail
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="clear"></div>
    <div id="header" class="title">
        Edit Employee
    </div>
    <div class="clear"></div>
    <div id="firstName" class="labels">
        First Name:
    </div>
    <div id="firstNameEntry" class="textboxes">
        <asp:TextBox ID="tbFirstName" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="lastName" class="labels">
        Last Name:
    </div>
    <div id="lastNameEntry" class="textboxes">
        <asp:TextBox ID="tbLastName" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="SIN" class="labels">
        Social Insurance Number:
    </div>
    <div id="SINEntry" class="textboxes">
        <asp:TextBox ID="tbSIN" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="dateOfBirth" class="labels">
        Date of Birth (mm-dd-yyyy):
    </div>
    <div id="dateOfBirthEntry" class="textboxes">
        <asp:TextBox ID="tbDateOfBirth" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="dateOfHire" class="labels">
        Date of Hire (mm-dd-yyyy):
    </div>
    <div id="dateOfHireEntry" class="textboxes">
        <asp:TextBox ID="tbDateOfHire" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="dateOfTermination" class="labels">
        Date of Termination (mm-dd-yyyy):
    </div>
    <div id="dateOfTerminationEntry" class="textboxes">
        <asp:TextBox ID="tbDateOfTermination" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div id="terminationReason" class="labels">
        Reason For Termination:
    </div>
    <div id="terminationReasonEntry" class="textboxes">
        <asp:TextBox ID="tbTerminationReason" runat="server" Width="90%"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <asp:PlaceHolder ID="fulltimePlaceHolder" runat="server" Visible="False">
        <div id="salary" class="labels">
            Salary:
        </div>
        <div id="salaryEntry" class="textboxes">
            <asp:TextBox ID="tbSalary" runat="server" Width="90%"></asp:TextBox>
        </div>
        <div class="clear"></div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="parttimePlaceholder" runat="server" Visible="False">
        <div id="hourlyRate" class="labels">
            Hourly Rate:
        </div>
        <div id="hourlyRateEntry" class="textboxes">
            <asp:TextBox ID="tbHourlyRate" runat="server" Width="90%"></asp:TextBox>
        </div>
        <div class="clear"></div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="contractPlaceholder" runat="server" Visible="False">
        <div id="contractStart" class="labels">
            Contract Start Date (mm-dd-yyyy):
        </div>
        <div id="contractStartEntry" class="textboxes">
            <asp:TextBox ID="tbContractStart" runat="server" Width="90%"></asp:TextBox>
        </div>
        <div class="clear"></div>
        <div id="contractEnd" class="labels">
            Contract End Date (mm-dd-yyyy):
        </div>
        <div id="contractEndEntry" class="textboxes">
            <asp:TextBox ID="tbContractEnd" runat="server" Width="90%"></asp:TextBox>
        </div>
        <div class="clear"></div>
        <div id="contractRate" class="labels">
            Fixed Contract Rate:
        </div>
        <div id="contractRateEntry" class="textboxes">
            <asp:TextBox ID="tbContractRate" runat="server" Width="90%"></asp:TextBox>
        </div>
        <div class="clear"></div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="seasonalPlaceholder" runat="server" Visible="False">
        <div id="piecePay" class="labels">
            Piece Pay:
        </div>
        <div id="piecePayEntry" class="textboxes">
            <asp:TextBox ID="tbPiecePay" runat="server" Width="90%"></asp:TextBox>
        </div>
        <div class="clear"></div>
    </asp:PlaceHolder>
    <div id="activeDropdown" class="dropdownDiv">
        <asp:DropDownList ID="active" runat="server" class="dropdown">
            <asp:ListItem Text="Active" Value="0" />
            <asp:ListItem Text="Left Company" Value="1" />
            <asp:ListItem Text="Retired" Value="2" />
            <asp:ListItem Text="Terminated" Value="3" />
            <asp:ListItem Text="Laid-Off" Value="4" />
            <asp:ListItem Text="Contract Lapsed" Value="5" />
        </asp:DropDownList>
    </div>
    <div class="clear"></div>
    <div id="buttons" class="buttonsDiv">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="buttons" />
        <asp:Button ID="btnSaveAddNew" runat="server" Text="Save" CssClass="buttons" />
    </div>
    <div class="clear"></div>
        </form>
</asp:Content>