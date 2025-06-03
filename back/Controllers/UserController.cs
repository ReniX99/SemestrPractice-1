
using back.DTOs.User;
using back.Services;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    private readonly CookieOptions cookieOptions = new CookieOptions
    {
        HttpOnly = true,
        SameSite = SameSiteMode.None,
        Secure = true
    };
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("auth/register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        try
        {
            var token = await _userService.Register(registerDto);
            Response.Cookies.Append("tasty-cookies", token, cookieOptions);

            return StatusCode(201);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("auth/login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        try
        {
            var token = await _userService.Login(loginDto);
            Response.Cookies.Append("tasty-cookies", token, cookieOptions);

            return Ok();
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        int userId = _userService.GetUserId(HttpContext);
        List<UserDto> users = await _userService.GetAll(userId);

        return Ok(users);
    }
}
