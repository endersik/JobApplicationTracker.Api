namespace JobApplicationTracker.Api.Dtos;

public record class ApplicationDetailsDto(
    int Id,
    string CompanyName,
    int TitleId,
    DateOnly Deadline
    );
