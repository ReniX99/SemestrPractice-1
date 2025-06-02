using System;

namespace back.DTOs.User;

public class LoginDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
