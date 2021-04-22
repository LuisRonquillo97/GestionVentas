using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.EntityConfigurations
{
    public class TipoPagoEntityConfiguration : IEntityTypeConfiguration<TipoPagoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoPagoEntity> builder)
        {
            builder.ToTable("TipoPago");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descripcion).HasMaxLength(50).HasColumnName("Descripcion");
            builder.Property(x => x.Activo).HasDefaultValue(true).HasColumnName("Activo");
        }
    }
}
