using Controladores.Catalogos;
using System;
using System.Windows.Forms;
using Vista.Interfaces;

namespace Vista.Vistas.Clientes
{
    public partial class FrmClientes : Form, IFormClosable
    {
        private readonly ClientesCatalogoController clientesCat;
        public string Key { get; set; }
        public FrmClientes()
        {
            InitializeComponent();
            Key = "clientes";
            clientesCat = new ClientesCatalogoController();
            ModoBusqueda();
            SetDgv();
            this.MaximizeBox = false;
        }

        private void ModoBusqueda()
        {
            txtId.Enabled = true;
            btnAgregar.Enabled = true;
            btnBuscar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        private void ModoEdicion()
        {
            txtId.Enabled = false;
            btnAgregar.Enabled = false;
            btnBuscar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }
        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtRfc.Text = "";
        }
        private void SetDgv()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientesCat.Listar(txtId.Text, txtDireccion.Text, txtNombre.Text, txtRfc.Text);
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvClientes.Columns[dgvClientes.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(clientesCat.Agregar(txtDireccion.Text,txtNombre.Text,txtRfc.Text), "Aviso");
            LimpiarCampos();
            ModoBusqueda();
            SetDgv();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(clientesCat.Modificar(txtId.Text,txtDireccion.Text, txtNombre.Text, txtRfc.Text), "Aviso");
            LimpiarCampos();
            ModoBusqueda();
            SetDgv();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(clientesCat.Desactivar(txtId.Text), "Aviso");
            LimpiarCampos();
            ModoBusqueda();
            SetDgv();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            SetDgv();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ModoBusqueda();
        }

        private void DgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvClientes.Rows[e.RowIndex];
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtNombre.Text = row.Cells["NombreCompleto"].Value.ToString();
            txtRfc.Text = row.Cells["Rfc"].Value.ToString();
            txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
            ModoEdicion();
        }
    }
}
