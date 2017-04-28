/*
*  FILE             : EmployeeSearch.aspx.cs
*  PROJECT          : Software Quality 2 Final Project
*  PROGRAMMER       : Brad Carradine, Jackson Ruby, James Simpson
*  DATE		        : April 21, 2016
*  DESCRIPTION      :
*          This file contains all of the methods in the code-behind part of the EmployeeSearch.aspx page. This page allows the user to search
*               through the different employees.
*/

using System;
using System.Data;
using System.Web.UI.WebControls;

namespace EMS_PSS
{
    public partial class EmployeeSearch : System.Web.UI.Page
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
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        /*
        * Function: btnSearch_Click
        * Description:
        *	    This event method will be called when the btnSearch is clicked.  It will then search through the data to see if there was matches
        *	        and return the list of the things that match.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable DBReturnTable = SQL_Connection.SearchTable(SQL_Connection.EMPLOYEE_TABLE, txtSearch.Text);
            TableRow row = null;

            row = new TableRow();
            for (int i = 0; i < DBReturnTable.Columns.Count; i++)
            {
                if (i != 0 && i != 6 && i != 9 && i < 16)
                {
                    string colName = DBReturnTable.Columns[i].ColumnName;
                    TableHeaderCell headCell = new TableHeaderCell();
                    if (colName.ToLower() == "socialinsurancenumber")
                    {
                        colName = "SIN";
                    }
                    else if (colName.ToLower() == "contractstartdate")
                    {
                        colName = "C.StartDate";
                    }
                    else if (colName.ToLower() == "contractenddate")
                    {
                        colName = "C.EndDate";
                    }
                    else if (colName.ToLower() == "fixedcontractrate")
                    {
                        colName = "ContractRate";
                    }
                    else if (colName.ToLower() == "dateoftermination")
                    {
                        colName = "Termination";
                    }
                    headCell.Text = colName;
                    row.Cells.Add(headCell);
                }
            }
            ResultsTable.Rows.Add(row);

            for (int i = 0; i < DBReturnTable.Rows.Count; i++)
            {
                row = new TableRow();
                for (int c = 0; c < DBReturnTable.Columns.Count; c++)
                {
                    string cellVal = DBReturnTable.Rows[i][c].ToString();
                    float intCellVal = 0;
                    DateTime dtCellVal = new DateTime();
                    if (c != 0 && c != 6 && c != 9 && c < 16)
                    {
                        TableCell cell = new TableCell();
                        if (c != 4 && float.TryParse(cellVal, out intCellVal))
                        {
                            cellVal = intCellVal.ToString("c2");
                        }
                        else if (DateTime.TryParse(cellVal, out dtCellVal))
                        {
                            cellVal = dtCellVal.ToShortDateString();
                        }
                        cell.Text = cellVal;
                        row.Cells.Add(cell);
                    }
                }
                ResultsTable.Rows.Add(row);
            }
        }
    }
}