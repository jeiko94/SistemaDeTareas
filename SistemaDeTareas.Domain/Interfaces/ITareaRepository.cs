using SistemaDeTareas.Domain.Entities;

namespace SistemaDeTareas.Domain.Interfaces
{
    public interface ITareaRepository
    {
        Task AddAsync(Tarea tarea);
        Task<Tarea> GetByIdAsync(int id);
        Task<IEnumerable<Tarea>> GetAllAsync();
        Task<IEnumerable<Tarea>> GetByUsuarioIdAsync(int usuarioId);
    }
}
