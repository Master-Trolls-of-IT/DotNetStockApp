using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DotNetStockApp
{
    public partial class Dbmodel2 : DbContext
    {
        public Dbmodel2()
            : base("name=Dbmodel2")
        {
        }

        public virtual DbSet<OrdersDb> OrdersDbs { get; set; }
        public virtual DbSet<ProductsDB> ProductsDBs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UsersDB> UsersDBs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
