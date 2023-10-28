using ClassLibrary.model;
using ClassLibrary.model.OcopModel;
using ClassLibrary.model.permission;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.connectdb
{
    public class DataContextOCOP: DbContext
    {
        public DataContextOCOP(DbContextOptions<DataContextOCOP> options) : base(options) { }
        //public DbSet<TableDatabase> Tablegen { get; set; }
        public DbSet<Nhomsps> Nhomsps { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<EmployePermissions>().HasKey(i => new { i.role_id, i.employer_id });
        }
    }
}
