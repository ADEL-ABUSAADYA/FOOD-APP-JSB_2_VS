using System.Diagnostics;
using FOOD_APP_JSB_2.Models;
using Microsoft.EntityFrameworkCore;

namespace FOOD_APP_JSB_2.Data;

public class Context : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=ExamSystemDB1;User Id=SA;Password=StrongP@ssw0rd;Encrypt=False;")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Instructor>().ToTable("Instructor");
    }
}