using System;
using back.DTOs.Exercise;
using back.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers;

[Route("task")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly UserService _userService;
    private readonly ExerciseService _exerciseService;
    public ExerciseController(UserService userService, ExerciseService exerciseService)
    {
        _userService = userService;
        _exerciseService = exerciseService;
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateExerciseDto createExerciseDto)
    {
        int userId = _userService.GetUserId(HttpContext);
        int exerciseId = await _exerciseService.Create(createExerciseDto, userId);

        return StatusCode(201, new { id = exerciseId });
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        int userId = _userService.GetUserId(HttpContext);

        List<ExerciseDto> dto = await _exerciseService.GetAll(userId);

        return Ok(dto);
    }

    [HttpPut("{exerciseId:int}")]
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] int exerciseId, [FromBody] UpdateExerciseDto updateExerciseDto)
    {
        try
        {
            await _exerciseService.Update(exerciseId, updateExerciseDto);
            return Ok();
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpDelete("{exerciseId:int}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] int exerciseId)
    {
        try
        {
            await _exerciseService.Delete(exerciseId);
            return Ok();
        }
        catch
        {
            return NotFound();
        }
    }
}
