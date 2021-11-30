using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShelbyCompany.Data
{
    public class ShelbyCompanyContext : DbContext
    {
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=69.10.49.185,1433;Initial Catalog=ShelbyCompany;User ID=yadz;Password=yadz;");
        }
    }
}
