using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace DotNetStockApp
{
    public partial class StockLevels : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var context = new  DbModel())
                {
                    /*
                    // Add values to the products DB
                    ProductsDB firstProduct = new ProductsDB
                    {
                        Name = "test",
                        Quantity = 1,
                        Cost = 1,
                        SellingPrice = 1,
                        SeriesNumber = 1,
                        ExpirationDate = DateTime.Now,

                    };
                    
                    context.ProductsDBs.Add(firstProduct);
                    context.SaveChanges();
             */
                    var products = context.ProductsDBs.ToList();
                    foreach (var product in products)
                    {
                        Series series = new Series(product.Name + product.SeriesNumber);
                        


                        series.Label = product.Name + " (series number : " + product.SeriesNumber + " )"; 
                        
                        series.AxisLabel = "Produits";
                      

                        
                        series.Points.Add((double)product.Quantity);
                        Chart1.Series.Add(series);
                    }
                    
                    Chart1.DataBind();

                  
                }
               

            }
        }
    }
}