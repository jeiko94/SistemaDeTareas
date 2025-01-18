using SistemaDeTareas.Aplicacion.DTO;

namespace SistemaDeTareas.Aplicacion.Interfaces
{
    public interface ITareaService
    {
        Task<TareaDto> CrearTareaAsync(CrearTareaRequest request);
        Task<IEnumerable<TareaDto>> ObtenerTareasAsync();
        Task<TareaDto> ObtenerTareaPorIdAsync(int id);
        Task<TareaDto> AsignarTareaAsync(int tareaId, int usuarioId);
        Task<IEnumerable<TareaDto>> ObtenerTareasPorUsuarioAsync(int usuarioId);
    }
}
