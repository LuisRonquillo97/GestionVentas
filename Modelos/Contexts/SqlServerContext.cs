using Microsoft.EntityFrameworkCore;
using Modelos.Entities;
using Modelos.EntityConfigurations;


namespace Modelos.Contexts
{
    /*
     * Esta clase se encarga de conectar las entidades con la base de datos.
     * cada que queramos agregar una nueva tabla, primero se deben hacer su entidad, y su entityConfiguration, para asignarlos aquí.
     */
    public class SqlServerContext: DbContext
    {
        //cadena de conexión a base de datos. se puede modificar si se desea conectar a otro lugar.
        private readonly string DefaultConn = @"Data Source=LRONQUILLO\SQLEXPRESS;Initial Catalog=GestionVentas;Integrated Security=True;User ID=sa;Password=nAxx*362";
        //aquí se crean los DbSets de cada tabla, esto sirve para cuando vamos a utilizar una tabla, podamos hacer algo tipo Context.Usuarios
        //y C# ya sepa a qué tabla nos referimos.
        #region DBSets
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<ArticuloEntity> Articulos { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<TipoPagoEntity> TiposPago { get; set; }
        public DbSet<EncabezadoNotaEntity> EncabezadosNota { get; set; }
        public DbSet<DetalleNotaEntity> DetallesNota { get; set; }
        
        #endregion

        //esta parte no se modifica, aquí se asigna la variable DefaultConn como cadena de conexión a SQL server.
        #region Conexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DefaultConn);
        }
        #endregion 
        /*
         * aquí asignamos la configuración de cada entidad.
         * Si no se pasa por aquí, el sistema no sabrá si el DbSet que creamos antes debe ir relacionado a alguna tabla, cual campo 
         * es llave primaria, etc etc etc. Es obligatorio hacerlo.
         */
        #region Configuraciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ArticuloEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TipoPagoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EncabezadoNotaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleNotaEntityConfiguration());
        }
        #endregion 
    }
}
