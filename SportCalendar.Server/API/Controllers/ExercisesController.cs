using Microsoft.AspNetCore.Mvc;
using SportCalendar.Server.Application.DTOs;
using SportCalendar.Server.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly ExerciseService _service;

    public ExercisesController(ExerciseService service)
    {
        _service = service;
    }

    [HttpGet("{date}")]
    public async Task<IActionResult> Get(DateOnly date)
    {
        var result = await _service.GetExercises(date);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateExerciseDto dto)
    {
        await _service.AddAsync(dto);
        return Ok();
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(
        int id,
        UpdateStatusDto dto)
    {
        await _service.UpdateStatus(id, dto.Status);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
