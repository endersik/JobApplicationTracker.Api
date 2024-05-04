using JobApplicationTracker.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Api.Data;

public class ApplicationTrackerContext(DbContextOptions<ApplicationTrackerContext> options) 
    : DbContext(options)
{
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<Title> Titles => Set<Title>();
}
