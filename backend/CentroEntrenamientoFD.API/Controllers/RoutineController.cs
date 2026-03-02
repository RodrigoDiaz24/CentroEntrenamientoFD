using CentroEntrenamientoFD.Application.DTOs;
using CentroEntrenamientoFD.Application.Mapper;
using CentroEntrenamientoFD.Application.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult Post([FromBody] ClientRoutineDto dto)
        {
            var routine = RoutineMapper.ToDomain(dto);
            _service.CrearRutina(routine);
            return Ok();
        }

        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            var rutina = _service.ObtenerRutina(nombre);
            if (rutina == null) return NotFound();
            return Ok(rutina);
        }
    }
}
