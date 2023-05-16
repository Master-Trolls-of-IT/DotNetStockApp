using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStockApp
{
    public partial class StockEntries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if User is at least a user and redirect him if not
            if (!checkUser(User.Identity.Name))
            {
                Response.Redirect("Unauthorized.aspx");
            }

            using (var context = new DbModel())
            {
                var products = context.ProductsDBs.ToList();
                TableRow firsTableRow = new TableRow();
                TableCell firstCell = new TableCell();
                firstCell.Text = "<b>Name</b>";
                firsTableRow.Cells.Add(firstCell);
                TableCell secondCell = new TableCell();
                secondCell.Text = "<b>Quantity</b>";
                firsTableRow.Cells.Add(secondCell);
                TableCell thirdCell = new TableCell();
                thirdCell.Text = "<b>Cost</>";
                firsTableRow.Cells.Add(thirdCell);
                TableCell fourthCell = new TableCell();
                fourthCell.Text = "<b>Selling Price</>";
                firsTableRow.Cells.Add(fourthCell);
                TableCell fifthCell = new TableCell();
                fifthCell.Text = "<b>Series Number</b>";
                firsTableRow.Cells.Add(fifthCell);
                TableCell sixthCell = new TableCell();
                sixthCell.Text = "<b>Expiration Date</b>";
                firsTableRow.Cells.Add(sixthCell);
                TableCell seventhCell = new TableCell();
                seventhCell.Text = "<b>Photo</b>";
                firsTableRow.Cells.Add(seventhCell);
                TableCell eighthCell = new TableCell();
                eighthCell.Text = "<b>Edit</b>";
                firsTableRow.Cells.Add(eighthCell);
                ProductTable.Rows.Add(firsTableRow);
                
                
                    foreach (var product in products)
                {
                    TableRow row = new TableRow();

                    TableCell cell1 = new TableCell();
                    cell1.Text = product.Name;
                    row.Cells.Add(cell1);
                    TableCell cell2 = new TableCell();
                    cell2.Text = product.Quantity.ToString();
                    row.Cells.Add(cell2);
                    TableCell cell3 = new TableCell();
                    cell3.Text = product.Cost.ToString();
                    row.Cells.Add(cell3);
                    TableCell cell4 = new TableCell();
                    cell4.Text = product.SellingPrice.ToString();
                    row.Cells.Add(cell4);
                    TableCell cell5 = new TableCell();
                    cell5.Text = product.SeriesNumber.ToString();
                    row.Cells.Add(cell5);
                    TableCell cell6 = new TableCell();
                    cell6.Text = product.ExpirationDate.ToString();
                    row.Cells.Add(cell6);
                    TableCell cell7 = new TableCell();
                    cell7.Text = product.Photo;
                    row.Cells.Add(cell7);
                    //Button cell
                    TableCell cell8 = new TableCell();
                    Button button = new Button();
                    button.Text = "Edit";
                    button.ID = product.SeriesNumber.ToString();
                    button.Click += new EventHandler(this.EditButton_Click);
                    cell8.Controls.Add(button);
                    row.Cells.Add(cell8);

                    ProductTable.Rows.Add(row);
                }
                ProductTable.DataBind();
            }


        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            //Show the edit page
            Button button = (Button)sender;
            Response.Redirect("Edit.aspx?SeriesNumber=" + button.ID);
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
}