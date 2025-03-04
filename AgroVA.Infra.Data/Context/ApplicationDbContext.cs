using AgroVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgroVA.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public ApplicationDbContext()
        {
            
        }
        public DbSet<Annotation> Annotations { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Harvest> Harvests { get; set; }
        public DbSet<HuskPrice> HuskPrices { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Promissory> Promissories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
