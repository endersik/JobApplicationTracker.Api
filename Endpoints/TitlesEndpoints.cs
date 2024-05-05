using JobApplicationTracker.Api.Data;
using JobApplicationTracker.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Api.Endpoints;

public static class TitlesEndpoints
{
    public static RouteGroupBuilder MapTitlesEndpoints(this WebApplication app){
        var group = app.MapGroup("titles");

        group.MapGet("/", async (ApplicationTrackerContext dbContext) =>
            await dbContext.Titles
                           .Select(title => title.ToDto())
                           .AsNoTracking()
                           .ToListAsync());
        return group;                   
    }
}
