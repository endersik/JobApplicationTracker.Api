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

        group.MapGet("/", (ApplicationTrackerContext dbContext) =>
             dbContext.Applications
                      .Include(application => application.Title)
                      .Select(application => application.ToApplicationSummaryDto())
                      .AsNoTracking());

        group.MapGet("/{id}", (int id, ApplicationTrackerContext dbContext) => {
            Application? application = dbContext.Applications.Find(id);

            return application is null ?
                Results.NotFound() : Results.Ok(application.ToApplicationDetailsDto());
            })
            .WithName(GetApplicationEndpointName);

        group.MapPost("/", (CreateApplicationDto newApplication, ApplicationTrackerContext dbContext) => {
            
            Application application = newApplication.ToEntity();

            dbContext.Applications.Add(application);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(
                GetApplicationEndpointName,
                new { id = application.Id },
                application.ToApplicationDetailsDto());
        });

        group.MapPut("/{id}", (int id, UpdateApplicationDto updatedApplication, ApplicationTrackerContext dbContext) => {
            var existingApplication = dbContext.Applications.Find(id);

            if(existingApplication is null){
                return Results.NotFound();
            }

            dbContext.Entry(existingApplication)
                     .CurrentValues
                     .SetValues(updatedApplication.ToEntity(id));
            
            dbContext.SaveChanges();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id, ApplicationTrackerContext dbContext) => {
            
            dbContext.Applications
                    .Where(application => application.Id == id)
                    .ExecuteDelete();
            
            return Results.NoContent();
        }); 

        return group;
    }
}
