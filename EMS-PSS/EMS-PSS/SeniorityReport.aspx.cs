/*
*  FILE             : SeniorityReport.aspx.cs
*  PROJECT          : Software Quality 2 Final Project
*  PROGRAMMER       : Brad Carradine, Jackson Ruby, James Simpson
*  DATE		        : April 21, 2016
*  DESCRIPTION      :
*          This file contains all of the methods in the code-behind part of the SeniorityReport.aspx page.  This page will allow the user to view the seniority report.
*/

using System;
using System.Data;

namespace EMS_PSS
{
    public partial class SeniorityReport : System.Web.UI.Page
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
                    html = "Seniority Report <br /><table><tr><th>Employee Name</th><th>SIN</th><th>Type</th><th>Date Of Hire</th><th>Years Of Service</th></tr>";

                    DataTable userList = SQL_Connection.GetTable(SQL_Connection.EMPLOYEE_TABLE, new string[1] { "Active='1'" });
                    DateTime today = DateTime.Now;

                    foreach (DataRow row in userList.Rows)
                    {
                        DateTime dateOfHire = DateTime.Parse(row["DateOfHire"].ToString());

                        int yearsOfService = today.Year - dateOfHire.Year;

                        if (dateOfHire.Month == dateOfHire.Month && today.Day < dateOfHire.Day)
                        {
                            yearsOfService--;
                        }
                        else if (today.Month < dateOfHire.Month)
                        {
                            yearsOfService--;
                        }

                        html += html += "<tr style='text-align: left;'><td>" + row["FirstName"] + "</td><td>" + row["SocialInsuranceNumber"] + "</td><td>"
                            + row["DateOfHire"] + "</td><td>" + yearsOfService.ToString() + "</td></tr>";
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