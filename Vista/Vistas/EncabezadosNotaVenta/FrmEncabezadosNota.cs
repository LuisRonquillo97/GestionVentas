using Controladores.Catalogos;
using Datos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vista.Interfaces;
using Vista.Vistas.DetallesNotaVenta;

namespace Vista.Vistas.EncabezadosNotaVenta
{
    public partial class FrmEncabezadosNota : Form, IFormClosable
    {
        public string Key { get; set; }
        private readonly TiposPagoCatalogoController tiposPagoCat;
        private readonly EncabezadosNotaCatalogoController encabezadosCat;
        private readonly DetallesNotaCatalogoController detallesCat;
        public FrmEncabezadosNota()
        {
            Key = "EncabezadoNota";
            tiposPagoCat = new TiposPagoCatalogoController();
            encabezadosCat = new EncabezadosNotaCatalogoController();
            detallesCat = new DetallesNotaCatalogoController();
            InitializeComponent();
            ModoBusqueda();
            SetCmbTipoPago();
            SetDgv();
            this.MaximizeBox = false;
        }
        #region metodos de formulario
        public void ModoEdicion()
        {
            txtId.Enabled = false;
            txtIdCliente.Enabled = false;
            txtClienteNombre.Enabled = false;
            dtpFechaCreado.Enabled = false;
            btnBuscar.Enabled = false;
            btnDetalles.Enabled = true;
            btnActualizar.Enabled = true;
            cmbTipoPago.Enabled = false;
        }
        public void ModoBusqueda()
        {
            txtId.Enabled = true;
            txtIdCliente.Enabled = true;
            txtClienteNombre.Enabled = true;
            dtpFechaCreado.Enabled = true;
            btnBuscar.Enabled = true;
            btnDetalles.Enabled = false;
            btnActualizar.Enabled = false;
            cmbTipoPago.Enabled = true;
        }
        private void SetCmbTipoPago()
        {
            cmbTipoPago.Items.Clear();
            var comboBoxItems = tiposPagoCat.ListarItemsComboBoxTipoPago();
            cmbTipoPago.Items.AddRange(comboBoxItems.ToArray());
        }
        private ComboBoxItem GetCmbTipoPago()
        {
            return cmbTipoPago.SelectedItem as ComboBoxItem;
        }
        private void LimpiarCampos()
        {
            txtClienteNombre.Text = "";
            txtComentario.Text = "";
            txtId.Text = "";
            txtIdCliente.Text = "";
            dtpFechaCreado.Value = DateTime.Now;
            lblTotal.Text = "$----.--";
            cmbStatus.SelectedItem = null;
            SetCmbTipoPago();
        }
        private void SetDgv()
        {
            DateTime? fecha = null;
            ComboBoxItem comboBoxItem = GetCmbTipoPago();
            string cmbitemId = "";
            dgvEncabezados.DataSource = null;

            if (dtpFechaCreado.Value.Date != DateTime.Now.Date)
            {
                fecha = dtpFechaCreado.Value;
            }
            if (comboBoxItem != null)
            {
                cmbitemId = comboBoxItem.Value.ToString();
            }
            dgvEncabezados.DataSource = encabezadosCat.ListarDgvEncabezadoNota(txtId.Text, txtComentario.Text, fecha, txtIdCliente.Text, cmbitemId, cmbStatus.SelectedItem != null ? cmbStatus.SelectedItem.ToString() : "");
            dgvEncabezados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEncabezados.Columns[dgvEncabezados.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        #endregion

        #region componentesFormulario
        private void DgvEncabezados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvEncabezados.Rows[e.RowIndex];
            List<ComboBoxItem> itemsCombo = new List<ComboBoxItem>();
            foreach (ComboBoxItem item in cmbTipoPago.Items)
            {
                itemsCombo.Add(item);
            }
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtClienteNombre.Text = row.Cells["Cliente"].Value.ToString();
            txtComentario.Text = row.Cells["Comentario"].Value.ToString();
            txtIdCliente.Text = row.Cells["IdCliente"].Value.ToString();
            cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
            cmbTipoPago.SelectedIndex = cmbTipoPago.Items.IndexOf(itemsCombo.First(x => x.Value.ToString() == row.Cells["IdTipoPago"].Value.ToString()));
            if (DateTime.TryParse(row.Cells["FechaCreado"].Value.ToString(), out DateTime fechaCreado))
            {
                dtpFechaCreado.Value = fechaCreado;
            }
            ModoEdicion();
            lblTotal.Text = $"${detallesCat.TotalDetalle(txtId.Text):###,###,###.##}";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            SetDgv();
        }

        private void BtnDetalles_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                FrmDetalleNota frmDetalleNota = new FrmDetalleNota(id);
                frmDetalleNota.ShowDialog();
            }

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ComboBoxItem selectedCombo = cmbTipoPago.SelectedItem as ComboBoxItem;
            MessageBox.Show(encabezadosCat.Modificar(txtId.Text, txtComentario.Text, dtpFechaCreado.Value, txtIdCliente.Text, selectedCombo.Value.ToString(), cmbStatus.SelectedItem.ToString()), "Aviso");
            LimpiarCampos();
            SetDgv();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ModoBusqueda();
            SetDgv();
        }
        #endregion


    }
}