using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EMS_PSS
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        private int ID;
        private DataRow EmployeeInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            string temp = Request.QueryString["ID"];
            int.TryParse(temp, out ID);
            DateTime TempDOB = new DateTime();
            DateTime TempDOH = new DateTime();
            DateTime TempCSD = new DateTime();
            DateTime TempCED = new DateTime();
            float pay = 0;
            int companyID = 0;

            EmployeeInfo = SQL_Connection.GetRow(SQL_Connection.EMPLOYEE_TABLE, new string[1]{ "EmployeeID=" + ID });
            if (int.TryParse(EmployeeInfo[0].ToString(), out companyID))
            {
                txtCompany.Text = SQL_Connection.GetCompanyName(companyID);
            }
            else
            {
                txtCompany.Text =EmployeeInfo[0].ToString();
            }
            
            txtLastName.Text = EmployeeInfo[2].ToString();
            txtFirstName.Text = EmployeeInfo[3].ToString();
            txtSIN.Text = EmployeeInfo[4].ToString();
            if (DateTime.TryParse(EmployeeInfo[5].ToString(), out TempDOB))
            {
                txtDateOfBirth.Text = TempDOB.ToShortDateString();
            }
            else
            {
                txtDateOfBirth.Text = EmployeeInfo[5].ToString();
            }

            if (DateTime.TryParse(EmployeeInfo[7].ToString(), out TempDOH))
            {
                txtDateOfHire.Text = TempDOH.ToShortDateString();
            }
            else
            {
                txtDateOfHire.Text = EmployeeInfo[7].ToString();
            }

            if (DateTime.TryParse(EmployeeInfo[12].ToString(), out TempCSD))
            {
                txtContractStartDate.Text = TempCSD.ToShortDateString();
            }
            else
            {
                txtContractStartDate.Text = EmployeeInfo[12].ToString();
            }

            if (DateTime.TryParse(EmployeeInfo[13].ToString(), out TempCED))
            {
                txtContractEndDate.Text = TempDOB.ToShortDateString();
            }
            else
            {
                txtContractEndDate.Text = EmployeeInfo[13].ToString();
            }
            
            
            if (EmployeeInfo[1].ToString().ToLower() == "full time")
            {
                if (float.TryParse(EmployeeInfo[10].ToString(), out pay))
                {
                    txtPay.Text = pay.ToString("0.00");
                }
                else
                {
                    txtPay.Text = EmployeeInfo[10].ToString();
                }                
            }
            else if (EmployeeInfo[1].ToString().ToLower() == "part time")
            {
                if (float.TryParse(EmployeeInfo[11].ToString(), out pay))
                {
                    txtPay.Text = pay.ToString("0.00");
                }
                else
                {
                    txtPay.Text = EmployeeInfo[11].ToString();
                }                
            }
            else if (EmployeeInfo[1].ToString().ToLower() == "seasonal")
            {
                if (float.TryParse(EmployeeInfo[15].ToString(), out pay))
                {
                    txtPay.Text = pay.ToString("0.00");
                }
                else
                {
                    txtPay.Text = EmployeeInfo[15].ToString();
                }
            }
            else if (EmployeeInfo[1].ToString().ToLower() == "contract")
            {
                if (float.TryParse(EmployeeInfo[14].ToString(), out pay))
                {
                    txtPay.Text = pay.ToString("0.00");
                }
                else
                {
                    txtPay.Text = EmployeeInfo[14].ToString();
                }
            }
           
        }


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
        
        protected void btnSaveAddNew_Click(object sender, EventArgs e)
        {
            SQL_Connection.UpdateEmployee(ID, SQL_Connection.EMPLOYED_WITH_COMPANY_ID, SQL_Connection.GetCompanyID(txtCompany.Text).ToString());
            SQL_Connection.UpdateEmployee(ID, SQL_Connection.LAST_NAME, txtLastName.Text);
            SQL_Connection.UpdateEmployee(ID, SQL_Connection.FIRST_NAME, txtFirstName.Text);
            SQL_Connection.UpdateEmployee(ID, SQL_Connection.SIN, txtSIN.Text);
            SQL_Connection.UpdateEmployee(ID, SQL_Connection.DATE_OF_BIRTH, txtDateOfBirth.Text);
            SQL_Connection.UpdateEmployee(ID, SQL_Connection.DATE_OF_HIRE, txtDateOfHire.Text);
            if (EmployeeInfo[1].ToString().ToLower() == "full time")
            {
                SQL_Connection.UpdateEmployee(ID, SQL_Connection.SALARY, txtPay.Text);
            }
            else if (EmployeeInfo[1].ToString().ToLower() == "part time")
            {
                SQL_Connection.UpdateEmployee(ID, SQL_Connection.HOURLY_RATE, txtPay.Text);
            }
            else if (EmployeeInfo[1].ToString().ToLower() == "seasonal")
            {
                SQL_Connection.UpdateEmployee(ID, SQL_Connection.PIECE_PAY, txtPay.Text);
            }
            else if (EmployeeInfo[1].ToString().ToLower() == "contract")
            {
                SQL_Connection.UpdateEmployee(ID, SQL_Connection.FIXED_CONTRACT_RATE, txtPay.Text);
                SQL_Connection.UpdateEmployee(ID, SQL_Connection.CONTRACT_START_DATE, txtContractStartDate.Text);
                SQL_Connection.UpdateEmployee(ID, SQL_Connection.CONTRACT_END_DATE, txtContractEndDate.Text);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}