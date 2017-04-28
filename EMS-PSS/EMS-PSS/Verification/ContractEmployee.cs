/*
 *  FILE            : ContractEmployee.cs
 *  PROJECT         : EMS Term Project
 *  PROGRAMMER      : Jackson Ruby
 *  FIRST VERSION   : 12/11/15
 *  DESCRIPTION     :
 *          Contains all code for any given contract employee.
 */

using Log;
using System;

namespace Employee
{
    /*
    * The contract employee class containing all properties associated with a contract employee.
    *
    * This class contains all the properties and functions directly relating to the contract employee.
    *
    */

    public class ContractEmployee : Employee
    {
        private string contractStartDate;
        private string contractStopDate;
        private double fixedContractAmount;

        /*
         *  Constructor with no parameters for setting default blank values.
         */

        public ContractEmployee() : base()
        {
            contractStartDate = "";
            contractStopDate = "";
            fixedContractAmount = 0.0;
            EmployeeType = CONTRACT;
        }

        /*
         *   FUNCTION    : ContractEmployee
         *   DESCRIPTION : Constructor with first and last name
         *   PARAMETERS  :
         *       string - newFirstName 
         *       string - newLastName 
         */
        public ContractEmployee(string newFirstName, string newLastName) : base()
        {
            setFirstName(newFirstName);
            setLastName(newLastName);
            SIN = "";
            DateOfBirth = "";
            contractStartDate = "";
            contractStopDate = "";
            fixedContractAmount = 0.0;
            EmployeeType = CONTRACT;
        }

        /*
        *   FUNCTION    : ContractEmployee
        *   DESCRIPTION : Constructor taking all parameters.
        *   PARAMETERS  :
        *        string - newFirstName 
        *        string - newLastName 
        *        string - newSIN
        *        string - newDateOfBirth
        *        string - newContractStartDate 
        *        string - newContractStopDate 
        *        double - newFixedContractAmount
        */
        public ContractEmployee(string newFirstName, string newLastName, string newSIN, string newDateOfBirth,
            string newContractStartDate, string newContractStopDate, double newFixedContractAmount) : base()
        {
            setFirstName(newFirstName);
            setLastName(newLastName);
            setContractSIN(newSIN, newDateOfBirth);
            setDateOfBirth(newDateOfBirth);
            setContractStartDate(newContractStartDate);
            setContractStopDate(newContractStopDate);
            setFixedContractAmount(newFixedContractAmount);
            EmployeeType = CONTRACT;
        }

        /*
         *  Contract start date property containing getter and setter.
         */

        public string ContractStartDate
        {
            get { return contractStartDate; }
            set { contractStartDate = value; }
        }


        /*
        *   FUNCTION    : setContractStartDate
        *   DESCRIPTION : Sets the contract start date based on validity.
        *   PARAMETERS  :
        *            string - dateToVerify
        *   RETURNS     :
        *            bool Valid or Invalid for true or false.
        */
        public bool setContractStartDate(string dateToVerify)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.date(dateToVerify);
                ContractStartDate = dateToVerify;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Contract Start Date:" + dateToVerify + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                ContractStartDate = "";
            }

            return valid;
        }

        /*
         *  Contract stop date property containing getter and setter.
         */

        public string ContractStopDate
        {
            get { return contractStopDate; }
            set { contractStopDate = value; }
        }

        /*
        *   FUNCTION    : setContractStopDate
        *   DESCRIPTION : Sets the contract stop date based on validity.
        *   PARAMETERS  :
        *            string - dateToVerify
        *   RETURNS     :
        *            bool Valid or Invalid for true or false.
        */
        public bool setContractStopDate(string dateToVerify)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.date(dateToVerify);
                ContractStopDate = dateToVerify;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Contract End Date:" + dateToVerify + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                ContractStopDate = "";
            }

            return valid;
        }

        /*
         *  Fixed contract amount property containing getter and setter.
         */

        public double FixedContractAmount
        {
            get { return fixedContractAmount; }
            set { fixedContractAmount = value; }
        }
        
        /*
        *   FUNCTION    : ()
        *   DESCRIPTION : Sets the fixed contract amount based on validity.
        *   PARAMETERS  :
                    double - amountToVerify
        *   RETURNS     :
                     bool - Valid or Invalid for true or false.
        */
        public bool setFixedContractAmount(double amountToVerify)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.number(amountToVerify);
                FixedContractAmount = amountToVerify;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Fixed Contract Amount:" + amountToVerify.ToString() + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                FixedContractAmount = 0.0;
            }

            return valid;
        }

        /*
        *   FUNCTION    : validate()
        *   DESCRIPTION : Validates a given contract employee.
        *    RETURN: bool Valid or Invalid for true or false.
        */
        public override bool validate()
        {
            bool allValid = false;

            try
            {
                Validation.Validate.name(FirstName);
                Validation.Validate.name(LastName);
                Validation.Validate.sin(SIN, DateOfBirth);
                Validation.Validate.date(DateOfBirth);
                Validation.Validate.date(ContractStartDate);
                Validation.Validate.date(ContractStopDate);
                Validation.Validate.number(FixedContractAmount);
                if (SIN != "0" && FixedContractAmount != 0 &&
                    Validation.Validate.chronologicalDates(ContractStartDate, ContractStopDate))
                {
                    allValid = true;
                }
            }
            catch (Exception)
            { }

            if (allValid)
            {
                try
                {
                    Logging.LogThis("Employee - " + LastName + "," + FirstName + " (" + SIN + ") - VALID", this.GetType().Name);
                }
                catch (Exception)
                { }
            }
            else
            {
                try
                {
                    Logging.LogThis("Employee - " + LastName + "," + FirstName + " (" + SIN + ") - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
            }

            return allValid;
        }

        /*
         *   FUNCTION    : details()
         *   DESCRIPTION : Displays the details of a contract employee.
         *   PARAMETERS  :
         *        int - x  
         *        int - y  
         *        ConsoleColor - backColour 
         *        ConsoleColor - frontColour
         */
        public override void details(int x, int y, ConsoleColor backColour, ConsoleColor frontColour)
        {
            string fullLine = "| CT |";

            if (LastName.Length > 12)
            {
                fullLine += LastName.Substring(0, 9) + "...";
            }
            else
            {
                fullLine += LastName;
                for (int i = LastName.Length; i < 12; i++)
                {
                    fullLine += " ";
                }
            }
            fullLine += "|";
            if (FirstName.Length > 12)
            {
                fullLine += FirstName.Substring(0, 9) + "...";
            }
            else
            {
                fullLine += FirstName;
                for (int i = FirstName.Length; i < 12; i++)
                {
                    fullLine += " ";
                }
            }

            fullLine += "| " + DateOfBirth + "  | " + SIN + "  |     N/A    " + "|         N/A        " + " | " + ContractStartDate + " | " + ContractStopDate + " |  N/A   |";

            string pay = String.Format("{0:0.00}", FixedContractAmount);

            for (int i = 12; i > pay.Length + 1; i--)
            {
                fullLine += " ";
            }
            fullLine += "$" + pay + " |";

            try
            {
                Logging.LogThis("Contract Employee: " + fullLine, this.GetType().Name);
            }
            catch (Exception)
            { }
            //UI.MenuFunctions.WriteColorString(fullLine, x, y, backColour, frontColour);
        }
    }
}