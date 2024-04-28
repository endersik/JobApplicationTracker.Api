namespace JobApplicationTracker.Api.Dtos;
public record class CreateApplicationDto
(
    string CompanyName,
    string Position,
    Seniority Seniority,
    DateOnly Deadline,
    bool IsApplied
);
