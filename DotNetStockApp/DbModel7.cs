using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DotNetStockApp
{
    public partial class DbModel7 : DbContext
    {
        public DbModel7()
            : base("name=DbModel7")
        {
        }

        public virtual DbSet<OrderProductDB> OrderProductDBs { get; set; }
        public virtual DbSet<OrdersDb> OrdersDbs { get; set; }
        public virtual DbSet<ProductsDB> ProductsDBs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UsersDB> UsersDBs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
