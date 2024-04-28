namespace JobApplicationTracker.Api.Dtos;

public record class UpdateApplicationDto
(
    string CompanyName,
    string Position,
    Seniority Seniority,
    DateOnly Deadline,
    bool IsApplied
);
