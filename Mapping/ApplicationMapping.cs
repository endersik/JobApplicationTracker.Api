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

    public static Application ToEntity(this UpdateApplicationDto application, int id){
        return new Application(){
            Id = id,
            CompanyName = application.CompanyName,
            TitleId = application.TitleId,
            Deadline = application.Deadline
        };
    }

    public static ApplicationSummaryDto ToApplicationSummaryDto(this Application application){
        return new(
                application.Id,
                application.CompanyName,
                application.Title!.Name,
                application.Deadline
            );
    }

    public static ApplicationDetailsDto ToApplicationDetailsDto(this Application application){
        return new(
                application.Id,
                application.CompanyName,
                application.TitleId,
                application.Deadline
            );
    }
}
