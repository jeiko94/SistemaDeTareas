using Microsoft.EntityFrameworkCore;
using SistemaDeTareas.Domain.Entities;
using SistemaDeTareas.Domain.Interfaces;
using SistemaDeTareas.Infraestructura.Persistence;

namespace SistemaDeTareas.Infraestructura.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Correo.Direccion == email);
        }
        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
