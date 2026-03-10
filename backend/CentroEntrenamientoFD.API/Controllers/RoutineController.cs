using CentroEntrenamientoFD.Application.DTOs;
using CentroEntrenamientoFD.Application.Mapper;
using CentroEntrenamientoFD.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CentroEntrenamientoFD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutineController : ControllerBase
    {
        private readonly RoutineService _service;

        public RoutineController(RoutineService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a new routine template and the first execution week.
        /// </summary>
        /// <remarks>
        /// The coach defines:
        /// - routine structure
        /// - exercises
        /// - micro slots
        /// 
        /// This endpoint automatically creates the first execution.
        /// </remarks>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientRoutineDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim is null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim);

            var routine = RoutineMapper.ToDomain(dto, userId);

            await _service.CreateRoutineWithExecution(routine);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var routine = _service.GetRoutine(id);

            if (routine == null)
                return NotFound();

            return Ok(routine);
        }
    }
}
