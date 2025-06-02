using System;

namespace back.Entities;

public class TaskUser
{
    public int UserId { get; set; }
    public required User User { get; set; }
    public int TaskId { get; set; }
    public required Task Task { get; set; }
}
