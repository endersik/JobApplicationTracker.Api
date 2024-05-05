using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Api.Dtos;

public record class UpdateApplicationDto
(
    [Required][StringLength(20)]string CompanyName,
    [Required][StringLength(50)]string Title,
    DateOnly Deadline
);
