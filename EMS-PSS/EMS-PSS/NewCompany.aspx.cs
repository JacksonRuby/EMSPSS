using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS_PSS
{
    public partial class NewCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

        protected void btnSaveAddNew_Click(object sender, EventArgs e)
        {
            SQL_Connection.InsertCompany(txtCompany.Text);
            Response.Redirect("SystemAdmin.aspx");
        }
    }
}