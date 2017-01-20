using HelloWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWebApi.Contexts
{
    public class NorthwindSlimContext: DbContext
    {
        public NorthwindSlimContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category")
                    .Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product")
                    .Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");
            });
        }
    }
}