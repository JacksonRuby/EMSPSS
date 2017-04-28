/*
*  FILE             : NewUser.aspx.cs
*  PROJECT          : Software Quality 2 Final Project
*  PROGRAMMER       : Brad Carradine, Jackson Ruby, James Simpson
*  DATE		        : April 21, 2016
*  DESCRIPTION      :
*          This file contains all of the methods in the code-behind part of the NewUser.aspx page. This page will allow the user to add a new user to the system.
*/

using System;

namespace EMS_PSS
{
    public partial class NewUser : System.Web.UI.Page
    {
        /*
        * Function: Page_Load
        * Description:
        *	This event method will be called when the page is loaded. It checks to make sure that the user is logged in, and if not, redirects them to the
        *	    Login page.  It then checks if the user is an admin, and will render the page if they are, or will display an error if not.
        * Parameters:
        *	object sender
        *	EventArgs e
        * Returns:
        *	None.
        */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
               
            }
        }

        protected void btnSaveAddNew_Click(object sender, EventArgs e)
        {
            SQL_Connection.InsertUser(
                0,
                txtLastName.Text,
                txtFirstName.Text,
                chkAdmin.Checked,
                txtUsername.Text,
                Encryption.enc(txtUsername.Text));
            Response.Redirect("SystemAdmin.aspx");
        }
    }
}