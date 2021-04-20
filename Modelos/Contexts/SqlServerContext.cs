using Microsoft.EntityFrameworkCore;
using Modelos.Entities;
using Modelos.EntityConfigurations;


namespace Modelos.Contexts
{
    public class SqlServerContext: DbContext
    {
        private readonly string DefaultConn = @"Data Source=LRONQUILLO\SQLEXPRESS;Initial Catalog=GestionVentas;Integrated Security=True;User ID=sa;Password=nAxx*362";
        #region DBSets
        public DbSet<UsuariosEntity> Usuarios { get; set; }
        
        #endregion

        #region Conexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DefaultConn);
        }
        #endregion 

        #region Configuraciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());
        }
        #endregion 
    }
}
