using Controladores.Catalogos;
using Datos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Vistas.Articulos;

namespace Vista.Vistas.NotasVenta
{
    public partial class FrmPuntoVenta : Form
    {
        private readonly ArticulosCatalogoController articulosCat;
        private readonly EncabezadosNotaCatalogoController encabezadosCat;
        private List<DetallesNotaData> DetallesNotas { get; set; }
        public FrmPuntoVenta()
        {
            articulosCat = new ArticulosCatalogoController();
            encabezadosCat = new EncabezadosNotaCatalogoController();
            InitializeComponent();
            SetDgv();
        }
        public void ObtenerArticulo(object sender, EventArgs e)
        {
            FrmSeleccionarArticulo frmSelArt = sender as FrmSeleccionarArticulo;
            ArticulosData articulo = articulosCat.BuscarPorId(frmSelArt.idSeleccionado);
            if (articulo != null)
            {
                DetallesNotas.Add(new DetallesNotaData
                {
                    IdArticulo = articulo.Id,
                    Cantidad=1,
                    Articulo=articulo,
                    PrecioVenta=articulo.PrecioVenta
                });
                SetDgv();
            }

        }

        private void BtnNuevoArticulo_Click(object sender, EventArgs e)
        {
            FrmSeleccionarArticulo selArt = new FrmSeleccionarArticulo();
            selArt.FormClosing += ObtenerArticulo;

        }
        private void SetDgv()
        {
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = DetallesNotas;
        }
    }
}
