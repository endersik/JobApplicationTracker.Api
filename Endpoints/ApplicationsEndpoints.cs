using JobApplicationTracker.Api.Data;
using JobApplicationTracker.Api.Dtos;
using JobApplicationTracker.Api.Entities;
using JobApplicationTracker.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Api.Endpoints;

public static class ApplicationsEndpoints
{
    const string GetApplicationEndpointName = "GetApplication";

    public static RouteGroupBuilder MapApplicationsEndpoints(this WebApplication app){
        var group = app.MapGroup("applications")
                        .WithParameterValidation();

        group.MapGet("/", async (ApplicationTrackerContext dbContext) =>
             await  dbContext.Applications
                      .Include(application => application.Title)
                      .Select(application => application.ToApplicationSummaryDto())
                      .AsNoTracking()
                      .ToListAsync());

        group.MapGet("/{id}", async (int id, ApplicationTrackerContext dbContext) => {
            Application? application = await dbContext.Applications.FindAsync(id);

            return application is null ?
                Results.NotFound() : Results.Ok(application.ToApplicationDetailsDto());
            })
            .WithName(GetApplicationEndpointName);

        group.MapPost("/", async (CreateApplicationDto newApplication, ApplicationTrackerContext dbContext) => {
            
            Application application = newApplication.ToEntity();

            dbContext.Applications.Add(application);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetApplicationEndpointName,
                new { id = application.Id },
                application.ToApplicationDetailsDto());
        });

        group.MapPut("/{id}", async (int id, UpdateApplicationDto updatedApplication, ApplicationTrackerContext dbContext) => {
            var existingApplication = await dbContext.Applications.FindAsync(id);

            if(existingApplication is null){
                return Results.NotFound();
            }

            dbContext.Entry(existingApplication)
                     .CurrentValues
                     .SetValues(updatedApplication.ToEntity(id));
            
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, ApplicationTrackerContext dbContext) => {
            
            await   dbContext.Applications
                    .Where(application => application.Id == id)
                    .ExecuteDeleteAsync();
            
            return Results.NoContent();
        }); 

        return group;
    }
}
