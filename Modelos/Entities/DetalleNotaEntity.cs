namespace Modelos.Entities
{
    public class DetalleNotaEntity
    {
        public int? Id { get; set; }
        public int? IdArticulo { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? Cantidad { get; set; }
        public int? IdEncabezadoNota { get; set; }
        public virtual EncabezadoNotaEntity EncabezadoNota { get; set; }
        public virtual ArticuloEntity Articulo { get; set; }
    }
}
