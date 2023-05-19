using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStockApp
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Fill table with product that is specified in the URL
            if (!IsPostBack)
            {
                using (var context = new DbModel())
                {
                    var products = context.ProductsDBs.ToList();
                    foreach (var product in products)
                    {
                        if (product.SeriesNumber.ToString() == Request.QueryString["SeriesNumber"])
                        {
                            Name.Text = product.Name;
                            Quantity.Text = product.Quantity.ToString();
                            Cost.Text = product.Cost.ToString();
                            SellingPrice.Text = product.SellingPrice.ToString();
                            SeriesNumber.Text = product.SeriesNumber.ToString();
                            DateTime date = DateTime.Parse(product.ExpirationDate.ToString());
                            string dateString = date.ToString("yyyy-MM-dd");
                            ExpirationDate.Text = dateString;
                            Photo.Text = product.Photo;
                        }
                    }
                }
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            //Delete the product that is specified in the URL and add a new one with the same series number and the new values
            using (var context = new DbModel())
            {
                var products = context.ProductsDBs.ToList();
                foreach (var product in products)
                {
                    if (product.SeriesNumber.ToString() == Request.QueryString["SeriesNumber"])
                    {
                        //Remove All orders that contain the product
                        var orders = context.OrdersDbs.ToList();
                        //Go through the Order Product Table
                        var orderProducts = context.OrderProductDBs.ToList();
                        foreach(var el in orderProducts)
                        {
                            //If the product is in the order
                            if (el.SeriesNumber == product.SeriesNumber)
                            {
                                //Remove the order
                                foreach (var order in orders)
                                {
                                    if (order.OrderId == el.OrderId)
                                    {
                                        context.OrdersDbs.Remove(order);
                                        context.SaveChanges();
                                    }
                                }
                                //Remove the order product
                                context.OrderProductDBs.Remove(el);
                                context.SaveChanges();
                            }
                        }

                        context.ProductsDBs.Remove(product);
                        context.SaveChanges();
                    }
                }

                
                ProductsDB newProduct = new ProductsDB
                {
                    Name = Name.Text,
                    Quantity = int.Parse(Quantity.Text),
                    Cost = int.Parse(Cost.Text),
                    SellingPrice = int.Parse(SellingPrice.Text),
                    SeriesNumber = int.Parse(SeriesNumber.Text),
                    ExpirationDate = DateTime.Parse(ExpirationDate.Text),
                    Photo = Photo.Text
                };
                context.ProductsDBs.Add(newProduct);
                context.SaveChanges();
                // Redirect to the products page
                Response.Redirect("StockEntries.aspx");
            }
        }
    }
}