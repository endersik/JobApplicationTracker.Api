using JobApplicationTracker.Api.Dtos;
using JobApplicationTracker.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapApplicationsEndpoints();

app.Run();
