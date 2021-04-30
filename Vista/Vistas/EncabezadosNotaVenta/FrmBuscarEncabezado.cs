using Controladores.Catalogos;
using Datos.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Vistas.EncabezadosNotaVenta
{
    public partial class FrmBuscarEncabezado : Form
    {
        private readonly TiposPagoCatalogoController tiposPagoCat;
        private readonly EncabezadosNotaCatalogoController encabezadosCat;
        public int IdEncabezado { get; set; }
        public FrmBuscarEncabezado()
        {
            tiposPagoCat = new TiposPagoCatalogoController();
            encabezadosCat = new EncabezadosNotaCatalogoController();
            InitializeComponent();
            SetCmbTipoPago();
            SetDgv();
        }
        #region interacción de datos
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
        private void SetDgv()
        {
            ComboBoxItem comboBoxItem = GetCmbTipoPago();
            string cmbitemId = "";
            dgvEncabezados.DataSource = null;
            if (comboBoxItem != null)
            {
                cmbitemId = comboBoxItem.Value.ToString();
            }
            dgvEncabezados.DataSource = encabezadosCat.ListarDgvEncabezadoNota(txtId.Text, "", null, txtIdCliente.Text, cmbitemId, cmbStatus.SelectedItem != null ? cmbStatus.SelectedItem.ToString() : "");
        }
        #endregion

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            SetDgv();
        }

        private void DgvEncabezados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdEncabezado = Convert.ToInt32(dgvEncabezados.Rows[e.RowIndex].Cells["Id"].Value);
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtIdCliente.Text = "";
            txtNombreCliente.Text = "";
            cmbStatus.SelectedItem = null;
            SetCmbTipoPago();
            SetDgv();
        }
    }
}
