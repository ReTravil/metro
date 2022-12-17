using System;
using Metropolis.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product_type> Product_types{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public IEnumerable<Brand> Brand { get; internal set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Market> Markets{ get; set; }
        public DbSet<Vender> Venders { get; set; }
    }
}
