using System;

namespace back.Entities;

public class Task
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime DateTime { get; set; }
    public required string Priority { get; set; }
}
