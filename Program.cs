using JobApplicationTracker.Api.Data;
using JobApplicationTracker.Api.Dtos;
using JobApplicationTracker.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("ApplicationTracker");
builder.Services.AddSqlite<ApplicationTrackerContext>(connString);

var app = builder.Build();

app.MapApplicationsEndpoints();
app.MapTitlesEndpoints();

await app.MigrateDbAsync();

app.Run();
