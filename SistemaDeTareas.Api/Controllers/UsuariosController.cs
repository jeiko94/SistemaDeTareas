using Microsoft.AspNetCore.Mvc;
using SistemaDeTareas.Aplicacion.DTO;
using SistemaDeTareas.Aplicacion.Interfaces;

namespace SistemaDeTareas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioRequest request)
        {
            var usuarioCreado = await _usuarioService.CrearUsuarioAsync(request);
            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = usuarioCreado.Id }, usuarioCreado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPoIdAsync(id);
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLosUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerTodosLosUsuariosAsync();
            return Ok(usuarios);
        }
    }
}
