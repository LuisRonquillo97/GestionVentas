using System;
using System.Windows.Forms;
using Vista.Interfaces;
using Controladores.Catalogos;

namespace Vista.Vistas.Articulos
{
    public partial class FrmArticulos : Form, IFormClosable
    {
        private readonly ArticulosCatalogoController articulosCat;
        public string Key { get; set; }
        public FrmArticulos()
        {
            InitializeComponent();
            articulosCat = new ArticulosCatalogoController();
            Key = "articulos";
            SetDataGrid();
            BotonesNuevo();
            btnAgregar.Click += BtnAgregar_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnBuscar.Click += BtnBuscar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            dgvArticulos.CellDoubleClick += DgvArticulos_CellDoubleClick;
        }
        #region Botones
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(articulosCat.Agregar(txtDescripcion.Text, txtExistencia.Text, txtImpuesto.Text, txtPrecioVenta.Text));
            LimpiarCampos();
            SetDataGrid();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(articulosCat.Modificar(txtId.Text, txtDescripcion.Text, txtExistencia.Text, txtImpuesto.Text, txtPrecioVenta.Text));
            LimpiarCampos();
            SetDataGrid();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(articulosCat.Desactivar(txtId.Text));
                LimpiarCampos();
                SetDataGrid();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            SetDataGrid();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            BotonesNuevo();
        }
        #endregion

        #region Comportamiento del formulario
        public void SetDataGrid()
        {
            dgvArticulos.DataSource = null;
            
            dgvArticulos.DataSource = articulosCat.Listar(txtId.Text, txtDescripcion.Text, txtExistencia.Text, txtImpuesto.Text, txtPrecioVenta.Text);
        }
        public void BotonesEdicion()
        {
            txtId.Enabled = false;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnBuscar.Enabled = false;
        }
        public void BotonesNuevo()
        {
            txtId.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = true;
        }
        public void LimpiarCampos()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtExistencia.Text = "";
            txtImpuesto.Text = "";
            txtPrecioVenta.Text = "";
            BotonesNuevo();
        }
        #endregion
        private void DgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvArticulos.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtDescripcion.Text = dgvArticulos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                txtExistencia.Text = dgvArticulos.Rows[e.RowIndex].Cells["Existencia"].Value.ToString();
                txtImpuesto.Text = dgvArticulos.Rows[e.RowIndex].Cells["Impuesto"].Value.ToString();
                txtPrecioVenta.Text = dgvArticulos.Rows[e.RowIndex].Cells["PrecioVenta"].Value.ToString();
                BotonesEdicion();
            }
        }
    }
}
