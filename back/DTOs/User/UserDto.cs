using System;

namespace back.DTOs.User;

public class UserDto
{
    public required int Id { get; set; }
    public required string Email { get; set; }
}
