using Microsoft.EntityFrameworkCore;
using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Shared.Extensions;

namespace practice_tf.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Brand).IsRequired();
        builder.Entity<Product>().Property(p => p.Model).IsRequired();
        builder.Entity<Product>().Property(p => p.SerialNumber).IsRequired();
        builder.Entity<Product>().Property(p => p.Status).IsRequired();
        builder.Entity<Product>().Ignore(p => p.StatusDescription);

        builder.UseSnakeCaseNamingConvention();
    }
}