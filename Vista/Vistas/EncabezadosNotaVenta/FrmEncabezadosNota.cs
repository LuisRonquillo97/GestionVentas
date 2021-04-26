using Controladores.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Interfaces;
using Datos.Helpers;
using Vista.Vistas.DetallesNotaVenta;
using System.Linq;

namespace Vista.Vistas.EncabezadosNotaVenta
{
    public partial class FrmEncabezadosNota : Form, IFormClosable
    {
        public string Key { get; set; }
        private readonly TiposPagoCatalogoController tiposPagoCat;
        private readonly EncabezadosNotaCatalogoController encabezadosCat;
        public FrmEncabezadosNota()
        {
            Key = "EncabezadoNota";
            tiposPagoCat = new TiposPagoCatalogoController();
            encabezadosCat = new EncabezadosNotaCatalogoController();
            InitializeComponent();
            ModoBusqueda();
            SetCmbTipoPago();
            SetDgv();
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
        }
        private void SetCmbTipoPago()
        {
            cmbTipoPago.Items.Clear();
            var comboBoxItems = tiposPagoCat.ListarItemsComboBoxTipoPago();
            cmbTipoPago.Items.AddRange(comboBoxItems.ToArray());
        }
        private void LimpiarCampos()
        {
            txtClienteNombre.Text = "";
            txtComentario.Text = "";
            txtId.Text = "";
            txtIdCliente.Text = "";
            dtpFechaCreado.Value = DateTime.Now;
            lblTotal.Text = "$----.--";
            SetCmbTipoPago();
        }
        private void SetDgv()
        {
            dgvEncabezados.DataSource = null;

            dgvEncabezados.DataSource = MapDatagrid();
        }
        private List<DgvValues> MapDatagrid()
        {
            List<DgvValues> datagridValues = new List<DgvValues>();
            DateTime? fechaCreado = dtpFechaCreado.Value;
            if (dtpFechaCreado.Value.Date == DateTime.Now.Date)
            {
                fechaCreado = null;
            }
            var datosEncabezado = encabezadosCat.Listar(txtId.Text, txtComentario.Text, fechaCreado, txtIdCliente.Text, cmbTipoPago.SelectedItem is ComboBoxItem selectedCombo ? selectedCombo.Value.ToString() : "", cmbStatus.SelectedItem != null ? cmbStatus.SelectedItem.ToString() : "");
            foreach (var dato in datosEncabezado)
            {
                datagridValues.Add(new DgvValues
                {
                    Id = dato.Id.Value,
                    IdCliente = dato.IdCliente.Value,
                    Cliente = dato.Cliente.NombreCompleto,
                    Comentario = dato.Comentario,
                    IdTipoPago = dato.IdTipoPago.Value,
                    Status = dato.Status,
                    TipoPago = dato.TipoPago.Descripcion,
                    FechaCreado=dato.FechaCreado.Value
                });
            }
            return datagridValues;
        }
        #endregion

        #region componentesFormulario
        private void DgvEncabezados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvEncabezados.Rows[e.RowIndex];
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtClienteNombre.Text = row.Cells["Cliente"].Value.ToString();
            txtComentario.Text = row.Cells["Comentario"].Value.ToString();
            txtIdCliente.Text = row.Cells["IdCliente"].Value.ToString();
            cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
            cmbTipoPago.SelectedItem = cmbTipoPago.Items.IndexOf(new ComboBoxItem { Text = row.Cells["TipoPago"].Value.ToString(), Value = Convert.ToInt32(row.Cells["IdTipoPago"]) });
            if(DateTime.TryParse(row.Cells["FechaCreado"].Value.ToString(),out DateTime fechaCreado))
            {
                dtpFechaCreado.Value = fechaCreado;
            }
            ModoEdicion();
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
            MessageBox.Show(encabezadosCat.Modificar(txtId.Text, txtComentario.Text, dtpFechaCreado.Value, txtIdCliente.Text, selectedCombo.Value.ToString(), cmbStatus.SelectedText), "Aviso");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ModoBusqueda();
        }
        #endregion


    }
}
internal class DgvValues
{
    public DateTime FechaCreado { get; set; }
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public string Cliente { get; set; }
    public string Status { get; set; }
    public int IdTipoPago { get; set; }
    public string TipoPago { get; set; }
    public string Comentario { get; set; }
}