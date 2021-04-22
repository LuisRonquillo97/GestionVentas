using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.Entities;

namespace Modelos.EntityConfigurations
{
    public class DetalleNotaEntityConfiguration : IEntityTypeConfiguration<DetalleNotaEntity>
    {
        public void Configure(EntityTypeBuilder<DetalleNotaEntity> builder)
        {
            #region tablas y relaciones
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Articulo).WithMany(x => x.DetallesNota).HasForeignKey(x => x.IdArticulo).HasPrincipalKey(x => x.Id);
            builder.HasOne(x => x.EncabezadoNota).WithMany(x => x.DetalleNotas).HasForeignKey(x => x.IdEncabezadoNota).HasPrincipalKey(x => x.Id);
            #endregion
            #region Propiedades
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.IdArticulo).IsRequired().HasColumnName("IdArticulo");
            builder.Property(x => x.IdEncabezadoNota).IsRequired().HasColumnName("IdEncNotaVenta");
            builder.Property(x => x.PrecioVenta).IsRequired().HasColumnName("PrecioVenta");
            builder.Property(x => x.Cantidad).IsRequired().HasColumnName("Cantidad");
            #endregion
        }
    }
}
