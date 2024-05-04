namespace JobApplicationTracker.Api.Dtos;

public enum Seniority{
        Intern = 1,
        Junior,
        Associate,
        MidLevel,
        Senior,
        Lead,
        Manager
    }
public record class ApplicationDto(
    int Id,
    string CompanyName,
    string Title,
    Seniority Seniority,
    DateOnly Deadline,
    bool IsApplied
    );
