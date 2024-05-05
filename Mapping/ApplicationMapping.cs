using JobApplicationTracker.Api.Dtos;
using JobApplicationTracker.Api.Entities;

namespace JobApplicationTracker.Api.Mapping;

public static class ApplicationMapping
{
    public static Application ToEntity(this CreateApplicationDto application){
        return new Application(){
            CompanyName = application.CompanyName,
            TitleId = application.TitleId,
            Deadline = application.Deadline
        };
    }

    public static ApplicationDto ToDto(this Application application){
        return new(
                application.Id,
                application.CompanyName,
                application.Title!.Name,
                application.Deadline
            );
    }
}
