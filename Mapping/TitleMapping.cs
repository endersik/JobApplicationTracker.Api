using JobApplicationTracker.Api.Dtos;
using JobApplicationTracker.Api.Entities;

namespace JobApplicationTracker.Api.Mapping;

public static class TitleMapping
{
    public static TitleDto ToDto(this Title title){
        return new TitleDto(title.Id, title.Name);
    }
}
