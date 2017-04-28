/*
*  FILE             : PayrollReport.aspx.cs
*  PROJECT          : Software Quality 2 Final Project
*  PROGRAMMER       : Brad Carradine, Jackson Ruby, James Simpson
*  DATE		        : April 21, 2016
*  DESCRIPTION      :
*          This file contains all of the methods in the code-behind part of the PayrollReport.aspx page. This page will display the payroll report.
*/

using System;

namespace EMS_PSS
{
    public partial class PayrollReport : System.Web.UI.Page
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