using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Api.Dtos;
public record class CreateApplicationDto
(
    [Required][StringLength(20)]string CompanyName,
    int TitleId,
    DateOnly Deadline
);
