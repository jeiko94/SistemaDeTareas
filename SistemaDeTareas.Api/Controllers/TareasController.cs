using Microsoft.AspNetCore.Mvc;
using SistemaDeTareas.Aplicacion.DTO;
using SistemaDeTareas.Aplicacion.Interfaces;

namespace SistemaDeTareas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareasController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTarea([FromBody] CrearTareaRequest request)
        {
            var tareaCreada = await _tareaService.CrearTareaAsync(request);
            return CreatedAtAction(nameof(ObtenerTareaPorId), new { id = tareaCreada.Id }, tareaCreada);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasLasTareas()
        {
            var tareas = await _tareaService.ObtenerTareasAsync();
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTareaPorId(int id)
        {
            var tarea = await _tareaService.ObtenerTareaPorIdAsync(id);
            return Ok(tarea);
        }

        [HttpPut("{tareaId}/asignar/{usuarioId}")]
        public async Task<IActionResult> AsignarTarea(int tareaId, int usuarioId)
        {
            var tareaAsignada = await _tareaService.AsignarTareaAsync(tareaId, usuarioId);
            return Ok(tareaAsignada);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> ObtenerTareasPorUsuario(int usuarioId)
        {
            var tareas = await _tareaService.ObtenerTareasPorUsuarioAsync(usuarioId);
            return Ok(tareas);
        }
    }
}
