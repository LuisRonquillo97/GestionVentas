using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.Entities;

namespace Modelos.EntityConfigurations
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<UsuariosEntity>
    {
        public void Configure(EntityTypeBuilder<UsuariosEntity> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("Id");
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(100).HasColumnName("Nombre");
            builder.Property(p => p.NombreUsuario).IsRequired().HasMaxLength(30).HasColumnName("NombreUsuario");
            builder.Property(p => p.Contraseña).IsRequired().HasMaxLength(50).HasColumnName("Contraseña");
            builder.Property(p => p.Activo).IsRequired().HasColumnName("Activo").HasDefaultValue(true);
        }
    }
}
