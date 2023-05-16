namespace DotNetStockApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersDB")]
    public partial class UsersDB
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string login { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string rights { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string password { get; set; }
    }
}
