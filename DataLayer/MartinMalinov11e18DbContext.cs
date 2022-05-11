using Microsoft.EntityFrameworkCore;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MartinMalinov11e18DbContext : DbContext
    {
        public MartinMalinov11e18DbContext()
        {

        }

        public MartinMalinov11e18DbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-V6LP4Q1;Database=MartinMalinov11e18Db;Trusted_Connection=True");
            }
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
