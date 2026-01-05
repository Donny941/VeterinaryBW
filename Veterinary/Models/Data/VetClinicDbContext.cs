using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Veterinary.Models.Data
{
    public class VetClinicDbContext : IdentityDbContext<User>
    {
        public VetClinicDbContext(DbContextOptions<VetClinicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Recovery> Recoveries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Animal configuration
            modelBuilder.Entity<Animal>()
                .HasIndex(a => a.MicrochipNumber)
                .IsUnique();

            modelBuilder.Entity<Animal>()
                .HasMany(a => a.Visits)
                .WithOne(v => v.Animal)
                .HasForeignKey(v => v.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Recovery)
                .WithOne(r => r.Animal)
                .HasForeignKey<Recovery>(r => r.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Product configuration
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(s => s.Product)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Sale configuration
            modelBuilder.Entity<Sale>()
                .HasIndex(s => s.SaleDate);

            modelBuilder.Entity<Sale>()
                .HasIndex(s => s.ClientTaxCode);

            // Recovery configuration
            modelBuilder.Entity<Recovery>()
                .HasIndex(r => r.IsActive);
        }
    }
}
