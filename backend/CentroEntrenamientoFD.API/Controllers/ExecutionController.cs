using CentroEntrenamientoFD.Application.DTOs;
using CentroEntrenamientoFD.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CentroEntrenamientoFD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExecutionController : ControllerBase
    {
        private readonly RoutineService _service;

        public ExecutionController(RoutineService service)
        {
            _service = service;
        }

        /// <summary>
        /// Registers a new training execution for an existing routine.
        /// </summary>
        /// <remarks>
        /// Used when the athlete completes another training week.
        /// </remarks>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateExecutionDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim is null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim);

            await _service.CreateExecution(dto, userId);

            return Ok();
        }
    }
}
