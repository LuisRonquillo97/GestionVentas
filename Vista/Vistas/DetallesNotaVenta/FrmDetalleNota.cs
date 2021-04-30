using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Interfaces;
using Controladores.Catalogos;
using Datos.Data;
using Vista.Vistas.EncabezadosNotaVenta;

namespace Vista.Vistas.DetallesNotaVenta
{
    public partial class FrmDetalleNota : Form, IFormClosable
    {
        public string Key { get; set; }
        private readonly EncabezadosNotaCatalogoController encabezadoCat;
        private readonly DetallesNotaCatalogoController detalleCat;

        public FrmDetalleNota(int? idEncabezado = null)
        {
            Key = "DetalleNotas";
            InitializeComponent();
            encabezadoCat = new EncabezadosNotaCatalogoController();
            detalleCat = new DetallesNotaCatalogoController();
            if (idEncabezado.HasValue)
            {
                CargarEncabezadoNota(idEncabezado.Value);
                btnBuscarNotaVenta.Enabled = false;
                btnLimpiar.Enabled = false;
            }
            ModoBusquedaEncabezado();
        }
        public FrmDetalleNota()
        {
            Key = "DetalleNotas";
            InitializeComponent();
            encabezadoCat = new EncabezadosNotaCatalogoController();
            detalleCat = new DetallesNotaCatalogoController();
            ModoBusquedaEncabezado();
        }
        #region Metodos de interacción de datos del formulario
        private void SetDgv()
        {
            dgvDetalleNota.DataSource = null;
            dgvDetalleNota.DataSource = detalleCat.ListarDgv(txtIdDetalleNota.Text, txtCantidad.Text, txtIdArticulo.Text, txtIdNotaVenta.Text, txtPrecioVenta.Text);
        }
        private void Modificar()
        {
            MessageBox.Show(detalleCat.Modificar(txtIdDetalleNota.Text, txtCantidad.Text, txtIdArticulo.Text, txtIdNotaVenta.Text, txtPrecioVenta.Text), "Aviso");
        }
        private void Eliminar()
        {
            MessageBox.Show(detalleCat.Desactivar(txtIdDetalleNota.Text), "Aviso");
        }
        private void CargarEncabezadoNota(int idEncabezadoNota)
        {
            DgvEncabezadoNota encabezado = encabezadoCat.BuscarPorId(idEncabezadoNota);
            if (encabezado != null)
            {
                txtIdNotaVenta.Text = encabezado.Id.ToString();
                lblNombreCliente.Text = encabezado.Cliente;
                txtComentario.Text = encabezado.Comentario;
                lblFechaCreacion.Text = encabezado.FechaCreado.ToShortDateString();
                lblStatus.Text = encabezado.Status;
                lblTipoPago.Text = encabezado.TipoPago;
                SetDgv();
                ModoBusquedaDetalle();
            }
            else
            {
                MessageBox.Show("No se encontró el encabezado de nota de venta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion
        #region Metodos de comportamiento del formulario
        private void ModoEdicionDetalle()
        {
            txtIdDetalleNota.Enabled = false;
            txtIdArticulo.Enabled = false;
            txtPrecioVenta.Enabled = true;
            txtDescripcion.Enabled = false;
            txtCantidad.Enabled = true;
            btnBuscar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }
        private void ModoBusquedaDetalle()
        {
            txtIdDetalleNota.Enabled = true;
            txtIdArticulo.Enabled = true;
            txtPrecioVenta.Enabled = true;
            txtDescripcion.Enabled = true;
            txtCantidad.Enabled = true;
            btnBuscar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        private void ModoBusquedaEncabezado()
        {
            txtIdDetalleNota.Enabled = false;
            txtIdArticulo.Enabled = false;
            txtPrecioVenta.Enabled = false;
            txtDescripcion.Enabled = false;
            txtCantidad.Enabled = false;
            btnBuscar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        private void LimpiarDetalle()
        {
            txtIdDetalleNota.Text = "";
            txtIdArticulo.Text = "";
            txtCantidad.Text = "";
            txtPrecioVenta.Text = "";
            txtDescripcion.Text = "";
            lblTotalArticulo.Text = "";
        }
        private void LimpiarEncabezado()
        {
            LimpiarDetalle();
            txtIdNotaVenta.Text = "";
            lblNombreCliente.Text = "";
            lblTipoPago.Text = "";
            lblStatus.Text = "";
            txtComentario.Text = "";
            lblFechaCreacion.Text = "";
        }
        #endregion
        #region Metodos de componentes del formulario
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            SetDgv();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
            LimpiarDetalle();
            ModoBusquedaDetalle();
            SetDgv();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            LimpiarDetalle();
            ModoBusquedaDetalle();
            SetDgv();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarDetalle();
            ModoBusquedaDetalle();
            SetDgv();
        }

        private void DgvDetalleNota_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvDetalleNota.Rows[e.RowIndex];
            txtIdArticulo.Text = row.Cells["IdArticulo"].Value.ToString();
            txtIdDetalleNota.Text = row.Cells["IdDetalleNota"].Value.ToString();
            txtDescripcion.Text = row.Cells["Articulo"].Value.ToString();
            txtPrecioVenta.Text = row.Cells["PrecioVenta"].Value.ToString();
            txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
            lblTotalArticulo.Text = $"${Convert.ToDecimal(row.Cells["Total"].Value):###,###.##}";
            ModoEdicionDetalle();
        }

        private void BtnBuscarNotaVenta_Click(object sender, EventArgs e)
        {
            FrmBuscarEncabezado frmBuscar = new FrmBuscarEncabezado();
            frmBuscar.FormClosing += FrmBuscar_FormClosing;
            frmBuscar.ShowDialog();
        }

        private void FrmBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmBuscarEncabezado frmEncabezado = sender as FrmBuscarEncabezado;
            LimpiarDetalle();
            CargarEncabezadoNota(frmEncabezado.IdEncabezado);
        }

        private void TxtIdNotaVenta_Leave(object sender, EventArgs e)
        {
            if(int.TryParse(txtIdNotaVenta.Text, out int id))
            {
                CargarEncabezadoNota(id);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de limpiar todo? si tiene datos modificándose, estos se perderán.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                LimpiarEncabezado();
                ModoBusquedaEncabezado();
            }
            
        }
        #endregion


    }
}
