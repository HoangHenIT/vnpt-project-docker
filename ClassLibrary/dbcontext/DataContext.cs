using ClassLibrary.model;
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


        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
