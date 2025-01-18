using Microsoft.EntityFrameworkCore;
using SistemaDeTareas.Domain.Entities;
using SistemaDeTareas.Domain.Interfaces;
using SistemaDeTareas.Infraestructura.Persistence;

namespace SistemaDeTareas.Infraestructura.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        public readonly AppDbContext _context;

        public TareaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }
        public async Task<Tarea> GetByIdAsync(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }
        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            return await _context.Tareas.ToListAsync();
        }
        public async Task<IEnumerable<Tarea>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Tareas
                .Where(t => t.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
