using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.EntityConfigurations
{
    public class EncabezadoNotaEntityConfiguration : IEntityTypeConfiguration<EncabezadoNotaEntity>
    {
        public void Configure(EntityTypeBuilder<EncabezadoNotaEntity> builder)
        {
            #region tabla y relaciones
            builder.ToTable("EncNotaVenta");
            builder.HasMany(x => x.DetalleNotas).WithOne(x => x.EncabezadoNota).HasForeignKey(x => x.IdEncabezadoNota).HasPrincipalKey(x => x.Id);
            builder.HasOne(x => x.Cliente).WithMany(x => x.EncabezadosNota).HasForeignKey(x => x.IdCliente).HasPrincipalKey(x => x.Id);
            builder.HasOne(x => x.TipoPago).WithMany(x => x.EncabezadosNota).HasForeignKey(x => x.IdTipoPago).HasPrincipalKey(x => x.Id);
            #endregion
            #region propiedades de tabla
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.IdCliente).IsRequired().HasColumnName("IdCliente");
            builder.Property(x => x.IdTipoPago).IsRequired().HasColumnName("IdTipoPago");
            builder.Property(x => x.FechaCreado).IsRequired().HasDefaultValue(DateTime.Now).HasColumnName("FechaCreado");
            builder.Property(x => x.Comentario).IsRequired().HasMaxLength(100).HasColumnName("Comentario");
            builder.Property(x => x.Status).IsRequired().HasMaxLength(10).HasColumnName("Status");
            #endregion
        }
    }
}
