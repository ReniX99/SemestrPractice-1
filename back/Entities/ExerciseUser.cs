using System;

namespace back.Entities;

public class ExerciseUser
{
    public int UserId { get; set; }
    public User? User { get; set; }
    public int ExerciseId { get; set; }
    public Exercise? Exercise { get; set; }
}
