using JobApplicationTracker.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<ApplicationDto> applications = [
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

app.MapGet("applications", () => applications);

app.MapGet("applications/{id}", (int id) => applications.Find(application => application.Id == id));

app.Run();
