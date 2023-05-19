using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStockApp
{
    public partial class ProductManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if User is an admin and redirect him if not
            if (!checkAdmin(User.Identity.Name))
            {
                Response.Redirect("Unauthorized.aspx");
            }
            using (var context = new DbModel())
            {
                var products = context.ProductsDBs.ToList();
                DropDownList1.DataSource = products;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataBind();
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

        protected void uploadButton_Click(object sender, EventArgs e)
        {
            //Check that every field is filled
            if (string.IsNullOrEmpty(NameInput.Text) || string.IsNullOrEmpty(QuantityInput.Text) ||
                string.IsNullOrEmpty(CostInput.Text) || string.IsNullOrEmpty(SellingPriceInput.Text) ||
                string.IsNullOrEmpty(SeriesNumberInput.Text) || string.IsNullOrEmpty(ExpirationDateInput.Text) ||
                string.IsNullOrEmpty(PhotoInput.FileName))
            {
                // Show error message
                ErrorLabel.Text = "Please fill all fields";
                return;
            }

            //Check that every field is correctly filled (numbers are numbers, dates are dates)
            if (!int.TryParse(QuantityInput.Text, out int quantity) || !int.TryParse(CostInput.Text, out int cost) ||
                !int.TryParse(SellingPriceInput.Text, out int sellingPrice) ||
                !int.TryParse(SeriesNumberInput.Text, out int seriesNumber))
            {
                // Show error message
                ErrorLabel.Text = "Please number fields correctly (Quantity - Cost - SellingPrice - SeriesNumber)";
                return;
            }

            if (PhotoInput.HasFile)
            {
                ProductsDB newProduct = new ProductsDB()
                {
                    Name = NameInput.Text,
                    Quantity = quantity,
                    Cost = cost,
                    SellingPrice = sellingPrice,
                    SeriesNumber = seriesNumber,
                    ExpirationDate = DateTime.Parse(ExpirationDateInput.Text),
                    Photo = PhotoInput.FileName
                };
                string fileName = PhotoInput.FileName;
                //Store the file inside ~/Images folder
                PhotoInput.SaveAs(Server.MapPath("~/Images/") + fileName);
                using (var context = new DbModel())
                {
                    context.ProductsDBs.Add(newProduct);
                    context.SaveChanges();
                }
                // Reset all fields if upload was successful
                NameInput.Text = "";
                QuantityInput.Text = "";
                CostInput.Text = "";
                SellingPriceInput.Text = "";
                SeriesNumberInput.Text = "";
                ExpirationDateInput.Text = "";
                PhotoInput.Dispose();
                //Refresh the dropdownlist
                using (var context = new DbModel())
                {
                    var products = context.ProductsDBs.ToList();
                    DropDownList1.DataSource = products;
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataBind();
                }

            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            //Delete the selected product
            using (var context = new DbModel())
            {
                var product = context.ProductsDBs.FirstOrDefault(p => p.Name == DropDownList1.SelectedValue);
                if (product != null)
                {
                    //Delete all references to the product in the order products table
                    var orderProducts = context.OrderProductDBs.ToList();
                    foreach (var orderProduct in orderProducts)
                    {
                        if (orderProduct.SeriesNumber == product.SeriesNumber)
                        {
                            context.OrderProductDBs.Remove(orderProduct);
                            //delete the order associated with the order product
                            var orders = context.OrdersDbs.ToList();
                            foreach (var order in orders)
                            {
                                if (order.OrderId == orderProduct.OrderId)
                                {
                                    context.OrdersDbs.Remove(order);
                                }
                            }
                        }
                    }
                    context.ProductsDBs.Remove(product);
                    context.SaveChanges();
                }
                //Refresh the dropdownlist
                var products = context.ProductsDBs.ToList();
                DropDownList1.DataSource = products;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataBind();
            }


        }

    
    }
}