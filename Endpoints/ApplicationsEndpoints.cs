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
            new DateOnly(2024, 3, 17)
        ),

        new (
            2,
            "Apple",
            "iOS Developer",
            new DateOnly(2024, 5, 12)
        )
    ];

    public static RouteGroupBuilder MapApplicationsEndpoints(this WebApplication app){
        var group = app.MapGroup("applications")
                        .WithParameterValidation();

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
                newApplication.Title,
                newApplication.Deadline
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
                updatedApplication.Title,
                updatedApplication.Deadline
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
