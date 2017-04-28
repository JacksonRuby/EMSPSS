/*
*  FILE             : ActiveEmployeeReport.aspx.cs
*  PROJECT          : Software Quality 2 Final Project
*  PROGRAMMER       : Brad Carradine, Jackson Ruby, James Simpson
*  DATE		        : April 21, 2016
*  DESCRIPTION      :
*          This file contains all of the methods in the code-behind part of the ActiveEmployeeReport.aspx page.  This file will display the report
*               that has to do with how many active employees there are.
*/

using System;
using System.Data;

namespace EMS_PSS
{
    public partial class ActiveEmployeesReport : System.Web.UI.Page
    {
        /*
        * Function: Page_Load
        * Description:
        *	    This event method will be called when the page is loaded. It checks to make sure that the user is logged in, and if not, redirects them to the
        *	        Login page.  It then checks if the user is an admin, and will render the page if they are, or will display an error if not.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if ((bool)Session["isadmin"] == true)
                {
                    string html = "";
                    //Full Time
                    html = "Full Time <br /><table><tr><th>Employee Name</th><th>Date Of Hire</th><th>Avg. Hours</th></tr>";

                    DataTable userListFullTime = SQL_Connection.GetTable(SQL_Connection.EMPLOYEE_TABLE, new string[2] { "Active='1'", "EmployeeType='FullTime'" });

                    foreach (DataRow row in userListFullTime.Rows)
                    {
                        float hours = SQL_Connection.GetColumnSum("Timesheet", "HoursWorked", new string[1] { "EmployeeID='" + row["EmployeeID"].ToString() + "'" });
                        float numberShifts = SQL_Connection.GetColumnCount("Timesheet", "HoursWorked", new string[1] { "EmployeeID='" + row["EmployeeID"].ToString() + "'" });
                        float average = 0.0f;
                        if (hours != 0.0 && numberShifts != 0.0)
                        {
                            average = hours / numberShifts;
                        }
                        html += "<tr style='text-align: left;'><td>" + row["EmployeeName"] + "</td><td>" + row["DateOfHire"] + "</td><td>" + average.ToString() + "</td></tr>";
                    }
                    html += "</table>";
                    html += "<br />";
                    //Part Time
                    html += "Part Time <br /><table><tr><th>Employee Name</th><th>Date Of Hire</th><th>Avg. Hours</th></tr>";

                    DataTable userListPartTime = SQL_Connection.GetTable(SQL_Connection.EMPLOYEE_TABLE, new string[2] { "Active='1'", "EmployeeType='PartTime'" });

                    foreach (DataRow row in userListPartTime.Rows)
                    {
                        float hours = SQL_Connection.GetColumnSum("Timesheet", "HoursWorked", new string[1] { "EmployeeID='" + row["EmployeeID"].ToString() + "'" });
                        float numberShifts = SQL_Connection.GetColumnCount("Timesheet", "HoursWorked", new string[1] { "EmployeeID='" + row["EmployeeID"].ToString() + "'" });
                        float average = 0.0f;
                        if (hours != 0.0 && numberShifts != 0.0)
                        {
                            average = hours / numberShifts;
                        }
                        html += "<tr style='text-align: left;'><td>" + row["EmployeeName"] + "</td><td>" + row["DateOfHire"] + "</td><td>" + average.ToString() + "</td></tr>";
                    }
                    html += "</table>";
                    html += "<br />";
                    //Seasonal
                    html += "Seasonal<br /><table><tr><th>Employee Name</th><th>Date Of Hire</th><th>Avg. Hours</th></tr>";

                    DataTable userListSeasonal = SQL_Connection.GetTable(SQL_Connection.EMPLOYEE_TABLE, new string[2] { "Active='1'", "EmployeeType='Seasonal'" });

                    foreach (DataRow row in userListSeasonal.Rows)
                    {
                        float hours = SQL_Connection.GetColumnSum("Timesheet", "HoursWorked", new string[1] { "EmployeeID='" + row["EmployeeID"].ToString() + "'" });
                        float numberShifts = SQL_Connection.GetColumnCount("Timesheet", "HoursWorked", new string[1] { "EmployeeID='" + row["EmployeeID"].ToString() + "'" });
                        float average = 0.0f;
                        if (hours != 0.0 && numberShifts != 0.0)
                        {
                            average = hours / numberShifts;
                        }
                        html += "<tr style='text-align: left;'><td>" + row["EmployeeName"] + "</td><td>" + row["DateOfHire"] + "</td><td>" + average.ToString() + "</td></tr>";//Need to add fucking average hours
                    }
                    html += "</table>";
                    html += "<br />";
                    //Contract

                    html += "Contract<br /><table><tr><th>Employee Name</th><th>Date Of Hire</th><th>Avg. Hours</th></tr>";

                    DataTable userListContract = SQL_Connection.GetTable(SQL_Connection.EMPLOYEE_TABLE, new string[2] { "Active='1'", "EmployeeType='Seasonal'" });

                    foreach (DataRow row in userListSeasonal.Rows)
                    {
                        html += "<tr style='text-align: left;'><td>" + row["EmployeeName"] + "</td><td>" + row["DateOfHire"] + "</td><td> ---- </td></tr>";
                    }
                    html += "</table>";
                    html += "Date Generated: " + DateTime.Now.ToString();
                    html += "Run By: " + Session["user"].ToString();

                    Reports.InnerHtml = html;
                }
                else
                {
                    string html = "";

                    html = "<h1 style='color: red;'>You are not a valid user.</h1>";

                    Reports.InnerHtml = html;
                }
            }
        }
    }
}