/*
*  FILE             : DisplayAllEmployees.aspx.cs
*  PROJECT          : Software Quality 2 Final Project
*  PROGRAMMER       : Brad Carradine, Jackson Ruby, James Simpson
*  DATE		        : April 21, 2016
*  DESCRIPTION      :
*          This file contains all of the methods in the code-behind part of the DisplayAllEmployees.aspx page.  It will allow the user to display all the employees.
*/

using System;
using System.Data;
using System.Web.UI.WebControls;

namespace EMS_PSS
{
    public partial class DisplayAllEmployees : System.Web.UI.Page
    {
        private int lowerrange = 0;
        private int upperrange = 0;
        private int count = 0;

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
                lowerrange = (int)Session["lowerrange"];
                upperrange = (int)Session["upperrange"];
                count = SQL_Connection.GetNumRows("Employee");
                DataTable DBReturnTable = SQL_Connection.GetTable(SQL_Connection.EMPLOYEE_TABLE, upperrange, lowerrange);
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
                    HyperLink link = new HyperLink();
                    link.NavigateUrl = "EditEmployee.aspx?ID=" + DBReturnTable.Rows[i]["EmployeeID"].ToString();
                    link.Text = "Edit";

                    TableCell EditCell = new TableCell();
                    EditCell.Controls.Add(link);
                    row.Cells.Add(EditCell);
                    ResultsTable.Rows.Add(row);
                }
            }
        }

        /*
        * Function: btnNext_Click
        * Description:
        *	    This event method will be called when the btnNext button is clicked.  It then switches the page to a new one.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void btnNext_Click(object sender, EventArgs e)
        {
            lowerrange = upperrange;
            Session["lowerrange"] = lowerrange;
            if (upperrange + 20 >= count)
            {
                upperrange = count;
            }
            else
            {
                upperrange += 20;
            }

            Session["upperrange"] = upperrange;
            Response.Redirect("DisplayAllEmployees.aspx", false);
        }

        /*
        * Function: btnPrev_Click
        * Description:
        *	    This event method will be called when the btnPrev button is clicked.  It then switches the page to a new one.
        * Parameters:
        *	    object sender
        *	    EventArgs e
        * Returns:
        *	    None.
        */

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            upperrange = lowerrange;
            Session["upperrange"] = upperrange;
            if (lowerrange - 20 < 0)
            {
                lowerrange = 0;
            }
            else
            {
                lowerrange -= 20;
            }
            Session["lowerrange"] = lowerrange;
            Response.Redirect("DisplayAllEmployees.aspx", false);
        }
    }
}