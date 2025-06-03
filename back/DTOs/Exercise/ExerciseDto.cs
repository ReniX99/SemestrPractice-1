using System;

namespace back.DTOs.Exercise;

public class ExerciseDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required DateOnly Date { get; set; }
    public required string Priority { get; set; }
    public required bool IsActive { get; set; }
}
