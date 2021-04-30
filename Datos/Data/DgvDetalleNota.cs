namespace Datos.Data
{
    public class DgvDetalleNota
    {
        public int IdDetalleNota { get; set; }
        public int IdArticulo { get; set; }
        public string Articulo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
