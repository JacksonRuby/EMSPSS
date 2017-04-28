using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EMS_PSS
{
    public static class SQL_Connection
    {
        private static string ConnString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
        public static string LoggedInUser = "";
        public const int SYSTEM_USER_TABLE = 1;
        public const int EMPLOYEE_TABLE = 2;
        public const int COMPANY_TABLE = 3;
        public const int EMPLOYED_WITH_COMPANY_ID = 1;
        public const int EMPLOYEE_TYPE = 2;
        public const int LAST_NAME = 3;
        public const int FIRST_NAME = 4;
        public const int SIN = 5;
        public const int DATE_OF_BIRTH = 6;
        public const int REASON_FOR_LEAVING = 7;
        public const int DATE_OF_HIRE = 8;
        public const int DATE_OF_TERMINATION = 9;
        public const int RECORD_COMPLETE = 10;
        public const int SALARY = 11;
        public const int HOURLY_RATE = 12;
        public const int CONTRACT_START_DATE = 13;
        public const int CONTRACT_END_DATE = 14;
        public const int FIXED_CONTRACT_RATE = 15;
        public const int PIECE_PAY = 16;
        public const int COMPANY_ID = 19;
        public const int ACTIVE = 17;

        /*
        *   FUNCTION    : SelectAllFromTable()
        *   DESCRIPTION : Accesses the database and gets all data from a given table.
        *   PARAMETERS  :
        *       DataTable dt        : The datatable as a reference to put data into.
        *       string TableName    : The table to access.
        */

        public static void SelectAllFromTable(ref DataTable dt, string TableName)
        {
            //connect to the database
            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + TableName, dbConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConnection.Open();
            da.Fill(dt);
            dbConnection.Close();
            da.Dispose();
        }

        /*
        *   FUNCTION    : RowExists()
        *   DESCRIPTION : Accesses the database and checks if a row exists.
        *   PARAMETERS  :
        *       string TableName    : The table to access.
        *       string[] Conditions : The conditions to check for. Each condition must be the
        *                             row name and what to compare it to. For example:
        *                             "Username='Admin'" or "Salary=100".
        *   RETURNS     :
        *       bool
        */

        public static bool RowExists(string TableName, string[] Conditions = null)
        {
            bool exists = false;
            int num = 0;
            string cmdString = "SELECT COUNT(*) FROM " + TableName;
            if (Conditions != null)
            {
                cmdString += " WHERE ";
                int count = 1;
                foreach (string con in Conditions)
                {
                    cmdString += con;
                    if (count < Conditions.Length)
                    {
                        cmdString += " AND ";
                    }
                    count++;
                }
            }

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            dbConnection.Open();
            num = (int)cmd.ExecuteScalar();
            if (num > 0)
            {
                exists = true;
            }
            dbConnection.Close();
            return exists;
        }

        /*
        *   FUNCTION    : NumRowsExist()
        *   DESCRIPTION : Accesses the database and sees how many rows exist based on set conditions.
        *   PARAMETERS  :
        *       string TableName    : The table to access.
        *       string[] Conditions : The conditions to check for. Each condition must be the
        *                             row name and what to compare it to. For example:
        *                             "Username='Admin'" or "Salary=100".
        *   RETURNS     :
        *       bool
        */

        public static int NumRowsExist(string TableName, string[] Conditions = null)
        {
            int num = 0;
            string cmdString = "SELECT COUNT(*) FROM " + TableName;
            if (Conditions != null)
            {
                cmdString += " WHERE ";
                int count = 1;
                foreach (string con in Conditions)
                {
                    cmdString += con;
                    if (count < Conditions.Length)
                    {
                        cmdString += " AND ";
                    }
                    count++;
                }
            }

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            dbConnection.Open();
            num = (int)cmd.ExecuteScalar();
            dbConnection.Close();

            return num;
        }

        /*
        *   FUNCTION    : GetRow()
        *   DESCRIPTION : Accesses the database and gets a row based on the conditions.
        *   PARAMETERS  :
        *       int TableType       : The type of table row to return.
        *       string[] Conditions : The conditions to check for. Each condition must be the
        *                             row name and what to compare it to. For example:
        *                             "Username='Admin'" or "Salary=100".
        *   RETURNS     :
        *       DataRow
        */

        public static DataRow GetRow(int TableType, string[] Conditions)
        {
            DataTable TempTable = null;
            string cmdString = "SELECT * FROM ";

            if (TableType == SYSTEM_USER_TABLE)
            {
                cmdString += "SystemUser";
                SetUpTable(ref TempTable, SYSTEM_USER_TABLE);
            }
            else if (TableType == EMPLOYEE_TABLE)
            {
                cmdString += "Employee";
                SetUpTable(ref TempTable, EMPLOYEE_TABLE);
            }

            if (Conditions != null)
            {
                cmdString += " WHERE ";
                int count = 1;
                foreach (string con in Conditions)
                {
                    cmdString += con;
                    if (count < Conditions.Length)
                    {
                        cmdString += " AND ";
                    }
                    count++;
                }
            }

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConnection.Open();
            da.Fill(TempTable);
            dbConnection.Close();
            da.Dispose();
            return TempTable.Rows[0];
        }

        /*
        *   FUNCTION    : GetColumnInRow()
        *   DESCRIPTION : Accesses the database and gets a column in a row based on the conditions.
        *   PARAMETERS  :
        *       int TableType       : The type of table row to return. (USE: SQL_Connection.[TABLE_TYPE])
        *       int ColumnType      : The column to return. (USE: SQL_Connection.[COLUMN_TYPE])
        *       string[] Conditions : The conditions to check for. Each condition must be the
        *                             row name and what to compare it to. For example:
        *                             "Username='Admin'" or "Salary=100".
        *   RETURNS     :
        *       string
        */

        public static string GetColumnInRow(int TableType, int ColumnType, string[] Conditions)
        {
            DataTable TempTable = null;
            string cmdString = "SELECT * FROM ";

            if (TableType == SYSTEM_USER_TABLE)
            {
                cmdString += "SystemUser";
                SetUpTable(ref TempTable, SYSTEM_USER_TABLE);
            }
            else if (TableType == EMPLOYEE_TABLE)
            {
                cmdString += "Employee";
                SetUpTable(ref TempTable, EMPLOYEE_TABLE); ;
            }

            if (Conditions != null)
            {
                cmdString += " WHERE ";
                int count = 1;
                foreach (string con in Conditions)
                {
                    cmdString += con;
                    if (count < Conditions.Length)
                    {
                        cmdString += " AND ";
                    }
                    count++;
                }
            }

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConnection.Open();
            da.Fill(TempTable);
            dbConnection.Close();
            da.Dispose();
            return TempTable.Rows[0][ColumnType - 1].ToString();
        }

        /*
        *   FUNCTION    : GetColumnSum()
        *   DESCRIPTION : Accesses the database and gets a column in a row based on the conditions.
        *   PARAMETERS  :
        *       string TableName    : The table to access.
        *       string ColumnName   : The column to get the sum of.
        *   RETURNS     :
        *       float
        */

        public static float GetColumnSum(string TableName, string ColumnName, string[] conditions)
        {
            string cmdString = "SELECT SUM(" + ColumnName + ") FROM " + TableName;

            if (conditions != null)
            {
                cmdString += " WHERE ";
                int count = 1;
                foreach (string con in conditions)
                {
                    cmdString += con;
                    if (count < conditions.Length)
                    {
                        cmdString += " AND ";
                    }
                    count++;
                }
            }
            float total = 0;

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            dbConnection.Open();
            total = (float)cmd.ExecuteScalar();
            return total;
        }

        public static float GetColumnCount(string TableName, string ColumnName, string[] conditions)
        {
            string cmdString = "SELECT COUNT(" + ColumnName + ") FROM " + TableName;

            if (conditions != null)
            {
                cmdString += " WHERE ";
                int count = 1;
                foreach (string con in conditions)
                {
                    cmdString += con;
                    if (count < conditions.Length)
                    {
                        cmdString += " AND ";
                    }
                    count++;
                }
            }
            float total = 0;

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            dbConnection.Open();
            total = (float)cmd.ExecuteScalar();
            return total;
        }

        public static int GetNumRows(string TableName)
        {
            string cmdString = "SELECT COUNT(*) FROM " + TableName;

            int total = 0;

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            dbConnection.Open();
            total = (int)cmd.ExecuteScalar();
            return total;
        }

        /*
        *   FUNCTION    : IsAdmin()
        *   DESCRIPTION : Accesses the database checks if a user is an admin.
        *   PARAMETERS  :
        *       string username : The username to use.
        *       string password : The password to use.
        *   RETURNS     :
        *       bool
        */

        public static bool IsAdmin(string username, string password)
        {
            bool isadmin = false;
            string cmdString = "SELECT COUNT(*) FROM SystemUser WHERE UserName='" + username + "' AND Password='" + password + "' AND IsAdmin=1";

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            dbConnection.Open();
            int num = (int)cmd.ExecuteScalar();
            if (num > 0)
            {
                isadmin = true;
            }
            dbConnection.Close();

            return isadmin;
        }

        /*
        *   FUNCTION    : GetTable()
        *   DESCRIPTION : Accesses the database gets table values based on ranges.
        *   PARAMETERS  :
        *       int TableType   : The table to access;
        *       int UpperRange  : The top side of the limit statement.
        *       int LowerRange  : The bottom side of the limit statement.
        *   RETURNS     :
        *       DataTable
        */

        public static DataTable GetTable(int TableType, int UpperRange = 0, int LowerRange = 0)
        {
            DataTable TempTable = null;
            string cmdString = "SELECT * FROM ";

            if (TableType == SYSTEM_USER_TABLE)
            {
                cmdString += "SystemUser ";
                SetUpTable(ref TempTable, SYSTEM_USER_TABLE);
            }
            else if (TableType == EMPLOYEE_TABLE)
            {
                cmdString += "Employee ";
                SetUpTable(ref TempTable, EMPLOYEE_TABLE);
            }
            cmdString += " ORDER BY LastName ";
            cmdString += "OFFSET " + LowerRange.ToString() + " ROWS ";
            cmdString += "FETCH NEXT " + UpperRange.ToString() + "ROWS ONLY";
            

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConnection.Open();
            da.Fill(TempTable);
            dbConnection.Close();
            da.Dispose();

            return TempTable;
        }

        /*
        *   FUNCTION    : GetTable()
        *   DESCRIPTION : Accesses the database gets table values based on conditions.
        *   PARAMETERS  :
        *       int TableType        : The table to access;
        *       string[] Conditions : The conditions of returned rows.
        *   RETURNS     :
        *       DataTable
        */

        public static DataTable GetTable(int TableType, string[] Conditions = null)
        {
            DataTable TempTable = null;
            string cmdString = "SELECT * FROM ";

            if (TableType == SYSTEM_USER_TABLE)
            {
                cmdString += "SystemUser ";
                SetUpTable(ref TempTable, SYSTEM_USER_TABLE);
            }
            else if (TableType == EMPLOYEE_TABLE)
            {
                cmdString += "Employee ";
                SetUpTable(ref TempTable, EMPLOYEE_TABLE);
            }

            if (Conditions != null)
            {
                cmdString += " WHERE ";
                int count = 1;
                foreach (string con in Conditions)
                {
                    cmdString += con;
                    if (count < Conditions.Length)
                    {
                        cmdString += " AND ";
                    }
                    count++;
                }
            }

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConnection.Open();
            da.Fill(TempTable);
            dbConnection.Close();
            da.Dispose();

            return TempTable;
        }

        /*
        *   FUNCTION    : SearchTable()
        *   DESCRIPTION : Accesses the database gets table values based on query.
        *   PARAMETERS  :
        *       int TableType   : The table to access;
        *       string query    : The query to check rows against.
        *   RETURNS     :
        *       DataTable
        */
        public static DataTable SearchTable(int TableType, string query)
        {
            DataTable RtnTable = null;

            string cmdString = "SELECT * FROM ";

            if (TableType == SYSTEM_USER_TABLE)
            {
                cmdString += "SystemUser ";
                SetUpTable(ref RtnTable, TableType);
            }
            else if (TableType == EMPLOYEE_TABLE)
            {
                cmdString += "Employee ";
                SetUpTable(ref RtnTable, TableType);
            }

            cmdString += "WHERE ";

            int tempNum = 0;
            if (int.TryParse(query, out tempNum))
            {
                cmdString += "SocialInsuranceNumber=" + query.ToLower();
            }
            else
            {
                cmdString += "LastName LIKE '%" + query.ToLower() + "%' OR ";
                cmdString += "FirstName LIKE '%" + query.ToLower() + "%'";
            }

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = cmdString;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConnection.Open();
            da.Fill(RtnTable);
            dbConnection.Close();
            da.Dispose();

            return RtnTable;
        }

        /*
        *   FUNCTION    : InsertUser()
        *   DESCRIPTION : Inserts a user into the user table.
        *   PARAMETERS  :
        *       int CompanyID       : Int value of the company.
        *       string LastName     : User's last name.
        *       string FirstName    : User's first name.
        *       bool IsAdmin        : Toggle for user being admin.
        *       string UserName     : Username for user.
        *       string EncPassword  : Encrypted password for user.
        */
        public static void InsertUser(int CompanyID, string LastName, string FirstName, bool IsAdmin, string UserName, string EncPassword)
        {
            string CmdString = "INSERT INTO SystemUser VALUES (" + CompanyID + ", '" + LastName + "', '" + FirstName + "', ";
            if (IsAdmin)
            {
                CmdString += "1";
            }
            else
            {
                CmdString += "0";
            }
            CmdString += ", '" + UserName + "', '" + EncPassword + "')";

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = CmdString;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
        }

        /*
        *   FUNCTION    : InsertFullTimeEmployee()
        *   DESCRIPTION : Inserts a employee into the employee table.
        *   PARAMETERS  :
        *       int CompanyID               : Int value of the company.
        *       string LastName             : Employee's last name.
        *       string FirstName            : Employee's first name.
        *       int SIN                     : Employees social insurance number.
        *       DateTime DateOfBirth        : Employee's date of birth.
        *       string ReasonForLeaving     : Employee's reason for leaving. Can be blank.
        *       DateTime DateOfHire         : Date employee was hired.
        *       DateTime DateOfTermination  : Date employee was fired. Can be blank.
        *       bool RecordComplete         : Specifies if this employee's record is complete.
        *       float Salary                : Salary of the employee.
        *       int Active                  : Value for active state.
        */
        public static void InsertFullTimeEmployee(int CompanyID, string LastName, string FirstName, int SIN, DateTime DateOfBirth, string ReasonForLeaving, DateTime DateOfHire, DateTime DateOfTermination, bool RecordComplete, float Salary, int Active)
        {
            string CmdString = "INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, ReasonForLeaving, DateOfHire, DateOfTermination, RecordComplete, Salary, Active) VALUES (" +
                CompanyID + ", '" +
                "FullTime" + "', '" +
                LastName.Replace("'", "''") + "', '" +
                FirstName.Replace("'", "''") + "', " +
                SIN.ToString() + ", '" +
                DateOfBirth + "', '" +
                ReasonForLeaving + "', '" +
                DateOfHire + "', '" +
                DateOfTermination + "', ";

            if (RecordComplete)
            {
                CmdString += "1";
            }
            else
            {
                CmdString += "0";
            }
            CmdString += ", " + 
                Salary.ToString() + ", " + 
                Active + ")";

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = CmdString;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
        }

        /*
        *   FUNCTION    : InsertPartTimeEmployee()
        *   DESCRIPTION : Inserts a employee into the employee table.
        *   PARAMETERS  :
        *       int CompanyID               : Int value of the company.
        *       string LastName             : Employee's last name.
        *       string FirstName            : Employee's first name.
        *       int SIN                     : Employees social insurance number.
        *       DateTime DateOfBirth        : Employee's date of birth.
        *       string ReasonForLeaving     : Employee's reason for leaving. Can be blank.
        *       DateTime DateOfHire         : Date employee was hired.
        *       DateTime DateOfTermination  : Date employee was fired. Can be blank.
        *       bool RecordComplete         : Specifies if this employee's record is complete.
        *       float HourlyRate            : Hourly pay rate of the employee.
        *       int Active                  : Value for active state.
        */
        public static void InsertPartTimeEmployee(int CompanyID, string LastName, string FirstName, int SIN, DateTime DateOfBirth, string ReasonForLeaving, DateTime DateOfHire, DateTime DateOfTermination, bool RecordComplete, float HourlyRate, int Active)
        {
            string CmdString = "INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, ReasonForLeaving, DateOfHire, DateOfTermination, RecordComplete, HourlyRate, Active) VALUES (" +
                CompanyID + ", '" +
                "PartTime" + "', '" +
                LastName.Replace("'", "''") + "', '" +
                FirstName.Replace("'", "''") + "', " +
                SIN.ToString() + ", '" +
                DateOfBirth + "', '" +
                ReasonForLeaving + "', '" +
                DateOfHire + "', '" +
                DateOfTermination + "', ";

            if (RecordComplete)
            {
                CmdString += "1";
            }
            else
            {
                CmdString += "0";
            }
            CmdString += ", " +
                HourlyRate.ToString() + ", " +
                Active + ")";

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = CmdString;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
        }

        /*
        *   FUNCTION    : InsertSeasonalEmployee()
        *   DESCRIPTION : Inserts a employee into the employee table.
        *   PARAMETERS  :
        *       int CompanyID               : Int value of the company.
        *       string LastName             : Employee's last name.
        *       string FirstName            : Employee's first name.
        *       int SIN                     : Employees social insurance number.
        *       DateTime DateOfBirth        : Employee's date of birth.
        *       string ReasonForLeaving     : Employee's reason for leaving. Can be blank.
        *       DateTime DateOfHire         : Date employee was hired.
        *       DateTime DateOfTermination  : Date employee was fired. Can be blank.
        *       bool RecordComplete         : Specifies if this employee's record is complete.
        *       float PiecePay              : Pay for each piece made for the employee.
        *       int Active                  : Value for active state.
        */
        public static void InsertSeasonalEmployee(int CompanyID, string LastName, string FirstName, int SIN, DateTime DateOfBirth, string ReasonForLeaving, DateTime DateOfHire, DateTime DateOfTermination, bool RecordComplete, float PiecePay, int Active)
        {
            string CmdString = "INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, ReasonForLeaving, DateOfHire, DateOfTermination, RecordComplete, PiecePay, Active) VALUES (" +
                CompanyID + ", '" +
                "Seasonal" + "', '" +
                LastName.Replace("'", "''") + "', '" +
                FirstName.Replace("'", "''") + "', " +
                SIN.ToString() + ", '" +
                DateOfBirth + "', '" +
                ReasonForLeaving + "', '" +
                DateOfHire + "', '" +
                DateOfTermination + "', ";

            if (RecordComplete)
            {
                CmdString += "1";
            }
            else
            {
                CmdString += "0";
            }
            CmdString += ", " +
                PiecePay.ToString() + ", " +
                Active + ")";

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = CmdString;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
        }

        /*
        *   FUNCTION    : InsertContractEmployee()
        *   DESCRIPTION : Inserts a employee into the employee table.
        *   PARAMETERS  :
        *       int CompanyID               : Int value of the company.
        *       string LastName             : Employee's last name.
        *       string FirstName            : Employee's first name.
        *       int SIN                     : Employees social insurance number.
        *       DateTime DateOfBirth        : Employee's date of birth.
        *       string ReasonForLeaving     : Employee's reason for leaving. Can be blank.
        *       DateTime DateOfHire         : Date employee was hired.
        *       DateTime DateOfTermination  : Date employee was fired. Can be blank.
        *       bool RecordComplete         : Specifies if this employee's record is complete.
        *       DateTime ContractStartDate  : Date of the contract start.
        *       DateTime ContractEndDate    : Date of the cotnract end.
        *       float FixedContractRate     : Fixed contract rate of the employee.
        *       int Active                  : Value for active state.
        */
        public static void InsertContractEmployee(int CompanyID, string LastName, string FirstName, int SIN, DateTime DateOfBirth, string ReasonForLeaving, DateTime DateOfHire, DateTime DateOfTermination, bool RecordComplete, DateTime ContractStartDate, DateTime ContractEndDate, float FixedContractRate, int Active)
        {
            string CmdString = "INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, ReasonForLeaving, DateOfHire, DateOfTermination, RecordComplete, ContractStartDate, ContractEndDate, FixedContractRate, Active) VALUES (" +
                CompanyID + ", '" +
                "Contract" + "', '" +
                LastName.Replace("'", "''") + "', '" +
                FirstName.Replace("'", "''") + "', " +
                SIN.ToString() + ", '" +
                DateOfBirth + "', '" +
                ReasonForLeaving + "', '" +
                DateOfHire + "', '" +
                DateOfTermination + "', ";

            if (RecordComplete)
            {
                CmdString += "1";
            }
            else
            {
                CmdString += "0";
            }
            CmdString += ", '" +
                ContractStartDate + "', '" +
                ContractEndDate + "', " +
                FixedContractRate + ", " +
                Active + ")";

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = CmdString;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
        }

        public static void InsertCompany(string CompanyName)
        {
            string CmdString = "INSERT INTO Company VALUES('" + CompanyName.Replace("'", "''") + "')";

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = CmdString;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
        }

        /*
        *   FUNCTION    : UpdateEmployee()
        *   DESCRIPTION : Updates an employee in the employee table.
        *   PARAMETERS  :
        *       int EmployeeID      : ID of employee to update.
        *       int ColumnType      : The column to update.
        *       string NewValue     : The value to insert.
        */
        public static void UpdateEmployee(int EmployeeID, int ColumnType, string NewValue)
        {
            string UpdateString = "UPDATE Employee SET " + GetColumnName(ColumnType) + "=";

            float tempInt = 0;
            if (float.TryParse(NewValue, out tempInt))
            {
                UpdateString += NewValue;
            }
            else
            {
                UpdateString += "'" + NewValue + "'";
            }
            UpdateString += " WHERE EmployeeID=" + EmployeeID;

            DataRow OldRow = GetRow(EMPLOYEE_TABLE, new string[1] { "EmployeeID=" + EmployeeID });
            string CurrentUser = GetColumnInRow(SYSTEM_USER_TABLE, 5, new string[1] { "UserName='" + LoggedInUser + "'" });
            int UserID = 0;
            int.TryParse(CurrentUser, out UserID);

            UpdateAuditTable(EmployeeID, UserID, OldRow[ColumnType - 1].ToString(), NewValue, "Row Updated");

            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = UpdateString;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
        }

        /*
        *   FUNCTION    : UpdateAuditTable()
        *   DESCRIPTION : Adds a new addition to the audit table.
        *   PARAMETERS  :
        *       int EmployeeID       : The id of the employee being updated.
        *       int UserID           : The id of the user updating the employee.
        *       string PreviousValue : The value previously in the column updated.
        *       string NewValue      : The new value in the column.
        *       string Message       : A message for the update.
        */
        public static void UpdateAuditTable(int EmployeeID, int UserID, string PreviousValue, string NewValue, string Message)
        {
            string CmdString = "INSERT INTO Audit VALUES (" + EmployeeID + ", " + UserID + ", '" + DateTime.Now + "', ";
            float temp = 0;
            DateTime tempDateTime = new DateTime();
            if (DateTime.TryParse(NewValue, out tempDateTime))
            {
                PreviousValue = tempDateTime.ToShortDateString();
            }
            if (float.TryParse(NewValue, out temp))
            {
                CmdString += PreviousValue + ", '";
            }
            else
            {
                CmdString += "'" + PreviousValue.Replace("'", "''") + "', '";
            }
            
            CmdString += NewValue.Replace("'", "''") + "', '" + Message.Replace("'", "''") + "')";

            if (PreviousValue.ToLower() != NewValue.ToLower())
            {
                SqlConnection dbConnection = new SqlConnection(ConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = CmdString;
                dbConnection.Open();
                cmd.ExecuteNonQuery();
                dbConnection.Close();
            }
            
        }

        public static int GetCompanyID(string CompanyName)
        {
            string CmdString = "SELECT * FROM Company WHERE CompanyName='" + CompanyName + "'";
            int rtnInt = -1;

            DataTable TempTable = null;
            SetUpTable(ref TempTable, COMPANY_TABLE);
            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = CmdString;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConnection.Open();
            da.Fill(TempTable);
            dbConnection.Close();
            da.Dispose();
            if (TempTable.Rows.Count > 0)
            {
                int.TryParse(TempTable.Rows[0][0].ToString(), out rtnInt);
            }
            return rtnInt;
        }

        public static string GetCompanyName(int CompanyID)
        {
            string CmdString = "SELECT * FROM Company WHERE CompanyID=" + CompanyID;

            DataTable TempTable = null;
            SetUpTable(ref TempTable, COMPANY_TABLE);
            SqlConnection dbConnection = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = CmdString;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConnection.Open();
            da.Fill(TempTable);
            dbConnection.Close();
            da.Dispose();
            return TempTable.Rows[0][1].ToString();
        }

        private static bool RowsEqual(DataRow r1, DataRow r2)
        {
            bool equal = true;

            for (int i = 0; i < System.Math.Min(r1.Table.Columns.Count, r1.Table.Columns.Count) - 1; i++)
            {
                if (r1[i].ToString() != r2[i].ToString())
                {
                    equal = false;
                }
            }

            return equal;
        }

        private static void SetUpTable(ref DataTable tbl, int TableType)
        {
            if (tbl == null)
            {
                tbl = new DataTable();
            }
            if (TableType == EMPLOYEE_TABLE)
            {
                tbl.Columns.AddRange(new DataColumn[17]{
                new DataColumn("EmployedWithCompanyID"),
                new DataColumn("EmployeeType"),
                new DataColumn("LastName"),
                new DataColumn("FirstName"),
                new DataColumn("SocialInsuranceNumber"),
                new DataColumn("DateOfBirth"),
                new DataColumn("ReasonForLeaving"),
                new DataColumn("DateOfHire"),
                new DataColumn("DateOfTermination"),
                new DataColumn("RecordComplete"),
                new DataColumn("Salary"),
                new DataColumn("HourlyRate"),
                new DataColumn("ContractStartDate"),
                new DataColumn("ContractEndDate"),
                new DataColumn("FixedContractRate"),
                new DataColumn("PiecePay"),
                new DataColumn("Active")});
            }
            else if (TableType == SYSTEM_USER_TABLE)
            {
                tbl.Columns.AddRange(new DataColumn[6]{
                new DataColumn("CompanyID"),
                new DataColumn("LastName"),
                new DataColumn("FirstName"),
                new DataColumn("IsAdmin"),
                new DataColumn("UserName"),
                new DataColumn("Password")});
            }
            else if (TableType == COMPANY_TABLE)
            {
                tbl.Columns.AddRange(new DataColumn[2]{
                new DataColumn("CompanyID"),
                new DataColumn("CompanyName") });
            }
        }

        public static string GetColumnName(int ColumnType)
        {
            string rtnString = "";
            switch (ColumnType)
            {
                case EMPLOYED_WITH_COMPANY_ID:
                    rtnString = "EmployedWithCompanyID";
                    break;
                case EMPLOYEE_TYPE:
                    rtnString = "EmployeeType";
                    break;
                case LAST_NAME:
                    rtnString = "LastName";
                    break;
                case FIRST_NAME:
                    rtnString = "FirstName";
                    break;
                case SIN:
                    rtnString = "SocialInsuranceNumber";
                    break;
                case DATE_OF_BIRTH:
                    rtnString = "DateOfBirth";
                    break;
                case REASON_FOR_LEAVING:
                    rtnString = "ReasonForLeaving";
                    break;
                case DATE_OF_HIRE:
                    rtnString = "DateOfHire";
                    break;
                case DATE_OF_TERMINATION:
                    rtnString = "DateOfTermination";
                    break;
                case RECORD_COMPLETE:
                    rtnString = "RecordComplete";
                    break;
                case SALARY:
                    rtnString = "Salary";
                    break;
                case HOURLY_RATE:
                    rtnString = "HourlyRate";
                    break;
                case CONTRACT_START_DATE:
                    rtnString = "ContractStartDate";
                    break;
                case CONTRACT_END_DATE:
                    rtnString = "ContractEndDate";
                    break;
                case FIXED_CONTRACT_RATE:
                    rtnString = "FixedContractRate";
                    break;
                case PIECE_PAY:
                    rtnString = "PiecePay";
                    break;
                case ACTIVE:
                    rtnString = "Active";
                    break;
            }
            return rtnString;
        }
    }
}