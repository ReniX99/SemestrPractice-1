using System;

namespace back.Entities;

public class Exercise
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public DateOnly Date { get; set; }
    public required string Priority { get; set; }
    public required bool IsActive { get; set; }
}
