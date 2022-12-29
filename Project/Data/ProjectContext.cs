using Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Project.Areas.Identity.Data;

namespace Project.Data
{
    public class ProjectContext : IdentityDbContext<CustomUser>
    {
        public ProjectContext(DbContextOptions<ProjectContext> option) : base(option)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Cart> Cart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           

           
            modelBuilder.Entity<Klant>().ToTable("Klant");
            modelBuilder.Entity<Product>().ToTable("Product").Property(p => p.Prijs).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Categorie>().ToTable("Categorie");
            modelBuilder.Entity<Cart>().ToTable("Cart");
        }
    }
}