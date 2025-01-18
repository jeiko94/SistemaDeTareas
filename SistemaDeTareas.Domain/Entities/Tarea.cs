namespace SistemaDeTareas.Domain.Entities
{
    public class Tarea
    {
        public int Id { get; private set; }
        public string? Titulo { get; private set; }
        public string? Descripcion { get; private set; }
        public DateTime FechaCreacion { get; private set; }

        //Asignación a un usuario
        public int? UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        private Tarea() { }

        public Tarea(string titulo, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentNullException("El título es obligatorio.");

            Titulo = titulo;
            Descripcion = descripcion;
            FechaCreacion = DateTime.Now;
        }

        public void AsignarUsuario(int usuarioId)
        {
            UsuarioId = usuarioId;
        }

    }
}
