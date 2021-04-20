using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.Entities;

namespace Modelos.EntityConfigurations
{
    /*
     * Esta es la configuración de la entidad.
     * Siempre que se hace una configuración de entidad, tenemos que utilizar la interfaz IEntityTypeConfiguration
     * y pasarle entre comparadores <> el nombre de la entidad de la cual haremos la configuración
     * en este caso, es de usuariosEntity.
     */
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<UsuariosEntity>
    {
        /*
         * La intefaz que usamos tiene este método que debemos implemental.
         * builder es el parámetro que utilizamos para crear la relación a BD
         */
        public void Configure(EntityTypeBuilder<UsuariosEntity> builder)
        {
            //primero, le decimos cómo se llama la tabla con la que debe conectarse
            builder.ToTable("Usuario");
            //después, le decimos cuál es la llave primaria
            builder.HasKey(k => k.Id);
            /*
             * después, le decimos campo por campo, que características tienen.
             * por ejemplo, si el parámetro es requerido, cuál es la longitud máxima del campo, si tiene algún valor por defecto...
             * Siempre es obligatorio decirle a cada campo, con que columna de la tabla en SQL tienen relación
             * si no se pone, puede generar errores al no saber con qué campo de BD debeconectarse.
             */
            builder.Property(p => p.Id).IsRequired().HasColumnName("Id");
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(100).HasColumnName("Nombre");
            builder.Property(p => p.NombreUsuario).IsRequired().HasMaxLength(30).HasColumnName("NombreUsuario");
            builder.Property(p => p.Contraseña).IsRequired().HasMaxLength(50).HasColumnName("Contraseña");
            builder.Property(p => p.Activo).IsRequired().HasColumnName("Activo").HasDefaultValue(true);
        }
    }
}
