﻿/*
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
    /*
    * The full time employee class containing all properties associated with a full time employee.
    *
    * This class contains all the properties and functions directly relating to the full time employee.
    *
    */

    public class FullTimeEmployee : Employee
    {
        private string dateOfHire;
        private string dateOfTermination;
        private double salary;

        /*
         *  Constructor with no parameters for setting default blank values.
         */
        public FullTimeEmployee() : base()
        {
            dateOfHire = "";
            dateOfTermination = "";
            salary = 0.0;
            EmployeeType = FULLTIME;
        }
        
        /*
         *   FUNCTION    : FullTimeEmployee()
         *   DESCRIPTION : Constructor with first and last name
         *   PARAMETERS  :
         *       string - newFirstName 
         *       string - newLastName 
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
        
        /*
         *   FUNCTION    : FullTimeEmployee()
         *   DESCRIPTION : Constructor taking all parameters.
         *   PARAMETERS  :
         *        string - newFirstName 
         *        string - newLastName 
         *        string - newSIN
         *        string - newDateOfBirth
         *        string - newDateOfHire 
         *        string - newDateOfTermination
         *        double - newSalary 
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

        /*
         *  Date of hire property containing getter and setter.
         */

        public string DateOfHire
        {
            get { return dateOfHire; }
            set { dateOfHire = value; }
        }


        /*
        *   FUNCTION    : setDateOfHire()
        *   DESCRIPTION : Sets the date of hire based on validity and adds it.
        *   PARAMETERS  :
        *           string - dateToVerify
        *   RETURNS     :
        *           bool
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

        /*
        *   FUNCTION    : setDateOfTermination()
        *   DESCRIPTION : Sets the date of termination based on validity.
        *   PARAMETERS  :
        *           string - dateToVerify
        *   RETURNS     :
        *           bool
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

        /*
         *  FUNCTION    : setSalary()
         *  DESCRIPTION : Sets the salary based on validation.
         *  PARAMETERS  :
         *      double salaryToVerify
         *  RETURNS     :
         *      bool
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
            //UI.MenuFunctions.WriteColorString(fullLine, x, y, backColour, frontColour);
        }
    }
}