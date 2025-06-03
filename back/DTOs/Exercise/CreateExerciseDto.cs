using System;

namespace back.DTOs.Exercise;

public class CreateExerciseDto
{
    public required string Title { get; set; }
    public DateOnly Date { get; set; }
    public required string Priority { get; set; }
    public bool IsActive { get; set; }
    public List<int> UserIds { get; set; } = [];
}
