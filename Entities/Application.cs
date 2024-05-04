using JobApplicationTracker.Api.Dtos;

namespace JobApplicationTracker.Api.Entities;

public class Application
{
    public int Id { get; set; }
    public required string CompanyName { get; set; }

    public int TitleId { get; set; }
    public Title? Title { get; set; }

    public Seniority Seniority { get; set; }
    public DateOnly Deadline { get; set; }
    public bool IsApplied { get; set; }
}
