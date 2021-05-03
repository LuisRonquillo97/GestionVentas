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
            this.MaximizeBox = false;
        }
        public void SetDataGrid()
        {
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = articulosCat.Listar(txtId.Text, txtDescripcion.Text, "", "", "");
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvArticulos.Columns[dgvArticulos.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
