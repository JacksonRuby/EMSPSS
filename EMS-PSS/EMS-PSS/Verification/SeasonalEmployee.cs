/*
 *  FILE            : SeasonalEmployee.cs
 *  PROJECT         : EMS Term Project
 *  PROGRAMMER      : Jackson Ruby
 *  FIRST VERSION   : 12/11/15
 *  DESCRIPTION     :
 *          Contains all code for a given seasonal employee.
 */

using Log;
using System;

namespace Employee
{
    /**
    * @brief The seasonal employee class containing all properties associated with a seasonal employee.
    *
    * This class contains all the properties and functions directly relating to the seasonal employee.
    *
    */

    public class SeasonalEmployee : Employee
    {
        private string season;
        private double piecePay;

        /**
         *  Constructor with no parameters for setting default blank values.
         *  @param None.
         *  @return None.
         */
        /*
         *   FUNCTION    : SeasonalEmployee()
         *   DESCRIPTION : Constructor with no parameters
         */
        public SeasonalEmployee() : base()
        {
            season = "";
            piecePay = 0.0;
            EmployeeType = SEASONAL;
        }

        /*
         *   FUNCTION    : SeasonalEmployee()
         *   DESCRIPTION : Constructor with first and last name
         *   PARAMETERS  :
         *       string - newFirstName 
         *       string - newLastName 
         */

        public SeasonalEmployee(string newFirstName, string newLastName)
            : base()
        {
            setFirstName(newFirstName);
            setLastName(newLastName);
            SIN = "";
            DateOfBirth = "";
            season = "";
            piecePay = 0.0;
            EmployeeType = SEASONAL;
        }
        
        /*
        *   FUNCTION    : SeasonalEmployee()
        *   DESCRIPTION : Constructor taking all parameters.
        *   PARAMETERS  :
        *        string - newFirstName 
        *        string - newLastName 
        *        string - newSIN
        *        string - newDateOfBirth
        *        string - newSeason 
        *        string - newPiecePay 
        */
        public SeasonalEmployee(string newFirstName, string newLastName, string newSIN, string newDateOfBirth,
            string newSeason, double newPiecePay) : base()
        {
            setFirstName(newFirstName);
            setLastName(newLastName);
            setSIN(newSIN);
            setDateOfBirth(newDateOfBirth);
            setSeason(newSeason);
            setPiecePay(newPiecePay);
            EmployeeType = SEASONAL;
        }

        /*
         *  Season property getter and setter.
         */

        public string Season
        {
            get { return season; }
            set { season = value; }
        }
        
        /*
        *   FUNCTION    : setSeason()
        *   DESCRIPTION : Sets the season based on validity.
        *   PARAMETERS  :
        *           string - seasonToVerify
        *   RETURNS     :
        *          bool
        */
        public bool setSeason(string seasonToVerify)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.season(seasonToVerify);
                Season = seasonToVerify;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Season:" + seasonToVerify + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                Season = "";
            }

            return valid;
        }

        /*
         *  Piece pay property containing getter and setter.
         */

        public double PiecePay
        {
            get { return piecePay; }
            set { piecePay = value; }
        }

        /*
         *  FUNCTION    : setPiecePay()
         *  DESCRIPTION : Sets the piece pay based on validation.
         *  PARAMETERS  :
         *      double payToVerify
         *  RETURNS     :
         *      bool
         */
        public bool setPiecePay(double payToVerify)
        {
            bool valid = false;
            try
            {
                valid = Validation.Validate.number(payToVerify);
                PiecePay = payToVerify;
            }
            catch (Exception)
            {
                try
                {
                    Logging.LogThis("Piece Pay:" + payToVerify.ToString() + " - INVALID", this.GetType().Name);
                }
                catch (Exception)
                { }
                PiecePay = 0.0;
            }

            return valid;
        }

        /*
        *   FUNCTION    : validate()
        *   DESCRIPTION : Validates a given seasonal employee.
        *   RETURNS     :
        *           bool
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
                Validation.Validate.season(Season);
                Validation.Validate.number(PiecePay);
                if (SIN != "0" && Season != "" && PiecePay != 0)
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
         *   DESCRIPTION : Displays the details of a seasonal employee.
         *   PARAMETERS  :
         *        int - x  
         *        int - y  
         *        ConsoleColor - backColour 
         *        ConsoleColor - frontColour
        */
        public override void details(int x, int y, ConsoleColor backColour, ConsoleColor frontColour)
        {
            string fullLine = "| SN |";

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

            fullLine += "| " + DateOfBirth + "  | " + SIN + " |     N/A    " + "|         N/A        " + " |     N/A    " + "|     N/A   ";

            if (Season.Length == 6)
            {
                fullLine += " | " + Season + " |";
            }
            else
            {
                fullLine += " |  " + Season + "  |";
            }

            string pay = String.Format("{0:0.00}", PiecePay);

            for (int i = 12; i > pay.Length + 1; i--)
            {
                fullLine += " ";
            }
            fullLine += "$" + pay + " |";

            try
            {
                Logging.LogThis("Seasonal Employee: " + fullLine, this.GetType().Name);
            }
            catch (Exception)
            { }
            //UI.MenuFunctions.WriteColorString(fullLine, x, y, backColour, frontColour);
        }
    }
}