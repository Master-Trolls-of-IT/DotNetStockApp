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
                    var products = context.ProductsDBs.ToList();
                    int count = 0;
                    foreach (var product in products)
                    {
                        Series series = new Series(product.Name + product.SeriesNumber);
                        series.AxisLabel = "Produits";

                        series.Points.Add((double)product.Quantity);
                        // Add value to point
                        series.Label = product.Quantity.ToString();
                        Chart1.Series.Add(series);
                    }
                    Chart1.Legends.Add(new Legend("Legend1"));
                    Chart1.Legends["Legend1"].Docking = Docking.Bottom;
                    Chart1.Legends["Legend1"].Alignment = System.Drawing.StringAlignment.Center;
                    Chart1.Legends["Legend1"].BorderColor = Color.Black;
                    Chart1.Legends["Legend1"].BorderWidth = 1;
                    Chart1.Legends["Legend1"].BorderDashStyle = ChartDashStyle.Solid;
                    Chart1.Legends["Legend1"].ShadowColor = Color.Black;
                    Chart1.Legends["Legend1"].ShadowOffset = 1;
                    Chart1.Legends["Legend1"].Font = new Font("Arial", 8.0f, FontStyle.Bold);
                    Chart1.Legends["Legend1"].BackColor = Color.Gray;
                    Chart1.BackColor = Color.DarkGray;
                    Chart1.DataBind();

                  
                }
               

            }
        }
    }
}