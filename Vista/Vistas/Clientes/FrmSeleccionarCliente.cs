using Controladores.Catalogos;
using System;
using System.Windows.Forms;

namespace Vista.Vistas.Clientes
{
    public partial class FrmSeleccionarCliente : Form
    {
        ClientesCatalogoController clientesCat;
        public int idSeleccionado { get; set; }
        public FrmSeleccionarCliente()
        {
            clientesCat = new ClientesCatalogoController();
            InitializeComponent();
            SetDgv();
            this.MaximizeBox = false;
        }
        public void SetDgv()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientesCat.Listar(txtId.Text, "", txtNombre.Text, txtRfc.Text);
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvClientes.Columns[dgvClientes.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                this.Close();
            }
        }
    }
}
