using Microsoft.EntityFrameworkCore;
using practice_tf.API.Inventory.Domain.Model;
using practice_tf.API.Maintenance.Domain.Model;
using practice_tf.API.Shared.Extensions;

namespace practice_tf.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<MaintenanceActivity> MaintenanceActivities { get; set; } = null!;

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

        builder.Entity<Product>()
            .HasOne(p => p.MaintenanceActivity)
            .WithOne(p => p.Product)
            .HasForeignKey<MaintenanceActivity>(p => p.Id);
        
        builder.Entity<MaintenanceActivity>().ToTable("MaintenanceActivities");
        builder.Entity<MaintenanceActivity>().HasKey(p => p.Id);
        builder.Entity<MaintenanceActivity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MaintenanceActivity>().Property(p => p.Summary).IsRequired();
        builder.Entity<MaintenanceActivity>().Property(p => p.Description);
        builder.Entity<MaintenanceActivity>().Property(p => p.ActivityResult).IsRequired();
        builder.Entity<MaintenanceActivity>().Property(p => p.ProductSerialNumber).IsRequired();

       
        builder.UseSnakeCaseNamingConvention();
    }
}