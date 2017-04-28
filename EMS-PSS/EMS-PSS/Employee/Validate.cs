/*
 *  FILE            : Validate.cs
 *  PROJECT         : EMS Term Project
 *  PROGRAMMER      : Jackson Ruby
 *  FIRST VERSION   : 12/11/15
 *  DESCRIPTION     :
 *          This file contains all the validation code.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Validation
{
    /**
    * @brief The validate class contains all methods for validating all information added to an employee class.
    *
    * This class contains all the validation functions for information added to an employee class.
    *
    */

    public static class Validate
    {
        /**
         *  Validates a given date.
         *  @param dateToVerify The date to check for validity.
         *  @return bool Valid or Invalid for true or false.
         */

        public static bool date(string dateToVerify)
        {
            bool returnValid = true;

            //check the date is in the format YYYY-MM-DD
            if (dateToVerify.Length == 10)
            {
                //split date and ensure each part is correct length
                string[] parts = dateToVerify.Split('-');
                if (parts[0].Length == 4 && parts[1].Length == 2 && parts[2].Length == 2)
                {
                    //check all parts are numbers and add to a list numbers
                    bool allints = true;
                    List<int> intValues = new List<int>();
                    for (int i = 0; i < parts.Length; i++)
                    {
                        for (int character = 0; character < parts[i].Length; character++)
                        {
                            if (!Char.IsDigit(parts[i][character]))
                            {
                                allints = false;
                                break;
                            }
                        }

                        if (allints)
                        {
                            intValues.Add(int.Parse(parts[i].ToString()));
                        }
                        else
                        {
                            break;
                        }
                    }

                    //if all parts are numbers
                    if (allints)
                    {
                        DateTime current = DateTime.Now;
                        if (intValues[0] <= current.Year)
                        {
                            //check if each part of the date is an appropriate value
                            int temp = intValues[1];
                            if (temp > current.Month && intValues[0] == current.Year)
                            {
                                returnValid = false;
                                string exceptionStr = "Month cannot be later than current month.";
                                throw new Exception(exceptionStr);
                            }
                            else if (intValues[2] > current.Day && temp == current.Month && intValues[0] == current.Year)
                            {
                                returnValid = false;
                                string exceptionStr = "Day cannot be later than current day.";
                                throw new Exception(exceptionStr);
                            }
                            else
                            {
                                if (intValues[2] < 1)
                                {
                                    returnValid = false;
                                    throw new Exception("Day value cannot be less than 1.");
                                }
                                else if (temp == 01 || temp == 03 || temp == 05 || temp == 07 || temp == 08 || temp == 10 || temp == 12)
                                {
                                    //check date value is valid for a month with 30 days
                                    if (intValues[2] > 31)
                                    {
                                        returnValid = false;
                                        string exceptionStr = "Day value cannot be larger than 30 with corresponding month " + intValues[1] + ".";
                                        throw new Exception(exceptionStr);
                                    }
                                }
                                else if (temp == 04 || temp == 06 || temp == 09 || temp == 11)
                                {
                                    //check date value is valid for a month with 31 days
                                    if (intValues[2] > 30)
                                    {
                                        returnValid = false;
                                        string exceptionStr = "Day value cannot be larger than 31 with corresponding month " + intValues[1] + ".";
                                        throw new Exception(exceptionStr);
                                    }
                                }
                                else if (temp == 02)
                                {
                                    //check date value is valid for february
                                    int maxNum = 28;
                                    if (DateTime.IsLeapYear(intValues[0]))
                                    {
                                        maxNum = 29;
                                    }
                                    if (intValues[2] > maxNum)
                                    {
                                        returnValid = false;
                                        string exceptionStr = "Day value cannot be larger than " + maxNum + " with corresponding month " + intValues[1] + " and year " + intValues[0] + ".";
                                        throw new Exception(exceptionStr);
                                    }
                                }
                            }
                            
                        }
                        else
                        {
                            returnValid = false;
                            string exceptionStr = "Year cannot be later than current year.";
                            throw new Exception(exceptionStr);
                        }
                        
                    }
                    else
                    {
                        returnValid = false;
                        string exceptionStr = "Date value must be all numbers.";
                        throw new Exception(exceptionStr);
                    }
                }
                else
                {
                    returnValid = false;
                    string exceptionStr = "Date must be in format YYYY-MM-DD.";
                    throw new Exception(exceptionStr);
                }
            }
            else
            {
                returnValid = false;
                string exceptionStr = "Date must be in format YYYY-MM-DD.";
                throw new Exception(exceptionStr);
            }

            return returnValid;
        }

        /**
         *  Validates a given social insurance number.
         *  @param SIN The social insurance number to check for validity.
         *  @return bool Valid or Invalid for true or false.
         */

        public static bool sin(string SIN)
        {
            bool returnValid = true;

            //ensure the sin string is all numbers and spaces
            if (isNumbersAndSpaces(SIN))
            {
                //check if the SIN is 9 characters without spaces
                string tempSIN = SIN;
                SIN = "";
                foreach (char c in tempSIN)
                {
                    if (c != ' ')
                    {
                        SIN += c;
                    }
                }

                //reformat string to "### ### ###"
                if (SIN.Length >= 9)
                {
                    SIN = SIN.Substring(0, 3) + " " + SIN.Substring(3, 3) + " " + SIN.Substring(6, 3);
                }
                else
                {
                    returnValid = false;
                    string exceptionStr = "SIN contains too many numbers.";
                    throw new Exception(exceptionStr);
                }
            }
            else
            {
                returnValid = false;
                string exceptionStr = "SIN must be all numbers.";
                throw new Exception(exceptionStr);
            }

            //ensure everything is okay so far
            if (returnValid && SIN.Length == 11 && SIN[3] == ' ' && SIN[7] == ' ')
            {
                //convert to a list of numbers
                string[] sinParts = SIN.Split();
                List<int> intParts = new List<int>();
                for (int part = 0; part < 3; part++)
                {
                    for (int character = 0; character < 3; character++)
                    {
                        intParts.Add(int.Parse(sinParts[part][character].ToString()));
                    }
                }

                //do SIN calculation for even numbers
                int[] evens = new int[4] { intParts[1], intParts[3], intParts[5], intParts[7] };
                int evenSum = sinSum(evens);

                //do SIN calculation for odd numbers
                int[] odds = new int[4] { intParts[0], intParts[2], intParts[4], intParts[6] };
                int oddSum = 0;
                foreach (int i in odds)
                {
                    oddSum += i;
                }

                //add sums and get last character for checking
                int sumBoth = evenSum + oddSum;
                string temp = sumBoth.ToString();
                int check = 0;
                int lastChar = int.Parse(temp[temp.Count() - 1].ToString());
                if (lastChar != 0)
                {
                    check = 10 - lastChar;
                }

                //check the last digit is good
                if (check == intParts[8])
                {
                    returnValid = true;
                }
                else
                {
                    returnValid = false;
                    string exceptionStr = "Values do not make a valid SIN number.";
                    throw new Exception(exceptionStr);
                }
            }
            else if (SIN.Length == 1 && SIN == "0")
            {
                returnValid = true;
            }
            else
            {
                returnValid = false;
                string exceptionStr = "Invalid number of characters in the SIN.";
                throw new Exception(exceptionStr);
            }

            return returnValid;
        }

        /*
         *  FUNCTION    : sin()
         *  DESCRIPTION : Second sin function verifying a business number based on the date provided.
         *  PARAMETERS  :
         *      string SIN
         *      string dateOfIncorp
         *  RETURNS     :
         *      bool
         */

        public static bool sin(string BN, string dateOfIncorp)
        {
            bool returnValid = true;

            //ensure the business number is all numbers and spaces
            if (isNumbersAndSpaces(BN))
            {
                //remove all spaces
                string tempSIN = BN;
                BN = "";
                foreach (char c in tempSIN)
                {
                    if (c != ' ')
                    {
                        BN += c;
                    }
                }

                //reformat to appropriate business number
                if (BN.Length >= 9)
                {
                    BN = BN.Substring(0, 5) + " " + BN.Substring(5, 4);
                }
                else
                {
                    returnValid = false;
                    string exceptionStr = "Business Number contains too many numbers.";
                    throw new Exception(exceptionStr);
                }
            }
            else
            {
                returnValid = false;
                string exceptionStr = "Business Number must be all numbers.";
                throw new Exception(exceptionStr);
            }

            //ensure everything is okay so far
            if (returnValid && BN.Length == 10 && BN[5] == ' ')
            {
                //check the date corresponds with the first characters of the business number
                try
                {
                    if (Validate.date(dateOfIncorp) && BN.Substring(0, 2) != dateOfIncorp.Substring(2, 2))
                    {
                        returnValid = false;
                        string exceptionStr = "Business Number does not correspond with Date of Incorperation.";
                        throw new Exception(exceptionStr);
                    }
                }
                catch (Exception e)
                {
                    returnValid = false;
                    throw new Exception(e.Message);
                }
            }
            else if (BN.Length == 1 && BN == "0")
            {
                returnValid = true;
            }
            else
            {
                returnValid = false;
                string exceptionStr = "Invalid number of characters in the Business Number.";
                throw new Exception(exceptionStr);
            }

            return returnValid;
        }

        /**
         *  Doe adding of specific characters in the sin for checking for validity.
         *  @param numbers The numbers contained in the SIN.
         *  @return int The specific sum calculated.
         */

        private static int sinSum(int[] numbers)
        {
            int sum = 0;
            //iterate through the numbers
            for (int i = 0; i < numbers.Length; i++)
            {
                //multiply each number by 2
                numbers[i] *= 2;
                /*
                 * if the new number is larger than ten, then split into two seperate digits
                 * and add each digit to the sum
                 * ie.  if the number is 6 and is multiplied by 2, then the new number is 12.
                 *      the two digits are separated (1 and 2) and both added to the sum
                 *      separately.
                 */
                if (numbers[i] > 10)
                {
                    string temp = numbers[i].ToString();
                    sum += int.Parse(temp[0].ToString());
                    sum += int.Parse(temp[1].ToString());
                }
                else
                {
                    sum += numbers[i];
                }
            }

            return sum;
        }

        /*
         *  FUNCTION    : isNumbersAndSpaces()
         *  DESCRIPTION : Checks if a string is all numbers and spaces.
         *  PARAMETERS  :
         *      string SIN
         *  RETURNS     :
         *      bool
         */

        private static bool isNumbersAndSpaces(string SIN)
        {
            bool returnVal = true;
            //iterate through the characters of the SIN string
            for (int character = 0; character < SIN.Length; character++)
            {
                //check each character is a number or a space
                if (!char.IsDigit(SIN[character]) && SIN[character] != ' ')
                {
                    returnVal = false;
                }
            }
            return returnVal;
        }

        /*
         *  FUNCTION    : name()
         *  DESCRIPTION : Validates a name string.
         *  PARAMETERS  :
         *      string name
         *  RETURNS     :
         *      bool
         */

        public static bool name(string name)
        {
            bool returnValid = true;
            //iterate through the name string
            foreach (char c in name)
            {
                //check each character is a letter, an apostrophe or a dash
                if (!char.IsLetter(c) && c != '\'' && c != '-')
                {
                    returnValid = false;
                    string exceptionStr = "Name can only contain letters with the exception of apostrophies and dashes.";
                    throw new Exception(exceptionStr);
                }
            }

            return returnValid;
        }

        /**
         *  Validates a given number.
         *  @param numToVerify The number to check for validity.
         *  @return bool Valid or Invalid for true or false.
         */

        public static bool number(double numToVerify)
        {
            bool returnValid = true;
            //check that the number is greater than 0
            if (numToVerify < 0)
            {
                returnValid = false;
                string exceptionStr = "Number must be larger than 0.";
                throw new Exception(exceptionStr);
            }

            return returnValid;
        }

        /**
         *  Validates a given season string.
         *  @param seasonToVerify The season to check for validity.
         *  @return bool Valid or Invalid for true or false.
         */

        public static bool season(string seasonToVerify)
        {
            bool returnValid = true;
            //check that the season is a valid season, or a space
            string season = seasonToVerify.ToLower();
            if (season != "" && season != "winter" && season != "summer" &&
                season != "spring" && season != "fall")
            {
                returnValid = false;
                string exceptionStr = "Invalid season type.";
                throw new Exception(exceptionStr);
            }

            return returnValid;
        }

        /**
         *  Validates two dates being in chronological order.
         *  @param startDate The date that should be before the other date.
         *  @param endDate The date that should be after the other date.
         *  @return bool Valid or Invalid for true or false.
         */

        public static bool chronologicalDates(string startDate, string endDate)
        {
            bool allValid = false;

            if (endDate != "")
            {
                //split the dates into manageable pieces
                string[] endParts = endDate.Split('-');
                string[] startParts = startDate.Split('-');

                int endYear = 0;
                int.TryParse(endParts[0], out endYear);
                int startYear = 0;
                int.TryParse(startParts[0], out startYear);
                //if the end year is larger than the start year, then the fields are valid
                if (endYear > startYear)
                {
                    allValid = true;
                }
                else if (endYear == startYear)
                {
                    int endMo = 0;
                    int.TryParse(endParts[1], out endMo);
                    int startMo = 0;
                    int.TryParse(startParts[1], out startMo);
                    //if the years are the same, check the months
                    //if the end month is larger than the start month, then the fields are valid
                    if (endMo > startMo)
                    {
                        allValid = true;
                    }
                    else if (endMo == startMo)
                    {
                        int endDay = 0;
                        int.TryParse(endParts[2], out endDay);
                        int startDay = 0;
                        int.TryParse(startParts[2], out startDay);
                        //if the months are the same, check the days
                        //if the end day is larger than the start day, then the fields are valid
                        if (endDay > startDay)
                        {
                            allValid = true;
                        }
                    }
                }
            }
            else
            {
                allValid = true;
            }

            return allValid;
        }
    }
}