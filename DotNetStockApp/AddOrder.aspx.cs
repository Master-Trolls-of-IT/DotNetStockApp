using Microsoft.Ajax.Utilities;
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
    public partial class AddOrder : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!checkUser(User.Identity.Name))
            {
                Response.Redirect("Unauthorized.aspx");
            }
            //Check if the page is loaded for the first time
            if (!IsPostBack)
            {
                //Fill the Drop down list with all the products
                using (var context = new DbModel())
                {
                    var products = context.ProductsDBs.ToList();
                    foreach (var product in products)
                    {
                        DropDownList1.Items.Add(new ListItem(product.Name.ToString(), product.SeriesNumber.ToString()));
                    }
                    DropDownList1.DataBind();
                }
            }
           

        }
        
        protected void ValidateProductButton_Click(object sender, EventArgs e)
        {

            //Get the quantity in the ProductQuantity textbox
            var quantity = int.Parse(ProductQuantity.Text);
            //Add the product and the quantity to the gridview named productsgrid
            using (var context = new DbModel())
            {
                var products = context.ProductsDBs.ToList();
                // Get the selected product
                string selectedProduct = DropDownList1.SelectedValue;
                // Get the product with the selected series number
                var product = products.Where(x => x.SeriesNumber.ToString() == selectedProduct).FirstOrDefault();
                //Add a new row to the existing data in the repeater
                

                DataTable dataTable;
                if (Session["GridViewData"] != null)
                {
                    dataTable = (DataTable)Session["GridViewData"];
                }
                else
                {
                    dataTable = new DataTable();
                    dataTable.Columns.Add("Name");
                    dataTable.Columns.Add("Quantity");
                    dataTable.Columns.Add("SeriesNumber");
                }
                /*
                foreach (GridViewRow row in productsGridView.Rows)
                {
                    Label nameLabel = (Label)row.FindControl("Name");
                    Label quantityLabel = (Label)row.FindControl("Quantity");

                    if (nameLabel != null && quantityLabel != null)
                    {
                        string name = nameLabel.Text;
                        int existingQuantity = int.Parse(quantityLabel.Text);
                        dataTable.Rows.Add(name, existingQuantity);
                    }
                }*/
               

                dataTable.Rows.Add(product.Name, quantity,product.SeriesNumber);
                Session["GridViewData"] = dataTable;
                productsGridView.DataSource = dataTable;
                productsGridView.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //THis is the event handler for the submit button
            //Get the customer name
            var customerName = Customer.Text;
            //Get the Delivery Date
            var deliveryDate = DeliveryDate.Text;
            //Get the Products in the order
            DataTable products = (DataTable)Session["GridViewData"];


            //Create a new order
            using (var context = new DbModel())
            {
                var order = new OrdersDb();
                order.Customer = customerName;
                order.DeliveryDate = DateTime.Parse(deliveryDate);
                //order.Products = products;
                context.OrdersDbs.Add(order);
                context.SaveChanges();
                //Get the order id
                var orderId = order.OrderId;
                //Add products to the OrderProductDB table
                //Go through each product in the products list

                foreach (DataRow row in products.Rows)
                {
                    var orderProduct = new OrderProductDB();
                    orderProduct.OrderId = orderId;
                    orderProduct.SeriesNumber = int.Parse((string)row["SeriesNumber"]);
                    orderProduct.Quantity = int.Parse((string)row["Quantity"]);
                    context.OrderProductDBs.Add(orderProduct);
                    context.SaveChanges();
                }
            }
            Response.Redirect("CommandManagement.aspx");



        }
        protected void DeleteProductButton_Click(object sender, EventArgs ea)
        {
            throw new NotImplementedException();
        }
        protected void productsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteProduct")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());

                DataTable dataTable = (DataTable)Session["GridViewData"];
                if (dataTable != null && rowIndex >= 0 && rowIndex < dataTable.Rows.Count)
                {
                    dataTable.Rows.RemoveAt(rowIndex);
                    Session["GridViewData"] = dataTable;

                    productsGridView.DataSource = dataTable;
                    productsGridView.DataBind();
                }
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
    }

    internal class YourDataType
    {
        public string Name { get; internal set; }
        public int Quantity { get; internal set; }
        public string SeriesNumber { get; internal set; }
    }

    
}