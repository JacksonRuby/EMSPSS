/*
*  FILE             : SystemAdmin.aspx.cs
*  PROJECT          : Software Quality 2 Final Project
*  PROGRAMMER       : Brad Carradine, Jackson Ruby, James Simpson
*  DATE		        : April 21, 2016
*  DESCRIPTION      :
*          This file contains all of the methods in the code-behind part of the SystemAdmin.aspx page. This page allows the user to go to the other
*               system administration pages.
*/

using System;

namespace EMS_PSS
{
    public partial class SystemAdmin : System.Web.UI.Page
    {
        /*
        * Function: Page_Load
        * Description:
        *	    This event method will be called when the page is loaded. It checks to make sure that the user is logged in, and if not, redirects them to the
        *	        Login page.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }
                else if ((bool)Session["isadmin"] == false)
                {
                    Response.Redirect("index.aspx", false);
                }
            }
            
        }
    }
}