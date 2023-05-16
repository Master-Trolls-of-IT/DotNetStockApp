using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStockApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (ValidateUser(Login1.UserName, Login1.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false, "ProductManagement.aspx");
            }
            else
            {

            }
        }
        public bool ValidateUser(string userName, string passWord)
        {
            using (var context = new DbModel())
            {
                var users = context.UsersDBs.ToList();
                foreach (var user in users)
                {
                    if (userName == user.Name && passWord == user.password)
                    {
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}