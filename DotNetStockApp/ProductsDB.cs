namespace DotNetStockApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductsDB")]
    public partial class ProductsDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductsDB()
        {
            OrderProductDBs = new HashSet<OrderProductDB>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public long? Quantity { get; set; }

        public long? Cost { get; set; }

        public long? SellingPrice { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SeriesNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProductDB> OrderProductDBs { get; set; }
    }
}
