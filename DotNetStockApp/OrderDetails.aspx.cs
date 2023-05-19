using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStockApp
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get the OrderID from the URL
            int orderID = Convert.ToInt32(Request.QueryString["OrderID"]);
            //Check if User is an admin and redirect him if not
            if (!checkUser(User.Identity.Name))
            {
                Response.Redirect("Unauthorized.aspx");
            }

            //Show order details in gridview
            using (var context = new DbModel())
            {
                var orderDetails = context.OrdersDbs.Where(x => x.OrderId == orderID).ToList();
                // Get all products
                var test = context.OrderProductDBs.ToList();
                var products = context.OrderProductDBs.Where(x => x.OrderId == orderID).ToList();
                var productsSeriesNumber = products.Select(x => x.SeriesNumber).ToList();
                // Get the number of products in the order
                int numberOfProducts = products.Count();
                // Get the total price of the order

                long totalPrice = 0;
                foreach (var product in productsSeriesNumber)
                {
                    //Get price of the product with series number
                    var price = context.ProductsDBs.Where(x => x.SeriesNumber == product).Select(x => x.Cost)
                        .FirstOrDefault();
                    if (price != null)
                    {
                        totalPrice += (long)price;
                    }
                }
                //Get the selling price of the order
                long sellingPrice = 0;
                foreach (var product in productsSeriesNumber)
                {
                    //Get price of the product with series number
                    var price = context.ProductsDBs.Where(x => x.SeriesNumber == product).Select(x => x.SellingPrice)
                        .FirstOrDefault();
                    if (price != null)
                    {
                        sellingPrice += (long)price;
                    }
                }
                //get the customer 
                var customer = context.OrdersDbs.Where(x => x.OrderId == orderID).Select(x => x.Customer).FirstOrDefault();
                if (customer != null)
                {
                    customer = customer.Replace(" ", string.Empty);
                }
                List<OrderDetail> showDetails = new List<OrderDetail>();
                //Add the number of products, total price, selling price and customer to the gridview as well as the order details
                foreach (var order in orderDetails)
                {
                    //Add the number of products, total price, selling price and customer to the gridview as well as the order details
                    showDetails.Add(new OrderDetail()
                    {
                        DeliveryDate = (DateTime)order.DeliveryDate,
                        NumberOfProducts = numberOfProducts,
                        TotalPrice = totalPrice,
                        SellingPrice = sellingPrice,
                        Customer = customer
                    });
                }


                lblOrderID.Text = orderID.ToString();
                GridView1.DataSource = showDetails;
                GridView1.CssClass = "table";
                GridView1.DataBind();
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

        protected void GoBack_Click(object sender, EventArgs e)
        {
            //Function that goes back to the previous page
            Response.Redirect("CommandManagement.aspx");
        }
    }

    internal class OrderDetail
    {
        public DateTime DeliveryDate { get; set; }
        public int NumberOfProducts { get; set; }
        public long TotalPrice { get; set; }
        public long SellingPrice { get; set; }
        public string Customer { get; set; }
    }
}