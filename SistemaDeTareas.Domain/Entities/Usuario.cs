using SistemaDeTareas.Domain.ValueObjects;

namespace SistemaDeTareas.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string? Nombre { get; private set; }
        public string? Apellido { get; private set; }
        public Email Correo { get; private set; }

        //Constructor privado para EF Core o Serialización
        private Usuario() { }

        public Usuario(string nombre, string apellido, Email correo)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentNullException(nameof(nombre), "El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(apellido)) throw new ArgumentNullException(nameof(apellido), "El apellido es obligatorio.");

            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
        }

    }
}
