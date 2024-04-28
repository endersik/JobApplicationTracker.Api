using JobApplicationTracker.Api.Dtos;

namespace JobApplicationTracker.Api.Endpoints;

public static class ApplicationsEndpoints
{
    const string GetApplicationEndpointName = "GetApplication";

    private static readonly List<ApplicationDto> applications = [
        new (
            1,
            "Microsoft", 
            "Cloud Engineer",
            Seniority.Junior,
            new DateOnly(2024, 3, 17),
            true
        ),

        new (
            2,
            "Apple",
            "iOS Developer",
            Seniority.Intern,
            new DateOnly(2024, 5, 12),
            false
        )
    ];

    public static RouteGroupBuilder MapApplicationsEndpoints(this WebApplication app){
        var group = app.MapGroup("applications");

        group.MapGet("/", () => applications);

        group.MapGet("/{id}", (int id) => {
            ApplicationDto? application = applications.Find(application => application.Id == id);

            return application is null ? Results.NotFound() : Results.Ok(application);
            })
            .WithName(GetApplicationEndpointName);

        group.MapPost("/", (CreateApplicationDto newApplication) => {
            ApplicationDto application = new(
                applications.Count + 1,
                newApplication.CompanyName,
                newApplication.Position,
                newApplication.Seniority,
                newApplication.Deadline,
                newApplication.IsApplied
            );

            applications.Add(application);

            return Results.CreatedAtRoute(GetApplicationEndpointName, new { id = application.Id }, application);
        });

        group.MapPut("/{id}", (int id, UpdateApplicationDto updatedApplication) => {
            var index = applications.FindIndex(application => application.Id == id);

            if(index == -1){
                return Results.NotFound();
            }

            applications[index] = new ApplicationDto(
                id,
                updatedApplication.CompanyName,
                updatedApplication.Position,
                updatedApplication.Seniority,
                updatedApplication.Deadline,
                updatedApplication.IsApplied
                );

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) => {
            
            applications.RemoveAll(application => application.Id == id);
            
            return Results.NoContent();
        }); 

        return group;
    }
}
