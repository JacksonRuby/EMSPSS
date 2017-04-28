/*
*  FILE             : Login.aspx.cs
*  PROJECT          : Software Quality 2 Final Project
*  PROGRAMMER       : Brad Carradine, Jackson Ruby, James Simpson
*  DATE		        : April 21, 2016
*  DESCRIPTION      :
*          This file contains all of the methods in the code-behind part of the Login.aspx page. This page allows the user to log-in and use the rest of the system.
*/

using System;
using System.Web.UI.WebControls;

namespace EMS_PSS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /*
        * Function: Page_Load
        * Description:
        *	    This event method will be called when the page is loaded. It does not currently do anything, but is necessary for the page to function.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /*
        * Function: Login_Authenticate
        * Description:
        *	    This event method will be called when the login button is clicked.  It authenticates the user.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = Login.UserName;
            string password = Encryption.enc(Login.Password);
            if (SQL_Connection.RowExists("SystemUser", new string[1] { "Password='" + password + "'" }))
            {
                Session["user"] = username;
                SQL_Connection.LoggedInUser = username;
                Session["pass"] = password;
                Session["lowerrange"] = 0;
                Session["upperrange"] = 20;
                if (SQL_Connection.IsAdmin(username, password))
                {
                    Session["isadmin"] = true;
                }
                else
                {
                    Session["isadmin"] = false;
                }
            }
            Response.Redirect("index.aspx", false);
        }
    }
}