using SistemaDeTareas.Domain.Entities;

namespace SistemaDeTareas.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario);
        Task<bool> ExistsByEmailAsync(string email);
        Task<Usuario> GetByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
    }
}
