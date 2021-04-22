using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.Entities;
namespace Modelos.EntityConfigurations
{
    public class ClienteEntityConfiguration : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(100).HasColumnName("Direccion");
            builder.Property(x => x.NombreCompleto).IsRequired().HasMaxLength(250).HasColumnName("NombreCompleto");
            builder.Property(x => x.Rfc).IsRequired().HasMaxLength(15).HasColumnName("Rfc");
            builder.Property(x => x.Activo).IsRequired().HasDefaultValue(true).HasColumnName("Activo");
        }
    }
}
