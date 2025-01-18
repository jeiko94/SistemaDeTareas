namespace SistemaDeTareas.Domain.ValueObjects
{
    public class Email
    {
        public string Direccion { get; private set; }

        public Email(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion) || !direccion.Contains("@"))
                throw new ArgumentException("El correo electronico no es valido.");

            Direccion = direccion;
        }

        public override string ToString()
        {
            return Direccion ?? string.Empty;
        }
    }
}
