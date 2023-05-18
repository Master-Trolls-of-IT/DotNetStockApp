using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStockApp
{
    public partial class AddOrder : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
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

                myRepeater.ItemDataBound += myRepeater_ItemDataBound;
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
                List<YourDataType> list = new List<YourDataType>();
                if (Session["RepeaterData"] != null)
                {
                    list = (List<YourDataType>)Session["RepeaterData"];
                }
                else
                {
                    list = new List<YourDataType>();
                }
                /*
                List<YourDataType> dataSource = myRepeater.DataSource as List<YourDataType>;
                if (dataSource != null)
                {
                    foreach (YourDataType data in dataSource)
                    {
                        list.Add(data);
                    }
                }*/
               /*
                foreach(RepeaterItem item in myRepeater.Items)
                {
                    //Get Name and Quantity from the repeater
                    var name = (Label)item.FindControl("Name");

                    var quantityLabel = (Label)item.FindControl("Quantity");

                    //Add the existing data to the list
                    if (quantityLabel != null && name != null)
                    {
                        list.Add(new
                        {
                            Name = name.Text,
                            Quantity = quantityLabel.Text,
                        });
                    } else
                    {
                        list.Add(new
                        {
                            Name = "No products added",
                            Quantity = "0",
                        });
                    }

                }*/
                list.Add(new YourDataType
                {
                    Name = product.Name,
                    Quantity = quantity,
                });
                Session["RepeaterData"] = list;
                myRepeater.DataSource = list;
                
                myRepeater.DataBind();
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
            var products = myRepeater.DataSource as List<object>;
            //Create a new order
            using (var context = new DbModel())
            {
                var order = new OrdersDb();
                order.Customer = customerName;
                order.DeliveryDate = DateTime.Parse(deliveryDate);
                //order.Products = products;
                context.OrdersDbs.Add(order);
                context.SaveChanges();
            }

        }
        protected void DeleteProductButton_Click(object sender, EventArgs ea)
        {
            throw new NotImplementedException();
        }
        protected void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataSource = myRepeater.DataSource as List<object>;

                // Access the controls inside the repeater item
                e.Item.DataBind();
                /*var Quantity = e.Item.DataItem as string;

                // Bind the data to the controls
                if (Name != null && Quantity != null)
                {
                    var dataItem = (YourDataType)e.Item.DataItem; // Replace YourDataType with the appropriate data type
                    Name = dataItem.Name;
                    Quantity = dataItem.Quantity.ToString();
                }
                e.Item.DataBind();*/
            }
           
        }
    }

    internal class YourDataType
    {
        public string Name { get; internal set; }
        public int Quantity { get; internal set; }
    }

    internal class DataTable
    {
        public List<object> Rows { get; internal set; }
        public DataTable()
        {
            Rows = new List<object>();
        }
    }
}