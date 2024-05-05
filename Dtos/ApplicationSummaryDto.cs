namespace JobApplicationTracker.Api.Dtos;

public record class ApplicationSummaryDto(
    int Id,
    string CompanyName,
    string Title,
    DateOnly Deadline
    );
