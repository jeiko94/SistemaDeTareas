using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTareas.Domain.Entities;

namespace SistemaDeTareas.Infraestructura.Configurations
{
    public class TareaConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Descripcion)
                .HasMaxLength(100);

            builder.Property(t => t.FechaCreacion)
                .IsRequired();

            //Relacion uno a muchos
            builder.HasOne(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.UsuarioId);
        }
    }
}
