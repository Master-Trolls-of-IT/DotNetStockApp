namespace DotNetStockApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdersDb")]
    public partial class OrdersDb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrdersDb()
        {
            OrderProductDBs = new HashSet<OrderProductDB>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OrderId { get; set; }

        [StringLength(50)]
        public string Customer { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeliveryDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProductDB> OrderProductDBs { get; set; }
    }
}
