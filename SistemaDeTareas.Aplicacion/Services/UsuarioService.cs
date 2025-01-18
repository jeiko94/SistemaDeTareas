using SistemaDeTareas.Aplicacion.DTO;
using SistemaDeTareas.Aplicacion.Interfaces;
using SistemaDeTareas.Domain.Entities;
using SistemaDeTareas.Domain.Exceptions;
using SistemaDeTareas.Domain.Interfaces;
using SistemaDeTareas.Domain.ValueObjects;

namespace SistemaDeTareas.Aplicacion.Services
{
    //Implementa la lógica para crear y consultar usuarios, incluyendo la validación de duplicados.
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto> CrearUsuarioAsync(CrearUsuarioRequest request)
        {
            //Verificar si el correo ya existe
            bool existeCorreo = await _usuarioRepository.ExistsByEmailAsync(request.Correo);

            if (existeCorreo)
            {
                throw new UsuarioDuplicadoException(request.Correo);
            }

            var correoValue = new Email(request.Correo);
            var nuevoUsuario = new Usuario(request.Nombre,request.Apellido, correoValue);

            await _usuarioRepository.AddAsync(nuevoUsuario);

            return new UsuarioDto
            {
                Id = nuevoUsuario.Id,
                Nombre = nuevoUsuario.Nombre,
                Apellido = nuevoUsuario.Apellido,
                Correo = nuevoUsuario.Correo.ToString()
            };
        }
        public async Task<UsuarioDto> ObtenerUsuarioPoIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) throw new DomainException($"Usuario con Id {id} no encontrado ");

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo.ToString()
            };
        }
        public async Task<IEnumerable<UsuarioDto>> ObtenerTodosLosUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            return usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo.ToString()
            });
        }
    }
}
