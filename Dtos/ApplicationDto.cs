namespace JobApplicationTracker.Api.Dtos;

public record class ApplicationDto(
    int Id,
    string CompanyName,
    string Title,
    DateOnly Deadline
    );
