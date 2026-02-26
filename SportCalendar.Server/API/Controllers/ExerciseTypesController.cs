using Microsoft.AspNetCore.Mvc;
using SportCalendar.Server.Application.Services;

namespace SportCalendar.Server.API.Controllers
{
    [ApiController]
    [Route("api/exercise-types")]
    public class ExerciseTypesController : ControllerBase
    {
        private readonly ExerciseTypeService _service;

        public ExerciseTypesController(ExerciseTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
