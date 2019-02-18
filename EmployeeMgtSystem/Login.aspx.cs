using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;

namespace EmployeeMgtSystem
{
    public partial class Login : System.Web.UI.Page
    {
        User model = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities();
            var query = from u in db.Users
                        where u.UserName == txtUser.Text
                        && u.Password == txtPassword.Text
                        select u;
            if (query.Any())
            {
                Session["id"] = model.Id;
                Response.Redirect("EmployeeMaster.aspx");
                lblError.Text = "Login Success";
            }
            else
            {
                lblError.Text = "Login Failed";
            }
        }
    }
}