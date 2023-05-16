namespace DotNetStockApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderProductDB")]
    public partial class OrderProductDB
    {
        public long? OrderId { get; set; }

        public long? ProductSeriesNumber { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public virtual OrdersDb OrdersDb { get; set; }

        public virtual ProductsDB ProductsDB { get; set; }
    }
}
