using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStockApp
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if User is an admin and redirect him if not
            if (!checkAdmin(User.Identity.Name))
            {
                Response.Redirect("Unauthorized.aspx");
            }

        }

        public bool checkAdmin(string login)
        {
            using (var context = new DbModel())
            {
                if (string.IsNullOrEmpty(login))
                {
                    return false;
                }

                var users = context.UsersDBs.ToList();
                foreach (var user in users)
                {
                    if (User.Identity.Name == user.Name)
                    {
                        if (user.rights == "admin")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Add the user to the database
            using (var context = new DbModel())
            {
                var user = new UsersDB();
                user.Name = Name.Text;
                user.password = Password.Text;
                user.login = Login.Text;
                //Get the right from the dropdownlist
                user.rights = Rights.SelectedValue;
                context.UsersDBs.Add(user);
                context.SaveChanges();
            }
            Response.Redirect("Default.aspx");
        }
    }
}