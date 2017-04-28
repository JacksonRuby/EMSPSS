/*
 *  FILE            : Employee.cs
 *  PROJECT         : EMS Term Project
 *  PROGRAMMER      : Jackson Ruby
 *  FIRST VERSION   : 12/11/15
 *  DESCRIPTION     :
 *          The base class for all employees.
 */

using Log;
using System;

namespace Employee
{
    /**
    * @brief The base employee class containing all common properties of the different employees.
    *
    * This class is the base class for all other employees.  It contains properties and functions that
    * are common among all child classes.
    *
    */

    public abstract class Employee
    {
        private string firstName;
        private string lastName;
        private string sin;
        private string dateOfBirth;

        public const int FULLTIME = 0;
        public const int CONTRACT = 1;
        public const int PARTTIME = 2;
        public const int SEASONAL = 3;
        private int employeeType;

        /*
        *   FUNCTION    : Employee
        *   DESCRIPTION : Default constructor.
        */
        protected Employee()
        {
        }

        /**
         *  First name property containing getter and setter.
         */

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        /*
        *   FUNCTION    : setFirstName()
        *   DESCRIPTION : Sets the first name based on validity.
        *   PARAMETERS  :
        *          string nameToVerifty
        *   RETURNS     :
        *            bool Valid or Invalid for true or false.
        */
        public bool setFirstName(string nameToVerify)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.name(nameToVerify);
                FirstName = nameToVerify;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("First Name:" + nameToVerify + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                FirstName = "";
            }

            return valid;
        }

        /*
         *  Last name property containing getter and setter.
         */

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        
        /*
        *   FUNCTION    : setLastName()
        *   DESCRIPTION : Sets the last name based on validity.
        *   PARAMETERS  :
        *          string nameToVerifty
        *   RETURNS     :
        *           bool Valid or Invalid for true or false.
        */
        public bool setLastName(string nameToVerify)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.name(nameToVerify);
                LastName = nameToVerify;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Last Name:" + nameToVerify + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                LastName = "";
            }

            return valid;
        }

        /*
         *  Social insurance number property containing getter and setter.
         */

        public string SIN
        {
            get { return sin; }
            set { sin = value; }
        }

        /*
        *   FUNCTION    : setSIN()
        *   DESCRIPTION : Sets the social insurance number based on validity.
        *   PARAMETERS  :
        *           string - newSIN
        *   RETURNS     :
        *           bool Valid or Invalid for true or false.
        */
        public bool setSIN(string newSIN)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.sin(newSIN);
                string temp = newSIN;
                newSIN = "";
                foreach (char c in temp)
                {
                    if (c != ' ')
                    {
                        newSIN += c;
                    }
                }
                SIN = newSIN.Substring(0, 3) + " " + newSIN.Substring(3, 3) + " " + newSIN.Substring(6, 3);
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("SIN Number:" + newSIN + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                SIN = "0";
            }

            return valid;
        }
        
        /*
        *   FUNCTION    : setContractSIN()
        *   DESCRIPTION : Sets the SIN (Business number in this case) based on validity of the date.
        *   PARAMETERS  :
        *           string - newSIN
        *           string - newDate
        *   RETURNS     : bool Valid or Invalid for true or false.
        */
        public bool setContractSIN(string newSIN, string newDate)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.sin(newSIN, newDate);
                string temp = newSIN;
                newSIN = "";
                foreach (char c in temp)
                {
                    if (c != ' ')
                    {
                        newSIN += c;
                    }
                }
                SIN = newSIN.Substring(0, 5) + " " + newSIN.Substring(5, 4);
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Business Number:" + newSIN + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                SIN = "0";
            }

            return valid;
        }

        /*
         *  Date of birth property containing getter and setter.
         */

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        
        /*
        *   FUNCTION    : setDateOfBirth()
        *   DESCRIPTION : Sets the date of birth based on validity.
        *   PARAMETERS  :
        *           string - newDate
        *   RETURNS     :
        *           bool Valid or Invalid for true or false.
        */
        public bool setDateOfBirth(string newDate)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.date(newDate);
                DateOfBirth = newDate;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Date of Birth:" + newDate + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                DateOfBirth = "";
            }

            return valid;
        }

        /*
         *  Employee type property containing getter and setter.
         */
        public int EmployeeType
        {
            get { return employeeType; }
            set { employeeType = value; }
        }

        //abstract functions
        abstract public bool validate();

        abstract public void details(int x, int y, ConsoleColor backColour, ConsoleColor frontColour);
    }
}