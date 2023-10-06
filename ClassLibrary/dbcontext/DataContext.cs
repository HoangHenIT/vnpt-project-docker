using ClassLibrary.model;
using ClassLibrary.model.permission;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.connectdb
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //public DbSet<TableDatabase> Tablegen { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Employers> Employers { get; set; }
        public DbSet<HistoryLogins> HistoryLogins { get; set; }

        public DbSet<CategoryMenus> CategoryMenu { get; set; }
        public DbSet<RolePermissions> RolePermissions { get; set; }
        public DbSet<EmployePermissions> EmployePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
