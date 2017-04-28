/*
*  FILE             : InactiveEmployeeReport.aspx.cs
*  PROJECT          : Software Quality 2 Final Project
*  PROGRAMMER       : Brad Carradine, Jackson Ruby, James Simpson
*  DATE		        : April 21, 2016
*  DESCRIPTION      :
*          This file contains all of the methods in the code-behind part of the InactiveEmployeeReport.aspx page. This page will
*               display the amount of users who have left the company.
*/

using System;
using System.Data;

namespace EMS_PSS
{
    public partial class InactiveEmployeeReport : System.Web.UI.Page
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
                    html = "Inactive Employment Report <br /><table><tr><th>Employee Name</th><th>Date Of Hire</th><th>Terminated</th><th>Type</th><th>Reason For Leaving</th></tr>";

                    DataTable inactiveEmployees = SQL_Connection.GetTable(SQL_Connection.EMPLOYEE_TABLE, new string[1] { "Active !='1'" });

                    foreach (DataRow row in inactiveEmployees.Rows)
                    {
                        html += "<tr style='text-align: left;'><td>" + row["EmployeeName"] + "</td><td>" + row["DateOfHire"]
                            + "</td><td>" + row["DateOfTermination"] + "</td><td>" + row["EmployeeType"] + "</td><td>"
                            + row["ReasonForLeaving"] + "</td></tr>";
                    }
                    html += "</table>";
                    html += "Date Generated: " + DateTime.Now.ToString();
                    html += "Run By: " + Session["user"].ToString();
                    html += "<br />";

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