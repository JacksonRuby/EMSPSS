/*
 *  FILE            : FullTimeEmployee.cs
 *  PROJECT         : EMS Term Project
 *  PROGRAMMER      : Jackson Ruby
 *  FIRST VERSION   : 12/11/15
 *  DESCRIPTION     :
 *          Contains all code for a given full time employee.
 */

using Log;
using System;

namespace Employee
{
    /**
    * @brief The full time employee class containing all properties associated with a full time employee.
    *
    * This class contains all the properties and functions directly relating to the full time employee.
    *
    */

    public class FullTimeEmployee : Employee
    {
        private string dateOfHire;
        private string dateOfTermination;
        private double salary;

        /**
         *  Constructor with no parameters for setting default blank values.
         *  @param None.
         *  @return None.
         */

        public FullTimeEmployee() : base()
        {
            dateOfHire = "";
            dateOfTermination = "";
            salary = 0.0;
            EmployeeType = FULLTIME;
        }

        /**
         *  Constructor with first and last name.
         *  @param newFirstName The first name of the employee.
         *  @param newLastname The last name of the employee.
         *  @return None.
         */

        public FullTimeEmployee(string newFirstName, string newLastName) : base()
        {
            setFirstName(newFirstName);
            setLastName(newLastName);
            SIN = "";
            DateOfBirth = "";
            dateOfHire = "";
            dateOfTermination = "";
            salary = 0.0;
            EmployeeType = FULLTIME;
        }

        /**
         *  Constructor taking all parameters.
         *  @param newFirstName The first name of the employee.
         *  @param newLastname The last name of the employee.
         *  @param newSIN The social insurance number of the employee.
         *  @param newDateOfBirth The date of birth of the employee.
         *  @param newDateOfHire The date the employee was hired.
         *  @param newDateOfTermination The date the employee was fired, if exists.
         *  @param newHourlyRate The hourly rate of pay for the employee.
         *  @return None.
         */

        public FullTimeEmployee(string newFirstName, string newLastName, string newSIN, string newDateOfBirth,
            string newDateOfHire, string newDateOfTermination, double newSalary) : base()
        {
            setFirstName(newFirstName);
            setLastName(newLastName);
            setSIN(newSIN);
            setDateOfBirth(newDateOfBirth);
            setDateOfHire(newDateOfHire);
            setDateOfTermination(newDateOfTermination);
            setSalary(newSalary);
            EmployeeType = FULLTIME;
        }

        /**
         *  Date of hire property containing getter and setter.
         */

        public string DateOfHire
        {
            get { return dateOfHire; }
            set { dateOfHire = value; }
        }

        /**
         *  Sets the date of hire based on validity.
         *  @param dateToVerify The date of hire to check and add.
         *  @return bool Valid or Invalid for true or false.
         */

        public bool setDateOfHire(string dateToVerify)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.date(dateToVerify);
                DateOfHire = dateToVerify;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Date Of Hire:" + dateToVerify + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                DateOfHire = "";
            }

            return valid;
        }

        /**
         *  Date of termination property containing getter and setter.
         */

        public string DateOfTermination
        {
            get { return dateOfTermination; }
            set { dateOfTermination = value; }
        }

        /**
         *  Sets the date of termination based on validity.
         *  @param dateToVerify The date of termination to check and add.
         *  @return bool Valid or Invalid for true or false.
         */

        public bool setDateOfTermination(string dateToVerify)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.date(dateToVerify);
                DateOfTermination = dateToVerify;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Date of Termination:" + dateToVerify + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                DateOfTermination = "";
            }

            return valid;
        }

        /**
         *  Salary property containing getter and setter.
         */

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        /**
         *  Sets the salary based on validity.
         *  @param salaryToVerify The salary to check and add.
         *  @return bool Valid or Invalid for true or false.
         */

        public bool setSalary(double salaryToVerify)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.number(salaryToVerify);
                Salary = salaryToVerify;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Salary:" + salaryToVerify.ToString() + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                Salary = 0.0;
            }

            return valid;
        }

        /**
         *  Validates a given full time employee.
         *  @param None.
         *  @return bool Valid or Invalid for true or false.
         */

        public override bool validate()
        {
            bool allValid = false;

            try
            {
                Validation.Validate.name(FirstName);
                Validation.Validate.name(LastName);
                Validation.Validate.sin(SIN);
                Validation.Validate.date(DateOfBirth);
                Validation.Validate.date(DateOfHire);
                if (DateOfTermination != "")
                {
                    Validation.Validate.date(DateOfTermination);
                }
                Validation.Validate.number(Salary);
                if (SIN != "0" && Salary != 0 &&
                    Validation.Validate.chronologicalDates(DateOfHire, DateOfTermination) &&
                    Validation.Validate.chronologicalDates(DateOfBirth, DateOfHire))
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

        /**
          *  Displays the details of a full time employee.
          *  @param x X position to display the employee.
          *  @param y Y position to display the employee.
          *  @param backColour Colour of the background when displaying the employee.
          *  @param frontColour Colour of the text when displaying the employee.
          *  @return None.
          */

        public override void details(int x, int y, ConsoleColor backColour, ConsoleColor frontColour)
        {
            string fullLine = "| FT |";

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

            fullLine += "| " + DateOfBirth + "  | " + SIN + " | " + DateOfHire;

            if (DateOfTermination != "")
            {
                fullLine += " |     " + DateOfTermination + "      ";
            }
            else
            {
                fullLine += " |         N/A         ";
            }
            fullLine += "|     N/A    " + "|     N/A    " + "|  N/A   |";

            string pay = String.Format("{0:0.00}", Salary);

            for (int i = 12; i > pay.Length + 1; i--)
            {
                fullLine += " ";
            }
            fullLine += "$" + pay + " |";

            try
            {
                Logging.LogThis("Full Time Employee: " + fullLine, this.GetType().Name);
            }
            catch (Exception)
            { }
            UI.MenuFunctions.WriteColorString(fullLine, x, y, backColour, frontColour);
        }
    }
}