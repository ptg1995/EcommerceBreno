using EcommerceBreno.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBreno.ProductApi.Context;

public class AppDBContext: DbContext
{

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){}

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Category
        modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);

        modelBuilder.Entity<Category>().Property(c => c.Name)
                         .HasMaxLength(100)
                         .IsRequired();
        modelBuilder.Entity<Category>().HasMany(g => g.Products)
                        .WithOne(c => c.Category)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>()
                        .HasData(
                            new Category
                            { 
                                CategoryId = 1,
                                Name = "Calça Jeans",
                            },
                            new Category
                            {
                                CategoryId = 2,
                                Name = "Bermuda Jeans",
                            }
                         );

        //Product
        modelBuilder.Entity<Product>().HasKey(c => c.Id);

        modelBuilder.Entity<Product>().Property(c => c.Name)
                        .HasMaxLength(100)
                            .IsRequired();
        modelBuilder.Entity<Product>().Property(c => c.Description)
                        .HasMaxLength(255)
                            .IsRequired();
        modelBuilder.Entity<Product>().Property(c => c.ImageUrl)
                        .HasMaxLength(255)
                            .IsRequired();
        modelBuilder.Entity<Product>().Property(c => c.Price)
                        .HasPrecision(12,2);
        modelBuilder.Entity<Product>().Property(c => c.Stock)
                        .HasMaxLength(255)
                            .IsRequired();
       
    }

    internal Category FindAsync(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}
