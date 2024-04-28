﻿using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Api.Dtos;
public record class CreateApplicationDto
(
    [Required][StringLength(20)]string CompanyName,
    [Required][StringLength(50)]string Position,
    [Range(1,7)]Seniority Seniority,
    DateOnly Deadline,
    bool IsApplied
);
