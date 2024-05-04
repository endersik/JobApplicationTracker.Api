using JobApplicationTracker.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Api.Data;

public class ApplicationTrackerContext(DbContextOptions<ApplicationTrackerContext> options) 
    : DbContext(options)
{
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<Title> Titles => Set<Title>();

    override protected void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Title>().HasData(
            new { Id = 1, Name = "Backend Developer" },
            new { Id = 2, Name = "Frontend Developer" },
            new { Id = 3, Name = "Fullstack Developer" },
            new { Id = 4, Name = "Mobile Developer" }
        );
    }
}
