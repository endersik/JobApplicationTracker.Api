using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Api.Dtos;

public record class UpdateApplicationDto
(
    [Required][StringLength(20)]string CompanyName,
    int TitleId,
    DateOnly Deadline
);
