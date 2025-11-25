using ClassLibrary.model;
using ClassLibrary.model.OcopModel;
using ClassLibrary.model.permission;
using ClassLibrary.model.productModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.connectdb
{
    public class DataContextProduct: DbContext
    {
        public DataContextProduct(DbContextOptions<DataContextProduct> options) : base(options) { }
        //public DbSet<TableDatabase> Tablegen { get; set; }
        public DbSet<Categorys> Category { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<ProductImages> ProductImage { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<EmployePermissions>().HasKey(i => new { i.role_id, i.employer_id });
        }
    }
}
