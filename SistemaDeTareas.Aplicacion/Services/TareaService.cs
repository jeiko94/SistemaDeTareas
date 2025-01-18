using SistemaDeTareas.Aplicacion.DTO;
using SistemaDeTareas.Aplicacion.Interfaces;
using SistemaDeTareas.Domain.Entities;
using SistemaDeTareas.Domain.Exceptions;
using SistemaDeTareas.Domain.Interfaces;

namespace SistemaDeTareas.Aplicacion.Services
{
    public class TareaService : ITareaService
    {
        private readonly ITareaRepository _tareaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public TareaService(ITareaRepository tareaRepository, IUsuarioRepository usuarioRepository)
        {
            _tareaRepository = tareaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<TareaDto> CrearTareaAsync(CrearTareaRequest request)
        {
            var nuevaTarea = new Tarea(request.Titulo, request.Descripcion);
            await _tareaRepository.AddAsync(nuevaTarea);

            return new TareaDto
            {
                Id = nuevaTarea.Id,
                Titulo = nuevaTarea.Titulo,
                Descripcion = nuevaTarea.Descripcion,
                FechaCreacion = nuevaTarea.FechaCreacion
            };
        }
        public async Task<IEnumerable<TareaDto>> ObtenerTareasAsync()
        {
            var tareas = await _tareaRepository.GetAllAsync();

            return tareas.Select(t => new TareaDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                FechaCreacion = t.FechaCreacion,
                UsuarioId = t.UsuarioId
            });
        }
        public async Task<TareaDto> ObtenerTareaPorIdAsync(int id)
        {
            var tarea = await _tareaRepository.GetByIdAsync(id);

            if (tarea == null) throw new DomainException($"Tarea con Id {id} no encontrado ");

            return new TareaDto
            {
                Id = tarea.Id,
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                FechaCreacion = tarea.FechaCreacion,
                UsuarioId= tarea.UsuarioId
            };
        }
        public async Task<TareaDto> AsignarTareaAsync(int tareaId, int usuarioId)
        {
            var tarea = await _tareaRepository.GetByIdAsync(tareaId);
            if (tarea == null) throw new DomainException($"Tarea con Id: {tareaId} no encontrada.");

            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);
            if (usuario == null) throw new DomainException($"Usuario con Id {usuarioId} no encontrado.");

            tarea.AsignarUsuario(usuarioId);

            return new TareaDto
            {
                Id = tarea.Id,
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                FechaCreacion = tarea.FechaCreacion,
                UsuarioId = tarea.UsuarioId
            };
        }
        public async Task<IEnumerable<TareaDto>> ObtenerTareasPorUsuarioAsync(int usuarioId)
        {
            var tareas = await _tareaRepository.GetByUsuarioIdAsync(usuarioId);

            return tareas.Select(t => new TareaDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                FechaCreacion = t.FechaCreacion,
                UsuarioId = t.UsuarioId
            });
        }
    }
}
