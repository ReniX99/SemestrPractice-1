using System;
using System.IdentityModel.Tokens.Jwt;
using back.DTOs.User;
using back.JWT;
using back.Repositories;

namespace back.Services;

public class UserService
{
    private readonly PasswordHasher _passwordHasher;
    private readonly UserRepository _userRepository;
    private readonly JwtProvider _jwtProvider;

    public UserService(PasswordHasher passwordHasher, UserRepository userRepository, JwtProvider jwtProvider)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }
    public async Task<string> Register(RegisterDto registerDto)
    {
        var exsistingUser = await _userRepository.GetByEmail(registerDto.Email);

        if (exsistingUser != null)
        {
            throw new Exception($"A user with this email already exists");
        }

        var password = registerDto.Password;
        var hashedPassword = _passwordHasher.Generate(password);

        var createdUser = await _userRepository.Add(registerDto.Email, hashedPassword);

        var token = _jwtProvider.GenerateToken(createdUser);

        return token;
    }

    public async Task<string> Login(LoginDto loginDto)
    {
        var user = await _userRepository.GetByEmail(loginDto.Email);

        if (user == null)
        {
            throw new Exception("Invalid Email");
        }

        var result = _passwordHasher.Verify(loginDto.Password, user.PasswordHash);

        if (result == false)
        {
            throw new Exception("Email not found and/or password incorrect");
        }

        var token = _jwtProvider.GenerateToken(user);

        return token;
    }

    public int GetUserId(HttpContext httpContext)
    {
        var token = httpContext.Request.Cookies["tasty-cookies"];
        var tokenValue = new JwtSecurityTokenHandler().ReadJwtToken(token);

        var stringUserId = tokenValue.Claims.First(claim => claim.Type == "userId").Value;
        var userId = Convert.ToInt32(stringUserId);

        return userId;
    }
}
