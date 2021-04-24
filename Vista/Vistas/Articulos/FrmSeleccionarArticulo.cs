using Controladores.Catalogos;
using System;
using System.Windows.Forms;

namespace Vista.Vistas.Articulos
{
    public partial class FrmSeleccionarArticulo : Form
    {
        private readonly ArticulosCatalogoController articulosCat;
        public int idSeleccionado { get; set; }
        public FrmSeleccionarArticulo()
        {
            InitializeComponent();
            articulosCat = new ArticulosCatalogoController();
            SetDataGrid();
        }
        public void SetDataGrid()
        {
            dgvArticulos.DataSource = null;

            dgvArticulos.DataSource = articulosCat.Listar(txtId.Text, txtDescripcion.Text, "", "", "");
        }

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dgvArticulos.Rows[e.RowIndex].Cells["Id"].Value);
                this.Close();
            }
        }
    }
}
