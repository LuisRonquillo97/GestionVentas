using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.Entities;

namespace Modelos.EntityConfigurations
{
    public class ArticulosEntityConfiguration : IEntityTypeConfiguration<ArticulosEntity>
    {
        public void Configure(EntityTypeBuilder<ArticulosEntity> builder)
        {
            builder.ToTable("Articulo");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("Id");
            builder.Property(p => p.Descripcion).HasMaxLength(100).HasColumnName("Descripcion");
            builder.Property(p => p.Impuesto).HasColumnName("Impuesto");
            builder.Property(p => p.PrecioVenta).HasColumnName("PrecioVenta");
            builder.Property(p => p.Existencia).HasColumnName("Existencia");
            builder.Property(p => p.Activo).HasDefaultValue(true).IsRequired().HasColumnName("Activo");
        }
    }
}
