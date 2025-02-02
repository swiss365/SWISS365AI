using Microsoft.EntityFrameworkCore;
using SWISS365AI.Domain.Entities;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<License> Licenses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<License>().HasIndex(l => l.LicenseKey).IsUnique();
    }
}