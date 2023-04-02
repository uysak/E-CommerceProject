using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ECommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;Database=E-Commerce;UID=root;PWD=123+abc+;Charset=utf8;SslMode=none";
                optionsBuilder.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion);
            }

            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoFirm> CargoFirms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
