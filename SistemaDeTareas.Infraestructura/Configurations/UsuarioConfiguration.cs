using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTareas.Domain.Entities;

namespace SistemaDeTareas.Infraestructura.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            //Mapeo del Value Object "Email"
            builder.OwnsOne(u => u.Correo, correo =>
            {
                correo.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Correo");
            });
        }
    }
}
