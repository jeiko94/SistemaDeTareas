using SistemaDeTareas.Aplicacion.DTO;

namespace SistemaDeTareas.Aplicacion.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> CrearUsuarioAsync(CrearUsuarioRequest request);
        Task<UsuarioDto> ObtenerUsuarioPoIdAsync(int id);
        Task<IEnumerable<UsuarioDto>> ObtenerTodosLosUsuariosAsync();
    }
}
