namespace SistemaDeTareas.Aplicacion.DTO
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioId { get; set; }
    }
}
