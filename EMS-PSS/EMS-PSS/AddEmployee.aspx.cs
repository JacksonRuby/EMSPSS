/*
*  FILE             : AddEmployee.aspx.cs
*  PROJECT          : Software Quality 2 Final Project
*  PROGRAMMER       : Brad Carradine, Jackson Ruby, James Simpson
*  DATE		        : April 21, 2016
*  DESCRIPTION      :
*          This file contains all of the methods in the code-behind part of the AddEmployee.aspx page.  This file will allow the user to add a new
*               employee to the database.
*/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS_PSS
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        /*
        * Function: Page_Load
        * Description:
        *	    This event method will be called when the page is loaded. It will determine how to render out the page and will render out the relevant
        *	        fields based off of the users level and otherwise.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void Page_Load(object sender, EventArgs e)
        {
            listType.Items.Add("Full Time");
            listType.Items.Add("Part Time");
            listType.Items.Add("Seasonal");
            if ((bool)Session["isadmin"] == true)
            {
                listType.Items.Add("Contract");
            }
            else
            {
                Pay.Visible = false;
                payEntry.Visible = false;
                txtPay.Enabled = false;
                txtPay.Visible = false;

                contractstartdate.Visible = false;
                contractstartdateEntry.Visible = false;
                txtContractStartDate.Enabled = false;
                txtContractStartDate.Visible = false;

                contractenddate.Visible = false;
                contractenddateEntry.Visible = false;
                txtContractEndDate.Enabled = false;
                txtContractEndDate.Visible = false;
            }
        }

        /*
        * Function: btnSaveAddNew_Click
        * Description:
        *	    This event method will be called when the btnSaveAddNew is clicked. It then will add the new user based off of the selected employee type.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void btnSaveAddNew_Click(object sender, EventArgs e)
        {
            Page.Validate();
            int companyID = SQL_Connection.GetCompanyID(txtCompany.Text);
            int SIN = -1;
            int.TryParse(txtSIN.Text, out SIN);
            float pay = 0;
            float.TryParse(txtPay.Text, out pay);
            DateTime DOB = DateTime.Now;
            DateTime DOH = DateTime.Now;
            DateTime CSD = DateTime.Now;
            DateTime CED = DateTime.Now;
            DateTime.TryParse(txtDateOfBirth.Text, out DOB);
            DateTime.TryParse(txtDateOfHire.Text, out DOH);
            DateTime.TryParse(txtContractStartDate.Text, out CSD);
            DateTime.TryParse(txtContractEndDate.Text, out CED);

            if (listType.SelectedItem.Text == "Full Time")
            {
                SQL_Connection.InsertFullTimeEmployee(companyID, txtLastName.Text, txtFirstName.Text, SIN, DOB, "", DOH, new DateTime(), false, pay, 1);
            }
            else if (listType.SelectedItem.Text == "Part Time")
            {
                SQL_Connection.InsertPartTimeEmployee(companyID, txtLastName.Text, txtFirstName.Text, SIN, DOB, "", DOH, new DateTime(), false, pay, 1);
            }
            else if (listType.SelectedItem.Text == "Seasonal")
            {
                SQL_Connection.InsertSeasonalEmployee(companyID, txtLastName.Text, txtFirstName.Text, SIN, DOB, "", DOH, new DateTime(), false, pay, 1);
            }
            else if (listType.SelectedItem.Text == "Contract")
            {
                SQL_Connection.InsertContractEmployee(companyID, txtLastName.Text, txtFirstName.Text, SIN, DOB, "", DOH, new DateTime(), false, CSD, CED, pay, 1);
            }
            Response.Redirect("EmployeeMaintenance.aspx", false);
        }

        /*
        * Function: SinValidation_ServerValidate
        * Description:
        *	    This event method will be called the user goes to submit the page to ensure that the sin values are correct.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void SinValidation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool valid = true;
            try
            {
                Validation.Validate.sin(args.Value);
            }
            catch (Exception e)
            {
                SinValidation.ErrorMessage = e.Message;
                valid = false;
            }
            args.IsValid = valid;
        }

        /*
        * Function: DateValidation
        * Description:
        *	    This event method will be called the user goes to submit the page to ensure that the date values are correct.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void DateValidation(object source, ServerValidateEventArgs args)
        {
            bool valid = true;
            try
            {
                Validation.Validate.date(args.Value);
            }
            catch (Exception e)
            {
                SinValidation.ErrorMessage = e.Message;
                valid = false;
            }
            args.IsValid = valid;
        }

        /*
        * Function: DateValidation
        * Description:
        *	    This event method will be called the user goes to submit the page to ensure that the number values are correct.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void NumValidation(object source, ServerValidateEventArgs args)
        {
            bool valid = true;
            double temp = 0;
            double.TryParse(args.Value, out temp);
            try
            {
                Validation.Validate.number(temp);
            }
            catch (Exception e)
            {
                SinValidation.ErrorMessage = e.Message;
                valid = false;
            }
            args.IsValid = valid;
        }

        /*
        * Function: DateValidation
        * Description:
        *	    This event method will be called the user switches the employee type.  It will change the values that correspond
        *	        to the employee type.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void listType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listType.SelectedIndex == 0)
            {
                lblPay.Text = "Salary:";
            }
            else if (listType.SelectedIndex == 1)
            {
                lblPay.Text = "Hourly Rate:";
            }
            else if (listType.SelectedIndex == 2)
            {
                lblPay.Text = "Piece Pay:";
            }
            else if (listType.SelectedIndex == 3)
            {
                lblPay.Text = "Fixed Contract Amount:";
                contractstartdate.Visible = true;
                contractstartdateEntry.Visible = true;
                txtContractStartDate.Enabled = true;
                txtContractStartDate.Visible = true;

                contractenddate.Visible = true;
                contractenddateEntry.Visible = true;
                txtContractEndDate.Enabled = true;
                txtContractEndDate.Visible = true;
            }
        }
    }
}