/*
 *  FILE            : Logging.cs
 *  PROJECT         : EMS Term Project
 *  PROGRAMMER      : Brad Carradine
 *  FIRST VERSION   : 12/11/15
 *  DESCRIPTION     :
 *          Contains all code that will allow the program to create logs of information. This is useful for an audit trail.
 */

using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Log
{
    /**
    * @brief A class which allows for logging.
    *
    * This class is meant to allow logging from any point in the program.  This class is a static class to allow it to be called and not instantiated so that it can save instantiating an object,
    *  write the log then stop using the object.  Because of this, the single method within is self-contained and does not rely on any other variables.
    */

    public static class Logging
    {
        /**
         *  The function that will be called to write the log to a text file.  The file will automatically create the file based on the date. It wlil take a message from the
         *      class as well as the calling class name (but not the method, as that can be done by .NET).  This method will return several exceptions. They are:
         *          - DirectoryNotFoundException
         *          - UnautorizedAccessException
         *          - ArgumentException
         *          - IOException
         *  @param message The message that can be logged.  This allows the person reading the logs to know what has happened.
         *  @param className The class that is calling the LogThis method.  This is not easily grabbed from the program, so it has to be manually sent.
         *  @param memberName This is automatically filled out based off of what function is calling the LogThis method.
         *  @return <b>Nothing</b>
         */

        public static void LogThis(string message, string className, [CallerMemberName] string memberName = "")
        {
            StreamWriter theLogFile;
            string directory = Directory.GetCurrentDirectory();

            //Checks to see if the Directory exists and if not, creates it.
            if (!Directory.Exists(@".\logs"))
            {
                Directory.CreateDirectory("logs"); ;
            }

            try
            {
                //Creates a new StreamWriter in the logs directory and appends to the file (or creates it if it does not exist.
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                string time = DateTime.Now.ToLongTimeString();

                //Writes to the file for todays date.  THe true means that it is appending to the end of the file.
                theLogFile = new StreamWriter(directory + @"\logs\ems." + date + ".log", true);

                theLogFile.WriteLine(date + " - " + time + " [" + className + "." + memberName + "] -\t" + message);
                theLogFile.Close();
            }
            //If there is any issue with writing to the log file, it will catch and then re-throw the exception.
            catch (DirectoryNotFoundException dnfe)
            {
                throw dnfe;
            }
            catch (UnauthorizedAccessException uae)
            {
                throw uae;
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
        }
    }
}