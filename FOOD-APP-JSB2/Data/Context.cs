using System.Diagnostics;
using FOOD_APP_JSB_2.Models;
using Microsoft.EntityFrameworkCore;

namespace FOOD_APP_JSB_2.Data;

public class Context : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserFeature> UserFeatures { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FOOD-CQRS;Trusted_Connection=True;MultipleActiveResultSets=true")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Instructor>().ToTable("Instructor");
    }
}