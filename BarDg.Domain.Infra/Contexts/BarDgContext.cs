using BarDg.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarDg.Domain.Infra.Contexts
{
    public class BarDgContext : IdentityDbContext
    {
        private readonly string _connString = "Server=(LocalDB)\\MSSQLLocalDB;Database=BarDg;Trusted_Connection=True;MultipleActiveResultSets=true"; 

        public BarDgContext()
        {
        }

        public BarDgContext(DbContextOptions<BarDgContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connString,
                sqlOptions => sqlOptions.EnableRetryOnFailure(3));
        }
    }
}