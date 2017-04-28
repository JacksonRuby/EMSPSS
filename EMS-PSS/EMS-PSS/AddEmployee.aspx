<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="EMS_PSS.AddEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Employee
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="clear"></div>
    <div id="header" class="title">
        Add New Employee
    </div>
    <div class="clear"></div>
    <div id="Company" class="labels">
        Company
    </div>
    <div id="CompanyEntry" class="textboxes">
        <asp:TextBox ID="txtCompany" runat="server" Width="60%" CausesValidation="True"></asp:TextBox>
        <asp:RequiredFieldValidator id="CompanyValidate" runat="server" ErrorMessage="Required" ControlToValidate="txtCompany" />
    </div>
    <div class="clear"></div>
    <div id="EmployeeType" class="labels">
        EmployeeType
    </div>
    <div id="TypeEntry" class="textboxes">
        <asp:DropDownList ID="listType" runat="server" Height="16px" Width="60%" OnSelectedIndexChanged="listType_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <div class="clear"></div>
    <div id="FirstName" class="labels">
        First Name:
    </div>
    <div id="FirstNameEntry" class="textboxes">
        <asp:TextBox ID="txtFirstName" runat="server" Width="60%" CausesValidation="True"></asp:TextBox>
        <asp:RequiredFieldValidator id="FirstNameValidate" runat="server" ErrorMessage="Required" ControlToValidate="txtFirstName" />
    </div>
    <div class="clear"></div>
    <div id="LastName" class="labels">
        Last Name:
    </div>
    <div id="LastNameEntry" class="textboxes">
        <asp:TextBox ID="txtLastName" runat="server" Width="60%" CausesValidation="True"></asp:TextBox>
        <asp:RequiredFieldValidator id="LastNameValidate" runat="server" ErrorMessage="Required" ControlToValidate="txtLastName" />
    </div>
    <div class="clear"></div>
    <div id="SIN" class="labels">
        Social Insurance Number:
    </div>
    <div id="SINEntry" class="textboxes">
        <asp:TextBox ID="txtSIN" runat="server" Width="60%" CausesValidation="True"></asp:TextBox>
        <asp:CustomValidator ID="SinValidation" runat="server" ErrorMessage="SIN Invalid" ControlToValidate="txtSIN" OnServerValidate="SinValidation_ServerValidate" Display="Dynamic" ValidateEmptyText="True" ValidateRequestMode="Enabled"></asp:CustomValidator>
    </div>
    <div class="clear"></div>
    <div id="DOB" class="labels">
        Date of Birth (YYYY-MM-DD):
    </div>
    <div id="DOBEntry" class="textboxes">
        <asp:TextBox ID="txtDateOfBirth" runat="server" Width="60%" CausesValidation="True" ></asp:TextBox>
        <asp:CustomValidator ID="DOBCValidate" runat="server" ErrorMessage="Date of Birth Invalid" ControlToValidate="txtDateOfBirth" OnServerValidate="DateValidation" Display="Dynamic" ValidateEmptyText="True" ValidateRequestMode="Enabled"></asp:CustomValidator>
    </div>
    <div class="clear"></div>
    <div id="DOH" class="labels">
        Date of Hire (YYYY-MM-DD):
    </div>
    <div id="DOHEntry" class="textboxes">
        <asp:TextBox ID="txtDateOfHire" runat="server" Width="60%" CausesValidation="True" ></asp:TextBox>
        <asp:CustomValidator ID="DOHCValidate" runat="server" ErrorMessage="Date of Hire Invalid" ControlToValidate="txtDateOfHire" OnServerValidate="DateValidation" Display="Dynamic" ValidateEmptyText="True" ValidateRequestMode="Enabled"></asp:CustomValidator>
    </div>
    <div class="clear"></div>
    <div id="contractstartdate" class="labels" runat="server">
        Contract Start Date (YYYY-MM-DD):
    </div>
    <div id="contractstartdateEntry" class="textboxes" runat="server">
        <asp:TextBox ID="txtContractStartDate" runat="server" Width="60%" CausesValidation="True" ></asp:TextBox>
        <asp:CustomValidator ID="constractstartdateValidate" runat="server" ErrorMessage="Contract Start Date Invalid" ControlToValidate="txtContractStartDate" OnServerValidate="DateValidation" Display="Dynamic" ValidateEmptyText="True" ValidateRequestMode="Enabled"></asp:CustomValidator>
    </div>
        <div class="clear"></div>
    <div id="contractenddate" class="labels" runat="server">
        Contract End Date (YYYY-MM-DD):
    </div>
    <div id="contractenddateEntry" class="textboxes" runat="server">
        <asp:TextBox ID="txtContractEndDate" runat="server" Width="60%" CausesValidation="True" ></asp:TextBox>
        <asp:CustomValidator ID="contractenddateValidate" runat="server" ErrorMessage="Contract End Date Invalid" ControlToValidate="txtContractEndDate" OnServerValidate="DateValidation" Display="Dynamic" ValidateEmptyText="True" ValidateRequestMode="Enabled"></asp:CustomValidator>
    </div>
        <div class="clear"></div>
    <div id="Pay" class="labels" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <asp:Label ID="lblPay" runat="server" Text="Salary:">Salary:</asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="listType" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="payEntry" class="textboxes" runat="server">
        <asp:TextBox ID="txtPay" runat="server" Width="60%" CausesValidation="True" ></asp:TextBox>
        <asp:CustomValidator ID="payValidate" runat="server" ErrorMessage="Pay Invalid" ControlToValidate="txtPay" OnServerValidate="DateValidation" Display="Dynamic" ValidateEmptyText="True" ValidateRequestMode="Enabled"></asp:CustomValidator>
    </div>
    <div class="clear"></div>
    <div id="buttons" class="buttonsDiv">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="buttons" />
        <asp:Button ID="btnSaveAddNew" runat="server" Text="Save" CssClass="buttons" OnClick="btnSaveAddNew_Click" />
    </div>
    <div class="clear"></div>
        </form >
</asp:Content>
