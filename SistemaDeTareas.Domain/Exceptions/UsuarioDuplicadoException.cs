namespace SistemaDeTareas.Domain.Exceptions
{
    public class UsuarioDuplicadoException : DomainException
    {
        public UsuarioDuplicadoException(string email) : base($"Ya existe un usuario con el correo {email}") { }
    }
}
