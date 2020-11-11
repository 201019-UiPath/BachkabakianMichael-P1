using Microsoft.EntityFrameworkCore;
using JCDB.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace JCDB
{
    public class JCContext : DbContext
    {
        public JCContext()
        {

        }

        public JCContext(DbContextOptions<JCContext> options):base(options)
        {

        }

        /// <summary>
        /// Making all the Table DbSets
        /// </summary>
        /// <value></value>
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<Manager> Managers { get; set; }


        /// <summary>
        /// Used The OnConfiguring DbContext Options Builder to Establish a Connection To The Database Through The Connection String in my 'appsetting.Json'
        /// </summary>
        /// <param name="optionsBuilder"></param>

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!(optionsBuilder.IsConfigured))
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("JCDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        /// <summary>
        /// Used The OnModelCreating Model Builder To Specify the Foreign Keys in my Associative Entities for EFCore
        /// </summary>
        /// <param name="modelBuilder"></param>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartLine>()
            .HasKey(cl => new { cl.CartId, cl.ProductId });

            modelBuilder.Entity<Inventory>()
            .HasKey(inv => new { inv.LocationId, inv.ProductId });

            modelBuilder.Entity<OrderLine>()
            .HasKey(ol => new { ol.OrderId, ol.ProductId });
        }
    }
}