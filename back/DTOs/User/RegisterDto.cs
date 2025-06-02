using System;

namespace back.DTOs.User;

public class RegisterDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
