using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace DotNetStockApp
{
    public partial class CommandManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if User is an admin and redirect him if not
                if (!checkUser(User.Identity.Name))
                {
                    Response.Redirect("Unauthorized.aspx");
                }

                using (var context = new DbModel())
                {
                var orders = context.OrdersDbs.ToList();
                
                GridView1.DataSource = orders.OrderBy(x => x.DeliveryDate);
                GridView1.DataBind();
            }
            
            

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Check if the row is a data row.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the ID of the order.
                int orderID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderID"));
                // Add a JavaScript function to the onclick attribute of the row.
                e.Row.Attributes["onclick"] = "location.href='OrderDetails.aspx?OrderID=" + orderID + "';";
                e.Row.Style["cursor"] = "pointer";
                test.Text = orderID.ToString();
            }
        }



        public bool checkUser(string login)
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
                        if (user.rights == "admin" || user.rights == "user")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        private string GetSortDirection(string column)
        {
            // By default, sort ascending.
            string direction = "ASC";

            // Check if the column is already sorted.
            string currentDirection = ViewState["SortDirection"] as string;
            if (currentDirection != null && currentDirection.Equals("ASC") && column.Equals(ViewState["SortExpression"] as string))
            {
                // If the column is already sorted ascending, sort descending.
                direction = "DESC";
            }

            // Save the sort expression and direction in ViewState.
            ViewState["SortExpression"] = column;
            ViewState["SortDirection"] = direction;

            return direction;
        }

        private List<OrdersDb> GetData()
        {
            var data = new List<OrdersDb>();
            using (var context = new DbModel())
            {
                var orders = context.OrdersDbs.ToList();
                data = orders;

            }

            return data;
        }

        protected void GridView1_OnSorting(object sender, GridViewSortEventArgs e)
        {
            var data = GetData();
            var direction = GetSortDirection(e.SortExpression);
            if (direction == "ASC")
            {
                GridView1.DataSource = data.OrderBy(x => x.GetType().GetProperty(e.SortExpression).GetValue(x, null));
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = data.OrderByDescending(x => x.GetType().GetProperty(e.SortExpression).GetValue(x, null));
                GridView1.DataBind();
            }
        }
    }
}