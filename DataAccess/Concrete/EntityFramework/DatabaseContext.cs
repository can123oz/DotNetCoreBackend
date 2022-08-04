using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-07T1LR2;Database=EnginOdev;Trusted_Connection=true");
        }
        public DbSet<Color> Color  { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand  { get; set; }
    }
}
